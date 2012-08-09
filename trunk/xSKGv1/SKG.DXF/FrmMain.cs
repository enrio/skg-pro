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
    using BLL;
    using Home.Sytem;
    using Help.Infor;
    using SKG.Extend;
    using SKG.Hasher;

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

            // Information of server, timer
            var cnn = (new Pol_LangBLL()).Connection();
            bsiServer.Caption = String.Format("[SV:{0} | DB:{1}]", cnn.DataSource, cnn.Database);
            bsiUser.Caption = null;
            bsiTimer.Caption = null;
        }

        /// <summary>
        /// Default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            Global.Parent = this;

            // Check license
            //var key = (new Registri()).Read("License");
            //var ok = License.IsLincense(key);
            //if (ok == LicState.None)
            //{
            //    Extend.ShowRight<FrmPol_License>(this);
            //    return;
            //}
            //else bbiRegistry.Enabled = false;

            if (!Sample.CheckDb())
            {
                Extend.ShowRight<FrmPol_Setting>(this);
                return;
            }
            //else bbiSetting.Visibility = BarItemVisibility.Never;

            Extend.Login();
        }

        /// <summary>
        /// System timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrMain_Tick(object sender, EventArgs e)
        {
            if (Global.Session.Current != null)
            {
                bsiTimer.Caption = Global.Session.Current.ToStringVN();
                Global.Session.Current = Global.Session.Current.AddSeconds(1);
            }
        }
    }
}