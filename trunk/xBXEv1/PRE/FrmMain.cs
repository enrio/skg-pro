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
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraBars.Docking;

    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static Session _sss = new Session();

        public FrmMain()
        {
            InitializeComponent();
        }

        public static void VisibleParentForm(Form parentForm, bool visible = true)
        {
            if (parentForm != null)
            {
                foreach (Control ctr in parentForm.Controls)
                {
                    if (ctr.GetType() == typeof(RibbonControl)) ctr.Visible = visible;
                    if (ctr.GetType() == typeof(DockPanel)) ctr.Visible = visible;
                    if (ctr.GetType() == typeof(BarManager)) ctr.Visible = visible;
                }
            }
        }

        public static void ClearMenuParentForm(Form parentForm)
        {
            if (parentForm != null)
            {
                while (((RibbonForm)parentForm).Ribbon.Pages.Count > 1)
                    ((RibbonForm)parentForm).Ribbon.Pages[1].Dispose();

                while (((ApplicationMenu)((RibbonForm)parentForm).Ribbon.ApplicationButtonDropDownControl).ItemLinks.Count > 1)
                    ((ApplicationMenu)((RibbonForm)parentForm).Ribbon.ApplicationButtonDropDownControl).ItemLinks[1].Dispose();
            }
        }

        public static void CloseAllChildrenForm(Form parentForm)
        {
            if (parentForm != null)
                foreach (Form childrenForm in parentForm.MdiChildren)
                    childrenForm.Close();
        }

        #region Catalog
        private void bbiPol_Right_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var x in MdiChildren) if (x is Catalog.FrmPol_Right) return;
            var frm = new Catalog.FrmPol_Right() { MdiParent = this, Text = "Quyền hạn" };
            frm.Show();
        }

        private void bbiPol_Role_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var x in MdiChildren) if (x is Catalog.FrmPol_Role) return;
            var frm = new Catalog.FrmPol_Role() { MdiParent = this, Text = "Vai trò" };
            frm.Show();
        }

        private void bbiPol_User_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var x in MdiChildren) if (x is Catalog.FrmPol_User) return;
            var frm = new Catalog.FrmPol_User() { MdiParent = this, Text = "Người dùng" };
            frm.Show();
        }

        private void bbiTra_Group_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var x in MdiChildren) if (x is Catalog.FrmTra_Group) return;
            var frm = new Catalog.FrmTra_Group() { MdiParent = this, Text = "Nhóm xe" };
            frm.Show();
        }

        private void bbiTra_Kind_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var x in MdiChildren) if (x is Catalog.FrmTra_Kind) return;
            var frm = new Catalog.FrmTra_Kind() { MdiParent = this, Text = "Loại xe" };
            frm.Show();
        }

        private void bbiTra_Vehicle_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var x in MdiChildren) if (x is Catalog.FrmTra_Vehicle) return;
            var frm = new Catalog.FrmTra_Vehicle() { MdiParent = this, Text = "Xe cộ" };
            frm.Show();
        }
        #endregion

        #region System
        private void bbiLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            const string STR_LOGIN = "Đăng &nhập";
            const string STR_LOGOUT = "Đăng &xuất";

            if (bbiLogin.Caption == STR_LOGOUT)
            {
                //_sss.Login = false;
                bbiLogin.Caption = STR_LOGIN;
                bbiLogin.LargeGlyph = Properties.Resources.login;

                bbiCloseAll_ItemClick(sender, e);
                //ShowMenu(false); // hide menu
            }

            using (var frm = new Main.FrmLogin())
            {
                frm.ShowDialog();
            }

            //if (_sss.Login)
            //{
            //    bbiLogin.Caption = STR_LOGOUT;
            //    bbiLogin.LargeGlyph = Properties.Resources.logout;

            //    ShowMenu(); // show menu
            //    ShowDefault();
            //}
            //else ShowMenu(false); // hide menu
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
            Application.Exit();
        }

        private void bbiPol_UserRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var x in MdiChildren) if (x is Main.FrmPol_UserRole) return;
            var frm = new Main.FrmPol_UserRole() { MdiParent = this, Text = "Người dùng" };
            frm.Show();
        }

        private void bbiPol_RoleRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var x in MdiChildren) if (x is Main.FrmPol_RoleRight) return;
            var frm = new Main.FrmPol_RoleRight() { MdiParent = this, Text = "Nhóm người dùng" };
            frm.Show();
        }
        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //BaseBLL.CreateData(true);
        }
    }
}