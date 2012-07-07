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
        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            var a = AppDomain.CurrentDomain.BaseDirectory + @"\Plugins";
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



        private static AvailablePlugin FindPlugin(string name)
        {
            foreach (AvailablePlugin pluginOn in Global.Plugins.Plugins)
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