namespace UTL.HSH
{
    partial class FrmBauVlv
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
            this.label2 = new System.Windows.Forms.Label();
            this.mskKey = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOk = new System.Windows.Forms.Button();
            this.mskProId = new System.Windows.Forms.MaskedTextBox();
            this.lblInf = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Khoá bản quyền:";
            // 
            // mskKey
            // 
            this.mskKey.Location = new System.Drawing.Point(106, 65);
            this.mskKey.Name = "mskKey";
            this.mskKey.Size = new System.Drawing.Size(189, 20);
            this.mskKey.TabIndex = 4;
            this.mskKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã sản phẩm:";
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(301, 39);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(55, 46);
            this.cmdOk.TabIndex = 5;
            this.cmdOk.Text = "Đồ&ng ý";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // mskProId
            // 
            this.mskProId.Location = new System.Drawing.Point(106, 39);
            this.mskProId.Name = "mskProId";
            this.mskProId.ReadOnly = true;
            this.mskProId.Size = new System.Drawing.Size(189, 20);
            this.mskProId.TabIndex = 2;
            this.mskProId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblInf
            // 
            this.lblInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInf.Location = new System.Drawing.Point(12, 9);
            this.lblInf.Name = "lblInf";
            this.lblInf.Size = new System.Drawing.Size(344, 27);
            this.lblInf.TabIndex = 0;
            this.lblInf.Text = "ĐĂNG KÍ BẢN QUYỀN PHẦN MỀM";
            this.lblInf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmBauVlv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 97);
            this.Controls.Add(this.lblInf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.mskProId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmBauVlv";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmBauVlv_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.MaskedTextBox mskKey;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.MaskedTextBox mskProId;
        public System.Windows.Forms.Label lblInf;
        protected System.Windows.Forms.Button cmdOk;
    }
}