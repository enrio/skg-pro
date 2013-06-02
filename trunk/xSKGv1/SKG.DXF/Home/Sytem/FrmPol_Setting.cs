#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 29/07/2012 10:27
 * Update: 02/06/2013 08:10
 * Status: OK
 */
#endregion

using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

namespace SKG.DXF.Home.Sytem
{
    using SKG.Datax;
    using SKG.Plugin;
    using SKG.Extend;

    using DevExpress.XtraEditors;

    /// <summary>
    /// Menuz - Setting
    /// </summary>
    public partial class FrmPol_Setting : FrmMenuz
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmPol_Setting);
                var name = Global.GetIconName(type);

                var menu = new Menuz
                {
                    Code = type.FullName,
                    Parent = typeof(Level2).FullName,
                    Text = STR_TITLE,
                    Level = 1,
                    Order = 0,
                    Picture = String.Format(Global.STR_ICON, name)
                };
                return menu;
            }
        }
        #endregion

        #region Implements
        #endregion

        #region Overrides
        #endregion

        #region Methods
        public FrmPol_Setting()
        {
            InitializeComponent();
        }

        void EnabledControl(bool enabled)
        {
            cbbServer.Enabled = enabled;
            cbbAuthen.Enabled = enabled;
            cbbDb.Enabled = enabled;

            if (enabled && cbbAuthen.SelectedIndex == 1)
            {
                cbbUser.Enabled = !enabled;
                txtPass.Enabled = !enabled;
            }
            else
            {
                cbbUser.Enabled = enabled;
                txtPass.Enabled = enabled;
            }
        }
        #endregion

        #region Events
        private void FrmSetting_Load(object sender, EventArgs e)
        {
            _cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var a = _cfg.ConnectionStrings.ConnectionStrings[1];
            var cfg = a.ConnectionString.GetConfig();

            if (cfg != null)
            {
                if (cfg.Count > 1)
                {
                    cbbAuthen.SelectedIndex = 1; // select Windows Authencation

                    cbbServer.EditValue = cfg[0];
                    cbbDb.EditValue = cfg[1];
                }

                if (cfg.Count > 3)
                {
                    cbbAuthen.SelectedIndex = 0; // select SQL Server Authencation

                    cbbUser.EditValue = cfg[2];
                    txtPass.EditValue = cfg[3];
                }
            }

            if (a.ProviderName == _b.ProviderName) chkSQLCE.Checked = true;
            else chkSQLCE.Checked = false;

            chkSQLCE_CheckedChanged(sender, e);
        }

        private void cmdClose_Click(object sender, EventArgs e) { Close(); }

        private void cmdSetup_Click(object sender, EventArgs e)
        {
            if (!IsValid) return;

            _cfg.ConnectionStrings.ConnectionStrings[1] = ConnectionStringSetting;
            _cfg.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection(_cfg.ConnectionStrings.SectionInformation.Name);
            Properties.Settings.Default.Reload();

            Sample.CreateData(true, !chkSQLCE.Checked);
            Extend.Login();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (!IsValid) return;

            try
            {
                _cfg.ConnectionStrings.ConnectionStrings[1] = ConnectionStringSetting;
                _cfg.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection(_cfg.ConnectionStrings.SectionInformation.Name);
                Properties.Settings.Default.Reload();

                Extend.Login();
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
            if (cbbAuthen.SelectedIndex == 1) // select Windows Authencation
            {
                cbbUser.Enabled = false;
                txtPass.Enabled = false;
            }
            else // select SQL Server Authencation
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
                    var a = ConnectionStringSetting.ConnectionString.Replace(_dbName, "master");
                    using (var db = new Server(a))
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
            EnabledControl(!chkSQLCE.Checked);
        }
        #endregion

        #region Properties
        /// <summary>
        /// This configuration
        /// </summary>
        Configuration _cfg;

        /// <summary>
        /// Connection string for SQL Server
        /// </summary>
        private ConnectionStringSettings _a =
            new ConnectionStringSettings(_dbName,
                String.Format(@"Data Source=.;Initial Catalog={0};Integrated Security=True", _dbName),
                "System.Data.SqlClient");

        /// <summary>
        /// Connection string for SQL CE 4.0
        /// </summary>
        private ConnectionStringSettings _b =
            new ConnectionStringSettings(_dbName,
                String.Format(@"Data Source=|DataDirectory|\{0}.sdf", _dbName),
                "System.Data.SqlServerCe.4.0");

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

                if (data == "" || data == STR_FIND) data = _dbName;
                if (cbbAuthen.Text == STR_WIND) str = String.Format(Server.STR_TRU, sver, data);
                else str = String.Format(Server.STR_SEC, sver, data, user, pass);

                _a.ConnectionString = str;
                return _a;
            }
        }

        private bool IsValid
        {
            get
            {
                var a = ConnectionStringSetting.ConnectionString;

                if (chkSQLCE.Checked) return true;
                else
                {
                    var b = a.Replace(_dbName, "master");
                    if (!b.CheckSqlConnect())
                    {
                        XtraMessageBox.Show(STR_NOCONNECT, STR_SETUP);
                        return false;
                    }
                }

                return true;
            }
        }
        #endregion

        #region Fields
        static string _dbName = Global.DbName;
        #endregion

        #region Constants
        private const string STR_TITLE = "Cài đặt";

        private const string STR_FIND = "<Tìm kiếm>";
        private const string STR_WIND = "Windows";

        private const string STR_SETUP = "Cài đặt";
        private const string STR_NOCONNECT = "Không kết nối được server!";
        private const string STR_NOT_FOUND = "Không tìm thấy file cấu hình!";
        #endregion
    }
}