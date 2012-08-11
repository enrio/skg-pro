namespace SKG.Reader
{
    partial class FrmTransfer
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
            this.tstMenu = new System.Windows.Forms.ToolStrip();
            this.cmdOpenExcel = new System.Windows.Forms.ToolStripButton();
            this.cboExcelSheet = new System.Windows.Forms.ToolStripComboBox();
            this.cmdLoadExcel = new System.Windows.Forms.ToolStripButton();
            this.cmdCopy2Sql = new System.Windows.Forms.ToolStripButton();
            this.cmdOpenSql = new System.Windows.Forms.ToolStripButton();
            this.cboSqlTable = new System.Windows.Forms.ToolStripComboBox();
            this.cmdLoadSql = new System.Windows.Forms.ToolStripButton();
            this.cmdCopy2Excel = new System.Windows.Forms.ToolStripButton();
            this.spcPanel = new System.Windows.Forms.SplitContainer();
            this.dgvExcel = new System.Windows.Forms.DataGridView();
            this.dgvSql = new System.Windows.Forms.DataGridView();
            this.tstMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcPanel)).BeginInit();
            this.spcPanel.Panel1.SuspendLayout();
            this.spcPanel.Panel2.SuspendLayout();
            this.spcPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSql)).BeginInit();
            this.SuspendLayout();
            // 
            // tstMenu
            // 
            this.tstMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdOpenExcel,
            this.cboExcelSheet,
            this.cmdLoadExcel,
            this.cmdCopy2Sql,
            this.cmdOpenSql,
            this.cboSqlTable,
            this.cmdLoadSql,
            this.cmdCopy2Excel});
            this.tstMenu.Location = new System.Drawing.Point(0, 0);
            this.tstMenu.Name = "tstMenu";
            this.tstMenu.Size = new System.Drawing.Size(987, 25);
            this.tstMenu.TabIndex = 0;
            this.tstMenu.Text = "Main menu";
            // 
            // cmdOpenExcel
            // 
            this.cmdOpenExcel.Image = global::SKG.Properties.Resources.openxls;
            this.cmdOpenExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdOpenExcel.Name = "cmdOpenExcel";
            this.cmdOpenExcel.Size = new System.Drawing.Size(81, 22);
            this.cmdOpenExcel.Text = "Open &Excel";
            this.cmdOpenExcel.Click += new System.EventHandler(this.cmdOpenExcel_Click);
            // 
            // cboExcelSheet
            // 
            this.cboExcelSheet.Name = "cboExcelSheet";
            this.cboExcelSheet.Size = new System.Drawing.Size(121, 25);
            this.cboExcelSheet.SelectedIndexChanged += new System.EventHandler(this.cboExcelSheet_SelectedIndexChanged);
            // 
            // cmdLoadExcel
            // 
            this.cmdLoadExcel.Image = global::SKG.Properties.Resources.xls;
            this.cmdLoadExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLoadExcel.Name = "cmdLoadExcel";
            this.cmdLoadExcel.Size = new System.Drawing.Size(78, 22);
            this.cmdLoadExcel.Text = "Load E&xcel";
            this.cmdLoadExcel.Click += new System.EventHandler(this.cmdLoadExcel_Click);
            // 
            // cmdCopy2Sql
            // 
            this.cmdCopy2Sql.Image = global::SKG.Properties.Resources.copy;
            this.cmdCopy2Sql.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCopy2Sql.Name = "cmdCopy2Sql";
            this.cmdCopy2Sql.Size = new System.Drawing.Size(82, 22);
            this.cmdCopy2Sql.Text = "&Copy to Sql";
            this.cmdCopy2Sql.Click += new System.EventHandler(this.cmdCopy2Sql_Click);
            // 
            // cmdOpenSql
            // 
            this.cmdOpenSql.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmdOpenSql.Image = global::SKG.Properties.Resources.opensql;
            this.cmdOpenSql.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdOpenSql.Name = "cmdOpenSql";
            this.cmdOpenSql.Size = new System.Drawing.Size(70, 22);
            this.cmdOpenSql.Text = "Open &Sql";
            this.cmdOpenSql.Click += new System.EventHandler(this.cmdOpenSql_Click);
            // 
            // cboSqlTable
            // 
            this.cboSqlTable.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cboSqlTable.Name = "cboSqlTable";
            this.cboSqlTable.Size = new System.Drawing.Size(121, 25);
            this.cboSqlTable.SelectedIndexChanged += new System.EventHandler(this.cboSqlTable_SelectedIndexChanged);
            // 
            // cmdLoadSql
            // 
            this.cmdLoadSql.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmdLoadSql.Image = global::SKG.Properties.Resources.sql;
            this.cmdLoadSql.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdLoadSql.Name = "cmdLoadSql";
            this.cmdLoadSql.Size = new System.Drawing.Size(67, 22);
            this.cmdLoadSql.Text = "L&oad Sql";
            this.cmdLoadSql.Click += new System.EventHandler(this.cmdLoadSql_Click);
            // 
            // cmdCopy2Excel
            // 
            this.cmdCopy2Excel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmdCopy2Excel.Image = global::SKG.Properties.Resources.copy;
            this.cmdCopy2Excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCopy2Excel.Name = "cmdCopy2Excel";
            this.cmdCopy2Excel.Size = new System.Drawing.Size(93, 22);
            this.cmdCopy2Excel.Text = "Copy &to Excel";
            // 
            // spcPanel
            // 
            this.spcPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcPanel.Location = new System.Drawing.Point(0, 25);
            this.spcPanel.Name = "spcPanel";
            // 
            // spcPanel.Panel1
            // 
            this.spcPanel.Panel1.Controls.Add(this.dgvExcel);
            // 
            // spcPanel.Panel2
            // 
            this.spcPanel.Panel2.Controls.Add(this.dgvSql);
            this.spcPanel.Size = new System.Drawing.Size(987, 466);
            this.spcPanel.SplitterDistance = 471;
            this.spcPanel.TabIndex = 1;
            // 
            // dgvExcel
            // 
            this.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExcel.Location = new System.Drawing.Point(0, 0);
            this.dgvExcel.Name = "dgvExcel";
            this.dgvExcel.RowHeadersVisible = false;
            this.dgvExcel.Size = new System.Drawing.Size(471, 466);
            this.dgvExcel.TabIndex = 0;
            // 
            // dgvSql
            // 
            this.dgvSql.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSql.Location = new System.Drawing.Point(0, 0);
            this.dgvSql.Name = "dgvSql";
            this.dgvSql.RowHeadersVisible = false;
            this.dgvSql.Size = new System.Drawing.Size(512, 466);
            this.dgvSql.TabIndex = 1;
            // 
            // FrmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 491);
            this.Controls.Add(this.spcPanel);
            this.Controls.Add(this.tstMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer data";
            this.Load += new System.EventHandler(this.frmTransfer_Load);
            this.tstMenu.ResumeLayout(false);
            this.tstMenu.PerformLayout();
            this.spcPanel.Panel1.ResumeLayout(false);
            this.spcPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcPanel)).EndInit();
            this.spcPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSql)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tstMenu;
        private System.Windows.Forms.ToolStripButton cmdOpenExcel;
        private System.Windows.Forms.ToolStripComboBox cboExcelSheet;
        private System.Windows.Forms.ToolStripButton cmdLoadExcel;
        private System.Windows.Forms.ToolStripButton cmdCopy2Sql;
        private System.Windows.Forms.ToolStripButton cmdOpenSql;
        private System.Windows.Forms.ToolStripComboBox cboSqlTable;
        private System.Windows.Forms.ToolStripButton cmdLoadSql;
        private System.Windows.Forms.ToolStripButton cmdCopy2Excel;
        private System.Windows.Forms.SplitContainer spcPanel;
        private System.Windows.Forms.DataGridView dgvExcel;
        private System.Windows.Forms.DataGridView dgvSql;
    }
}