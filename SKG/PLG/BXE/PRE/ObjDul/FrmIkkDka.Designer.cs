namespace BXE.PRE.ObjDul
{
    partial class FrmIkkDka
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
            this.label6 = new System.Windows.Forms.Label();
            this.dgvAep = new System.Windows.Forms.DataGridView();
            this.ctmMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctmSetPass = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmDelPass = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmDelRow = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.cbbRole = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNo_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAep)).BeginInit();
            this.ctmMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(477, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(270, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "QUẢN LÍ NGƯỜI DÙNG";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvAep
            // 
            this.dgvAep.AllowUserToAddRows = false;
            this.dgvAep.AllowUserToDeleteRows = false;
            this.dgvAep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNo_,
            this.colAcc,
            this.colPass,
            this.colName,
            this.colBirth,
            this.colAddress,
            this.colPhone,
            this.colRole});
            this.dgvAep.Location = new System.Drawing.Point(12, 91);
            this.dgvAep.Name = "dgvAep";
            this.dgvAep.ReadOnly = true;
            this.dgvAep.Size = new System.Drawing.Size(735, 345);
            this.dgvAep.TabIndex = 19;
            this.dgvAep.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAep_CellClick);
            this.dgvAep.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAep_CellEndEdit);
            this.dgvAep.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAep_CellPainting);
            this.dgvAep.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAep_ColumnHeaderMouseClick);
            this.dgvAep.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAep_DataError);
            this.dgvAep.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvAep_RowValidating);
            this.dgvAep.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAep_UserDeletingRow);
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
            // ctmSetPass
            // 
            this.ctmSetPass.Name = "ctmSetPass";
            this.ctmSetPass.Size = new System.Drawing.Size(151, 22);
            this.ctmSetPass.Text = "Đặt mật khẩu";
            // 
            // ctmDelPass
            // 
            this.ctmDelPass.Name = "ctmDelPass";
            this.ctmDelPass.Size = new System.Drawing.Size(151, 22);
            this.ctmDelPass.Text = "&Xoá mật khẩu";
            // 
            // ctmDelRow
            // 
            this.ctmDelRow.Name = "ctmDelRow";
            this.ctmDelRow.Size = new System.Drawing.Size(151, 22);
            this.ctmDelRow.Text = "Xoá &dòng này";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài khoản:";
            // 
            // txtAcc
            // 
            this.txtAcc.Location = new System.Drawing.Point(76, 12);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(95, 20);
            this.txtAcc.TabIndex = 1;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(76, 38);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(95, 20);
            this.txtPass.TabIndex = 3;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(76, 64);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(95, 20);
            this.txtName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Họ tên:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(240, 38);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(231, 20);
            this.txtAddress.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày sinh:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(393, 13);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(78, 20);
            this.txtPhone.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Địa chỉ:";
            // 
            // dtpBirth
            // 
            this.dtpBirth.CustomFormat = "dd/MM/yyyy";
            this.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirth.Location = new System.Drawing.Point(240, 12);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(83, 20);
            this.dtpBirth.TabIndex = 7;
            // 
            // cbbRole
            // 
            this.cbbRole.FormattingEnabled = true;
            this.cbbRole.Location = new System.Drawing.Point(240, 64);
            this.cbbRole.Name = "cbbRole";
            this.cbbRole.Size = new System.Drawing.Size(231, 21);
            this.cbbRole.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(177, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Quyền:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(329, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Điện thoại:";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(513, 55);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(54, 30);
            this.cmdAdd.TabIndex = 15;
            this.cmdAdd.Text = "&Thêm";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Enabled = false;
            this.cmdEdit.Location = new System.Drawing.Point(573, 55);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(54, 30);
            this.cmdEdit.TabIndex = 16;
            this.cmdEdit.Text = "&Sửa";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Enabled = false;
            this.cmdDelete.Location = new System.Drawing.Point(633, 55);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(54, 30);
            this.cmdDelete.TabIndex = 17;
            this.cmdDelete.Text = "&Xoá";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(693, 55);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(54, 30);
            this.cmdRefresh.TabIndex = 18;
            this.cmdRefresh.Text = "&Làm mới";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
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
            // colAcc
            // 
            this.colAcc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colAcc.DataPropertyName = "Acc";
            this.colAcc.HeaderText = "Tài khoản";
            this.colAcc.Name = "colAcc";
            this.colAcc.ReadOnly = true;
            this.colAcc.Width = 80;
            // 
            // colPass
            // 
            this.colPass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colPass.DataPropertyName = "Pass";
            this.colPass.HeaderText = "Mật khẩu";
            this.colPass.Name = "colPass";
            this.colPass.ReadOnly = true;
            this.colPass.Visible = false;
            this.colPass.Width = 77;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Họ tên";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 64;
            // 
            // colBirth
            // 
            this.colBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colBirth.DataPropertyName = "Birth";
            this.colBirth.HeaderText = "Ngày sinh";
            this.colBirth.Name = "colBirth";
            this.colBirth.ReadOnly = true;
            this.colBirth.Width = 79;
            // 
            // colAddress
            // 
            this.colAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAddress.DataPropertyName = "Address";
            this.colAddress.HeaderText = "Địa chỉ";
            this.colAddress.Name = "colAddress";
            this.colAddress.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colPhone.DataPropertyName = "Phone";
            this.colPhone.HeaderText = "Điện thoại";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 80;
            // 
            // colRole
            // 
            this.colRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colRole.DataPropertyName = "Role";
            this.colRole.HeaderText = "Quyền";
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            this.colRole.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colRole.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colRole.Width = 63;
            // 
            // FrmIkkDka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 448);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbbRole);
            this.Controls.Add(this.dtpBirth);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAcc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAep);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmIkkDka";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÍ NGƯỜI DÙNG";
            this.Load += new System.EventHandler(this.FrmIkkDka_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAep)).EndInit();
            this.ctmMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvAep;
        private System.Windows.Forms.ContextMenuStrip ctmMain;
        private System.Windows.Forms.ToolStripMenuItem ctmSetPass;
        private System.Windows.Forms.ToolStripMenuItem ctmDelPass;
        private System.Windows.Forms.ToolStripMenuItem ctmDelRow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.ComboBox cbbRole;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewComboBoxColumn colRole;
    }
}