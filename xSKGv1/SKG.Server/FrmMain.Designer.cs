namespace SKG.Server
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
            this.components = new System.ComponentModel.Container();
            this.srpMain = new System.IO.Ports.SerialPort(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnAutoSendReceive = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // srpMain
            // 
            this.srpMain.PortName = "COM5";
            this.srpMain.ReadTimeout = 300;
            this.srpMain.WriteTimeout = 300;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(150, 144);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnAutoSendReceive
            // 
            this.btnAutoSendReceive.Location = new System.Drawing.Point(12, 162);
            this.btnAutoSendReceive.Name = "btnAutoSendReceive";
            this.btnAutoSendReceive.Size = new System.Drawing.Size(150, 25);
            this.btnAutoSendReceive.TabIndex = 1;
            this.btnAutoSendReceive.Text = "Nhận/Gửi";
            this.btnAutoSendReceive.UseVisualStyleBackColor = true;
            this.btnAutoSendReceive.Click += new System.EventHandler(this.btnAutoSendReceive_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 195);
            this.Controls.Add(this.btnAutoSendReceive);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort srpMain;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnAutoSendReceive;
        private System.Windows.Forms.Timer timer1;
    }
}