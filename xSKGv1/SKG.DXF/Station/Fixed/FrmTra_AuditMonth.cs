using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Station.Fixed
{
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    public partial class FrmTra_AuditMonth : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(FrmTra_AuditMonth).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "THEO DÕI THÁNG",
                    Level = 3,
                    Order = 23,
                    Picture = @"Icons\Vehicle.png"
                };
                return menu;
            }
        }
        #endregion

        public string _num;

        public FrmTra_AuditMonth()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            AllowPrint = true;

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
            txtCode.Text = null;
            txtGuest.Text = "0";

            base.ResetInput();
        }

        protected override void ClearDataBindings()
        {
            txtCode.DataBindings.Clear();
            txtGuest.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            txtCode.DataBindings.Add("EditValue", _dtb, ".Code");
            txtGuest.DataBindings.Add("EditValue", _dtb, ".Guest");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            txtCode.Properties.ReadOnly = isReadOnly;
            txtGuest.Properties.ReadOnly = isReadOnly;

            grcMain.Enabled = isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

                var o = new Tra_Detail()
                {
                    Id = id,
                    Guest = txtGuest.Text.ToInt32()
                };

                var oki = _bll.Tra_Detail.UpdateGuest(o);
                if (oki == null) XtraMessageBox.Show(STR_DUPLICATE, STR_EDIT);

                return oki != null ? true : false;
            }
            catch { return false; }
        }

        public string num = "";
        protected override void LoadData()
        {
            _dtb = _bll.Tra_Detail.GetInDepotFixed();

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
            }

            base.LoadData();
        }

        protected override void PerformPrint()
        {
            var rpt = new Report.Rpt_Audit
            {
                Name = Global.Session.User.Acc +
                    Global.Session.Current.ToString("_dd.MM.yyyy_HH.mm.ss") + "_td"
            };

            var frm = new FrmPrint();
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
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

            var c = txtGuest.Text.Length == 0 ? false : true;
            if (!c)
            {
                txtGuest.Focus();
                XtraMessageBox.Show(STR_NOT_N, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        private void FrmTra_Media_Load(object sender, EventArgs e)
        {
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

        private const string STR_NOT_V = "Chưa nhập biển số xe!";
        private const string STR_NOT_C = "Chưa nhập số ghế!";
        private const string STR_NOT_N = "Chưa nhập lượt khách đi!";
    }
}