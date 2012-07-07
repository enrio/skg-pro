using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            var b = AppDomain.CurrentDomain.BaseDirectory + @"Plugins\POS\";
            menuStrip1.LoadMenu(b);

            Global.Plugins.FindPlugins();
            var f = (a + "Menu.xml").ToMenu(typeof(Plugin).Name);
            foreach (Plugin i in Global.Plugins.Plugins)
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

            var x = res.ToDataTable(false, typeof(Plugin).Name);
            x.WriteXml(Application.StartupPath + @"\Menu.xml");
        }

        private void Data()
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
    }
}