using System;
using System.Collections.Generic;

namespace PRE.Catalog
{
    using System.Windows.Forms;

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
                if (!ValidInput()) ; return false;

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
            return base.ValidInput();
        }
        #endregion
    }
}