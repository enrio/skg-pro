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
    using BLL;
    using DAL.Entities;

    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            BaseBLL.CreateData(true);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = BaseBLL._tra_GroupBLL.Select();
        }
    }
}