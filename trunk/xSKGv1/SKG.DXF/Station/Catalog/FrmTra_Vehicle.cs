﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.DXF.Station.Catalog
{
    using SKG;
    using BLL;
    using SKG.DXF;
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    public partial class FrmTra_Vehicle : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Code = typeof(FrmTra_Vehicle).FullName, Parent = typeof(Level2).FullName, Text = "Xe cộ", Level = 3, Order = 22, Picture = @"Icons\Vehicle.png" };
                return menu;
            }
        }
        #endregion

        public string _num;
        public FrmTra_Vehicle()
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
            txtNumber.Properties.NullValuePrompt = String.Format("Nhập {0}", lblNumber.Text.ToBetween(null, ":", Format.Lower));

            base.SetNullPrompt();
        }

        protected override void PerformDelete()
        {
            var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

            if (id == new Guid()) XtraMessageBox.Show(STR_SELECT, STR_DELETE);
            else
            {
                var cfm = String.Format(STR_CONFIRM, txtNumber.Text);
                var oki = XtraMessageBox.Show(cfm, STR_DELETE, MessageBoxButtons.OKCancel);

                if (oki == DialogResult.OK)
                    if (_bll.Tra_Vehicle.Delete(id) != null) PerformRefresh();
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
            if (_num + "" != "") Close();
            base.PerformSave();
        }

        protected override void ResetInput()
        {
            lokKind.ItemIndex = 0;
            txtNumber.Text = null;
            txtNumber.Text = "0";
            txtDescript.Text = null;
            txtDriver.Text = null;
            txtAddress.Text = null;
            txtPhone.Text = null;
            dteBirth.EditValue = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            lokKind.DataBindings.Clear();
            txtNumber.DataBindings.Clear();
            txtChair.DataBindings.Clear();
            txtDescript.DataBindings.Clear();
            txtDriver.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            dteBirth.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            lokKind.DataBindings.Add("EditValue", _dtb, ".Tra_KindId");
            txtNumber.DataBindings.Add("EditValue", _dtb, ".Number");
            txtChair.DataBindings.Add("EditValue", _dtb, ".Chair");
            txtDescript.DataBindings.Add("EditValue", _dtb, ".Descript");
            txtDriver.DataBindings.Add("EditValue", _dtb, ".Driver");
            txtAddress.DataBindings.Add("EditValue", _dtb, ".Address");
            txtPhone.DataBindings.Add("EditValue", _dtb, ".Phone");
            dteBirth.DataBindings.Add("EditValue", _dtb, ".Birth");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            lokKind.Properties.ReadOnly = isReadOnly;
            txtNumber.Properties.ReadOnly = isReadOnly;
            txtChair.Properties.ReadOnly = isReadOnly;
            txtDescript.Properties.ReadOnly = isReadOnly;
            txtDriver.Properties.ReadOnly = isReadOnly;
            txtAddress.Properties.ReadOnly = isReadOnly;
            txtPhone.Properties.ReadOnly = isReadOnly;
            dteBirth.Properties.ReadOnly = isReadOnly;

            grcMain.Enabled = isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

                var o = new Tra_Vehicle()
                {
                    Id = id,
                    TransportId = (Guid)lokKind.GetColumnValue("Id"),
                    Number = txtNumber.Text,
                    Seats = txtChair.Text.ToInt32(),
                    Driver = txtDriver.Text,
                    Birth = dteBirth.DateTime,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Note = txtDescript.Text
                };

                var oki = _bll.Tra_Vehicle.Update(o);
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

                var o = new Tra_Vehicle()
                {
                    TransportId = (Guid)lokKind.GetColumnValue("Id"),
                    Number = txtNumber.Text,
                    Seats = txtChair.Text.ToInt32(),
                    Driver = txtDriver.Text,
                    Birth = dteBirth.DateTime,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Note = txtDescript.Text
                };

                var oki = _bll.Tra_Vehicle.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        public string num = "";
        protected override void LoadData()
        {
            if (num != "")
            {
                _dtb = _bll.Tra_Vehicle.Select((object)num);
                //PerformEdit();
            }
            else _dtb = _bll.Tra_Vehicle.Select();

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var a = txtNumber.Text.Length == 0 ? false : true;
            if (!a) txtNumber.Focus();

            var oki = true;
            if (lokKind.GetColumnValue("Code") + "" == "L")
            {
                oki = txtChair.Text.Length == 0 ? false : true;
                if (!oki) XtraMessageBox.Show(STR_NOT_C, Text);
            }

            return a && oki;
        }
        #endregion

        private void FrmTra_Vehicle_Load(object sender, EventArgs e)
        {
            lokKind.Properties.DataSource = _bll.Tra_Kind.Select();
            lokKind.ItemIndex = 0;

            if (_num + "" != "")
            {
                PerformAdd();
                txtNumber.Text = _num;
            }
        }

        private const string STR_ADD = "Thêm xe";
        private const string STR_EDIT = "Sửa xe";
        private const string STR_DELETE = "Xoá xe";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Xe này có rồi";

        private const string STR_NOT_C = "Chưa nhập số ghế!";
    }
}