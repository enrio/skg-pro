namespace SKG.PRE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiLogin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSetting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCloseAll = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPol_Right = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPol_Role = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPol_User = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAuthor = new DevExpress.XtraBars.BarButtonItem();
            this.bbiProduct = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRegistry = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPol_UserRight = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPol_RoleRight = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTra_Group = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTra_Kind = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTra_Vehicle = new DevExpress.XtraBars.BarButtonItem();
            this.rgbMain = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.bsiServer = new DevExpress.XtraBars.BarStaticItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.bsiTimer = new DevExpress.XtraBars.BarStaticItem();
            this.bbiPol_UserRole = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGateIn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGateOut = new DevExpress.XtraBars.BarButtonItem();
            this.bbiInDepot = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSales = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHelp = new DevExpress.XtraBars.BarButtonItem();
            this.rbpMain = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgPermission = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgSkin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpCatalog = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgTransport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgPolicy = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpManage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgInOut = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgSumary = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
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
            // 
            // 
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiLogin,
            this.bbiSetting,
            this.bbiCloseAll,
            this.bbiExit,
            this.bbiPol_Right,
            this.bbiPol_Role,
            this.bbiPol_User,
            this.bbiAuthor,
            this.bbiProduct,
            this.bbiRegistry,
            this.bbiPol_UserRight,
            this.bbiPol_RoleRight,
            this.bbiTra_Group,
            this.bbiTra_Kind,
            this.bbiTra_Vehicle,
            this.rgbMain,
            this.bsiServer,
            this.bsiUser,
            this.bsiTimer,
            this.bbiPol_UserRole,
            this.bbiGateIn,
            this.bbiGateOut,
            this.bbiInDepot,
            this.bbiSales,
            this.bbiHelp});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 27;
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
            this.bbiLogin.Caption = "Đăng nhập";
            this.bbiLogin.Id = 1;
            this.bbiLogin.LargeGlyph = global::SKG.PRE.Properties.Resources.login;
            this.bbiLogin.Name = "bbiLogin";
            this.bbiLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLogin_ItemClick);
            // 
            // bbiSetting
            // 
            this.bbiSetting.Caption = "Cài đặt";
            this.bbiSetting.Id = 2;
            this.bbiSetting.LargeGlyph = global::SKG.PRE.Properties.Resources.setting;
            this.bbiSetting.Name = "bbiSetting";
            this.bbiSetting.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSetting_ItemClick);
            // 
            // bbiCloseAll
            // 
            this.bbiCloseAll.Caption = "Đóng hết cửa sổ";
            this.bbiCloseAll.Id = 3;
            this.bbiCloseAll.LargeGlyph = global::SKG.PRE.Properties.Resources.close;
            this.bbiCloseAll.Name = "bbiCloseAll";
            this.bbiCloseAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCloseAll_ItemClick);
            // 
            // bbiExit
            // 
            this.bbiExit.Caption = "Thoát";
            this.bbiExit.Id = 4;
            this.bbiExit.LargeGlyph = global::SKG.PRE.Properties.Resources.exit;
            this.bbiExit.Name = "bbiExit";
            this.bbiExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExit_ItemClick);
            // 
            // bbiPol_Right
            // 
            this.bbiPol_Right.Caption = "Chức năng (form)";
            this.bbiPol_Right.Id = 5;
            this.bbiPol_Right.LargeGlyph = global::SKG.PRE.Properties.Resources.palette;
            this.bbiPol_Right.Name = "bbiPol_Right";
            this.bbiPol_Right.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPol_Right_ItemClick);
            // 
            // bbiPol_Role
            // 
            this.bbiPol_Role.Caption = "Nhóm người dùng";
            this.bbiPol_Role.Id = 6;
            this.bbiPol_Role.LargeGlyph = global::SKG.PRE.Properties.Resources.users;
            this.bbiPol_Role.Name = "bbiPol_Role";
            this.bbiPol_Role.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPol_Role_ItemClick);
            // 
            // bbiPol_User
            // 
            this.bbiPol_User.Caption = "Người sử dụng";
            this.bbiPol_User.Id = 7;
            this.bbiPol_User.LargeGlyph = global::SKG.PRE.Properties.Resources.user;
            this.bbiPol_User.Name = "bbiPol_User";
            this.bbiPol_User.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPol_User_ItemClick);
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
            this.bbiRegistry.LargeGlyph = global::SKG.PRE.Properties.Resources.registry;
            this.bbiRegistry.Name = "bbiRegistry";
            this.bbiRegistry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRegistry_ItemClick);
            // 
            // bbiPol_UserRight
            // 
            this.bbiPol_UserRight.Caption = "Cho người dùng";
            this.bbiPol_UserRight.Id = 11;
            this.bbiPol_UserRight.LargeGlyph = global::SKG.PRE.Properties.Resources.user;
            this.bbiPol_UserRight.Name = "bbiPol_UserRight";
            this.bbiPol_UserRight.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPol_UserRight_ItemClick);
            // 
            // bbiPol_RoleRight
            // 
            this.bbiPol_RoleRight.Caption = "Cho nhóm người";
            this.bbiPol_RoleRight.Id = 12;
            this.bbiPol_RoleRight.LargeGlyph = global::SKG.PRE.Properties.Resources.main;
            this.bbiPol_RoleRight.Name = "bbiPol_RoleRight";
            this.bbiPol_RoleRight.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPol_RoleRight_ItemClick);
            // 
            // bbiTra_Group
            // 
            this.bbiTra_Group.Caption = "Danh mục nhóm xe";
            this.bbiTra_Group.Id = 13;
            this.bbiTra_Group.LargeGlyph = global::SKG.PRE.Properties.Resources.group;
            this.bbiTra_Group.Name = "bbiTra_Group";

            // 
            // bbiTra_Kind
            // 
            this.bbiTra_Kind.Caption = "Danh mục loại xe";
            this.bbiTra_Kind.Id = 14;
            this.bbiTra_Kind.LargeGlyph = global::SKG.PRE.Properties.Resources.kind;
            this.bbiTra_Kind.Name = "bbiTra_Kind";

            // 
            // bbiTra_Vehicle
            // 
            this.bbiTra_Vehicle.Caption = "Danh mục xe cộ";
            this.bbiTra_Vehicle.Id = 15;
            this.bbiTra_Vehicle.LargeGlyph = global::SKG.PRE.Properties.Resources.car;
            this.bbiTra_Vehicle.Name = "bbiTra_Vehicle";

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
            this.bsiServer.Glyph = global::SKG.PRE.Properties.Resources.db;
            this.bsiServer.Id = 17;
            this.bsiServer.Name = "bsiServer";
            this.bsiServer.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiUser
            // 
            this.bsiUser.Caption = "User";
            this.bsiUser.Glyph = global::SKG.PRE.Properties.Resources.user;
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
            // bbiPol_UserRole
            // 
            this.bbiPol_UserRole.Caption = "Người dùng thuộc nhóm";
            this.bbiPol_UserRole.Id = 20;
            this.bbiPol_UserRole.LargeGlyph = global::SKG.PRE.Properties.Resources.users;
            this.bbiPol_UserRole.Name = "bbiPol_UserRole";
            this.bbiPol_UserRole.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPol_UserRole_ItemClick);
            // 
            // bbiGateIn
            // 
            this.bbiGateIn.Caption = "Cổng vào";
            this.bbiGateIn.Id = 22;
            this.bbiGateIn.LargeGlyph = global::SKG.PRE.Properties.Resources.palette;
            this.bbiGateIn.Name = "bbiGateIn";

            // 
            // bbiGateOut
            // 
            this.bbiGateOut.Caption = "Cổng ra";
            this.bbiGateOut.Id = 23;
            this.bbiGateOut.LargeGlyph = global::SKG.PRE.Properties.Resources._out;
            this.bbiGateOut.Name = "bbiGateOut";

            // 
            // bbiInDepot
            // 
            this.bbiInDepot.Caption = "Xe trong bến";
            this.bbiInDepot.Id = 24;
            this.bbiInDepot.LargeGlyph = global::SKG.PRE.Properties.Resources.main;
            this.bbiInDepot.Name = "bbiInDepot";

            // 
            // bbiSales
            // 
            this.bbiSales.Caption = "Doanh thu";
            this.bbiSales.Id = 25;
            this.bbiSales.LargeGlyph = global::SKG.PRE.Properties.Resources.cost;
            this.bbiSales.Name = "bbiSales";

            // 
            // bbiHelp
            // 
            this.bbiHelp.Caption = "Hướng dẫn";
            this.bbiHelp.Id = 26;
            this.bbiHelp.LargeGlyph = global::SKG.PRE.Properties.Resources.infor;
            this.bbiHelp.Name = "bbiHelp";
            this.bbiHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiHelp_ItemClick);
            // 
            // rbpMain
            // 
            this.rbpMain.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSystem,
            this.rpgPermission,
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
            // rpgPermission
            // 
            this.rpgPermission.ItemLinks.Add(this.bbiPol_UserRight);
            this.rpgPermission.ItemLinks.Add(this.bbiPol_RoleRight);
            this.rpgPermission.ItemLinks.Add(this.bbiPol_UserRole);
            this.rpgPermission.Name = "rpgPermission";
            this.rpgPermission.Text = "&Phân quyền";
            // 
            // rpgSkin
            // 
            this.rpgSkin.ItemLinks.Add(this.rgbMain);
            this.rpgSkin.Name = "rpgSkin";
            this.rpgSkin.Text = "&Giao diện";
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
            this.rpgTransport.ItemLinks.Add(this.bbiTra_Group);
            this.rpgTransport.ItemLinks.Add(this.bbiTra_Kind);
            this.rpgTransport.ItemLinks.Add(this.bbiTra_Vehicle);
            this.rpgTransport.Name = "rpgTransport";
            this.rpgTransport.Text = "&Vận tải";
            // 
            // rpgPolicy
            // 
            this.rpgPolicy.ItemLinks.Add(this.bbiPol_Right);
            this.rpgPolicy.ItemLinks.Add(this.bbiPol_Role);
            this.rpgPolicy.ItemLinks.Add(this.bbiPol_User);
            this.rpgPolicy.Name = "rpgPolicy";
            this.rpgPolicy.Text = "&Chính sách";
            // 
            // rbpManage
            // 
            this.rbpManage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgInOut,
            this.rpgSumary});
            this.rbpManage.Name = "rbpManage";
            this.rbpManage.Text = "Quản lí";
            // 
            // rpgInOut
            // 
            this.rpgInOut.ItemLinks.Add(this.bbiGateIn);
            this.rpgInOut.ItemLinks.Add(this.bbiGateOut);
            this.rpgInOut.Name = "rpgInOut";
            this.rpgInOut.Text = "Ra vào";
            // 
            // rpgSumary
            // 
            this.rpgSumary.ItemLinks.Add(this.bbiInDepot);
            this.rpgSumary.ItemLinks.Add(this.bbiSales);
            this.rpgSumary.Name = "rpgSumary";
            this.rpgSumary.Text = "Thống kê";
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
            this.Text = "QUẢN LÍ XE RA VÀO BẾN";
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
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpCatalog;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpManage;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpHelp;
        private DevExpress.XtraBars.BarButtonItem bbiLogin;
        private DevExpress.XtraBars.BarButtonItem bbiSetting;
        private DevExpress.XtraBars.BarButtonItem bbiCloseAll;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPermission;
        private DevExpress.XtraBars.BarButtonItem bbiExit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTransport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPolicy;
        private DevExpress.XtraBars.BarButtonItem bbiPol_Right;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tmmMain;
        private System.Windows.Forms.Timer tmrMain;
        private DevExpress.XtraBars.BarButtonItem bbiPol_Role;
        private DevExpress.XtraBars.BarButtonItem bbiPol_User;
        private DevExpress.XtraBars.BarButtonItem bbiAuthor;
        private DevExpress.XtraBars.BarButtonItem bbiProduct;
        private DevExpress.XtraBars.BarButtonItem bbiRegistry;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgInformation;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgUse;
        private DevExpress.XtraBars.BarButtonItem bbiPol_UserRight;
        private DevExpress.XtraBars.BarButtonItem bbiPol_RoleRight;
        private DevExpress.XtraBars.BarButtonItem bbiTra_Group;
        private DevExpress.XtraBars.BarButtonItem bbiTra_Kind;
        private DevExpress.XtraBars.BarButtonItem bbiTra_Vehicle;
        private DevExpress.XtraBars.RibbonGalleryBarItem rgbMain;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSkin;
        private DevExpress.XtraBars.BarStaticItem bsiServer;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarStaticItem bsiTimer;
        private DevExpress.XtraBars.BarButtonItem bbiPol_UserRole;
        private DevExpress.XtraBars.BarButtonItem bbiGateIn;
        private DevExpress.XtraBars.BarButtonItem bbiGateOut;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgInOut;
        private DevExpress.XtraBars.BarButtonItem bbiInDepot;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSumary;
        private DevExpress.XtraBars.BarButtonItem bbiSales;
        private DevExpress.XtraBars.BarButtonItem bbiHelp;
    }
}