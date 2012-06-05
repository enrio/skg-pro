using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BXE.PRE.ObjDul
{
    public partial class FrmLgoSci : Form, UTL.PLG.ItfPlg
    {
        #region Contansts
        private const string STR_MENU = "&Loại xe";
        #endregion

        #region Default objects
        public UTL.BLL.UecLajVei _sss = new UTL.BLL.UecLajVei();
        private DataSet _dts = new DataSet();
        #endregion

        #region More objects
        private DAL.KindDAL _dal = new DAL.KindDAL();
        private DAL.Kind _obj = new DAL.Kind();
        #endregion

        #region Properties
        #endregion

        #region Implements
        string UTL.PLG.ItfPlg.Name { get { return STR_MENU; } }
        string UTL.PLG.ItfPlg.Description { get { return "Kind form"; } }
        string UTL.PLG.ItfPlg.Author { get { return "Zng Tfy"; } }
        string UTL.PLG.ItfPlg.Version { get { return "1.0"; } }

        UserControl UTL.PLG.ItfPlg.Usrcontrol { get { return null; } }
        Form UTL.PLG.ItfPlg.Frmcontrol { get { return this; } }
        UTL.PLG.ItfHst UTL.PLG.ItfPlg.Host { get; set; }

        public UTL.BLL.UecLajVei Sss { get { return _sss; } set { _sss = value; } }
        public UTL.CsoInf Inf { get; set; }

        void UTL.PLG.ItfPlg.Initialize() { }
        void UTL.PLG.ItfPlg.Dispose() { }
        #endregion

        #region Constructors
        public FrmLgoSci()
        {
            InitializeComponent();

            AddGroup();
        }
        #endregion

        #region Events
        private void FrmLgoSci_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void dgvAep_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            return;
            //using (var sf = new StringFormat { Alignment = StringAlignment.Center })
            //{
            //    if (e.ColumnIndex < 0 && e.RowIndex >= 0 && e.RowIndex < dgvAep.Rows.Count)
            //    {
            //        using (var drawBrush = new SolidBrush(Color.Black))
            //        {
            //            e.Graphics.DrawString((e.RowIndex + 1).ToString(), Font, drawBrush, e.CellBounds, sf);
            //        }
            //        e.Handled = true;
            //    }
            //}
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmdAdd.Text == "&Thêm") ResetAdd();
                else // save mode
                {
                    GetFromEditBox();

                    if (_dal.Insert(_obj))
                    {
                        UTL.CsoUTL.Show("Lưu thành công!");
                        Reset();
                    }
                    else UTL.CsoUTL.Show("Không lưu được!");
                }
            }
            catch { return; }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmdEdit.Text == "&Sửa") ResetEdit(false);
                else // save mode
                {
                    GetFromEditBox();

                    if (_dal.Update(_obj))
                    {
                        UTL.CsoUTL.Show("Lưu thành công!");
                        Reset();
                    }
                    else UTL.CsoUTL.Show("Không lưu được!");
                }
            }
            catch { return; }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dal.Delete(_obj))
                {
                    UTL.CsoUTL.Show("Xoá thành công!");
                    Reset();
                }
                else UTL.CsoUTL.Show("Không xoá được!");
            }
            catch { return; }
        }

        private void cmdRefresh_Click(object sender, EventArgs e) { Reset(); }

        private void dgvAep_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Stt();
        }

        private void dgvAep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                GetFromGridView(e.RowIndex); // get current user object

                // Show information in form
                txtName.Text = _obj.Name;
                cbbGroupId.SelectedValue = _obj.GroupId;
                txtDescript.Text = _obj.Descript;
                txtChairMax.Text = _obj.ChairMax.Value.ToString();
                txtChairMin.Text = _obj.ChairMin.Value.ToString();
                txtLengthMax.Text = _obj.LengthMax.Value.ToString();
                txtLengthMin.Text = _obj.LengthMin.Value.ToString();
                txtWeightMin.Text = _obj.WeightMin.Value.ToString();
                txtWeightMax.Text = _obj.WeightMax.Value.ToString();
                txtPrice1.Text = _obj.Money1.Value.ToString();
                txtPrice2.Text = _obj.Money2.Value.ToString();

                if (cmdEdit.Enabled == false) ResetEdit(); // edit mode
            }
            catch { return; }
        }
        #endregion

        #region Methods
        private void AddGroup()
        {
            try
            {
                var dtb = (new DAL.GroupDAL()).GetData();

                cbbGroupId.DataSource = dtb;
                cbbGroupId.DisplayMember = "Name";
                cbbGroupId.ValueMember = "Id";

                colGroupId.DataSource = dtb;
                colGroupId.DisplayMember = "Name";
                colGroupId.ValueMember = "Id";
                colGroupId.ValueType = typeof(long);
            }
            catch { return; }
        }

        private void LoadData()
        {
            dgvAep.DataSource = _dal.GetData();
        }

        private void ReadOnly(bool isReadOnly = true)
        {
            txtName.ReadOnly = isReadOnly;
            txtChairMin.ReadOnly = isReadOnly;
            txtChairMax.ReadOnly = isReadOnly;
            txtWeightMax.ReadOnly = isReadOnly;
            txtWeightMin.ReadOnly = isReadOnly;
            txtLengthMax.ReadOnly = isReadOnly;
            txtLengthMin.ReadOnly = isReadOnly;
            txtPrice1.ReadOnly = isReadOnly;
            txtPrice2.ReadOnly = isReadOnly;
            txtDescript.ReadOnly = isReadOnly;
            cbbGroupId.Enabled = !isReadOnly;
        }

        private void ClearText()
        {
            txtName.Text = null;
            txtChairMin.Text = null;
            txtChairMax.Text = null;
            txtWeightMax.Text = null;
            txtWeightMin.Text = null;
            txtLengthMax.Text = null;
            txtLengthMin.Text = null;
            txtPrice1.Text = null;
            txtPrice2.Text = null;
            txtDescript.Text = null;
            cbbGroupId.SelectedValue = cbbGroupId.Items.Count - 1;
        }

        private void ResetAdd()
        {
            cmdAdd.Text = "&Lưu"; cmdAdd.Enabled = true;
            cmdEdit.Text = "&Sửa"; cmdEdit.Enabled = false;
            cmdDelete.Text = "&Xoá"; cmdDelete.Enabled = false;
            cmdRefresh.Text = "&Huỷ";
            ClearText(); ReadOnly(false);
        }

        private void ResetEdit(bool isEdit = true)
        {
            if (isEdit)
            {
                cmdAdd.Text = "&Thêm"; cmdAdd.Enabled = true;
                cmdEdit.Enabled = true;
                cmdDelete.Text = "&Xoá"; cmdDelete.Enabled = true;
            }
            else
            {
                cmdEdit.Text = "&Lưu";
                cmdRefresh.Text = "&Huỷ";
                ReadOnly(false);
            }
        }

        private void Reset()
        {
            cmdAdd.Text = "&Thêm"; cmdAdd.Enabled = true;
            cmdEdit.Text = "&Sửa"; cmdEdit.Enabled = false;
            cmdDelete.Text = "&Xoá"; cmdDelete.Enabled = false;
            cmdRefresh.Text = "&Làm mới";

            ClearText(); ReadOnly(); LoadData();
        }

        private void GetFromEditBox()
        {
            _obj.Name = txtName.Text;
            _obj.GroupId = Convert.ToInt32(cbbGroupId.SelectedValue);
            _obj.Descript = txtDescript.Text;

            int c1, c2;
            Int32.TryParse(txtChairMin.Text, out c1);
            Int32.TryParse(txtChairMax.Text, out c2);
            _obj.ChairMin = c1;
            _obj.ChairMax = c2;

            decimal l1, l2;
            Decimal.TryParse(txtLengthMin.Text, out l1);
            Decimal.TryParse(txtLengthMax.Text, out l2);
            _obj.LengthMin = l1;
            _obj.LengthMax = l2;

            Decimal.TryParse(txtWeightMin.Text, out l1);
            Decimal.TryParse(txtWeightMax.Text, out l2);
            _obj.WeightMax = l1;
            _obj.WeightMin = l2;

            Decimal.TryParse(txtPrice1.Text, out l1);
            Decimal.TryParse(txtPrice1.Text, out l2);
            _obj.Money1 = l1;
            _obj.Money2 = l2;

            _obj.Type = "VNĐ";
        }

        private void GetFromGridView(int rowIndex)
        {
            _obj.Id = Convert.ToInt64(dgvAep.Rows[rowIndex].Cells["colId"].Value);
            _obj.Name = dgvAep.Rows[rowIndex].Cells["colName"].Value + "";
            _obj.GroupId = Convert.ToInt32(dgvAep.Rows[rowIndex].Cells["colGroupId"].Value);
            _obj.Descript = dgvAep.Rows[rowIndex].Cells["colDescript"].Value + "";

            int c1, c2;
            Int32.TryParse(dgvAep.Rows[rowIndex].Cells["colChairMin"].Value + "", out c1);
            Int32.TryParse(dgvAep.Rows[rowIndex].Cells["colChairMax"].Value + "", out c2);
            _obj.ChairMin = c1;
            _obj.ChairMax = c2;

            decimal l1, l2;
            Decimal.TryParse(dgvAep.Rows[rowIndex].Cells["colLengthMin"].Value + "", out l1);
            Decimal.TryParse(dgvAep.Rows[rowIndex].Cells["colLengthMax"].Value + "", out l2);
            _obj.LengthMin = l1;
            _obj.LengthMax = l2;

            Decimal.TryParse(dgvAep.Rows[rowIndex].Cells["colWeightMin"].Value + "", out l1);
            Decimal.TryParse(dgvAep.Rows[rowIndex].Cells["colWeightMax"].Value + "", out l2);
            _obj.WeightMax = l1;
            _obj.WeightMin = l2;

            Decimal.TryParse(dgvAep.Rows[rowIndex].Cells["colPrice1"].Value + "", out l1);
            Decimal.TryParse(dgvAep.Rows[rowIndex].Cells["colPrice1"].Value + "", out l2);
            _obj.Money1 = l1;
            _obj.Money2 = l2;

            _obj.Type = "VNĐ";
        }

        private void Stt()
        {
            for (int i = 0; i < dgvAep.Rows.Count; i++)
                dgvAep.Rows[i].Cells["colNo_"].Value = i + 1;
        }
        #endregion

        #region More
        #endregion
    }
}