#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 29/07/2012 10:27
 * Update: 29/07/2012 10:27
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Help.Infor
{
    using SKG.Hasher;
    using SKG.Plugin;
    using DevExpress.XtraEditors;

    public partial class FrmPol_License : SKG.DXF.FrmMenuz
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Đăng kí", Level = 3, Order = 996, Picture = @"Icons\Registry.png" };
                return menu;
            }
        }
        #endregion

        public FrmPol_License()
        {
            InitializeComponent();
        }

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

        LicState _license = LicState.None;
    }
}