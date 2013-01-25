using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

namespace SMSapplication
{
    /// <summary>
    /// Sms for xSKGv1
    /// </summary>
    public class Sms : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) { }
        }

        ~Sms() { Dispose(false); }

        #region Open and close ports
        /// <summary>
        /// Open Port
        /// </summary>
        /// <param name="portName">Port name</param>
        /// <param name="baudRate">Baud rate</param>
        /// <param name="dataBits">Data bits</param>
        /// <param name="readTimeout">Read timeout</param>
        /// <param name="writeTimeout">Write timeout</param>
        /// <returns></returns>
        public SerialPort OpenPort(string portName, int baudRate, int dataBits, int readTimeout, int writeTimeout)
        {
            receiveNow = new AutoResetEvent(false);
            var port = new SerialPort();

            try
            {
                port.PortName = portName;           // COM1
                port.BaudRate = baudRate;           // 9600
                port.DataBits = dataBits;           // 8
                port.StopBits = StopBits.One;       // 1
                port.Parity = Parity.None;          // None
                port.ReadTimeout = readTimeout;     // 300
                port.WriteTimeout = writeTimeout;   // 300
                port.Encoding = Encoding.GetEncoding("iso-8859-1");
                port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                port.Open();
                port.DtrEnable = true;
                port.RtsEnable = true;
            }
            catch (Exception ex) { throw ex; }
            return port;
        }

        /// <summary>
        /// Close port
        /// </summary>
        /// <param name="port">Port</param>
        public void ClosePort(SerialPort port)
        {
            try
            {
                port.Close();
                port.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
                port = null;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        /// <summary>
        /// Execute AT command
        /// </summary>
        /// <param name="port">Port</param>
        /// <param name="command">AT command</param>
        /// <param name="responseTimeout">Response timeout</param>
        /// <param name="errorMessage">Error message</param>
        /// <returns></returns>
        public string ExecCommand(SerialPort port, string command, int responseTimeout, string errorMessage)
        {
            try
            {
                port.DiscardOutBuffer();
                port.DiscardInBuffer();
                receiveNow.Reset();
                port.Write(command + "\r");

                string input = ReadResponse(port, responseTimeout);
                if ((input.Length == 0) || ((!input.EndsWith("\r\n> ")) && (!input.EndsWith("\r\nOK\r\n"))))
                    throw new ApplicationException("No success message was received.");
                return input;
            }
            catch (Exception ex) { throw ex; }
        }

        /// <summary>
        /// Receive data from port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars) receiveNow.Set();
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
            string buffer = string.Empty;
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
                        if (buffer.Length > 0)
                            throw new ApplicationException("Response received is incomplete.");
                        else
                            throw new ApplicationException("No data received from phone.");
                    }
                }
                while (!buffer.EndsWith("\r\nOK\r\n") && !buffer.EndsWith("\r\n> ") && !buffer.EndsWith("\r\nERROR\r\n"));
            }
            catch (Exception ex) { throw ex; }
            return buffer;
        }

        /// <summary>
        /// Count SMS
        /// </summary>
        /// <param name="port">Port</param>
        /// <returns></returns>
        public int CountSMSmessages(SerialPort port)
        {
            int countTotalMessages = 0;
            try
            {
                #region Execute command
                string recievedData = ExecCommand(port, "AT", 300, "No phone connected at ");
                recievedData = ExecCommand(port, "AT+CMGF=1", 300, "Failed to set message format.");

                const string command = "AT+CPMS?";
                recievedData = ExecCommand(port, command, 1000, "Failed to count SMS message");
                int uReceivedDataLength = recievedData.Length;
                #endregion

                #region If command is executed successfully
                if ((recievedData.Length >= 45) && (recievedData.StartsWith("AT+CPMS?")))
                {
                    #region Parsing SMS
                    string[] strSplit = recievedData.Split(',');
                    string strMessageStorageArea1 = strSplit[0];     // SM
                    string strMessageExist1 = strSplit[1];           // Msgs exist in SM
                    #endregion

                    countTotalMessages = Convert.ToInt32(strMessageExist1); // count total number of SMS in SIM
                }
                #endregion

                #region If command is not executed successfully
                else if (recievedData.Contains("ERROR"))
                {
                    #region Error in counting total number of SMS
                    string recievedError = recievedData;
                    recievedError = recievedError.Trim();
                    recievedData = "Following error occured while counting the message" + recievedError;
                    #endregion

                }
                #endregion

                return countTotalMessages;
            }
            catch (Exception ex) { throw ex; }
        }

        #region Read SMS
        public AutoResetEvent receiveNow;
        /// <summary>
        /// Read SMS
        /// </summary>
        /// <param name="port">port</param>
        /// <param name="command">AT command</param>
        /// <returns></returns>
        public ShortMessageCollection ReadSMS(SerialPort port, string command)
        {
            // Set up the phone and read the messages
            ShortMessageCollection messages = null;
            try
            {
                #region Execute Command
                // Check connection
                ExecCommand(port, "AT", 300, "No phone connected");
                // Use message format "Text mode"

                ExecCommand(port, "AT+CMGF=1", 300, "Failed to set message format.");

                // Use character set "PCCP437"
                ExecCommand(port, "AT+CSCS=\"PCCP437\"", 300, "Failed to set character set.");

                // Select SIM storage
                ExecCommand(port, "AT+CPMS=\"SM\"", 300, "Failed to select message storage.");

                // Read the messages
                string input = ExecCommand(port, command, 5000, "Failed to read the messages.");
                #endregion

                messages = ParseMessages(input); // parse messages
            }
            catch (Exception ex) { throw ex; }

            if (messages != null) return messages;
            return null;
        }

        /// <summary>
        /// Parse messages
        /// </summary>
        /// <param name="input">Data input</param>
        /// <returns></returns>
        public ShortMessageCollection ParseMessages(string input)
        {
            var messages = new ShortMessageCollection();
            try
            {
                var r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n");
                var m = r.Match(input);

                while (m.Success)
                {
                    var msg = new ShortMessage
                    {
                        Index = m.Groups[1].Value,
                        Status = m.Groups[2].Value,
                        Sender = m.Groups[3].Value,
                        Alphabet = m.Groups[4].Value,
                        Sent = m.Groups[5].Value,
                        Message = m.Groups[6].Value
                    };

                    messages.Add(msg);
                    m = m.NextMatch();
                }
            }
            catch (Exception ex) { throw ex; }

            return messages;
        }
        #endregion

        #region Send SMS
        static AutoResetEvent readNow = new AutoResetEvent(false);
        /// <summary>
        /// Send SMS
        /// </summary>
        /// <param name="port">Port</param>
        /// <param name="phoneNo">Phone number</param>
        /// <param name="message">Message</param>
        /// <returns></returns>
        public bool sendMsg(SerialPort port, string phoneNo, string message)
        {
            bool isSend = false;
            try
            {
                string recievedData = ExecCommand(port, "AT", 300, "No phone connected");
                recievedData = ExecCommand(port, "AT+CMGF=1", 300, "Failed to set message format.");

                var command = String.Format("AT+CMGS=\"{0}\"", phoneNo);
                recievedData = ExecCommand(port, command, 300, "Failed to accept phoneNo");

                command = String.Format("{0}{1}\r", message, Char.ConvertFromUtf32(26));
                recievedData = ExecCommand(port, command, 3000, "Failed to send message"); //3 seconds

                if (recievedData.EndsWith("\r\nOK\r\n")) isSend = true;
                else if (recievedData.Contains("ERROR")) isSend = false;

                return isSend;
            }
            catch (Exception ex) { throw ex; }
        }

        static void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars) readNow.Set();
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region Delete SMS
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
                #region Execute command
                var recievedData = ExecCommand(port, "AT", 300, "No phone connected");
                recievedData = ExecCommand(port, "AT+CMGF=1", 300, "Failed to set message format.");

                var cmd = command;
                recievedData = ExecCommand(port, cmd, 300, "Failed to delete message");
                #endregion

                if (recievedData.EndsWith("\r\nOK\r\n")) isDeleted = true;
                if (recievedData.Contains("ERROR")) isDeleted = false;

                return isDeleted;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion
    }
}