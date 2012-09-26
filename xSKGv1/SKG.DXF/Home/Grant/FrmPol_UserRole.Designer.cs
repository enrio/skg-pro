namespace SKG.DXF.Home.Grant
{
    partial class FrmPol_UserRole
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
            this.ricSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.trlMain = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ricSelect
            // 
            this.ricSelect.AutoHeight = false;
            this.ricSelect.Name = "ricSelect";
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
            this.dockPanel1.ID = new System.Guid("b837e0c6-e6f3-40c6-86d5-f4668d486fd2");
            this.dockPanel1.Location = new System.Drawing.Point(0, 63);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(951, 200);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(943, 173);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("501f2f64-e5c4-41ad-bd19-c128490a6f54");
            this.dockPanel2.Location = new System.Drawing.Point(0, 263);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel2.Size = new System.Drawing.Size(951, 303);
            this.dockPanel2.Text = "dockPanel2";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.trlMain);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(943, 276);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // trlMain
            // 
            this.trlMain.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.trlMain.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.trlMain.Appearance.Empty.Options.UseBackColor = true;
            this.trlMain.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.trlMain.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.trlMain.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trlMain.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.trlMain.Appearance.EvenRow.Options.UseBackColor = true;
            this.trlMain.Appearance.EvenRow.Options.UseBorderColor = true;
            this.trlMain.Appearance.EvenRow.Options.UseFont = true;
            this.trlMain.Appearance.EvenRow.Options.UseForeColor = true;
            this.trlMain.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.trlMain.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.trlMain.Appearance.FocusedCell.Options.UseBackColor = true;
            this.trlMain.Appearance.FocusedCell.Options.UseForeColor = true;
            this.trlMain.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.trlMain.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.trlMain.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.trlMain.Appearance.FocusedRow.Options.UseBackColor = true;
            this.trlMain.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.trlMain.Appearance.FocusedRow.Options.UseForeColor = true;
            this.trlMain.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.trlMain.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.trlMain.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.trlMain.Appearance.FooterPanel.Options.UseBackColor = true;
            this.trlMain.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.trlMain.Appearance.FooterPanel.Options.UseForeColor = true;
            this.trlMain.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.trlMain.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.trlMain.Appearance.GroupButton.Options.UseBackColor = true;
            this.trlMain.Appearance.GroupButton.Options.UseBorderColor = true;
            this.trlMain.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.trlMain.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.trlMain.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.trlMain.Appearance.GroupFooter.Options.UseBackColor = true;
            this.trlMain.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.trlMain.Appearance.GroupFooter.Options.UseForeColor = true;
            this.trlMain.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.trlMain.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.trlMain.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.trlMain.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.trlMain.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.trlMain.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.trlMain.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.trlMain.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.trlMain.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.trlMain.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.trlMain.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.trlMain.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.trlMain.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.trlMain.Appearance.HorzLine.Options.UseBackColor = true;
            this.trlMain.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.trlMain.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.trlMain.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trlMain.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.trlMain.Appearance.OddRow.Options.UseBackColor = true;
            this.trlMain.Appearance.OddRow.Options.UseBorderColor = true;
            this.trlMain.Appearance.OddRow.Options.UseFont = true;
            this.trlMain.Appearance.OddRow.Options.UseForeColor = true;
            this.trlMain.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.trlMain.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.trlMain.Appearance.Preview.Options.UseFont = true;
            this.trlMain.Appearance.Preview.Options.UseForeColor = true;
            this.trlMain.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.trlMain.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.trlMain.Appearance.Row.Options.UseBackColor = true;
            this.trlMain.Appearance.Row.Options.UseForeColor = true;
            this.trlMain.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.trlMain.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.trlMain.Appearance.SelectedRow.Options.UseBackColor = true;
            this.trlMain.Appearance.SelectedRow.Options.UseForeColor = true;
            this.trlMain.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.trlMain.Appearance.TreeLine.Options.UseBackColor = true;
            this.trlMain.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.trlMain.Appearance.VertLine.Options.UseBackColor = true;
            this.trlMain.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4});
            this.trlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlMain.Location = new System.Drawing.Point(0, 0);
            this.trlMain.Name = "trlMain";
            this.trlMain.OptionsPrint.UsePrintStyles = true;
            this.trlMain.OptionsView.EnableAppearanceEvenRow = true;
            this.trlMain.OptionsView.EnableAppearanceOddRow = true;
            this.trlMain.OptionsView.ShowCheckBoxes = true;
            this.trlMain.Size = new System.Drawing.Size(943, 276);
            this.trlMain.TabIndex = 5;
            this.trlMain.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.trlMain_AfterCheckNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Format";
            this.treeListColumn1.FieldName = "Format";
            this.treeListColumn1.MinWidth = 32;
            this.treeListColumn1.Name = "treeListColumn1";
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "STT";
            this.treeListColumn2.FieldName = "No_";
            this.treeListColumn2.MinWidth = 32;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.ReadOnly = true;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "Nhóm / Họ tên";
            this.treeListColumn3.FieldName = "Name";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.ReadOnly = true;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 1;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "Mô tả";
            this.treeListColumn4.FieldName = "Descript";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.ReadOnly = true;
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 2;
            // 
            // FrmPol_UserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(951, 566);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "FrmPol_UserRole";
            this.Text = "Người dùng thuộc nhóm";
            this.Controls.SetChildIndex(this.dockPanel1, 0);
            this.Controls.SetChildIndex(this.dockPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ricSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraTreeList.TreeList trlMain;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ricSelect;
    }
}
