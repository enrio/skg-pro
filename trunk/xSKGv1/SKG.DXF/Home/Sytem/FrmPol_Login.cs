﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 29/07/2012 10:27
 * Update: 02/06/2013 08:10
 * Status: OK
 */
#endregion

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Home.Sytem
{
    using BLL;
    using SKG.Plugin;

    using DevExpress.XtraEditors;

    /// <summary>
    /// Menuz - Login
    /// </summary>
    public partial class FrmPol_Login : FrmMenuz
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmPol_Login);
                var name = Global.GetIconName(type);

                var menu = new Menuz
                {
                    Code = type.FullName,
                    Parent = typeof(Level2).FullName,
                    Text = STR_TITLE,
                    Level = 1,
                    Order = 0,
                    Picture = String.Format(Global.STR_ICON, name)
                };
                return menu;
            }
        }

        public override Form Form { get { return this; } }
        #endregion

        #region Delegate and event when logon
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

        #region Implements
        #endregion

        #region Overrides
        #endregion

        #region Methods
        public FrmPol_Login()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void FrmLogin_Load(object sender, EventArgs e)
        {
#if DEBUG
            txtUser.Text = "admin";
            txtPass.Text = "@13579208";
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
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Đăng nhập";

        private const string STR_ERR = "Lỗi đăng nhập";
        private const string STR_LOGIN = "Đăng nhập";
        #endregion
    }
}