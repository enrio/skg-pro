namespace SKG.DXF
{
    partial class _FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiLogin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSetting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCloseAll = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAuthor = new DevExpress.XtraBars.BarButtonItem();
            this.bbiProduct = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRegistry = new DevExpress.XtraBars.BarButtonItem();
            this.rgbMain = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.bsiServer = new DevExpress.XtraBars.BarStaticItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.bsiTimer = new DevExpress.XtraBars.BarStaticItem();
            this.bbiHelp = new DevExpress.XtraBars.BarButtonItem();
            this.rbpMain = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgSkin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgInformation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgUse = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tmmMain = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmmMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiLogin,
            this.bbiSetting,
            this.bbiCloseAll,
            this.bbiExit,
            this.bbiAuthor,
            this.bbiProduct,
            this.bbiRegistry,
            this.rgbMain,
            this.bsiServer,
            this.bsiUser,
            this.bsiTimer,
            this.bbiHelp});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 27;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpMain,
            this.rbpHelp});
            this.ribbon.Size = new System.Drawing.Size(1015, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bbiLogin
            // 
            this.bbiLogin.Caption = "Đăng nhập";
            this.bbiLogin.Id = 1;
            this.bbiLogin.LargeGlyph = global::SKG.DXF.Properties.Resources.login;
            this.bbiLogin.Name = "bbiLogin";
            this.bbiLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLogin_ItemClick);
            // 
            // bbiSetting
            // 
            this.bbiSetting.Caption = "Cài đặt";
            this.bbiSetting.Id = 2;
            this.bbiSetting.LargeGlyph = global::SKG.DXF.Properties.Resources.setting;
            this.bbiSetting.Name = "bbiSetting";
            this.bbiSetting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSetting_ItemClick);
            // 
            // bbiCloseAll
            // 
            this.bbiCloseAll.Caption = "Đóng hết";
            this.bbiCloseAll.Id = 3;
            this.bbiCloseAll.LargeGlyph = global::SKG.DXF.Properties.Resources.close;
            this.bbiCloseAll.Name = "bbiCloseAll";
            this.bbiCloseAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCloseAll_ItemClick);
            // 
            // bbiExit
            // 
            this.bbiExit.Caption = "Thoát";
            this.bbiExit.Id = 4;
            this.bbiExit.LargeGlyph = global::SKG.DXF.Properties.Resources.exit;
            this.bbiExit.Name = "bbiExit";
            this.bbiExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExit_ItemClick);
            // 
            // bbiAuthor
            // 
            this.bbiAuthor.Caption = "&Tác giả";
            this.bbiAuthor.Id = 8;
            this.bbiAuthor.Name = "bbiAuthor";
            // 
            // bbiProduct
            // 
            this.bbiProduct.Caption = "&Sản phẩm";
            this.bbiProduct.Id = 9;
            this.bbiProduct.Name = "bbiProduct";
            // 
            // bbiRegistry
            // 
            this.bbiRegistry.Caption = "Đăng &kí";
            this.bbiRegistry.Id = 10;
            this.bbiRegistry.LargeGlyph = global::SKG.DXF.Properties.Resources.registry;
            this.bbiRegistry.Name = "bbiRegistry";
            this.bbiRegistry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRegistry_ItemClick);
            // 
            // rgbMain
            // 
            this.rgbMain.Caption = "ribbonGalleryBarItem1";
            this.rgbMain.Id = 16;
            this.rgbMain.Name = "rgbMain";
            // 
            // bsiServer
            // 
            this.bsiServer.Caption = "Server";
            this.bsiServer.Glyph = global::SKG.DXF.Properties.Resources.db;
            this.bsiServer.Id = 17;
            this.bsiServer.Name = "bsiServer";
            this.bsiServer.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiUser
            // 
            this.bsiUser.Caption = "User";
            this.bsiUser.Glyph = global::SKG.DXF.Properties.Resources.user;
            this.bsiUser.Id = 18;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiTimer
            // 
            this.bsiTimer.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiTimer.Caption = "Timer";
            this.bsiTimer.Id = 19;
            this.bsiTimer.Name = "bsiTimer";
            this.bsiTimer.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbiHelp
            // 
            this.bbiHelp.Caption = "Hướng dẫn";
            this.bbiHelp.Id = 26;
            this.bbiHelp.LargeGlyph = global::SKG.DXF.Properties.Resources.infor;
            this.bbiHelp.Name = "bbiHelp";
            this.bbiHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHelp_ItemClick);
            // 
            // rbpMain
            // 
            this.rbpMain.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSystem,
            this.rpgSkin});
            this.rbpMain.Name = "rbpMain";
            this.rbpMain.Text = "Trang chính";
            // 
            // rpgSystem
            // 
            this.rpgSystem.ItemLinks.Add(this.bbiLogin);
            this.rpgSystem.ItemLinks.Add(this.bbiSetting);
            this.rpgSystem.ItemLinks.Add(this.bbiCloseAll);
            this.rpgSystem.ItemLinks.Add(this.bbiExit);
            this.rpgSystem.Name = "rpgSystem";
            this.rpgSystem.Text = "&Hệ thống";
            // 
            // rpgSkin
            // 
            this.rpgSkin.ItemLinks.Add(this.rgbMain);
            this.rpgSkin.Name = "rpgSkin";
            this.rpgSkin.Text = "&Giao diện";
            // 
            // rbpHelp
            // 
            this.rbpHelp.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgInformation,
            this.rpgUse});
            this.rbpHelp.Name = "rbpHelp";
            this.rbpHelp.Text = "Trợ giúp";
            // 
            // rpgInformation
            // 
            this.rpgInformation.ItemLinks.Add(this.bbiAuthor);
            this.rpgInformation.ItemLinks.Add(this.bbiProduct);
            this.rpgInformation.ItemLinks.Add(this.bbiRegistry);
            this.rpgInformation.Name = "rpgInformation";
            this.rpgInformation.Text = "&Thông tin";
            // 
            // rpgUse
            // 
            this.rpgUse.ItemLinks.Add(this.bbiHelp);
            this.rpgUse.Name = "rpgUse";
            this.rpgUse.Text = "&Sử dụng";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiServer);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiTimer);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 549);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1015, 31);
            // 
            // tmmMain
            // 
            this.tmmMain.MdiParent = this;
            // 
            // tmrMain
            // 
            this.tmrMain.Enabled = true;
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 580);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "...:: SKG ::...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmmMain)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSystem;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpHelp;
        private DevExpress.XtraBars.BarButtonItem bbiLogin;
        private DevExpress.XtraBars.BarButtonItem bbiSetting;
        private DevExpress.XtraBars.BarButtonItem bbiCloseAll;
        private DevExpress.XtraBars.BarButtonItem bbiExit;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tmmMain;
        private System.Windows.Forms.Timer tmrMain;
        private DevExpress.XtraBars.BarButtonItem bbiAuthor;
        private DevExpress.XtraBars.BarButtonItem bbiProduct;
        private DevExpress.XtraBars.BarButtonItem bbiRegistry;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgInformation;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgUse;
        private DevExpress.XtraBars.RibbonGalleryBarItem rgbMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSkin;
        private DevExpress.XtraBars.BarStaticItem bsiServer;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarStaticItem bsiTimer;
        private DevExpress.XtraBars.BarButtonItem bbiHelp;
    }
}