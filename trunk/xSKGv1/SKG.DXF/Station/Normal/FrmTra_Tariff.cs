#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:17
 * Update: 08/11/2012 19:52
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Normal
{
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
                var type = typeof(FrmTra_Tariff);
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

            base.SetNullPrompt();
        }

        protected override void PerformDelete()
        {
            var tmpId = grvMain.GetFocusedRowCellValue("Id");
            if (tmpId == null)
            {
                XtraMessageBox.Show("CHỌN DÒNG CẦN XOÁ\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ",
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
                    if (_bll.Tra_Detail.Delete(id) != null) PerformRefresh();
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
            lokGroup.ItemIndex = 0;

            txtName.Text = null;
            txtCode.Text = null;
            txtDescript.Text = null;

            calPrice1.Text = null;
            calPrice2.Text = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            lokGroup.DataBindings.Clear();

            txtName.DataBindings.Clear();
            txtCode.DataBindings.Clear();
            txtDescript.DataBindings.Clear();

            calPrice1.DataBindings.Clear();
            calPrice2.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            lokGroup.DataBindings.Add("EditValue", _dtb, ".Tra_GroupId");

            txtName.DataBindings.Add("EditValue", _dtb, ".Text");
            txtCode.DataBindings.Add("EditValue", _dtb, ".Code");
            txtDescript.DataBindings.Add("EditValue", _dtb, ".Note");

            calPrice1.DataBindings.Add("EditValue", _dtb, ".Price1");
            calPrice2.DataBindings.Add("EditValue", _dtb, ".Price2");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            lokGroup.Properties.ReadOnly = isReadOnly;

            txtName.Properties.ReadOnly = isReadOnly;
            txtCode.Properties.ReadOnly = isReadOnly;
            txtDescript.Properties.ReadOnly = isReadOnly;

            calPrice1.Properties.ReadOnly = isReadOnly;
            calPrice2.Properties.ReadOnly = isReadOnly;

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
                    GroupId = (Guid)lokGroup.GetColumnValue("Id"),
                    Code = txtCode.Text,

                    Text = txtName.Text,
                    Note = txtCode.Text,

                    Price1 = (int)calPrice1.Value,
                    Price2 = (int)calPrice2.Value
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
                    GroupId = (Guid)lokGroup.GetColumnValue("Id"),
                    Code = txtCode.Text,

                    Text = txtName.Text,
                    Note = txtCode.Text,

                    Price1 = (int)calPrice1.Value,
                    Price2 = (int)calPrice2.Value
                };

                var oki = _bll.Tra_Tariff.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Tra_Tariff.SelectForNormal();

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

        #region Methods
        public FrmTra_Tariff()
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

        private void FrmTra_Kind_Load(object sender, EventArgs e)
        {
            lokGroup.Properties.DataSource = _bll.Pol_Dictionary.Select((object)Global.STR_GROUP);
            lokGroup.ItemIndex = 0;
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Bảng giá loại";
        private const string STR_ADD = "Thêm " + STR_TITLE;
        private const string STR_EDIT = "Sửa " + STR_TITLE;
        private const string STR_DELETE = "Xoá " + STR_TITLE;

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá loại '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Loại này có rồi";
        #endregion
    }
}