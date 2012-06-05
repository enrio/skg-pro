namespace SKG.SYS
{
    partial class FrmCbuHeq
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
            this.cmdSet = new System.Windows.Forms.Button();
            this.cmdNo = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.radSql = new System.Windows.Forms.RadioButton();
            this.radWin = new System.Windows.Forms.RadioButton();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdDb = new System.Windows.Forms.Button();
            this.cbbDB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdServer = new System.Windows.Forms.Button();
            this.cbbServer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdSet
            // 
            this.cmdSet.Location = new System.Drawing.Point(12, 118);
            this.cmdSet.Name = "cmdSet";
            this.cmdSet.Size = new System.Drawing.Size(46, 56);
            this.cmdSet.TabIndex = 14;
            this.cmdSet.Text = "&SET";
            this.cmdSet.UseVisualStyleBackColor = true;
            this.cmdSet.Click += new System.EventHandler(this.cmdSet_Click);
            // 
            // cmdNo
            // 
            this.cmdNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.cmdNo.Location = new System.Drawing.Point(248, 150);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(50, 24);
            this.cmdNo.TabIndex = 13;
            this.cmdNo.Text = "&NO";
            this.cmdNo.UseVisualStyleBackColor = true;
            this.cmdNo.Click += new System.EventHandler(this.cmdNo_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOk.Location = new System.Drawing.Point(248, 118);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(50, 24);
            this.cmdOk.TabIndex = 12;
            this.cmdOk.Text = "&OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // radSql
            // 
            this.radSql.AutoSize = true;
            this.radSql.Checked = true;
            this.radSql.Location = new System.Drawing.Point(64, 154);
            this.radSql.Name = "radSql";
            this.radSql.Size = new System.Drawing.Size(175, 17);
            this.radSql.TabIndex = 11;
            this.radSql.TabStop = true;
            this.radSql.Text = "User &SQL Server authentication";
            this.radSql.UseVisualStyleBackColor = true;
            this.radSql.CheckedChanged += new System.EventHandler(this.radSql_CheckedChanged);
            // 
            // radWin
            // 
            this.radWin.AutoSize = true;
            this.radWin.Location = new System.Drawing.Point(64, 122);
            this.radWin.Name = "radWin";
            this.radWin.Size = new System.Drawing.Size(161, 17);
            this.radWin.TabIndex = 10;
            this.radWin.TabStop = true;
            this.radWin.Text = "User &windows authentication";
            this.radWin.UseVisualStyleBackColor = true;
            this.radWin.CheckedChanged += new System.EventHandler(this.radWin_CheckedChanged);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(108, 65);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(190, 20);
            this.txtPass.TabIndex = 6;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pass:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(108, 39);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(190, 20);
            this.txtUser.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "User:";
            // 
            // cmdDb
            // 
            this.cmdDb.Location = new System.Drawing.Point(266, 91);
            this.cmdDb.Name = "cmdDb";
            this.cmdDb.Size = new System.Drawing.Size(32, 21);
            this.cmdDb.TabIndex = 9;
            this.cmdDb.Text = "...";
            this.cmdDb.UseVisualStyleBackColor = true;
            this.cmdDb.Click += new System.EventHandler(this.cmdDb_Click);
            // 
            // cbbDB
            // 
            this.cbbDB.FormattingEnabled = true;
            this.cbbDB.Location = new System.Drawing.Point(108, 92);
            this.cbbDB.Name = "cbbDB";
            this.cbbDB.Size = new System.Drawing.Size(152, 21);
            this.cbbDB.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "DB:";
            // 
            // cmdServer
            // 
            this.cmdServer.Location = new System.Drawing.Point(266, 11);
            this.cmdServer.Name = "cmdServer";
            this.cmdServer.Size = new System.Drawing.Size(32, 21);
            this.cmdServer.TabIndex = 2;
            this.cmdServer.Text = "...";
            this.cmdServer.UseVisualStyleBackColor = true;
            this.cmdServer.Click += new System.EventHandler(this.cmdServer_Click);
            // 
            // cbbServer
            // 
            this.cbbServer.FormattingEnabled = true;
            this.cbbServer.Location = new System.Drawing.Point(108, 12);
            this.cbbServer.Name = "cbbServer";
            this.cbbServer.Size = new System.Drawing.Size(152, 21);
            this.cbbServer.TabIndex = 1;
            this.cbbServer.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // FrmCbuHeq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SKG.Properties.Resources.Database;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(312, 188);
            this.Controls.Add(this.cmdSet);
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.radSql);
            this.Controls.Add(this.radWin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdDb);
            this.Controls.Add(this.cbbDB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdServer);
            this.Controls.Add(this.cbbServer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCbuHeq";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cau hinh he thong";
            this.Load += new System.EventHandler(this.FrmCbuHeq_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSet;
        private System.Windows.Forms.Button cmdNo;
        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.RadioButton radSql;
        private System.Windows.Forms.RadioButton radWin;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdDb;
        private System.Windows.Forms.ComboBox cbbDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdServer;
        private System.Windows.Forms.ComboBox cbbServer;
        private System.Windows.Forms.Label label1;
    }
}