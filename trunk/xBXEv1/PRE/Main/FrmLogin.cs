using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PRE.Main
{
    using BLL;
    using DAL.Entities;

    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        private const string STR_ERR = "Lỗi đăng nhập";
        private const string STR_LOGIN = "Đăng nhập";

        #region Event logon
        public delegate void LogonHandler();

        public event LogonHandler BeforeLogon;
        public event LogonHandler AfterLogon;
        public event LogonHandler AfterLogout;

        void NotifyBeforeLogon() { if (BeforeLogon != null) BeforeLogon(); }
        void NotifyAfterLogon() { if (AfterLogon != null) AfterLogon(); }
        void NotifyAfterLogout() { if (AfterLogout != null) AfterLogout(); }
        #endregion

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //bbiStatusCapsLock.Caption = Console.CapsLock ? "Mở" : "Tắt";
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            var sss = BaseBLL._pol_UserBLL.CheckLogin(txtUser.Text, txtPass.Text);
            if (sss != null)
            {
                BasePRE._sss = sss;
                NotifyAfterLogon();
                Close();
            }
            else MessageBox.Show(STR_ERR, STR_LOGIN);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogon_Click(sender, null);

            //if (e.KeyCode == Keys.CapsLock)
            //    bbiStatusCapsLock.Caption = Console.CapsLock ? "Mở" : "Tắt";
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPass.Text == "")
                txtPass_KeyDown(sender, e);
        }
    }
}