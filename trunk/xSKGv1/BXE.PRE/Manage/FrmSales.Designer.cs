namespace BXE.PRE.Manage
{
    partial class FrmSales
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
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbeMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbeQuater = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dteTo = new DevExpress.XtraEditors.DateEdit();
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.dteFrom = new DevExpress.XtraEditors.DateEdit();
            this.lblFrom = new DevExpress.XtraEditors.LabelControl();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.grcMain = new DevExpress.XtraGrid.GridControl();
            this.grvMain = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeQuater.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFrom.Properties)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockPanel1.ID = new System.Guid("ce5af645-1cb6-4a38-b09c-a753d0da5418");
            this.dockPanel1.Location = new System.Drawing.Point(0, 63);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 54);
            this.dockPanel1.Size = new System.Drawing.Size(951, 54);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.labelControl4);
            this.dockPanel1_Container.Controls.Add(this.labelControl3);
            this.dockPanel1_Container.Controls.Add(this.cbeMonth);
            this.dockPanel1_Container.Controls.Add(this.cbeQuater);
            this.dockPanel1_Container.Controls.Add(this.dteTo);
            this.dockPanel1_Container.Controls.Add(this.lblTo);
            this.dockPanel1_Container.Controls.Add(this.dteFrom);
            this.dockPanel1_Container.Controls.Add(this.lblFrom);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(943, 27);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(96, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Tháng:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(20, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Quí:";
            // 
            // cbeMonth
            // 
            this.cbeMonth.Location = new System.Drawing.Point(136, 3);
            this.cbeMonth.Name = "cbeMonth";
            this.cbeMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeMonth.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbeMonth.Size = new System.Drawing.Size(56, 20);
            this.cbeMonth.TabIndex = 1;
            this.cbeMonth.SelectedIndexChanged += new System.EventHandler(this.cbeMonth_SelectedIndexChanged);
            // 
            // cbeQuater
            // 
            this.cbeQuater.Location = new System.Drawing.Point(34, 3);
            this.cbeQuater.Name = "cbeQuater";
            this.cbeQuater.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeQuater.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbeQuater.Size = new System.Drawing.Size(56, 20);
            this.cbeQuater.TabIndex = 0;
            this.cbeQuater.SelectedIndexChanged += new System.EventHandler(this.cbeQuater_SelectedIndexChanged);
            // 
            // dteTo
            // 
            this.dteTo.EditValue = null;
            this.dteTo.Location = new System.Drawing.Point(391, 3);
            this.dteTo.Name = "dteTo";
            this.dteTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dteTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dteTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteTo.Size = new System.Drawing.Size(80, 20);
            this.dteTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(334, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(51, 13);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "Đến ngày:";
            // 
            // dteFrom
            // 
            this.dteFrom.EditValue = null;
            this.dteFrom.Location = new System.Drawing.Point(248, 3);
            this.dteFrom.Name = "dteFrom";
            this.dteFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dteFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dteFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteFrom.Size = new System.Drawing.Size(80, 20);
            this.dteFrom.TabIndex = 2;
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(198, 6);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(44, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "Từ ngày:";
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("05646b24-98a0-40ac-b748-ad2917ec208b");
            this.dockPanel2.Location = new System.Drawing.Point(0, 117);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(951, 200);
            this.dockPanel2.Size = new System.Drawing.Size(951, 449);
            this.dockPanel2.Text = "dockPanel2";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.grcMain);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(943, 422);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // grcMain
            // 
            this.grcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcMain.Location = new System.Drawing.Point(0, 0);
            this.grcMain.MainView = this.grvMain;
            this.grcMain.Name = "grcMain";
            this.grcMain.Size = new System.Drawing.Size(943, 422);
            this.grcMain.TabIndex = 4;
            this.grcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMain});
            // 
            // grvMain
            // 
            this.grvMain.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4});
            this.grvMain.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.grvMain.GridControl = this.grcMain;
            this.grvMain.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Money", null, "\"Tổng tiền: {0:0,0}\"")});
            this.grvMain.Name = "grvMain";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Thông tin";
            this.gridBand1.Columns.Add(this.gridColumn1);
            this.gridBand1.Columns.Add(this.gridColumn2);
            this.gridBand1.Columns.Add(this.gridColumn3);
            this.gridBand1.Columns.Add(this.gridColumn13);
            this.gridBand1.Columns.Add(this.gridColumn4);
            this.gridBand1.Columns.Add(this.gridColumn5);
            this.gridBand1.Columns.Add(this.gridColumn6);
            this.gridBand1.Columns.Add(this.gridColumn7);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 525;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "STT";
            this.gridColumn2.FieldName = "No_";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Biển số xe";
            this.gridColumn3.FieldName = "Number";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Loại xe";
            this.gridColumn13.FieldName = "KindName";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Người cho vào";
            this.gridColumn4.FieldName = "UserInName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Thời gian vào";
            this.gridColumn5.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn5.FieldName = "DateIn";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Người cho ra";
            this.gridColumn6.FieldName = "UserOutName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Thời gian ra";
            this.gridColumn7.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "DateOut";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Lượt xe";
            this.gridBand2.Columns.Add(this.gridColumn8);
            this.gridBand2.Columns.Add(this.gridColumn9);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 150;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Nửa ngày";
            this.gridColumn8.FieldName = "HalfDay";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Một ngày (lần)";
            this.gridColumn9.FieldName = "Days";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Đơn giá";
            this.gridBand3.Columns.Add(this.gridColumn10);
            this.gridBand3.Columns.Add(this.gridColumn11);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 150;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Nửa ngày";
            this.gridColumn10.DisplayFormat.FormatString = "#,#";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Price1";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Một ngày (lần)";
            this.gridColumn11.DisplayFormat.FormatString = "#,#";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "Price2";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "Tính tiền";
            this.gridBand4.Columns.Add(this.gridColumn12);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 75;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Thành tiền";
            this.gridColumn12.DisplayFormat.FormatString = "#,#";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn12.FieldName = "Money";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            // 
            // FrmSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(951, 566);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "FrmSales";
            this.Text = "Doanh thu";
            this.Controls.SetChildIndex(this.dockPanel1, 0);
            this.Controls.SetChildIndex(this.dockPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeQuater.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFrom.Properties)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraGrid.GridControl grcMain;
        private DevExpress.XtraEditors.DateEdit dteFrom;
        private DevExpress.XtraEditors.LabelControl lblFrom;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cbeMonth;
        private DevExpress.XtraEditors.ComboBoxEdit cbeQuater;
        private DevExpress.XtraEditors.DateEdit dteTo;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvMain;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn13;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn11;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn12;
    }
}
