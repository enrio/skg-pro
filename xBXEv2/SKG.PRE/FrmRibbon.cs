using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.PRE
{
    using UTL.Plugin;
    using UTL.Extension;

    public partial class FrmRibbon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmRibbon()
        {
            InitializeComponent();
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            var a = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\BXE\";
            ribbon.LoadMenu(a);

            var b = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\POS\";
            ribbon.LoadMenu(b);

            Global.Plugins.FindPlugins();
            var f = (a + "Menu.xml").ToMenu(typeof(AvailablePlugin).Name);
            foreach (AvailablePlugin i in Global.Plugins.Plugins)
                i.Type = i.Instance.GetType() + "";

            var res = from p in f
                      join c in Global.Plugins.Plugins on p.Type equals c.Type into j1
                      from j2 in j1.DefaultIfEmpty()
                      select new
                      {
                          p.Level,
                          p.Text1,
                          p.Text2,
                          p.Type,
                          p.Icon,
                          p.Show,

                          //Instance = j2 == null ? null : j2.Instance,
                          //Path = j2 == null ? null : j2.Path
                      };

            var x = res.ToDataTable(false, typeof(AvailablePlugin).Name);
            x.WriteXml(App.StartupPath + @"\Menu.xml");
        }
    }
}