namespace SKG.DXF.Home.Sytem
{
    partial class FrmPol_Connection
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
            this.components = new System.ComponentModel.Container();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tmrMain
            // 
            this.tmrMain.Enabled = true;
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(140, 42);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPol_Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(162, 63);
            this.ControlBox = false;
            this.Controls.Add(this.lblInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPol_Connection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết nối máy chủ ...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Label lblInfo;

    }
}