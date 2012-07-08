using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;

namespace SKG.PRE
{
    using UTL.Plugin;
    using UTL.Extension;
    using System.Linq;

    public partial class FrmDemo : RibbonForm
    {
        public FrmDemo()
        {
            InitializeComponent();
            InitSkinGallery();
            InitGrid();

        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        BindingList<Person> gridDataList = new BindingList<Person>();
        void InitGrid()
        {
            gridDataList.Add(new Person("John", "Smith"));
            gridDataList.Add(new Person("Gabriel", "Smith"));
            gridDataList.Add(new Person("Ashley", "Smith", "some comment"));
            gridDataList.Add(new Person("Adrian", "Smith", "some comment"));
            gridDataList.Add(new Person("Gabriella", "Smith", "some comment"));
            gridControl.DataSource = gridDataList;
        }

        private void FrmDemo_Load(object sender, EventArgs e)
        {
            GetPlugin();
            CreateMenu();
        }

        /// <summary>
        /// Get plugin
        /// </summary>
        private void GetPlugin()
        {
            var a = Application.StartupPath + @"\Plugins\BXE\";
            var b = Global.Service.GetPlugin(a + "BXE.PRE.exe");
            var c = b.ToDataTable(false, typeof(Plugin).Name);

            var r = from s in b
                    orderby s.Menu.Order
                    select s.Menu;

            c = r.ToDataTable(false, typeof(Plugin).Name);
            c.WriteXml(a + "Menu.xml");

            a = Application.StartupPath + @"\Plugins\POS\";
            b = Global.Service.GetPlugin(a + "POS.dll");
            c = b.ToDataTable(false, typeof(Plugin).Name);

            r = from s in b
                orderby s.Menu.Order
                select s.Menu;

            c = r.ToDataTable(false, typeof(Plugin).Name);
            c.WriteXml(a + "Menu.xml");
        }

        /// <summary>
        /// Load menu of all plugins
        /// </summary>
        private void CreateMenu()
        {
            var a = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\BXE\";
            ribbonControl.LoadMenu(a);

            var b = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\POS\";
            ribbonControl.LoadMenu(b);

            //Global.Service.FindPlugins();
            //var menu = (a + "Menu.xml").ToMenu(typeof(Plugin).Name);
            //foreach (Plugin i in Global.Service.Plugins)
            //    i.Type = i.Instance.GetType() + "";

            //var res = from s in menu
            //          join p in Global.Service.Plugins on s.Type equals p.Type into k
            //          from q in k.DefaultIfEmpty()
            //          select new
            //          {
            //              s.Level,
            //              s.Caption,
            //              s.Type,
            //              s.Picture,
            //              s.Show,

            //              //Instance = q == null ? null : q.Instance,
            //              Path = q == null ? null : q.Path
            //          };

            //var x = res.ToDataTable(false, typeof(Plugin).Name);
            //x.WriteXml(Application.StartupPath + @"\Menu.xml");
        }
    }
}