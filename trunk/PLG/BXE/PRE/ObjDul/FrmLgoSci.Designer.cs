namespace BXE.PRE.ObjDul
{
    partial class FrmLgoSci
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbGroupId = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescript = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChairMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChairMin = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgvAep = new System.Windows.Forms.DataGridView();
            this.ctmDelRow = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmDelPass = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ctmSetPass = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.ctmMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtWeightMin = new System.Windows.Forms.TextBox();
            this.txtWeightMax = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLengthMin = new System.Windows.Forms.TextBox();
            this.txtLengthMax = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPrice1 = new System.Windows.Forms.TextBox();
            this.txtPrice2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNo_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDescript = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLengthMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLengthMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeightMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeightMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChairMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChairMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAep)).BeginInit();
            this.ctmMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(758, 108);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(54, 30);
            this.cmdRefresh.TabIndex = 30;
            this.cmdRefresh.Text = "&Làm mới";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Enabled = false;
            this.cmdDelete.Location = new System.Drawing.Point(698, 109);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(54, 30);
            this.cmdDelete.TabIndex = 28;
            this.cmdDelete.Text = "&Xoá";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Enabled = false;
            this.cmdEdit.Location = new System.Drawing.Point(638, 108);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(54, 30);
            this.cmdEdit.TabIndex = 29;
            this.cmdEdit.Text = "&Sửa";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(578, 108);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(54, 30);
            this.cmdAdd.TabIndex = 27;
            this.cmdAdd.Text = "&Thêm";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Nhóm xe:";
            // 
            // cbbGroupId
            // 
            this.cbbGroupId.FormattingEnabled = true;
            this.cbbGroupId.Location = new System.Drawing.Point(80, 38);
            this.cbbGroupId.Name = "cbbGroupId";
            this.cbbGroupId.Size = new System.Drawing.Size(372, 21);
            this.cbbGroupId.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(578, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mô tả:";
            // 
            // txtDescript
            // 
            this.txtDescript.Location = new System.Drawing.Point(578, 80);
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.Size = new System.Drawing.Size(234, 20);
            this.txtDescript.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tối thiểu:";
            // 
            // txtChairMax
            // 
            this.txtChairMax.Location = new System.Drawing.Point(63, 41);
            this.txtChairMax.Name = "txtChairMax";
            this.txtChairMax.Size = new System.Drawing.Size(41, 20);
            this.txtChairMax.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tối đa:";
            // 
            // txtChairMin
            // 
            this.txtChairMin.Location = new System.Drawing.Point(63, 15);
            this.txtChairMin.Name = "txtChairMin";
            this.txtChairMin.Size = new System.Drawing.Size(41, 20);
            this.txtChairMin.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(372, 20);
            this.txtName.TabIndex = 1;
            // 
            // dgvAep
            // 
            this.dgvAep.AllowUserToAddRows = false;
            this.dgvAep.AllowUserToDeleteRows = false;
            this.dgvAep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNo_,
            this.colName,
            this.colGroupId,
            this.colDescript,
            this.colType,
            this.colLengthMin,
            this.colLengthMax,
            this.colWeightMin,
            this.colWeightMax,
            this.colChairMin,
            this.colChairMax,
            this.colPrice1,
            this.colPrice2});
            this.dgvAep.Location = new System.Drawing.Point(12, 144);
            this.dgvAep.Name = "dgvAep";
            this.dgvAep.ReadOnly = true;
            this.dgvAep.Size = new System.Drawing.Size(800, 301);
            this.dgvAep.TabIndex = 31;
            this.dgvAep.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAep_CellClick);
            this.dgvAep.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAep_CellPainting);
            this.dgvAep.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAep_ColumnHeaderMouseClick);
            // 
            // ctmDelRow
            // 
            this.ctmDelRow.Name = "ctmDelRow";
            this.ctmDelRow.Size = new System.Drawing.Size(151, 22);
            this.ctmDelRow.Text = "Xoá &dòng này";
            // 
            // ctmDelPass
            // 
            this.ctmDelPass.Name = "ctmDelPass";
            this.ctmDelPass.Size = new System.Drawing.Size(151, 22);
            this.ctmDelPass.Text = "&Xoá mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên loại xe:";
            // 
            // ctmSetPass
            // 
            this.ctmSetPass.Name = "ctmSetPass";
            this.ctmSetPass.Size = new System.Drawing.Size(151, 22);
            this.ctmSetPass.Text = "Đặt mật khẩu";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(458, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(354, 47);
            this.label6.TabIndex = 4;
            this.label6.Text = "DANH MỤC LOẠI XE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctmMain
            // 
            this.ctmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctmSetPass,
            this.ctmDelPass,
            this.ctmDelRow});
            this.ctmMain.Name = "ctmMain";
            this.ctmMain.Size = new System.Drawing.Size(152, 70);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtChairMin);
            this.groupBox1.Controls.Add(this.txtChairMax);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 73);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Số ghế (SG)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtWeightMin);
            this.groupBox2.Controls.Add(this.txtWeightMax);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(135, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 73);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tải trọng (TT)";
            // 
            // txtWeightMin
            // 
            this.txtWeightMin.Location = new System.Drawing.Point(63, 15);
            this.txtWeightMin.Name = "txtWeightMin";
            this.txtWeightMin.Size = new System.Drawing.Size(41, 20);
            this.txtWeightMin.TabIndex = 14;
            // 
            // txtWeightMax
            // 
            this.txtWeightMax.Location = new System.Drawing.Point(63, 41);
            this.txtWeightMax.Name = "txtWeightMax";
            this.txtWeightMax.Size = new System.Drawing.Size(41, 20);
            this.txtWeightMax.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Tối thiểu:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Tối đa:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLengthMin);
            this.groupBox3.Controls.Add(this.txtLengthMax);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(255, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(114, 73);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chiều dài (CD)";
            // 
            // txtLengthMin
            // 
            this.txtLengthMin.Location = new System.Drawing.Point(63, 15);
            this.txtLengthMin.Name = "txtLengthMin";
            this.txtLengthMin.Size = new System.Drawing.Size(41, 20);
            this.txtLengthMin.TabIndex = 19;
            // 
            // txtLengthMax
            // 
            this.txtLengthMax.Location = new System.Drawing.Point(63, 41);
            this.txtLengthMax.Name = "txtLengthMax";
            this.txtLengthMax.Size = new System.Drawing.Size(41, 20);
            this.txtLengthMax.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Tối thiểu:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Tối đa:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPrice1);
            this.groupBox4.Controls.Add(this.txtPrice2);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(375, 65);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(197, 73);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Đơn giá (ĐG)";
            // 
            // txtPrice1
            // 
            this.txtPrice1.Location = new System.Drawing.Point(92, 15);
            this.txtPrice1.Name = "txtPrice1";
            this.txtPrice1.Size = new System.Drawing.Size(99, 20);
            this.txtPrice1.TabIndex = 24;
            // 
            // txtPrice2
            // 
            this.txtPrice2.Location = new System.Drawing.Point(92, 41);
            this.txtPrice2.Name = "txtPrice2";
            this.txtPrice2.Size = new System.Drawing.Size(99, 20);
            this.txtPrice2.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Nửa ngày (1):";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Một ngày (2):";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "0#";
            this.colNo_.DefaultCellStyle = dataGridViewCellStyle1;
            this.colNo_.HeaderText = "TT";
            this.colNo_.Name = "colNo_";
            this.colNo_.ReadOnly = true;
            this.colNo_.Width = 30;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Tên loại xe";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colGroupId
            // 
            this.colGroupId.DataPropertyName = "GroupId";
            this.colGroupId.HeaderText = "Nhóm xe";
            this.colGroupId.Name = "colGroupId";
            this.colGroupId.ReadOnly = true;
            this.colGroupId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGroupId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colDescript
            // 
            this.colDescript.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDescript.DataPropertyName = "Descript";
            this.colDescript.HeaderText = "Mô tả";
            this.colDescript.Name = "colDescript";
            this.colDescript.ReadOnly = true;
            this.colDescript.Width = 59;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "Loại tiền";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Visible = false;
            this.colType.Width = 5;
            // 
            // colLengthMin
            // 
            this.colLengthMin.DataPropertyName = "LengthMin";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "0.0";
            dataGridViewCellStyle2.NullValue = "-";
            this.colLengthMin.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLengthMin.HeaderText = "CD tối thiểu";
            this.colLengthMin.Name = "colLengthMin";
            this.colLengthMin.ReadOnly = true;
            this.colLengthMin.Width = 30;
            // 
            // colLengthMax
            // 
            this.colLengthMax.DataPropertyName = "LengthMax";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "0.0";
            dataGridViewCellStyle3.NullValue = "-";
            this.colLengthMax.DefaultCellStyle = dataGridViewCellStyle3;
            this.colLengthMax.HeaderText = "CD tối đa";
            this.colLengthMax.Name = "colLengthMax";
            this.colLengthMax.ReadOnly = true;
            this.colLengthMax.Width = 30;
            // 
            // colWeightMin
            // 
            this.colWeightMin.DataPropertyName = "WeightMin";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "0.0";
            dataGridViewCellStyle4.NullValue = "-";
            this.colWeightMin.DefaultCellStyle = dataGridViewCellStyle4;
            this.colWeightMin.HeaderText = "TT tối thiểu";
            this.colWeightMin.Name = "colWeightMin";
            this.colWeightMin.ReadOnly = true;
            this.colWeightMin.Width = 30;
            // 
            // colWeightMax
            // 
            this.colWeightMax.DataPropertyName = "WeightMax";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "0.0";
            dataGridViewCellStyle5.NullValue = "-";
            this.colWeightMax.DefaultCellStyle = dataGridViewCellStyle5;
            this.colWeightMax.HeaderText = "TT tối đa";
            this.colWeightMax.Name = "colWeightMax";
            this.colWeightMax.ReadOnly = true;
            this.colWeightMax.Width = 30;
            // 
            // colChairMin
            // 
            this.colChairMin.DataPropertyName = "ChairMin";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "0";
            dataGridViewCellStyle6.NullValue = "-";
            this.colChairMin.DefaultCellStyle = dataGridViewCellStyle6;
            this.colChairMin.HeaderText = "SG tối thiểu";
            this.colChairMin.Name = "colChairMin";
            this.colChairMin.ReadOnly = true;
            this.colChairMin.Width = 30;
            // 
            // colChairMax
            // 
            this.colChairMax.DataPropertyName = "ChairMax";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "0";
            dataGridViewCellStyle7.NullValue = "-";
            this.colChairMax.DefaultCellStyle = dataGridViewCellStyle7;
            this.colChairMax.HeaderText = "SG tối đa";
            this.colChairMax.Name = "colChairMax";
            this.colChairMax.ReadOnly = true;
            this.colChairMax.Width = 30;
            // 
            // colPrice1
            // 
            this.colPrice1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colPrice1.DataPropertyName = "Money1";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "0,0";
            dataGridViewCellStyle8.NullValue = "-";
            this.colPrice1.DefaultCellStyle = dataGridViewCellStyle8;
            this.colPrice1.HeaderText = "ĐG 1";
            this.colPrice1.Name = "colPrice1";
            this.colPrice1.ReadOnly = true;
            this.colPrice1.Width = 48;
            // 
            // colPrice2
            // 
            this.colPrice2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colPrice2.DataPropertyName = "Money2";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "0,0";
            dataGridViewCellStyle9.NullValue = "-";
            this.colPrice2.DefaultCellStyle = dataGridViewCellStyle9;
            this.colPrice2.HeaderText = "ĐG 2";
            this.colPrice2.Name = "colPrice2";
            this.colPrice2.ReadOnly = true;
            this.colPrice2.Width = 48;
            // 
            // FrmLgoSci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 457);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cbbGroupId);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dgvAep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescript);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmLgoSci";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục loại xe";
            this.Load += new System.EventHandler(this.FrmLgoSci_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAep)).EndInit();
            this.ctmMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbGroupId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescript;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChairMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChairMin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgvAep;
        private System.Windows.Forms.ToolStripMenuItem ctmDelRow;
        private System.Windows.Forms.ToolStripMenuItem ctmDelPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem ctmSetPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip ctmMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtWeightMin;
        private System.Windows.Forms.TextBox txtWeightMax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLengthMin;
        private System.Windows.Forms.TextBox txtLengthMax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPrice1;
        private System.Windows.Forms.TextBox txtPrice2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescript;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLengthMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLengthMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeightMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeightMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChairMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChairMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice2;
    }
}