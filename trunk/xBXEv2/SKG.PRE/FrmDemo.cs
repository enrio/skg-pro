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
            var a = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\BXE";
            var b = Global.Plugins.FindConfigs(a);
            menuStrip1.LoadMenu(b);

            a = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\POS";
            b = Global.Plugins.FindConfigs(a);
            menuStrip1.LoadMenu(b);
        }
    }
}