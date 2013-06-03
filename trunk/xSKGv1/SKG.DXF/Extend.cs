﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 02/06/2013 08:52
 * Status: OK
 */
#endregion

using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace SKG.DXF
{
    using BLL;
    using Home.Sytem;
    using DAL.Entities;

    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraTreeList;
    using DevExpress.Utils.Drawing;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraGrid.Views.BandedGrid;
    using DevExpress.XtraTreeList.StyleFormatConditions;

    /// <summary>
    /// Extension of methods for presentation layer
    /// </summary>
    public static class Extend
    {
        /// <summary>
        /// Main form ribbon
        /// </summary>
        private static FrmMain _frmMain = (FrmMain)Global.Parent;

        #region Numbered
        /// <summary>
        /// Numbered on GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                e.Info.DisplayText = (e.RowHandle + 1) + "";
            }
        }

        /// <summary>
        /// Numbered on TreeList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CustomDrawNodeIndicator(object sender, CustomDrawNodeIndicatorEventArgs e)
        {
            var tree = (TreeList)sender;
            var args = (IndicatorObjectInfoArgs)e.ObjectArgs;
            var tmp = tree.GetVisibleIndexByNode(e.Node);

            if (e.IsNodeIndicator && tmp >= 0)
            {
                args.DisplayText = (tmp + 1) + "";
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                e.ImageIndex = -1;
            }
        }
        #endregion

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
        /// Set standard BandedGridView
        /// </summary>
        /// <param name="grv">BandedGridView</param>
        public static void SetStandard(this BandedGridView grv, int width = 40)
        {
            try
            {
                grv.OptionsView.ShowAutoFilterRow = true;
                grv.OptionsView.ColumnAutoWidth = false;

                grv.OptionsBehavior.Editable = false;
                grv.Appearance.BandPanel.Options.UseTextOptions = true;
                grv.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
                grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
                grv.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

                grv.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(CustomDrawRowIndicator);
                grv.IndicatorWidth = width;
                grv.Columns["No_"].Visible = false;
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
        /// Set standard GridView
        /// </summary>
        /// <param name="grv">GridView</param>
        public static void SetStandard(this GridView grv, int width = 40)
        {
            try
            {
                grv.OptionsView.ShowAutoFilterRow = true;
                grv.OptionsBehavior.Editable = false;
                grv.OptionsView.ColumnAutoWidth = false;

                grv.Appearance.HeaderPanel.Options.UseTextOptions = true;
                grv.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

                grv.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(CustomDrawRowIndicator);
                grv.IndicatorWidth = width;
                grv.Columns["No_"].Visible = false;
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
        /// Set standard TreeList
        /// </summary>
        /// <param name="trl">TreeList</param>
        public static void SetStandard(this TreeList trl, int width = 40)
        {
            try
            {
                trl.OptionsView.ShowAutoFilterRow = true;
                trl.OptionsBehavior.Editable = false;

                trl.Appearance.HeaderPanel.Options.UseTextOptions = true;
                trl.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

                trl.CustomDrawNodeIndicator += new CustomDrawNodeIndicatorEventHandler(CustomDrawNodeIndicator);
                trl.IndicatorWidth = width;
                trl.Columns["No_"].Visible = false;
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
                var menu = BaseBLL._bll.Pol_Dictionary.SelectRights();
                if (menu == null) return;

                var path = Path.GetDirectoryName(s) + @"\";
                var asm = Assembly.LoadFile(s);

                RibbonPage m1 = null;
                RibbonPageGroup m2 = null;

                var root = menu.Select("ParentId Is Null");
                foreach (System.Data.DataRow r1 in root)
                {
                    var text = r1["Text"] + "";
                    var code = r1["Code"] + "";
                    var icon = String.Format("{0}{1}", path, r1["More"]);

                    m1 = new RibbonPage(text.ToUpper());
                    var zac = Global.Session.GetZAction(code);
                    m1.Visible = zac != null ? zac.Access : false;
                    if (!m1.Visible) continue;

                    m1.Tag = code;
                    m1.Image = Image.FromFile(icon);
                    m.Pages.Add(m1);

                    var con = menu.Select(String.Format("ParentId = '{0}'", r1["Id"]));
                    foreach (System.Data.DataRow r2 in con)
                    {
                        text = r2["Text"] + "";
                        code = r2["Code"] + "";
                        icon = String.Format("{0}{1}", path, r2["More"]);

                        m2 = new RibbonPageGroup(text.ToUpper());
                        zac = Global.Session.GetZAction(code);
                        m2.Visible = zac != null ? zac.Access : false;
                        if (!m2.Visible) continue;

                        m2.Tag = code;
                        m2.Glyph = Image.FromFile(icon);
                        m1.Groups.Add(m2);

                        var chau = menu.Select(String.Format("ParentId = '{0}'", r2["Id"]));
                        foreach (System.Data.DataRow r3 in chau)
                        {
                            text = r3["Text"] + "";
                            code = r3["Code"] + "";
                            icon = String.Format("{0}{1}", path, r3["More"]);

                            // Change name menu out gate for admin or operator
                            if (code == typeof(Station.Manage.FrmTra_GateOut).FullName)
                            {
                                var ql = Global.Session.User.CheckAdmin() || Global.Session.User.CheckOperator();
                                if (ql) text = "Tạm ra bến";
                            }

                            var m3 = new BarButtonItem() { Caption = text.ToUpper() };

                            if (code != typeof(FrmPol_Login).FullName)
                            {
                                zac = Global.Session.GetZAction(code);
                                var ok = zac != null ? zac.Access : false;
                                m3.Visibility = ok ? BarItemVisibility.Always : BarItemVisibility.Never;
                            }

                            if (m3.Visibility == BarItemVisibility.Always)
                            {
                                m2.ItemLinks.Add(m3);
                                m3.Tag = asm.CreateInstance(code);

                                /*var tmp = asm.CreateInstance(code);
                                if (tmp is Form)
                                {
                                    var frm = (Form)tmp;
                                    frm.Text = text.ToUpper();
                                    m3.Tag = frm;
                                }
                                else m3.Tag = tmp;*/

                                m3.LargeGlyph = Image.FromFile(icon);
                                m3.ItemClick += ButtonItem_ItemClick;
                            }
                        }
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
                else if (n == typeof(Help.Infor.Frm_Manual).FullName)
                {
                    System.Windows.Forms.Help.ShowHelp(_frmMain, @"Manual.chm");
                    return;
                }
                else if (n == typeof(Help.Infor.Frm_About).FullName)
                {
                    var frm = new Help.Infor.Frm_About();
                    frm.ShowDialog();
                    return;
                }

                var f = (Form)e.Item.Tag;
                if (f.GetType().BaseType == typeof(FrmInput))
                {
                    if (f == null || f.IsDisposed)
                        f = Activator.CreateInstance(f.GetType()) as FrmInput;

                    f.Text = e.Item.Caption;
                    ((FrmInput)f).ShowRight(Global.Parent);
                }
                else
                {
                    if (f == null || f.IsDisposed)
                        f = Activator.CreateInstance(f.GetType()) as Form;

                    if (f.GetType().FullName != typeof(FrmPol_Login).FullName)
                    {
                        f.MdiParent = Global.Parent;
                        f.Text = e.Item.Caption;
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
            _frmMain.bsiUser.Caption = String.Format("{0} - {1}",
                Global.Session.User.Name.ToUpper(), Global.Session.User.Note);

            var menuz1 = _frmMain.ribbon.FindMenuz(typeof(Home.Level1).FullName);
            var menuz2 = menuz1.FindMenuz(typeof(Home.Sytem.Level2).FullName);
            var menuz3 = menuz2.FindMenuz(typeof(Home.Sytem.FrmPol_Login).FullName);

            _frmMain.InitSkinGallery(menuz1);

            menuz3.LargeGlyph = Image.FromFile(Application.StartupPath + @"\Icons\Logout.png");
            menuz3.Caption = "ĐĂNG XUẤT";

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

        /// <summary>
        /// Format bold, color row parent
        /// </summary>
        /// <param name="trl">TreeList</param>
        /// <param name="font">Font</param>
        /// <param name="col">Colum name</param>
        public static void FormatRows(this TreeList trl, Font font, string col)
        {
            var sfc = new StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal,
                trl.Columns[col], null, true, true, true);

            sfc.Appearance.BackColor = Color.Orange;
            sfc.Appearance.BackColor2 = Color.Yellow;
            sfc.Appearance.GradientMode = LinearGradientMode.BackwardDiagonal;

            var f = new Font(font, FontStyle.Bold);
            sfc.Appearance.Font = f;
            sfc.Appearance.ForeColor = Color.Blue;

            trl.FormatConditions.Add(sfc);
        }
    }
}