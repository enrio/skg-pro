using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SKG.Reader
{
    using Microsoft.Win32;

    public partial class FrmConfig : Form
    {
        private const string STR_KEY = "xQOS.UTL.Reader";
        private const string STR_NOT = "SQL Server or DB Name is not null!";
        private const string STR_SVR = "SQL Server";
        private const string STR_DBS = "DB Name";
        private const string STR_LOG = "Login";
        private const string STR_PSS = "Password";
        private const string STR_CHK = "Checked";

        public bool _status;

        public FrmConfig()
        {
            InitializeComponent();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(STR_KEY);
            if (key != null && key.ValueCount > 0)
            {
                if (key.GetValue(STR_CHK).ToString() == "True" || key.GetValue(STR_CHK).ToString() == "False")
                {
                    cboSQLServer.Text = key.GetValue(STR_SVR).ToString();
                    cboDBName.Text = key.GetValue(STR_DBS).ToString();
                    txtLogin.Text = key.GetValue(STR_LOG).ToString();
                    txtPassword.Text = key.GetValue(STR_PSS).ToString();
                    chkRemember.Checked = Convert.ToBoolean(key.GetValue(STR_CHK));
                }
                key.Close();
            }

            if (!chkRemember.Checked)
            {
                cboAuthentication.SelectedIndex = 0;
                ChangeStatus(false);
            }
            else
            {
                cboAuthentication.SelectedIndex = 1;
                ChangeStatus(true);
            }
        }

        private void ChangeStatus(bool flag)
        {
            txtLogin.Enabled = flag;
            txtPassword.Enabled = flag;
            chkRemember.Enabled = flag;
        }

        private void cboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAuthentication.SelectedIndex == 0)
            {
                ChangeStatus(false);
            }
            else
            {
                ChangeStatus(true);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            if (cboDBName.Text + "" == "" || cboSQLServer.Text + "" == "")
            {
                MessageBox.Show(STR_NOT, "Error");
            }
            else
            {
                // Save info to registry
                if (chkRemember.Checked)
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(STR_KEY);
                    key.SetValue(STR_SVR, cboSQLServer.Text);
                    key.SetValue(STR_DBS, cboDBName.Text);
                    key.SetValue(STR_LOG, txtLogin.Text);
                    key.SetValue(STR_PSS, txtPassword.Text);
                    key.SetValue(STR_CHK, chkRemember.Checked);
                    key.Close();
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(STR_KEY);
                    if (key != null)
                    {
                        Registry.CurrentUser.DeleteSubKey(STR_KEY);
                    }
                }

                _status = true;
                Close();
            }
        }

        private void cmdHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not support!", "Help");
        }

        private void cboSQLServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSQLServer.SelectedIndex == cboSQLServer.Items.Count - 1)
            {
                var tbl = SKG.Reader.SqlReader.GetSQLServers();

                cboSQLServer.Items.Clear();
                foreach (DataRow r in tbl.Rows)
                {
                    string s = String.Format(@"{0}\{1}", r["ServerName"], r["InstanceName"]);
                    cboSQLServer.Items.Add(s.TrimEnd(new char[] { '\\' }));
                }
                if (cboSQLServer.Items.Count > 0)
                {
                    cboSQLServer.SelectedIndex = 0;
                }
                cboSQLServer.Items.Add("<Browse for more...>");
            }
        }

        private void cboDBName_Click(object sender, EventArgs e)
        {
            try
            {
                var sqr = new SqlReader();

                if (txtLogin.Enabled)
                {
                    sqr = new SqlReader(cboSQLServer.Text, "master", txtLogin.Text, txtPassword.Text);
                }
                else
                {
                    sqr = new SqlReader(cboSQLServer.Text, "master");
                }

                using (var tbl = sqr.GetDatabases())
                {
                    cboDBName.Items.Clear();
                    foreach (DataRow r in tbl.Rows)
                    {
                        string s = r["name"].ToString();
                        cboDBName.Items.Add(s.TrimEnd(new char[] { '\\' }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}