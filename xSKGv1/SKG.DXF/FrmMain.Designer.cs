﻿namespace SKG.DXF
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
            this.bsiServer = new DevExpress.XtraBars.BarStaticItem();
            this.bsiUser = new DevExpress.XtraBars.BarStaticItem();
            this.bsiTimer = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tmdMain = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmdMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bsiServer,
            this.bsiUser,
            this.bsiTimer});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(893, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bsiServer
            // 
            this.bsiServer.Caption = "Server";
            this.bsiServer.Glyph = global::SKG.DXF.Properties.Resources.db;
            this.bsiServer.Id = 1;
            this.bsiServer.Name = "bsiServer";
            this.bsiServer.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiUser
            // 
            this.bsiUser.Caption = "User";
            this.bsiUser.Glyph = global::SKG.DXF.Properties.Resources.user;
            this.bsiUser.Id = 2;
            this.bsiUser.Name = "bsiUser";
            this.bsiUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiTimer
            // 
            this.bsiTimer.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiTimer.Caption = "Timer";
            this.bsiTimer.Id = 3;
            this.bsiTimer.Name = "bsiTimer";
            this.bsiTimer.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiServer);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiUser);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiTimer);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 439);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(893, 31);
            // 
            // tmdMain
            // 
            this.tmdMain.MdiParent = this;
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
            this.ClientSize = new System.Drawing.Size(893, 470);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "...:: SKG ::...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FrmMain_Activated);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmdMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tmdMain;
        private System.Windows.Forms.Timer tmrMain;
        private DevExpress.XtraBars.BarStaticItem bsiServer;
        private DevExpress.XtraBars.BarStaticItem bsiUser;
        private DevExpress.XtraBars.BarStaticItem bsiTimer;
    }
}