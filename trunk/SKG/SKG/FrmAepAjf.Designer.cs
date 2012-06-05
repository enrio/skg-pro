namespace SKG
{
    partial class FrmAepAjf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAepAjf));
            this.mnuAep = new System.Windows.Forms.MenuStrip();
            this.mnuSys = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCbuHeq = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSys_00 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSboLii = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUilHga = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDsa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTke = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBca = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHeo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSiqDkc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBauVlv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHeo_00 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuYhvTeo = new System.Windows.Forms.ToolStripMenuItem();
            this.staAep = new System.Windows.Forms.StatusStrip();
            this.staFawObj = new System.Windows.Forms.ToolStripStatusLabel();
            this.staMbzAil = new System.Windows.Forms.ToolStripStatusLabel();
            this.staYcpDar = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrFhvHfj = new System.Windows.Forms.Timer(this.components);
            this.mnuAep.SuspendLayout();
            this.staAep.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuAep
            // 
            this.mnuAep.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSys,
            this.mnuDsa,
            this.mnuTke,
            this.mnuBca,
            this.mnuHeo});
            this.mnuAep.Location = new System.Drawing.Point(0, 0);
            this.mnuAep.Name = "mnuAep";
            this.mnuAep.Size = new System.Drawing.Size(639, 24);
            this.mnuAep.TabIndex = 1;
            this.mnuAep.Text = "menuStrip1";
            // 
            // mnuSys
            // 
            this.mnuSys.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCbuHeq,
            this.mnuSys_00,
            this.mnuSboLii,
            this.mnuUilHga});
            this.mnuSys.Name = "mnuSys";
            this.mnuSys.Size = new System.Drawing.Size(63, 20);
            this.mnuSys.Text = "&Hệ thống";
            this.mnuSys.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuSys_DropDownItemClicked);
            // 
            // mnuCbuHeq
            // 
            this.mnuCbuHeq.Enabled = false;
            this.mnuCbuHeq.Name = "mnuCbuHeq";
            this.mnuCbuHeq.Size = new System.Drawing.Size(127, 22);
            this.mnuCbuHeq.Text = "&Cấu hình";
            this.mnuCbuHeq.Click += new System.EventHandler(this.mnuCbuHeq_Click);
            // 
            // mnuSys_00
            // 
            this.mnuSys_00.Name = "mnuSys_00";
            this.mnuSys_00.Size = new System.Drawing.Size(124, 6);
            // 
            // mnuSboLii
            // 
            this.mnuSboLii.Enabled = false;
            this.mnuSboLii.Name = "mnuSboLii";
            this.mnuSboLii.Size = new System.Drawing.Size(127, 22);
            this.mnuSboLii.Text = "&Sao lưu";
            // 
            // mnuUilHga
            // 
            this.mnuUilHga.Enabled = false;
            this.mnuUilHga.Name = "mnuUilHga";
            this.mnuUilHga.Size = new System.Drawing.Size(127, 22);
            this.mnuUilHga.Text = "&Phục hồi";
            // 
            // mnuDsa
            // 
            this.mnuDsa.Enabled = false;
            this.mnuDsa.Name = "mnuDsa";
            this.mnuDsa.Size = new System.Drawing.Size(66, 20);
            this.mnuDsa.Text = "&Danh mục";
            this.mnuDsa.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuDsa_DropDownItemClicked);
            // 
            // mnuTke
            // 
            this.mnuTke.Enabled = false;
            this.mnuTke.Name = "mnuTke";
            this.mnuTke.Size = new System.Drawing.Size(63, 20);
            this.mnuTke.Text = "&Thống kê";
            this.mnuTke.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuTke_DropDownItemClicked);
            // 
            // mnuBca
            // 
            this.mnuBca.Enabled = false;
            this.mnuBca.Name = "mnuBca";
            this.mnuBca.Size = new System.Drawing.Size(57, 20);
            this.mnuBca.Text = "&Báo cáo";
            this.mnuBca.Visible = false;
            // 
            // mnuHeo
            // 
            this.mnuHeo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSiqDkc,
            this.mnuBauVlv,
            this.mnuHeo_00,
            this.mnuYhvTeo});
            this.mnuHeo.Name = "mnuHeo";
            this.mnuHeo.Size = new System.Drawing.Size(58, 20);
            this.mnuHeo.Text = "&Trợ giúp";
            // 
            // mnuSiqDkc
            // 
            this.mnuSiqDkc.Name = "mnuSiqDkc";
            this.mnuSiqDkc.Size = new System.Drawing.Size(159, 22);
            this.mnuSiqDkc.Text = "&Sử dụng";
            // 
            // mnuBauVlv
            // 
            this.mnuBauVlv.Name = "mnuBauVlv";
            this.mnuBauVlv.Size = new System.Drawing.Size(159, 22);
            this.mnuBauVlv.Text = "&Mua bản quyền";
            this.mnuBauVlv.Click += new System.EventHandler(this.mnuBauVlv_Click);
            // 
            // mnuHeo_00
            // 
            this.mnuHeo_00.Name = "mnuHeo_00";
            this.mnuHeo_00.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuYhvTeo
            // 
            this.mnuYhvTeo.Name = "mnuYhvTeo";
            this.mnuYhvTeo.Size = new System.Drawing.Size(159, 22);
            this.mnuYhvTeo.Text = "&Thông tin";
            this.mnuYhvTeo.Click += new System.EventHandler(this.mnuYhvTeo_Click);
            // 
            // staAep
            // 
            this.staAep.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staFawObj,
            this.staMbzAil,
            this.staYcpDar});
            this.staAep.Location = new System.Drawing.Point(0, 375);
            this.staAep.Name = "staAep";
            this.staAep.Size = new System.Drawing.Size(639, 22);
            this.staAep.TabIndex = 2;
            this.staAep.Text = "statusStrip1";
            // 
            // staFawObj
            // 
            this.staFawObj.Name = "staFawObj";
            this.staFawObj.Size = new System.Drawing.Size(67, 17);
            this.staFawObj.Text = "USER LOGIN";
            // 
            // staMbzAil
            // 
            this.staMbzAil.Name = "staMbzAil";
            this.staMbzAil.Size = new System.Drawing.Size(45, 17);
            this.staMbzAil.Text = "SERVER";
            // 
            // staYcpDar
            // 
            this.staYcpDar.Name = "staYcpDar";
            this.staYcpDar.Size = new System.Drawing.Size(31, 17);
            this.staYcpDar.Text = "TIME";
            // 
            // tmrFhvHfj
            // 
            this.tmrFhvHfj.Enabled = true;
            this.tmrFhvHfj.Interval = 1000;
            this.tmrFhvHfj.Tick += new System.EventHandler(this.tmrFhvHfj_Tick);
            // 
            // FrmAepAjf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SKG.Properties.Resources.bxe;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(639, 397);
            this.Controls.Add(this.staAep);
            this.Controls.Add(this.mnuAep);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuAep;
            this.Name = "FrmAepAjf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "..::.. SKG ..::.. QUAN LI XE RA VAO BEN - BEN XE NGA TU GA - TP. HO CHI MINH";
            this.Load += new System.EventHandler(this.FrmAepAjf_Load);
            this.mnuAep.ResumeLayout(false);
            this.mnuAep.PerformLayout();
            this.staAep.ResumeLayout(false);
            this.staAep.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuAep;
        private System.Windows.Forms.StatusStrip staAep;
        private System.Windows.Forms.ToolStripMenuItem mnuSys;
        private System.Windows.Forms.ToolStripMenuItem mnuCbuHeq;
        private System.Windows.Forms.ToolStripMenuItem mnuDsa;
        private System.Windows.Forms.ToolStripMenuItem mnuTke;
        private System.Windows.Forms.ToolStripMenuItem mnuBca;
        private System.Windows.Forms.ToolStripMenuItem mnuHeo;
        private System.Windows.Forms.ToolStripMenuItem mnuSiqDkc;
        private System.Windows.Forms.ToolStripSeparator mnuHeo_00;
        private System.Windows.Forms.ToolStripMenuItem mnuYhvTeo;
        private System.Windows.Forms.ToolStripStatusLabel staFawObj;
        private System.Windows.Forms.ToolStripStatusLabel staMbzAil;
        private System.Windows.Forms.ToolStripStatusLabel staYcpDar;
        private System.Windows.Forms.Timer tmrFhvHfj;
        private System.Windows.Forms.ToolStripMenuItem mnuSboLii;
        private System.Windows.Forms.ToolStripMenuItem mnuUilHga;
        private System.Windows.Forms.ToolStripMenuItem mnuBauVlv;
        private System.Windows.Forms.ToolStripSeparator mnuSys_00;
    }
}

