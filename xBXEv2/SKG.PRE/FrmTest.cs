using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.PRE
{
    using UTL.Extension;
    using UTL.Plugin;

    public partial class FrmTest : Form
    {
        private const string STR_PREFIX = "xBXEv1.PRE.";

        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            //var d = DateTime.Now;

            //var d1 = d.ToStartOfDay();
            //var d2 = d.ToEndOfDay();

            //var w1 = d.ToStartOfWeek();
            //var v2 = d.ToEndOfWeek();

            //var n1 = 100;
            //var n2 = 100L;
            //var n3 = 100D;

            //var t = n1.ToVietnamese("đồng");
            //t = n2.ToVietnamese("đồng");
            //t = n3.ToVietnamese("đồng");

            //var a = AppDomain.CurrentDomain.BaseDirectory + @"\Plugins";
            //var b = Services.FindConfigs(a);
            //LoadMenu(b);
        }

        private void LoadMenu(List<string> l)
        {
            var u = new List<AvailablePlugin>();
            var o = new AvailablePlugin() { Level = 1, Text1 = "Vận tải", Text2 = "Transport", Type = "BXE", Icon = @"Icon\Transport.png" };
            u.Add(o);
            o = new AvailablePlugin() { Level = 2, Text1 = "Danh mục", Text2 = "Catalog", Type = "BXE.PRE.Catalog", Icon = @"Icon\Catalog.png" };
            u.Add(o);
            o = new AvailablePlugin() { Level = 3, Text1 = "Nhóm xe", Text2 = "Group", Type = "BXE.PRE.Catalog.FrmGroup", Icon = @"Icon\Group.png" };
            u.Add(o);
            o = new AvailablePlugin() { Level = 3, Text1 = "Loại xe", Text2 = "Kind", Type = "BXE.PRE.Catalog.FrmKind", Icon = @"Icon\Kind.png" };
            u.Add(o);
            o = new AvailablePlugin() { Level = 3, Text1 = "Xe cộ", Text2 = "Vehicle", Type = "BXE.PRE.Catalog.FrmVehicle", Icon = @"Icon\Vehicle.png" };
            u.Add(o);
            o = new AvailablePlugin() { Level = 2, Text1 = "Báo cáo", Text2 = "Report", Type = "BXE.PRE.Report", Icon = @"Icon\Report.png" };
            u.Add(o);
            o = new AvailablePlugin() { Level = 3, Text1 = "In ấn", Text2 = "Print", Type = "BXE.PRE.Report.FrmPrint", Icon = @"Icon\Print.png" };
            u.Add(o);
            o = new AvailablePlugin() { Level = 2, Text1 = "Thống kê", Text2 = "Sumary", Type = "BXE.PRE.Sumary", Icon = @"Icon\Sumary.png" };
            u.Add(o);
            o = new AvailablePlugin() { Level = 3, Text1 = "Doanh thu", Text2 = "Sales", Type = "BXE.PRE.Sumary.FrmSales", Icon = @"Icon\Sales.png" };
            u.Add(o);
            o = new AvailablePlugin() { Level = 2, Text1 = "Kiểm tra", Text2 = "Test", Type = "BXE.PRE", Icon = @"Icon\Test.png" };
            u.Add(o);
            o = new AvailablePlugin() { Level = 3, Text1 = "Cơ sở", Text2 = "Base", Type = "BXE.PRE.FrmBase", Icon = @"Icon\Base.png" };
            u.Add(o);

            //var x = u.ToDataTable(false, typeof(AvailablePlugin).Name);
            //x.WriteXml("c:\\t.xml");

            menuStrip1.LoadMenu(l);
        }

        private void LoadMenu()
        {
            if (Global.Plugins.AvailablePlugins.Count > 0)
            {
                AddMenu(ref tsmSystem);
                AddMenu(ref tsmSystem, STR_PREFIX + "FrmDemo");
                AddMenu(ref tsmSystem);
                tsmSystem.DropDownItems.Add("&Thoát");

                //AddMenu(ref mnuDsa, "FrmAfcVbq");
                //AddMenu(ref mnuDsa, "FrmAfcGaa");
                //AddMenu(ref mnuDsa);
                //AddMenu(ref mnuDsa, "FrmIkkDka");
                //AddMenu(ref mnuDsa, "FrmLgoSci");

                //AddMenu(ref mnuTke, "FrmTkeVbq");
                //AddMenu(ref mnuTke, "FrmTkeGaa");
                //AddMenu(ref mnuTke, "FrmAhvBdd");
            }
        }

        private static AvailablePlugin FindPlugin(string name)
        {
            foreach (AvailablePlugin pluginOn in Global.Plugins.AvailablePlugins)
                if (pluginOn.Instance.Frmcontrol.GetFullName() == name)
                    return pluginOn;
            return null;
        }

        private static void AddMenu(ref ToolStripMenuItem mnu, string name = null)
        {
            if (name == null) mnu.DropDownItems.Add(new ToolStripSeparator());
            else
            {
                var res = FindPlugin(name);
                //if (res != null) mnu.DropDownItems.Add(res.Instance.Name);
                if (res != null) mnu.DropDownItems.Add(name);
            }
        }

        private static void DisMenu(ref ToolStripMenuItem mnu, string name, bool enabled = true)
        {
            for (int i = 0; i < mnu.DropDownItems.Count; i++)
            {
                var o = mnu.DropDownItems[i];
                if (o.Text == name) o.Enabled = enabled;
            }
        }
    }
}