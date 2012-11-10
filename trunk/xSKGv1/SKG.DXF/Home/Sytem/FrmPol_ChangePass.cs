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
    public partial class FrmPol_ChangePass : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmPol_ChangePass);
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
        #endregion

        #region Implements
        #endregion

        #region Overrides
        #endregion

        #region Methods
        public FrmPol_ChangePass()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == txtConfirm.Text)
            {
                var bll = new Pol_UserBLL();
                if (bll.ChangePass(txtPass.Text))
                {
                    XtraMessageBox.Show(STR_SUCC, STR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Extend.Login();
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

        private void txtConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave_Click(sender, null);
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Đổi mật khẩu";

        private const string STR_ERR = "Không đổi được mật khẩu!";
        private const string STR_CONFIRM = "Mật khẩu không trùng khớp";
        private const string STR_SUCC = "Đổi mật khẩu thành công!";
        #endregion
    }
}