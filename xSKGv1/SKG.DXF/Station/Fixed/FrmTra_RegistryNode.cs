#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 25/01/2012 21:07
 * Update: 02/06/2013 21:07
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

    public partial class FrmTra_RegistryNode : FrmInput
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
                    if (_bll.Pol_Dictionary.Delete(id) != null) PerformRefresh();
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

        protected override void ResetInput()
        {
            lueTransport.ItemIndex = 0;
            lueRoute.ItemIndex = 0;
            calNode.EditValue = 1;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            lueTransport.DataBindings.Clear();
            lueRoute.DataBindings.Clear();
            cbbDays.DataBindings.Clear();
            calNode.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            lueTransport.DataBindings.Add("EditValue", _dtb, ".ParentId");
            lueRoute.DataBindings.Add("EditValue", _dtb, ".More");
            cbbDays.DataBindings.Add("EditValue", _dtb, ".More3");
            calNode.DataBindings.Add("EditValue", _dtb, ".Order");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            lueTransport.Properties.ReadOnly = isReadOnly;
            lueRoute.Properties.ReadOnly = isReadOnly;
            cbbDays.Properties.ReadOnly = isReadOnly;
            calNode.Properties.ReadOnly = isReadOnly;

            grcMain.Enabled = isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var id = (Guid)grvMain.GetFocusedRowCellValue("Id");
                var c = cbbDays.EditValue + "|" + lueTransport.EditValue + "|" + lueRoute.EditValue;

                var o = new Pol_Dictionary()
                {
                    Id = id,
                    ParentId = (Guid)lueTransport.EditValue,
                    Code = c,
                    Text = lueRoute.Text,
                    More = lueRoute.EditValue + "",
                    More3 = cbbDays.EditValue + "",
                    Order = calNode.Value.ToInt32(),
                    Type = Global.STR_NODE
                };

                var gui = new Guid();
                var ok = Guid.TryParse(lueTransport.EditValue + "", out gui);
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

                var c = cbbDays.EditValue + "|" + lueTransport.EditValue + "|" + lueRoute.EditValue;

                var o = new Pol_Dictionary()
                {
                    ParentId = (Guid)lueTransport.EditValue,
                    Code = c,
                    Text = lueRoute.Text,
                    More = lueRoute.EditValue + "",
                    More3 = cbbDays.EditValue + "",
                    Order = calNode.Value.ToInt32(),
                    Type = Global.STR_NODE
                };

                var gui = new Guid();
                var ok = Guid.TryParse(lueTransport.EditValue + "", out gui);
                if (ok) o.ParentId = gui;

                var oki = _bll.Pol_Dictionary.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Pol_Dictionary.Select((object)Global.STR_NODE);

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                grvMain.BestFitColumns();
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var a = cbbDays.Text.Length == 0 ? false : true;
            var days = cbbDays.Text.ToInt32();

            if (!a || days < 28 || days > 31)
            {
                cbbDays.Focus();
                XtraMessageBox.Show("Nhập số ngày (28 - 31)", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            var b = calNode.Text.Length == 0 ? false : true;
            if (!b || calNode.Value < 1)
            {
                calNode.Focus();
                XtraMessageBox.Show("Nhập nốt tài > 0", Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
        #endregion

        #region Methods
        public FrmTra_RegistryNode()
        {
            InitializeComponent();
            Text = STR_TITLE.ToUpper();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();
        }
        #endregion

        #region Events
        private void FrmTra_RegistryNode_Load(object sender, EventArgs e)
        {
            lueTransport.Properties.DataSource = _bll.Pol_Dictionary.SelectTransport();
            lueTransport.ItemIndex = 0;

            lueRoute.Properties.DataSource = _bll.Tra_Tariff.SelectForFixed();
            lueRoute.ItemIndex = 0;
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Đ.kí nốt tài";
        private const string STR_ADD = "Thêm " + STR_TITLE;
        private const string STR_EDIT = "Sửa " + STR_TITLE;
        private const string STR_DELETE = "Xoá " + STR_TITLE;

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "ĐÃ ĐĂNG KÍ RỒI";

        private const string STR_CHOICE = "CHỌN DÒNG CẦN XOÁ\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ";
        private const string STR_CHOICE_E = "CHỌN DÒNG CẦN SỬA\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ SỬA";
        #endregion
    }
}