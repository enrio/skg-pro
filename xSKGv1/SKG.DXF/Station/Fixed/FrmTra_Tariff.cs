#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:17
 * Update: 08/11/2012 19:52
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.DXF.Station.Fixed
{
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    public partial class FrmTra_Tariff : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_Tariff);
                var name = Global.GetIconName(type);

                var menu = new Menuz
                {
                    Code = type.FullName,
                    Parent = typeof(Level2).FullName,
                    Text = STR_TITLE,
                    Level = 1,
                    Order = 0,
                    Picture = String.Format(Global.STR_ICON, name)
                };
                return menu;
            }
        }
        #endregion

        #region Implements
        #endregion

        #region Overrides
        protected override void SetNullPrompt()
        {
            txtName.Properties.NullValuePrompt = String.Format("Nhập {0}", lblName.Text.ToBetween(null, ":", Format.Lower));

            base.SetNullPrompt();
        }

        protected override void PerformDelete()
        {
            var tmpId = grvMain.GetFocusedRowCellValue("Id");
            if (tmpId == null)
            {
                XtraMessageBox.Show("CHỌN DÒNG CẦN XOÁ\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var text = grvMain.GetFocusedRowCellValue("Text");
            var id = (Guid)tmpId;

            if (id == new Guid())
                XtraMessageBox.Show(STR_SELECT.ToUpper(), STR_DELETE.ToUpper(),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                var cfm = String.Format(STR_CONFIRM, text);
                var oki = XtraMessageBox.Show(cfm.ToUpper(), STR_DELETE.ToUpper(), MessageBoxButtons.OKCancel);

                if (oki == DialogResult.OK)
                    if (_bll.Tra_Detail.Delete(id) != null) PerformRefresh();
                    else XtraMessageBox.Show(STR_UNDELETE.ToUpper(), STR_DELETE.ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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

            ReadOnlyControl();
            grvMain.ExpandAllGroups();

            base.PerformRefresh();
        }

        protected override void PerformSave()
        {
            switch (_state)
            {
                case State.Add:
                    if (InsertObject())
                    {
                        ResetInput(); LoadData();
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

        protected override void ResetInput()
        {
            //lokGroup.ItemIndex = 0;
            txtName.Text = null;

            calPrice1.Text = null;
            calPrice2.Text = null;

            calRose1.Text = null;
            calRose2.Text = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            lokGroup.DataBindings.Clear();
            txtName.DataBindings.Clear();

            calPrice1.DataBindings.Clear();
            calPrice2.DataBindings.Clear();

            calRose1.DataBindings.Clear();
            calRose2.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            lokGroup.DataBindings.Add("EditValue", _dtb, ".GroupId");
            txtName.DataBindings.Add("EditValue", _dtb, ".Text");

            calPrice1.DataBindings.Add("EditValue", _dtb, ".Price1");
            calPrice2.DataBindings.Add("EditValue", _dtb, ".Price2");

            calRose1.DataBindings.Add("EditValue", _dtb, ".Rose1");
            calRose2.DataBindings.Add("EditValue", _dtb, ".Rose2");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            txtName.Properties.ReadOnly = isReadOnly;
            lokGroup.Properties.ReadOnly = isReadOnly;

            calPrice1.Properties.ReadOnly = isReadOnly;
            calPrice2.Properties.ReadOnly = isReadOnly;

            calRose1.Properties.ReadOnly = isReadOnly;
            calRose2.Properties.ReadOnly = isReadOnly;

            grcMain.Enabled = isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

                var o = new Tra_Tariff()
                {
                    Id = id,

                    Text = txtName.Text,
                    //Note = txtDescript.Text,
                    GroupId = (Guid)lokGroup.GetColumnValue("Id"),
                    Code = "STATION",

                    Price1 = (int)calPrice1.Value,
                    Price2 = (int)calPrice2.Value,

                    Rose1 = (int)calRose1.Value,
                    Rose2 = (int)calRose2.Value
                };

                var oki = _bll.Tra_Tariff.Update(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_EDIT);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override bool InsertObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var o = new Tra_Tariff()
                {
                    Text = txtName.Text,
                    // Note = txtDescript.Text,
                    GroupId = (Guid)lokGroup.GetColumnValue("Id"),
                    Code = "STATION",
                    Price1 = (int)calPrice1.Value,
                    Price2 = (int)calPrice2.Value,

                    Rose1 = (int)calRose1.Value,
                    Rose2 = (int)calRose2.Value
                };

                var oki = _bll.Tra_Tariff.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Tra_Tariff.SelectForFixed();

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var a = txtName.Text.Length == 0 ? false : true;
            if (!a)
            {
                XtraMessageBox.Show("CHƯA NHẬP TÊN TUYẾN", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtName.Focus();
                return false;
            }

            var b = calPrice1.Text.Length == 0 ? false : true;
            if (!b)
            {
                XtraMessageBox.Show("CHƯA NHẬP ĐƠN GIÁ LỆ PHÍ GHẾ", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                calPrice1.Focus();
                return false;
            }

            var c = calRose1.Text.Length == 0 ? false : true;
            if (!c)
            {
                XtraMessageBox.Show("CHƯA NHẬP ĐƠN GIÁ HOA HỒNG GHẾ", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                calRose1.Focus();
                return false;
            }

            return true;
        }
        #endregion

        #region Methods
        public FrmTra_Tariff()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;

            grvMain.Appearance.BandPanel.Options.UseTextOptions = true;
            grvMain.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grvMain.Appearance.HeaderPanel.Options.UseTextOptions = true;
            grvMain.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }
        #endregion

        #region Events
        private void FrmTra_Tariff_Load(object sender, EventArgs e)
        {
            lokGroup.Properties.DataSource = _bll.Pol_Dictionary.Select((object)Global.STR_PROVINCE);
            lokGroup.ItemIndex = 0;
        }

        private void calPrice1_EditValueChanged(object sender, EventArgs e)
        {
            calPrice2.EditValue = Convert.ToInt32(calPrice1.EditValue) * 130 / 100;
        }

        private void calRose1_EditValueChanged(object sender, EventArgs e)
        {
            calRose2.EditValue = Convert.ToInt32(calRose1.EditValue) * 130 / 100;
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Bảng giá tuyến";
        private const string STR_ADD = "Thêm " + STR_TITLE;
        private const string STR_EDIT = "Sửa " + STR_TITLE;
        private const string STR_DELETE = "Xoá " + STR_TITLE;

        private const string STR_SELECT = "HÃY CHỌN DỮ LIỆU";
        private const string STR_CONFIRM = "CÓ XOÁ TUYẾN '{0}' NÀY KHÔNG?";
        private const string STR_UNDELETE = "KHÔNG XOÁ ĐƯỢC\n\rDỮ LIỆU ĐANG SỬ DỤNG";
        private const string STR_DUPLICATE = "TUYẾN NÀY CÓ RỒI";
        #endregion
    }
}