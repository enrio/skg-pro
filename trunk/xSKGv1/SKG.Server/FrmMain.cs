﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SKG.Server
{
    using SKG.SMS;
    using System.IO.Ports;
    using System.Threading;
    using System.Text.RegularExpressions;

    public partial class FrmMain : Form
    {
        private const string STR_RN = "\r\n> ";
        private const string STR_ERROR = "\r\nERROR\r\n";
        private const string STR_OK = "\r\nOK\r\n";

        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Receive data from port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void srpMain_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars) receiveNow.Set();
            }
            catch (Exception ex) { throw ex; }
        }

        void OpenPort()
        {
            receiveNow = new AutoResetEvent(false);            
            try
            {
                srpMain.PortName = "COM1";
                srpMain.BaudRate = 9600;
                srpMain.DataBits = 8;
                srpMain.StopBits = StopBits.One;
                srpMain.Parity = Parity.None;
                srpMain.ReadTimeout = 300;
                srpMain.WriteTimeout = 300;

                srpMain.DataReceived += new SerialDataReceivedEventHandler(srpMain_DataReceived);
                srpMain.Open();
                srpMain.DtrEnable = true;
                srpMain.RtsEnable = true;
            }
            catch (Exception ex) { throw ex; }            
        }

        void ClosePort()
        {
            try
            {
                srpMain.Close();
                srpMain.DataReceived -= new SerialDataReceivedEventHandler(srpMain_DataReceived);
                srpMain = null;
            }
            catch (Exception ex) { throw ex; }
        }

        #region AT command
        /// <summary>
        /// Execute AT command
        /// </summary>
        /// <param name="port">Port</param>
        /// <param name="command">AT command</param>
        /// <param name="responseTimeout">Response timeout</param>
        /// <returns></returns>
        public string ExecCommand(SerialPort port, string command, int responseTimeout)
        {
            try
            {
                port.DiscardOutBuffer();
                port.DiscardInBuffer();
                receiveNow.Reset();
                port.Write(command + "\r");

                string input = ReadResponse(port, responseTimeout);
                if ((input.Length == 0) || ((!input.EndsWith(STR_RN)) && (!input.EndsWith(STR_OK))))
                    throw new ApplicationException("No success message was received.");
                return input;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Read response
        /// </summary>
        /// <param name="port">Port</param>
        /// <param name="timeout">Timeout</param>
        /// <returns></returns>
        public string ReadResponse(SerialPort port, int timeout)
        {
            string buffer = "";
            try
            {
                do
                {
                    if (receiveNow.WaitOne(timeout, false))
                    {
                        string t = port.ReadExisting();
                        buffer += t;
                    }
                    else
                    {
                        if (buffer.Length > 0) throw new ApplicationException("Response received is incomplete.");
                        else throw new ApplicationException("No data received from phone.");
                    }
                }
                while (!buffer.EndsWith(STR_OK) && !buffer.EndsWith(STR_RN) && !buffer.EndsWith(STR_ERROR));
            }
            catch (Exception ex) { throw ex; }
            return buffer;
        }

        /// <summary>
        /// Count SMS
        /// </summary>
        /// <param name="port">Port</param>
        /// <returns></returns>
        public int CountMsg(SerialPort port)
        {
            int countTotalMessages = 0;
            try
            {
                #region Execute command
                string recievedData = ExecCommand(port, "AT", 300);
                recievedData = ExecCommand(port, "AT+CMGF=1", 300);

                const string command = "AT+CPMS?";
                recievedData = ExecCommand(port, command, 1000);
                #endregion

                //if ((recievedData.Length >= 45) && (recievedData.StartsWith("AT+CPMS?")))
                if ((recievedData.Length >= 45))
                {
                    string[] strSplit = recievedData.Split(',');
                    //string strMessageStorageArea1 = strSplit[0];     // SM
                    string strMessageExist1 = strSplit[1];           // Msgs exist in SM
                    countTotalMessages = Convert.ToInt32(strMessageExist1); // count total number of SMS in SIM
                }
                else if (recievedData.Contains("ERROR"))
                {
                    string recievedError = recievedData;
                    recievedError = recievedError.Trim();
                    recievedData = "Following error occured while counting the message " + recievedError;
                }

                return countTotalMessages;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Read, Send & Delete SMS
        AutoResetEvent receiveNow;
        static AutoResetEvent readNow = new AutoResetEvent(false);

        /// <summary>
        /// Read SMS
        /// </summary>
        /// <param name="port">port</param>
        /// <param name="command">AT command</param>
        /// <returns></returns>
        public Messages ReadMsg(SerialPort port, string command)
        {
            // Set up the phone and read the messages
            Messages messages = null;
            try
            {
                #region Execute Command
                ExecCommand(port, "AT", 300); // check connection
                ExecCommand(port, "AT+CMGF=1", 300); // use message format "Text mode"

                //ExecCommand(port, "AT+CSCS=\"PCCP437\"", 300); // use character set "PCCP437"
                ExecCommand(port, "AT+CPMS=\"SM\"", 300); // select SIM storage

                string input = ExecCommand(port, command, 5000); // read the messages
                #endregion

                messages = ParseMsg(input); // parse messages
            }
            catch (Exception ex) { throw ex; }

            if (messages != null) return messages;
            return null;
        }

        /// <summary>
        /// Send SMS
        /// </summary>
        /// <param name="port">Port</param>
        /// <param name="phoneNo">Phone number</param>
        /// <param name="message">Message</param>
        /// <returns></returns>
        public bool SendMsg(SerialPort port, string phoneNo, string message)
        {
            bool isSend = false;
            try
            {
                string recievedData = ExecCommand(port, "AT", 300);
                recievedData = ExecCommand(port, "AT+CMGF=1", 300);

                var command = String.Format("AT+CMGS=\"{0}\"", phoneNo);
                recievedData = ExecCommand(port, command, 300);

                command = String.Format("{0}{1}\r", message, Char.ConvertFromUtf32(26));
                recievedData = ExecCommand(port, command, 3000); //3 seconds

                if (recievedData.EndsWith(STR_OK)) isSend = true;
                else if (recievedData.Contains("ERROR")) isSend = false;

                return isSend;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Delete SMS
        /// </summary>
        /// <param name="port">Port</param>
        /// <param name="command">AT command</param>
        /// <returns></returns>
        public bool DeleteMsg(SerialPort port, string command)
        {
            bool isDeleted = false;
            try
            {
                var recievedData = ExecCommand(port, "AT", 300);
                recievedData = ExecCommand(port, "AT+CMGF=1", 300);
                var cmd = command;
                recievedData = ExecCommand(port, cmd, 300);

                if (recievedData.EndsWith(STR_OK)) isDeleted = true;
                if (recievedData.Contains("ERROR")) isDeleted = false;

                return isDeleted;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        /// <summary>
        /// Parse messages
        /// </summary>
        /// <param name="input">Data input</param>
        /// <returns></returns>
        public Messages ParseMsg(string input)
        {
            var messages = new Messages();
            try
            {
                var r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n");
                var m = r.Match(input);

                while (m.Success)
                {
                    var msg = new Message
                    {
                        Index = m.Groups[1].Value,
                        Status = m.Groups[2].Value,
                        Sender = m.Groups[3].Value,
                        Alphabet = m.Groups[4].Value,
                        Sent = m.Groups[5].Value,
                        Content = m.Groups[6].Value
                    };

                    messages.Add(msg);
                    m = m.NextMatch();
                }
            }
            catch (Exception ex) { throw ex; }

            return messages;
        }

        /// <summary>
        /// Auto detect COM port
        /// </summary>
        /// <param name="port">COM port</param>
        /// <param name="timeout">Timeout</param>
        /// <returns></returns>
        public int AutoDetect(SerialPort port)
        {
            int countTotalMessages = 0;
            try
            {
                #region Execute command
                string recievedData = ExecCommand(port, "AT", 300);
                recievedData = ExecCommand(port, "AT+CMGF=1", 300);

                const string command = "AT+CPMS?";
                recievedData = ExecCommand(port, command, 1000);
                #endregion

                //if ((recievedData.Length >= 45) && (recievedData.StartsWith("AT+CPMS?")))
                if ((recievedData.Length >= 45))
                {
                    string[] strSplit = recievedData.Split(',');
                    //string strMessageStorageArea1 = strSplit[0];     // SM
                    string strMessageExist1 = strSplit[1];           // Msgs exist in SM
                    countTotalMessages = Convert.ToInt32(strMessageExist1); // count total number of SMS in SIM
                }
                else if (recievedData.Contains("ERROR"))
                {
                    string recievedError = recievedData;
                    recievedError = recievedError.Trim();
                    recievedData = "Following error occured while counting the message " + recievedError;
                }

                return countTotalMessages;
            }
            catch { return -1; }
        }
    }
}