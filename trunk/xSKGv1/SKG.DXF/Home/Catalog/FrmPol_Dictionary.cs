using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Home.Catalog
{
    using SKG.Plugin;
    using SKG.Extend;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    public partial class FrmPol_Dictionary : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Code = typeof(FrmPol_Dictionary).FullName, Parent = typeof(Level2).FullName, Text = "Ngôn ngữ", Level = 0, Order = 12, Picture = @"Icons\Lang.png" };
                return menu;
            }
        }
        #endregion

        public FrmPol_Dictionary()
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
            txtCode.Properties.NullValuePrompt = String.Format("Nhập {0}", lblCode.Text.ToBetween(null, ":", Format.Lower));
            txtName.Properties.NullValuePrompt = String.Format("Nhập {0}", lblName.Text.ToBetween(null, ":", Format.Lower));
            txtType.Properties.NullValuePrompt = String.Format("Nhập {0}", lblType.Text.ToBetween(null, ":", Format.Lower));

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
            txtType.Text = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            txtName.DataBindings.Clear();
            txtCode.DataBindings.Clear();
            txtDescript.DataBindings.Clear();
            txtType.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            txtName.DataBindings.Add("EditValue", _dtb, ".Caption");
            txtCode.DataBindings.Add("EditValue", _dtb, ".Code");
            txtDescript.DataBindings.Add("EditValue", _dtb, ".Descript");
            txtType.DataBindings.Add("EditValue", _dtb, ".Type");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            txtCode.Properties.ReadOnly = isReadOnly;
            txtName.Properties.ReadOnly = isReadOnly;
            txtDescript.Properties.ReadOnly = isReadOnly;
            txtType.Properties.ReadOnly = isReadOnly;

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
                    Note = txtDescript.Text,
                    Type = txtType.Text
                };

                var oki = _bll.Pol_Dictionary.Update(o);
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
                    Note = txtDescript.Text,
                    Type = txtType.Text
                };

                var oki = _bll.Pol_Dictionary.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Pol_Dictionary.Select();

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

            var c = txtType.Text.Length == 0 ? false : true;
            if (!c) txtType.Focus();

            return b && a && c;
        }
        #endregion

        private const string STR_ADD = "Thêm ngôn ngữ";
        private const string STR_EDIT = "Sửa ngôn ngữ";
        private const string STR_DELETE = "Xoá ngôn ngữ";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá mã '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Mã này có rồi";
    }
}