#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 17/06/2013 07:49
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
    using DevExpress.LookAndFeel;
    using DevExpress.XtraEditors;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraBars.Helpers;

    /// <summary>
    /// Form main of system
    /// </summary>
    public partial class FrmMain : RibbonForm
    {
        /// <summary>
        /// Init skin gallery
        /// </summary>
        /// <param name="rp">RibbonPage</param>
        public void InitSkinGallery(RibbonPage rp, string skin = "DevExpress Style")
        {
            var rgbiSkins = new RibbonGalleryBarItem { Caption = "Skins" };
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

            var skinsRibbonPageGroup = new RibbonPageGroup();
            skinsRibbonPageGroup.ItemLinks.Add(rgbiSkins);
            skinsRibbonPageGroup.Name = "skinsRibbonPageGroup";
            skinsRibbonPageGroup.ShowCaptionButton = false;
            skinsRibbonPageGroup.Text = "GIAO DIỆN";

            ribbon.Items.Add(rgbiSkins);
            rp.Groups.Add(skinsRibbonPageGroup);

            SkinHelper.InitSkinGallery(rgbiSkins, true);
            UserLookAndFeel.Default.SetSkinStyle(skin);
        }

        public FrmMain()
        {
            InitializeComponent();

            Global.Parent = this;

            #region Information of server, timer
            bsiServer.Caption = String.Format("[SV:{0} | DB:{1}]",
                Global.Connection.DataSource, Global.Connection.Database);
            bsiUser.Caption = null;
            #endregion
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var cfg = Global.Connection.ConnectionString.GetConfig();
            if (!cfg[0].Ping())
            {
                var str = "Lỗi kết nối mạng nội bộ, hãy xem lại kết nối mạng{0}Hoặc liên hệ:"
                    + "{0}Triết - 0982 878 707{0}Toàn - 01645 515 010{0}" + "Để khắc phục sự cố!";

                str = String.Format(str, Environment.NewLine);
                XtraMessageBox.Show(str, "Lỗi kết nối");

                return;
            }

            if (!Sample.CheckDb())
                Extend.ShowRight<FrmPol_Setting>(this);
            else Extend.Login();
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