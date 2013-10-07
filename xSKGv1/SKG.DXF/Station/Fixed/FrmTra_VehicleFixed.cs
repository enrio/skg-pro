#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 25/01/2012 21:07
 * Update: 26/09/2013 20:07
 * Status: OK
 */
#endregion

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Fixed
{
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;

    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;

    public partial class FrmTra_VehicleFixed : FrmInput
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
            txtCode.Properties.NullValuePrompt = String.Format("Nhập {0}",
                lblCode.Text.ToBetween(null, ":", Format.Lower));

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
            var oki = XtraMessageBox.Show(STR_CFM, STR_PRINT, MessageBoxButtons.YesNo);
            var tb = _bll.Tra_Vehicle.SelectForPrint(_term);

            if (oki == DialogResult.Yes)
            {
                var rpt = new Report.Rpt_VehicleFixed1
                {
                    Name = String.Format(STR_DT, Global.Session.User.Acc, Global.Session.Current),
                    DataSource = tb
                };

                rpt.parTitle1.Value = Global.Title1;
                rpt.parTitle2.Value = Global.Title2;
                rpt.parDate.Value = Global.Session.Current;

                frm.SetReport(rpt);
            }
            else
            {
                var rpt = new Report.Rpt_VehicleFixed2
                {
                    Name = String.Format(STR_DT, Global.Session.User.Acc, Global.Session.Current),
                    DataSource = tb
                };

                rpt.parTitle1.Value = Global.Title1;
                rpt.parTitle2.Value = Global.Title2;
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

        protected override void ResetInput()
        {
            txtCode.EditValue = null;
            txtSeats.EditValue = 0;
            txtBeds.EditValue = 0;
            txtIncome.EditValue = null;
            txtProductionYear.EditValue = null;

            dteLimitedRegistration.DateTime = _tomorrow;
            dteTermInsurance.DateTime = _tomorrow;
            dteTermFixedRoutes.DateTime = _tomorrow;
            dteTermRegistry.DateTime = _tomorrow;

            cheHigh.EditValue = false;
            cheCity.EditValue = false;
            txtHours.EditValue = null;
            txtNote.EditValue = null;

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            lueTransport.DataBindings.Clear();
            lueRoute.DataBindings.Clear();
            lueDriver.DataBindings.Clear();

            txtCode.DataBindings.Clear();
            txtSeats.DataBindings.Clear();
            txtBeds.DataBindings.Clear();
            txtIncome.DataBindings.Clear();
            txtProductionYear.DataBindings.Clear();

            dteLimitedRegistration.DataBindings.Clear();
            dteTermInsurance.DataBindings.Clear();
            dteTermFixedRoutes.DataBindings.Clear();
            dteTermRegistry.DataBindings.Clear();

            cheHigh.DataBindings.Clear();
            cheCity.DataBindings.Clear();
            txtHours.DataBindings.Clear();
            txtNote.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            lueTransport.DataBindings.Add("EditValue", _dtb, ".TransportId");
            lueRoute.DataBindings.Add("EditValue", _dtb, ".TariffId");
            lueDriver.DataBindings.Add("EditValue", _dtb, ".Driver");

            txtCode.DataBindings.Add("EditValue", _dtb, ".Code");
            txtSeats.DataBindings.Add("EditValue", _dtb, ".Seats");
            txtBeds.DataBindings.Add("EditValue", _dtb, ".Beds");
            txtIncome.DataBindings.Add("EditValue", _dtb, ".More");
            txtProductionYear.DataBindings.Add("EditValue", _dtb, ".ProductionYear");

            dteLimitedRegistration.DataBindings.Add("EditValue", _dtb, ".LimitedRegistration");
            dteTermInsurance.DataBindings.Add("EditValue", _dtb, ".TermInsurance");
            dteTermFixedRoutes.DataBindings.Add("EditValue", _dtb, ".TermFixedRoutes");
            dteTermRegistry.DataBindings.Add("EditValue", _dtb, ".TermDriverLicense");

            cheHigh.DataBindings.Add("EditValue", _dtb, ".High");
            cheCity.DataBindings.Add("EditValue", _dtb, ".City");
            txtHours.DataBindings.Add("EditValue", _dtb, ".Text");
            txtNote.DataBindings.Add("EditValue", _dtb, ".Note");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            lueTransport.Properties.ReadOnly = isReadOnly;
            lueRoute.Properties.ReadOnly = isReadOnly;

            txtCode.Properties.ReadOnly = isReadOnly;
            txtSeats.Properties.ReadOnly = isReadOnly;
            txtBeds.Properties.ReadOnly = isReadOnly;
            txtIncome.Properties.ReadOnly = isReadOnly;
            txtProductionYear.Properties.ReadOnly = isReadOnly;

            dteLimitedRegistration.Properties.ReadOnly = isReadOnly;
            dteTermInsurance.Properties.ReadOnly = isReadOnly;
            dteTermFixedRoutes.Properties.ReadOnly = isReadOnly;
            dteTermRegistry.Properties.ReadOnly = isReadOnly;

            cheHigh.Properties.ReadOnly = isReadOnly;
            cheCity.Properties.ReadOnly = isReadOnly;
            txtHours.Properties.ReadOnly = isReadOnly;
            txtNote.Properties.ReadOnly = isReadOnly;

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

                    Fixed = true,
                    Code = txtCode.Text,
                    Seats = txtSeats.Text.ToInt32(),
                    Beds = txtBeds.Text.ToInt32(),

                    ProductionYear = txtProductionYear.Text,
                    High = cheHigh.Checked,
                    City = cheCity.Checked,
                    Text = txtHours.Text,
                    Note = txtNote.Text,
                    More = txtIncome.Text
                };

                if (!dteLimitedRegistration.EditValue.IsNullOrEmpty())
                    o.LimitedRegistration = dteLimitedRegistration.DateTime;

                if (!dteTermInsurance.EditValue.IsNullOrEmpty())
                    o.TermInsurance = dteTermInsurance.DateTime;

                if (!dteTermFixedRoutes.EditValue.IsNullOrEmpty())
                    o.TermFixedRoutes = dteTermFixedRoutes.DateTime;

                if (!dteTermRegistry.EditValue.IsNullOrEmpty())
                    o.TermDriverLicense = dteTermRegistry.DateTime;

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

                    Fixed = true,
                    Code = txtCode.Text,
                    Seats = txtSeats.Text.ToInt32(),
                    Beds = txtBeds.Text.ToInt32(),

                    ProductionYear = txtProductionYear.Text,
                    High = cheHigh.Checked,
                    City = cheCity.Checked,
                    Text = txtHours.Text,
                    Note = txtNote.Text,
                    More = txtIncome.Text
                };

                if (!dteLimitedRegistration.EditValue.IsNullOrEmpty())
                    o.LimitedRegistration = dteLimitedRegistration.DateTime;

                if (!dteTermInsurance.EditValue.IsNullOrEmpty())
                    o.TermInsurance = dteTermInsurance.DateTime;

                if (!dteTermFixedRoutes.EditValue.IsNullOrEmpty())
                    o.TermFixedRoutes = dteTermFixedRoutes.DateTime;

                if (!dteTermRegistry.EditValue.IsNullOrEmpty())
                    o.TermDriverLicense = dteTermRegistry.DateTime;

                var oki = _bll.Tra_Vehicle.Insert(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_ADD);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = DataFilter == null ? _bll.Tra_Vehicle.SelectForFixed(_term) : DataFilter;

            if (_dtb != null) grcMain.DataSource = _dtb;
            grvMain.BestFitColumns();

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var a = txtCode.Text.Length == 0 ? false : true;
            if (!a)
            {
                txtCode.Focus();
                XtraMessageBox.Show(STR_NOT_V, Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            var b = txtSeats.Text.Length == 0 ? false : true;
            if (!b)
            {
                txtSeats.Focus();
                XtraMessageBox.Show(STR_NOT_C, Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            Text = STR_TITLE.ToUpper();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();

            AllowPrint = true;

            txtMark.Properties.ReadOnly = true;
            txtPhone.Properties.ReadOnly = true;
            dteTermDriverLicense.Properties.ReadOnly = true;
        }
        #endregion

        #region Events
        private void dteLimitedRegistration_EditValueChanged(object sender, EventArgs e)
        {
            dteLimitedRegistration.Properties.Appearance.BackColor = Color.Transparent;
            if (dteLimitedRegistration.EditValue.IsNullOrEmpty()) return;

            if (dteLimitedRegistration.DateTime <= _tomorrow)
                dteLimitedRegistration.Properties.Appearance.BackColor = Color.Red;
        }

        private void dteTermFixedRoutes_EditValueChanged(object sender, EventArgs e)
        {
            dteTermFixedRoutes.Properties.Appearance.BackColor = Color.Transparent;
            if (dteTermFixedRoutes.EditValue.IsNullOrEmpty()) return;

            if (dteTermFixedRoutes.DateTime <= _tomorrow)
                dteTermFixedRoutes.Properties.Appearance.BackColor = Color.Red;
        }

        private void dteTermInsurance_EditValueChanged(object sender, EventArgs e)
        {
            dteTermInsurance.Properties.Appearance.BackColor = Color.Transparent;
            if (dteTermInsurance.EditValue.IsNullOrEmpty()) return;

            if (dteTermInsurance.DateTime <= _tomorrow)
                dteTermInsurance.Properties.Appearance.BackColor = Color.Red;
        }

        private void dteTermDriverLicense_EditValueChanged(object sender, EventArgs e)
        {
            dteTermDriverLicense.Properties.Appearance.BackColor = Color.Transparent;
            if (dteTermDriverLicense.EditValue.IsNullOrEmpty()) return;

            if (dteTermDriverLicense.DateTime <= _tomorrow)
                dteTermDriverLicense.Properties.Appearance.BackColor = Color.Red;
        }

        private void dteTermRegistry_EditValueChanged(object sender, EventArgs e)
        {
            dteTermRegistry.Properties.Appearance.BackColor = Color.Transparent;
            if (dteTermRegistry.EditValue.IsNullOrEmpty()) return;

            if (dteTermRegistry.DateTime <= _tomorrow)
                dteTermRegistry.Properties.Appearance.BackColor = Color.Red;
        }

        private void cmdAllVehicle_Click(object sender, EventArgs e)
        {
            _term = TermForFixed.Default;
            PerformRefresh();
        }

        private void cmdLimitedRegistration_Click(object sender, EventArgs e)
        {
            _term = TermForFixed.Registration;
            PerformRefresh();
        }

        private void cmdTermFixedRoutes_Click(object sender, EventArgs e)
        {
            _term = TermForFixed.FixedRoutes;
            PerformRefresh();
        }

        private void cmdTermInsurance_Click(object sender, EventArgs e)
        {
            _term = TermForFixed.Insurance;
            PerformRefresh();
        }

        private void cmdTermDriverLicense_Click(object sender, EventArgs e)
        {
            _term = TermForFixed.DriverLicense;
            PerformRefresh();
        }

        private void lueRoute_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
                DXF.Extend.ShowRight<FrmTra_Tariff>(Global.Parent);
        }

        private void lueTransport_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
                DXF.Extend.ShowRight<FrmTra_Transport>(Global.Parent);
        }

        private void lueDriver_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                var frm = new FrmTra_DriverInfo()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Number = txtCode.Text
                };

                frm.AllowAdd = false;
                frm.ShowDialog();
                txtCode_EditValueChanged(sender, e);
            }
        }

        private void FrmTra_VehicleFixed_Activated(object sender, EventArgs e)
        {
            lueTransport.Properties.DataSource = _bll.Pol_Dictionary.SelectTransport();
            lueRoute.Properties.DataSource = _bll.Tra_Tariff.SelectForFixed();
            lueLicenseNo.Properties.DataSource = _bll.Pol_Dictionary.Select((object)Global.STR_DRIVER);

            if (DetailId == null)
            {
                groupBox4.Enabled = false;
                colDateIn.Visible = false;
                colDateOut.Visible = false;

                lueDriver.Properties.ReadOnly = false;
                lueLicenseNo.Properties.ReadOnly = false;
            }
            else
            {
                groupBox4.Enabled = true;
                colDateIn.Visible = true;
                colDateOut.Visible = true;
            }
        }

        private void txtCode_EditValueChanged(object sender, EventArgs e)
        {
            lueDriver.Properties.DataSource = _bll.Pol_Dictionary.SelectByMore(txtCode.Text, Global.STR_DRIVER);
            lueDriver_EditValueChanged(sender, e);
        }

        private void lueDriver_EditValueChanged(object sender, EventArgs e)
        {
            lueLicenseNo.EditValue = lueDriver.GetColumnValue("Code");
            txtMark.EditValue = lueDriver.GetColumnValue("Note");
            dteTermDriverLicense.EditValue = lueDriver.GetColumnValue("More1");
            txtPhone.EditValue = lueDriver.GetColumnValue("More2");
            chkTempOut.EditValue = grvMain.GetFocusedRowCellValue("Repair");
            chkNotEnough.EditValue = grvMain.GetFocusedRowCellValue("NotEnough").ToBoolean();
        }

        private void lueLicenseNo_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCode.Text.IsNullOrEmpty()) return;
            var code = lueLicenseNo.GetColumnValue("Code") + "";

            _bll.Pol_Dictionary.UpdateMoreByCode(code, txtCode.Text);
            lueDriver.Properties.DataSource = _bll.Pol_Dictionary.SelectByMore(txtCode.Text, Global.STR_DRIVER);

            lueDriver.EditValue = code;
            txtMark.EditValue = lueLicenseNo.GetColumnValue("Note");
            dteTermDriverLicense.EditValue = lueLicenseNo.GetColumnValue("More1");
            txtPhone.EditValue = lueLicenseNo.GetColumnValue("More2");
            chkTempOut.EditValue = grvMain.GetFocusedRowCellValue("Repair");
            chkNotEnough.EditValue = grvMain.GetFocusedRowCellValue("NotEnough").ToBoolean();
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            if (DetailId != null)
            {
                if (lueLicenseNo.Text.IsNullOrEmpty())
                {
                    XtraMessageBox.Show("Chưa nhập thông tin!", "Kiểm tra");
                    return;
                }

                var de = new Tra_Detail()
                {
                    Id = DetailId.Value,
                    More = lueDriver.EditValue + "",
                    Repair = chkTempOut.Checked,
                    Show = !chkNotEnough.Checked
                };

                _bll.Tra_Detail.UpdateDriver(de);

                DataFilter = _bll.Tra_Vehicle.FindForFixed(DetailId.Value);
                PerformRefresh();
                Close();
            }
            else XtraMessageBox.Show("Không kiểm tra được!", "Kiểm tra");
        }

        private void cmdUnTest_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Data filter when r-click on detail in, out
        /// </summary>
        public DataTable DataFilter { get; set; }

        /// <summary>
        /// Id of detail in, out
        /// </summary>
        public Guid? DetailId { get; set; }
        #endregion

        #region Fields
        /// <summary>
        /// Điều kiện lọc
        /// </summary>
        TermForFixed _term = TermForFixed.Default;

        /// <summary>
        /// Ngày hôm sau
        /// </summary>
        DateTime _tomorrow = Global.Session.Current.AddDays(2);
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

        private const string STR_CFM = "IN THEO MẪU 1 (CHỌN YES), MẪU 2 (CHỌN NO)";
        private const string STR_PRINT = "In danh sách";
        private const string STR_DT = "{0}{1:_dd.MM.yyyy_HH.mm.ss}_ds";

        private const string STR_CHOICE = "CHỌN DÒNG CẦN XOÁ\n\rHOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ";
        private const string STR_CHOICE_E = "CHỌN DÒNG CẦN SỬA\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ SỬA";
        #endregion
    }
}