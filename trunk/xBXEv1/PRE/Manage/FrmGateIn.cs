using System;
using System.Collections.Generic;

namespace PRE.Manage
{
    using SKG.UTL.Extension;
    using SKG.UTL;

    using DAL.Entities;

    /// <summary>
    /// Cổng vào
    /// </summary>
    public partial class FrmGateIn : PRE.Catalog.FrmBase
    {
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

        public FrmGateIn()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            tmrMain.Enabled = true; // bật đồng hồ đếm giờ
            lblUserIn.Text = BasePRE._sss.User.Name.ToUpper();

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;
        }

        #region Override
        protected override void PerformDelete()
        {
            //var tmp = grvMain.GetFocusedRowCellValue("Id") + "";

            base.PerformDelete();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            if (_dtb != null)
            {
                ClearDataBindings();
                if (_dtb.Rows.Count > 0) DataBindingControl();
            }

            base.PerformRefresh();
        }

        protected override void PerformSave()
        {
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
            lkeGroup.ItemIndex = 0;
            lkeKind.ItemIndex = 0;

            txtNumber.Text = null;
            txtChair.Text = null;

            txtDriver.Text = null;
            txtAddress.Text = null;
            txtPhone.Text = null;
            txtDescript.Text = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            txtNumber.DataBindings.Clear();
            txtChair.DataBindings.Clear();

            txtDriver.DataBindings.Clear();
            dteBirth.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtDescript.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            txtNumber.DataBindings.Add("EditValue", _dtb, ".Number");
            txtChair.DataBindings.Add("EditValue", _dtb, ".Chair");
            txtDriver.DataBindings.Add("EditValue", _dtb, ".Driver");
            dteBirth.DataBindings.Add("EditValue", _dtb, ".Birth");
            txtAddress.DataBindings.Add("EditValue", _dtb, ".Address");
            txtPhone.DataBindings.Add("EditValue", _dtb, ".Phone");
            txtDescript.DataBindings.Add("EditValue", _dtb, ".Descript");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            lkeGroup.Properties.ReadOnly = isReadOnly;
            lkeKind.Properties.ReadOnly = isReadOnly;

            txtNumber.Properties.ReadOnly = isReadOnly;
            txtChair.Properties.ReadOnly = isReadOnly;
            txtDriver.Properties.ReadOnly = isReadOnly;
            dteBirth.Properties.ReadOnly = isReadOnly;
            txtAddress.Properties.ReadOnly = isReadOnly;
            txtPhone.Properties.ReadOnly = isReadOnly;
            txtDescript.Properties.ReadOnly = isReadOnly;

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
                    //Pol_UserInId = BasePRE._sss.User.Id,
                    //Tra_VehicleId = id,
                    DateIn = BasePRE._sss.Current
                };

                if (_bll.Tra_Detail.Update(o) != null) return true;
                else
                {
                    BasePRE.ShowMessage(STR_IN_GATE, Text);
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
                        Pol_UserInId = BasePRE._sss.User.Id,
                        Tra_VehicleId = id,
                        DateIn = BasePRE._sss.Current
                    };

                    if (_bll.Tra_Detail.Insert(o) != null) return true;
                    else
                    {
                        BasePRE.ShowMessage(STR_IN_GATE, Text);
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        var ve = new Tra_Vehicle
                        {
                            Number = txtNumber.Text,
                            Tra_KindId = (Guid)lkeKind.GetColumnValue("Id"),
                            Chair = txtChair.Text.ToInt32(),
                            Driver = txtDriver.Text,
                            Birth = dteBirth.DateTime,
                            Address = txtAddress.Text,
                            Phone = txtPhone.Text,
                            Descript = txtDescript.Text
                        };

                        if (_bll.Tra_Vehicle.Insert(ve) != null) // thêm xe nào vào danh sách xe cộ
                        {
                            var o = new Tra_Detail()
                            {
                                Pol_UserInId = BasePRE._sss.User.Id,
                                Tra_VehicleId = ve.Id,
                                DateIn = BasePRE._sss.Current
                            };

                            if (_bll.Tra_Detail.Insert(o) != null) return true;
                            else
                            {
                                BasePRE.ShowMessage(STR_NO_SAVE, Text);
                                return false;
                            }
                        }
                        else
                        {
                            BasePRE.ShowMessage(STR_IN_MAG, Text);
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        BasePRE.ShowMessage(String.Format(STR_INP_ERR, Environment.NewLine, ex.Message), Text);
                        return false;
                    }
                }
            }
            catch { return false; }
            finally { GetDataInMinute(); }
        }

        protected override void LoadData()
        {
            //_dtb = _bll.Select();

            //if (_dtb != null)
            //{
            //    grcMain.DataSource = _dtb;
            //    gridColumn2.BestFit(); // fit column STT
            //}

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var oki = txtNumber.Text.Length == 0 ? false : true;

            if (!oki) BasePRE.ShowMessage(STR_NOT_INP, Text);
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

                if (!oki) BasePRE.ShowMessage(STR_NOT_NUM, Text);
            }

            if (lkeGroup.GetColumnValue("Code") + "" == "E")
            {
                oki = txtChair.Text.Length == 0 ? false : true;
                if (!oki) BasePRE.ShowMessage(STR_NOT_C, Text);
            }

            return oki;
        }

        static int _sec; // current second
        protected override void TimerTick(object sender, EventArgs e)
        {
            _sec++; if (_sec >= 10) { GetDataInMinute(); _sec = 0; }
            lblDateIn.Text = BasePRE._sss.Current.ToStringVN();

            base.TimerTick(sender, e);
        }
        #endregion

        private void FrmGateIn_Load(object sender, EventArgs e)
        {
            lkeGroup.Properties.DataSource = _bll.Tra_Group.Select();
            lkeGroup.ItemIndex = 0;

            ReadOnlyControl();
        }

        private void lkeGroup_EditValueChanged(object sender, EventArgs e)
        {
            var id = (Guid)lkeGroup.GetColumnValue("Id");
            lkeKind.Properties.DataSource = _bll.Tra_Kind.Select(id);
            lkeKind.ItemIndex = 0;
        }

        /// <summary>
        /// Danh sách xe vào bến trong vòng 01 phút
        /// </summary>
        private void GetDataInMinute()
        {
            _dtb = _bll.Tra_Detail.GetDataInMinute();
            if (_dtb == null) return;

            if (_dtb.Rows.Count > 0)
                grcMain.DataSource = _dtb;
            else
            {
                for (int i = 0; i < grvMain.RowCount; i++)
                    grvMain.DeleteRow(i);

                //cmdIn.Enabled = true;
                //cmdEdit.Enabled = false;
                //cmdDelete.Enabled = false;
            }
        }
    }
}