using System;
using System.Collections.Generic;
using System.Linq;

namespace PRE
{
    using BLL;
    using System.Windows.Forms;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraBars.Docking;

    public static class BasePRE
    {
        public static Session _sss = new Session();

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

        public static void VisibleMenuParentForm(Form parent, bool visible = true)
        {
            if (parent != null)
            {
                var i = ((RibbonForm)parent).Ribbon.Pages.Count;
                while (i-- > 1)
                    ((RibbonForm)parent).Ribbon.Pages[i].Visible = visible;
            }
        }

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

        public static void CloseAllChildrenForm(Form parent)
        {
            if (parent != null)
                foreach (Form childrenForm in parent.MdiChildren)
                    childrenForm.Close();
        }

        public static void CloseAllChildrenForm(Form parent, Form active)
        {
            if (parent != null)
            {
                foreach (Form child in parent.MdiChildren)
                    if (child != active && child.GetType().FullName != "PRE.Main.FrmLogin")
                        child.Close();
            }
        }

        public static Form GetMdiChilden(Form parent, string childrenName, bool isFullName = false)
        {
            Form frmreturn = null;

            if (parent.MdiChildren != null)
                foreach (Form frm in parent.MdiChildren)
                {
                    var name = "";
                    if (isFullName) name = frm.GetType().FullName;
                    else name = frm.GetType().Name;

                    if (name == childrenName)
                    {
                        frmreturn = frm;
                        break;
                    }
                }

            return frmreturn;
        }
    }
}