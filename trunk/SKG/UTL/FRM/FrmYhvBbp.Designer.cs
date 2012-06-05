namespace UTL.FRM
{
    partial class FrmYhvBbp
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
            this.lblInfor = new System.Windows.Forms.Label();
            this.cmdOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInfor
            // 
            this.lblInfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfor.Location = new System.Drawing.Point(12, 9);
            this.lblInfor.Name = "lblInfor";
            this.lblInfor.Size = new System.Drawing.Size(268, 56);
            this.lblInfor.TabIndex = 0;
            this.lblInfor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(120, 75);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(52, 30);
            this.cmdOk.TabIndex = 1;
            this.cmdOk.Text = "&OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // FrmYhvBbp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 118);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.lblInfor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmYhvBbp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmYhvBbp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInfor;
        private System.Windows.Forms.Button cmdOk;
    }
}