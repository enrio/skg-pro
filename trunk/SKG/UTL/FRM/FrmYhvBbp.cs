using System;
using System.Windows.Forms;

namespace UTL.FRM
{
    public partial class FrmYhvBbp : Form
    {
        public string Infor;

        public FrmYhvBbp()
        {
            InitializeComponent();
        }

        private void FrmYhvBbp_Load(object sender, EventArgs e)
        {
            lblInfor.Text = Infor;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}