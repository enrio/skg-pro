using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.DXF
{
    using BLL;
    //using Main;
    using Plugin;
    using Catalog;
    using DAL.Entities;
    using System.Drawing;
    using System.Reflection;
    using DevExpress.XtraBars;
    using System.Windows.Forms;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraTreeList.Columns;

    public static class BasePRE
    {
        #region Extension for for load menu
        /// <summary>
        /// Form MDI parent
        /// </summary>
        public static Form Parent { get; set; }

        /// <summary>
        /// Load menu for RibbonControl
        /// </summary>
        /// <param name="m">RibbonControl</param>
        /// <param name="s">Path's Menu.xml</param>
        public static void LoadMenu(this RibbonControl m, List<string> l, Form f = null)
        {
            Parent = f;
            foreach (var i in l) m.LoadMenu(i);
        }

        /// <summary>
        /// Load menu for RibbonControl
        /// </summary>
        /// <param name="m">RibbonControl</param>
        /// <param name="s">Path's Menu.xml</param>
        public static void LoadMenu(this RibbonControl m, string s)
        {
            var menu = Services.GetMenu(s);
            RibbonPage m1 = null;
            RibbonPageGroup m2 = null;

            for (int j = 0; j < menu.Count; j++)
            {
                if (menu[j].Level == 1) // menu level 1 (root)
                {
                    m1 = new RibbonPage(menu[j].Caption);
                    m1.Image = Image.FromFile(s + menu[j].Picture);
                    m.Pages.Add(m1);
                }
                else if (menu[j].Level == 2) // menu level 2
                {
                    m2 = new RibbonPageGroup(menu[j].Caption);
                    m2.Glyph = Image.FromFile(s + menu[j].Picture);
                    m1.Groups.Add(m2);
                }
                else if (m2 != null) // menu level 3
                {
                    var m3 = new BarButtonItem() { Caption = menu[j].Caption };
                    m2.ItemLinks.Add(m3);

                    Assembly y = null;
                    try { y = Assembly.LoadFile(s + "BXE.PRE.dll"); }
                    catch { y = Assembly.LoadFile(s + "POS.dll"); }

                    m3.Tag = y.CreateInstance(menu[j].Type);
                    m3.LargeGlyph = Image.FromFile(s + menu[j].Picture);
                    m3.ItemClick += ButtonItem_ItemClick;
                }
            }
        }

        private static void ButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var f = (FrmInRight)e.Item.Tag;
                if (f == null || f.IsDisposed)
                    f = Activator.CreateInstance(f.GetType()) as FrmInRight;
                f.ShowRight(Parent);
            }
            catch { return; }
        }
        #endregion

        /// <summary>
        /// Phiên đăng nhập của người dùng hiện tại
        /// </summary>
        public static Session _sss = new Session();

        /// <summary>
        /// Ẩn/hiện RibbonControl, DockPanel, BarManager của form cha
        /// </summary>
        /// <param name="parent">Form cha</param>
        /// <param name="visible">true: hiện; false: ẩn</param>
        public static void VisibleParentForm(Form parent, bool visible = true)
        {
            if (parent != null)
            {
                foreach (Control i in parent.Controls)
                {
                    var a = i.GetType();
                    if (a == typeof(RibbonControl)) i.Visible = visible;
                    if (a == typeof(DockPanel)) i.Visible = visible;
                    if (a == typeof(BarManager)) i.Visible = visible;
                }
            }
        }

        /// <summary>
        /// Ẩn/hiện RibbonPage (menu) của RibbonForm, trừ RibbonPage đầu và cuối
        /// </summary>
        /// <param name="parent">Form cha</param>
        /// <param name="visible">true: hiện; false: ẩn</param>
        public static void VisibleMenuParentForm(Form parent, bool visible = true)
        {
            if (parent != null)
            {
                var i = ((RibbonForm)parent).Ribbon.Pages.Count - 1;
                while (i-- > 1)
                    ((RibbonForm)parent).Ribbon.Pages[i].Visible = visible;
            }
        }

        /// <summary>
        /// Xoá tất cả RibbonPage - ItemLinks (menu) của form cha
        /// </summary>
        /// <param name="parent">Form cha</param>
        public static void ClearMenuParentForm(Form parent)
        {
            try
            {
                if (parent != null)
                {
                    while (((RibbonForm)parent).Ribbon.Pages.Count > 1)
                        ((RibbonForm)parent).Ribbon.Pages[1].Dispose();

                    while (((ApplicationMenu)((RibbonForm)parent)
                        .Ribbon.ApplicationButtonDropDownControl)
                        .ItemLinks.Count > 1)
                        ((ApplicationMenu)((RibbonForm)parent)
                            .Ribbon.ApplicationButtonDropDownControl)
                            .ItemLinks[1].Dispose();
                }
            }
            catch { return; }
        }

        /// <summary>
        /// Đóng tất cả form con
        /// </summary>
        /// <param name="parent">Form cha</param>
        public static void CloseAllChildrenForm(Form parent)
        {
            if (parent != null)
                foreach (Form childrenForm in parent.MdiChildren)
                    childrenForm.Close();
        }

        /// <summary>
        /// Đóng tất cả form con
        /// </summary>
        /// <param name="parent">Form cha</param>
        /// <param name="active">Form không đóng</param>
        public static void CloseAllChildrenForm(Form parent, Form active)
        {
            if (parent != null)
            {
                var tmp = typeof(FrmInRight).FullName;

                foreach (Form child in parent.MdiChildren)
                    if (child != active && child.GetType().FullName != tmp)
                        child.Close();
            }
        }

        /// <summary>
        /// Lấy form con
        /// </summary>
        /// <param name="parent">Form cha</param>
        /// <param name="childName">Tên đầy đủ của form con</param>
        /// <returns>Form con</returns>
        public static Form GetMdiChilden(Form parent, string childName)
        {
            Form tmp = null;

            if (parent.MdiChildren != null)
                foreach (Form frm in parent.MdiChildren)
                    if (frm.GetType().FullName == childName)
                    {
                        tmp = frm;
                        break;
                    }

            return tmp;
        }

        /// <summary>
        /// Hiện form với quyền của người dùng
        /// </summary>
        /// <param name="frm">FrmBase</param>
        static void ShowRight(this FrmInRight frm)
        {
            var code = frm.GetType().Name;
            if (code == typeof(FrmInRight).Name) return;

            var bll = new Pol_RightBLL();
            var o = bll.Select(code);

            if (o == null)
            {
                o = new Pol_Right() { Code = code, Name = frm.Text, Descript = "" };
                bll.Insert(o);
            }

            ZAction z = frm.CheckRight();
            if (z == null || z.Access == false) frm.Dispose();
            else frm.Show();
        }

        /// <summary>
        /// Hiện form với quyền của người dùng, tạo form từ class
        /// </summary>
        /// <typeparam name="T">Class của form cần tạo</typeparam>
        /// <param name="parent">Form cha</param>
        public static void ShowRight<T>(Form parent) where T : Form, new()
        {
            var x = typeof(T);
            var frm = (T)GetMdiChilden(parent, x.FullName);

            if (frm == null || frm.IsDisposed)
            {
                frm = new T() { MdiParent = parent };
                if (x.BaseType == typeof(FrmInRight))
                    (frm as FrmInRight).ShowRight();
                else frm.Show();
            }
            else frm.Activate();
        }

        /// <summary>
        /// Show form with user's rights
        /// </summary>
        /// <param name="f">Form childen</param>
        /// <param name="parent">Form parent</param>
        public static void ShowRight(this FrmInRight f, Form parent)
        {
            var a = f.GetType();
            var b = (FrmInRight)GetMdiChilden(parent, a.FullName);

            if (b == null || b.IsDisposed)
            {
                f.MdiParent = parent;
                f.ShowRight();
            }
            else b.Activate();
        }

        /// <summary>
        /// Set false some properties's DockPanel
        /// </summary>
        /// <param name="d">DockPanel</param>
        /// <param name="caption">Caption's DockPanel</param>
        public static void SetDockPanel(this DockPanel d, string caption)
        {
            d.Options.AllowFloating = false;
            d.Options.FloatOnDblClick = false;
            d.Options.ShowAutoHideButton = false;
            d.Options.ShowCloseButton = false;
            d.Options.ShowMaximizeButton = false;
            d.Text = caption;
        }

        /// <summary>
        /// Best fit columns
        /// </summary>
        /// <param name="t">TreeList</param>
        public static void AutoFit(this TreeList t)
        {
            foreach (TreeListColumn x in t.Columns)
            {
                if (x.VisibleIndex != t.Columns.Count - 1)
                    x.BestFit();
            }
        }
    }
}