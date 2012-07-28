using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.MSF.Home.Sytem
{
    using BLL;
    using SKG.Plugin;

    public partial class FrmLogin : SKG.MSF.FrmMenuz
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Đăng nhập", Level = 3, Order = 3, Picture = @"Icons\Login.png" };
                return menu;
            }
        }
        #endregion

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
        }
    }
}