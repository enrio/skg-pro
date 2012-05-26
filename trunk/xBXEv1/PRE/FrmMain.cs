using System;
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

            bsiServer.Caption = String.Format("[SV:{0} | DB:{1}]",
                                  BaseBLL._pol_ActionBLL.Connection().DataSource,
                                  BaseBLL._pol_ActionBLL.Connection().Database);
            bsiUser.Caption = null;
            bsiTimer.Caption = null;

            //BLL.BaseBLL.CreateData(true);

            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true);
        }

        /// <summary>
        /// Hiện menu, thay đổi nút đăng nhập -> đăng xuất
        /// </summary>
        private void ShowMenu()
        {
            BasePRE.VisibleMenuParentForm(this);

            bbiLogin.LargeGlyph = Properties.Resources.logout;
            bbiLogin.Caption = Properties.Settings.Default.Logout;

            bsiUser.Caption = BasePRE._sss.Pol_User.Name;
        }

        /// <summary>
        /// Ẩn menu, thay đổi nút đăng xuất -> đăng nhập
        /// </summary>
        private void HideMenu()
        {
            BasePRE.VisibleMenuParentForm(this, false);

            bbiLogin.LargeGlyph = Properties.Resources.login;
            bbiLogin.Caption = Properties.Settings.Default.Login;

            bsiUser.Caption = null;
        }

        /// <summary>
        /// Thực hiện đăng nhập hệ thống
        /// </summary>
        private void Login()
        {
            const string TITLE = "Đăng nhập";

            try
            {
                var x = typeof(FrmLogin);
                var frm = (FrmLogin)BasePRE.GetMdiChilden(this, x.FullName);
                if (frm == null) frm = new FrmLogin() { MdiParent = this, Text = TITLE };

                frm.BeforeLogon += HideMenu;
                frm.AfterLogon += ShowMenu;

                frm.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, TITLE); }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Login();
        }

        #region Catalog
        private void bbiPol_Right_ItemClick(object sender, ItemClickEventArgs e)
        {
            var x = typeof(FrmPol_Right);
            var frm = (FrmPol_Right)BasePRE.GetMdiChilden(this, x.FullName);

            if (frm == null)
            {
                frm = new FrmPol_Right() { MdiParent = this, Text = "Quyền hạn" };
                frm.Show();
            }
            else frm.Activate();
        }

        private void bbiPol_Role_ItemClick(object sender, ItemClickEventArgs e)
        {
            var x = typeof(FrmPol_Role);
            var frm = (FrmPol_Role)BasePRE.GetMdiChilden(this, x.FullName);

            if (frm == null)
            {
                frm = new FrmPol_Role() { MdiParent = this, Text = "Vai trò" };
                frm.Show();
            }
            else frm.Activate();
        }

        private void bbiPol_User_ItemClick(object sender, ItemClickEventArgs e)
        {
            var x = typeof(FrmPol_User);
            var frm = (FrmPol_User)BasePRE.GetMdiChilden(this, x.FullName);

            if (frm == null)
            {
                frm = new FrmPol_User() { MdiParent = this, Text = "Người dùng" };
                frm.Show();
            }
            else frm.Activate();
        }

        private void bbiTra_Group_ItemClick(object sender, ItemClickEventArgs e)
        {
            var x = typeof(FrmTra_Group);
            var frm = (FrmTra_Group)BasePRE.GetMdiChilden(this, x.FullName);

            if (frm == null)
            {
                frm = new FrmTra_Group() { MdiParent = this, Text = "Nhóm xe" };
                frm.Show();
            }
            else frm.Activate();
        }

        private void bbiTra_Kind_ItemClick(object sender, ItemClickEventArgs e)
        {
            var x = typeof(FrmTra_Kind);
            var frm = (FrmTra_Kind)BasePRE.GetMdiChilden(this, x.FullName);

            if (frm == null)
            {
                frm = new FrmTra_Kind() { MdiParent = this, Text = "Loại xe" };
                frm.Show();
            }
            else frm.Activate();
        }

        private void bbiTra_Vehicle_ItemClick(object sender, ItemClickEventArgs e)
        {
            var x = typeof(FrmTra_Vehicle);
            var frm = (FrmTra_Vehicle)BasePRE.GetMdiChilden(this, x.FullName);

            if (frm == null)
            {
                frm = new FrmTra_Vehicle() { MdiParent = this, Text = "Danh sách xe" };
                frm.Show();
            }
            else frm.Activate();
        }
        #endregion

        #region System
        private void bbiLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            Login();
        }

        private void bbiSetting_ItemClick(object sender, ItemClickEventArgs e)
        {

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
            var x = typeof(FrmPol_UserRole);
            var frm = (FrmPol_UserRole)BasePRE.GetMdiChilden(this, x.FullName);

            if (frm == null)
            {
                frm = new FrmPol_UserRole() { MdiParent = this, Text = "Quyền người dùng" };
                frm.Show();
            }
            else frm.Activate();
        }

        private void bbiPol_RoleRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            var x = typeof(FrmPol_RoleRight);
            var frm = (FrmPol_RoleRight)BasePRE.GetMdiChilden(this, x.FullName);

            if (frm == null)
            {
                frm = new FrmPol_RoleRight() { MdiParent = this, Text = "Nhóm người dùng" };
                frm.Show();
            }
            else frm.Activate();
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            if (BasePRE._sss.Current != null)
            {
                bsiTimer.Caption = BasePRE._sss.Current.Value.ToString("dd/MM/yyyy hh:mm:ss");
                BasePRE._sss.Current = BasePRE._sss.Current.Value.AddSeconds(1);
            }
        }
        #endregion
    }
}