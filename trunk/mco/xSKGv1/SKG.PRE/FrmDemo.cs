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

            Global.Service.GetPlugins();
        }

        private void FrmDemo_Load(object sender, EventArgs e)
        {
            CreateMenu();
        }

        /// <summary>
        /// Load menu of all plugins
        /// </summary>
        private void CreateMenu()
        {
            var a = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\BXE\";
            menuStrip1.LoadMenu(a);

            var b = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\POS\";
            menuStrip1.LoadMenu(b);
        }
    }
}