using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace SKG.DXF
{
    using BLL;
    using Main;
    using Sytem;
    using Catalog;
    using SKG.Extend;
    using SKG.Hasher;
    using DevExpress.XtraEditors;
    using DevExpress.XtraBars.Helpers;

    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
            SkinHelper.InitSkinGallery(rgbMain, true);

            Extend.Session = new Session();
            BeforeLogon();

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
            Extend.VisibleMenuParentForm(this);

            bbiLogin.LargeGlyph = Properties.Resources.logout;
            bbiLogin.Caption = Properties.Settings.Default.Logout;
            bsiUser.Caption = Extend.Session.User.Name;

            // Hiện form mặc định
            var d = Extend.Session.Default;
            foreach (var r in d)
            {
                if (r.Code == null) break;

                var t = Type.GetType("SKG.DXF.Catalog." + r.Code);
                if (t == null) t = Type.GetType("SKG.DXF.Main." + r.Code);
                if (t == null) t = Type.GetType(r.Code);

                if (t == null) return;
                var frm = Activator.CreateInstance(t) as FrmInRight;
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
            Extend.VisibleMenuParentForm(this, false);

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
                Extend.CloseAllChildrenForm(this);

                var x = typeof(FrmLogin);
                var frm = (FrmLogin)Extend.GetMdiChilden(this, x.FullName);
                if (frm == null) frm = new FrmLogin() { MdiParent = this };

                frm.BeforeLogon += BeforeLogon;
                frm.AfterLogon += AfterLogon;

                frm.Show();
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, Text); }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var a = Extend.Service.GetPlugins();
            ribbon.Pages.Remove(rbpHelp);
            ribbon.LoadMenu(a, this);
            ribbon.Pages.Add(rbpHelp);
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
            Extend.ShowRight<FrmPol_Right>(this);
        }

        private void bbiPol_Role_ItemClick(object sender, ItemClickEventArgs e)
        {
            Extend.ShowRight<FrmPol_Role>(this);
        }

        private void bbiPol_User_ItemClick(object sender, ItemClickEventArgs e)
        {
            Extend.ShowRight<FrmPol_User>(this);
        }
        #endregion

        #region System
        private void bbiLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            Login();
        }

        private void bbiSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            Extend.ShowRight<FrmSetting>(this);
        }

        private void bbiCloseAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            Extend.CloseAllChildrenForm(this);
        }

        private void bbiExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void bbiPol_UserRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            Extend.ShowRight<FrmPol_UserRight>(this);
        }

        private void bbiPol_RoleRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            Extend.ShowRight<FrmPol_RoleRight>(this);
        }

        private void bbiPol_UserRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            Extend.ShowRight<FrmPol_UserRole>(this);
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            if (Extend.Session.Current != null)
            {
                bsiTimer.Caption = Extend.Session.Current.ToStringVN();
                Extend.Session.Current = Extend.Session.Current.AddSeconds(1);
            }
        }
        #endregion

        private void bbiHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            Help.ShowHelp(this, @"Guide.chm");
        }

        private void bbiRegistry_ItemClick(object sender, ItemClickEventArgs e)
        {
            Extend.ShowRight<FrmLicense>(this);
        }
    }
}