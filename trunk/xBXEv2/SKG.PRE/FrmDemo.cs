using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.PRE
{
    public partial class FrmDemo : Form
    {
        public FrmDemo()
        {
            InitializeComponent();
        }

        private void FrmDemo_Load(object sender, EventArgs e)
        {
            var a = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\BXE\";
            menuStrip1.LoadMenu(a);

            a = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\POS\";
            menuStrip1.LoadMenu(a);
        }
    }
}