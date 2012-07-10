﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;


namespace SKG.PRE
{
    using BLL;
    using Main;
    using Catalog;
    using Orther;
    using SKG.Extend;
    using SKG.Hasher;
    using DevExpress.XtraEditors;

    public partial class FrmMain : RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
            InitSkinGallery();
            InitGrid();
            splitContainerControl.Visible = false;

            InitializeComponent2();
            BeforeLogon();

            // Thông tin server, đồng hồ
            var cnn = (new Pol_ActionBLL()).Connection();
            bsiServer.Caption = String.Format("[SV:{0} | DB:{1}]", cnn.DataSource, cnn.Database);
            bsiUser.Caption = null;
            bsiTimer.Caption = null;
        }

        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        readonly BindingList<Person> gridDataList = new BindingList<Person>();

        void InitGrid()
        {
            gridDataList.Add(new Person("John", "Smith"));
            gridDataList.Add(new Person("Gabriel", "Smith"));
            gridDataList.Add(new Person("Ashley", "Smith", "some comment"));
            gridDataList.Add(new Person("Adrian", "Smith", "some comment"));
            gridDataList.Add(new Person("Gabriella", "Smith", "some comment"));
            gridControl.DataSource = gridDataList;
        }

        /// <summary>
        /// Sau khi đăng nhập, hiện menu, thay đổi nút đăng nhập -> đăng xuất
        /// </summary>
        private void AfterLogon()
        {
            BasePRE.VisibleMenuParentForm(this);

            bbiLogin.LargeGlyph = Properties.Resources.logout;
            bbiLogin.Caption = Properties.Settings.Default.Logout;
            bsiUser.Caption = BasePRE._sss.User.Name;

            // Hiện form mặc định
            var d = BasePRE._sss.Default;
            foreach (var r in d)
            {
                if (r.Code == null) break;

                var t = Type.GetType("SKG.PRE.Catalog." + r.Code);
                if (t == null) t = Type.GetType("SKG.PRE.Main." + r.Code);
                if (t == null) t = Type.GetType("SKG.PRE.Manage." + r.Code);
                if (t == null) t = Type.GetType(r.Code);

                if (t == null) return;
                var frm = Activator.CreateInstance(t) as FrmBase;
                if (frm != null) frm.ShowRight(this);
            }

            // Tài khoản là admin hoặc thuộc nhóm Quản trị mới có quyền phân quyền
#if DEBUG
            rpgPermission.Visible = true;
            bbiSetting.Visibility = BarItemVisibility.Always;
#else
            var a = BasePRE._sss.GetUserRole("QT");
            var b = BasePRE._sss.User.Acc.ToUpper();

            if (a != null || b == "ADMIN")
            {
                rpgPermission.Visible = true;
                bbiSetting.Visibility = BarItemVisibility.Always;
            }
            else
            {
                rpgPermission.Visible = false;
                bbiSetting.Visibility = BarItemVisibility.Never;
            }
#endif
        }

        /// <summary>
        /// Trước khi đăng nhập, ẩn menu, thay đổi nút đăng xuất -> đăng nhập
        /// </summary>
        private void BeforeLogon()
        {
            BasePRE.VisibleMenuParentForm(this, false);

            bbiLogin.LargeGlyph = Properties.Resources.login;
            bbiLogin.Caption = Properties.Settings.Default.Login;

            bsiUser.Caption = null;
            rpgPermission.Visible = false;
        }

        /// <summary>
        /// Thực hiện đăng nhập hệ thống
        /// </summary>
        private void Login()
        {
            try
            {
                BasePRE.CloseAllChildrenForm(this);

                var x = typeof(FrmLogin);
                var frm = (FrmLogin)BasePRE.GetMdiChilden(this, x.FullName);
                if (frm == null) frm = new FrmLogin() { MdiParent = this };

                frm.BeforeLogon += BeforeLogon;
                frm.AfterLogon += AfterLogon;

                frm.Show();
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, Text); }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var a = Global.Service.GetPlugins();

            ribbon.Pages.Remove(rbpHelp);
            ribbon.LoadMenu(a, this);
            ribbon.Pages.Add(rbpHelp);

            ribbonControl.Pages.Remove(helpRibbonPage);
            ribbonControl.LoadMenu(a, this);
            ribbonControl.Pages.Add(helpRibbonPage);
#if !DEBUG
            // Check license
            var key = (new Registri()).Read("License");
            var ok = License.IsLincense(key);
            if (ok == LicState.None)
            {
                BasePRE.ShowRight<FrmLicense>(this);
                return;
            }
            else bbiRegistry.Enabled = false;

            if (!Sample.CheckDb())
            {
                BasePRE.ShowRight<FrmSetting>(this);
                return;
            }
            else bbiSetting.Visibility = BarItemVisibility.Never;
#endif
            Login();
        }

        #region Catalog
        private void bbiPol_Right_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmPol_Right>(this);
        }

        private void bbiPol_Role_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmPol_Role>(this);
        }

        private void bbiPol_User_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmPol_User>(this);
        }
        #endregion

        #region System
        private void bbiLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            Login();
        }

        private void bbiSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmSetting>(this);
        }

        private void bbiCloseAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.CloseAllChildrenForm(this);
        }

        private void bbiExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void bbiPol_UserRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmPol_UserRight>(this);
        }

        private void bbiPol_RoleRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmPol_RoleRight>(this);
        }

        private void bbiPol_UserRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmPol_UserRole>(this);
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            if (BasePRE._sss.Current != null)
            {
                bsiTimer.Caption = BasePRE._sss.Current.ToStringVN();
                BasePRE._sss.Current = BasePRE._sss.Current.AddSeconds(1);
            }
        }
        #endregion

        private void bbiHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            Help.ShowHelp(this, @"Guide.chm");
        }

        private void bbiRegistry_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmLicense>(this);
        }
    }
}