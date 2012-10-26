﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Station.Manage
{
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    /// <summary>
    /// Cổng vào
    /// </summary>
    public partial class FrmTra_GateInNormal : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Code = typeof(FrmTra_GateInNormal).FullName, Parent = typeof(Level2).FullName, Text = "CỔNG VÀO - XE VÃNG LAI", Level = 3, Order = 27, Picture = @"Icons\GateIn.png" };
                return menu;
            }
        }
        #endregion

        Guid _idLoaixe = Guid.Empty;

        public FrmTra_GateInNormal()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            tmrMain.Enabled = true; // bật đồng hồ đếm giờ
            AllowEdit = false;

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;
        }

        #region Override
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

        protected override void PerformSave()
        {
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
                    {
                        PerformCancel();
                    }
                    break;

                case State.Edit:
                    if (UpdateObject())
                    {
                        PerformCancel();
                    }
                    break;

                default:
                    break;
            }

            base.PerformSave();
        }

        protected override void ResetInput()
        {
            //lkeGroup.ItemIndex = 0;
            //lkeKind.ItemIndex = 0;

            txtNumber.Text = null;
            //txtChair.Text = null;

            //txtDriver.Text = null;
            //txtAddress.Text = null;
            //txtPhone.Text = null;
            //txtDescript.Text = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            txtNumber.DataBindings.Clear();
            //txtChair.DataBindings.Clear();

            //txtDriver.DataBindings.Clear();
            //dteBirth.DataBindings.Clear();
            //txtAddress.DataBindings.Clear();
            //txtPhone.DataBindings.Clear();
            //txtDescript.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            txtNumber.DataBindings.Add("EditValue", _dtb, ".Code");
            //txtChair.DataBindings.Add("EditValue", _dtb, ".Chair");
            //txtDriver.DataBindings.Add("EditValue", _dtb, ".Driver");
            //dteBirth.DataBindings.Add("EditValue", _dtb, ".Birth");
            //txtAddress.DataBindings.Add("EditValue", _dtb, ".Address");
            //txtPhone.DataBindings.Add("EditValue", _dtb, ".Phone");
            //txtDescript.DataBindings.Add("EditValue", _dtb, ".Descript");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            //lkeGroup.Properties.ReadOnly = isReadOnly;
            //lkeKind.Properties.ReadOnly = isReadOnly;

            txtNumber.Properties.ReadOnly = isReadOnly;
            //txtChair.Properties.ReadOnly = isReadOnly;
            //txtDriver.Properties.ReadOnly = isReadOnly;
            //dteBirth.Properties.ReadOnly = isReadOnly;
            //txtAddress.Properties.ReadOnly = isReadOnly;
            //txtPhone.Properties.ReadOnly = isReadOnly;
            //txtDescript.Properties.ReadOnly = isReadOnly;

            grcMain.Enabled = isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var id = (Guid)grvMain.GetFocusedRowCellValue("Id");
                var o = new Tra_Detail()
                {
                    Id = id,
                    //Pol_UserInId = Global.Session.User.Id,
                    //Tra_VehicleId = id,
                    DateIn = Global.Session.Current
                };

                //var ve = (Tra_Vehicle)_bll.Tra_Vehicle.Select(txtNumber.Text);
                //ve.Number = 

                if (_bll.Tra_Detail.Update(o) != null) return true;
                else
                {
                    XtraMessageBox.Show(STR_IN_GATE, Text);
                    return false;
                }

            }
            catch { return false; }
        }

        protected override bool InsertObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var id = _bll.Tra_Vehicle.CheckExist(txtNumber.Text);

                if (id != new Guid()) // kiểm tra biển số xe trong danh sách các xe được quản lí
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
                else
                {
                    try
                    {
                        var ve = new Tra_Vehicle
                        {
                            Code = txtNumber.Text,
                            TransportId = _idLoaixe,
                            //Seats = txtChair.Text.ToInt32(),
                            //Driver = txtDriver.Text,
                            //Birth = dteBirth.DateTime,
                            //Address = txtAddress.Text,
                            //Phone = txtPhone.Text,
                            //Note = txtDescript.Text
                        };

                        if (_bll.Tra_Vehicle.Insert(ve) != null) // thêm xe nào vào danh sách xe cộ
                        {
                            var o = new Tra_Detail()
                            {
                                Pol_UserInId = Global.Session.User.Id,
                                Tra_VehicleId = ve.Id,
                                DateIn = Global.Session.Current
                            };

                            if (_bll.Tra_Detail.Insert(o) != null) return true;
                            else
                            {
                                XtraMessageBox.Show(STR_NO_SAVE, Text);
                                return false;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(STR_IN_MAG, Text);
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(String.Format(STR_INP_ERR, Environment.NewLine, ex.Message), Text);
                        return false;
                    }
                }
            }
            catch { return false; }
            finally { LoadData(); }
        }

        /// <summary>
        /// Danh sách 20 xe vào bến cuối cùng
        /// </summary>
        protected override void LoadData()
        {
            //_dtb = _bll.Select();

            //if (_dtb != null)
            //{
            //    grcMain.DataSource = _dtb;
            //    gridColumn2.BestFit(); // fit column STT
            //}

            _dtb = _bll.Tra_Detail.Get20LatestForNormal();
            if (_dtb == null) return;

            if (_dtb.Rows.Count > 0)
                grcMain.DataSource = _dtb;
            else
            {
                for (int i = 0; i < grvMain.RowCount; i++)
                    grvMain.DeleteRow(i);

                //cmdIn.Enabled = true;
                bbiEdit.Enabled = false;
                bbiDelete.Enabled = false;
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var oki = txtNumber.Text.Length == 0 ? false : true;

            if (!oki) XtraMessageBox.Show(STR_NOT_INP, Text);
            else
            {
                // Check format number
                if (txtNumber.Text.Length > 2)
                {
                    int num;
                    string tmp = txtNumber.Text.Substring(0, 2);
                    oki = oki && Int32.TryParse(tmp, out num);

                    tmp = txtNumber.Text.Substring(2, 1);
                    oki = oki && !Int32.TryParse(tmp, out num);
                }
                else oki = false;

                if (!oki) XtraMessageBox.Show(STR_NOT_NUM, Text);
            }

            return oki;
        }

        protected override void TimerTick(object sender, EventArgs e)
        {
            lblDateIn.Text = Global.Session.Current.ToStringVN();

            base.TimerTick(sender, e);
        }
        #endregion

        private void FrmGateIn_Load(object sender, EventArgs e)
        {
            //lblUserIn.Text = Global.Session.User.Name.ToUpper();

            ReadOnlyControl();
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

        #region Properties
        public string EditNumber { set; get; } // number need to update from form gate out
        public bool EditMode { set; get; } // edit mode allow edit mode in this form or another form
        public bool EditHand { set; get; } // edit by hand        
        #endregion

        private const string STR_ADD = "Thêm chi tiết ra/vào";
        private const string STR_EDIT = "Sửa chi tiết ra/vào";
        private const string STR_DELETE = "Xoá chi tiết ra/vào";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá số xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Mã này có rồi";

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PerformSave();
        }
    }
}