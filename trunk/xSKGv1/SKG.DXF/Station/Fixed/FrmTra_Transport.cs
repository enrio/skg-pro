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

namespace SKG.DXF.Station.Fixed
{
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;

    using DevExpress.Utils;
    using DevExpress.XtraEditors;

    public partial class FrmTra_Transport : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_Transport);
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
            txtName.DataBindings.Add("EditValue", _dtb, ".Text");
            txtDescript.DataBindings.Add("EditValue", _dtb, ".Note");

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

                var o = new Pol_Dictionary()
                {
                    Id = id,
                    Type = Global.STR_TRANSPORT,
                    Text = txtName.Text,
                    Note = txtDescript.Text
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
                    Type = Global.STR_TRANSPORT,
                    Text = txtName.Text,
                    Note = txtDescript.Text
                };

                var oki = _bll.Pol_Dictionary.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Pol_Dictionary.Select((object)Global.STR_TRANSPORT);

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
        public FrmTra_Transport()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;
            grvMain.Appearance.HeaderPanel.Options.UseTextOptions = true;
            grvMain.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            grvMain.IndicatorWidth = 50;
        }
        #endregion

        #region Events
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Đơn vị vận tải";
        private const string STR_ADD = "Thêm " + STR_TITLE;
        private const string STR_EDIT = "Sửa " + STR_TITLE;
        private const string STR_DELETE = "Xoá " + STR_TITLE;

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá đơn vị vận tải '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Đơn vị vận tải này có rồi";
        #endregion
    }
}