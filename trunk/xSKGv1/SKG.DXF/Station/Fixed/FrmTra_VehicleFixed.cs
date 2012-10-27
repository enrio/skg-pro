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

    public partial class FrmTra_VehicleFixed : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Code = typeof(FrmTra_VehicleFixed).FullName, Parent = typeof(Level2).FullName, Text = "Xe cố định", Level = 3, Order = 23, Picture = @"Icons\Vehicle.png" };
                return menu;
            }
        }
        #endregion

        public string _num;

        public FrmTra_VehicleFixed()
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
            txtCode.Properties.NullValuePrompt = String.Format("Nhập {0}", lblCode.Text.ToBetween(null, ":", Format.Lower));

            base.SetNullPrompt();
        }

        protected override void PerformDelete()
        {
            var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

            if (id == new Guid()) XtraMessageBox.Show(STR_SELECT, STR_DELETE);
            else
            {
                var cfm = String.Format(STR_CONFIRM, txtCode.Text);
                var oki = XtraMessageBox.Show(cfm, STR_DELETE, MessageBoxButtons.OKCancel);

                if (oki == DialogResult.OK)
                    if (_bll.Tra_Vehicle.Delete(id) != null) PerformRefresh();
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
            if (_num + "" != "") Close();
            base.PerformSave();
        }

        protected override void ResetInput()
        {
            lueTransport.ItemIndex = 0;
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

            txtProductionYear.DataBindings.Clear();
            dteLimitedRegistration.DataBindings.Clear();
            dteTermInsurance.DataBindings.Clear();
            dteTermFixedRoutes.DataBindings.Clear();
            dteTermDriverLicense.DataBindings.Clear();

            cheHigh.DataBindings.Clear();
            cheCity.DataBindings.Clear();
            txtServerQuality.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            lueTransport.DataBindings.Add("EditValue", _dtb, ".TransportId");
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
            txtServerQuality.DataBindings.Add("EditValue", _dtb, ".ServerQuality");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            lueTransport.Properties.ReadOnly = isReadOnly;
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
            txtServerQuality.Properties.ReadOnly = isReadOnly;

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
                    ServerQuality = txtServerQuality.Text
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
                    ServerQuality = txtServerQuality.Text
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

        public string num = "";
        protected override void LoadData()
        {
            if (num != "")
            {
                _dtb = _bll.Tra_Vehicle.Select((object)num);
                //PerformEdit();
            }
            else _dtb = _bll.Tra_Vehicle.SelectForFixed();

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var a = txtCode.Text.Length == 0 ? false : true;
            if (!a) txtCode.Focus();

            var oki = txtSeats.Text.Length == 0 ? false : true;
            if (!oki) XtraMessageBox.Show(STR_NOT_C, Text);

            return a && oki;
        }
        #endregion

        private void FrmTra_Media_Load(object sender, EventArgs e)
        {
            lueTransport.Properties.DataSource = _bll.Pol_Dictionary.SelectTransport();
            lueTransport.ItemIndex = 0;

            lueRoute.Properties.DataSource = _bll.Tra_Tariff.SelectForFixed();
            lueRoute.ItemIndex = 0;

            if (_num + "" != "")
            {
                PerformAdd();
                txtCode.Text = _num;
            }
        }

        private const string STR_ADD = "Thêm xe";
        private const string STR_EDIT = "Sửa xe";
        private const string STR_DELETE = "Xoá xe";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Xe này có rồi";

        private const string STR_NOT_C = "Chưa nhập số ghế!";
    }
}