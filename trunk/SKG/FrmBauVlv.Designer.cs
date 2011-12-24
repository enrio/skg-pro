namespace SKG
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
            this.mskProId = new System.Windows.Forms.MaskedTextBox();
            this.cmdOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mskKey = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // mskProId
            // 
            this.mskProId.Location = new System.Drawing.Point(106, 12);
            this.mskProId.Name = "mskProId";
            this.mskProId.ReadOnly = true;
            this.mskProId.Size = new System.Drawing.Size(189, 20);
            this.mskProId.TabIndex = 1;
            this.mskProId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(301, 12);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(52, 46);
            this.cmdOk.TabIndex = 4;
            this.cmdOk.Text = "Đồ&ng ý";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sản phẩm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Khoá bản quyền:";
            // 
            // mskKey
            // 
            this.mskKey.Location = new System.Drawing.Point(106, 38);
            this.mskKey.Name = "mskKey";
            this.mskKey.Size = new System.Drawing.Size(189, 20);
            this.mskKey.TabIndex = 3;
            this.mskKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmBauVlv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 71);
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
            this.Text = "Đăng kí bản quyền phần mềm";
            this.Load += new System.EventHandler(this.FrmBauVlv_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mskProId;
        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskKey;
    }
}