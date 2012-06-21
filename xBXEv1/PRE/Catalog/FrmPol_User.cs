using System;
using System.Collections.Generic;

namespace PRE.Catalog
{
    using DAL.Entities;
    using System.Windows.Forms;
    using SKG.UTL;

    /// <summary>
    /// Danh sách người dùng
    /// </summary>
    public partial class FrmPol_User : PRE.Catalog.FrmBase
    {
        private const string STR_ADD = "Thêm người dùng";
        private const string STR_EDIT = "Sửa người dùng";
        private const string STR_DELETE = "Xoá người dùng";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá tài khoản '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Tài khoản này có rồi";
        private const string STR_EMPTY = "Chưa nhập [{0}]";

        private const string STR_PASS = "Mật khẩu 6 kí tự trở lên!";

        public FrmPol_User()
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
                    if (_bll.Pol_User.Delete(id) != null) PerformRefresh();
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

                default:
                    break;
            }

            base.PerformSave();
        }

        protected override void ResetText()
        {
            txtName.Text = null;
            txtAcc.Text = null;
            txtPass.Text = null;
            dteBirth.EditValue = null;
            txtAddress.Text = null;
            txtPhone.Text = null;

            txtName.Properties.NullValuePrompt = String.Format("Nhập {0}", lblName.Text.ToBetween(null, ":", Format.Lower));
            txtAcc.Properties.NullValuePrompt = String.Format("Nhập {0}", lblAcc.Text.ToBetween(null, ":", Format.Lower));

            base.ResetText();
        }

        protected override void ClearDataBindings()
        {
            txtName.DataBindings.Clear();
            txtAcc.DataBindings.Clear();
            txtPass.DataBindings.Clear();
            dteBirth.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtPhone.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            txtName.DataBindings.Add("EditValue", _dtb, ".Name");
            txtAcc.DataBindings.Add("EditValue", _dtb, ".Acc");
            txtPass.DataBindings.Add("EditValue", _dtb, ".Pass");
            dteBirth.DataBindings.Add("EditValue", _dtb, ".Birth");
            txtAddress.DataBindings.Add("EditValue", _dtb, ".Address");
            txtPhone.DataBindings.Add("EditValue", _dtb, ".Phone");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            txtName.Properties.ReadOnly = isReadOnly;
            txtAcc.Properties.ReadOnly = isReadOnly;
            txtPass.Properties.ReadOnly = isReadOnly;
            dteBirth.Properties.ReadOnly = isReadOnly;
            txtAddress.Properties.ReadOnly = isReadOnly;
            txtPhone.Properties.ReadOnly = isReadOnly;

            grcMain.Enabled = isReadOnly;

            if (_state == State.Edit) txtAcc.Properties.ReadOnly = true;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

                var o = new Pol_User()
                {
                    Id = id,
                    Acc = txtAcc.Text,
                    Pass = txtPass.Text,
                    Name = txtName.Text,
                    Birth = dteBirth.DateTime,
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text
                };

                var oki = _bll.Pol_User.Update(o);
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

                var o = new Pol_User()
                {
                    Acc = txtAcc.Text,
                    Pass = txtPass.Text,
                    Name = txtName.Text,
                    Birth = dteBirth.DateTime,
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text
                };

                var oki = _bll.Pol_User.Insert(o);
                if (oki == null) BasePRE.ShowMessage(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Pol_User.Select();

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
                gridColumn6.BestFit(); // fit column Birth
                gridColumn7.BestFit(); // fit column Phone
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var oki = txtName.Text.Length == 0 ? false : true;

            if (!oki)
            {
                BasePRE.ShowMessage(String.Format(STR_EMPTY, lblName.Text), Text);
                txtName.Focus();
            }

            oki &= txtAcc.Text.Length == 0 ? false : true;

            if (!oki)
            {
                BasePRE.ShowMessage(String.Format(STR_EMPTY, lblAcc.Text), Text);
                txtAcc.Focus();
            }

            return oki;
        }
        #endregion
    }
}