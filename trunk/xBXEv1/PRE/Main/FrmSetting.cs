using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PRE.Main
{
    using SKG.UTL;
    using SKG.UTL.Db;

    using System.Configuration;
    using DAL;

    public partial class FrmSetting : DevExpress.XtraEditors.XtraForm
    {
        private const string STR_FIND = "<Tìm kiếm>";
        private const string STR_WIND = "Windows";

        private const string STR_SETUP = "Cài đặt";
        private const string STR_EXISTS = "Cơ sở dữ liệu đã có!";
        private const string STR_NOCONNECT = "Không kết nối được server!";
        private const string STR_TEMPLATE = "Đã tạo xong dữ liễu mẫu!";
        private const string STR_SET_TEMP = "Cài dữ liệu mẫu không?";
        private const string STR_NOT_FOUND = "Không tìm thấy file cấu hình!";
        private const string STR_SAVE = "Đã lưu cấu hình!\nHãy khởi động lại hệ thống...";

        /// <summary>
        /// Connection string for SQL Server
        /// </summary>
        ConnectionStringSettings _a = new ConnectionStringSettings("xBXEv1", @"Data Source=.;Initial Catalog=xBXEv1;Integrated Security=True", "System.Data.SqlClient");

        /// <summary>
        /// Connection string for SQL CE 4.0
        /// </summary>
        ConnectionStringSettings _b = new ConnectionStringSettings("xBXEv1", @"Data Source=|DataDirectory|\xBXEv1.sdf", "System.Data.SqlServerCe.4.0");

        /// <summary>
        /// Get string connect
        /// </summary>
        private ConnectionStringSettings ConnectionStringSetting
        {
            get
            {
                if (chkSQLCE.Checked) return _b;

                var sver = cbbServer.Text;
                var user = cbbUser.Text;
                var pass = txtPass.Text;
                var data = cbbDb.Text;
                var str = "";

                if (data == "" || data == STR_FIND) data = "xBXEv1";
                if (cbbAuthen.Text == STR_WIND) str = String.Format(SQLServer.STR_TRU, sver, data);
                else str = String.Format(SQLServer.STR_SEC, sver, data, user, pass);

                _a.ConnectionString = str;
                return _a;
            }
        }

        public FrmSetting()
        {
            InitializeComponent();
        }

        #region Events
        Configuration _config;
        private void FrmSetting_Load(object sender, EventArgs e)
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var a = _config.ConnectionStrings.ConnectionStrings[1];

            if (a.ProviderName == _b.ProviderName) chkSQLCE.Checked = true;
            else chkSQLCE.Checked = false;

            chkSQLCE_CheckedChanged(sender, e);
        }

        private void cmdClose_Click(object sender, EventArgs e) { Close(); }

        private void cmdSetup_Click(object sender, EventArgs e)
        {
            BLL.BaseBLL.CreateData(true);
            BasePRE.ShowMessage(STR_TEMPLATE, STR_SETUP);
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                var a = ConnectionStringSetting.ConnectionString;
                if (!a.CheckSqlConnect())
                {
                    BasePRE.ShowMessage(STR_NOCONNECT, STR_SETUP);
                    return;
                }

                _config.ConnectionStrings.ConnectionStrings[1] = ConnectionStringSetting;
                _config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection(_config.ConnectionStrings.SectionInformation.Name);
                Properties.Settings.Default.Reload();

                BasePRE.ShowMessage(STR_SAVE, STR_SETUP);

                Application.ExitThread();
                Application.Exit();
            }
            catch { BasePRE.ShowMessage(STR_NOT_FOUND, STR_SETUP); }
        }

        private void cbbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbServer.SelectedItem + "" == STR_FIND)
                {
                    var tbl = BaseDAL.GetSQLServers();
                    cbbServer.Properties.Items.Remove(STR_FIND);

                    cbbServer.Properties.Items.Clear();
                    foreach (DataRow dtr in tbl.Rows)
                        cbbServer.Properties.Items.Add(dtr["name"]);

                    cbbServer.Properties.Items.Add(STR_FIND);

                    if (cbbServer.Properties.Items.Count > 1) cbbServer.SelectedIndex = 0;
                    else cbbServer.SelectedIndex = -1;
                }
            }
            catch { return; }
        }

        private void cbbAuthen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbAuthen.SelectedItem + "" == STR_WIND)
            {
                cbbUser.Enabled = false;
                txtPass.Enabled = false;
            }
            else
            {
                cbbUser.Enabled = true;
                txtPass.Enabled = true;
            }
        }

        private void cbbDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbDb.SelectedItem + "" == STR_FIND)
                {
                    var a = ConnectionStringSetting.ConnectionString.Replace("xBXEv1", "master");
                    var db = new SQLServer(a);
                    var tbl = db.GetDatabases();
                    cbbDb.Properties.Items.Remove(STR_FIND);

                    cbbDb.Properties.Items.Clear();
                    foreach (var dtr in tbl)
                        cbbDb.Properties.Items.Add(dtr);

                    cbbDb.Properties.Items.Add(STR_FIND);

                    if (cbbDb.Properties.Items.Count > 1) cbbDb.SelectedIndex = 0;
                    else cbbDb.SelectedIndex = -1;
                }
            }
            catch { return; }
        }

        private void chkSQLCE_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSQLCE.Checked)
            {
                cbbServer.Enabled = false;
                cbbAuthen.Enabled = false;
                cbbUser.Enabled = false;
                txtPass.Enabled = false;
                cbbDb.Enabled = false;
            }
            else
            {
                cbbServer.Enabled = true;
                cbbAuthen.Enabled = true;
                cbbUser.Enabled = true;
                txtPass.Enabled = true;
                cbbDb.Enabled = true;
            }
        }
        #endregion
    }
}