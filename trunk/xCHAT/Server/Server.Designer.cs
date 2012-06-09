namespace Server
{
    partial class Server
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fsfsafToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sdsfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fdsadfsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.tabStrip1 = new DevComponents.DotNetBar.TabStrip();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fsfsafToolStripMenuItem,
            this.fdsadfsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(445, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fsfsafToolStripMenuItem
            // 
            this.fsfsafToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sdsfToolStripMenuItem});
            this.fsfsafToolStripMenuItem.Name = "fsfsafToolStripMenuItem";
            this.fsfsafToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.fsfsafToolStripMenuItem.Text = "fsfsaf";
            // 
            // sdsfToolStripMenuItem
            // 
            this.sdsfToolStripMenuItem.Name = "sdsfToolStripMenuItem";
            this.sdsfToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sdsfToolStripMenuItem.Text = "sdsf";
            this.sdsfToolStripMenuItem.Click += new System.EventHandler(this.sdsfToolStripMenuItem_Click);
            // 
            // fdsadfsToolStripMenuItem
            // 
            this.fdsadfsToolStripMenuItem.Name = "fdsadfsToolStripMenuItem";
            this.fdsadfsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.fdsadfsToolStripMenuItem.Text = "fdsadfs";
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxControl1.Location = new System.Drawing.Point(307, 24);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(138, 314);
            this.listBoxControl1.TabIndex = 9;
            // 
            // tabStrip1
            // 
            this.tabStrip1.AutoSelectAttachedControl = true;
            this.tabStrip1.CanReorderTabs = true;
            this.tabStrip1.CloseButtonOnTabsVisible = true;
            this.tabStrip1.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabStrip1.CloseButtonVisible = true;
            this.tabStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabStrip1.Location = new System.Drawing.Point(0, 24);
            this.tabStrip1.MdiForm = this;
            this.tabStrip1.MdiTabbedDocuments = true;
            this.tabStrip1.Name = "tabStrip1";
            this.tabStrip1.SelectedTab = null;
            this.tabStrip1.Size = new System.Drawing.Size(307, 23);
            this.tabStrip1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Dock;
            this.tabStrip1.TabIndex = 10;
            this.tabStrip1.Text = "tabStrip1";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 338);
            this.Controls.Add(this.tabStrip1);
            this.Controls.Add(this.listBoxControl1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Server";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Server_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fsfsafToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sdsfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fdsadfsToolStripMenuItem;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevComponents.DotNetBar.TabStrip tabStrip1;
       








    }
}