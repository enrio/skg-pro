using System;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;

namespace SKG
{
    public partial class FrmAepAjf : Form
    {
        private const string STR_LOGIN = "Đăng &nhập";
        public static UTL.BLL.UecLajVei _sss = new UTL.BLL.UecLajVei();
        private const string STR_LOGOUT = "Đăng &xuất";

        public FrmAepAjf()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            // Check license
            var key = new UTL.HSH.FawCdt();
            var res = key.Read("Key");

            if (UTL.HSH.BamDul.isLincense(res))
            {
                mnuSys.Enabled = true;
                mnuBauVlv.Enabled = false;
            }
            else
            {
                mnuSys.Enabled = false;
                mnuBauVlv.Enabled = true;
            }
        }

        private void FrmAepAjf_Load(object sender, EventArgs e)
        {
            tmrFhvHfj_Tick(sender, e);
            staMbzAil.Text = String.Format("{0} - {1}", GetServer(), GetDb());

            Config();

            Global.Plugins.FindPlugins();
            LoadMenu(); EnableMenu();

            // Auto load login form
            if (mnuSys.Enabled)
            {
                var ex = new ToolStripItemClickedEventArgs(new ToolStripMenuItem());
                ex.ClickedItem.Text = STR_LOGIN;
                mnuSys_DropDownItemClicked(sender, ex);
            }
        }

