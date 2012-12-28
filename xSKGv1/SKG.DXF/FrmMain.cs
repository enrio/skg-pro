#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 23/07/2012 22:07
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;

namespace SKG.DXF
{
    using Home.Sytem;
    using SKG.Extend;
    using System.Windows.Forms;
    using DevExpress.XtraEditors;

    /// <summary>
    /// Form main of system
    /// </summary>
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        /// <summary>
        /// Create
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();

            //SkinHelper.InitSkinGallery(rgbMain, true);

            #region Information of server, timer
            bsiServer.Caption = String.Format("[SV:{0} | DB:{1}]",
                Global.Connection.DataSource, Global.Connection.Database);
            bsiUser.Caption = null;
            #endregion
        }

        /// <summary>
        /// Default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Global.Parent = this;

            var ok = Datax.Base.PingToHost(Global.Connection.DataSource);
            if (!ok)
            {
                XtraMessageBox.Show("Lỗi kết nối máy chủ cơ sở dữ liệu, vui lòng thử lại sau!\n\rHoặc liên hệ Võ Minh Triết\n\rSdt: 0982 878 707 để khắc phục sự cố.",
                     "Lỗi kết nối...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Sample.IsNotConnect)
            {
                XtraMessageBox.Show("Máy chủ cơ sở dữ liệu lỗi kết nối, vui lòng thử lại sau!\n\rHoặc liên hệ Võ Minh Triết\n\rSdt: 0982 878 707 để khắc phục sự cố.",
                     "Lỗi kết nối...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Sample.IsDbNotExists)
            {
                Extend.ShowRight<FrmPol_Setting>(this);
                return;
            }

            Extend.Login();
        }

        /// <summary>
        /// System timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrMain_Tick(object sender, EventArgs e)
        {
            bsiTimer.Caption = Global.Session.Current.ToStringVN();
            Global.Session.Current = Global.Session.Current.AddSeconds(1);
        }
    }
}