using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Station.Fixed
{
    using SKG;
    using BLL;
    using SKG.DXF;
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;
    using DevExpress.XtraEditors;
    using DevExpress.XtraBars.Docking;

    public partial class FrmTra_Registry : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Code = typeof(FrmTra_Registry).FullName, Parent = typeof(Level2).FullName, Text = "Đăng ký", Level = 3, Order = 20, Picture = @"Icons\Group.png" };
                return menu;
            }
        }
        #endregion

        public FrmTra_Registry()
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
            cboNumber.Properties.NullValuePrompt = String.Format("Nhập {0}", lblNumber.Text.ToBetween(null, ":", Format.Lower));

            base.SetNullPrompt();
        }

        protected override void PerformDelete()
        {
            var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

            if (id == new Guid()) XtraMessageBox.Show(STR_SELECT, STR_DELETE);
            else
            {
                var cfm = String.Format(STR_CONFIRM, cboNumber.Text);
                var oki = XtraMessageBox.Show(cfm, STR_DELETE, MessageBoxButtons.OKCancel);

                if (oki == DialogResult.OK)
                    if (_bll.Tra_Registry.Delete(id) != null) PerformRefresh();
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

            base.PerformSave();
        }

        protected override void ResetInput()
        {
            cboNumber.Text = null;
            lokTariff.ItemIndex = 0;
            lokBenden.ItemIndex = 0;
            dteXuatben.Text = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            cboNumber.DataBindings.Clear();
            lokTariff.DataBindings.Clear();
            lokBenden.DataBindings.Clear();
            dteXuatben.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            cboNumber.DataBindings.Add("EditValue", _dtb, ".Number");
            lokTariff.DataBindings.Add("EditValue", _dtb, ".TariffId");
            lokBenden.DataBindings.Add("EditValue", _dtb, ".CommissionId");
            dteXuatben.DataBindings.Add("EditValue", _dtb, ".TimeLeaves");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            //cboNumber.Properties.ReadOnly = isReadOnly;
            lokTariff.Properties.ReadOnly = isReadOnly;
            lokBenden.Properties.ReadOnly = isReadOnly;
            dteXuatben.Properties.ReadOnly = isReadOnly;

            grcMain.Enabled = isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

                var o = new Tra_Registry()
                {
                    Id = id,
                    TariffId = (Guid)lokTariff.EditValue,

                    //TimeLeaves = dteXuatben.DateTime
                };

                var oki = _bll.Tra_Registry.Update(o);
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
                    Type = Global.STR_GROUP,
                    Text = cboNumber.Text,

                };

                var oki = _bll.Tra_Registry.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Tra_Registry.Select();

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var a = cboNumber.Text.Length == 0 ? false : true;
            if (!a) cboNumber.Focus();
            return a;
        }
        #endregion

        private const string STR_ADD = "Thêm nhóm xe";
        private const string STR_EDIT = "Sửa nhóm xe";
        private const string STR_DELETE = "Xoá nhóm xe";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá nhóm '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Nhóm này có rồi";

        private void FrmTra_Registry_Load(object sender, EventArgs e)
        {
            lokTariff.Properties.DataSource = _bll.Tra_Tariff.SelectForFixed();
            lokTariff.ItemIndex = 0;
        }
    }
}