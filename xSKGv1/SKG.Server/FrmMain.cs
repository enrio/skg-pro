using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SKG.Server
{
    using System.IO.Ports;
    using System.Threading;

    public partial class FrmMain : Form
    {
        private const string STR_RN = "\r\n> ";
        private const string STR_ERROR = "\r\nERROR\r\n";
        private const string STR_OK = "\r\nOK\r\n";

        public AutoResetEvent receiveNow;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void srpMain_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        void OpenPort()
        {
        }

        void ClosePort()
        {
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
    }
}