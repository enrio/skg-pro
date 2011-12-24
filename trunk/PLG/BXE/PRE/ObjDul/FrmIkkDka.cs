using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace BXE.PRE.ObjDul
{
    public partial class FrmIkkDka : Form, UTL.PLG.ItfPlg
    {
        #region Contansts
        private const string STR_MENU = "Người &dùng";
        #endregion

        #region Default objects
        public UTL.BLL.UecLajVei _sss = new UTL.BLL.UecLajVei();
        private DataSet _dts = new DataSet();
        #endregion

        #region More objects
        private DAL.UserDAL _dal = new DAL.UserDAL();
        private DAL.User _obj = new DAL.User();
        private readonly DataTable _role = new DataTable("Role");
        #endregion

        #region Properties
        #endregion

        #region Implements
        string UTL.PLG.ItfPlg.Name { get { return STR_MENU; } }
        string UTL.PLG.ItfPlg.Description { get { return "User form"; } }
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
        public FrmIkkDka()
        {
            InitializeComponent();

            CreateRole();
        }
        #endregion

        #region Events
        private void FrmIkkDka_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void dgvAep_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CellEndEdit(e.RowIndex);
        }

        private void dgvAep_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            return;
            using (var sf = new StringFormat { Alignment = StringAlignment.Center })
            {
                if (e.ColumnIndex < 0 && e.RowIndex >= 0 && e.RowIndex < dgvAep.Rows.Count)
                {
                    using (var drawBrush = new SolidBrush(Color.Black))
                    {
                        e.Graphics.DrawString((e.RowIndex + 1).ToString(), Font, drawBrush, e.CellBounds, sf);
                    }
                    e.Handled = true;
                }
            }
        }

        private void dgvAep_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            UTL.CsoUTL.Show("Lỗi nhập ngày tháng năm!");
        }

        private void dgvAep_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                var m = _dts.GetChanges(DataRowState.Modified);
                var a = _dts.GetChanges(DataRowState.Added);

                if (m != null) // update
                {
                    foreach (DataRow dtr in m.Tables[0].Rows)
                    {
                        var usr = ProcessRow(dtr);
                        if (_dal.Update(usr)) _dts.AcceptChanges();
                        else UTL.CsoUTL.Show("Không sửa được!");
                    }
                }

                if (a != null) // insert
                {
                    foreach (DataRow dtr in a.Tables[0].Rows)
                    {
                        var usr = ProcessRow(dtr);
                        if (_dal.Insert(usr)) _dts.AcceptChanges();
                        else UTL.CsoUTL.Show("Không thêm được!");
                    }
                }
            }
            catch { return; }
        }

        private void dgvAep_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                object id = e.Row.Cells["colId"].Value;
                id = id + "" == "" ? -1 : id;

                if (_dal.Delete(new DAL.User() { Id = Convert.ToInt64(id) }))
                    UTL.CsoUTL.Show("Xoá thành công!");
                else
                {
                    UTL.CsoUTL.Show("Không xoá được!");
                    e.Cancel = true;
                }
            }
            catch
            {
                UTL.CsoUTL.Show("Lỗi xoá dữ liệu!");
                e.Cancel = true;
            }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmdAdd.Text == "&Thêm") ResetAdd();
                else // save mode
                {
                    var usr = new DAL.User()
                    {
                        Acc = txtAcc.Text,
                        Pass = txtPass.Text,
                        Name = txtName.Text,
                        Birth = dtpBirth.Value,
                        Phone = txtPhone.Text,
                        Address = txtAddress.Text,
                        Role = Convert.ToInt32(cbbRole.SelectedValue)
                    };

                    if (_dal.Insert(usr))
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
                    // Update current edit user object                    
                    _obj.Acc = txtAcc.Text;
                    _obj.Pass = txtPass.Text;
                    _obj.Name = txtName.Text;
                    _obj.Birth = dtpBirth.Value;
                    _obj.Phone = txtPhone.Text;
                    _obj.Address = txtAddress.Text;
                    _obj.Role = Convert.ToInt32(cbbRole.SelectedValue);

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

                // Get current user object
                _obj.Id = Convert.ToInt64(dgvAep.Rows[e.RowIndex].Cells["colId"].Value);
                _obj.Acc = dgvAep.Rows[e.RowIndex].Cells["colAcc"].Value + "";
                _obj.Pass = dgvAep.Rows[e.RowIndex].Cells["colPass"].Value + "";
                _obj.Name = dgvAep.Rows[e.RowIndex].Cells["colName"].Value + "";
                _obj.Birth = Convert.ToDateTime(dgvAep.Rows[e.RowIndex].Cells["colBirth"].Value);
                _obj.Phone = dgvAep.Rows[e.RowIndex].Cells["colPhone"].Value + "";
                _obj.Address = dgvAep.Rows[e.RowIndex].Cells["colAddress"].Value + "";
                _obj.Role = Convert.ToInt32(dgvAep.Rows[e.RowIndex].Cells["colRole"].Value);

                // Show information in form
                txtAcc.Text = _obj.Acc;
                txtPass.Text = _obj.Pass;
                txtName.Text = _obj.Name;
                dtpBirth.Value = _obj.Birth.Value;
                txtPhone.Text = _obj.Phone;
                txtAddress.Text = _obj.Address;
                cbbRole.SelectedValue = _obj.Role;

                if (cmdEdit.Enabled == false) ResetEdit(); // edit mode
            }
            catch { return; }
        }
        #endregion

        #region Methods
        private void Stt()
        {
            for (int i = 0; i < dgvAep.Rows.Count; i++)
                dgvAep.Rows[i].Cells["colNo_"].Value = i + 1;
        }

        private void CreateRole()
        {
            try
            {
                _role.Columns.Add("Id").DataType = typeof(int);
                _role.Columns.Add("Name");

                _role.Rows.Add(0, "Quản trị");
                _role.Rows.Add(1, "Quản lí");
                _role.Rows.Add(2, "Người dùng");
                _role.Rows.Add(3, "Cổng vào");
                _role.Rows.Add(4, "Cổng ra");
                _role.Rows.Add(5, "Không có");

                cbbRole.DataSource = _role;
                cbbRole.DisplayMember = "Name";
                cbbRole.ValueMember = "Id";

                colRole.DataSource = _role;
                colRole.DisplayMember = "Name";
                colRole.ValueMember = "Id";
                colRole.ValueType = typeof(int);
            }
            catch { return; }
        }

        private void LoadData()
        {
            dgvAep.DataSource = _dal.GetData();
        }

        private void CellEndEdit(int rowIndex)
        {
            try
            {
                if (rowIndex == -1) return;

                object acc = dgvAep.Rows[rowIndex].Cells["colAcc"].Value;
                object pass = dgvAep.Rows[rowIndex].Cells["colPass"].Value;
                object name = dgvAep.Rows[rowIndex].Cells["colName"].Value;
                object birth = dgvAep.Rows[rowIndex].Cells["colBirth"].Value;
                object address = dgvAep.Rows[rowIndex].Cells["colAddress"].Value;
                object phone = dgvAep.Rows[rowIndex].Cells["colPhone"].Value;
                object role = dgvAep.Rows[rowIndex].Cells["colRole"].Value;

                _obj.Acc = acc + "";
                _obj.Pass = pass + "";
                _obj.Name = name + "";

                var dti = new DateTime();
                if (DateTime.TryParse(birth + "", out dti))
                    _obj.Birth = Convert.ToDateTime(birth);
                else _obj.Birth = null;

                _obj.Address = address + "";
                _obj.Phone = phone + "";

                if (role + "" == "")
                    role = UTL.BLL.UecLajVei.Roles.None;
                _obj.Role = Convert.ToInt32(role);
            }
            catch { return; }
        }

        private static DAL.User ProcessRow(DataRow row)
        {
            try
            {
                object id = row["Id"];
                object acc = row["Acc"];
                object pass = row["Pass"];
                object name = row["Name"];
                object birth = row["Birth"];
                object address = row["Address"];
                object phone = row["Phone"];
                object role = row["Role"];

                var usr = new DAL.User();
                if (id + "" == "") id = -1;
                else usr.Id = Convert.ToInt64(id);

                usr.Acc = acc + "";
                usr.Pass = pass + "";
                usr.Name = name + "";

                var dti = new DateTime();

                if (DateTime.TryParse(birth + "", out dti))
                    usr.Birth = Convert.ToDateTime(birth);
                else usr.Birth = null;

                usr.Address = address + "";
                usr.Phone = phone + "";

                if (role + "" == "")
                    role = UTL.BLL.UecLajVei.Roles.None;
                usr.Role = Convert.ToInt32(role);

                return usr;
            }
            catch { return null; }
        }

        private void ReadOnly(bool isReadOnly = true)
        {
            try
            {
                txtAcc.ReadOnly = isReadOnly;
                txtPass.ReadOnly = isReadOnly;
                txtName.ReadOnly = isReadOnly;
                txtPhone.ReadOnly = isReadOnly;
                txtAddress.ReadOnly = isReadOnly;
                dtpBirth.Enabled = !isReadOnly;
                cbbRole.Enabled = !isReadOnly;
            }
            catch { return; }
        }

        private void ClearText()
        {
            try
            {
                txtAcc.Text = null;
                txtPass.Text = null;
                txtName.Text = null;
                txtPhone.Text = null;
                txtAddress.Text = null;
                dtpBirth.Value = DateTime.Now;
                cbbRole.SelectedValue = cbbRole.Items.Count - 1;
            }
            catch { return; }
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
        #endregion

        #region More
        #endregion
    }
}