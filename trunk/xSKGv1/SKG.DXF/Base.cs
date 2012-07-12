﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF
{
    using BLL;
    using Sytem;
    using DAL.Entities;
    using DevExpress.XtraBars;
    using System.Windows.Forms;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraTreeList.Columns;

    /// <summary>
    /// Some methods for presentation layer
    /// </summary>
    public static class Base
    {
        /// <summary>
        /// Session of current an user logon
        /// </summary>
        public static Session _sss = new Session();

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
            catch { throw new Exception(); }
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
            catch { throw new Exception(); }
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
                while (((RibbonForm)parent).Ribbon.Pages.Count > 1)
                    ((RibbonForm)parent).Ribbon.Pages[1].Dispose();
                while (((ApplicationMenu)((RibbonForm)parent).Ribbon.ApplicationButtonDropDownControl).ItemLinks.Count > 1)
                    ((ApplicationMenu)((RibbonForm)parent).Ribbon.ApplicationButtonDropDownControl).ItemLinks[1].Dispose();
            }
            catch { throw new Exception(); }
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
            catch { throw new Exception(); }
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
                var name = typeof(FrmLogin).FullName;
                foreach (Form child in parent.MdiChildren)
                    if (child != active && child.GetType().FullName != name)
                        child.Close();
            }
            catch { throw new Exception(); }
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
            catch { throw new Exception(); }
        }

        /// <summary>
        /// Show form with user's right
        /// </summary>
        /// <param name="form">Form right</param>
        static void ShowRight(this FrmInRight form)
        {
            try
            {
                var code = form.GetType().Name;
                if (code == typeof(FrmNoRight).Name) return;

                var bll = new Pol_RightBLL();
                var o = bll.Select(code);

                if (o == null)
                {
                    o = new Pol_Right() { Code = code, Name = form.Text, Descript = "" };
                    bll.Insert(o);
                }

                ZAction z = form.CheckRight();
                if (z == null || z.Access == false) form.Dispose();
                else form.Show();
            }
            catch { throw new Exception(); }
        }

        /// <summary>
        /// Show form with user's right, create by its class
        /// </summary>
        /// <typeparam name="T">Class of form need to create</typeparam>
        /// <param name="parent">Parent</param>
        public static void ShowRight<T>(Form parent) where T : Form, new()
        {
            try
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
            catch { throw new Exception(); }
        }

        /// <summary>
        /// Show form with user's rights
        /// </summary>
        /// <param name="form">Form childen</param>
        /// <param name="parent">Form parent</param>
        public static void ShowRight(this FrmInRight form, Form parent)
        {
            try
            {
                var a = form.GetType();
                var b = (FrmInRight)GetMdiChilden(parent, a.FullName);
                if (b == null || b.IsDisposed)
                {
                    form.MdiParent = parent;
                    form.ShowRight();
                }
                else b.Activate();
            }
            catch { throw new Exception(); }
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
            catch { throw new Exception(); }
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
            catch { throw new Exception(); }
        }
    }
}