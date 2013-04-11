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
            this.sccMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.ckbAutoUpdate = new DevExpress.XtraEditors.CheckButton();
            this.cbbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dteDay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sccContent = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).BeginInit();
            this.sccMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccContent)).BeginInit();
            this.sccContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // sccMain
            // 
            this.sccMain.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.sccMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.sccMain.Horizontal = false;
            this.sccMain.Location = new System.Drawing.Point(0, 63);
            this.sccMain.Name = "sccMain";
            this.sccMain.Panel1.Controls.Add(this.ckbAutoUpdate);
            this.sccMain.Panel1.Controls.Add(this.cbbType);
            this.sccMain.Panel1.Controls.Add(this.labelControl2);
            this.sccMain.Panel1.Controls.Add(this.dteDay);
            this.sccMain.Panel1.Controls.Add(this.labelControl1);
            this.sccMain.Panel1.Text = "Panel1";
            this.sccMain.Panel2.Controls.Add(this.sccContent);
            this.sccMain.Panel2.Text = "Panel2";
            this.sccMain.Size = new System.Drawing.Size(593, 336);
            this.sccMain.SplitterPosition = 28;
            this.sccMain.TabIndex = 7;
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
            this.cbbType.EditValueChanged += new System.EventHandler(this.cbbType_SelectedIndexChanged);
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
            this.sccContent.Size = new System.Drawing.Size(593, 303);
            this.sccContent.SplitterPosition = 294;
            this.sccContent.TabIndex = 0;
            this.sccContent.Text = "splitContainerControl1";
            // 
            // FrmTra_Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(593, 399);
            this.Controls.Add(this.sccMain);
            this.Name = "FrmTra_Sales";
            this.Load += new System.EventHandler(this.FrmTra_Sales_Load);
            this.Controls.SetChildIndex(this.sccMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).EndInit();
            this.sccMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccContent)).EndInit();
            this.sccContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl sccMain;
        private DevExpress.XtraEditors.CheckButton ckbAutoUpdate;
        private DevExpress.XtraEditors.ComboBoxEdit cbbType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dteDay;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SplitContainerControl sccContent;
    }
}