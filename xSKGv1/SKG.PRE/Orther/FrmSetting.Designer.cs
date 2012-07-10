namespace SKG.PRE.Orther
{
    partial class FrmSetting
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
            this.gctMain = new DevExpress.XtraEditors.GroupControl();
            this.chkSQLCE = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cbbDb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmdClose = new DevExpress.XtraEditors.SimpleButton();
            this.cbbServer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmdSetup = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
            this.cbbAuthen = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cbbUser = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gctMain)).BeginInit();
            this.gctMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSQLCE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbDb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbAuthen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gctMain
            // 
            this.gctMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gctMain.Controls.Add(this.chkSQLCE);
            this.gctMain.Controls.Add(this.labelControl6);
            this.gctMain.Controls.Add(this.cbbDb);
            this.gctMain.Controls.Add(this.labelControl1);
            this.gctMain.Controls.Add(this.txtPass);
            this.gctMain.Controls.Add(this.labelControl2);
            this.gctMain.Controls.Add(this.cmdClose);
            this.gctMain.Controls.Add(this.cbbServer);
            this.gctMain.Controls.Add(this.cmdSetup);
            this.gctMain.Controls.Add(this.labelControl3);
            this.gctMain.Controls.Add(this.cmdOk);
            this.gctMain.Controls.Add(this.cbbAuthen);
            this.gctMain.Controls.Add(this.labelControl4);
            this.gctMain.Controls.Add(this.labelControl5);
            this.gctMain.Controls.Add(this.cbbUser);
            this.gctMain.Location = new System.Drawing.Point(12, 12);
            this.gctMain.Name = "gctMain";
            this.gctMain.Size = new System.Drawing.Size(318, 236);
            this.gctMain.TabIndex = 0;
            this.gctMain.Text = "Cài đặt";
            // 
            // chkSQLCE
            // 
            this.chkSQLCE.EditValue = true;
            this.chkSQLCE.Location = new System.Drawing.Point(15, 204);
            this.chkSQLCE.Name = "chkSQLCE";
            this.chkSQLCE.Properties.Caption = "SQL CE";
            this.chkSQLCE.Size = new System.Drawing.Size(64, 19);
            this.chkSQLCE.TabIndex = 6;
            this.chkSQLCE.CheckedChanged += new System.EventHandler(this.chkSQLCE_CheckedChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(17, 173);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(66, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Cơ sở dữ liệu:";
            // 
            // cbbDb
            // 
            this.cbbDb.Location = new System.Drawing.Point(114, 170);
            this.cbbDb.Name = "cbbDb";
            this.cbbDb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbDb.Properties.Items.AddRange(new object[] {
            "<Tìm kiếm>"});
            this.cbbDb.Size = new System.Drawing.Size(188, 20);
            this.cbbDb.TabIndex = 5;
            this.cbbDb.SelectedIndexChanged += new System.EventHandler(this.cbbDb_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(57, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(197, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "CẤU HÌNH CƠ SỞ DỮ LIỆU";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(114, 144);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.UseSystemPasswordChar = true;
            this.txtPass.Size = new System.Drawing.Size(188, 20);
            this.txtPass.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên máy chủ:";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(235, 196);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(67, 27);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "Đó&ng";
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cbbServer
            // 
            this.cbbServer.EditValue = ".";
            this.cbbServer.Location = new System.Drawing.Point(101, 66);
            this.cbbServer.Name = "cbbServer";
            this.cbbServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbServer.Properties.Items.AddRange(new object[] {
            "<Tìm kiếm>"});
            this.cbbServer.Size = new System.Drawing.Size(201, 20);
            this.cbbServer.TabIndex = 1;
            this.cbbServer.SelectedIndexChanged += new System.EventHandler(this.cbbServer_SelectedIndexChanged);
            // 
            // cmdSetup
            // 
            this.cmdSetup.Location = new System.Drawing.Point(162, 196);
            this.cmdSetup.Name = "cmdSetup";
            this.cmdSetup.Size = new System.Drawing.Size(67, 27);
            this.cmdSetup.TabIndex = 8;
            this.cmdSetup.Text = "Cài đặt";
            this.cmdSetup.Click += new System.EventHandler(this.cmdSetup_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 95);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Xác thực:";
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(89, 196);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(67, 27);
            this.cmdOk.TabIndex = 7;
            this.cmdOk.Text = "Chấp nhận";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cbbAuthen
            // 
            this.cbbAuthen.EditValue = "SQL Server";
            this.cbbAuthen.Location = new System.Drawing.Point(101, 92);
            this.cbbAuthen.Name = "cbbAuthen";
            this.cbbAuthen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbAuthen.Properties.Items.AddRange(new object[] {
            "SQL Server",
            "Windows"});
            this.cbbAuthen.Size = new System.Drawing.Size(201, 20);
            this.cbbAuthen.TabIndex = 2;
            this.cbbAuthen.SelectedIndexChanged += new System.EventHandler(this.cbbAuthen_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(17, 147);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Mật khẩu:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(17, 121);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(50, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Tài khoản:";
            // 
            // cbbUser
            // 
            this.cbbUser.Location = new System.Drawing.Point(114, 118);
            this.cbbUser.Name = "cbbUser";
            this.cbbUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbUser.Size = new System.Drawing.Size(188, 20);
            this.cbbUser.TabIndex = 3;
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 257);
            this.Controls.Add(this.gctMain);
            this.Name = "FrmSetting";
            this.Text = "Cài đặt";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gctMain)).EndInit();
            this.gctMain.ResumeLayout(false);
            this.gctMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSQLCE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbDb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbAuthen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbUser.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gctMain;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cbbDb;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton cmdClose;
        private DevExpress.XtraEditors.ComboBoxEdit cbbServer;
        private DevExpress.XtraEditors.SimpleButton cmdSetup;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton cmdOk;
        private DevExpress.XtraEditors.ComboBoxEdit cbbAuthen;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cbbUser;
        private DevExpress.XtraEditors.CheckEdit chkSQLCE;
    }
}