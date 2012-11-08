﻿using System;
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
                var menu = new Menuz
                {
                    Code = typeof(FrmTra_Tariff).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "Bảng giá xe cố định",
                    Level = 3,
                    Order = 21,
                    Picture = @"Icons\Kind.png"
                };
                return menu;
            }
        }
        #endregion

        public FrmTra_Tariff()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;
        }

        #region Override
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
                XtraMessageBox.Show("KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ", Text);
                return;
            }

            var id = (Guid)tmpId;

            if (id == new Guid()) XtraMessageBox.Show(STR_SELECT, STR_DELETE);
            else
            {
                var cfm = String.Format(STR_CONFIRM, txtName.Text);
                var oki = XtraMessageBox.Show(cfm, STR_DELETE, MessageBoxButtons.OKCancel);

                if (oki == DialogResult.OK)
                    if (_bll.Tra_Tariff.Delete(id) != null) PerformRefresh();
                    else XtraMessageBox.Show(STR_UNDELETE, STR_DELETE);
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
            if (!a) txtName.Focus();

            return a;
        }
        #endregion

        private const string STR_ADD = "Thêm loại xe";
        private const string STR_EDIT = "Sửa loại xe";
        private const string STR_DELETE = "Xoá loại xe";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá loại '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Loại này có rồi";

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
    }
}