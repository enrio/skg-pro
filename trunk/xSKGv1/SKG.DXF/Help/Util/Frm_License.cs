#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 10/11/2012 21:48
 * Update: 10/11/2012 21:48
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Help.Util
{
    using SKG.Hasher;
    using SKG.Plugin;
    using DevExpress.XtraEditors;

    public partial class Frm_License : SKG.DXF.FrmMenuz
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(Frm_License);
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
        public Frm_License()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void cmdOk_Click(object sender, EventArgs e)
        {
            if ((txtRegister.Text + "").Length < 3)
            {
                XtraMessageBox.Show("Tên phải nhập từ 3 kí tự", "Đăng kí");
                return;
            }

            // Check license
            _license = License.IsLincense(txtLicenseKey.Text);

            if (_license == LicState.Unlimited)
            {
                txtExpire.Text = "Không giới hạn!";

                string tmp = String.Format("Mua thành công!{0}Cám ơn bạn đã sử dụng phầm mềm!"
                    + "{0}Xin hãy khởi động lại chương trình!", Environment.NewLine);
                XtraMessageBox.Show(tmp, "Đăng kí");

                Extend.ShowRight<Home.Sytem.FrmPol_Setting>(Global.Parent);
                Close();
            }
            else if (_license == LicState.Trial)
            {
                txtExpire.Text = "Phiên bản thử nghiệm!";

                string tmp = String.Format("Phần mềm dùng thử!{0}Cám ơn bạn đã sử dụng phầm mềm!"
                    + "{0}Xin hãy khởi động lại chương trình!", Environment.NewLine);
                XtraMessageBox.Show(tmp, "Đăng kí");

                Extend.ShowRight<Home.Sytem.FrmPol_Setting>(Global.Parent);
                Close();
            }
            else txtExpire.Text = "Không được sử dụng!";

            // Save to registry
            var key = new Registri();
            key.Write("Register", txtRegister.Text);
            key.Write("License", txtLicenseKey.Text);
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            if (_license == LicState.Unlimited) Close();
            else Close();
        }

        private void FrmLicense_Load(object sender, EventArgs e)
        {
            txtPcName.Text = Environment.MachineName;
            txtProductId.Text = License.GetProuctKey();
        }

        private void cmdTrial_Click(object sender, EventArgs e)
        {
            txtLicenseKey.Text = License.GetTrialKey();
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        LicState _license = LicState.None;
        #endregion

        #region Constants
        private const string STR_TITLE = "Bảng quyền";
        #endregion
    }
}