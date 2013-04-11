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
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dckSalesMonth = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dckSalesDay = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.sccMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.ckbAutoUpdate = new DevExpress.XtraEditors.CheckButton();
            this.cbbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dteDay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sccContent = new DevExpress.XtraEditors.SplitContainerControl();
            this.dckSalesQuatar = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.usrSalesMonth = new SKG.DXF.Station.Charts.UsrSales();
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.dckSalesMonth.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dckSalesDay.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).BeginInit();
            this.sccMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccContent)).BeginInit();
            this.sccContent.SuspendLayout();
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
            this.panelContainer1.ActiveChild = this.dckSalesMonth;
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
            this.dockPanel1_Container.Controls.Add(this.usrSalesMonth);
            this.dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(585, 282);
            this.dockPanel1_Container.TabIndex = 0;
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
            this.sccMain.Panel1.Controls.Add(this.ckbAutoUpdate);
            this.sccMain.Panel1.Controls.Add(this.cbbType);
            this.sccMain.Panel1.Controls.Add(this.labelControl2);
            this.sccMain.Panel1.Controls.Add(this.dteDay);
            this.sccMain.Panel1.Controls.Add(this.labelControl1);
            this.sccMain.Panel1.Text = "Panel1";
            this.sccMain.Panel2.Controls.Add(this.sccContent);
            this.sccMain.Panel2.Text = "Panel2";
            this.sccMain.Size = new System.Drawing.Size(585, 282);
            this.sccMain.SplitterPosition = 23;
            this.sccMain.TabIndex = 6;
            this.sccMain.Text = "splitContainerControl1";
            // 
            // ckbAutoUpdate
            // 
            this.ckbAutoUpdate.Location = new System.Drawing.Point(351, 2);
            this.ckbAutoUpdate.Name = "ckbAutoUpdate";
            this.ckbAutoUpdate.Size = new System.Drawing.Size(98, 20);
            this.ckbAutoUpdate.TabIndex = 4;
            this.ckbAutoUpdate.Text = "Tự động cập nhật";
            this.ckbAutoUpdate.CheckedChanged += new System.EventHandler(this.ckbAutoUpdate_CheckedChanged);
            // 
            // cbbType
            // 
            this.cbbType.EditValue = "Theo miền (xe cố định)";
            this.cbbType.Location = new System.Drawing.Point(211, 3);
            this.cbbType.Name = "cbbType";
            this.cbbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbType.Properties.Items.AddRange(new object[] {
            "Theo miền (xe cố định)",
            "Theo vùng (xe cố định)",
            "Theo tỉnh (xe cố định)",
            "Theo đvvt (xe cố định)",
            "Theo nhóm (xe vãng lai)",
            "Theo loại (xe vãng lai)",
            "Theo cố định, vãng lai"});
            this.cbbType.Size = new System.Drawing.Size(134, 20);
            this.cbbType.TabIndex = 3;
            this.cbbType.SelectedIndexChanged += new System.EventHandler(this.cbbType_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(169, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Tiêu chí";
            // 
            // dteDay
            // 
            this.dteDay.EditValue = null;
            this.dteDay.Location = new System.Drawing.Point(61, 3);
            this.dteDay.Name = "dteDay";
            this.dteDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteDay.Size = new System.Drawing.Size(102, 20);
            this.dteDay.TabIndex = 1;
            this.dteDay.EditValueChanged += new System.EventHandler(this.dteDay_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn ngày";
            // 
            // sccContent
            // 
            this.sccContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccContent.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.sccContent.Location = new System.Drawing.Point(0, 0);
            this.sccContent.Name = "sccContent";
            this.sccContent.Panel1.Text = "Panel1";
            this.sccContent.Panel2.Text = "Panel2";
            this.sccContent.Size = new System.Drawing.Size(585, 254);
            this.sccContent.SplitterPosition = 290;
            this.sccContent.TabIndex = 0;
            this.sccContent.Text = "splitContainerControl1";
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
            // usrSalesMonth
            // 
            this.usrSalesMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrSalesMonth.Location = new System.Drawing.Point(0, 0);
            this.usrSalesMonth.Name = "usrSalesMonth";
            this.usrSalesMonth.Size = new System.Drawing.Size(585, 282);
            this.usrSalesMonth.TabIndex = 0;
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
            this.dckSalesMonth.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dckSalesDay.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).EndInit();
            this.sccMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccContent)).EndInit();
            this.sccContent.ResumeLayout(false);
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
        private DevExpress.XtraEditors.ComboBoxEdit cbbType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dteDay;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckButton ckbAutoUpdate;
        private UsrSales usrSalesMonth;
    }
}