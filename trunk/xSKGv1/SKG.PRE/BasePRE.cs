using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.PRE
{
    using BLL;
    using DAL.Entities;
    using Catalog;
    using Main;
    using System.Windows.Forms;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;

    /// <summary>
    /// Xử lí các chức năng trên form
    /// </summary>
    public static class BasePRE
    {
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
                var tmp = typeof(FrmLogin).FullName;

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
        static void ShowRight(this FrmBase frm)
        {
            var code = frm.GetType().Name;
            if (code == typeof(FrmLogin).Name) return;

            var bll = new Pol_RightBLL();
            var o = bll.Select(code);

            if (o == null)
            {
                o = new Pol_Right() { Code = code, Name = frm.Text, Descript = "" };
                bll.Insert(o);
            }

            Action z = frm.CheckRight();
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
                if (x.BaseType == typeof(FrmBase))
                    (frm as FrmBase).ShowRight();
                else frm.Show();
            }
            else frm.Activate();
        }

        /// <summary>
        /// Show form with user's rights
        /// </summary>
        /// <param name="f">Form childen</param>
        /// <param name="parent">Form parent</param>
        public static void ShowRight(this FrmBase f, Form parent)
        {
            var a = f.GetType();
            var b = (FrmBase)GetMdiChilden(parent, a.FullName);

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