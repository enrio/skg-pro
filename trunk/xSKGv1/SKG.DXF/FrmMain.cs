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
            bsiTimer.Caption = null;
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

            if (!Sample.CheckDb())
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
            if (Global.Session.Current == null) return;
            bsiTimer.Caption = Global.Session.Current.ToStringVN();
            Global.Session.Current = Global.Session.Current.AddSeconds(1);
        }
    }
}