        private void mnuSys_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == STR_LOGOUT)
            {
                _sss.Login = false;
                e.ClickedItem.Text = STR_LOGIN;
                EnableMenu();
            }

            PlugTypes.AvailablePlugin selectedPlugin = Global.Plugins.AvailablePlugins.Find(e.ClickedItem.Text);
            if (selectedPlugin != null)
            {
                selectedPlugin.Instance.Frmcontrol.ShowDialog();
                object o = InvokeMethod(selectedPlugin.Instance.Frmcontrol, "GetSss");
                _sss = (UTL.BLL.UecLajVei)o;

                if (_sss.Login) e.ClickedItem.Text = STR_LOGOUT;
            }

            if (e.ClickedItem.Text == "&Thoát") Application.Exit();

            EnableMenu();
        }

        private void mnuDsa_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            PlugTypes.AvailablePlugin selectedPlugin = Global.Plugins.AvailablePlugins.Find(e.ClickedItem.Text);
            if (selectedPlugin != null)
            {
                selectedPlugin.Instance.Sss = _sss;
                selectedPlugin.Instance.Frmcontrol.ShowDialog();
            }
        }

        private void mnuTke_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            PlugTypes.AvailablePlugin selectedPlugin = Global.Plugins.AvailablePlugins.Find(e.ClickedItem.Text);
            if (selectedPlugin != null)
            {
                selectedPlugin.Instance.Sss = _sss;
                selectedPlugin.Instance.Frmcontrol.ShowDialog();
            }
        }

        private static object InvokeMethod(object instance, string methodName)
        {
            MethodInfo mi = instance.GetType().GetMethod(methodName);
            return mi.Invoke(instance, null);
        }

        private void mnuCbuHeq_Click(object sender, EventArgs e)
        {
            using (var x = new SYS.FrmCbuHeq())
            {
                var res = x.ShowDialog();
                if (res == DialogResult.OK) Config();
            }
        }

        private void EnableMenu()
        {
            if (_sss.Login)
            {
                switch (_sss.Role)
                {
                    case UTL.BLL.UecLajVei.Roles.Admin:
                        mnuDsa.Enabled = true;
                        mnuTke.Enabled = true;
                        mnuBca.Enabled = true;
                        mnuSboLii.Enabled = true;
                        mnuUilHga.Enabled = true;

                        DisMenu(ref mnuDsa, "Cổng &vào");
                        DisMenu(ref mnuDsa, "Cổng &ra");
                        DisMenu(ref mnuDsa, "Người &dùng");
                        DisMenu(ref mnuDsa, "&Loại xe");
                        break;

                    case UTL.BLL.UecLajVei.Roles.Manager:
                        mnuDsa.Enabled = false;
                        mnuTke.Enabled = true;
                        mnuBca.Enabled = true;
                        mnuSboLii.Enabled = false;
                        mnuUilHga.Enabled = false;

                        DisMenu(ref mnuDsa, "Cổng &vào", false);
                        DisMenu(ref mnuDsa, "Cổng &ra", false);
                        DisMenu(ref mnuDsa, "Người &dùng", false);
                        DisMenu(ref mnuDsa, "&Loại xe", false);
                        break;

                    case UTL.BLL.UecLajVei.Roles.User:
                        mnuDsa.Enabled = true;
                        mnuTke.Enabled = false;
                        mnuBca.Enabled = false;
                        mnuSboLii.Enabled = false;
                        mnuUilHga.Enabled = false;

                        DisMenu(ref mnuDsa, "Cổng &vào");
                        DisMenu(ref mnuDsa, "Cổng &ra");
                        DisMenu(ref mnuDsa, "Người &dùng", false);
                        DisMenu(ref mnuDsa, "&Loại xe", false);
                        break;

                    case UTL.BLL.UecLajVei.Roles.Gatein:
                        mnuDsa.Enabled = true;
                        mnuTke.Enabled = false;
                        mnuBca.Enabled = false;
                        mnuSboLii.Enabled = false;
                        mnuUilHga.Enabled = false;

                        DisMenu(ref mnuDsa, "Cổng &vào");
                        DisMenu(ref mnuDsa, "Cổng &ra", false);
                        DisMenu(ref mnuDsa, "Người &dùng", false);
                        DisMenu(ref mnuDsa, "&Loại xe", false);

                        // Auto show Gatein form
                        var ex = new ToolStripItemClickedEventArgs(new ToolStripMenuItem());
                        ex.ClickedItem.Text = "Cổng &vào";
                        mnuDsa_DropDownItemClicked(null, ex);
                        break;

                    case UTL.BLL.UecLajVei.Roles.Gateout:
                        mnuDsa.Enabled = true;
                        mnuTke.Enabled = false;
                        mnuBca.Enabled = false;
                        mnuSboLii.Enabled = false;
                        mnuUilHga.Enabled = false;

                        DisMenu(ref mnuDsa, "Cổng &vào", false);
                        DisMenu(ref mnuDsa, "Cổng &ra");
                        DisMenu(ref mnuDsa, "Người &dùng", false);
                        DisMenu(ref mnuDsa, "&Loại xe", false);

                        // Auto show Gatein form
                        ex = new ToolStripItemClickedEventArgs(new ToolStripMenuItem());
                        ex.ClickedItem.Text = "Cổng &ra";
                        mnuDsa_DropDownItemClicked(null, ex);
                        break;

                    case UTL.BLL.UecLajVei.Roles.None:
                        mnuDsa.Enabled = false;
                        mnuTke.Enabled = false;
                        mnuBca.Enabled = false;
                        mnuSboLii.Enabled = false;
                        mnuUilHga.Enabled = false;
                        break;
                }
            }
            else
            {
                mnuDsa.Enabled = false;
                mnuTke.Enabled = false;
                mnuBca.Enabled = false;
            }

            staFawObj.Text = String.Format("[{0}]", _sss.Name);
        }

        private void tmrFhvHfj_Tick(object sender, EventArgs e)
        {
            try
            {
                staYcpDar.Text = _sss.Current.Value.ToString("[dd/MM/yyyy HH:mm:ss]");
                _sss.Current = _sss.Current.Value.AddSeconds(1);
            }
            catch { staYcpDar.Text = DateTime.Now.ToString("[dd/MM/yyyy HH:mm:ss]"); }

        }

        private static string StrCnn()
        {
            Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return _config.ConnectionStrings.ConnectionStrings[1].ConnectionString;
        }

        private static string GetServer()
        {
            try
            {
                string str = StrCnn();
                string[] s = str.Split(new char[] { ';' });
                str = s[0];
                s = str.Split(new char[] { '=' });

                return s[1] == "." ? "LOCAL" : s[1];
            }
            catch { return "?"; }
        }

        private static string GetDb()
        {
            try
            {
                string str = StrCnn();
                string[] s = str.Split(new char[] { ';' });
                str = s[1];
                s = str.Split(new char[] { '=' });

                return s[1] == "." ? "BXE" : s[1];
            }
            catch { return "?"; }
        }

        private static bool CheckCnn()
        {
            var res = new UTL.RDR.SqlSvr(StrCnn());
            return res.Open();
        }

        private void Config()
        {
            if (CheckCnn()) mnuCbuHeq.Enabled = false;
            else
            {
                mnuCbuHeq.Enabled = true;
                mnuCbuHeq_Click(null, null);
            }
        }

        private static PlugTypes.AvailablePlugin FindPlugin(string name)
        {
            foreach (PlugTypes.AvailablePlugin pluginOn in Global.Plugins.AvailablePlugins)
                if (pluginOn.Instance.Frmcontrol.Name == name)
                    return pluginOn;
            return null;
        }

        private static void AddMenu(ref ToolStripMenuItem mnu, string name = null)
        {
            if (name == null) mnu.DropDownItems.Add(new ToolStripSeparator());
            else
            {
                var res = FindPlugin(name);
                if (res != null) mnu.DropDownItems.Add(res.Instance.Name);
            }
        }

        private void LoadMenu()
        {
            if (Global.Plugins.AvailablePlugins.Count > 0)
            {
                AddMenu(ref mnuSys);
                AddMenu(ref mnuSys, "FrmFawObj");
                AddMenu(ref mnuSys);
                mnuSys.DropDownItems.Add("&Thoát");

                AddMenu(ref mnuDsa, "FrmAfcVbq");
                AddMenu(ref mnuDsa, "FrmAfcGaa");
                AddMenu(ref mnuDsa);
                AddMenu(ref mnuDsa, "FrmIkkDka");
                AddMenu(ref mnuDsa, "FrmLgoSci");

                //AddMenu(ref mnuTke, "FrmTkeVbq");
                AddMenu(ref mnuTke, "FrmTkeGaa");
                AddMenu(ref mnuTke, "FrmAhvBdd");
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

        private void mnuYhvTeo_Click(object sender, EventArgs e)
        {
            using (var x = new FrmYhvTeo()) { x.ShowDialog(); }
        }

        private void mnuBauVlv_Click(object sender, EventArgs e)
        {
            using (var x = new UTL.HSH.FrmBauVlv()) { x.ShowDialog(); }
        }
    }
}