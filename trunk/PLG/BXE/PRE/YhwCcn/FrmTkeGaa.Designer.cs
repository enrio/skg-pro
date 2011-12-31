namespace BXE.PRE.YhwCcn
{
    partial class FrmTkeGaa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAep = new System.Windows.Forms.DataGridView();
            this.colNo_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKindName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTGVao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTGRa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdInDay = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.radIn = new System.Windows.Forms.RadioButton();
            this.radOut = new System.Windows.Forms.RadioButton();
            this.cbbQuy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbThang = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAep)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAep
            // 
            this.dgvAep.AllowUserToAddRows = false;
            this.dgvAep.AllowUserToDeleteRows = false;
            this.dgvAep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo_,
            this.colNumber,
            this.colAccIn,
            this.colAccOut,
            this.colGroupName,
            this.colKindName,
            this.colLength,
            this.colWeight,
            this.colChair,
            this.colTGVao,
            this.colTGRa,
            this.colDays,
            this.colHour,
            this.colPrice,
            this.colPrice2,
            this.colMoney});
            this.dgvAep.Location = new System.Drawing.Point(15, 64);
            this.dgvAep.Name = "dgvAep";
            this.dgvAep.ReadOnly = true;
            this.dgvAep.Size = new System.Drawing.Size(940, 444);
            this.dgvAep.TabIndex = 10;
            this.dgvAep.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentClick);
            this.dgvAep.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvMain_CellPainting);
            this.dgvAep.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAep_ColumnHeaderMouseClick);
            // 
            // colNo_
            // 
            this.colNo_.DataPropertyName = "No_";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "0#";
            this.colNo_.DefaultCellStyle = dataGridViewCellStyle13;
            this.colNo_.HeaderText = "TT";
            this.colNo_.Name = "colNo_";
            this.colNo_.ReadOnly = true;
            this.colNo_.Width = 30;
            // 
            // colNumber
            // 
            this.colNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNumber.DataPropertyName = "Number";
            this.colNumber.HeaderText = "Biển số";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            this.colNumber.Width = 67;
            // 
            // colAccIn
            // 
            this.colAccIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAccIn.DataPropertyName = "AccIn";
            this.colAccIn.HeaderText = "Người cho vào";
            this.colAccIn.Name = "colAccIn";
            this.colAccIn.ReadOnly = true;
            this.colAccIn.Width = 102;
            // 
            // colAccOut
            // 
            this.colAccOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAccOut.DataPropertyName = "AccOut";
            this.colAccOut.HeaderText = "Người cho ra";
            this.colAccOut.Name = "colAccOut";
            this.colAccOut.ReadOnly = true;
            this.colAccOut.Width = 93;
            // 
            // colGroupName
            // 
            this.colGroupName.DataPropertyName = "GroupName";
            this.colGroupName.HeaderText = "Nhóm xe";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.ReadOnly = true;
            // 
            // colKindName
            // 
            this.colKindName.DataPropertyName = "KindName";
            this.colKindName.HeaderText = "Loại xe";
            this.colKindName.Name = "colKindName";
            this.colKindName.ReadOnly = true;
            // 
            // colLength
            // 
            this.colLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.colLength.DataPropertyName = "Length";
            this.colLength.HeaderText = "Chiều dài";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 5;
            // 
            // colWeight
            // 
            this.colWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.colWeight.DataPropertyName = "Weight";
            this.colWeight.HeaderText = "Tải trọng";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            this.colWeight.Width = 5;
            // 
            // colChair
            // 
            this.colChair.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.colChair.DataPropertyName = "Chair";
            this.colChair.HeaderText = "Số ghế";
            this.colChair.Name = "colChair";
            this.colChair.ReadOnly = true;
            this.colChair.Width = 5;
            // 
            // colTGVao
            // 
            this.colTGVao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTGVao.DataPropertyName = "DateIn";
            this.colTGVao.HeaderText = "Thời gian vào";
            this.colTGVao.Name = "colTGVao";
            this.colTGVao.ReadOnly = true;
            this.colTGVao.Width = 97;
            // 
            // colTGRa
            // 
            this.colTGRa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTGRa.DataPropertyName = "DateOut";
            this.colTGRa.HeaderText = "Thời gian ra";
            this.colTGRa.Name = "colTGRa";
            this.colTGRa.ReadOnly = true;
            this.colTGRa.Width = 88;
            // 
            // colDays
            // 
            this.colDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.colDays.DataPropertyName = "Day";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.NullValue = null;
            this.colDays.DefaultCellStyle = dataGridViewCellStyle14;
            this.colDays.HeaderText = "Ngày đậu";
            this.colDays.Name = "colDays";
            this.colDays.ReadOnly = true;
            this.colDays.Width = 5;
            // 
            // colHour
            // 
            this.colHour.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.colHour.DataPropertyName = "Hour";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colHour.DefaultCellStyle = dataGridViewCellStyle15;
            this.colHour.HeaderText = "Giờ đậu";
            this.colHour.Name = "colHour";
            this.colHour.ReadOnly = true;
            this.colHour.Width = 5;
            // 
            // colPrice
            // 
            this.colPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colPrice.DataPropertyName = "Price1";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "#,### \"VNĐ\"";
            dataGridViewCellStyle16.NullValue = null;
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle16;
            this.colPrice.HeaderText = "ĐG nửa ngày";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 95;
            // 
            // colPrice2
            // 
            this.colPrice2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colPrice2.DataPropertyName = "Price2";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "#,### \"VNĐ\"";
            this.colPrice2.DefaultCellStyle = dataGridViewCellStyle17;
            this.colPrice2.HeaderText = "ĐG một ngày";
            this.colPrice2.Name = "colPrice2";
            this.colPrice2.ReadOnly = true;
            this.colPrice2.Width = 94;
            // 
            // colMoney
            // 
            this.colMoney.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMoney.DataPropertyName = "Money";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "#,### \"VNĐ\"";
            dataGridViewCellStyle18.NullValue = null;
            this.colMoney.DefaultCellStyle = dataGridViewCellStyle18;
            this.colMoney.HeaderText = "Thành tiền";
            this.colMoney.Name = "colMoney";
            this.colMoney.ReadOnly = true;
            this.colMoney.Width = 83;
            // 
            // cmdInDay
            // 
            this.cmdInDay.Location = new System.Drawing.Point(186, 35);
            this.cmdInDay.Name = "cmdInDay";
            this.cmdInDay.Size = new System.Drawing.Size(89, 23);
            this.cmdInDay.TabIndex = 6;
            this.cmdInDay.Text = "&Xem thống kê";
            this.cmdInDay.UseVisualStyleBackColor = true;
            this.cmdInDay.Click += new System.EventHandler(this.cmdInDay_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(48, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(132, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến:";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(48, 38);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(132, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(281, 35);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(89, 23);
            this.cmdPrint.TabIndex = 7;
            this.cmdPrint.Text = "&In thống kê";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPdf_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(666, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 43);
            this.label3.TabIndex = 9;
            this.label3.Text = "THỐNG KÊ DOANH THU";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(477, 14);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(183, 43);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "?";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radIn
            // 
            this.radIn.AutoSize = true;
            this.radIn.Location = new System.Drawing.Point(186, 12);
            this.radIn.Name = "radIn";
            this.radIn.Size = new System.Drawing.Size(71, 17);
            this.radIn.TabIndex = 4;
            this.radIn.Text = "Ngày vào";
            this.radIn.UseVisualStyleBackColor = true;
            // 
            // radOut
            // 
            this.radOut.AutoSize = true;
            this.radOut.Checked = true;
            this.radOut.Location = new System.Drawing.Point(263, 12);
            this.radOut.Name = "radOut";
            this.radOut.Size = new System.Drawing.Size(62, 17);
            this.radOut.TabIndex = 5;
            this.radOut.TabStop = true;
            this.radOut.Text = "Ngày ra";
            this.radOut.UseVisualStyleBackColor = true;
            // 
            // cbbQuy
            // 
            this.cbbQuy.FormattingEnabled = true;
            this.cbbQuy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbbQuy.Location = new System.Drawing.Point(425, 14);
            this.cbbQuy.Name = "cbbQuy";
            this.cbbQuy.Size = new System.Drawing.Size(46, 21);
            this.cbbQuy.TabIndex = 11;
            this.cbbQuy.SelectedIndexChanged += new System.EventHandler(this.cbbQuy_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Quý:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tháng:";
            // 
            // cbbThang
            // 
            this.cbbThang.FormattingEnabled = true;
            this.cbbThang.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbbThang.Location = new System.Drawing.Point(425, 36);
            this.cbbThang.Name = "cbbThang";
            this.cbbThang.Size = new System.Drawing.Size(46, 21);
            this.cbbThang.TabIndex = 13;
            this.cbbThang.SelectedIndexChanged += new System.EventHandler(this.cbbThang_SelectedIndexChanged);
            // 
            // FrmTkeGaa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 520);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbbThang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbQuy);
            this.Controls.Add(this.radOut);
            this.Controls.Add(this.radIn);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.cmdInDay);
            this.Controls.Add(this.dgvAep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTkeGaa";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ XE RA - TÍNH DOANH THU";
            this.Load += new System.EventHandler(this.FrmTkeGaa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAep;
        private System.Windows.Forms.Button cmdInDay;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.RadioButton radIn;
        private System.Windows.Forms.RadioButton radOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKindName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChair;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTGVao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTGRa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoney;
        private System.Windows.Forms.ComboBox cbbQuy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbThang;
    }
}