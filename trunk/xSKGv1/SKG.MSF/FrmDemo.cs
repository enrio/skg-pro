using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.MSF
{
    using SKG.Extend;

    public partial class FrmDemo : Form
    {
        public FrmDemo()
        {
            InitializeComponent();
        }

        private void FrmDemo_Load(object sender, EventArgs e)
        {
            var a = Global.Service.GetPlugins();
            menuStrip1.LoadMenu(a, this);
        }
    }
}