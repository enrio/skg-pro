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

namespace SKG.DXF.Station.Sumary
{
    using SKG.Extend;
    using SKG.Plugin;
    using DevExpress.XtraEditors;

    public partial class FrmTra_SalesFixed : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_SalesFixed);
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
        protected override void PerformDelete()
        {
            var tmpId = grvMain.GetFocusedRowCellValue("Id");
            if (tmpId == null)
            {
                XtraMessageBox.Show(STR_CHOICE,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var code = grvMain.GetFocusedRowCellValue("Code");
            var dateIn = grvMain.GetFocusedRowCellValue("DateIn");
            var id = (Guid)tmpId;

            if (id == new Guid()) XtraMessageBox.Show(STR_SELECT, STR_DELETE);
            else
            {
                var cfm = String.Format(STR_CONFIRM, code + " VÀO LÚC " + dateIn);
                var oki = XtraMessageBox.Show(cfm.ToUpper(), STR_DELETE, MessageBoxButtons.OKCancel);

                if (oki == DialogResult.OK)
                    if (_bll.Tra_Detail.Delete(id) != null) PerformRefresh();
                    else XtraMessageBox.Show(STR_UNDELETE, STR_DELETE);
            }

            base.PerformDelete();
        }

        protected override void PerformPrint()
        {
            var rpt = new Report.Rpt_Fixed
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_cd",
                Global.Session.User.Acc, Global.Session.Current)
            };

            DateTime shift;
            Session.Shift(out shift);

            rpt.xrlTitle.Text = "BẢNG KÊ DOANH THU XE KHÁCH BẾN XE NGÃ TƯ GA";
            rpt.xrlDuration.Text += "Từ ngày " + dteFrom.DateTime.ToString("dd/MM/yyyy");
            rpt.xrlDuration.Text += " đến ngày " + dteTo.DateTime.ToString("dd/MM/yyyy");

            rpt.parDate.Value = shift.Date;
            rpt.xrlCashier.Text = Global.Session.User.Name;

            var fr = dteFrom.DateTime.Date.AddHours(13).AddSeconds(1);
            var to = dteTo.DateTime.Date.AddHours(13);
            string receipt = "";

            rpt.DataSource = _bll.Tra_Detail.GetRevenueFixed(out _sum, out receipt, fr, to);
            rpt.xrcMoney.Text = _sum.ToVietnamese("đồng");
            rpt.xrlSophieu.Text = "Số phiếu: " + receipt;

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, _sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
        }

        protected override void LoadData()
        {
            var fr = dteFrom.DateTime.Date.AddHours(13).AddSeconds(1);
            var to = dteTo.DateTime.Date.AddHours(13);
            _dtb = _bll.Tra_Detail.SumaryFixed(out _sum, fr, to);

            grcMain.DataSource = _dtb;
            grvMain.BestFitColumns();

            base.LoadData();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            base.PerformRefresh();
        }
        #endregion

        #region Methods
        public FrmTra_SalesFixed()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();

            AllowAdd = false;
            AllowEdit = false;
            AllowSave = false;
            AllowCancel = false;
            AllowFind = false;
            AllowRefresh = false;
            AllowPrint = true;

            var d = Global.Session.Current;
            cbeMonth.SelectedIndex = (int)d.ToMonth() - 1;

            dteFrom.DateTime = d.AddDays(-1);
            dteTo.DateTime = d;

            var ql = Global.Session.User.CheckOperator() || Global.Session.User.CheckAdmin();
            if (!ql) cmdRestore.Visible = false;
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

        private void FrmTra_Sales_Activated(object sender, EventArgs e)
        {
            PerformRefresh();
        }

        private void cbeQuater_Validated(object sender, EventArgs e)
        {
            var a = cbeQuater.SelectedIndex + 1;
            var b = Global.Session.Current.Year;

            dteFrom.DateTime = b.ToStartOfQuarter(a).AddDays(-1);
            dteTo.DateTime = b.ToEndOfQuarter(a);
        }

        private void cbeMonth_Validated(object sender, EventArgs e)
        {
            var a = cbeMonth.SelectedIndex + 1;
            var b = Global.Session.Current.Year;
            var c = b.ToStartOfMonth(a).AddDays(-1);

            cbeQuater.SelectedIndex = (int)c.ToQuarter() - 1;
            dteFrom.DateTime = c;
            dteTo.DateTime = b.ToEndOfMonth(a);
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            PerformRefresh();
        }

        /// <summary>
        /// In phiếu thu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            var tmpId = grvMain.GetFocusedRowCellValue("Id");
            if (tmpId == null)
            {
                XtraMessageBox.Show(STR_CHOICE,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var detail = _bll.Tra_Detail.Find((Guid)tmpId);
            bool _isFixed = detail.Vehicle.Fixed;
            decimal total = 0;

            // Xe cố định, không đi sửa, xe đủ điều kiện
            if (_isFixed && !detail.Repair && detail.Show) // in phiếu thu xe cố định
            {
                var rpt = new Report.Rpt_Receipt();
                var tbl = new Station.DataSet.Dts_Fixed.ReceiptDataTable();
                var dtr = tbl.NewRow();

                dtr["Seri"] = String.Format("{0}/{1}", detail.Order, Global.Session.Current.Month);
                dtr["Date"] = Global.Session.Current;
                dtr["Number"] = detail.Vehicle.Code;
                dtr["Transport"] = detail.Vehicle.Transport.Text;

                dtr["Cost"] = detail.Cost;
                dtr["Rose"] = detail.Rose;

                var seat = detail.Seats ?? 0;
                var bed = detail.Beds ?? 0;
                dtr["CostDescript"] = String.Format("{0:#,0} x {1} + {2:#,0} x {3} = ",
                    detail.Price1, seat, detail.Price2, bed);
                dtr["RoseDescript"] = String.Format("{0:#,0} x {1} + {2:#,0} x {3} = ",
                    detail.Rose1, (seat < 1 ? 1 : seat - 1), detail.Rose2, bed);

                dtr["ArrearsDescript"] = String.Format("({0:#,0} + {1:#,0}) x {2} = ",
                    detail.Cost, detail.Rose, detail.Arrears ?? 0);
                var arrears = (detail.Cost + detail.Rose) * detail.Arrears ?? 0;
                total = arrears + detail.Cost + detail.Rose + detail.Parked;

                dtr["Arrears"] = arrears;
                dtr["Money"] = total;

                dtr["Parked"] = detail.Parked;
                dtr["ByChar"] = total.ToVietnamese("đồng");
                dtr["Creator"] = Global.Session.User.Name;
                dtr["Tariff"] = detail.Vehicle.Tariff.Text;

                tbl.Rows.Add(dtr);
                rpt.DataSource = tbl;

                try { rpt.Print(); }
                catch
                {
                    XtraMessageBox.Show("LỖI: MÁY KHÔNG IN ĐƯỢC!",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Phục hồi xe trạng thái xe trong bến
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRestore_Click(object sender, EventArgs e)
        {
            var tmpId = grvMain.GetFocusedRowCellValue("Id");
            if (tmpId == null)
            {
                XtraMessageBox.Show(STR_CHOICE_R,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var code = grvMain.GetFocusedRowCellValue("Code");
            var dateIn = grvMain.GetFocusedRowCellValue("DateIn");
            var id = (Guid)tmpId;

            var cfm = String.Format(STR_CONFIRM_R, code + " VÀO LÚC " + dateIn);
            var oki = XtraMessageBox.Show(cfm.ToUpper(), STR_RESTORE, MessageBoxButtons.OKCancel);

            if (oki == DialogResult.OK)
                if (_bll.Tra_Detail.Restore(id)) PerformRefresh();
                else XtraMessageBox.Show(STR_UNRESTORE, STR_RESTORE);
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        decimal _sum = 0;
        #endregion

        #region Constants
        private const string STR_TITLE = "Doanh thu xe cố định";
        private const string STR_SELECT = "Chọn dữ liệu!";

        private const string STR_DELETE = "Xoá xe";
        private const string STR_CONFIRM = "Có xoá xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";

        private const string STR_RESTORE = "Phục hồi";
        private const string STR_CONFIRM_R = "Có phục hồi xe '{0}' không?";
        private const string STR_UNRESTORE = "Không phục hồi được!";

        private const string STR_CHOICE = "CHỌN DÒNG CẦN XOÁ\n\rHOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ";
        private const string STR_CHOICE_R = "CHỌN DÒNG CẦN PHỤC HỒI\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ PHỤC HỒI";
        private const string STR_CHOICE_P = "CHỌN DÒNG CẦN IN\n\rHOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ IN";
        #endregion
    }
}