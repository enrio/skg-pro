using System;
using System.Collections.Generic;
using System.Linq;

namespace PRE
{
    using BLL;
    using Main;
    using System.Windows.Forms;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraBars.Docking;

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
                foreach (Control ctr in parent.Controls)
                {
                    if (ctr.GetType() == typeof(RibbonControl)) ctr.Visible = visible;
                    if (ctr.GetType() == typeof(DockPanel)) ctr.Visible = visible;
                    if (ctr.GetType() == typeof(BarManager)) ctr.Visible = visible;
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

                    while (((ApplicationMenu)((RibbonForm)parent).Ribbon.ApplicationButtonDropDownControl).ItemLinks.Count > 1)
                        ((ApplicationMenu)((RibbonForm)parent).Ribbon.ApplicationButtonDropDownControl).ItemLinks[1].Dispose();
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
    }
}