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
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Fixed
{
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    public partial class FrmTra_AuditDay : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_AuditDay);
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
        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            grvMain.OptionsBehavior.Editable = !isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override void PerformEdit()
        {
            grvMain.OptionsBehavior.Editable = true;
            base.PerformEdit();
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
                    if (!ValidInput()) return;
                    var o = _bll.Tra_Vehicle.Select(txtNumber.Text);

                    if (o == null)
                    {
                        XtraMessageBox.Show(String.Format(STR_NO_HAVE, txtNumber.Text), STR_MANAG,
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    var ve = (Tra_Vehicle)o;
                    if (!ve.Fixed)
                    {
                        XtraMessageBox.Show(String.Format(STR_WARNING, txtNumber.Text), STR_NORMAL,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (ve.TariffId == null)
                    {
                        XtraMessageBox.Show(String.Format(STR_WARNING_ROUTE, txtNumber.Text), STR_NORMAL,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

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

        protected override bool UpdateObject()
        {
            try
            {
                //if (!ValidInput()) return false;

                var tb = _dtb.GetChanges(DataRowState.Modified);
                foreach (DataRow r in tb.Rows)
                {
                    var id = (Guid)r["Id"];
                    var guest = "" + r["Guest"];
                    var discount = "" + r["Discount"];
                    var arrears = "" + r["Arrears"];

                    var o = new Tra_Detail()
                    {
                        Id = id,
                        Guest = guest.ToInt32(),
                        Discount = discount.ToInt32(),
                        Arrears = arrears.ToInt32()
                    };

                    _bll.Tra_Detail.UpdateMore(o);
                }
                return true;
            }
            catch { return false; }
        }

        public string num = "";
        protected override void LoadData()
        {
            DateTime fr, to;
            Session.CutShiftDay(dteDay.DateTime, out fr, out to);

            var isOut = (bool)radType.Properties.Items[radType.SelectedIndex].Value;
            _dtb = _bll.Tra_Detail.GetAuditFixed(fr, to, isOut);

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                grvMain.BestFitColumns();
            }

            base.LoadData();
        }

        protected override void PerformPrint()
        {
            var rpt = new Report.Rpt_AuditDay
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_tdn", Global.Session.User.Acc, Global.Session.Current)
            };
            int lxe, hk;
            decimal money;

            DateTime fr, to;
            Session.CutShiftDay(dteDay.DateTime, out fr, out to);

            rpt.DataSource = _bll.Tra_Detail.AuditDayFixed(fr, to, chkHideActive.Checked, out lxe, out hk, out money);
            rpt.xrlCashier.Text = Global.Session.User.Name;
            rpt.parDate.Value = Global.Session.Current;
            rpt.xrlTitle.Text += dteDay.DateTime.ToString(" dd/MM/yyyy");

            rpt.parLxe.Value = lxe;
            rpt.parHk.Value = hk;
            rpt.parDt.Value = money;

            var frm = new FrmPrint();
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
        }

        protected override bool ValidInput()
        {
            var oki = txtNumber.Text.Length == 0 ? false : true;
            if (!oki) XtraMessageBox.Show(STR_NOT_INP,
                          STR_ADD,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning);
            else
                txtNumber.Text = txtNumber.Text.Replace(" ", "");
            return oki;
        }

        protected override void ResetInput()
        {
            txtNumber.Text = null;
            txtArrears.Text = null;

            base.ResetInput();
        }

        protected override bool InsertObject()
        {
            try
            {
                var id = _bll.Tra_Vehicle.CheckExist(txtNumber.Text);

                if (id != new Guid())
                {
                    var o = new Tra_Detail()
                    {
                        UserInId = Global.Session.User.Id,
                        VehicleId = id,
                        DateIn = Global.Session.Current,
                        Code = txtNumber.Text,
                        Arrears = txtArrears.Text.ToInt32(),
                        Note = "ĐỘI ĐIỀU HÀNH: CHO VÀO ĐỂ TRUY THU;!;Thu tiền truy thu",
                        More = Global.STR_ARREAR
                    };

                    if (_bll.Tra_Detail.Insert(o) != null) return true;
                    else
                    {
                        XtraMessageBox.Show(STR_IN_GATE, STR_ADD,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else return false;
            }
            catch { return false; }
        }
        #endregion

        #region Methods
        public FrmTra_AuditDay()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();

            AllowDelete = false;
            AllowRefresh = false;
            AllowPrint = true;

            dteDay.DateTime = Global.Session.Current;
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

        private void dteDay_Validated(object sender, EventArgs e)
        {
            PerformRefresh();
        }

        private void dteDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PerformRefresh();
        }

        private void FrmTra_AuditMonth_Activated(object sender, EventArgs e)
        {
            PerformRefresh();
        }

        private void radType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformRefresh();
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        public string _num;
        #endregion

        #region Constants
        private const string STR_TITLE = "Theo dõi ngày";

        private const string STR_ADD = "Thêm chi tiết ra/vào";
        private const string STR_DELETE = "Xoá chi tiết ra/vào";
        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng!";

        private const string STR_CONFIRM = "CÓ XOÁ XE: {0}\nT.GIAN VÀO: {1}\nKHÔNG?";
        private const string STR_NO_HAVE = "BIỂN SỐ {0} CHƯA CÓ TRONG DANH SÁCH QUẢN LÝ\nLIÊN HỆ ĐỘI ĐIỀU HÀNH ĐỂ NHẬP THÔNG TIN XE";
        private const string STR_WARNING = "BIỂN SỐ {0} LÀ XE VÃNG LAI\nXIN HÃY NHẬP BÊN CỔNG VÀO VÃNG LAI";
        private const string STR_WARNING_ROUTE = "BIỂN SỐ {0} CHƯA ĐĂNG KÝ TUYẾN";
        private const string STR_IN_GATE = "XE NÀY ĐANG Ở TRONG BẾN!";
        private const string STR_NOT_INP = "CHƯA NHẬP BIỂN SỐ!";
        private const string STR_MANAG = "CHƯA QUẢN LÝ";

        private const string STR_INTO = "CHO XE VÀO";
        private const string STR_NORMAL = "XE VÃNG LAI";
        private const string STR_FIXED = "XE CỐ ĐỊNH";
        #endregion
    }
}