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
using System.Windows.Forms;
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
            var str = "";
            var cfg = Global.Connection.ConnectionString.GetConfig();

        Redo1:
            if (!cfg[0].Ping())
            {
                str = "LỖI KẾT NỐI MẠNG NỘI BỘ, HÃY XEM LẠI KẾT NỐI MẠNG{0}HOẶC LIÊN HỆ:";
                str += "{0}TRIẾT: 0982 878 707 - TOÀN: 01645 515 010{0}" + "ĐỂ KHẮC PHỤC SỰ CỐ!";
                str = String.Format(str, Environment.NewLine);

                var ok = XtraMessageBox.Show(str, "Lỗi kết nối",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (ok == DialogResult.Retry) goto Redo1;
                else ShowFrmPol_Setting();

                return;
            }

        Redo2:
            if (!Sample.CheckDb())
            {
                str = "LỖI MÁY CHỦ DỮ LIỆU, HÃY XEM LẠI SQL SERVER{0}HOẶC LIÊN HỆ:";
                str += "{0}TRIẾT: 0982 878 707 - TOÀN: 01645 515 010{0}" + "ĐỂ KHẮC PHỤC SỰ CỐ!";
                str = String.Format(str, Environment.NewLine);

                var ok = XtraMessageBox.Show(str, "Lỗi kết nối",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (ok == DialogResult.Retry) goto Redo2;
                else ShowFrmPol_Setting();

                return;
            }

            Extend.Login();
        }

        void ShowFrmPol_Setting()
        {
            var frm = new FrmPol_Login()
            {
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.None,
            };

            Global.Setting = true;
            if (frm.ShowDialog() == DialogResult.OK)
                Extend.ShowRight<FrmPol_Setting>(this);
            Global.Setting = false;
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