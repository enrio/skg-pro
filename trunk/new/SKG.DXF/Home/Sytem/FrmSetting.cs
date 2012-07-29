using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Home.Sytem
{
    using BLL;
    using SKG.Data;
    using SKG.Plugin;
    using SKG.Extend;
    using System.Configuration;
    using DevExpress.XtraEditors;

    public partial class FrmSetting : SKG.DXF.FrmMenuz
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Cài đặt", Level = 3, Order = 4, Picture = @"Icons\Setting.png" };
                return menu;
            }
        }
        #endregion

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
        ConnectionStringSettings _a = new ConnectionStringSettings("xSKGv1", @"Data Source=.;Initial Catalog=xSKGv1;Integrated Security=True", "System.Data.SqlClient");

        /// <summary>
        /// Connection string for SQL CE 4.0
        /// </summary>
        ConnectionStringSettings _b = new ConnectionStringSettings("xSKGv1", @"Data Source=|DataDirectory|\xSKGv1.sdf", "System.Data.SqlServerCe.4.0");

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

                if (data == "" || data == STR_FIND) data = "xSKGv1";
                if (cbbAuthen.Text == STR_WIND) str = String.Format(SqlServer.STR_TRU, sver, data);
                else str = String.Format(SqlServer.STR_SEC, sver, data, user, pass);

                _a.ConnectionString = str;
                return _a;
            }
        }

        private bool IsValid
        {
            get
            {
                var a = ConnectionStringSetting.ConnectionString;
                if (chkSQLCE.Checked)
                {
                    var b = a.Split(new char[] { '|' });
                    var c = String.Format("{0}{1}", Application.StartupPath, b[2]);
                    if (!c.CheckSqlCeConnect())
                    {
                        XtraMessageBox.Show(STR_NOCONNECT, STR_SETUP);
                        return false;
                    }
                }
                else
                {
                    var b = a.Replace("xSKGv1", "master");
                    if (!b.CheckSqlConnect())
                    {
                        XtraMessageBox.Show(STR_NOCONNECT, STR_SETUP);
                        return false;
                    }
                }
                return true;
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
            if (!IsValid) return;

            Sample.CreateData(true);
            XtraMessageBox.Show(STR_TEMPLATE, STR_SETUP);
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (!IsValid) return;

            try
            {
                _config.ConnectionStrings.ConnectionStrings[1] = ConnectionStringSetting;
                _config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection(_config.ConnectionStrings.SectionInformation.Name);
                Properties.Settings.Default.Reload();

                XtraMessageBox.Show(STR_SAVE, STR_SETUP);

                Application.ExitThread();
                Application.Exit();
            }
            catch { XtraMessageBox.Show(STR_NOT_FOUND, STR_SETUP); }
        }

        private void cbbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbServer.SelectedItem + "" == STR_FIND)
                {
                    var tbl = Base.GetSQLServers();
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
                    var a = ConnectionStringSetting.ConnectionString.Replace("xSKGv1", "master");
                    using (var db = new SqlServer(a))
                    {
                        var tbl = db.GetDatabases();
                        cbbDb.Properties.Items.Remove(STR_FIND);
                        cbbDb.Properties.Items.Clear();
                        foreach (var dtr in tbl)
                            cbbDb.Properties.Items.Add(dtr);
                    }

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