namespace BXE.PRE.VbqGaa
{
    partial class FrmAfcGaa
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
            this.lblWeight = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tmrDongHo = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cbbNumber = new System.Windows.Forms.ComboBox();
            this.lblMoney = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdInvoice = new System.Windows.Forms.Button();
            this.tblAep = new System.Windows.Forms.TableLayoutPanel();
            this.lblAccOut = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblAccIn = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblDateOut = new System.Windows.Forms.Label();
            this.lblDateIn = new System.Windows.Forms.Label();
            this.lblChair = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblKind = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmdRedo = new System.Windows.Forms.Button();
            this.cmdOut = new System.Windows.Forms.Button();
            this.lblInf = new System.Windows.Forms.Label();
            this.cmdInList = new System.Windows.Forms.Button();
            this.cmdSumary1 = new System.Windows.Forms.Button();
            this.cmdSumary2 = new System.Windows.Forms.Button();
            this.tmrAutoLoadData = new System.Windows.Forms.Timer(this.components);
            this.tblAep.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.ForeColor = System.Drawing.Color.Black;
            this.lblWeight.Location = new System.Drawing.Point(183, 97);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(25, 25);
            this.lblWeight.TabIndex = 9;
            this.lblWeight.Text = "?";
            this.lblWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWeight.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(5, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Loại xe:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(343, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(399, 39);
            this.label6.TabIndex = 3;
            this.label6.Text = "CỔNG RA";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrDongHo
            // 
            this.tmrDongHo.Interval = 1000;
            this.tmrDongHo.Tick += new System.EventHandler(this.tmrDongHo_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(5, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhóm loại xe:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(5, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tìm biển số:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdClose
            // 
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(493, 365);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(63, 58);
            this.cmdClose.TabIndex = 33;
            this.cmdClose.Text = "Đó&ng";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cbbNumber
            // 
            this.cbbNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbbNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbNumber.DisplayMember = "Number";
            this.cbbNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNumber.ForeColor = System.Drawing.Color.Gray;
            this.cbbNumber.FormattingEnabled = true;
            this.cbbNumber.Location = new System.Drawing.Point(183, 5);
            this.cbbNumber.Name = "cbbNumber";
            this.cbbNumber.Size = new System.Drawing.Size(152, 33);
            this.cbbNumber.TabIndex = 2;
            this.cbbNumber.ValueMember = "Id";
            this.cbbNumber.SelectedIndexChanged += new System.EventHandler(this.cbbNumber_SelectedIndexChanged);
            this.cbbNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbNumber_KeyDown);
            // 
            // lblMoney
            // 
            this.lblMoney.AutoSize = true;
            this.tblAep.SetColumnSpan(this.lblMoney, 2);
            this.lblMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney.ForeColor = System.Drawing.Color.Blue;
            this.lblMoney.Location = new System.Drawing.Point(183, 263);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(25, 25);
            this.lblMoney.TabIndex = 23;
            this.lblMoney.Text = "?";
            this.lblMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(5, 263);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 25);
            this.label11.TabIndex = 22;
            this.label11.Text = "Số tiền:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(5, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 25);
            this.label9.TabIndex = 20;
            this.label9.Text = "Đơn giá:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(5, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 25);
            this.label8.TabIndex = 18;
            this.label8.Text = "Thời gian đậu:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdInvoice
            // 
            this.cmdInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInvoice.Location = new System.Drawing.Point(12, 365);
            this.cmdInvoice.Name = "cmdInvoice";
            this.cmdInvoice.Size = new System.Drawing.Size(63, 58);
            this.cmdInvoice.TabIndex = 28;
            this.cmdInvoice.Text = "&Tính tiền";
            this.cmdInvoice.UseVisualStyleBackColor = true;
            this.cmdInvoice.Click += new System.EventHandler(this.cmdInvoice_Click);
            // 
            // tblAep
            // 
            this.tblAep.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tblAep.ColumnCount = 3;
            this.tblAep.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblAep.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblAep.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblAep.Controls.Add(this.lblAccOut, 1, 11);
            this.tblAep.Controls.Add(this.label6, 2, 0);
            this.tblAep.Controls.Add(this.label15, 0, 11);
            this.tblAep.Controls.Add(this.label2, 0, 2);
            this.tblAep.Controls.Add(this.lblAccIn, 1, 10);
            this.tblAep.Controls.Add(this.label1, 0, 1);
            this.tblAep.Controls.Add(this.label13, 0, 10);
            this.tblAep.Controls.Add(this.label4, 0, 0);
            this.tblAep.Controls.Add(this.cbbNumber, 1, 0);
            this.tblAep.Controls.Add(this.lblMoney, 1, 9);
            this.tblAep.Controls.Add(this.lblPrice, 1, 8);
            this.tblAep.Controls.Add(this.lblDuration, 1, 7);
            this.tblAep.Controls.Add(this.lblDateOut, 1, 6);
            this.tblAep.Controls.Add(this.lblDateIn, 1, 5);
            this.tblAep.Controls.Add(this.lblChair, 1, 4);
            this.tblAep.Controls.Add(this.lblWeight, 1, 3);
            this.tblAep.Controls.Add(this.lblNumber, 2, 4);
            this.tblAep.Controls.Add(this.label10, 2, 3);
            this.tblAep.Controls.Add(this.lblGroup, 1, 1);
            this.tblAep.Controls.Add(this.lblKind, 1, 2);
            this.tblAep.Controls.Add(this.label11, 0, 9);
            this.tblAep.Controls.Add(this.label9, 0, 8);
            this.tblAep.Controls.Add(this.label8, 0, 7);
            this.tblAep.Controls.Add(this.label7, 0, 6);
            this.tblAep.Controls.Add(this.label5, 0, 5);
            this.tblAep.Controls.Add(this.label3, 0, 4);
            this.tblAep.Controls.Add(this.label12, 0, 3);
            this.tblAep.Location = new System.Drawing.Point(12, 12);
            this.tblAep.Name = "tblAep";
            this.tblAep.RowCount = 12;
            this.tblAep.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAep.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAep.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAep.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAep.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAep.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAep.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAep.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAep.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAep.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAep.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAep.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblAep.Size = new System.Drawing.Size(747, 344);
            this.tblAep.TabIndex = 0;
            // 
            // lblAccOut
            // 
            this.lblAccOut.AutoSize = true;
            this.tblAep.SetColumnSpan(this.lblAccOut, 2);
            this.lblAccOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccOut.ForeColor = System.Drawing.Color.Black;
            this.lblAccOut.Location = new System.Drawing.Point(183, 317);
            this.lblAccOut.Name = "lblAccOut";
            this.lblAccOut.Size = new System.Drawing.Size(25, 25);
            this.lblAccOut.TabIndex = 27;
            this.lblAccOut.Text = "?";
            this.lblAccOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Gray;
            this.label15.Location = new System.Drawing.Point(5, 317);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(153, 25);
            this.label15.TabIndex = 26;
            this.label15.Text = "Người cho ra:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAccIn
            // 
            this.lblAccIn.AutoSize = true;
            this.tblAep.SetColumnSpan(this.lblAccIn, 2);
            this.lblAccIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccIn.ForeColor = System.Drawing.Color.Black;
            this.lblAccIn.Location = new System.Drawing.Point(183, 290);
            this.lblAccIn.Name = "lblAccIn";
            this.lblAccIn.Size = new System.Drawing.Size(25, 25);
            this.lblAccIn.TabIndex = 25;
            this.lblAccIn.Text = "?";
            this.lblAccIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(5, 290);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(170, 25);
            this.label13.TabIndex = 24;
            this.label13.Text = "Người cho vào:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.tblAep.SetColumnSpan(this.lblPrice, 2);
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.Black;
            this.lblPrice.Location = new System.Drawing.Point(183, 236);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(25, 25);
            this.lblPrice.TabIndex = 21;
            this.lblPrice.Text = "?";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.tblAep.SetColumnSpan(this.lblDuration, 2);
            this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.ForeColor = System.Drawing.Color.Black;
            this.lblDuration.Location = new System.Drawing.Point(183, 209);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(25, 25);
            this.lblDuration.TabIndex = 19;
            this.lblDuration.Text = "?";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDateOut
            // 
            this.lblDateOut.AutoSize = true;
            this.tblAep.SetColumnSpan(this.lblDateOut, 2);
            this.lblDateOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOut.ForeColor = System.Drawing.Color.Black;
            this.lblDateOut.Location = new System.Drawing.Point(183, 182);
            this.lblDateOut.Name = "lblDateOut";
            this.lblDateOut.Size = new System.Drawing.Size(25, 25);
            this.lblDateOut.TabIndex = 17;
            this.lblDateOut.Text = "?";
            this.lblDateOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDateIn
            // 
            this.lblDateIn.AutoSize = true;
            this.tblAep.SetColumnSpan(this.lblDateIn, 2);
            this.lblDateIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateIn.ForeColor = System.Drawing.Color.Black;
            this.lblDateIn.Location = new System.Drawing.Point(183, 155);
            this.lblDateIn.Name = "lblDateIn";
            this.lblDateIn.Size = new System.Drawing.Size(25, 25);
            this.lblDateIn.TabIndex = 15;
            this.lblDateIn.Text = "?";
            this.lblDateIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChair
            // 
            this.lblChair.AutoSize = true;
            this.lblChair.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChair.ForeColor = System.Drawing.Color.Black;
            this.lblChair.Location = new System.Drawing.Point(183, 124);
            this.lblChair.Name = "lblChair";
            this.lblChair.Size = new System.Drawing.Size(25, 25);
            this.lblChair.TabIndex = 12;
            this.lblChair.Text = "?";
            this.lblChair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.ForeColor = System.Drawing.Color.Red;
            this.lblNumber.Location = new System.Drawing.Point(343, 124);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(399, 29);
            this.lblNumber.TabIndex = 13;
            this.lblNumber.Text = "?";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label10.Location = new System.Drawing.Point(343, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(399, 25);
            this.label10.TabIndex = 10;
            this.label10.Text = "BIỂN SỐ XE";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.tblAep.SetColumnSpan(this.lblGroup, 2);
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.ForeColor = System.Drawing.Color.Gray;
            this.lblGroup.Location = new System.Drawing.Point(183, 43);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(19, 20);
            this.lblGroup.TabIndex = 5;
            this.lblGroup.Text = "?";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKind
            // 
            this.lblKind.AutoSize = true;
            this.tblAep.SetColumnSpan(this.lblKind, 2);
            this.lblKind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKind.ForeColor = System.Drawing.Color.Gray;
            this.lblKind.Location = new System.Drawing.Point(183, 70);
            this.lblKind.Name = "lblKind";
            this.lblKind.Size = new System.Drawing.Size(19, 20);
            this.lblKind.TabIndex = 7;
            this.lblKind.Text = "?";
            this.lblKind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(5, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Thời gian ra:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(5, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Thời gian vào:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(5, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Số ghế:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(5, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 25);
            this.label12.TabIndex = 8;
            this.label12.Text = "Tải trọng:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Visible = false;
            // 
            // cmdRedo
            // 
            this.cmdRedo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRedo.Location = new System.Drawing.Point(151, 365);
            this.cmdRedo.Name = "cmdRedo";
            this.cmdRedo.Size = new System.Drawing.Size(63, 58);
            this.cmdRedo.TabIndex = 30;
            this.cmdRedo.Text = "&Sửa lại";
            this.cmdRedo.UseVisualStyleBackColor = true;
            this.cmdRedo.Click += new System.EventHandler(this.cmdRedo_Click);
            // 
            // cmdOut
            // 
            this.cmdOut.Enabled = false;
            this.cmdOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOut.Location = new System.Drawing.Point(81, 365);
            this.cmdOut.Name = "cmdOut";
            this.cmdOut.Size = new System.Drawing.Size(63, 58);
            this.cmdOut.TabIndex = 29;
            this.cmdOut.Text = "&Cho ra";
            this.cmdOut.UseVisualStyleBackColor = true;
            this.cmdOut.Click += new System.EventHandler(this.cmdOut_Click);
            // 
            // lblInf
            // 
            this.lblInf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblInf.Location = new System.Drawing.Point(562, 364);
            this.lblInf.Name = "lblInf";
            this.lblInf.Size = new System.Drawing.Size(197, 59);
            this.lblInf.TabIndex = 34;
            this.lblInf.Text = "?";
            this.lblInf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdInList
            // 
            this.cmdInList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInList.Location = new System.Drawing.Point(220, 365);
            this.cmdInList.Name = "cmdInList";
            this.cmdInList.Size = new System.Drawing.Size(95, 58);
            this.cmdInList.TabIndex = 31;
            this.cmdInList.Text = "&Xe trong bến";
            this.cmdInList.UseVisualStyleBackColor = true;
            this.cmdInList.Click += new System.EventHandler(this.cmdInList_Click);
            // 
            // cmdSumary1
            // 
            this.cmdSumary1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSumary1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmdSumary1.Image = global::BXE.Properties.Resources.printer;
            this.cmdSumary1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSumary1.Location = new System.Drawing.Point(321, 365);
            this.cmdSumary1.Name = "cmdSumary1";
            this.cmdSumary1.Size = new System.Drawing.Size(80, 58);
            this.cmdSumary1.TabIndex = 32;
            this.cmdSumary1.Text = "&In nhóm 1";
            this.cmdSumary1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSumary1.UseVisualStyleBackColor = true;
            this.cmdSumary1.Click += new System.EventHandler(this.cmdSumary1_Click);
            // 
            // cmdSumary2
            // 
            this.cmdSumary2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSumary2.ForeColor = System.Drawing.Color.Red;
            this.cmdSumary2.Image = global::BXE.Properties.Resources.printer;
            this.cmdSumary2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSumary2.Location = new System.Drawing.Point(407, 365);
            this.cmdSumary2.Name = "cmdSumary2";
            this.cmdSumary2.Size = new System.Drawing.Size(80, 58);
            this.cmdSumary2.TabIndex = 35;
            this.cmdSumary2.Text = "In &nhóm 2";
            this.cmdSumary2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdSumary2.UseVisualStyleBackColor = true;
            this.cmdSumary2.Click += new System.EventHandler(this.cmdSumary2_Click);
            // 
            // tmrAutoLoadData
            // 
            this.tmrAutoLoadData.Enabled = true;
            this.tmrAutoLoadData.Interval = 30000;
            this.tmrAutoLoadData.Tick += new System.EventHandler(this.tmrAutoLoadData_Tick);
            // 
            // FrmAfcGaa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 432);
            this.Controls.Add(this.cmdSumary2);
            this.Controls.Add(this.cmdSumary1);
            this.Controls.Add(this.cmdInList);
            this.Controls.Add(this.lblInf);
            this.Controls.Add(this.cmdOut);
            this.Controls.Add(this.cmdRedo);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdInvoice);
            this.Controls.Add(this.tblAep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAfcGaa";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CỔNG RA";
            this.Load += new System.EventHandler(this.FrmAfcGaa_Load);
            this.tblAep.ResumeLayout(false);
            this.tblAep.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer tmrDongHo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox cbbNumber;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.TableLayoutPanel tblAep;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblDateOut;
        private System.Windows.Forms.Label lblDateIn;
        private System.Windows.Forms.Label lblChair;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Button cmdInvoice;
        private System.Windows.Forms.Button cmdRedo;
        private System.Windows.Forms.Button cmdOut;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblKind;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblAccIn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblAccOut;
        private System.Windows.Forms.Label lblInf;
        private System.Windows.Forms.Button cmdInList;
        private System.Windows.Forms.Button cmdSumary1;
        private System.Windows.Forms.Button cmdSumary2;
        private System.Windows.Forms.Timer tmrAutoLoadData;
    }
}