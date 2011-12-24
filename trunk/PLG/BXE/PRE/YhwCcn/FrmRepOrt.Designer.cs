namespace BXE.PRE.YhwCcn
{
    partial class FrmRepOrt
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bdsSumary = new System.Windows.Forms.BindingSource(this.components);
            this.rptAep = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSumary)).BeginInit();
            this.SuspendLayout();
            // 
            // bdsSumary
            // 
            this.bdsSumary.DataMember = "Sumary";
            // 
            // rptAep
            // 
            this.rptAep.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DtsRevenue";
            reportDataSource1.Value = this.bdsSumary;
            this.rptAep.LocalReport.DataSources.Add(reportDataSource1);
            this.rptAep.LocalReport.ReportEmbeddedResource = "BXE.PRE.YhwCcn.RptDbbYii.rdlc";
            this.rptAep.Location = new System.Drawing.Point(0, 0);
            this.rptAep.Name = "rptAep";
            this.rptAep.Size = new System.Drawing.Size(546, 426);
            this.rptAep.TabIndex = 0;
            // 
            // FrmRepOrt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 426);
            this.Controls.Add(this.rptAep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRepOrt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo thống kê";
            this.Load += new System.EventHandler(this.FrmRepOrt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdsSumary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptAep;
        private System.Windows.Forms.BindingSource bdsSumary;
    }
}