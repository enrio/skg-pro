using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PRE
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        BLL.GroupBLL _groupBLL = new BLL.GroupBLL();
        BLL.KindBLL _kindBLL = new BLL.KindBLL();
        BLL.VehicleBLL _vehicleBLL = new BLL.VehicleBLL();
        BLL.UserBLL _userBLL = new BLL.UserBLL();
        BLL.DetailBLL _detailBLL = new BLL.DetailBLL();

        private void btnSelect_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _groupBLL.Select();
        }
    }
}