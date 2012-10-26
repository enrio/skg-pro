#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 26/10/2012 23:21
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Station.Manage
{
    using SKG.Plugin;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    /// <summary>
    /// Input gate
    /// </summary>
    public partial class FrmTra_GateInNormal : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(FrmTra_GateInNormal).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "CỔNG VÀO - XE VÃNG LAI",
                    Level = 3,
                    Order = 27,
                    Picture = @"Icons\GateIn.png"
                };
                return menu;
            }
        }
        #endregion

        public FrmTra_GateInNormal()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            AllowEdit = false;

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;
        }

        #region Override
        protected override void PerformAdd()
        {
            tmrMain.Enabled = true;

            base.PerformAdd();
        }

        protected override void PerformCancel()
        {
            tmrMain.Enabled = false;

            base.PerformCancel();
        }

        protected override void PerformSave()
        {
            if (!ValidInput()) return;
            var o = _bll.Tra_Vehicle.Select(txtNumber.Text);

            if (o == null)
            {
                var frm = new Station.Normal.FrmTra_Vehicle
                {
                    _num = txtNumber.Text,
                    WindowState = FormWindowState.Maximized,
                    AllowCancel = false,
                    _state = State.Add
                };
                frm.ShowDialog();
            }

            switch (_state)
            {
                case State.Add:
                    if (InsertObject())
                        ResetInput();
                    break;

                case State.Edit:
                    if (UpdateObject())
                        PerformCancel();
                    break;

                default:
                    break;
            }

            base.PerformSave();
        }

        protected override bool InsertObject()
        {
            try
            {
                var id = _bll.Tra_Vehicle.CheckExist(txtNumber.Text);

                if (id != new Guid())
                {
                    var o = new Tra_Detail()
                    {
                        Pol_UserInId = Global.Session.User.Id,
                        Tra_VehicleId = id,
                        DateIn = Global.Session.Current
                    };

                    if (_bll.Tra_Detail.Insert(o) != null) return true;
                    else
                    {
                        XtraMessageBox.Show(STR_IN_GATE, Text);
                        return false;
                    }
                }
                else return false;
            }
            catch { return false; }
            finally { LoadData(); }
        }

        protected override bool UpdateObject()
        {
            try
            {
                var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

                var o = new Tra_Detail()
                {
                    Id = id,
                    DateIn = Global.Session.Current
                };

                if (_bll.Tra_Detail.Update(o) != null) return true;
                else
                {
                    XtraMessageBox.Show(STR_IN_GATE, Text);
                    return false;
                }
            }
            catch { return false; }
        }

        protected override void PerformDelete()
        {
            var tmp = grvMain.GetFocusedRowCellValue("Id");
            if (tmp + "" == "") return;
            var id = (Guid)tmp;

            if (id == new Guid()) XtraMessageBox.Show(STR_SELECT, STR_DELETE);
            else
            {
                var cfm = String.Format(STR_CONFIRM, txtNumber.Text);
                var oki = XtraMessageBox.Show(cfm, STR_DELETE, MessageBoxButtons.OKCancel);

                if (oki == DialogResult.OK)
                    if (_bll.Tra_Detail.Delete(id) != null) PerformRefresh();
                    else XtraMessageBox.Show(STR_UNDELETE, STR_DELETE);
            }

            base.PerformDelete();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            if (_dtb != null)
            {

                if (_dtb.Rows.Count > 0)
                {
                    ClearDataBindings();
                    DataBindingControl();
                }
            }

            base.PerformRefresh();
        }

        protected override void ResetInput()
        {
            txtNumber.Text = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            txtNumber.DataBindings.Clear();
            txtDateIn.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            txtNumber.DataBindings.Add("EditValue", _dtb, ".Code");
            txtDateIn.DataBindings.Add("Text", _dtb, ".DateIn");

            base.DataBindingControl();
        }

        /// <summary>
        /// Danh sách 20 xe vào bến cuối cùng
        /// </summary>
        protected override void LoadData()
        {
            _dtb = _bll.Tra_Detail.Get20LatestForNormal();
            if (_dtb == null) return;

            if (_dtb.Rows.Count > 0)
                grcMain.DataSource = _dtb;
            else
            {
                for (int i = 0; i < grvMain.RowCount; i++)
                    grvMain.DeleteRow(i);

                bbiEdit.Enabled = false;
                bbiDelete.Enabled = false;
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var oki = txtNumber.Text.Length == 0 ? false : true;
            if (!oki) XtraMessageBox.Show(STR_NOT_INP, Text);
            return oki;
        }

        protected override void TimerTick(object sender, EventArgs e)
        {
            txtDateIn.EditValue = Global.Session.Current;

            base.TimerTick(sender, e);
        }
        #endregion

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PerformSave();
        }

        const string STR_MENU = "Cổng &vào";
        private const string STR_DESC = "In gate form";
        private const string STR_DMY = "dd/MM/yyyy HH:mm:ss";

        private const string STR_IN_GATE = "Xe này đang ở trong bến!";
        private const string STR_IN_MAG = "Xe này đã có trong danh sách quản lí!";

        private const string STR_INP_ERR = "Lỗi, nhập dữ liệu sai{0}{1}";
        private const string STR_INP_HAD = "&Nhập bằng tay";
        private const string STR_ADD_SUC = "";// "Đã cho xe vào!";
        private const string STR_EDI_SUC = "Sửa thành công!";

        private const string STR_DEL_SUC = "Xoá thành công!";
        private const string STR_DEL_ERR = "Lỗi xoá dữ liệu!";

        private const string STR_NO_SAVE = "Không thêm được!";
        private const string STR_NOT_EDIT = "Không sửa được!";
        private const string STR_NOT_DEL = "Không xoá được!";
        private const string STR_NOT_NUM = "Biển số không hợp lệ hợp lệ!";
        private const string STR_NOT_INP = "Chưa nhập biển số!";
        private const string STR_NOT_C = "Chưa nhập số ghế!";

        private const string STR_ADD = "Thêm chi tiết ra/vào";
        private const string STR_EDIT = "Sửa chi tiết ra/vào";
        private const string STR_DELETE = "Xoá chi tiết ra/vào";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá số xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Mã này có rồi";
    }
}