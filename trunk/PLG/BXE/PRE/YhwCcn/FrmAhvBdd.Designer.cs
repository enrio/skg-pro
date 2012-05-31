namespace BXE.PRE.YhwCcn
{
    partial class FrmAhvBdd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAep = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNo_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKindName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInf = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.cmdRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(544, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH XE TRONG BẾN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvAep
            // 
            this.dgvAep.AllowUserToAddRows = false;
            this.dgvAep.AllowUserToDeleteRows = false;
            this.dgvAep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNo_,
            this.colNumber,
            this.colGroupName,
            this.colKindName,
            this.colAccIn,
            this.colPhone,
            this.colDateIn,
            this.colChair,
            this.colWeight,
            this.colLength});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAep.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAep.Location = new System.Drawing.Point(12, 68);
            this.dgvAep.Name = "dgvAep";
            this.dgvAep.ReadOnly = true;
            this.dgvAep.Size = new System.Drawing.Size(925, 512);
            this.dgvAep.TabIndex = 2;
            this.dgvAep.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAep_CellPainting);
            this.dgvAep.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAep_ColumnHeaderMouseClick);
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
            this.colNo_.DefaultCellStyle = dataGridViewCellStyle1;
            this.colNo_.HeaderText = "TT";
            this.colNo_.Name = "colNo_";
            this.colNo_.ReadOnly = true;
            this.colNo_.Width = 30;
            // 
            // colNumber
            // 
            this.colNumber.DataPropertyName = "Number";
            this.colNumber.HeaderText = "Biển số xe";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
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
            this.colKindName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colKindName.DataPropertyName = "KindName";
            this.colKindName.HeaderText = "Loại xe";
            this.colKindName.Name = "colKindName";
            this.colKindName.ReadOnly = true;
            // 
            // colAccIn
            // 
            this.colAccIn.DataPropertyName = "AccIn";
            this.colAccIn.HeaderText = "Người cho vào";
            this.colAccIn.Name = "colAccIn";
            this.colAccIn.ReadOnly = true;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "Phone";
            this.colPhone.HeaderText = "Điện thoại";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colDateIn
            // 
            this.colDateIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDateIn.DataPropertyName = "DateIn";
            this.colDateIn.HeaderText = "Thời gian vào";
            this.colDateIn.Name = "colDateIn";
            this.colDateIn.ReadOnly = true;
            this.colDateIn.Width = 97;
            // 
            // colChair
            // 
            this.colChair.DataPropertyName = "Chair";
            this.colChair.HeaderText = "Số ghế";
            this.colChair.Name = "colChair";
            this.colChair.ReadOnly = true;
            this.colChair.Width = 30;
            // 
            // colWeight
            // 
            this.colWeight.DataPropertyName = "Weight";
            this.colWeight.HeaderText = "Tải trọng";
            this.colWeight.Name = "colWeight";
            this.colWeight.ReadOnly = true;
            this.colWeight.Width = 30;
            // 
            // colLength
            // 
            this.colLength.DataPropertyName = "Length";
            this.colLength.HeaderText = "Chiều dài";
            this.colLength.Name = "colLength";
            this.colLength.ReadOnly = true;
            this.colLength.Width = 30;
            // 
            // lblInf
            // 
            this.lblInf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblInf.Location = new System.Drawing.Point(562, 9);
            this.lblInf.Name = "lblInf";
            this.lblInf.Size = new System.Drawing.Size(375, 24);
            this.lblInf.TabIndex = 1;
            this.lblInf.Text = "?";
            this.lblInf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Biển số xe:";
            // 
            // txtNumber
            // 
            this.txtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumber.Location = new System.Drawing.Point(115, 36);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(111, 26);
            this.txtNumber.TabIndex = 4;
            this.txtNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumber_KeyUp);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(232, 36);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(84, 26);
            this.cmdRefresh.TabIndex = 5;
            this.cmdRefresh.Text = "&Cập nhật";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // FrmAhvBdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 592);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInf);
            this.Controls.Add(this.dgvAep);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAhvBdd";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách xe trong bến";
            this.Load += new System.EventHandler(this.FrmAhvBdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAep;
        private System.Windows.Forms.Label lblInf;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo_;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKindName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChair;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button cmdRefresh;
    }
}