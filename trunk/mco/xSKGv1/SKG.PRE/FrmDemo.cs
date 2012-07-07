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
            DataBXE();
            DataPOS();

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

            Global.Plugins.FindPlugins();
            var menu = (a + "Menu.xml").ToMenu(typeof(Plugin).Name);
            foreach (Plugin i in Global.Plugins.Plugins)
                i.Type = i.Instance.GetType() + "";

            var res = from s in menu
                      join p in Global.Plugins.Plugins on s.Type equals p.Type into k
                      from q in k.DefaultIfEmpty()
                      select new
                      {
                          s.Level,
                          s.Text1,
                          s.Text2,
                          s.Type,
                          s.Icon,
                          s.Show,

                          //Instance = q == null ? null : q.Instance,
                          Path = q == null ? null : q.Path
                      };

            var x = res.ToDataTable(false, typeof(Plugin).Name);
            x.WriteXml(Application.StartupPath + @"\Menu.xml");
        }

        private static void DataBXE()
        {
            var u = new List<Plugin>();
            var o = new Plugin() { Level = 1, Text1 = "Vận tải", Text2 = "Transport", Type = "BXE", Icon = @"Icon\Transport.png" };
            u.Add(o);
            o = new Plugin() { Level = 2, Text1 = "Danh mục", Text2 = "Catalog", Type = "BXE.PRE.Catalog", Icon = @"Icon\Catalog.png" };
            u.Add(o);
            o = new Plugin() { Level = 3, Text1 = "Nhóm xe", Text2 = "Group", Type = "BXE.PRE.Catalog.FrmGroup", Icon = @"Icon\Group.png" };
            u.Add(o);
            o = new Plugin() { Level = 3, Text1 = "Loại xe", Text2 = "Kind", Type = "BXE.PRE.Catalog.FrmKind", Icon = @"Icon\Kind.png" };
            u.Add(o);
            o = new Plugin() { Level = 3, Text1 = "Xe cộ", Text2 = "Vehicle", Type = "BXE.PRE.Catalog.FrmVehicle", Icon = @"Icon\Vehicle.png" };
            u.Add(o);
            o = new Plugin() { Level = 2, Text1 = "Báo cáo", Text2 = "Report", Type = "BXE.PRE.Report", Icon = @"Icon\Report.png" };
            u.Add(o);
            o = new Plugin() { Level = 3, Text1 = "In ấn", Text2 = "Print", Type = "BXE.PRE.Report.FrmPrint", Icon = @"Icon\Print.png" };
            u.Add(o);
            o = new Plugin() { Level = 2, Text1 = "Thống kê", Text2 = "Sumary", Type = "BXE.PRE.Sumary", Icon = @"Icon\Sumary.png" };
            u.Add(o);
            o = new Plugin() { Level = 3, Text1 = "Doanh thu", Text2 = "Sales", Type = "BXE.PRE.Sumary.FrmSales", Icon = @"Icon\Sales.png" };
            u.Add(o);
            o = new Plugin() { Level = 2, Text1 = "Kiểm tra", Text2 = "Test", Type = "BXE.PRE", Icon = @"Icon\Test.png" };
            u.Add(o);
            o = new Plugin() { Level = 3, Text1 = "Cơ sở", Text2 = "Base", Type = "BXE.PRE.FrmBase", Icon = @"Icon\Base.png" };
            u.Add(o);

            var x = u.ToDataTable(false, typeof(Plugin).Name);
            x.WriteXml(Application.StartupPath + @"\Menu.xml");
        }

        private static void DataPOS()
        {
            var u = new List<Plugin>();
            var o = new Plugin() { Level = 1, Text1 = "Bán hàng", Text2 = "Point of sales", Type = "POS", Icon = @"Icon\POS.png" };
            u.Add(o);
            o = new Plugin() { Level = 2, Text1 = "Danh mục", Text2 = "Catalog", Type = "POS.PRE.Catalog", Icon = @"Icon\Catalog.png" };
            u.Add(o);
            o = new Plugin() { Level = 3, Text1 = "Nhóm hàng", Text2 = "Group", Type = "POS.PRE.Catalog.FrmGroup", Icon = @"Icon\Group.png" };
            u.Add(o);
            o = new Plugin() { Level = 3, Text1 = "Loại hàng", Text2 = "Kind", Type = "POS.PRE.Catalog.FrmKind", Icon = @"Icon\Kind.png" };
            u.Add(o);
            o = new Plugin() { Level = 3, Text1 = "Sản phẩm", Text2 = "Product", Type = "POS.PRE.Catalog.FrmProduct", Icon = @"Icon\Product.png" };
            u.Add(o);
            o = new Plugin() { Level = 2, Text1 = "Báo cáo", Text2 = "Report", Type = "POS.PRE.Report", Icon = @"Icon\Report.png" };
            u.Add(o);
            o = new Plugin() { Level = 3, Text1 = "In ấn", Text2 = "Print", Type = "POS.PRE.Report.FrmPrint", Icon = @"Icon\Print.png" };
            u.Add(o);
            o = new Plugin() { Level = 2, Text1 = "Thống kê", Text2 = "Sumary", Type = "POS.PRE.Sumary", Icon = @"Icon\Sumary.png" };
            u.Add(o);
            o = new Plugin() { Level = 3, Text1 = "Doanh thu", Text2 = "Sales", Type = "POS.PRE.Sumary.FrmSales", Icon = @"Icon\Sales.png" };
            u.Add(o);
            o = new Plugin() { Level = 2, Text1 = "Kiểm tra", Text2 = "Test", Type = "POS.PRE", Icon = @"Icon\Test.png" };
            u.Add(o);
            o = new Plugin() { Level = 3, Text1 = "Cơ sở", Text2 = "Base", Type = "POS.PRE.FrmBase", Icon = @"Icon\Base.png" };
            u.Add(o);

            var x = u.ToDataTable(false, typeof(Plugin).Name);
            x.WriteXml(Application.StartupPath + @"\Menu.xml");
        }
    }
}