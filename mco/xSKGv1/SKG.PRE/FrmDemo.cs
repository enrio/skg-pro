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
            Global.Service.FindPlugins(a);

            var b = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\POS\";
            Global.Service.FindPlugins(b);

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

            Global.Service.FindPlugins();
            var menu = (a + "Menu.xml").ToMenu(typeof(Plugin).Name);
            foreach (Plugin i in Global.Service.Plugins)
                i.Type = i.Instance.GetType() + "";

            var res = from s in menu
                      join p in Global.Service.Plugins on s.Type equals p.Type into k
                      from q in k.DefaultIfEmpty()
                      select new
                      {
                          s.Level,
                          s.Caption,
                          s.Type,
                          s.Picture,
                          s.Show,

                          //Instance = q == null ? null : q.Instance,
                          Path = q == null ? null : q.Path
                      };

            var x = res.ToDataTable(false, typeof(Plugin).Name);
            x.WriteXml(Application.StartupPath + @"\Menu.xml");
        }
    }
}