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
            menuStrip1.Items.Add("Toàn");

            foreach (var i in l)
            {
                var a = i.ToMenu("form");
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