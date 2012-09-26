namespace SKG.DXF.Station.Discrete
{
    partial class FrmTra_Vehicle
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
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSeats = new DevExpress.XtraEditors.TextEdit();
            this.txtBeds = new DevExpress.XtraEditors.TextEdit();
            this.lblBeds = new DevExpress.XtraEditors.LabelControl();
            this.lblSeats = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.lueTransport = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTransport = new DevExpress.XtraEditors.LabelControl();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.grcMain = new DevExpress.XtraGrid.GridControl();
            this.grvMain = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeats.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeds.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTransport.Properties)).BeginInit();
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
            this.dockPanel1.ID = new System.Guid("10b3cfe1-e785-4df6-b3c7-5ee3233ad318");
            this.dockPanel1.Location = new System.Drawing.Point(0, 63);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 93);
            this.dockPanel1.Size = new System.Drawing.Size(951, 93);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.groupBox2);
            this.dockPanel1_Container.Controls.Add(this.groupBox1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(943, 66);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSeats);
            this.groupBox2.Controls.Add(this.txtBeds);
            this.groupBox2.Controls.Add(this.lblBeds);
            this.groupBox2.Controls.Add(this.lblSeats);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(515, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tải trọng";
            // 
            // txtSeats
            // 
            this.txtSeats.Location = new System.Drawing.Point(46, 23);
            this.txtSeats.Name = "txtSeats";
            this.txtSeats.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeats.Properties.Appearance.Options.UseFont = true;
            this.txtSeats.Properties.Mask.EditMask = "([1-9]\\d*([.]\\d)?\\d?)|[0]";
            this.txtSeats.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSeats.Size = new System.Drawing.Size(55, 26);
            this.txtSeats.TabIndex = 1;
            // 
            // txtBeds
            // 
            this.txtBeds.Location = new System.Drawing.Point(171, 23);
            this.txtBeds.Name = "txtBeds";
            this.txtBeds.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeds.Properties.Appearance.Options.UseFont = true;
            this.txtBeds.Properties.Mask.EditMask = "([1-9]\\d*([.]\\d)?\\d?)|[0]";
            this.txtBeds.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtBeds.Size = new System.Drawing.Size(55, 26);
            this.txtBeds.TabIndex = 3;
            // 
            // lblBeds
            // 
            this.lblBeds.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeds.Location = new System.Drawing.Point(107, 26);
            this.lblBeds.Name = "lblBeds";
            this.lblBeds.Size = new System.Drawing.Size(58, 19);
            this.lblBeds.TabIndex = 2;
            this.lblBeds.Text = "Giường:";
            // 
            // lblSeats
            // 
            this.lblSeats.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeats.Location = new System.Drawing.Point(6, 26);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(34, 19);
            this.lblSeats.TabIndex = 0;
            this.lblSeats.Text = "Ghế:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.lblCode);
            this.groupBox1.Controls.Add(this.lueTransport);
            this.groupBox1.Controls.Add(this.lblTransport);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin xe";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(363, 23);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Size = new System.Drawing.Size(135, 26);
            this.txtCode.TabIndex = 3;
            // 
            // lblCode
            // 
            this.lblCode.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(301, 26);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(57, 19);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Biển số:";
            // 
            // lueTransport
            // 
            this.lueTransport.Location = new System.Drawing.Point(68, 23);
            this.lueTransport.Name = "lueTransport";
            this.lueTransport.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueTransport.Properties.Appearance.Options.UseFont = true;
            this.lueTransport.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueTransport.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueTransport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTransport.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("No", "STT", 10, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Tên")});
            this.lueTransport.Properties.DisplayMember = "Text";
            this.lueTransport.Properties.ShowHeader = false;
            this.lueTransport.Properties.ValueMember = "Id";
            this.lueTransport.Size = new System.Drawing.Size(227, 26);
            this.lueTransport.TabIndex = 1;
            // 
            // lblTransport
            // 
            this.lblTransport.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransport.Location = new System.Drawing.Point(6, 26);
            this.lblTransport.Name = "lblTransport";
            this.lblTransport.Size = new System.Drawing.Size(56, 19);
            this.lblTransport.TabIndex = 0;
            this.lblTransport.Text = "Loại xe:";
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("d59a7d3a-6cea-460f-9e5e-a1f9105d471d");
            this.dockPanel2.Location = new System.Drawing.Point(0, 156);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(951, 200);
            this.dockPanel2.Size = new System.Drawing.Size(951, 410);
            this.dockPanel2.Text = "dockPanel2";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.grcMain);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(943, 383);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // grcMain
            // 
            this.grcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcMain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcMain.Location = new System.Drawing.Point(0, 0);
            this.grcMain.MainView = this.grvMain;
            this.grcMain.Name = "grcMain";
            this.grcMain.Size = new System.Drawing.Size(943, 383);
            this.grcMain.TabIndex = 0;
            this.grcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMain});
            // 
            // grvMain
            // 
            this.grvMain.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvMain.Appearance.BandPanel.Options.UseFont = true;
            this.grvMain.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvMain.Appearance.GroupRow.Options.UseFont = true;
            this.grvMain.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvMain.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMain.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvMain.Appearance.Row.Options.UseFont = true;
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
            this.gridColumn6});
            this.grvMain.GridControl = this.grcMain;
            this.grvMain.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Transport", null, "- Số xe: {0:0,0}")});
            this.grvMain.Name = "grvMain";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Thông tin xe";
            this.gridBand1.Columns.Add(this.gridColumn1);
            this.gridBand1.Columns.Add(this.gridColumn2);
            this.gridBand1.Columns.Add(this.gridColumn3);
            this.gridBand1.Columns.Add(this.gridColumn4);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 164;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "STT";
            this.gridColumn2.FieldName = "No_";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.Width = 41;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Biển số";
            this.gridColumn3.FieldName = "Code";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.Width = 60;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Loại xe";
            this.gridColumn4.FieldName = "Kind";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.Width = 63;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Tải trọng";
            this.gridBand2.Columns.Add(this.gridColumn5);
            this.gridBand2.Columns.Add(this.gridColumn6);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 136;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ghế";
            this.gridColumn5.FieldName = "Seats";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.Width = 66;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Giường";
            this.gridColumn6.FieldName = "Beds";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.Width = 70;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Loại xe";
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 66;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "Thông tin quản lý";
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 69;
            // 
            // FrmTra_Vehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(951, 566);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "FrmTra_Vehicle";
            this.Load += new System.EventHandler(this.FrmTra_Media_Load);
            this.Controls.SetChildIndex(this.dockPanel1, 0);
            this.Controls.SetChildIndex(this.dockPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeats.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBeds.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTransport.Properties)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.TextEdit txtSeats;
        private DevExpress.XtraEditors.TextEdit txtBeds;
        private DevExpress.XtraEditors.LabelControl lblBeds;
        private DevExpress.XtraEditors.LabelControl lblSeats;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.LookUpEdit lueTransport;
        private DevExpress.XtraEditors.LabelControl lblTransport;
        private DevExpress.XtraGrid.GridControl grcMain;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvMain;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
    }
}