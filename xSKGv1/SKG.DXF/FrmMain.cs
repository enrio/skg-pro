#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 20/04/2013 09:09
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;

namespace SKG.DXF
{
    using Home.Sytem;
    using SKG.Extend;
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Ribbon;

    /// <summary>
    /// Form main of system
    /// </summary>
    public partial class FrmMain : RibbonForm
    {
        public RibbonGalleryBarItem rgbiSkins;
        public RibbonPageGroup skinsRibbonPageGroup;

        void InitSkinGallery()
        {
            rgbiSkins = new RibbonGalleryBarItem { Caption = "Skins" };
            rgbiSkins.Gallery.AllowHoverImages = true;
            rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseFont = true;
            rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.Options.UseTextOptions = true;
            rgbiSkins.Gallery.Appearance.ItemCaptionAppearance.Normal.TextOptions.HAlignment = HorzAlignment.Center;
            rgbiSkins.Gallery.ColumnCount = 4;
            rgbiSkins.Gallery.FixedHoverImageSize = false;
            rgbiSkins.Gallery.ImageSize = new System.Drawing.Size(32, 17);
            rgbiSkins.Gallery.ItemImageLocation = Locations.Top;
            rgbiSkins.Gallery.RowCount = 4;
            rgbiSkins.Id = 60;
            rgbiSkins.Name = "rgbiSkins";

            skinsRibbonPageGroup = new RibbonPageGroup();
            skinsRibbonPageGroup.ItemLinks.Add(rgbiSkins);
            skinsRibbonPageGroup.Name = "skinsRibbonPageGroup";
            skinsRibbonPageGroup.ShowCaptionButton = false;
            skinsRibbonPageGroup.Text = "Skins";

            ribbon.Items.Add(rgbiSkins);
        }

        public FrmMain()
        {
            InitializeComponent();

            Global.Parent = this;
            InitSkinGallery();

            #region Information of server, timer
            bsiServer.Caption = String.Format("[SV:{0} | DB:{1}]",
                Global.Connection.DataSource, Global.Connection.Database);
            bsiUser.Caption = null;
            #endregion
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
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
            bsiTimer.Caption = Global.Session.Current.ToStringVN();
            Global.Session.Current = Global.Session.Current.AddSeconds(1);
        }
    }
}