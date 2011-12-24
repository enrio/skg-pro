using System;
using System.Windows.Forms;

namespace UTL.FRM
{
    public partial class FrmFawObj : Form
    {
        public UTL.BLL.UecLajVei _sss = new UTL.BLL.UecLajVei();

        public FrmFawObj()
        {
            InitializeComponent();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}