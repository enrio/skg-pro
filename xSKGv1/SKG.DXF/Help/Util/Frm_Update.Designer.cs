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
            this.lblVersion = new DevExpress.XtraEditors.LabelControl();
            this.cmdUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(119, 56);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(36, 13);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "0.0.0.0";
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(70, 136);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(117, 38);
            this.cmdUpdate.TabIndex = 1;
            this.cmdUpdate.Text = "&Cập nhật";
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // Frm_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.lblVersion);
            this.Name = "Frm_Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblVersion;
        private DevExpress.XtraEditors.SimpleButton cmdUpdate;
    }
}