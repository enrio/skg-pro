namespace SKG.DXF.Station.Charts
{
    partial class FrmTra_Sales
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dckSalesDay = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.sccMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.cbbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dteDay = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sccContent = new DevExpress.XtraEditors.SplitContainerControl();
            this.dckSalesMonth = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dckSalesQuatar = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.dckSalesDay.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).BeginInit();
            this.sccMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteDay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccContent)).BeginInit();
            this.sccContent.SuspendLayout();
            this.dckSalesMonth.SuspendLayout();
            this.dckSalesQuatar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // panelContainer1
            // 
            this.panelContainer1.ActiveChild = this.dckSalesDay;
            this.panelContainer1.Controls.Add(this.dckSalesDay);
            this.panelContainer1.Controls.Add(this.dckSalesMonth);
            this.panelContainer1.Controls.Add(this.dckSalesQuatar);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelContainer1.FloatVertical = true;
            this.panelContainer1.ID = new System.Guid("282d4ad5-8c4e-4cd0-8ba2-cf0a159f255d");
            this.panelContainer1.Location = new System.Drawing.Point(0, 63);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(200, 200);
            this.panelContainer1.Size = new System.Drawing.Size(593, 336);
            this.panelContainer1.Tabbed = true;
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dckSalesDay
            // 
            this.dckSalesDay.Controls.Add(this.controlContainer1);
            this.dckSalesDay.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dckSalesDay.ID = new System.Guid("e601b1ec-7a0c-470b-b500-d099d84edfc2");
            this.dckSalesDay.Location = new System.Drawing.Point(4, 23);
            this.dckSalesDay.Name = "dckSalesDay";
            this.dckSalesDay.OriginalSize = new System.Drawing.Size(200, 200);
            this.dckSalesDay.Size = new System.Drawing.Size(585, 282);
            this.dckSalesDay.Text = "Doanh thu theo ngày";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.sccMain);
            this.controlContainer1.Location = new System.Drawing.Point(0, 0);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(585, 282);
            this.controlContainer1.TabIndex = 0;
            // 
            // sccMain
            // 
            this.sccMain.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.sccMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.sccMain.Horizontal = false;
            this.sccMain.Location = new System.Drawing.Point(0, 0);
            this.sccMain.Name = "sccMain";
            this.sccMain.Panel1.Controls.Add(this.layoutControl2);
            this.sccMain.Panel1.Controls.Add(this.layoutControl1);
            this.sccMain.Panel1.Text = "Panel1";
            this.sccMain.Panel2.Controls.Add(this.sccContent);
            this.sccMain.Panel2.Text = "Panel2";
            this.sccMain.Size = new System.Drawing.Size(585, 282);
            this.sccMain.SplitterPosition = 24;
            this.sccMain.TabIndex = 6;
            this.sccMain.Text = "splitContainerControl1";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.cbbType);
            this.layoutControl2.Location = new System.Drawing.Point(197, 0);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(231, 24);
            this.layoutControl2.TabIndex = 1;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // cbbType
            // 
            this.cbbType.Location = new System.Drawing.Point(42, 2);
            this.cbbType.Name = "cbbType";
            this.cbbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbType.Size = new System.Drawing.Size(187, 20);
            this.cbbType.StyleController = this.layoutControl2;
            this.cbbType.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(231, 24);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cbbType;
            this.layoutControlItem2.CustomizationFormText = "Tiêu chí";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(231, 24);
            this.layoutControlItem2.Text = "Tiêu chí";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(36, 13);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dteDay);
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(196, 24);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dteDay
            // 
            this.dteDay.EditValue = null;
            this.dteDay.Location = new System.Drawing.Point(58, 2);
            this.dteDay.Name = "dteDay";
            this.dteDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteDay.Size = new System.Drawing.Size(136, 20);
            this.dteDay.StyleController = this.layoutControl1;
            this.dteDay.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(196, 24);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dteDay;
            this.layoutControlItem1.CustomizationFormText = "Chọn ngày";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(196, 24);
            this.layoutControlItem1.Text = "Chọn ngày";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(52, 13);
            // 
            // sccContent
            // 
            this.sccContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccContent.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.sccContent.Location = new System.Drawing.Point(0, 0);
            this.sccContent.Name = "sccContent";
            this.sccContent.Panel1.Text = "Panel1";
            this.sccContent.Panel2.Text = "Panel2";
            this.sccContent.Size = new System.Drawing.Size(585, 253);
            this.sccContent.SplitterPosition = 290;
            this.sccContent.TabIndex = 0;
            this.sccContent.Text = "splitContainerControl1";
            // 
            // dckSalesMonth
            // 
            this.dckSalesMonth.Controls.Add(this.dockPanel1_Container);
            this.dckSalesMonth.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dckSalesMonth.FloatVertical = true;
            this.dckSalesMonth.ID = new System.Guid("16a2b87b-d010-4922-b8db-e0c55586e1c1");
            this.dckSalesMonth.Location = new System.Drawing.Point(4, 23);
            this.dckSalesMonth.Name = "dckSalesMonth";
            this.dckSalesMonth.OriginalSize = new System.Drawing.Size(200, 200);
            this.dckSalesMonth.Size = new System.Drawing.Size(585, 282);
            this.dckSalesMonth.Text = "Doanh thu theo tháng";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(585, 282);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dckSalesQuatar
            // 
            this.dckSalesQuatar.Controls.Add(this.dockPanel2_Container);
            this.dckSalesQuatar.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dckSalesQuatar.ID = new System.Guid("efddf0bf-8e67-492a-8bff-e08498797255");
            this.dckSalesQuatar.Location = new System.Drawing.Point(4, 23);
            this.dckSalesQuatar.Name = "dckSalesQuatar";
            this.dckSalesQuatar.OriginalSize = new System.Drawing.Size(200, 200);
            this.dckSalesQuatar.Size = new System.Drawing.Size(585, 282);
            this.dckSalesQuatar.Text = "Doanh thu theo quí";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(585, 282);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // FrmTra_Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(593, 399);
            this.Controls.Add(this.panelContainer1);
            this.Name = "FrmTra_Sales";
            this.Load += new System.EventHandler(this.FrmTra_Sales_Load);
            this.Controls.SetChildIndex(this.panelContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.dckSalesDay.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).EndInit();
            this.sccMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dteDay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccContent)).EndInit();
            this.sccContent.ResumeLayout(false);
            this.dckSalesMonth.ResumeLayout(false);
            this.dckSalesQuatar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dckSalesMonth;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dckSalesDay;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraEditors.SplitContainerControl sccMain;
        private DevExpress.XtraBars.Docking.DockPanel dckSalesQuatar;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraEditors.SplitContainerControl sccContent;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cbbType;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit dteDay;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}