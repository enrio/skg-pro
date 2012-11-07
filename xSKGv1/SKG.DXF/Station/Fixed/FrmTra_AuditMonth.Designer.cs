namespace SKG.DXF.Station.Fixed
{
    partial class FrmTra_AuditMonth
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
            this.txtNode = new DevExpress.XtraEditors.TextEdit();
            this.lblNode = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.grcMain = new DevExpress.XtraGrid.GridControl();
            this.grvMain = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
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
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 63);
            this.dockPanel1.Size = new System.Drawing.Size(951, 63);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.txtCode);
            this.dockPanel1_Container.Controls.Add(this.txtNode);
            this.dockPanel1_Container.Controls.Add(this.lblCode);
            this.dockPanel1_Container.Controls.Add(this.lblNode);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(943, 36);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // txtNode
            // 
            this.txtNode.Location = new System.Drawing.Point(362, 3);
            this.txtNode.Name = "txtNode";
            this.txtNode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNode.Properties.Appearance.Options.UseFont = true;
            this.txtNode.Properties.Mask.EditMask = "([1-9]\\d*([.]\\d)?\\d?)|[0]";
            this.txtNode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtNode.Size = new System.Drawing.Size(91, 26);
            this.txtNode.TabIndex = 24;
            // 
            // lblNode
            // 
            this.lblNode.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNode.Location = new System.Drawing.Point(233, 6);
            this.lblNode.Name = "lblNode";
            this.lblNode.Size = new System.Drawing.Size(123, 19);
            this.lblNode.TabIndex = 23;
            this.lblNode.Text = "Lượt khách đi xe:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(71, 3);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Size = new System.Drawing.Size(156, 26);
            this.txtCode.TabIndex = 2;
            // 
            // lblCode
            // 
            this.lblCode.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(8, 6);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(57, 19);
            this.lblCode.TabIndex = 1;
            this.lblCode.Text = "Biển số:";
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("d59a7d3a-6cea-460f-9e5e-a1f9105d471d");
            this.dockPanel2.Location = new System.Drawing.Point(0, 126);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(951, 200);
            this.dockPanel2.Size = new System.Drawing.Size(951, 440);
            this.dockPanel2.Text = "dockPanel2";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.grcMain);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(943, 413);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // grcMain
            // 
            this.grcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcMain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcMain.Location = new System.Drawing.Point(0, 0);
            this.grcMain.MainView = this.grvMain;
            this.grcMain.Name = "grcMain";
            this.grcMain.Size = new System.Drawing.Size(943, 413);
            this.grcMain.TabIndex = 0;
            this.grcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMain});
            // 
            // grvMain
            // 
            this.grvMain.Appearance.BandPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.grvMain.Appearance.BandPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.grvMain.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvMain.Appearance.BandPanel.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.BandPanel.Options.UseBackColor = true;
            this.grvMain.Appearance.BandPanel.Options.UseBorderColor = true;
            this.grvMain.Appearance.BandPanel.Options.UseFont = true;
            this.grvMain.Appearance.BandPanel.Options.UseForeColor = true;
            this.grvMain.Appearance.BandPanelBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.grvMain.Appearance.BandPanelBackground.BackColor2 = System.Drawing.Color.White;
            this.grvMain.Appearance.BandPanelBackground.Options.UseBackColor = true;
            this.grvMain.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.grvMain.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.grvMain.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White;
            this.grvMain.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.grvMain.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.grvMain.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.grvMain.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.grvMain.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.grvMain.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.grvMain.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.grvMain.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.grvMain.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.grvMain.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.grvMain.Appearance.Empty.Options.UseBackColor = true;
            this.grvMain.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.grvMain.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.grvMain.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvMain.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvMain.Appearance.EvenRow.Options.UseBorderColor = true;
            this.grvMain.Appearance.EvenRow.Options.UseFont = true;
            this.grvMain.Appearance.EvenRow.Options.UseForeColor = true;
            this.grvMain.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.grvMain.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.grvMain.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White;
            this.grvMain.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.grvMain.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.grvMain.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.grvMain.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.grvMain.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.grvMain.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.FilterPanel.Options.UseBackColor = true;
            this.grvMain.Appearance.FilterPanel.Options.UseForeColor = true;
            this.grvMain.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.grvMain.Appearance.FixedLine.Options.UseBackColor = true;
            this.grvMain.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.grvMain.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvMain.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvMain.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.grvMain.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.grvMain.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvMain.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvMain.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvMain.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.grvMain.Appearance.FocusedRow.Options.UseFont = true;
            this.grvMain.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvMain.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.grvMain.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.grvMain.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.FooterPanel.Options.UseBackColor = true;
            this.grvMain.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.grvMain.Appearance.FooterPanel.Options.UseForeColor = true;
            this.grvMain.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.grvMain.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.grvMain.Appearance.GroupButton.Options.UseBackColor = true;
            this.grvMain.Appearance.GroupButton.Options.UseBorderColor = true;
            this.grvMain.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.grvMain.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.grvMain.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvMain.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvMain.Appearance.GroupFooter.Options.UseForeColor = true;
            this.grvMain.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.grvMain.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            this.grvMain.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvMain.Appearance.GroupPanel.Options.UseForeColor = true;
            this.grvMain.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.grvMain.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.grvMain.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvMain.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvMain.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvMain.Appearance.GroupRow.Options.UseFont = true;
            this.grvMain.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvMain.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.grvMain.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.grvMain.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvMain.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.grvMain.Appearance.HeaderPanelBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.grvMain.Appearance.HeaderPanelBackground.BackColor2 = System.Drawing.Color.White;
            this.grvMain.Appearance.HeaderPanelBackground.Options.UseBackColor = true;
            this.grvMain.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.grvMain.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.grvMain.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.grvMain.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvMain.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.grvMain.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvMain.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.grvMain.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvMain.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.grvMain.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.grvMain.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvMain.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.OddRow.Options.UseBackColor = true;
            this.grvMain.Appearance.OddRow.Options.UseBorderColor = true;
            this.grvMain.Appearance.OddRow.Options.UseFont = true;
            this.grvMain.Appearance.OddRow.Options.UseForeColor = true;
            this.grvMain.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.grvMain.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.grvMain.Appearance.Preview.Options.UseFont = true;
            this.grvMain.Appearance.Preview.Options.UseForeColor = true;
            this.grvMain.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.grvMain.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvMain.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.Row.Options.UseBackColor = true;
            this.grvMain.Appearance.Row.Options.UseFont = true;
            this.grvMain.Appearance.Row.Options.UseForeColor = true;
            this.grvMain.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.grvMain.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            this.grvMain.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvMain.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.grvMain.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.grvMain.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvMain.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvMain.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            this.grvMain.Appearance.TopNewRow.Options.UseBackColor = true;
            this.grvMain.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.grvMain.Appearance.VertLine.Options.UseBackColor = true;
            this.grvMain.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
            this.grvMain.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.bandedGridColumn1,
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4,
            this.bandedGridColumn5});
            this.grvMain.GridControl = this.grcMain;
            this.grvMain.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Transport", null, "- Số xe: {0:0,0}")});
            this.grvMain.Name = "grvMain";
            this.grvMain.OptionsView.EnableAppearanceEvenRow = true;
            this.grvMain.OptionsView.EnableAppearanceOddRow = true;
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
            this.gridColumn2.Width = 42;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Biển số";
            this.gridColumn3.FieldName = "Code";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.Width = 61;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "ĐVVT";
            this.gridColumn4.FieldName = "Transport";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.Width = 156;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "Tuyến";
            this.bandedGridColumn1.FieldName = "Tariff";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 77;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "Nốt tài/tháng";
            this.bandedGridColumn2.FieldName = "Node";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 102;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ghế";
            this.gridColumn5.FieldName = "Seats";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.Width = 64;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Giường";
            this.gridColumn6.FieldName = "Beds";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.Width = 70;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "Lượt khách đi";
            this.bandedGridColumn3.FieldName = "Guest";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "T.gian vào";
            this.bandedGridColumn4.FieldName = "DateIn";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "Người cho vào";
            this.bandedGridColumn5.FieldName = "UserInName";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Visible = true;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Thông tin xe";
            this.gridBand1.Columns.Add(this.gridColumn1);
            this.gridBand1.Columns.Add(this.gridColumn2);
            this.gridBand1.Columns.Add(this.gridColumn3);
            this.gridBand1.Columns.Add(this.gridColumn4);
            this.gridBand1.Columns.Add(this.bandedGridColumn1);
            this.gridBand1.Columns.Add(this.bandedGridColumn2);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 438;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Tải trọng";
            this.gridBand2.Columns.Add(this.gridColumn5);
            this.gridBand2.Columns.Add(this.gridColumn6);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 134;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Thông tin vào";
            this.gridBand3.Columns.Add(this.bandedGridColumn5);
            this.gridBand3.Columns.Add(this.bandedGridColumn4);
            this.gridBand3.Columns.Add(this.bandedGridColumn3);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 225;
            // 
            // FrmTra_AuditMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(951, 566);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "FrmTra_AuditMonth";
            this.Text = "THEO DÕI THÁNG";
            this.Load += new System.EventHandler(this.FrmTra_Media_Load);
            this.Controls.SetChildIndex(this.dockPanel1, 0);
            this.Controls.SetChildIndex(this.dockPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.LabelControl lblNode;
        private DevExpress.XtraGrid.GridControl grcMain;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvMain;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private DevExpress.XtraEditors.TextEdit txtNode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
    }
}