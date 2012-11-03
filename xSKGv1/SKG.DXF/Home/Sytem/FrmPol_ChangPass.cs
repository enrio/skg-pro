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
    public partial class FrmPol_ChangPass : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(FrmPol_ChangPass).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "Đổi mật khẩu",
                    Level = 3,
                    Order = 3,
                    Picture = @"Icons\Login.png"
                };
                return menu;
            }
        }
        #endregion


        public FrmPol_ChangPass()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private const string STR_ERR = "Không đổi được mật khẩu!";
        private const string STR_CONFIRM = "Mật khẩu không trùng khớp";
        private const string STR_SUCC = "Đổi mật khẩu thành công!";
        private const string STR_TITLE = "Change password";

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == txtConfirm.Text)
            {
                var bll = new Pol_UserBLL();
                if (bll.ChangePass(txtPass.Text))
                {
                    XtraMessageBox.Show(STR_SUCC, STR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    XtraMessageBox.Show(STR_ERR, STR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show(STR_CONFIRM, STR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirm.Focus();
            }
        }

        private void FrmPol_ChangePass_Load(object sender, EventArgs e)
        {
            AllowBar = false;
        }
    }
}