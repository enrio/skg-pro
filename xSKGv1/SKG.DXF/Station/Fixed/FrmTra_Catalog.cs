using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Station.Fixed
{
    using SKG.Plugin;
    using SKG.Extend;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    public partial class FrmTra_Catalog : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Code = typeof(FrmTra_Catalog).FullName, Parent = typeof(Level2).FullName, Text = "Danh mục", Level = 0, Order = 12, Picture = @"Icons\Lang.png" };
                return menu;
            }
        }
        #endregion

        public FrmTra_Catalog()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;
        }

        private void FrmPol_Dictionary_Load(object sender, EventArgs e)
        {
            lokList.Properties.DataSource = _bll.Pol_Dictionary.SelectRoot();
            lokList.ItemIndex = 0;
        }

        private void lokList_EditValueChanged(object sender, EventArgs e)
        {
            PerformRefresh();
        }

        #region Override
        protected override void SetNullPrompt()
        {
            txtText.Properties.NullValuePrompt = String.Format("Nhập {0}", lblText.Text.ToBetween(null, ":", Format.Lower));
            txtNote.Properties.NullValuePrompt = String.Format("Nhập {0}", lblNote.Text.ToBetween(null, ":", Format.Lower));

            base.SetNullPrompt();
        }

        protected override void PerformDelete()
        {
            var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

            if (id == new Guid()) XtraMessageBox.Show(STR_SELECT, STR_DELETE);
            else
            {
                var cfm = String.Format(STR_CONFIRM, txtText.Text);
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

            if (lokBelong.Properties.DataSource == null)
            {
                lblBelong.Visible = false;
                lokBelong.Visible = false;
            }
            else
            {
                lblBelong.Visible = true;
                lokBelong.Visible = true;
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
            txtText.Text = null;
            txtNote.Text = null;
            lokBelong.ItemIndex = 0;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            txtText.DataBindings.Clear();
            txtNote.DataBindings.Clear();
            lokBelong.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            txtText.DataBindings.Add("EditValue", _dtb, ".Text");
            txtNote.DataBindings.Add("EditValue", _dtb, ".Note");
            lokBelong.DataBindings.Add("EditValue", _dtb, ".ParentId");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            lokList.Properties.ReadOnly = !isReadOnly;
            txtText.Properties.ReadOnly = isReadOnly;
            txtNote.Properties.ReadOnly = isReadOnly;
            lokBelong.Properties.ReadOnly = isReadOnly;

            grcMain.Enabled = isReadOnly;

            //if (_state == State.Edit) txtCode.Properties.ReadOnly = true;

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
                    //Code = txtCode.Text,
                    Text = txtText.Text,
                    Note = txtNote.Text,
                    Type = lokList.EditValue + ""
                };

                var gui = new Guid();
                var ok = Guid.TryParse(lokBelong.EditValue + "", out gui);
                if (ok) o.ParentId = gui;

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
                    //Code = txtCode.Text,
                    Text = txtText.Text,
                    Note = txtNote.Text,
                    Type = lokList.EditValue + ""
                };

                var gui = new Guid();
                var ok = Guid.TryParse(lokBelong.EditValue + "", out gui);
                if (ok) o.ParentId = gui;

                var oki = _bll.Pol_Dictionary.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Pol_Dictionary.Select(lokList.EditValue);
            grcMain.DataSource = _dtb;

            if (_dtb.Rows.Count <= 0) return;
            var tmp = _dtb.Rows[0]["ParentId"] + "";
            var o = (Pol_Dictionary)_bll.Pol_Dictionary.Select(tmp);

            if (o == null) lokBelong.Properties.DataSource = null;
            else lokBelong.Properties.DataSource = _bll.Pol_Dictionary.Select((object)o.Type);

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            //var a = txtCode.Text.Length == 0 ? false : true;
            //if (!a) txtCode.Focus();

            var b = txtText.Text.Length == 0 ? false : true;
            if (!b) txtText.Focus();

            return b;
        }
        #endregion

        private const string STR_ADD = "Thêm ngôn ngữ";
        private const string STR_EDIT = "Sửa ngôn ngữ";
        private const string STR_DELETE = "Xoá ngôn ngữ";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Mã này có rồi";
    }
}