#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 29/07/2012 10:27
 * Update: 30/07/2012 20:27
 * Status: None
 */
#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Home.Sytem
{
    using BLL;
    using SKG.Plugin;
    using DevExpress.XtraEditors;

    /// <summary>
    /// Menuz - Login
    /// </summary>
    public partial class FrmPol_Login : SKG.DXF.FrmMenuz
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(FrmPol_Login).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "Đăng nhập",
                    Level = 3,
                    Order = 3,
                    Picture = @"Icons\Login.png"
                };
                return menu;
            }
        }
        #endregion

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

        public FrmPol_Login()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
#if DEBUG
            txtUser.Text = "admin";
#endif
            NotifyBeforeLogon();

            //bbiStatusCapsLock.Caption = Console.CapsLock ? "Mở" : "Tắt";
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            try
            {
                var bll = new Pol_UserBLL();
                var sss = bll.CheckLogin(txtUser.Text, txtPass.Text);
                if (sss != null)
                {
                    Global.Session = sss;
                    NotifyAfterLogon();
                    Close();
                }
                else XtraMessageBox.Show(STR_ERR, STR_LOGIN);
            }
            catch { throw new Exception(); }
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

        private const string STR_ERR = "Lỗi đăng nhập";
        private const string STR_LOGIN = "Đăng nhập";
    }
}