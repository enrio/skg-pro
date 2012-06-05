using System;
using System.Windows.Forms;

namespace SKG.SYS
{
    public partial class FrmFawObj : Form
    {
        public FrmFawObj()
        {
            InitializeComponent();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            bool o = FrmAepAjf._sss.Login;
        }

        private void FrmFawObj_Load(object sender, EventArgs e)
        {
            FrmAepAjf._sss.Login = false;

            txtUser.Text = "admin";
            txtPass.Text = "admin";
        }
    }
}