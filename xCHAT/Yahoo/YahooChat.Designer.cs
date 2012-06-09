namespace Yahoo
{
    partial class YahooChat
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btDangNhap = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.tabStrip1 = new DevComponents.DotNetBar.TabStrip();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fsfsafToolStripMenuItem,
            this.fdsadfsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(500, 24);
            this.menuStrip1.TabIndex = 2;
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
            this.sdsfToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.sdsfToolStripMenuItem.Text = "sdsf";
            // 
            // fdsadfsToolStripMenuItem
            // 
            this.fdsadfsToolStripMenuItem.Name = "fdsadfsToolStripMenuItem";
            this.fdsadfsToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.fdsadfsToolStripMenuItem.Text = "fdsadfs";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtYID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btDangNhap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 93);
            this.panel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(288, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 29);
            this.button2.TabIndex = 5;
            this.button2.Text = "Đăng Xuất";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(81, 48);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(173, 20);
            this.txtPass.TabIndex = 4;
            this.txtPass.Text = "dth061088";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pass:";
            // 
            // txtYID
            // 
            this.txtYID.Location = new System.Drawing.Point(81, 9);
            this.txtYID.Name = "txtYID";
            this.txtYID.Size = new System.Drawing.Size(173, 22);
            this.txtYID.TabIndex = 2;
            this.txtYID.Text = "nvhau2135";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "YahooID:";
            // 
            // btDangNhap
            // 
            this.btDangNhap.Location = new System.Drawing.Point(288, 3);
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.Size = new System.Drawing.Size(87, 29);
            this.btDangNhap.TabIndex = 0;
            this.btDangNhap.Text = "Đăng Nhập";
            this.btDangNhap.UseVisualStyleBackColor = true;
            this.btDangNhap.Click += new System.EventHandler(this.btDangNhap_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(287, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 408);
            this.panel2.TabIndex = 15;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 29);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(213, 379);
            this.treeView1.TabIndex = 14;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 29);
            this.button1.TabIndex = 13;
            this.button1.Text = "Dan sách liên hệ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl1.Location = new System.Drawing.Point(282, 117);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 408);
            this.splitterControl1.TabIndex = 17;
            this.splitterControl1.TabStop = false;
            // 
            // tabStrip1
            // 
            this.tabStrip1.AutoSelectAttachedControl = true;
            this.tabStrip1.CanReorderTabs = true;
            this.tabStrip1.CloseButtonOnTabsVisible = true;
            this.tabStrip1.CloseButtonPosition = DevComponents.DotNetBar.eTabCloseButtonPosition.Right;
            this.tabStrip1.CloseButtonVisible = true;
            this.tabStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabStrip1.Location = new System.Drawing.Point(0, 117);
            this.tabStrip1.MdiForm = this;
            this.tabStrip1.MdiTabbedDocuments = true;
            this.tabStrip1.Name = "tabStrip1";
            this.tabStrip1.SelectedTab = null;
            this.tabStrip1.ShowMdiChildIcon = false;
            this.tabStrip1.Size = new System.Drawing.Size(282, 29);
            this.tabStrip1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Dock;
            this.tabStrip1.TabIndex = 18;
            this.tabStrip1.Text = "tabStrip1";
            // 
            // YahooChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 525);
            this.Controls.Add(this.tabStrip1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Name = "YahooChat";
            this.Text = "YahooChat";
            this.Load += new System.EventHandler(this.YahooChat_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fsfsafToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sdsfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fdsadfsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDangNhap;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYID;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevComponents.DotNetBar.TabStrip tabStrip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;

    }
}