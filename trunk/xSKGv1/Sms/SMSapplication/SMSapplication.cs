/*
 * Created by: Syeda Anila Nusrat. 
 * Date: 1st August 2009
 * Time: 2:54 PM 
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace SMSapplication
{
    /// <summary>
    /// SMS application
    /// </summary>
    public partial class SMSapplication : Form
    {
        #region Constructor
        public SMSapplication()
        {
            InitializeComponent();
        }
        #endregion

        #region Private variables
        SerialPort port = new SerialPort();
        Sms objclsSMS = new Sms();
        ShortMessageCollection objShortMessageCollection = new ShortMessageCollection();
        #endregion

        private void WriteStatusBar(string status)
        {
            try
            {
                statusBar1.Text = "Message: " + status;
            }
            catch { return; }
        }

        #region Private Events
        private void SMSapplication_Load(object sender, EventArgs e)
        {
            try
            {
                #region Display all available COM Ports
                string[] ports = SerialPort.GetPortNames();

                // Add all port names to the combo box:
                foreach (string port in ports)
                {
                    this.cboPortName.Items.Add(port);
                }
                #endregion

                //Remove tab pages
                this.tabSMSapplication.TabPages.Remove(tbSendSMS);
                this.tabSMSapplication.TabPages.Remove(tbReadSMS);
                this.tabSMSapplication.TabPages.Remove(tbDeleteSMS);

                this.btnDisconnect.Enabled = false;
            }
            catch (Exception ex) { ErrorLog(ex.Message); }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //Open communication port 
                this.port = objclsSMS.OpenPort(cboPortName.Text, Convert.ToInt32(cboBaudRate.Text),
                    Convert.ToInt32(cboDataBits.Text), Convert.ToInt32(txtReadTimeOut.Text),
                    Convert.ToInt32(txtWriteTimeOut.Text));

                if (this.port != null)
                {
                    this.gboPortSettings.Enabled = false;

                    //MessageBox.Show("Modem is connected at PORT " + this.cboPortName.Text);
                    this.statusBar1.Text = "Modem is connected at PORT " + cboPortName.Text;

                    //Add tab pages
                    this.tabSMSapplication.TabPages.Add(tbSendSMS);
                    this.tabSMSapplication.TabPages.Add(tbReadSMS);
                    this.tabSMSapplication.TabPages.Add(tbDeleteSMS);

                    this.lblConnectionStatus.Text = "Connected at " + cboPortName.Text;
                    this.btnDisconnect.Enabled = true;
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
                if (objclsSMS.sendMsg(this.port, this.txtSIM.Text, this.txtMessage.Text))
                    statusBar1.Text = "Message has sent successfully";
                else this.statusBar1.Text = "Failed to send message";
            }
            catch (Exception ex) { ErrorLog(ex.Message); }
        }

        private void btnReadSMS_Click(object sender, EventArgs e)
        {
            try
            {
                // Count SMS 
                int uCountSMS = objclsSMS.CountSMS(port);
                if (uCountSMS > 0)
                {
                    #region Command
                    string strCommand = "AT+CMGL=\"ALL\"";

                    if (this.rbReadAll.Checked) strCommand = "AT+CMGL=\"ALL\"";
                    else if (rbReadUnRead.Checked) strCommand = "AT+CMGL=\"REC UNREAD\"";
                    else if (rbReadStoreSent.Checked) strCommand = "AT+CMGL=\"STO SENT\"";
                    else if (rbReadStoreUnSent.Checked) strCommand = "AT+CMGL=\"STO UNSENT\"";
                    #endregion

                    #region Read SMS
                    // If SMS exist then read SMS
                    objShortMessageCollection = objclsSMS.ReadSMS(port, strCommand);
                    foreach (ShortMessage msg in objShortMessageCollection)
                    {
                        var tmp = new string[] { msg.Index, msg.Sent, msg.Sender, msg.Message };
                        var item = new ListViewItem(tmp) { Tag = msg };
                        lvwMessages.Items.Add(item);
                    }
                    #endregion
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
                int uCountSMS = objclsSMS.CountSMS(port);
                if (uCountSMS > 0)
                {
                    DialogResult dr = MessageBox.Show("Are u sure u want to delete the SMS?",
                        "Delete confirmation", MessageBoxButtons.YesNo);

                    if (dr.ToString() == "Yes")
                    {
                        #region Delete SMS

                        if (this.rbDeleteAllSMS.Checked)
                        {


                            #region Delete all SMS
                            if (objclsSMS.DeleteMsg(port, "AT+CMGD=1,4"))
                                statusBar1.Text = "Messages has deleted successfuly";
                            else statusBar1.Text = "Failed to delete messages";
                            #endregion
                        }
                        else if (rbDeleteReadSMS.Checked)
                        {
                            #region Delete read SMS
                            if (objclsSMS.DeleteMsg(port, "AT+CMGD=1,3"))
                                statusBar1.Text = "Messages has deleted successfuly";
                            else this.statusBar1.Text = "Failed to delete messages";
                            #endregion
                        }
                        #endregion
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
                int uCountSMS = objclsSMS.CountSMS(this.port);
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