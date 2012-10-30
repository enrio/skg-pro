namespace SKG.DXF.Help.Util
{
    partial class Frm_Update
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
            this.cmdUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.prbUpdate = new System.Windows.Forms.ProgressBar();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdUpdate.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.cmdUpdate.Appearance.Options.UseFont = true;
            this.cmdUpdate.Appearance.Options.UseForeColor = true;
            this.cmdUpdate.Location = new System.Drawing.Point(219, 12);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(76, 30);
            this.cmdUpdate.TabIndex = 0;
            this.cmdUpdate.Text = "&Cập nhật";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 49);
            this.label1.TabIndex = 2;
            this.label1.Text = "QUẢN LÍ XE RA/VÀO BẾN XE NGÃ TƯ GA - TP.HCM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prbUpdate
            // 
            this.prbUpdate.Location = new System.Drawing.Point(12, 61);
            this.prbUpdate.Name = "prbUpdate";
            this.prbUpdate.Size = new System.Drawing.Size(283, 14);
            this.prbUpdate.TabIndex = 4;
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.EditValue = "https://skg-pro.googlecode.com/svn/trunk/Update.zip";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(12, 81);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Size = new System.Drawing.Size(283, 20);
            this.hyperLinkEdit1.TabIndex = 5;
            // 
            // Frm_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(307, 111);
            this.Controls.Add(this.hyperLinkEdit1);
            this.Controls.Add(this.prbUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật phần mềm";
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cmdUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar prbUpdate;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
    }
}
