#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 25/07/2012 00:16
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF
{
    using BLL;
    using System.IO;
    using Home.Sytem;
    using DAL.Entities;
    using System.Drawing;
    using System.Reflection;
    using DevExpress.XtraBars;
    using System.Windows.Forms;
    using DevExpress.XtraEditors;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraTreeList.Columns;

    /// <summary>
    /// Extension of methods for presentation layer
    /// </summary>
    public static class Extend
    {
        /// <summary>
        /// Main form ribbon
        /// </summary>
        private static FrmMain _frmMain = (FrmMain)Global.Parent;

        #region Form methods
        /// <summary>
        /// Show or hide RibbonControl, DockPanel, BarManager of parent form
        /// </summary>
        /// <param name="parent">Parent</param>
        /// <param name="visible">Show or hide</param>
        public static void VisibleParentForm(this Form parent, bool visible = true)
        {
            try
            {
                if (parent == null) return;
                foreach (Control i in parent.Controls)
                {
                    var a = i.GetType();
                    if (a == typeof(RibbonControl)) i.Visible = visible;
                    if (a == typeof(DockPanel)) i.Visible = visible;
                    if (a == typeof(BarManager)) i.Visible = visible;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }

        /// <summary>
        /// Show or hide RibbonPage of RibbonForm, exclude RibbonPage first and end
        /// </summary>
        /// <param name="parent">Parent</param>
        /// <param name="visible">Show or hide</param>
        public static void VisibleMenuParentForm(this Form parent, bool visible = true)
        {
            try
            {
                if (parent == null) return;
                var i = ((RibbonForm)parent).Ribbon.Pages.Count - 1;
                while (i-- > 1) ((RibbonForm)parent).Ribbon.Pages[i].Visible = visible;
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }

        /// <summary>
        /// Delete all RibbonPage - ItemLinks (menu) of parent form
        /// </summary>
        /// <param name="parent">Parent</param>
        public static void ClearMenuParentForm(this Form parent)
        {
            try
            {
                if (parent == null) return;
                while (((RibbonForm)parent).Ribbon.Pages.Count > 0)
                    ((RibbonForm)parent).Ribbon.Pages[0].Dispose();

                /*while (((RibbonForm)parent).Ribbon.Pages.Count > 1)
                    ((RibbonForm)parent).Ribbon.Pages[1].Dispose();
                while (((ApplicationMenu)((RibbonForm)parent).Ribbon.ApplicationButtonDropDownControl).ItemLinks.Count > 1)
                    ((ApplicationMenu)((RibbonForm)parent).Ribbon.ApplicationButtonDropDownControl).ItemLinks[1].Dispose();*/
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }

        /// <summary>
        /// Close all children form
        /// </summary>
        /// <param name="parent">Parent</param>
        public static void CloseAllChildrenForm(this Form parent)
        {
            try
            {
                if (parent == null) return;
                foreach (Form childrenForm in parent.MdiChildren)
                    childrenForm.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }

        /// <summary>
        /// Close all children form exclude login form
        /// </summary>
        /// <param name="parent">Parent</param>
        /// <param name="active">Login</param>
        public static void CloseAllChildrenForm(this Form parent, Form active)
        {
            try
            {
                if (parent == null) return;
                var name = typeof(FrmPol_Login).FullName;
                foreach (Form child in parent.MdiChildren)
                    if (child != active && child.GetType().FullName != name)
                        child.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }

        /// <summary>
        /// Get children form
        /// </summary>
        /// <param name="parent">Parent</param>
        /// <param name="childName">Full name</param>
        /// <returns></returns>
        public static Form GetMdiChilden(this Form parent, string childName)
        {
            try
            {
                Form tmp = null;
                if (parent.MdiChildren == null) return tmp;
                foreach (Form frm in parent.MdiChildren)
                    if (frm.GetType().FullName == childName)
                    {
                        tmp = frm;
                        break;
                    }
                return tmp;
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        /// <summary>
        /// Show form with user's right
        /// </summary>
        /// <param name="form">Form right</param>
        static void ShowRight(this FrmInput form)
        {
            try
            {
                var code = form.GetType().FullName;
                if (code == typeof(FrmMenuz).Name) return;

                var bll = new Pol_DictionaryBLL();
                var o = (Pol_Dictionary)bll.Select(code);

                if (o == null)
                {
                    o = new Pol_Dictionary() { Code = code, Text = form.Text, Note = "" };
                    bll.InsertRight(o);
                }

                Zaction z = form.CheckRight();
                if (z == null || z.Access == false) form.Dispose();
                else form.Show();
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }

        /// <summary>
        /// Show form with user's right, create by its class
        /// </summary>
        /// <typeparam name="T">Class of form need to create</typeparam>
        /// <param name="parent">Parent</param>
        public static void ShowRight<T>(this Form parent) where T : Form, new()
        {
            try
            {
                var x = typeof(T);
                var frm = (T)GetMdiChilden(parent, x.FullName);
                if (frm == null || frm.IsDisposed)
                {
                    frm = new T() { MdiParent = parent };
                    if (x.BaseType == typeof(FrmInput))
                        (frm as FrmInput).ShowRight();
                    else frm.Show();
                }
                else frm.Activate();
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }

        /// <summary>
        /// Show form with user's rights
        /// </summary>
        /// <param name="form">Childen</param>
        /// <param name="parent">Parent</param>
        public static void ShowRight(this FrmInput form, Form parent)
        {
            try
            {
                var a = form.GetType();
                var b = (FrmInput)GetMdiChilden(parent, a.FullName);
                if (b == null || b.IsDisposed)
                {
                    form.MdiParent = parent;
                    form.ShowRight();
                }
                else b.Activate();
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }

        /// <summary>
        /// Set false some properties's DockPanel
        /// </summary>
        /// <param name="dock">Dock panel</param>
        /// <param name="text">Caption</param>
        public static void SetDockPanel(this DockPanel dock, string text)
        {
            try
            {
                dock.Options.AllowFloating = false;
                dock.Options.FloatOnDblClick = false;
                dock.Options.ShowAutoHideButton = false;
                dock.Options.ShowCloseButton = false;
                dock.Options.ShowMaximizeButton = false;
                dock.Text = text;
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }

        /// <summary>
        /// Best fit columns
        /// </summary>
        /// <param name="tree">Tree list</param>
        public static void AutoFit(this TreeList tree)
        {
            try
            {
                foreach (TreeListColumn x in tree.Columns)
                {
                    if (x.VisibleIndex != tree.Columns.Count - 1)
                        x.BestFit();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }
        #endregion

        #region Menu methods
        /// <summary>
        /// Load all menu for RibbonControl
        /// </summary>
        /// <param name="ribbon">Ribbon control</param>
        /// <param name="l">List all of plugin file name</param>
        /// <param name="parent">Parent</param>
        public static void LoadMenu(this RibbonControl ribbon, List<string> l)
        {
            try
            {
                foreach (var i in l) ribbon.LoadMenu(i);
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }

        /// <summary>
        /// Load menu for RibbonControl
        /// </summary>
        /// <param name="m">Ribbon control</param>
        /// <param name="s">Plugin file name</param>
        public static void LoadMenu(this RibbonControl m, string s)
        {
            try
            {
                var menu = Services.GetMenu(s);
                if (menu == null) return;
                var path = Path.GetDirectoryName(s) + @"\";

                RibbonPage m1 = null;
                RibbonPageGroup m2 = null;

                for (int j = 0; j < menu.Count; j++)
                {
                    if (menu[j].Level == 1) // menu level 1 (root)
                    {
                        m1 = new RibbonPage(menu[j].Text);

                        var zac = Global.Session.GetZAction(menu[j].Code);
                        //m1.Visible = zac != null ? zac.Access : false;

                        m1.Tag = menu[j].Code;
                        m1.Image = Image.FromFile(path + menu[j].Picture);
                        m.Pages.Add(m1);
                    }
                    else if (menu[j].Level == 2) // menu level 2
                    {
                        m2 = new RibbonPageGroup(menu[j].Text);

                        var zac = Global.Session.GetZAction(menu[j].Code);
                        //m2.Visible = zac != null ? zac.Access : false;

                        m2.Tag = menu[j].Code;
                        m2.Glyph = Image.FromFile(path + menu[j].Picture);
                        m1.Groups.Add(m2);
                    }
                    else if (m2 != null) // menu level 3
                    {
                        var m3 = new BarButtonItem() { Caption = menu[j].Text };

                        if (menu[j].Code != typeof(FrmPol_Login).FullName)
                        {
                            var zac = Global.Session.GetZAction(menu[j].Code);
                            m3.Enabled = zac != null ? zac.Access : false;
                        }

                        m2.ItemLinks.Add(m3);
                        Assembly y = Assembly.LoadFile(s);
                        m3.Tag = y.CreateInstance(menu[j].Code);
                        m3.LargeGlyph = Image.FromFile(path + menu[j].Picture);
                        m3.ItemClick += ButtonItem_ItemClick;
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }

        /// <summary>
        /// Find menuz level 1 (RibbonPage) on RibbonControl
        /// </summary>
        /// <param name="m">RibbonControl</param>
        /// <param name="tag">Type of menuz</param>
        /// <returns></returns>
        public static RibbonPage FindMenuz(this RibbonControl m, string tag)
        {
            var res = new RibbonPage();
            foreach (RibbonPage i in m.Pages)
                if (i.Tag + "" == tag)
                {
                    res = i;
                    break;
                }
            return res;
        }

        /// <summary>
        /// Find menuz level 2 (RibbonPageGroup) on RibbonPage
        /// </summary>
        /// <param name="m">RibbonPage</param>
        /// <param name="tag">Type of menuz</param>
        /// <returns></returns>
        public static RibbonPageGroup FindMenuz(this RibbonPage m, string tag)
        {
            var res = new RibbonPageGroup();
            foreach (RibbonPageGroup i in m.Groups)
                if (i.Tag + "" == tag)
                {
                    res = i;
                    break;
                }
            return res;
        }

        /// <summary>
        /// Find menuz level 3 (BarButtonItem) on RibbonPageGroup
        /// </summary>
        /// <param name="m">RibbonPageGroup</param>
        /// <param name="tag">Type of menuz</param>
        /// <returns></returns>
        public static BarButtonItem FindMenuz(this RibbonPageGroup m, string tag)
        {
            var res = new BarButtonItem();
            foreach (var i in m.ItemLinks)
            {
                var o = (BarButtonItemLink)i;
                var f = (Form)o.Item.Tag;
                if (f.GetType().FullName + "" == tag)
                {
                    res = o.Item;
                    break;
                }
            }
            return res;
        }

        /// <summary>
        /// Click on menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var n = e.Item.Tag.GetType().FullName;
                if (n == typeof(FrmPol_Close).FullName)
                {
                    CloseAllChildrenForm(_frmMain);
                    return;
                }
                else if (n == typeof(FrmPol_Exit).FullName)
                {
                    Application.Exit();
                    Application.ExitThread();
                    return;
                }
                else if (n == typeof(Help.Infor.Frm_PolManual).FullName)
                {
                    System.Windows.Forms.Help.ShowHelp(_frmMain, @"Manual.chm");
                    return;
                }

                var f = (Form)e.Item.Tag;
                if (f.GetType().BaseType == typeof(FrmInput))
                {
                    if (f == null || f.IsDisposed) f = Activator.CreateInstance(f.GetType()) as FrmInput;
                    ((FrmInput)f).ShowRight(Global.Parent);
                }
                else
                {
                    if (f == null || f.IsDisposed) f = Activator.CreateInstance(f.GetType()) as Form;
                    if (f.GetType().FullName != typeof(FrmPol_Login).FullName)
                    {
                        f.MdiParent = Global.Parent;
                        f.Show();
                    }
                    else Login();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return;
            }
        }
        #endregion

        #region Login
        /// <summary>
        /// After logon, show menuz, exchange login and logout button
        /// </summary>
        public static void AfterLogon()
        {
            // Load menuz
            var GetPlugins = Global.Service.GetPlugins();
            _frmMain.ribbon.LoadMenu(GetPlugins);

            VisibleMenuParentForm(_frmMain);
            _frmMain.bsiUser.Caption = Global.Session.User.Name;

            var ax = SKG.Extend.Data.ToDataTable(Global.Session.User.Pol_RoleRights);
            var bx = SKG.Extend.Data.ToDataTable(Global.Session.User.Pol_UserRights);
            var cx = SKG.Extend.Data.ToDataTable(Global.Session.User.Pol_UserRoles);

            var menuz1 = _frmMain.ribbon.FindMenuz(typeof(Home.Level1).FullName);
            var menuz2 = menuz1.FindMenuz(typeof(Home.Sytem.Level2).FullName);
            var menuz3 = menuz2.FindMenuz(typeof(Home.Sytem.FrmPol_Login).FullName);

            menuz3.LargeGlyph = Image.FromFile(Application.StartupPath + @"\Icons\Logout.png");
            menuz3.Caption = "Đăng xuất";

            // Show default form
            var d = Global.Session.Default;
            foreach (var r in d)
            {
                if (r.Code == null) continue;
                var a = typeof(SKG.DXF.Home.Grant.Level2).Namespace;
                var t = Type.GetType(String.Format("{0}.{1}", a, r.Code));
                if (t == null)
                {
                    a = typeof(SKG.DXF.Home.Catalog.Level2).Namespace;
                    t = Type.GetType(String.Format("{0}.{1}", a, r.Code));
                }
                if (t == null) t = Type.GetType(r.Code);
                if (t == null) continue;

                var frm = Activator.CreateInstance(t) as FrmInput;
                if (frm != null) frm.ShowRight(_frmMain);
            }
        }

        /// <summary>
        /// Before logon, hide menuz, exchange login and logout button
        /// </summary>
        public static void BeforeLogon()
        {
            ClearMenuParentForm(_frmMain);
            _frmMain.bsiUser.Caption = null;

            //VisibleMenuParentForm(_frmMain, false);
            //bbiLogin.LargeGlyph = Properties.Resources.login;
            //bbiLogin.Caption = Properties.Settings.Default.Login;
            //rpgPermission.Visible = false;
        }

        /// <summary>
        /// Perform login
        /// </summary>
        public static void Login()
        {
            try
            {
                CloseAllChildrenForm(_frmMain);

                var x = typeof(FrmPol_Login);
                var frm = (FrmPol_Login)GetMdiChilden(_frmMain, x.FullName);
                if (frm == null) frm = new FrmPol_Login() { MdiParent = _frmMain };

                frm.BeforeLogon += BeforeLogon;
                frm.AfterLogon += AfterLogon;

                frm.Show();
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, _frmMain.Text); }
        }
        #endregion
    }
}