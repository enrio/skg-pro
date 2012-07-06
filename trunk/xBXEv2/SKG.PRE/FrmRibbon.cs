using System;
using System.Collections.Generic;

namespace SKG.PRE
{
    public partial class FrmRibbon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmRibbon()
        {
            InitializeComponent();
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            var a = AppDomain.CurrentDomain.BaseDirectory + @"\Plugins";
            var b = Global.Plugins.FindConfigs(a);
            ribbon.LoadMenu(b);
        }
    }
}