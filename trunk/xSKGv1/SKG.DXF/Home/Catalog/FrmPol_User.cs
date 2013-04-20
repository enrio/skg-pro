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

    public partial class FrmPol_User : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmPol_User);
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
            txtAcc.Properties.NullValuePrompt = String.Format("Nhập {0}", lblAcc.Text.ToBetween(null, ":", Format.Lower));

            base.SetNullPrompt();
        }

        protected override void PerformEdit()
        {
            var tmpId = grvMain.GetFocusedRowCellValue("Id");
            if (tmpId == null)
            {
                XtraMessageBox.Show(STR_CHOICE_E,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            base.PerformEdit();
        }

        protected override void PerformDelete()
        {
            var tmpId = grvMain.GetFocusedRowCellValue("Id");
            if (tmpId == null)
            {
                XtraMessageBox.Show(STR_CHOICE,
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
                    if (_bll.Pol_User.Delete(id) != null) PerformRefresh();
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
            txtAcc.Text = null;
            txtPass.Text = null;
            dteBirth.DateTime = Global.Session.Current.ToBirth(18);
            txtAddress.Text = null;
            txtPhone.Text = null;
            txtCode.Text = null;
            txtNote.Text = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            txtName.DataBindings.Clear();
            txtAcc.DataBindings.Clear();
            txtPass.DataBindings.Clear();
            dteBirth.DataBindings.Clear();
            radSex.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtCode.DataBindings.Clear();
            txtNote.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            txtName.DataBindings.Add("EditValue", _dtb, ".Name");
            txtAcc.DataBindings.Add("EditValue", _dtb, ".Acc");
            txtPass.DataBindings.Add("EditValue", _dtb, ".Pass");
            dteBirth.DataBindings.Add("EditValue", _dtb, ".Birth");
            radSex.DataBindings.Add("EditValue", _dtb, ".Sex");
            txtAddress.DataBindings.Add("EditValue", _dtb, ".Address");
            txtPhone.DataBindings.Add("EditValue", _dtb, ".Phone");
            txtCode.DataBindings.Add("EditValue", _dtb, ".Code");
            txtNote.DataBindings.Add("EditValue", _dtb, ".Note");

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
            txtCode.Properties.ReadOnly = isReadOnly;
            txtNote.Properties.ReadOnly = isReadOnly;

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
                    Sex = radSex.EditValue.ToBoolean(),
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text,
                    Code = txtCode.Text,
                    Note = txtNote.Text
                };

                var oki = _bll.Pol_User.Update(o);
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

                var o = new Pol_User()
                {
                    Acc = txtAcc.Text,
                    Pass = txtPass.Text,
                    Name = txtName.Text,
                    Birth = dteBirth.DateTime,
                    Sex = radSex.EditValue.ToBoolean(),
                    Phone = txtPhone.Text,
                    Address = txtAddress.Text,
                    Code = txtCode.Text,
                    Note = txtNote.Text
                };

                var oki = _bll.Pol_User.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

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
                grvMain.BestFitColumns();
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var a = dteBirth.DateTime.ToAge(Global.Session.Current) < 18 ? false : true;
            if (!a)
            {
                lblInfo.Text = STR_AGE;
                dteBirth.Focus();
            }

            var b = txtPass.Text.Length < 6 ? false : true;
            if (!b)
            {
                lblInfo.Text = STR_PASS;
                txtPass.Focus();
            }

            if (a && b) lblInfo.Text = null;

            var c = txtAcc.Text.Length == 0 ? false : true;
            if (!c) txtAcc.Focus();

            var d = txtName.Text.Length == 0 ? false : true;
            if (!d) txtName.Focus();

            return a && b && c && d;
        }
        #endregion

        #region Methods
        public FrmPol_User()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();
        }
        #endregion

        #region Events
        /// <summary>
        /// Numbered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvMain_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle < 0)
                {
                    return;
                }
                e.Info.DisplayText = "" + (e.RowHandle + 1);
                e.Handled = false;
            }
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Người dùng";
        private const string STR_ADD = "Thêm " + STR_TITLE;
        private const string STR_EDIT = "Sửa " + STR_TITLE;
        private const string STR_DELETE = "Xoá " + STR_TITLE;

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá tài khoản '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Tài khoản này có rồi";

        private const string STR_AGE = "Phải 18 tuổi trở lên!";
        private const string STR_PASS = "Mật khẩu 6 kí tự trở lên!";

        private const string STR_CHOICE = "CHỌN DÒNG CẦN XOÁ\n\rHOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ";
        private const string STR_CHOICE_E = "CHỌN DÒNG CẦN SỬA\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ SỬA";
        #endregion
    }
}