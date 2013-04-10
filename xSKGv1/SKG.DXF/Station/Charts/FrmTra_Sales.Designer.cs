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
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).BeginInit();
            this.sccMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // sccMain
            // 
            this.sccMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccMain.Location = new System.Drawing.Point(0, 63);
            this.sccMain.Name = "sccMain";
            this.sccMain.Panel1.Text = "Panel1";
            this.sccMain.Panel2.Text = "Panel2";
            this.sccMain.Size = new System.Drawing.Size(292, 203);
            this.sccMain.SplitterPosition = 143;
            this.sccMain.TabIndex = 4;
            this.sccMain.Text = "splitContainerControl1";
            // 
            // FrmTra_Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.sccMain);
            this.Name = "FrmTra_Sales";
            this.Load += new System.EventHandler(this.FrmTra_Sales_Load);
            this.Controls.SetChildIndex(this.sccMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this._dtb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sccMain)).EndInit();
            this.sccMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl sccMain;

    }
}