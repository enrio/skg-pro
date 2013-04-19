using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.Server
{
    using SKG.SMS;
    using SKG.BLL;
    using SKG.Extend;
    using System.IO.Ports;
    using System.Threading;
    using System.Text.RegularExpressions;

    public partial class FrmMain : Form
    {
        private const string STR_RN = "\r\n> ";
        private const string STR_ERROR = "\r\nERROR\r\n";
        private const string STR_OK = "\r\nOK\r\n";

        AutoResetEvent receiveNow;
        string port;
        BaseBLL _bll = new BaseBLL();

        public FrmMain()
        {
            InitializeComponent();

            port = AutoDetect();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            OpenPort();
        }

        /// <summary>
        /// Receive data from port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                if (e.EventType == SerialData.Chars)
                    receiveNow.Set();
            }
            catch (Exception ex) { throw ex; }
        }

        void OpenPort()
        {
            if (srpMain == null)
            {
                srpMain = new SerialPort();
            }
            if (srpMain.IsOpen) return;

            receiveNow = new AutoResetEvent(false);
            try
            {
                srpMain.PortName = port;
                srpMain.BaudRate = 9600;
                srpMain.DataBits = 8;
                srpMain.StopBits = StopBits.One;
                srpMain.Parity = Parity.None;
                srpMain.ReadTimeout = 300;
                srpMain.WriteTimeout = 300;

                srpMain.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
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
                srpMain.DataReceived -= new SerialDataReceivedEventHandler(DataReceived);
                srpMain = null;
            }
            catch (Exception ex) { return; }
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
            catch (Exception ex) { return 0; }
        }
        #endregion

        #region Read, Send & Delete SMS
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
            catch { return false; }
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

        private void btnAutoSendReceive_Click(object sender, EventArgs e)
        {
            OpenPort();

            int uCountSMS = CountMsg(srpMain);
            if (uCountSMS > 0)
            {
                listView1.Clear();
                var at = "AT+CMGL=\"ALL\"";
                at = "AT+CMGL=\"REC UNREAD\"";

                var objShortMessageCollection = ReadMsg(srpMain, at);
                _bll = new BaseBLL();

                foreach (Message msg in objShortMessageCollection)
                {
                    var tmp = new string[] { msg.Index, msg.Sent, msg.Sender, msg.Content };
                    var item = new ListViewItem(tmp) { Tag = msg };
                    listView1.Items.Add(item);

                    var noidung = "";
                    decimal sum = 0;

                    var content = msg.Content.Trim();
                    content = content.ToUpper();
                    var ct = content.Split(new char[] { ' ' });

                    // Kiểm tra số điện thoại gởi tới có có quyền truy vấn thông tin không
                    var usr = _bll.Pol_User.SelectByPhone(msg.Sender);
                    var sai = "Khong tim thay nguoi su dung co so dien thoai nay!";

                    if (usr == null)
                    {
                        SendMsg(srpMain, msg.Sender, sai);
                        continue;
                    }

                    usr.Name = usr.Name.RemoveVN();
                    sai = "Sai cu phap; cu phap la DT, DTCD, DTVL, vidu: DT dd/MM/yyyy";

                    var ok = usr.CheckRole("TS");
                    ok = ok || usr.CheckRole("QT");
                    ok = ok || usr.CheckRole("QL");
                    ok = ok || usr.CheckRole("CR");

                    if (!ok)
                    {
                        noidung = usr.Name + " khong co quyen!";
                        SendMsg(srpMain, msg.Sender, noidung);
                        continue;
                    };

                    if (ct.Length < 2)
                    {
                        SendMsg(srpMain, msg.Sender, String.Format("{0}. Cam on {1}!", sai, usr.Name));
                        continue;
                    }

                    switch (ct[0])
                    {
                        case "DTCD":
                            content = content.Replace("DTCD", "").Trim();
                            var s = content.Split(new char[] { '/' });

                            if (s.Length > 2) // doanh thu theo ngay
                            {
                                var d = s[0].ToInt32();
                                var m = s[1].ToInt32();
                                var y = s[2].ToInt32();
                                var dt = new DateTime(y, m, d);
                                _bll.Tra_Detail.SumarySalesDay(out sum, Summary.AreaFixed, dt);
                                noidung = String.Format("Doanh thu xe CD ngay {0} la {1:#,0}", content, sum);
                            }
                            else if (s.Length > 1) // doanh thu theo thang
                            {
                                var m = s[0].ToInt32();
                                var y = s[1].ToInt32();
                                var dt = new DateTime(y, m, 1);
                                _bll.Tra_Detail.SumarySalesMonth(out sum, Summary.AreaFixed, dt);
                                noidung = String.Format("Doanh thu xe CD thang {0}/{1} la {2:#,0}", m, y, sum);
                            }
                            else if (s.Length > 0) // doanh thu theo nam
                            {
                                var y = s[0].ToInt32();
                                var dt = new DateTime(y, 1, 1);
                                _bll.Tra_Detail.SumarySalesYear(out sum, Summary.AreaFixed, dt);
                                noidung = String.Format("Doanh thu xe CD nam {0} la {1:#,0}", y, sum);
                            }
                            else noidung = sai;
                            break;

                        case "DTVL":
                            content = content.Replace("DTVL", "").Trim();
                            s = content.Split(new char[] { '/' });

                            if (s.Length > 2) // doanh thu theo ngay
                            {
                                var d = s[0].ToInt32();
                                var m = s[1].ToInt32();
                                var y = s[2].ToInt32();
                                var dt = new DateTime(y, m, d);
                                _bll.Tra_Detail.SumarySalesDay(out sum, Summary.KindNormal, dt);
                                noidung = String.Format("Doanh thu xe VL ngay {0} la {1:#,0}", content, sum);
                            }
                            else if (s.Length > 1) // doanh thu theo thang
                            {
                                var m = s[0].ToInt32();
                                var y = s[1].ToInt32();
                                var dt = new DateTime(y, m, 1);
                                _bll.Tra_Detail.SumarySalesMonth(out sum, Summary.KindNormal, dt);
                                noidung = String.Format("Doanh thu xe VL thang {0}/{1} la {2:#,0}", m, y, sum);
                            }
                            else if (s.Length > 0) // doanh thu theo nam
                            {
                                var y = s[0].ToInt32();
                                var dt = new DateTime(y, 1, 1);
                                _bll.Tra_Detail.SumarySalesYear(out sum, Summary.KindNormal, dt);
                                noidung = String.Format("Doanh thu xe VL nam {0} la {1:#,0}", y, sum);
                            }
                            else noidung = sai;
                            break;

                        case "DT":
                            content = content.Replace("DT", "").Trim();
                            s = content.Split(new char[] { '/' });

                            if (s.Length > 2) // doanh thu theo ngay
                            {
                                var d = s[0].ToInt32();
                                var m = s[1].ToInt32();
                                var y = s[2].ToInt32();
                                var dt = new DateTime(y, m, d);
                                noidung = SumarySalesDay(content, dt);
                            }
                            else if (s.Length > 1) // doanh thu theo thang
                            {
                                var m = s[0].ToInt32();
                                var y = s[1].ToInt32();
                                var dt = new DateTime(y, m, 1);
                                noidung = SumarySalesMonth(content, dt);
                            }
                            else if (s.Length > 0) // doanh thu theo nam
                            {
                                var y = s[0].ToInt32();
                                var dt = new DateTime(y, 1, 1);
                                _bll.Tra_Detail.SumarySalesYear(out sum, Summary.Both, dt);
                                noidung = SumarySalesYear(content, dt);
                            }
                            else noidung = sai;
                            break;

                        default:
                            noidung = sai;
                            break;
                    }

                    SendMsg(srpMain, msg.Sender, String.Format("{0}. Cam on {1}!", noidung, usr.Name));
                }
            }

            ClosePort();
        }

        private void cboPortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            port = cboPortName.Text;
        }

        private void trmMain_Tick(object sender, EventArgs e)
        {
            btnAutoSendReceive_Click(null, null);
        }

        /// <summary>
        /// Auto detect COM port
        /// </summary>
        /// <returns></returns>
        string AutoDetect()
        {
            var sms = new Sms();
            var port = new SerialPort();
            var ports = SerialPort.GetPortNames();

            foreach (var p in ports)
            {
                port = sms.OpenPort(p, 9600, 8, 300, 300);
                var ok = sms.AutoDetect(port);

                if (ok > -1)
                {
                    cboPortName.Items.Add(p);
                    cboPortName.Text = p;

                    port.Close();
                }
            }

            return cboPortName.Text;
        }

        string SumarySalesDay(string content, DateTime dt)
        {
            decimal fix, nor, sum;
            _bll.Tra_Detail.SumarySalesDay(out fix, Summary.AreaFixed, dt);
            _bll.Tra_Detail.SumarySalesDay(out nor, Summary.KindNormal, dt);
            sum = fix + nor;
            var format = "Doanh thu {4} {0} la {1:#,0}; Xe CD = {2:#,0}; Xe VL = {3:#,0}";
            return String.Format(format, content, sum, fix, nor, "ngay");
        }

        string SumarySalesMonth(string content, DateTime dt)
        {
            decimal fix, nor, sum;
            _bll.Tra_Detail.SumarySalesMonth(out fix, Summary.AreaFixed, dt);
            _bll.Tra_Detail.SumarySalesMonth(out nor, Summary.KindNormal, dt);
            sum = fix + nor;
            var format = "Doanh thu {4} {0} la {1:#,0}; Xe CD = {2:#,0}; Xe VL = {3:#,0}";
            return String.Format(format, content, sum, fix, nor, "thang");
        }

        string SumarySalesYear(string content, DateTime dt)
        {
            decimal fix, nor, sum;
            _bll.Tra_Detail.SumarySalesYear(out fix, Summary.AreaFixed, dt);
            _bll.Tra_Detail.SumarySalesYear(out nor, Summary.KindNormal, dt);
            sum = fix + nor;
            var format = "Doanh thu {4} {0} la {1:#,0}; Xe CD = {2:#,0}; Xe VL = {3:#,0}";
            return String.Format(format, content, sum, fix, nor, "nam");
        }
    }
}