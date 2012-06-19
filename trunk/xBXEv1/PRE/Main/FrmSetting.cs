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
        private const string STR_SAVE = "Đã lưu cấu hình!";

        public const string STR_SEC = "Data Source={0};Initial Catalog={1};User Id={2};Password={3};";
        public const string STR_TRU = "Data Source={0};Initial Catalog={1};Integrated Security=SSPI;";

        /// <summary>
        /// Get string connect
        /// </summary>
        private string StringConnect
        {
            get
            {
                string sver = cbbServer.Text;
                string user = cbbUser.Text;
                string pass = txtPass.Text;
                string data = cbbDb.Text;
                string str = "";

                if (data == "" || data == STR_FIND) data = "xBXEv1";
                if (cbbAuthen.Text == STR_WIND) str = String.Format(STR_TRU, sver, data);
                else str = String.Format(STR_SEC, sver, data, user, pass);

                return str;
            }
        }

        public FrmSetting()
        {
            InitializeComponent();
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
                Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                _config.ConnectionStrings.ConnectionStrings[1].ConnectionString = StringConnect;

                _config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(_config.ConnectionStrings.SectionInformation.Name);
                Properties.Settings.Default.Reload();

                BasePRE.ShowMessage(STR_SAVE, STR_SETUP);
                Close(); // close form                
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
                    var tbl = BaseDAL.GetDatabases();
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
    }
}