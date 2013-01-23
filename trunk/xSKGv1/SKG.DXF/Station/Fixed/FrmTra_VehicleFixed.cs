#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 10/11/2012 18:07
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
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;

    public partial class FrmTra_VehicleFixed : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_VehicleFixed);
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

        protected override void PerformPrint()
        {
            var frm = new FrmPrint();
            var oki = XtraMessageBox.Show("In theo mẫu 1 (chọn Yes), mẫu 2 (chọn No)", "In danh sách", MessageBoxButtons.YesNo);

            if (oki == DialogResult.Yes)
            {
                var rpt = new Report.Rpt_FixedVehicle1
                {
                    Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_ds", Global.Session.User.Acc, Global.Session.Current)
                };

                rpt.DataSource = _bll.Tra_Vehicle.SelectForPrint();
                rpt.parDate.Value = Global.Session.Current;
                frm.SetReport(rpt);
            }
            else
            {
                var rpt = new Report.Rpt_FixedVehicle2
                {
                    Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_ds", Global.Session.User.Acc, Global.Session.Current)
                };

                rpt.DataSource = _bll.Tra_Vehicle.SelectForPrint();
                rpt.parDate.Value = Global.Session.Current;
                frm.SetReport(rpt);
            }

            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
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
            txtCode.Text = null;
            txtSeats.Text = "0";
            txtBeds.Text = "0";
            txtNode.Text = "0";

            txtDriver.Text = null;
            txtPhone.Text = null;

            txtHours.Text = null;
            txtDays.Text = null;
            calPrice.Text = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            lueTransport.DataBindings.Clear();
            lueRoute.DataBindings.Clear();
            txtCode.DataBindings.Clear();
            txtSeats.DataBindings.Clear();
            txtBeds.DataBindings.Clear();

            txtProductionYear.DataBindings.Clear();
            dteLimitedRegistration.DataBindings.Clear();
            dteTermInsurance.DataBindings.Clear();
            dteTermFixedRoutes.DataBindings.Clear();
            dteTermDriverLicense.DataBindings.Clear();

            cheHigh.DataBindings.Clear();
            cheCity.DataBindings.Clear();
            txtNode.DataBindings.Clear();

            txtDriver.DataBindings.Clear();
            txtPhone.DataBindings.Clear();

            txtHours.DataBindings.Clear();
            txtDays.DataBindings.Clear();
            calPrice.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            lueTransport.DataBindings.Add("EditValue", _dtb, ".TransportId");
            lueRoute.DataBindings.Add("EditValue", _dtb, ".TariffId");
            txtCode.DataBindings.Add("EditValue", _dtb, ".Code");
            txtSeats.DataBindings.Add("EditValue", _dtb, ".Seats");
            txtBeds.DataBindings.Add("EditValue", _dtb, ".Beds");

            txtProductionYear.DataBindings.Add("EditValue", _dtb, ".ProductionYear");
            dteLimitedRegistration.DataBindings.Add("EditValue", _dtb, ".LimitedRegistration");
            dteTermInsurance.DataBindings.Add("EditValue", _dtb, ".TermInsurance");
            dteTermFixedRoutes.DataBindings.Add("EditValue", _dtb, ".TermFixedRoutes");
            dteTermDriverLicense.DataBindings.Add("EditValue", _dtb, ".TermDriverLicense");

            cheHigh.DataBindings.Add("EditValue", _dtb, ".High");
            cheCity.DataBindings.Add("EditValue", _dtb, ".City");
            txtNode.DataBindings.Add("EditValue", _dtb, ".Node");

            txtDriver.DataBindings.Add("EditValue", _dtb, ".Driver");
            txtPhone.DataBindings.Add("EditValue", _dtb, ".Phone");

            txtHours.DataBindings.Add("EditValue", _dtb, ".Note");
            txtDays.DataBindings.Add("EditValue", _dtb, ".More");
            calPrice.DataBindings.Add("EditValue", _dtb, ".Price");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            lueTransport.Properties.ReadOnly = isReadOnly;
            lueRoute.Properties.ReadOnly = isReadOnly;
            txtCode.Properties.ReadOnly = isReadOnly;
            txtSeats.Properties.ReadOnly = isReadOnly;
            txtBeds.Properties.ReadOnly = isReadOnly;

            txtProductionYear.Properties.ReadOnly = isReadOnly;
            dteLimitedRegistration.Properties.ReadOnly = isReadOnly;
            dteTermInsurance.Properties.ReadOnly = isReadOnly;
            dteTermFixedRoutes.Properties.ReadOnly = isReadOnly;
            dteTermDriverLicense.Properties.ReadOnly = isReadOnly;

            cheHigh.Properties.ReadOnly = isReadOnly;
            cheCity.Properties.ReadOnly = isReadOnly;
            txtNode.Properties.ReadOnly = isReadOnly;

            txtDriver.Properties.ReadOnly = isReadOnly;
            txtPhone.Properties.ReadOnly = isReadOnly;

            txtHours.Properties.ReadOnly = isReadOnly;
            txtDays.Properties.ReadOnly = isReadOnly;
            calPrice.Properties.ReadOnly = isReadOnly;

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
                    TransportId = (Guid)lueTransport.GetColumnValue("Id"),
                    TariffId = (Guid)lueRoute.GetColumnValue("Id"),
                    Code = txtCode.Text,
                    Seats = txtSeats.Text.ToInt32(),
                    Beds = txtBeds.Text.ToInt32(),
                    Fixed = true,

                    ProductionYear = txtProductionYear.Text,
                    High = cheHigh.Checked,
                    City = cheCity.Checked,
                    Node = txtNode.Text.ToInt32(),

                    Driver = txtDriver.Text,
                    Phone = txtPhone.Text,

                    Text = calPrice.Value + "",
                    Note = txtHours.Text,
                    More = txtDays.Text
                };

                if (dteLimitedRegistration.EditValue + "" != "")
                    o.LimitedRegistration = dteLimitedRegistration.DateTime;

                if (dteTermInsurance.EditValue + "" != "")
                    o.TermInsurance = dteTermInsurance.DateTime;

                if (dteTermFixedRoutes.EditValue + "" != "")
                    o.TermFixedRoutes = dteTermFixedRoutes.DateTime;

                if (dteTermDriverLicense.EditValue + "" != "")
                    o.TermDriverLicense = dteTermDriverLicense.DateTime;

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
                    TransportId = (Guid)lueTransport.GetColumnValue("Id"),
                    TariffId = (Guid)lueRoute.GetColumnValue("Id"),
                    Code = txtCode.Text,
                    Seats = txtSeats.Text.ToInt32(),
                    Beds = txtBeds.Text.ToInt32(),
                    Fixed = true,

                    ProductionYear = txtProductionYear.Text,
                    High = cheHigh.Checked,
                    City = cheCity.Checked,
                    Node = txtNode.Text.ToInt32(),

                    Driver = txtDriver.Text,
                    Phone = txtPhone.Text,

                    Text = calPrice.Value + "",
                    Note = txtHours.Text,
                    More = txtDays.Text
                };

                if (dteLimitedRegistration.EditValue + "" != "")
                    o.LimitedRegistration = dteLimitedRegistration.DateTime;

                if (dteTermInsurance.EditValue + "" != "")
                    o.TermInsurance = dteTermInsurance.DateTime;

                if (dteTermFixedRoutes.EditValue + "" != "")
                    o.TermFixedRoutes = dteTermFixedRoutes.DateTime;

                if (dteTermDriverLicense.EditValue + "" != "")
                    o.TermDriverLicense = dteTermDriverLicense.DateTime;

                var oki = _bll.Tra_Vehicle.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Tra_Vehicle.SelectForFixed();

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
            }

            grvMain.BestFitColumns();
            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var a = txtCode.Text.Length == 0 ? false : true;
            if (!a)
            {
                txtCode.Focus();
                XtraMessageBox.Show(STR_NOT_V, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var b = txtSeats.Text.Length == 0 ? false : true;
            if (!b)
            {
                txtSeats.Focus();
                XtraMessageBox.Show(STR_NOT_C, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var c = txtNode.Text.Length == 0 ? false : true;
            if (!c)
            {
                txtNode.Focus();
                XtraMessageBox.Show(STR_NOT_N, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var tmp = txtCode.Text.Replace(" ", "");
            txtCode.Text = tmp.ToUpper();
            return true;
        }
        #endregion

        #region Methods
        public FrmTra_VehicleFixed()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();

            AllowPrint = true;

            Text = STR_TITLE.ToUpper();
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

        private void lueRoute_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                DXF.Extend.ShowRight<FrmTra_Tariff>(Global.Parent);
            }
        }

        private void lueTransport_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                DXF.Extend.ShowRight<FrmTra_Transport>(Global.Parent);
            }
        }

        private void FrmTra_VehicleFixed_Activated(object sender, EventArgs e)
        {
            lueTransport.Properties.DataSource = _bll.Pol_Dictionary.SelectTransport();
            lueRoute.Properties.DataSource = _bll.Tra_Tariff.SelectForFixed();
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Nhập-sửa xe cố định";
        private const string STR_ADD = "Thêm " + STR_TITLE;
        private const string STR_EDIT = "Sửa " + STR_TITLE;
        private const string STR_DELETE = "Xoá " + STR_TITLE;

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";

        private const string STR_NOT_V = "Chưa nhập biển số xe!";
        private const string STR_NOT_C = "Chưa nhập số ghế!";
        private const string STR_NOT_N = "Chưa nhập nốt tài/tháng!";
        private const string STR_DUPLICATE = "XE NÀY CÓ RỒI";

        private const string STR_CHOICE = "CHỌN DÒNG CẦN XOÁ\n\rHOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ";
        private const string STR_CHOICE_E = "CHỌN DÒNG CẦN SỬA\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ SỬA";
        #endregion
    }
}