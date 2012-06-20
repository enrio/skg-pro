using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SKG.PRE
{
    using UTL;

    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            var d = DateTime.Now;

            var d1 = d.ToStartOfDay();
            var d2 = d.ToEndOfDay();

            var w1 = d.ToStartOfWeek();
            var v2 = d.ToEndOfWeek();

            var n1 = 100;
            var n2 = 100L;
            var n3 = 100D;

            var t = n1.ToVietnamese("đồng");
            t = n2.ToVietnamese("đồng");
            t = n3.ToVietnamese("đồng");
        }
    }
}