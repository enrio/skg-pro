using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SKG.Reader
{
    public partial class FrmTransfer : Form
    {
        readonly ExcelReader _exr;
        SqlReader _sqr;

        public FrmTransfer()
        {
            InitializeComponent();
            _exr = new ExcelReader();
            _sqr = new SqlReader();
        }

        private void frmTransfer_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
        }

        private void cmdOpenExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dag = new OpenFileDialog { Filter = "Excel files 97 - 2003(*.xls)|*.xls|Excel files 2007 - 2010(*.xlsx)|*.xlsx" })
                {
                    if (dag.ShowDialog(this) == DialogResult.Cancel)
                        return;
                    cboExcelSheet.Items.Clear();
                    cboExcelSheet.Text = null;
                    foreach (string s in _exr.GetTable(dag.FileName))
                        cboExcelSheet.Items.Add(s);
                }
                if (cboExcelSheet.Items.Count > 0)
                {
                    cboExcelSheet.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdOpenSql_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new FrmConfig())
                {
                    frm.ShowDialog();
                    if (!frm._status) return;
                    if (frm.txtLogin.Enabled)
                    {
                        _sqr = new SqlReader(frm.cboSQLServer.Text, frm.cboDBName.Text, frm.txtLogin.Text, frm.txtPassword.Text);
                    }
                    else
                    {
                        _sqr = new SqlReader(frm.cboSQLServer.Text, frm.cboDBName.Text);
                    }
                }
                cboSqlTable.Items.Clear();
                cboSqlTable.Text = null;
                foreach (string s in _sqr.GetTable())
                {
                    cboSqlTable.Items.Add(s);
                }
                if (cboSqlTable.Items.Count > 0)
                {
                    cboSqlTable.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdLoadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                dgvExcel.DataSource = _exr.GetData(cboExcelSheet.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdLoadSql_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSql.DataSource = _sqr.GetData(cboSqlTable.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdCopy2Sql_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable tbl = _exr.GetData(cboExcelSheet.SelectedItem.ToString());
                int i = _sqr.InsertData(tbl, cboSqlTable.SelectedItem.ToString());
                MessageBox.Show(String.Format("Sum of row(s): {0}", i));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboExcelSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tbl = _exr.GetColumn(cboExcelSheet.SelectedItem.ToString());
                dgvExcel.DataSource = tbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboSqlTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable tbl = _sqr.GetColumn(cboSqlTable.SelectedItem.ToString());
                dgvSql.DataSource = tbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}