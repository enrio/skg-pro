#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 25/01/2012 21:07
 * Update: 25/01/2012 21:07
 * Status: OK
 */
#endregion

using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.Server
{
    using SKG.SMS;

    /// <summary>
    /// SMS application
    /// </summary>
    public partial class FrmTestSms : Form
    {
        #region Constructor
        public FrmTestSms()
        {
            InitializeComponent();
        }
        #endregion

        #region Private variables
        SerialPort port = new SerialPort();
        Sms objclsSMS = new Sms();
        Messages objShortMessageCollection = new Messages();
        #endregion

        private void WriteStatusBar(string status)
        {
            try { statusBar1.Text = "Message: " + status; }
            catch { return; }
        }

        #region Private Events
        private void FrmTestSMS_Load(object sender, EventArgs e)
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();

                // Auto detect COM port
                foreach (var p in ports)
                {
                    port = objclsSMS.OpenPort(p, Convert.ToInt32(cboBaudRate.Text),
                    Convert.ToInt32(cboDataBits.Text), Convert.ToInt32(txtReadTimeOut.Text),
                    Convert.ToInt32(txtWriteTimeOut.Text));

                    var ok = objclsSMS.AutoDetect(port);
                    if (ok > -1)
                    {
                        cboPortName.Text = port.PortName;
                        port.Close();
                    }
                }

                // Add all port names to the combo box:
                foreach (string port in ports) cboPortName.Items.Add(port);

                //Remove tab pages
                tabSMSapplication.TabPages.Remove(tbSendSMS);
                tabSMSapplication.TabPages.Remove(tbReadSMS);
                tabSMSapplication.TabPages.Remove(tbDeleteSMS);

                btnDisconnect.Enabled = false;
            }
            catch (Exception ex) { ErrorLog(ex.Message); }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //Open communication port 
                port = objclsSMS.OpenPort(cboPortName.Text, Convert.ToInt32(cboBaudRate.Text),
                    Convert.ToInt32(cboDataBits.Text), Convert.ToInt32(txtReadTimeOut.Text),
                    Convert.ToInt32(txtWriteTimeOut.Text));

                if (port != null)
                {
                    gboPortSettings.Enabled = false;
                    this.statusBar1.Text = "Modem is connected at PORT " + cboPortName.Text;

                    //Add tab pages
                    tabSMSapplication.TabPages.Add(tbSendSMS);
                    tabSMSapplication.TabPages.Add(tbReadSMS);
                    tabSMSapplication.TabPages.Add(tbDeleteSMS);

                    lblConnectionStatus.Text = "Connected at " + cboPortName.Text;
                    btnDisconnect.Enabled = true;
                }
                else statusBar1.Text = "Invalid port settings";
            }
            catch (Exception ex) { ErrorLog(ex.Message); }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                gboPortSettings.Enabled = true;
                objclsSMS.ClosePort(this.port);

                //Remove tab pages
                tabSMSapplication.TabPages.Remove(tbSendSMS);
                tabSMSapplication.TabPages.Remove(tbReadSMS);
                tabSMSapplication.TabPages.Remove(tbDeleteSMS);

                lblConnectionStatus.Text = "Not Connected";
                btnDisconnect.Enabled = false;

            }
            catch (Exception ex) { ErrorLog(ex.Message); }
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                if (objclsSMS.SendMsg(port, txtSIM.Text, txtMessage.Text))
                    statusBar1.Text = "Message has sent successfully";
                else this.statusBar1.Text = "Failed to send message";
            }
            catch (Exception ex) { ErrorLog(ex.Message); }
        }

        private void btnReadSMS_Click(object sender, EventArgs e)
        {
            try
            {
                int uCountSMS = objclsSMS.CountMsg(port);
                if (uCountSMS > 0)
                {
                    string strCommand = "";
                    if (this.rbReadAll.Checked) strCommand = "AT+CMGL=\"ALL\"";
                    else if (rbReadUnRead.Checked) strCommand = "AT+CMGL=\"REC UNREAD\"";
                    else if (rbReadStoreSent.Checked) strCommand = "AT+CMGL=\"STO SENT\"";
                    else if (rbReadStoreUnSent.Checked) strCommand = "AT+CMGL=\"STO UNSENT\"";

                    objShortMessageCollection = objclsSMS.ReadMsg(port, strCommand);
                    foreach (Message msg in objShortMessageCollection)
                    {
                        var tmp = new string[] { msg.Index, msg.Sent, msg.Sender, msg.Content };
                        var item = new ListViewItem(tmp) { Tag = msg };
                        lvwMessages.Items.Add(item);
                    }
                }
                else
                {
                    lvwMessages.Clear();
                    statusBar1.Text = "There is no message in SIM";
                }
            }
            catch (Exception ex) { ErrorLog(ex.Message); }
        }

        private void btnDeleteSMS_Click(object sender, EventArgs e)
        {
            try
            {
                // Count SMS 
                int uCountSMS = objclsSMS.CountMsg(port);
                if (uCountSMS > 0)
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to delete the SMS?",
                        "Delete confirmation", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No) return;

                    if (this.rbDeleteAllSMS.Checked)
                    {
                        if (objclsSMS.DeleteMsg(port, "AT+CMGD=1,4"))
                            statusBar1.Text = "Messages has deleted successfuly";
                        else statusBar1.Text = "Failed to delete messages";
                    }
                    else if (rbDeleteReadSMS.Checked)
                    {
                        if (objclsSMS.DeleteMsg(port, "AT+CMGD=1,3"))
                            statusBar1.Text = "Messages has deleted successfuly";
                        else this.statusBar1.Text = "Failed to delete messages";
                    }
                }
            }
            catch (Exception ex) { ErrorLog(ex.Message); }
        }

        private void btnCountSMS_Click(object sender, EventArgs e)
        {
            try
            {
                //Count SMS
                int uCountSMS = objclsSMS.CountMsg(this.port);
                this.txtCountSMS.Text = uCountSMS.ToString();
            }
            catch (Exception ex) { ErrorLog(ex.Message); }
        }
        #endregion

        #region Error Log
        public void ErrorLog(string Message)
        {
            StreamWriter sw = null;
            try
            {
                WriteStatusBar(Message);

                var sLogFormat = String.Format("{0} {1} ==> ", DateTime.Now.ToShortDateString(),
                    DateTime.Now.ToLongTimeString());
                var sPathName = @"SMSapplicationErrorLog_";

                string sYear = DateTime.Now.Year.ToString();
                string sMonth = DateTime.Now.Month.ToString();
                string sDay = DateTime.Now.Day.ToString();

                string sErrorTime = String.Format("{0}-{1}-{2}", sDay, sMonth, sYear);
                sw = new StreamWriter(String.Format("{0}{1}.txt", sPathName, sErrorTime), true);

                sw.WriteLine(sLogFormat + Message);
                sw.Flush();
            }
            catch { return; }
            finally
            {
                if (sw != null)
                {
                    sw.Dispose();
                    sw.Close();
                }
            }
        }
        #endregion
    }
}