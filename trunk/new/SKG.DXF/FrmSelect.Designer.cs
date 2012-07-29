namespace SKG.DXF
{
    partial class FrmSelect
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
            this.trlMain = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // trlMain
            // 
            this.trlMain.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn6});
            this.trlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlMain.Location = new System.Drawing.Point(0, 0);
            this.trlMain.Name = "trlMain";
            this.trlMain.OptionsView.ShowCheckBoxes = true;
            this.trlMain.Size = new System.Drawing.Size(494, 299);
            this.trlMain.TabIndex = 3;
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
            this.treeListColumn3.Caption = "Họ tên / Tên form, menuz";
            this.treeListColumn3.FieldName = "Caption";
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
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "Mã";
            this.treeListColumn6.FieldName = "Id";
            this.treeListColumn6.Name = "treeListColumn6";
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(12, 12);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "Tất cả";
            this.chkAll.Size = new System.Drawing.Size(70, 19);
            this.chkAll.TabIndex = 0;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::SKG.DXF.Properties.Resources.ok;
            this.btnSelect.Location = new System.Drawing.Point(326, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 36);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Chọn";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 54);
            this.panel1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::SKG.DXF.Properties.Resources.closex;
            this.btnCancel.Location = new System.Drawing.Point(407, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trlMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 299);
            this.panel2.TabIndex = 5;
            // 
            // FrmSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 353);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn dữ liệu";
            this.Load += new System.EventHandler(this.FrmSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList trlMain;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Panel panel2;
    }
}