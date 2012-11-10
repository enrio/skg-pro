namespace SKG.DXF.Home.Catalog
{
    partial class FrmPol_Dictionary
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
            this.lblBelong = new DevExpress.XtraEditors.LabelControl();
            this.lokBelong = new DevExpress.XtraEditors.LookUpEdit();
            this.txtNote = new DevExpress.XtraEditors.TextEdit();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.txtText = new DevExpress.XtraEditors.TextEdit();
            this.lblText = new DevExpress.XtraEditors.LabelControl();
            this.lokList = new DevExpress.XtraEditors.LookUpEdit();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.grcMain = new DevExpress.XtraGrid.GridControl();
            this.grvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lokBelong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokList.Properties)).BeginInit();
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
            this.dockPanel1.ID = new System.Guid("79ec1f5d-51c0-407c-9e7e-4af54225b6f5");
            this.dockPanel1.Location = new System.Drawing.Point(0, 63);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 61);
            this.dockPanel1.Size = new System.Drawing.Size(951, 61);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.lblBelong);
            this.dockPanel1_Container.Controls.Add(this.lokBelong);
            this.dockPanel1_Container.Controls.Add(this.txtNote);
            this.dockPanel1_Container.Controls.Add(this.lblNote);
            this.dockPanel1_Container.Controls.Add(this.txtText);
            this.dockPanel1_Container.Controls.Add(this.lblText);
            this.dockPanel1_Container.Controls.Add(this.lokList);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(943, 34);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // lblBelong
            // 
            this.lblBelong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBelong.Location = new System.Drawing.Point(693, 6);
            this.lblBelong.Name = "lblBelong";
            this.lblBelong.Size = new System.Drawing.Size(50, 19);
            this.lblBelong.TabIndex = 7;
            this.lblBelong.Text = "Thuộc:";
            // 
            // lokBelong
            // 
            this.lokBelong.EditValue = 0;
            this.lokBelong.Location = new System.Drawing.Point(749, 3);
            this.lokBelong.Name = "lokBelong";
            this.lokBelong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lokBelong.Properties.Appearance.Options.UseFont = true;
            this.lokBelong.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lokBelong.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lokBelong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokBelong.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("No_", "STT", 10, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Danh sách")});
            this.lokBelong.Properties.DisplayMember = "Text";
            this.lokBelong.Properties.ShowHeader = false;
            this.lokBelong.Properties.ValueMember = "Id";
            this.lokBelong.Size = new System.Drawing.Size(191, 26);
            this.lokBelong.TabIndex = 8;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(492, 3);
            this.txtNote.Name = "txtNote";
            this.txtNote.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Properties.Appearance.Options.UseFont = true;
            this.txtNote.Size = new System.Drawing.Size(195, 26);
            this.txtNote.TabIndex = 7;
            // 
            // lblNote
            // 
            this.lblNote.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(426, 6);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(60, 19);
            this.lblNote.TabIndex = 6;
            this.lblNote.Text = "Ghi chú:";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(234, 3);
            this.txtText.Name = "txtText";
            this.txtText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Properties.Appearance.Options.UseFont = true;
            this.txtText.Size = new System.Drawing.Size(179, 26);
            this.txtText.TabIndex = 2;
            // 
            // lblText
            // 
            this.lblText.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(195, 6);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(33, 19);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Tên:";
            // 
            // lokList
            // 
            this.lokList.EditValue = 0;
            this.lokList.Location = new System.Drawing.Point(3, 3);
            this.lokList.Name = "lokList";
            this.lokList.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lokList.Properties.Appearance.Options.UseFont = true;
            this.lokList.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lokList.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lokList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokList.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("No_", "STT", 10, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Danh sách")});
            this.lokList.Properties.DisplayMember = "Text";
            this.lokList.Properties.ShowHeader = false;
            this.lokList.Properties.ValueMember = "Code";
            this.lokList.Size = new System.Drawing.Size(186, 26);
            this.lokList.TabIndex = 0;
            this.lokList.EditValueChanged += new System.EventHandler(this.lokList_EditValueChanged);
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("2c47a7f7-fe20-4cc7-a88d-5a8b9d15c589");
            this.dockPanel2.Location = new System.Drawing.Point(0, 124);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(951, 200);
            this.dockPanel2.Size = new System.Drawing.Size(951, 442);
            this.dockPanel2.Text = "dockPanel2";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.grcMain);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(943, 415);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // grcMain
            // 
            this.grcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcMain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcMain.Location = new System.Drawing.Point(0, 0);
            this.grcMain.MainView = this.grvMain;
            this.grcMain.Name = "grcMain";
            this.grcMain.Size = new System.Drawing.Size(943, 415);
            this.grcMain.TabIndex = 0;
            this.grcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMain});
            // 
            // grvMain
            // 
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
            this.grvMain.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 12F);
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
            this.grvMain.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvMain.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvMain.Appearance.FocusedRow.Options.UseBorderColor = true;
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
            this.grvMain.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvMain.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvMain.Appearance.GroupRow.Options.UseBorderColor = true;
            this.grvMain.Appearance.GroupRow.Options.UseFont = true;
            this.grvMain.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvMain.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.grvMain.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.grvMain.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.grvMain.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.grvMain.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMain.Appearance.HeaderPanel.Options.UseForeColor = true;
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
            this.grvMain.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 12F);
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
            this.grvMain.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
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
            this.grvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.grvMain.GridControl = this.grcMain;
            this.grvMain.Name = "grvMain";
            this.grvMain.OptionsView.EnableAppearanceEvenRow = true;
            this.grvMain.OptionsView.EnableAppearanceOddRow = true;
            this.grvMain.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grvMain_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "STT";
            this.gridColumn1.FieldName = "No_";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 38;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên";
            this.gridColumn2.FieldName = "Text";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 522;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ghi chú";
            this.gridColumn3.FieldName = "Note";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 525;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Thuộc";
            this.gridColumn4.FieldName = "Belong";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 89;
            // 
            // FrmPol_Dictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(951, 566);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "FrmPol_Dictionary";
            this.Load += new System.EventHandler(this.FrmPol_Dictionary_Load);
            this.Controls.SetChildIndex(this.dockPanel1, 0);
            this.Controls.SetChildIndex(this.dockPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lokBelong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokList.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Views.Grid.GridView grvMain;
        private DevExpress.XtraEditors.LookUpEdit lokList;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.TextEdit txtNote;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraEditors.TextEdit txtText;
        private DevExpress.XtraEditors.LabelControl lblText;
        private DevExpress.XtraEditors.LabelControl lblBelong;
        private DevExpress.XtraEditors.LookUpEdit lokBelong;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}
