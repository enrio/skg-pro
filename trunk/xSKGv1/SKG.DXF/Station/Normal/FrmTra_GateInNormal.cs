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

namespace SKG.DXF.Station.Normal
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
                    Text = "NHẬP XE VÃNG LAI",
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
                var frm = new Station.Normal.FrmTra_VehicleNormal
                {
                    _num = txtNumber.Text,
                    WindowState = FormWindowState.Maximized,
                    AllowCancel = false,
                    _state = State.Add
                };

                frm.ShowDialog();
                o = _bll.Tra_Vehicle.Select(txtNumber.Text);
            }

            if (o == null) return;
            var ve = (Tra_Vehicle)o;

            if (ve.Fixed)
            {
                XtraMessageBox.Show(String.Format(STR_WARNING, txtNumber.Text),
                    STR_KIND,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            switch (_state)
            {
                case State.Add:
                    if (InsertObject())
                    {
                        XtraMessageBox.Show("CHO XE VÀO", "XE VÃNG LAI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetInput();
                    }
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
                        XtraMessageBox.Show(STR_IN_GATE,
                            STR_ADD,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
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
                var tg = txtDateIn.Text.Replace("AM", "SÁNG");
                tg = tg.Replace("PM", "CHIỀU");

                var cfm = String.Format(STR_CONFIRM, txtNumber.Text, tg);
                var oki = XtraMessageBox.Show(cfm,
                              STR_DELETE,
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);

                if (oki == DialogResult.Yes)
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
            if (!oki) XtraMessageBox.Show(STR_NOT_INP,
                          STR_ADD,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning);
            else
                txtNumber.Text = txtNumber.Text.Replace(" ", "");
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

        private const string STR_ADD = "Thêm chi tiết ra/vào";
        private const string STR_DELETE = "Xoá chi tiết ra/vào";
        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng!";

        private const string STR_CONFIRM = "CÓ XOÁ XE: {0}\nT.GIAN VÀO: {1}\nKHÔNG?";
        private const string STR_WARNING = "BIỂN SỐ {0} LÀ XE CỐ ĐỊNH\nXIN HÃY NHẬP BÊN CỔNG VÀO CỐ ĐỊNH";
        private const string STR_IN_GATE = "XE NÀY ĐANG Ở TRONG BẾN!";
        private const string STR_NOT_INP = "CHƯA NHẬP BIỂN SỐ!";
        private const string STR_KIND = "XE CỐ ĐỊNH";

        private void FrmTra_GateInNormal_Load(object sender, EventArgs e)
        {
            AllowBar = false;
            PerformAdd();
        }
    }
}