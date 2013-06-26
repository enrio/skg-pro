﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 02/06/2013 20:32
 * Status: OK
 */
#endregion

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Normal
{
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;

    using DevExpress.XtraEditors;

    public partial class FrmTra_VehicleNormal : FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_VehicleNormal);
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
            txtCode.Properties.NullValuePrompt = String.Format("Nhập {0}", lblCode.Text.ToBetween(null, ":", Format.Lower));

            base.SetNullPrompt();
        }

        protected override void PerformFind()
        {
            _dtb = _bll.Tra_Vehicle.Find(txtCode.Text);

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                grvMain.BestFitColumns();
            }

            AllowDelete = false;
            AllowEdit = false;
            grvMain.Bands["badAudit"].Visible = true;

            base.PerformFind();
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

            var text = grvMain.GetFocusedRowCellValue("Code");
            var id = (Guid)tmpId;

            if (id == new Guid())
                XtraMessageBox.Show(STR_SELECT.ToUpper(), STR_DELETE.ToUpper(),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                var cfm = String.Format(STR_CONFIRM, text);
                var oki = XtraMessageBox.Show(cfm.ToUpper(), STR_DELETE.ToUpper(), MessageBoxButtons.OKCancel);

                if (oki == DialogResult.OK)
                    if (_bll.Tra_Vehicle.Delete(id) != null) PerformRefresh();
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

            AllowDelete = true;
            AllowEdit = true;
            var ql = Global.Session.User.CheckOperator() || Global.Session.User.CheckAdmin();
            if (!ql) grvMain.Bands["badAudit"].Visible = false;

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
                        NumOut = txtCode.Text;
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

            if (NumIn + "" != "") Close();
        }

        protected override void ResetInput()
        {
            txtCode.Text = null;
            txtSeats.Text = "0";
            txtBeds.Text = "0";

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            lueTransport.DataBindings.Clear();
            txtCode.DataBindings.Clear();
            txtSeats.DataBindings.Clear();
            txtBeds.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            lueTransport.DataBindings.Add("EditValue", _dtb, ".TariffId");
            txtCode.DataBindings.Add("EditValue", _dtb, ".Code");
            txtSeats.DataBindings.Add("EditValue", _dtb, ".Seats");
            txtBeds.DataBindings.Add("EditValue", _dtb, ".Beds");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            lueTransport.Properties.ReadOnly = isReadOnly;
            //txtCode.Properties.ReadOnly = isReadOnly;
            txtSeats.Properties.ReadOnly = isReadOnly;
            txtBeds.Properties.ReadOnly = isReadOnly;

            grcMain.Enabled = isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

                var o = new Tra_Vehicle()
                {
                    Id = id,
                    TariffId = (Guid)lueTransport.GetColumnValue("Id"),
                    Code = txtCode.Text,
                    Seats = txtSeats.Text.ToInt32(),
                    Beds = txtBeds.Text.ToInt32(),
                    Fixed = false,
                    City = false,
                    High = false
                };

                var oki = _bll.Tra_Vehicle.Update(o);
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

                var o = new Tra_Vehicle()
                {
                    TariffId = (Guid)lueTransport.GetColumnValue("Id"),
                    Code = txtCode.Text,
                    Seats = txtSeats.Text.ToInt32(),
                    Beds = txtBeds.Text.ToInt32(),
                    Fixed = false,
                    City = false,
                    High = false
                };

                var oki = _bll.Tra_Vehicle.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        public string num = "";
        protected override void LoadData()
        {
            if (num != "")
            {
                _dtb = _bll.Tra_Vehicle.Select((object)num);
                //PerformEdit();
            }
            else _dtb = _bll.Tra_Vehicle.SelectForNormal();

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                grvMain.BestFitColumns();
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var a = txtCode.Text.Length == 0 ? false : true;
            if (!a) txtCode.Focus();

            var oki = txtSeats.Text.Length == 0 ? false : true;
            if (!oki) XtraMessageBox.Show(STR_NOT_C, Text);

            var tmp = txtCode.Text.Replace(" ", "");
            txtCode.Text = tmp.ToUpper();
            return a && oki;
        }
        #endregion

        #region Methods
        public FrmTra_VehicleNormal()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();

            AllowFind = true;
        }
        #endregion

        #region Events
        private void FrmTra_VehicleNormal_Activated(object sender, EventArgs e)
        {
            // Bỏ qua xe ba gác
            lueTransport.Properties.DataSource = _bll.Tra_Tariff.SelectForNormal("J");
        }

        private void FrmTra_VehicleNormal_Load(object sender, EventArgs e)
        {
            if (NumIn + "" != "")
            {
                PerformAdd();
                txtCode.Text = NumIn;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Number input from vehicle ingate
        /// </summary>
        public string NumIn { set; private get; }

        /// <summary>
        /// Number outpur to vehicle ingate
        /// </summary>
        public string NumOut { private set; get; }
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Nhập-sửa xe vãng lai";
        private const string STR_ADD = "Thêm xe";
        private const string STR_EDIT = "Sửa xe";
        private const string STR_DELETE = "Xoá xe";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_NOT_C = "Chưa nhập số ghế!";

        private const string STR_DUPLICATE = "XE NÀY CÓ RỒI";

        private const string STR_CHOICE = "CHỌN DÒNG CẦN XOÁ\n\rHOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ";
        private const string STR_CHOICE_E = "CHỌN DÒNG CẦN SỬA\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ SỬA";
        #endregion
    }
}