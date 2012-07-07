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
            var a = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\BXE\";
            ribbonControl.LoadMenu(a);

            var b = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\POS\";
            ribbonControl.LoadMenu(b);

            Global.Service.FindPlugins();
            var f = (a + "Menu.xml").ToMenu(typeof(Plugin).Name);
            foreach (Plugin i in Global.Service.Plugins)
                i.Type = i.Instance.GetType() + "";

            var res = from p in f
                      join c in Global.Service.Plugins on p.Type equals c.Type into j1
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

            var x = res.ToDataTable(false, typeof(Plugin).Name);
            x.WriteXml(Application.StartupPath + @"\Menu.xml");
        }
    }
}