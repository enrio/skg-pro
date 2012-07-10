using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SKG.PRE.Main
{
    using BLL;

    /// <summary>
    /// Form đăng nhập hệ thống
    /// </summary>
    public partial class FrmLogin : XtraForm
    {
        private const string STR_ERR = "Lỗi đăng nhập";
        private const string STR_LOGIN = "Đăng nhập";

        #region Sự kiện đăng nhập
        /// <summary>
        /// Uỷ nhiệm xử lí đăng nhập
        /// </summary>
        public delegate void LogonHandler();

        /// <summary>
        /// Trước khi đăng nhập
        /// </summary>
        public event LogonHandler BeforeLogon;

        /// <summary>
        /// Sau khi đăng nhập
        /// </summary>
        public event LogonHandler AfterLogon;

        /// <summary>
        /// Báo cho biết trước khi đăng nhập
        /// </summary>
        void NotifyBeforeLogon() { if (BeforeLogon != null) BeforeLogon(); }

        /// <summary>
        /// Báo cho biết sau khi đăng nhập
        /// </summary>
        void NotifyAfterLogon() { if (AfterLogon != null) AfterLogon(); }
        #endregion

        public FrmLogin()
        {
            InitializeComponent();

#if DEBUG
            txtUser.Text = "admin";
#endif
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            NotifyBeforeLogon();

            //bbiStatusCapsLock.Caption = Console.CapsLock ? "Mở" : "Tắt";
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            var bll = new Pol_UserBLL();
            var sss = bll.CheckLogin(txtUser.Text, txtPass.Text);

            if (sss != null)
            {
                BasePRE._sss = sss;

                //var x = BaseBLL._pol_UserBLL.GetRights(sss.User.Id);
                //var y = BaseBLL._pol_UserBLL.GetRights(sss.User.Id, this.GetType().Name);

                NotifyAfterLogon();
                Close();
            }
            else XtraMessageBox.Show(STR_ERR, STR_LOGIN);
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