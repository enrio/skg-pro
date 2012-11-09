﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 29/07/2012 10:27
 * Update: 29/07/2012 10:27
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Home.Catalog
{
    using SKG.Plugin;
    using SKG.Extend;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    public partial class FrmPol_Right : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(FrmPol_Right).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "Chức năng",
                    Level = 0,
                    Order = 11,
                    Picture = @"Icons\Right.png"
                };
                return menu;
            }
        }
        #endregion

        public FrmPol_Right()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            AllowAdd = false;
            AllowDelete = false;

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;
        }

        #region Override
        protected override void SetNullPrompt()
        {
            txtCode.Properties.NullValuePrompt = String.Format("Nhập {0}", lblCode.Text.ToBetween(null, ":", Format.Lower));
            txtName.Properties.NullValuePrompt = String.Format("Nhập {0}", lblName.Text.ToBetween(null, ":", Format.Lower));

            base.SetNullPrompt();
        }

        protected override void PerformDelete()
        {
            var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

            if (id == new Guid()) XtraMessageBox.Show(STR_SELECT, STR_DELETE);
            else
            {
                var cfm = String.Format(STR_CONFIRM, txtName.Text);
                var oki = XtraMessageBox.Show(cfm, STR_DELETE, MessageBoxButtons.OKCancel);

                if (oki == DialogResult.OK)
                    if (_bll.Pol_Dictionary.Delete(id) != null) PerformRefresh();
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

                default:
                    break;
            }

            base.PerformSave();
        }

        protected override void ResetInput()
        {
            txtName.Text = null;
            txtCode.Text = null;
            txtDescript.Text = null;
            txtMore.Text = null;
            lueParent.ItemIndex = 0;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            txtName.DataBindings.Clear();
            txtCode.DataBindings.Clear();
            txtDescript.DataBindings.Clear();
            txtMore.DataBindings.Clear();
            lueParent.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            txtName.DataBindings.Add("EditValue", _dtb, ".Text");
            txtCode.DataBindings.Add("EditValue", _dtb, ".Code");
            txtDescript.DataBindings.Add("EditValue", _dtb, ".Note");
            txtMore.DataBindings.Add("EditValue", _dtb, ".More");
            lueParent.DataBindings.Add("EditValue", _dtb, ".ParentId");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            txtCode.Properties.ReadOnly = isReadOnly;
            txtName.Properties.ReadOnly = isReadOnly;
            txtDescript.Properties.ReadOnly = isReadOnly;
            txtMore.Properties.ReadOnly = isReadOnly;
            lueParent.Properties.ReadOnly = isReadOnly;

            grcMain.Enabled = isReadOnly;

            if (_state == State.Edit) txtCode.Properties.ReadOnly = true;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

                var o = new Pol_Dictionary()
                {
                    Id = id,
                    Code = txtCode.Text,
                    Text = txtName.Text,
                    More = txtMore.Text,
                    Note = txtDescript.Text
                };

                var parent = lueParent.EditValue + "";
                if (parent != "") o.ParentId = (Guid)lueParent.EditValue;

                var oki = _bll.Pol_Dictionary.UpdateRight(o);
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

                var o = new Pol_Dictionary()
                {
                    Code = txtCode.Text,
                    Text = txtName.Text,
                    More = txtMore.Text,
                    ParentId = (Guid)lueParent.EditValue,
                    Note = txtDescript.Text
                };

                var oki = _bll.Pol_Dictionary.InsertRight(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Pol_Dictionary.SelectRights();

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

            var b = txtCode.Text.Length == 0 ? false : true;
            if (!b) txtCode.Focus();

            return b && a;
        }
        #endregion

        private const string STR_ADD = "Thêm form, menu";
        private const string STR_EDIT = "Sửa form, menu";
        private const string STR_DELETE = "Xoá form, menu";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá mã '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Mã này có rồi";

        private void FrmPol_Right_Load(object sender, EventArgs e)
        {
            lueParent.Properties.DataSource = _bll.Pol_Dictionary.SelectRights();
            lueParent.ItemIndex = 0;
        }
    }
}