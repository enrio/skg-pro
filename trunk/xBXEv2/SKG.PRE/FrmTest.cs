using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.PRE
{
    using UTL;
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

            var a = AppDomain.CurrentDomain.BaseDirectory + @"\Plugins";
            var b = Global.Plugins.FindConfigs(a);
            LoadMenu(b);
        }

        private void LoadMenu(List<string> l)
        {
            //var u = new List<AvailablePlugin>();
            //var o = new AvailablePlugin() { Id = "1", ParentId = "0", Text1 = "Vận tải", Text2 = "Transport", Type = "BXE" };
            //u.Add(o);
            //o = new AvailablePlugin() { Id = "2", ParentId = "1", Text1 = "Danh mục", Text2 = "Catalog", Type = "BXE.PRE.Catalog" };
            //u.Add(o);
            //o = new AvailablePlugin() { Id = "3", ParentId = "2", Text1 = "Nhóm xe", Text2 = "Group", Type = "BXE.PRE.Catalog.FrmGroup" };
            //u.Add(o);
            //o = new AvailablePlugin() { Id = "4", ParentId = "2", Text1 = "Loại xe", Text2 = "Kind", Type = "BXE.PRE.Catalog.FrmKind" };
            //u.Add(o);
            //o = new AvailablePlugin() { Id = "5", ParentId = "2", Text1 = "Xe cộ", Text2 = "Vehicle", Type = "BXE.PRE.Catalog.FrmVehicle" };
            //u.Add(o);
            //o = new AvailablePlugin() { Id = "6", ParentId = "1", Text1 = "Báo cáo", Text2 = "Report", Type = "BXE.PRE.Report" };
            //u.Add(o);
            //o = new AvailablePlugin() { Id = "7", ParentId = "6", Text1 = "In ấn", Text2 = "Print", Type = "BXE.PRE.Report.Print" };
            //u.Add(o);
            //o = new AvailablePlugin() { Id = "8", ParentId = "1", Text1 = "Thống kê", Text2 = "Sumary", Type = "BXE.PRE.Sumary" };
            //u.Add(o);
            //o = new AvailablePlugin() { Id = "9", ParentId = "8", Text1 = "Doanh thu", Text2 = "Sales", Type = "BXE.PRE.Sumary.Sales" };
            //u.Add(o);
            //o = new AvailablePlugin() { Id = "10", ParentId = "1", Text1 = "Kiểm tra", Text2 = "Test", Type = "BXE.PRE.Test" };
            //u.Add(o);
            //o = new AvailablePlugin() { Id = "11", ParentId = "10", Text1 = "Cơ sở", Text2 = "", Type = "BXE.PRE.Test.FrmBase" };
            //u.Add(o);

            //var x = UTL.BaseUTL.Linq2Table(u, "menu");
            ////x.WriteXml("c:\\t.xml");

            foreach (var i in l)
            {
                var a = i.ToMenu("menu");
                if (a == null) continue;

                var oo = new ToolStripMenuItem(a[0].Text1);
                var b = menuStrip1.Items.Add(oo);

                for (int j = 1; j < a.Count; j++) oo.DropDownItems.Add(a[j].Text1);
            }
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