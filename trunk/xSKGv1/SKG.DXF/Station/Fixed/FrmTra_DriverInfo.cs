#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 25/01/2012 21:07
 * Update: 26/09/2013 23:07
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

    public partial class FrmTra_DriverInfo : FrmInput
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
            txtDriver.Properties.NullValuePrompt = String.Format("Nhập {0} tài xế",
                lblDriver.Text.ToBetween(null, ":", Format.Lower));

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
                {
                    var more = grvMain.GetFocusedRowCellValue("More") + "";
                    if (more != "") XtraMessageBox.Show(STR_UNDELETE.ToUpper(), STR_DELETE.ToUpper(),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        if (_bll.Pol_Dictionary.Delete(id) != null) PerformRefresh();
                        else XtraMessageBox.Show(STR_UNDELETE.ToUpper(), STR_DELETE.ToUpper(),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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

        protected override void ResetInput()
        {
            txtDriver.EditValue = null;
            txtLicenseNo.EditValue = null;
            txtMark.EditValue = null;
            txtPhone.EditValue = null;

            dteTermDriverLicense.EditValue = null;
            lueNumber.ItemIndex = 0;
            lueTransport.ItemIndex = 0;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            txtDriver.DataBindings.Clear();
            txtLicenseNo.DataBindings.Clear();
            txtMark.DataBindings.Clear();
            txtPhone.DataBindings.Clear();

            dteTermDriverLicense.DataBindings.Clear();
            lueNumber.DataBindings.Clear();
            lueTransport.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            txtDriver.DataBindings.Add("EditValue", _dtb, ".Text");
            txtLicenseNo.DataBindings.Add("EditValue", _dtb, ".Code");
            txtMark.DataBindings.Add("EditValue", _dtb, ".Note");
            txtPhone.DataBindings.Add("EditValue", _dtb, ".More2");

            dteTermDriverLicense.DataBindings.Add("EditValue", _dtb, ".More1");
            lueNumber.DataBindings.Add("EditValue", _dtb, ".More");
            lueTransport.DataBindings.Add("EditValue", _dtb, ".More3");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            txtDriver.Properties.ReadOnly = isReadOnly;
            txtLicenseNo.Properties.ReadOnly = isReadOnly;
            txtMark.Properties.ReadOnly = isReadOnly;
            txtPhone.Properties.ReadOnly = isReadOnly;

            dteTermDriverLicense.Properties.ReadOnly = isReadOnly;
            lueNumber.Properties.ReadOnly = !isReadOnly;
            lueTransport.Properties.ReadOnly = isReadOnly;

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
                    Code = txtLicenseNo.Text,
                    Text = txtDriver.Text,
                    Note = txtMark.Text,
                    More = lueNumber.Text,
                    More1 = dteTermDriverLicense.DateTime.ToStringDateVN(),
                    More2 = txtPhone.Text,
                    More3 = lueTransport.EditValue + "",
                    Type = Global.STR_DRIVER
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
                    Code = txtLicenseNo.Text,
                    Text = txtDriver.Text,
                    Note = txtMark.Text,
                    More = lueNumber.Text,
                    More1 = dteTermDriverLicense.DateTime.ToStringDateVN(),
                    More2 = txtPhone.Text,
                    More3 = lueTransport.EditValue + "",
                    Type = Global.STR_DRIVER
                };

                var oki = _bll.Pol_Dictionary.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Pol_Dictionary.Select((object)Global.STR_DRIVER);

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                grvMain.BestFitColumns();
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var a = txtLicenseNo.Text.Length == 0 ? false : true;
            if (!a) txtLicenseNo.Focus();

            var b = txtDriver.Text.Length == 0 ? false : true;
            if (!b) txtDriver.Focus();

            return a && b;
        }
        #endregion

        #region Methods
        public FrmTra_DriverInfo()
        {
            InitializeComponent();
            Text = STR_TITLE.ToUpper();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();
        }
        #endregion

        #region Events
        private void FrmTra_DriverInfo_Load(object sender, EventArgs e)
        {
            lueNumber.Properties.DataSource = _bll.Tra_Vehicle.SelectForFixed(TermForFixed.Default);

            var tb = _bll.Pol_Dictionary.SelectTransport();
            lueTransport.Properties.DataSource = tb;
            glkTransport.DataSource = tb;

            if (!Number.IsNullOrEmpty())
            {
                lueNumber.Text = Number;
                PerformAdd();
            }
            else lueNumber.ItemIndex = 0;
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        /// <summary>
        /// Number of vehicle
        /// </summary>
        public string Number { get; set; }
        #endregion

        #region Constants
        private const string STR_TITLE = "Tài xế";
        private const string STR_ADD = "Thêm " + STR_TITLE;
        private const string STR_EDIT = "Sửa " + STR_TITLE;
        private const string STR_DELETE = "Xoá " + STR_TITLE;

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Số GPLX này có rồi";

        private const string STR_CHOICE = "CHỌN DÒNG CẦN XOÁ\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ";
        private const string STR_CHOICE_E = "CHỌN DÒNG CẦN SỬA\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ SỬA";
        #endregion
    }
}