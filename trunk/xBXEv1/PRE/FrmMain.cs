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

    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private const string STR_LOGIN = "Đăng &nhập";
        private const string STR_LOGOUT = "Đăng &xuất";

        public FrmMain()
        {
            InitializeComponent();

            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true);
        }

        public void ShowLogin()
        {
            try
            {
                bbiLogin.LargeGlyph = Properties.Resources.login;
                bbiLogin.Caption = STR_LOGIN;

                BasePRE.VisibleMenuParentForm(this, false);

                var x = typeof(FrmLogin);
                var frm = (FrmLogin)BasePRE.GetMdiChilden(this, x.FullName, true);
                if (frm == null) frm = new FrmLogin() { MdiParent = this, Text = "Đăng nhập" };
                frm.AfterLogon += Logon;
                frm.Show();

                BasePRE.CloseAllChildrenForm(this, frm);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "FrmLogin"); }
        }

        void Logon()
        {
            BasePRE.VisibleMenuParentForm(this);

            bbiLogin.LargeGlyph = Properties.Resources.logout;
            bbiLogin.Caption = STR_LOGOUT;
        }

        #region Catalog
        private void bbiPol_Right_ItemClick(object sender, ItemClickEventArgs e)
        {
            var x = typeof(FrmPol_Right);
            var frm = (FrmPol_Right)BasePRE.GetMdiChilden(this, x.FullName, true);

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
            var frm = (FrmPol_Role)BasePRE.GetMdiChilden(this, x.FullName, true);

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
            var frm = (FrmPol_User)BasePRE.GetMdiChilden(this, x.FullName, true);

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
            var frm = (FrmTra_Group)BasePRE.GetMdiChilden(this, x.FullName, true);

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
            var frm = (FrmTra_Kind)BasePRE.GetMdiChilden(this, x.FullName, true);

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
            var frm = (FrmTra_Vehicle)BasePRE.GetMdiChilden(this, x.FullName, true);

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
            ShowLogin();
        }

        private void bbiSetting_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiCloseAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var frm in MdiChildren) frm.Close();
        }

        private void bbiExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void bbiPol_UserRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            var x = typeof(FrmPol_UserRole);
            var frm = (FrmPol_UserRole)BasePRE.GetMdiChilden(this, x.FullName, true);

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
            var frm = (FrmPol_RoleRight)BasePRE.GetMdiChilden(this, x.FullName, true);

            if (frm == null)
            {
                frm = new FrmPol_RoleRight() { MdiParent = this, Text = "Nhóm người dùng" };
                frm.Show();
            }
            else frm.Activate();
        }
        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //BLL.BaseBLL.CreateData();
            //BLL.BaseBLL.CreateData(true);
            ShowLogin();
        }
    }
}