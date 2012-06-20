using System;
using System.Collections.Generic;

namespace PRE.Catalog
{
    using UTL;
    using DAL.Entities;
    using System.Windows.Forms;
    using SKG.UTL;

    /// <summary>
    /// Danh sách xe cộ
    /// </summary>
    public partial class FrmTra_Vehicle : PRE.Catalog.FrmBase
    {
        private const string STR_ADD = "Thêm xe";
        private const string STR_EDIT = "Sửa xe";
        private const string STR_DELETE = "Xoá xe";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Xe này có rồi";
        private const string STR_EMPTY = "Chưa nhập [{0}]";

        public FrmTra_Vehicle()
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
                var cfm = String.Format(STR_CONFIRM, txtNumber.Text);
                var oki = BasePRE.ShowMessage(cfm, STR_DELETE, MessageBoxButtons.OKCancel);

                if (oki == DialogResult.OK)
                    if (_bll.Tra_Vehicle.Delete(id) != null) PerformRefresh();
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
            lokKind.ItemIndex = 0;
            txtNumber.Text = null;
            txtDescript.Text = null;
            txtDriver.Text = null;
            txtAddress.Text = null;
            txtPhone.Text = null;
            dteBirth.EditValue = null;

            base.ResetText();
        }

        protected override void ClearDataBindings()
        {
            lokKind.DataBindings.Clear();
            txtNumber.DataBindings.Clear();
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
                    Tra_KindId = (Guid)lokKind.GetColumnValue("Id"),
                    Number = txtNumber.Text,
                    Chair = txtChair.Text.ToInt32(),
                    Driver = txtDriver.Text,
                    Birth = dteBirth.DateTime,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Descript = txtDescript.Text
                };

                var oki = _bll.Tra_Vehicle.Update(o);
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

                var o = new Tra_Vehicle()
                {
                    Tra_KindId = (Guid)lokKind.GetColumnValue("Id"),
                    Number = txtNumber.Text,
                    Chair = txtChair.Text.ToInt32(),
                    Driver = txtDriver.Text,
                    Birth = dteBirth.DateTime,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Descript = txtDescript.Text
                };

                var oki = _bll.Tra_Vehicle.Insert(o);
                if (oki == null) BasePRE.ShowMessage(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Tra_Vehicle.Select();

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            return base.ValidInput();
        }
        #endregion

        private void FrmTra_Vehicle_Load(object sender, EventArgs e)
        {
            lokKind.Properties.DataSource = _bll.Tra_Kind.Select();
            lokKind.ItemIndex = 0;
        }
    }
}