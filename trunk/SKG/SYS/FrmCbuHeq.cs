using System;
using System.Windows.Forms;
using System.Configuration;

namespace SKG.SYS
{
    public partial class FrmCbuHeq : Form
    {
        public FrmCbuHeq()
        {
            InitializeComponent();
        }

        private void cmdServer_Click(object sender, EventArgs e)
        {
            try
            {
                cbbServer.DataSource = null;
                cbbDB.DataSource = null;
                cbbServer.DataSource = UTL.RDR.SqlSvr.GetSQLServers();
                cbbServer.DisplayMember = "name";
            }
            catch (Exception ex)
            {
                string s = String.Format("{0};{1}", "Không biết", ex.Message);
                string t = String.Format("{0};{1}", "Lỗi", "Error");
                UTL.CsoUTL.Show(s, t);
            }
        }

        private void cmdDb_Click(object sender, EventArgs e)
        {
            try
            {
                cbbDB.DataSource = null;
                var x = new UTL.RDR.SqlSvr(StrCnn());
                cbbDB.DataSource = x.GetDatabases();
                cbbDB.DisplayMember = "name";
            }
            catch (Exception ex)
            {
                string s = String.Format("{0};{1}", "Không biết", ex.Message);
                string t = String.Format("{0};{1}", "Lỗi", "Error");
                UTL.CsoUTL.Show(s, t);
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                _config.ConnectionStrings.ConnectionStrings[1].ConnectionString = StrCnn();
                _config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(_config.ConnectionStrings.SectionInformation.Name);
                Properties.Settings.Default.Reload();

                UTL.CsoUTL.Show("Đã lưu cấu hình!" + Environment.NewLine + "Xin hãy khởi động lại chương trình!");

                Close();
                Application.Exit();
            }
            catch (Exception ex)
            {
                string s = String.Format("{0};{1}", "Không tìm thấy file cấu hình!", ex.Message);
                string t = String.Format("{0};{1}", "Lỗi", "Error");
                UTL.CsoUTL.Show(s, t);
            }
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSet_Click(object sender, EventArgs e)
        {
            var dbName = UTL.DAL.CsoDAL.DbName;
            var fileDb = UTL.DAL.CsoDAL.FileDb;
            var x = new UTL.RDR.SqlSvr(StrCnn());
            if (x.Open())
            {
                if (x.NotExists(dbName)) // database not exists
                {
                    if (x.CreateDbName(dbName)) // create database                    
                        if (x.ExecuteFileSQL(dbName, fileDb, true))
                            cmdSet.Enabled = false;
                }
                else
                {
                    UTL.CsoUTL.Show("Cơ sở dữ liệu đã có;Database exitst");
                    cmdSet.Enabled = false;
                }
            }
            else
            {
                UTL.CsoUTL.Show(String.Format("{0};{1}", "Không kết nối được server!", "Not connect to server!"));
            }
        }

        private void radWin_CheckedChanged(object sender, EventArgs e)
        {
            ChangeText(false);
        }

        private void radSql_CheckedChanged(object sender, EventArgs e)
        {
            ChangeText(true);
        }

        private void ChangeText(bool change)
        {
            txtPass.Enabled = change;
            txtUser.Enabled = change;
        }

        private string StrCnn()
        {
            string sver = cbbServer.Text;
            string user = txtUser.Text;
            string pass = txtPass.Text;
            string data = cbbDB.Text;
            string str;

            if (radWin.Checked == true)
                str = String.Format(UTL.RDR.CsoRDR.STR_TRU, sver, (data == "" ? "master" : data));
            else
                str = String.Format(UTL.RDR.CsoRDR.STR_SEC, sver, data, user, pass);

            return str;
        }

        private void FrmCbuHeq_Load(object sender, EventArgs e)
        {
            if (cbbDB.Text + "" == "") UTL.DAL.CsoDAL.DbName = "BXE";
            else UTL.DAL.CsoDAL.DbName = cbbDB.Text;
            UTL.DAL.CsoDAL.FileDb = Application.StartupPath + @"\PLG\BXE.sql";
        }
    }
}