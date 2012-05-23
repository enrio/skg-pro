namespace PRE
{
    partial class FrmMain
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiLogin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSetting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRegistry = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExit = new DevExpress.XtraBars.BarButtonItem();
            this.rbpMain = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgPolicy = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpCatalog = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpManage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonText = null;
            // 
            // 
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiLogin,
            this.bbiSetting,
            this.bbiRegistry,
            this.bbiExit});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpMain,
            this.rbpCatalog,
            this.rbpManage,
            this.rbpHelp});
            this.ribbon.Size = new System.Drawing.Size(1015, 147);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bbiLogin
            // 
            this.bbiLogin.Caption = "Đăng &nhập";
            this.bbiLogin.Id = 1;
            this.bbiLogin.LargeGlyph = global::PRE.Properties.Resources.login;
            this.bbiLogin.Name = "bbiLogin";
            // 
            // bbiSetting
            // 
            this.bbiSetting.Caption = "&Cài đặt";
            this.bbiSetting.Id = 2;
            this.bbiSetting.LargeGlyph = global::PRE.Properties.Resources.setting;
            this.bbiSetting.Name = "bbiSetting";
            // 
            // bbiRegistry
            // 
            this.bbiRegistry.Caption = "Đăng &kí";
            this.bbiRegistry.Id = 3;
            this.bbiRegistry.LargeGlyph = global::PRE.Properties.Resources.registry;
            this.bbiRegistry.Name = "bbiRegistry";
            // 
            // bbiExit
            // 
            this.bbiExit.Caption = "&Thoát";
            this.bbiExit.Id = 4;
            this.bbiExit.LargeGlyph = global::PRE.Properties.Resources.exit;
            this.bbiExit.Name = "bbiExit";
            // 
            // rbpMain
            // 
            this.rbpMain.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSystem,
            this.rpgPolicy});
            this.rbpMain.Name = "rbpMain";
            this.rbpMain.Text = "Trang chính";
            // 
            // rpgSystem
            // 
            this.rpgSystem.ItemLinks.Add(this.bbiLogin);
            this.rpgSystem.ItemLinks.Add(this.bbiSetting);
            this.rpgSystem.ItemLinks.Add(this.bbiRegistry);
            this.rpgSystem.ItemLinks.Add(this.bbiExit);
            this.rpgSystem.Name = "rpgSystem";
            this.rpgSystem.Text = "&Hệ thống";
            // 
            // rpgPolicy
            // 
            this.rpgPolicy.Name = "rpgPolicy";
            this.rpgPolicy.Text = "&Phân quyền";
            // 
            // rbpCatalog
            // 
            this.rbpCatalog.Name = "rbpCatalog";
            this.rbpCatalog.Text = "Danh mục";
            // 
            // rbpManage
            // 
            this.rbpManage.Name = "rbpManage";
            this.rbpManage.Text = "Quản lí";
            // 
            // rbpHelp
            // 
            this.rbpHelp.Name = "rbpHelp";
            this.rbpHelp.Text = "Trợ giúp";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 549);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1015, 31);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 580);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "xBXE - QUẢN LÍ XE RA VÀO BẾN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSystem;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpCatalog;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpManage;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpHelp;
        private DevExpress.XtraBars.BarButtonItem bbiLogin;
        private DevExpress.XtraBars.BarButtonItem bbiSetting;
        private DevExpress.XtraBars.BarButtonItem bbiRegistry;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPolicy;
        private DevExpress.XtraBars.BarButtonItem bbiExit;
    }
}