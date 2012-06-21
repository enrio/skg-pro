using System;
using System.Collections.Generic;

namespace PRE.Catalog
{
    using DAL.Entities;
    using System.Windows.Forms;
    using SKG.UTL;

    /// <summary>
    /// Danh mục nhóm xe
    /// </summary>
    public partial class FrmTra_Group : PRE.Catalog.FrmBase
    {
        private const string STR_ADD = "Thêm nhóm xe";
        private const string STR_EDIT = "Sửa nhóm xe";
        private const string STR_DELETE = "Xoá nhóm xe";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá nhóm '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Nhóm này có rồi";
        private const string STR_EMPTY = "Chưa nhập [{0}]";
        private const string STR_NOT_INP = "Chưa nhập tên nhóm xe!";

        public FrmTra_Group()
        {
            InitializeComponent();

            SetDockPanel(dockPanel1, "Nhập liệu");
            SetDockPanel(dockPanel2, "Danh sách");

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;
        }

        #region Override
        protected override void PerformDelete()
        {
            var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

            if (id == new Guid()) BasePRE.ShowMessage(STR_SELECT, STR_DELETE);
            else
            {
                var cfm = String.Format(STR_CONFIRM, txtName.Text);
                var oki = BasePRE.ShowMessage(cfm, STR_DELETE, MessageBoxButtons.OKCancel);

                if (oki == DialogResult.OK)
                    if (_bll.Tra_Group.Delete(id) != null) PerformRefresh();
                    else BasePRE.ShowMessage(STR_UNDELETE, STR_DELETE);
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

            base.PerformSave();
        }

        protected override void ResetInput()
        {
            txtName.Text = null;
            txtDescript.Text = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            txtName.DataBindings.Clear();
            txtDescript.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            txtName.DataBindings.Add("EditValue", _dtb, ".Name");
            txtDescript.DataBindings.Add("EditValue", _dtb, ".Descript");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            txtName.Properties.ReadOnly = isReadOnly;
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

                var o = new Tra_Group()
                {
                    Id = id,
                    Name = txtName.Text,
                    Descript = txtDescript.Text
                };

                var oki = _bll.Tra_Group.Update(o);
                if (oki == null) BasePRE.ShowMessage(STR_DUPLICATE, STR_EDIT);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override bool InsertObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var o = new Tra_Group()
                {
                    Name = txtName.Text,
                    Descript = txtDescript.Text
                };

                var oki = _bll.Tra_Group.Insert(o);
                if (oki == null) BasePRE.ShowMessage(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Tra_Group.Select();

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var oki = txtName.Text.Length == 0 ? false : true;

            if (!oki)
            {
                BasePRE.ShowMessage(STR_NOT_INP, Text);
                txtName.Focus();
            }

            return oki;
        }
        #endregion
    }
}