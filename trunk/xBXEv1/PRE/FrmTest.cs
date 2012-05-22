using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRE
{
    public partial class FrmTest : Form
    {
        BLL.Tra_GroupBLL _tra_GroupBLL = new BLL.Tra_GroupBLL();

        public FrmTest()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = _tra_GroupBLL.Select();
        }
    }
}