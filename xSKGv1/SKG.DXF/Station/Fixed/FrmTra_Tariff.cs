using System;
using System.Collections.Generic;
using System.Linq;
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

    public partial class FrmTra_Tariff : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Code = typeof(FrmTra_Tariff).FullName, Parent = typeof(Level2).FullName, Text = "Bảng giá tuyến", Level = 3, Order = 21, Picture = @"Icons\Kind.png" };
                return menu;
            }
        }
        #endregion

        public FrmTra_Tariff()
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
                    if (_bll.Tra_Tariff.Delete(id) != null) PerformRefresh();
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
            grvMain.ExpandAllGroups();

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
            calPrice1.Text = null;
            calPrice2.Text = null;
            txtDescript.Text = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {            
            txtName.DataBindings.Clear();
            calPrice1.DataBindings.Clear();
            calPrice2.DataBindings.Clear();
            txtDescript.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {            
            txtName.DataBindings.Add("EditValue", _dtb, ".Text");
            calPrice1.DataBindings.Add("EditValue", _dtb, ".Price1");
            calPrice2.DataBindings.Add("EditValue", _dtb, ".Price2");
            txtDescript.DataBindings.Add("EditValue", _dtb, ".Descript");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            
            txtName.Properties.ReadOnly = isReadOnly;
            calPrice1.Properties.ReadOnly = isReadOnly;
            calPrice2.Properties.ReadOnly = isReadOnly;
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

                var o = new Tra_Tariff()
                {
                    Id = id,
                    
                    Text = txtName.Text,
                    Price1 = (int)calPrice1.Value,
                    Price2 = (int)calPrice2.Value,
                    Note = txtDescript.Text
                };

                var oki = _bll.Tra_Tariff.Update(o);
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

                var o = new Tra_Tariff()
                {                    
                    Text = txtName.Text,
                    Price1 = (int)calPrice1.Value,
                    Price2 = (int)calPrice2.Value,
                    Note = txtDescript.Text
                };

                var oki = _bll.Tra_Tariff.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Tra_Tariff.SelectForFixed();

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

            return a;
        }
        #endregion

        private void FrmTra_Kind_Load(object sender, EventArgs e)
        {
            
        }

        private const string STR_ADD = "Thêm loại xe";
        private const string STR_EDIT = "Sửa loại xe";
        private const string STR_DELETE = "Xoá loại xe";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá loại '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Loại này có rồi";
    }
}