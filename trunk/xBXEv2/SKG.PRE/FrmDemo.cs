using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.PRE
{
    using UTL.Plugin;
    using UTL.Extension;

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

            //a = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\POS\";
            //menuStrip1.LoadMenu(a);

            Global.Plugins.FindPlugins();
            var f = (a + "Menu.xml").ToMenu(typeof(AvailablePlugin).Name);

            foreach (AvailablePlugin i in Global.Plugins.AvailablePlugins)
            {

            }
        }
    }
}