﻿namespace SKG.MSF
{
    partial class FrmMain
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.staMain = new System.Windows.Forms.StatusStrip();
            this.tmrMain = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(762, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // staMain
            // 
            this.staMain.Location = new System.Drawing.Point(0, 413);
            this.staMain.Name = "staMain";
            this.staMain.Size = new System.Drawing.Size(762, 22);
            this.staMain.TabIndex = 2;
            this.staMain.Text = "statusStrip1";
            // 
            // tmrMain
            // 
            this.tmrMain.Enabled = true;
            this.tmrMain.Interval = 1000;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 435);
            this.Controls.Add(this.staMain);
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "...:: SKG ::...";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.StatusStrip staMain;
        private System.Windows.Forms.Timer tmrMain;
    }
}