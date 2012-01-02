namespace BXE.PRE.VbqGaa
{
    partial class FrmAfcVbq
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tmrDongHo = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.lblAccInName = new System.Windows.Forms.Label();
            this.lblDateIn = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdIn = new System.Windows.Forms.Button();
            this.dgvAep = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNo_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKindId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKindName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdInList = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.lblInf = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mskTaxiNumber = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mskThreeNumber = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.mskTruckL = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mskTruckW = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mskTruckNumber = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbTruckKind = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbbCarKind = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mskCarNumber = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.mskMediumNumber = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.mskMediumC = new System.Windows.Forms.MaskedTextBox();
            this.dtpDateIn = new System.Windows.Forms.DateTimePicker();
            this.cmdHand = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAep)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrDongHo
            // 
            this.tmrDongHo.Interval = 1000;
            this.tmrDongHo.Tick += new System.EventHandler(this.tmrDongHo_Tick);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(11, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Thời gian vào:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAccInName
            // 
            this.lblAccInName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccInName.Location = new System.Drawing.Point(592, 132);
            this.lblAccInName.Name = "lblAccInName";
            this.lblAccInName.Size = new System.Drawing.Size(414, 25);
            this.lblAccInName.TabIndex = 16;
            this.lblAccInName.Text = "?";
            this.lblAccInName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateIn
            // 
            this.lblDateIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateIn.Location = new System.Drawing.Point(179, 132);
            this.lblDateIn.Name = "lblDateIn";
            this.lblDateIn.Size = new System.Drawing.Size(231, 25);
            this.lblDateIn.TabIndex = 14;
            this.lblDateIn.Text = "?";
            this.lblDateIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(416, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Người cho vào:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdClose
            // 
            this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClose.Location = new System.Drawing.Point(576, 160);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(88, 48);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "Đó&ng";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdIn
            // 
            this.cmdIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIn.Location = new System.Drawing.Point(12, 160);
            this.cmdIn.Name = "cmdIn";
            this.cmdIn.Size = new System.Drawing.Size(88, 48);
            this.cmdIn.TabIndex = 3;
            this.cmdIn.Text = "&Cho vào";
            this.cmdIn.UseVisualStyleBackColor = true;
            this.cmdIn.Click += new System.EventHandler(this.cmdIn_Click);
            // 
            // dgvAep
            // 
            this.dgvAep.AllowUserToAddRows = false;
            this.dgvAep.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAep.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvAep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNo_,
            this.colGroupId,
            this.colKindId,
            this.colGroupName,
            this.colKindName,
            this.colNumber,
            this.colAccIn,
            this.colPhone,
            this.colDateIn,
            this.colLength,
            this.colWeight,
            this.colChair});
            this.dgvAep.Location = new System.Drawing.Point(12, 214);
            this.dgvAep.Name = "dgvAep";
            this.dgvAep.ReadOnly = true;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAep.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvAep.Size = new System.Drawing.Size(994, 518);
            this.dgvAep.TabIndex = 2;
            this.dgvAep.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAep_CellClick);
            this.dgvAep.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAep_CellLeave);
            this.dgvAep.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAep_CellPainting);
            this.dgvAep.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAep_ColumnHeaderMouseClick);
            this.dgvAep.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAep_UserDeletingRow);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colNo_
            // 
            this.colNo_.DataPropertyName = "No_";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "0#";
            this.colNo_.DefaultCellStyle = dataGridViewCellStyle11;
            this.colNo_.HeaderText = "TT";
            this.colNo_.Name = "colNo_";
            this.colNo_.ReadOnly = true;
            this.colNo_.Width = 30;
            // 
            // colGroupId
            // 
            this.colGroupId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colGroupId.DataPropertyName = "GroupId";
            this.colGroupId.HeaderText = "GroupId";
            this.colGroupId.Name = "colGroupId";
            this.colGroupId.ReadOnly = true;
            this.colGroupId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGroupId.Visible = false;
            // 
            // colKindId
            // 
            this.colKindId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colKindId.DataPropertyName = "KindId";
            this.colKindId.HeaderText = "KindId";
            this.colKindId.Name = "colKindId";
            this.colKindId.ReadOnly = true;
            this.colKindId.Visible = false;
            // 
            // colGroupName
            // 
            this.colGroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colGroupName.DataPropertyName = "GroupName";
            this.colGroupName.HeaderText = "Nhóm xe";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.ReadOnly = true;
            this.colGroupName.Width = 96;
            // 
            // colKindName
            // 
            this.colKindName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colKindName.DataPropertyName = "KindName";
            this.colKindName.HeaderText = "Loại xe";
            this.colKindName.Name = "colKindName";
            this.colKindName.ReadOnly = true;
            // 
            // colNumber
            // 
            this.colNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNumber.DataPropertyName = "Number";
            this.colNumber.HeaderText = "Biển số xe";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            this.colNumber.Width = 84;
            // 
            // colAccIn
            // 
            this.colAccIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAccIn.DataPropertyName = "AccIn";
            this.colAccIn.HeaderText = "Người cho vào";
            this.colAccIn.Name = "colAccIn";
            this.colAccIn.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPhone.DataPropertyName = "Phone";
            this.colPhone.HeaderText = "Điện thoại";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 97;
            // 
            // colDateIn
            // 
            this.colDateIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDateIn.DataPropertyName = "DateIn";
            this.colDateIn.HeaderText = "Thời gian vào";
            this.colDateIn.Name = "colDateIn";
            this.colDateIn.ReadOnly = true;
            this.colDateIn.Width = 94;
            // 
            // colLength
            // 
            this.colLength.DataPropertyName = "Length";
            this.colLength.HeaderText = "Chiều dài";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 50;
            // 
            // colWeight
            // 
            this.colWeight.DataPropertyName = "Weight";
            this.colWeight.HeaderText = "Tải trọng";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            this.colWeight.Width = 50;
            // 
            // colChair
            // 
            this.colChair.DataPropertyName = "Chair";
            this.colChair.HeaderText = "Số ghế";
            this.colChair.Name = "colChair";
            this.colChair.ReadOnly = true;
            this.colChair.Width = 50;
            // 
            // cmdEdit
            // 
            this.cmdEdit.Enabled = false;
            this.cmdEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEdit.Location = new System.Drawing.Point(106, 160);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(88, 48);
            this.cmdEdit.TabIndex = 4;
            this.cmdEdit.Text = "&Sửa";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdInList
            // 
            this.cmdInList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdInList.Location = new System.Drawing.Point(294, 160);
            this.cmdInList.Name = "cmdInList";
            this.cmdInList.Size = new System.Drawing.Size(88, 48);
            this.cmdInList.TabIndex = 6;
            this.cmdInList.Text = "Xe trong &bến";
            this.cmdInList.UseVisualStyleBackColor = true;
            this.cmdInList.Click += new System.EventHandler(this.cmdInList_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Enabled = false;
            this.cmdDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Location = new System.Drawing.Point(200, 160);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(88, 48);
            this.cmdDelete.TabIndex = 5;
            this.cmdDelete.Text = "&Xoá";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // lblInf
            // 
            this.lblInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblInf.Location = new System.Drawing.Point(670, 160);
            this.lblInf.Name = "lblInf";
            this.lblInf.Size = new System.Drawing.Size(336, 48);
            this.lblInf.TabIndex = 10;
            this.lblInf.Text = "?";
            this.lblInf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRefresh.Location = new System.Drawing.Point(388, 160);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(88, 48);
            this.cmdRefresh.TabIndex = 7;
            this.cmdRefresh.Text = "&Cập nhật";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(814, 117);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mskTaxiNumber);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(806, 84);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TAXI VÃNG LAI";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mskTaxiNumber
            // 
            this.mskTaxiNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskTaxiNumber.Location = new System.Drawing.Point(110, 6);
            this.mskTaxiNumber.Name = "mskTaxiNumber";
            this.mskTaxiNumber.Size = new System.Drawing.Size(148, 31);
            this.mskTaxiNumber.TabIndex = 0;
            this.mskTaxiNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskTaxiNumber.Validating += new System.ComponentModel.CancelEventHandler(this.mskTaxiNumber_Validating);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Gray;
            this.label17.Location = new System.Drawing.Point(6, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 25);
            this.label17.TabIndex = 5;
            this.label17.Text = "Biển số:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.mskThreeNumber);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(806, 84);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "BA BÁNH";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mskThreeNumber
            // 
            this.mskThreeNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskThreeNumber.Location = new System.Drawing.Point(110, 6);
            this.mskThreeNumber.Name = "mskThreeNumber";
            this.mskThreeNumber.Size = new System.Drawing.Size(148, 31);
            this.mskThreeNumber.TabIndex = 0;
            this.mskThreeNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskThreeNumber.Validating += new System.ComponentModel.CancelEventHandler(this.mskThreeNumber_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Biển số:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.mskTruckL);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.mskTruckW);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.mskTruckNumber);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.cbbTruckKind);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(806, 84);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "TẢI L.ĐẬU & V.LAI";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // mskTruckL
            // 
            this.mskTruckL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskTruckL.Location = new System.Drawing.Point(723, 47);
            this.mskTruckL.Name = "mskTruckL";
            this.mskTruckL.Size = new System.Drawing.Size(77, 31);
            this.mskTruckL.TabIndex = 3;
            this.mskTruckL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(598, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 25);
            this.label10.TabIndex = 12;
            this.label10.Text = "Chiều dài:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mskTruckW
            // 
            this.mskTruckW.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskTruckW.Location = new System.Drawing.Point(477, 47);
            this.mskTruckW.Name = "mskTruckW";
            this.mskTruckW.Size = new System.Drawing.Size(77, 31);
            this.mskTruckW.TabIndex = 2;
            this.mskTruckW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(367, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 25);
            this.label9.TabIndex = 9;
            this.label9.Text = "Tải trọng:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mskTruckNumber
            // 
            this.mskTruckNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskTruckNumber.Location = new System.Drawing.Point(108, 44);
            this.mskTruckNumber.Name = "mskTruckNumber";
            this.mskTruckNumber.Size = new System.Drawing.Size(148, 31);
            this.mskTruckNumber.TabIndex = 1;
            this.mskTruckNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskTruckNumber.Validating += new System.ComponentModel.CancelEventHandler(this.mskTruckNumber_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(6, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Biển số:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbTruckKind
            // 
            this.cbbTruckKind.DisplayMember = "Name";
            this.cbbTruckKind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTruckKind.FormattingEnabled = true;
            this.cbbTruckKind.Location = new System.Drawing.Point(108, 6);
            this.cbbTruckKind.Name = "cbbTruckKind";
            this.cbbTruckKind.Size = new System.Drawing.Size(692, 32);
            this.cbbTruckKind.TabIndex = 0;
            this.cbbTruckKind.ValueMember = "Id";
            this.cbbTruckKind.SelectedIndexChanged += new System.EventHandler(this.cbbTruckKind_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(6, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Loại xe:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbbCarKind);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.mskCarNumber);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(806, 84);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "XE KHÁCH L.ĐẬU";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbbCarKind
            // 
            this.cbbCarKind.DisplayMember = "Name";
            this.cbbCarKind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCarKind.FormattingEnabled = true;
            this.cbbCarKind.Location = new System.Drawing.Point(108, 6);
            this.cbbCarKind.Name = "cbbCarKind";
            this.cbbCarKind.Size = new System.Drawing.Size(692, 32);
            this.cbbCarKind.TabIndex = 0;
            this.cbbCarKind.ValueMember = "Id";
            this.cbbCarKind.SelectedIndexChanged += new System.EventHandler(this.cbbCarKind_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Loại xe:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mskCarNumber
            // 
            this.mskCarNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskCarNumber.Location = new System.Drawing.Point(108, 44);
            this.mskCarNumber.Name = "mskCarNumber";
            this.mskCarNumber.Size = new System.Drawing.Size(148, 31);
            this.mskCarNumber.TabIndex = 1;
            this.mskCarNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskCarNumber.Validating += new System.ComponentModel.CancelEventHandler(this.mskCarNumber_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(6, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 25);
            this.label11.TabIndex = 9;
            this.label11.Text = "Biển số:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.mskMediumNumber);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.label48);
            this.tabPage5.Controls.Add(this.mskMediumC);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(806, 84);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "XE KHÁCH V.LAI, T.CHUYỂN";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // mskMediumNumber
            // 
            this.mskMediumNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskMediumNumber.Location = new System.Drawing.Point(110, 6);
            this.mskMediumNumber.Name = "mskMediumNumber";
            this.mskMediumNumber.Size = new System.Drawing.Size(148, 31);
            this.mskMediumNumber.TabIndex = 0;
            this.mskMediumNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskMediumNumber.Validating += new System.ComponentModel.CancelEventHandler(this.mskMediumNumber_Validating);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Gray;
            this.label16.Location = new System.Drawing.Point(6, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 25);
            this.label16.TabIndex = 12;
            this.label16.Text = "Biển số:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.Color.Gray;
            this.label48.Location = new System.Drawing.Point(6, 46);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(93, 25);
            this.label48.TabIndex = 11;
            this.label48.Text = "Số ghế:";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mskMediumC
            // 
            this.mskMediumC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskMediumC.Location = new System.Drawing.Point(110, 43);
            this.mskMediumC.Name = "mskMediumC";
            this.mskMediumC.Size = new System.Drawing.Size(53, 31);
            this.mskMediumC.TabIndex = 1;
            this.mskMediumC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpDateIn
            // 
            this.dtpDateIn.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDateIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateIn.Location = new System.Drawing.Point(214, 302);
            this.dtpDateIn.Name = "dtpDateIn";
            this.dtpDateIn.Size = new System.Drawing.Size(231, 26);
            this.dtpDateIn.TabIndex = 25;
            this.dtpDateIn.Visible = false;
            // 
            // cmdHand
            // 
            this.cmdHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdHand.Location = new System.Drawing.Point(482, 160);
            this.cmdHand.Name = "cmdHand";
            this.cmdHand.Size = new System.Drawing.Size(88, 48);
            this.cmdHand.TabIndex = 8;
            this.cmdHand.Text = "&Nhập bằng tay";
            this.cmdHand.UseVisualStyleBackColor = true;
            this.cmdHand.Click += new System.EventHandler(this.cmdHand_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(832, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 117);
            this.label3.TabIndex = 18;
            this.label3.Text = "CỔNG VÀO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmAfcVbq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 744);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdHand);
            this.Controls.Add(this.dtpDateIn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblAccInName);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDateIn);
            this.Controls.Add(this.lblInf);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdInList);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.dgvAep);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAfcVbq";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CỔNG VÀO";
            this.Load += new System.EventHandler(this.FrmAfcVbq_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAep)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrDongHo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDateIn;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdIn;
        private System.Windows.Forms.DataGridView dgvAep;
        private System.Windows.Forms.Label lblAccInName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdInList;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Label lblInf;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.MaskedTextBox mskMediumC;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.MaskedTextBox mskTaxiNumber;
        private System.Windows.Forms.MaskedTextBox mskThreeNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mskTruckL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox mskTruckW;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mskTruckNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbTruckKind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbCarKind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskCarNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox mskMediumNumber;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.DateTimePicker dtpDateIn;
        private System.Windows.Forms.Button cmdHand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKindId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKindName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChair;
        private System.Windows.Forms.Label label3;
    }
}