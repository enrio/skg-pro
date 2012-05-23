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
            this.components = new System.ComponentModel.Container();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiLogin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSetting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRegistry = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPol_Right = new DevExpress.XtraBars.BarButtonItem();
            this.rbpMain = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgPermission = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpCatalog = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgTransport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgPolicy = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpManage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbpHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
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
            this.bbiExit,
            this.bbiPol_Right});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
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
            // bbiPol_Right
            // 
            this.bbiPol_Right.Caption = "&Quyền hạn";
            this.bbiPol_Right.Id = 5;
            this.bbiPol_Right.Name = "bbiPol_Right";
            this.bbiPol_Right.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPol_Right_ItemClick);
            // 
            // rbpMain
            // 
            this.rbpMain.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSystem,
            this.rpgPermission});
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
            // rpgPermission
            // 
            this.rpgPermission.Name = "rpgPermission";
            this.rpgPermission.Text = "&Phân quyền";
            // 
            // rbpCatalog
            // 
            this.rbpCatalog.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgTransport,
            this.rpgPolicy});
            this.rbpCatalog.Name = "rbpCatalog";
            this.rbpCatalog.Text = "Danh mục";
            // 
            // rpgTransport
            // 
            this.rpgTransport.Name = "rpgTransport";
            this.rpgTransport.Text = "&Vận tải";
            // 
            // rpgPolicy
            // 
            this.rpgPolicy.ItemLinks.Add(this.bbiPol_Right);
            this.rpgPolicy.Name = "rpgPolicy";
            this.rpgPolicy.Text = "&Chính sách";
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
            // tmmMain
            // 
            this.tmmMain.MdiParent = this;
            // 
            // tmrMain
            // 
            this.tmrMain.Enabled = true;
            this.tmrMain.Interval = 1000;
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
            this.Text = "QUẢN LÍ XE RA VÀO BẾN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmmMain)).EndInit();
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
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPermission;
        private DevExpress.XtraBars.BarButtonItem bbiExit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTransport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPolicy;
        private DevExpress.XtraBars.BarButtonItem bbiPol_Right;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tmmMain;
        private System.Windows.Forms.Timer tmrMain;
    }
}