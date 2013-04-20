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
            this.rdgDayMonth = new DevExpress.XtraEditors.RadioGroup();
            this.ckbAutoUpdate = new DevExpress.XtraEditors.CheckButton();
            this.cbbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dteDayMonth = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sccContent = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).BeginInit();
            this.sccMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgDayMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDayMonth.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDayMonth.Properties)).BeginInit();
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
            this.sccMain.Panel1.Controls.Add(this.rdgDayMonth);
            this.sccMain.Panel1.Controls.Add(this.ckbAutoUpdate);
            this.sccMain.Panel1.Controls.Add(this.cbbType);
            this.sccMain.Panel1.Controls.Add(this.labelControl2);
            this.sccMain.Panel1.Controls.Add(this.dteDayMonth);
            this.sccMain.Panel1.Controls.Add(this.labelControl1);
            this.sccMain.Panel1.Text = "Panel1";
            this.sccMain.Panel2.Controls.Add(this.sccContent);
            this.sccMain.Panel2.Text = "Panel2";
            this.sccMain.Size = new System.Drawing.Size(644, 366);
            this.sccMain.SplitterPosition = 29;
            this.sccMain.TabIndex = 6;
            this.sccMain.Text = "splitContainerControl1";
            // 
            // rdgDayMonth
            // 
            this.rdgDayMonth.EditValue = 'D';
            this.rdgDayMonth.Location = new System.Drawing.Point(176, 6);
            this.rdgDayMonth.Name = "rdgDayMonth";
            this.rdgDayMonth.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rdgDayMonth.Properties.Appearance.Options.UseBackColor = true;
            this.rdgDayMonth.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem('D', "Ngày"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem('M', "Tháng"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem('Y', "Năm")});
            this.rdgDayMonth.Size = new System.Drawing.Size(158, 23);
            this.rdgDayMonth.TabIndex = 2;
            this.rdgDayMonth.SelectedIndexChanged += new System.EventHandler(this.rdgDayMonth_SelectedIndexChanged);
            // 
            // ckbAutoUpdate
            // 
            this.ckbAutoUpdate.Location = new System.Drawing.Point(534, 6);
            this.ckbAutoUpdate.Name = "ckbAutoUpdate";
            this.ckbAutoUpdate.Size = new System.Drawing.Size(98, 23);
            this.ckbAutoUpdate.TabIndex = 5;
            this.ckbAutoUpdate.Text = "Tự động cập nhật";
            this.ckbAutoUpdate.CheckedChanged += new System.EventHandler(this.ckbAutoUpdate_CheckedChanged);
            // 
            // cbbType
            // 
            this.cbbType.EditValue = "Theo cố định, vãng lai";
            this.cbbType.Location = new System.Drawing.Point(395, 8);
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
            "Theo cố định, vãng lai",
            "Theo ngày trong tháng",
            "Theo tháng trong năm"});
            this.cbbType.Size = new System.Drawing.Size(133, 20);
            this.cbbType.TabIndex = 4;
            this.cbbType.EditValueChanged += new System.EventHandler(this.cbbType_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(340, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 23);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Kiểu xem";
            // 
            // dteDayMonth
            // 
            this.dteDayMonth.EditValue = null;
            this.dteDayMonth.Location = new System.Drawing.Point(60, 8);
            this.dteDayMonth.Name = "dteDayMonth";
            this.dteDayMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDayMonth.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dteDayMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteDayMonth.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dteDayMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteDayMonth.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteDayMonth.Size = new System.Drawing.Size(110, 20);
            this.dteDayMonth.TabIndex = 1;
            this.dteDayMonth.EditValueChanged += new System.EventHandler(this.dteDayMonth_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(3, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 23);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Thời gian";
            // 
            // sccContent
            // 
            this.sccContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccContent.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.sccContent.Location = new System.Drawing.Point(0, 0);
            this.sccContent.Name = "sccContent";
            this.sccContent.Panel1.Text = "Panel1";
            this.sccContent.Panel2.Text = "Panel2";
            this.sccContent.Size = new System.Drawing.Size(644, 332);
            this.sccContent.SplitterPosition = 319;
            this.sccContent.TabIndex = 7;
            this.sccContent.Text = "splitContainerControl1";
            // 
            // FrmTra_Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(644, 429);
            this.Controls.Add(this.sccMain);
            this.Name = "FrmTra_Sales";
            this.Load += new System.EventHandler(this.FrmTra_Sales_Load);
            this.Controls.SetChildIndex(this.sccMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).EndInit();
            this.sccMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdgDayMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDayMonth.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDayMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccContent)).EndInit();
            this.sccContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl sccMain;
        private DevExpress.XtraEditors.CheckButton ckbAutoUpdate;
        private DevExpress.XtraEditors.ComboBoxEdit cbbType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dteDayMonth;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SplitContainerControl sccContent;
        private DevExpress.XtraEditors.RadioGroup rdgDayMonth;
    }
}