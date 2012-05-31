using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRE.Manage
{
    using BLL;
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

        private const string STR_NOT_W = "Tải trọng không hợp lệ!";
        private const string STR_NOT_L = "Chiều dài không hợp lệ!";
        private const string STR_NOT_C = "Số ghế không hợp lệ!";

        public FrmGateIn()
        {
            InitializeComponent();

            tmrMain.Enabled = true; // bật đồng hồ đếm giờ
            lblUserIn.Text = BasePRE._sss.User.Name.ToUpper();

            SetDockPanel(dockPanel1, "Nhập liệu");
            SetDockPanel(dockPanel2, "Danh sách");

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;
            _bll = new Tra_DetailBLL();
        }

        #region Override
        protected override void PerformDelete()
        {
            var tmp = grvMain.GetFocusedRowCellValue("Id") + "";

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
                        ResetText(); LoadData();
                    }
                    break;

                case State.Edit:
                    if (UpdateObject())
                    {
                        ChangeStatus(); ReadOnlyControl();
                        PerformRefresh();
                    }
                    break;
            }

            base.PerformSave();
        }

        protected override void ResetText()
        {
            //txtName.Text = null;

            base.ResetText();
        }

        protected override void ClearDataBindings()
        {
            //txtName.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            //txtName.DataBindings.Add("EditValue", _dtb, ".Name");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            //txtName.Properties.ReadOnly = isReadOnly;

            grcMain.Enabled = isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) ; return false;

            }
            catch { return false; }
        }

        protected override bool InsertObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var id = BaseBLL._tra_VehicleBLL.CheckExist(txtNumber.Text);

                if (id != new Guid()) // kiểm tra biển số xe trong danh sách các xe được quản lí
                {
                    var o = new Tra_Detail()
                    {
                        Pol_UserInId = BasePRE._sss.User.Id,
                        Tra_VehicleId = id,
                        DateIn = BasePRE._sss.Current.Value
                    };

                    if (_bll.Insert(o) != null)
                    {
                        ResetText();
                        //lblInf.Text = STR_ADD_SUC;
                    }
                    else BasePRE.ShowMessage(STR_IN_GATE, Text);
                }
                else
                {
                    try
                    {
                        var ve = new Tra_Vehicle
                        {
                            Number = txtNumber.Text,
                            Tra_KindId = (Guid)lkeKind.GetColumnValue("Id"),
                            //Chair = chair
                            Driver = txtDriver.Text,
                            Birth = dteBirth.DateTime,
                            Address = txtAddress.Text
                        };

                        if (BaseBLL._tra_VehicleBLL.Insert(ve) != null) // thêm biển số xe nào vào danh sách quản lí
                        {
                            var o = new Tra_Detail()
                            {
                                Pol_UserInId = BasePRE._sss.User.Id,
                                Tra_VehicleId = ve.Id,
                                DateIn = BasePRE._sss.Current.Value
                            };

                            if (_bll.Insert(o) != null)
                            {
                                ResetText();
                                //lblInf.Text = STR_ADD_SUC;
                            }
                            else BasePRE.ShowMessage(STR_NO_SAVE, Text);
                        }
                        //else lblInf.Text = STR_IN_MAG;
                    }
                    catch (Exception ex)
                    {
                        BasePRE.ShowMessage(String.Format(STR_INP_ERR, Environment.NewLine, ex.Message), Text);
                        return false;
                    }
                }

                GetDataInMinute();
                return true;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Select();

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
            }

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

            return oki;
        }

        static int _sec; // current second
        protected override void tmrMain_Tick(object sender, EventArgs e)
        {
            _sec++; if (_sec >= 10) { GetDataInMinute(); _sec = 0; }
            lblDateIn.Text = BasePRE._sss.Current.Value.ToString("dd/MM/yyyy hh:mm:ss");

            base.tmrMain_Tick(sender, e);
        }
        #endregion

        private void FrmGateIn_Load(object sender, EventArgs e)
        {
            lkeGroup.Properties.DataSource = BaseBLL._tra_GroupBLL.Select();
            lkeGroup.ItemIndex = 0;
        }

        private void lkeGroup_EditValueChanged(object sender, EventArgs e)
        {
            var id = (Guid)lkeGroup.GetColumnValue("Id");
            lkeKind.Properties.DataSource = BaseBLL._tra_KindBLL.Select(id);
            lkeKind.ItemIndex = 0;
        }

        /// <summary>
        /// Danh sách xe vào bến trong vòng 01 phút
        /// </summary>
        private void GetDataInMinute()
        {
            var tb = BaseBLL._tra_DetailBLL.GetDataInMinute();
            if (tb == null) return;

            if (tb.Rows.Count > 0)
                grcMain.DataSource = tb;
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