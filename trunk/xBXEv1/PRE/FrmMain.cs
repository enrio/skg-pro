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

    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();

            BaseBLL.CreateData(true);
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
        #endregion

        #region System
        private void bbiLogin_ItemClick(object sender, ItemClickEventArgs e)
        {

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
            foreach (var x in MdiChildren) if (x is Main.FrmPol_UserRight) return;
            var frm = new Main.FrmPol_UserRight() { MdiParent = this, Text = "Người dùng" };
            frm.Show();
        }

        private void bbiPol_RoleRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var x in MdiChildren) if (x is Main.FrmPol_RoleRight) return;
            var frm = new Main.FrmPol_RoleRight() { MdiParent = this, Text = "Nhóm người dùng" };
            frm.Show();
        }
        #endregion
    }
}