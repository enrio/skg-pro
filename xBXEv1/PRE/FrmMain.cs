﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace PRE
{
    using BLL;
    using Catalog;
    using Main;
    using Manage;
    using DevExpress.XtraBars.Helpers;
    using DevExpress.XtraBars.Ribbon;

    /// <summary>
    /// Chương trình chính (xBXE - Quản lí xe ra, vào bến tại bến xe Ngã Tư Ga - TP.HCM)
    /// 
    /// Tác giả:    Nguyễn Văn Toàn - MSSV: LT11780
    /// Điện thoại: 01645 515 010
    /// Hộp thư:    nvt87x@gmail.com
    /// Yahoo:      teqzex18
    /// </summary>
    public partial class FrmMain : RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true);

            // Thông tin server, đồng hồ
            var cnn = (new Pol_ActionBLL()).Connection();
            bsiServer.Caption = String.Format("[SV:{0} | DB:{1}]", cnn.DataSource, cnn.Database);
            bsiUser.Caption = null;
            bsiTimer.Caption = null;
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
            if (BasePRE._sss.Default != null)
            {
                Type type = Type.GetType("PRE.Catalog." + BasePRE._sss.Default.Code);
                if (type == null) type = Type.GetType("PRE.Main." + BasePRE._sss.Default.Code);
                if (type == null) type = Type.GetType("PRE.Manage." + BasePRE._sss.Default.Code);
                if (type == null) type = Type.GetType(BasePRE._sss.Default.Code);
                if (type == null) return;

                var frm = Activator.CreateInstance(type) as FrmBase;
                if (frm != null) frm.ShowRight(this);
            }

            // Tài khoản là admin hoặc thuộc nhóm Quản trị mới có quyền phân quyền
#if DEBUG
            rpgPermission.Visible = true;
            bbiResetDB.Visibility = BarItemVisibility.Always;
#else
            var a = BasePRE._sss.GetUserRole("QT");
            var b = BasePRE._sss.User.Acc.ToUpper();

            if (a != null || b == "ADMIN")
                rpgPermission.Visible = true;
            else rpgPermission.Visible = false;
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
            catch (Exception ex) { BasePRE.ShowMessage(ex.Message, Text); }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
#if !DEBUG
            if (!BaseBLL.CheckDb())
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

        private void bbiTra_Group_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmTra_Group>(this);
        }

        private void bbiTra_Kind_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmTra_Kind>(this);
        }

        private void bbiTra_Vehicle_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmTra_Vehicle>(this);
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
                bsiTimer.Caption = BasePRE._sss.Current.Value.ToString("dd/MM/yyyy hh:mm:ss");
                BasePRE._sss.Current = BasePRE._sss.Current.Value.AddSeconds(1);
            }
        }

        private void bbiResetDB_ItemClick(object sender, ItemClickEventArgs e)
        {
            BLL.BaseBLL.CreateData(true);
        }
        #endregion

        #region Manage
        private void bbiGateIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmGateIn>(this);
        }

        private void bbiGateOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmGateOut>(this);
        }

        private void bbiInDepot_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmInDepot>(this);
        }

        private void bbiSales_ItemClick(object sender, ItemClickEventArgs e)
        {
            BasePRE.ShowRight<FrmSales>(this);
        }
        #endregion

        private void bbiHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            Help.ShowHelp(this, @"Guide.chm");
        }
    }
}