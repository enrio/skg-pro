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

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //bbiStatusCapsLock.Caption = Console.CapsLock ? "Mở" : "Tắt";
        }

        private void FrmLogin_SizeChanged(object sender, EventArgs e)
        {
            gctMain.Left = (ClientSize.Width - gctMain.Width) / 2;
            gctMain.Top = (ClientSize.Height - gctMain.Height) / 2;
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.CapsLock)
            //    bbiStatusCapsLock.Caption = Console.CapsLock ? "Mở" : "Tắt";
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdYes_Click(sender, null);

            //if (e.KeyCode == Keys.CapsLock)
            //    bbiStatusCapsLock.Caption = Console.CapsLock ? "Mở" : "Tắt";
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            var sss = BaseBLL._pol_UserBLL.CheckLogin(txtUser.Text, txtPass.Text);
            if (sss != null)
            {
                FrmMain._sss = sss;
                Close();
            }
            else MessageBox.Show(STR_ERR, STR_LOGIN);
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            //FrmMain._sss.Name = "Đăng nhập để làm việc";
            Close();
        }
    }
}