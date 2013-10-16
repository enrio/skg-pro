namespace SKG.DXF.Station
{
    partial class FrmRevenueNormal
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
            this.cmdNormal1 = new DevExpress.XtraEditors.SimpleButton();
            this.cmdNormal2 = new DevExpress.XtraEditors.SimpleButton();
            this.cmdNormal3 = new DevExpress.XtraEditors.SimpleButton();
            this.cmdReport = new DevExpress.XtraEditors.SimpleButton();
            this.lblInfo = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // cmdNormal1
            // 
            this.cmdNormal1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdNormal1.Location = new System.Drawing.Point(12, 34);
            this.cmdNormal1.Name = "cmdNormal1";
            this.cmdNormal1.Size = new System.Drawing.Size(102, 31);
            this.cmdNormal1.TabIndex = 1;
            this.cmdNormal1.Text = "XE &TẢI LƯU ĐẬU";
            // 
            // cmdNormal2
            // 
            this.cmdNormal2.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.cmdNormal2.Location = new System.Drawing.Point(120, 34);
            this.cmdNormal2.Name = "cmdNormal2";
            this.cmdNormal2.Size = new System.Drawing.Size(102, 31);
            this.cmdNormal2.TabIndex = 2;
            this.cmdNormal2.Text = "XE &SANG HÀNG";
            // 
            // cmdNormal3
            // 
            this.cmdNormal3.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cmdNormal3.Location = new System.Drawing.Point(12, 71);
            this.cmdNormal3.Name = "cmdNormal3";
            this.cmdNormal3.Size = new System.Drawing.Size(102, 31);
            this.cmdNormal3.TabIndex = 3;
            this.cmdNormal3.Text = "XE &VÃNG LAI";
            // 
            // cmdReport
            // 
            this.cmdReport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdReport.Location = new System.Drawing.Point(120, 71);
            this.cmdReport.Name = "cmdReport";
            this.cmdReport.Size = new System.Drawing.Size(102, 31);
            this.cmdReport.TabIndex = 4;
            this.cmdReport.Text = "&BÁO CÁO";
            // 
            // lblInfo
            // 
            this.lblInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInfo.Location = new System.Drawing.Point(12, 12);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(210, 16);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "CHỌN IN BẢNG KÊ VÀ BÁO CÁO";
            // 
            // FrmRevenueNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 112);
            this.ControlBox = false;
            this.Controls.Add(this.cmdReport);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.cmdNormal3);
            this.Controls.Add(this.cmdNormal2);
            this.Controls.Add(this.cmdNormal1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRevenueNormal";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In bảng kê và báo cáo xe lưu đậu";
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton cmdNormal1;
        public DevExpress.XtraEditors.SimpleButton cmdNormal2;
        public DevExpress.XtraEditors.SimpleButton cmdNormal3;
        public DevExpress.XtraEditors.SimpleButton cmdReport;
        public DevExpress.XtraEditors.LabelControl lblInfo;
    }
}