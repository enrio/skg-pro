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
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Fixed
{
    using SKG.Plugin;
    using SKG.Extend;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    public partial class FrmTra_Province : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_Province);
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
            txtText.Properties.NullValuePrompt = String.Format("Nhập {0}", lblText.Text.ToBetween(null, ":", Format.Lower));
            txtNote.Properties.NullValuePrompt = String.Format("Nhập {0}", lblNote.Text.ToBetween(null, ":", Format.Lower));

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

        #region Methods
        public FrmTra_Province()
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

        private void FrmPol_Dictionary_Load(object sender, EventArgs e)
        {
            lokList.Properties.DataSource = _bll.Pol_Dictionary.SelectForFixed();
            lokList.ItemIndex = 0;
        }

        private void lokList_EditValueChanged(object sender, EventArgs e)
        {
            PerformRefresh();
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Tỉnh/TP";

        private const string STR_ADD = "Thêm tỉnh/tp";
        private const string STR_EDIT = "Sửa tỉnh/tp";
        private const string STR_DELETE = "Xoá tỉnh/tp";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Mã này có rồi";
        #endregion
    }
}