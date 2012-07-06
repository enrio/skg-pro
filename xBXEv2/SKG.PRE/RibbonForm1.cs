using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace SKG.PRE
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            var a = AppDomain.CurrentDomain.BaseDirectory + @"\Plugins";
            var b = Global.Plugins.FindConfigs(a);
            //menuStrip1.LoadMenu(b);
        }
    }
}