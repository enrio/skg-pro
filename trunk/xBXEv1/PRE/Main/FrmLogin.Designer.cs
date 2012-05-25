namespace PRE.Main
{
    partial class FrmLogin
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
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmdNo = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmdYes = new DevExpress.XtraEditors.SimpleButton();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelBackground = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelUser = new DevExpress.XtraEditors.LabelControl();
            this.labelPassword = new DevExpress.XtraEditors.LabelControl();
            this.textUser = new DevExpress.XtraEditors.TextEdit();
            this.textPassword = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.buttonCardLogon = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonLogon = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gctMain)).BeginInit();
            this.gctMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBackground)).BeginInit();
            this.panelBackground.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gctMain
            // 
            this.gctMain.ContentImageAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.gctMain.Controls.Add(this.pictureEdit1);
            this.gctMain.Controls.Add(this.labelControl1);
            this.gctMain.Controls.Add(this.cmdNo);
            this.gctMain.Controls.Add(this.labelControl2);
            this.gctMain.Controls.Add(this.cmdYes);
            this.gctMain.Controls.Add(this.txtUser);
            this.gctMain.Controls.Add(this.txtPass);
            this.gctMain.Controls.Add(this.labelControl3);
            this.gctMain.Location = new System.Drawing.Point(100, 109);
            this.gctMain.Name = "gctMain";
            this.gctMain.Size = new System.Drawing.Size(346, 156);
            this.gctMain.TabIndex = 9;
            this.gctMain.Text = "Đăng nhập";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::PRE.Properties.Resources.loginx;
            this.pictureEdit1.Location = new System.Drawing.Point(5, 25);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(127, 124);
            this.pictureEdit1.TabIndex = 9;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(184, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(140, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // cmdNo
            // 
            this.cmdNo.Image = global::PRE.Properties.Resources.closex;
            this.cmdNo.Location = new System.Drawing.Point(249, 115);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(91, 34);
            this.cmdNo.TabIndex = 3;
            this.cmdNo.Text = "Đó&ng";
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(181, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tài khoản:";
            // 
            // cmdYes
            // 
            this.cmdYes.Image = global::PRE.Properties.Resources.ok;
            this.cmdYes.Location = new System.Drawing.Point(152, 115);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(91, 34);
            this.cmdYes.TabIndex = 2;
            this.cmdYes.Text = "Đăng &nhập";
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(239, 56);
            this.txtUser.Name = "txtUser";
            this.txtUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Properties.Appearance.Options.UseFont = true;
            this.txtUser.Size = new System.Drawing.Size(101, 22);
            this.txtUser.TabIndex = 0;
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(239, 82);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.UseSystemPasswordChar = true;
            this.txtPass.Size = new System.Drawing.Size(101, 20);
            this.txtPass.TabIndex = 1;
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(181, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Mật khẩu:";
            // 
            // panelBackground
            // 
            this.panelBackground.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBackground.ContentImage = global::PRE.Properties.Resources.logon;
            this.panelBackground.Controls.Add(this.tableLayoutPanel1);
            this.panelBackground.Location = new System.Drawing.Point(517, 109);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(467, 352);
            this.panelBackground.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelUser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelPassword, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textUser, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textPassword, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(85, 184);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(297, 86);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // labelUser
            // 
            this.labelUser.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelUser.Location = new System.Drawing.Point(3, 3);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(56, 16);
            this.labelUser.TabIndex = 5;
            this.labelUser.Text = "Tài khoản";
            // 
            // labelPassword
            // 
            this.labelPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPassword.Location = new System.Drawing.Point(3, 29);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(52, 16);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Mật khẩu";
            // 
            // textUser
            // 
            this.textUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.textUser.EditValue = "";
            this.textUser.Location = new System.Drawing.Point(65, 3);
            this.textUser.Name = "textUser";
            this.textUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.textUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textUser.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.textUser.Properties.Appearance.Options.UseBackColor = true;
            this.textUser.Properties.Appearance.Options.UseFont = true;
            this.textUser.Properties.Appearance.Options.UseForeColor = true;
            this.textUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.textUser.Size = new System.Drawing.Size(229, 20);
            this.textUser.TabIndex = 0;
            // 
            // textPassword
            // 
            this.textPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.textPassword.EditValue = "";
            this.textPassword.Location = new System.Drawing.Point(65, 29);
            this.textPassword.Name = "textPassword";
            this.textPassword.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.textPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textPassword.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.textPassword.Properties.Appearance.Options.UseBackColor = true;
            this.textPassword.Properties.Appearance.Options.UseFont = true;
            this.textPassword.Properties.Appearance.Options.UseForeColor = true;
            this.textPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.textPassword.Properties.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(229, 20);
            this.textPassword.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tableLayoutPanel1.SetColumnSpan(this.panelControl1, 2);
            this.panelControl1.Controls.Add(this.buttonCardLogon);
            this.panelControl1.Controls.Add(this.buttonCancel);
            this.panelControl1.Controls.Add(this.buttonLogon);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 52);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(297, 34);
            this.panelControl1.TabIndex = 7;
            // 
            // buttonCardLogon
            // 
            this.buttonCardLogon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCardLogon.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCardLogon.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.buttonCardLogon.Appearance.Options.UseFont = true;
            this.buttonCardLogon.Appearance.Options.UseForeColor = true;
            this.buttonCardLogon.Location = new System.Drawing.Point(9, 6);
            this.buttonCardLogon.Name = "buttonCardLogon";
            this.buttonCardLogon.Size = new System.Drawing.Size(129, 23);
            this.buttonCardLogon.TabIndex = 3;
            this.buttonCardLogon.Text = "Quét thẻ nhân viên";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Appearance.Options.UseForeColor = true;
            this.buttonCancel.Location = new System.Drawing.Point(213, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Thoát";
            // 
            // buttonLogon
            // 
            this.buttonLogon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLogon.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogon.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.buttonLogon.Appearance.Options.UseFont = true;
            this.buttonLogon.Appearance.Options.UseForeColor = true;
            this.buttonLogon.Location = new System.Drawing.Point(138, 6);
            this.buttonLogon.Name = "buttonLogon";
            this.buttonLogon.Size = new System.Drawing.Size(75, 23);
            this.buttonLogon.TabIndex = 3;
            this.buttonLogon.Text = "Đăng nhập";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 563);
            this.Controls.Add(this.panelBackground);
            this.Controls.Add(this.gctMain);
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.SizeChanged += new System.EventHandler(this.FrmLogin_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gctMain)).EndInit();
            this.gctMain.ResumeLayout(false);
            this.gctMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBackground)).EndInit();
            this.panelBackground.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gctMain;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton cmdNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton cmdYes;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelBackground;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelUser;
        private DevExpress.XtraEditors.LabelControl labelPassword;
        private DevExpress.XtraEditors.TextEdit textUser;
        private DevExpress.XtraEditors.TextEdit textPassword;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton buttonCardLogon;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.SimpleButton buttonLogon;
    }
}