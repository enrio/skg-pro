#region Information
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

namespace SKG.DXF.Station.Sumary
{
    using SKG.Extend;
    using SKG.Plugin;

    using DevExpress.XtraEditors;
    using DevExpress.XtraReports.UI;

    public partial class FrmTra_SalesFixed : FrmInput
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
        protected override void PerformInvoice()
        {
            XtraMessageBox.Show("Chức năng này chưa có", "Tính tiền");
            base.PerformInvoice();
        }

        /// <summary>
        /// Phục hồi xe trạng thái xe trong bến
        /// </summary>
        protected override void PerformRestore()
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

            base.PerformRestore();
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
            var oki = XtraMessageBox.Show(Level1.STR_CFM,
                Level1.STR_PRINT, MessageBoxButtons.YesNo);

            var receipt = "";
            var to = dteTo.DateTime.Date.AddTicks(Global.CutsFr.Ticks);
            var fr = dteFrom.DateTime.Date.AddTicks(Global.CutsFr.Ticks).AddSeconds(1);

            var tb = _bll.Tra_Detail.GetRevenueFixed(out _sum, out receipt, fr, to);
            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, _sum) };

            if (oki == DialogResult.Yes)
            {
                var rpt = new Report.Rpt_ReportFixed
                {
                    Name = String.Format(Level1.STR_DT,
                    Global.Session.User.Acc, Global.Session.Current),
                    DataSource = tb
                };

                rpt.parTitle1.Value = Global.Title1;
                rpt.parTitle2.Value = Global.Title2;
                rpt.parAddress.Value = Global.Address;
                rpt.parTaxcode.Value = Global.Taxcode;
                rpt.xrlTitle.Text = String.Format(rpt.xrlTitle.Text,
                    fr.ToStringDateVN(), to.ToStringDateVN());

                var duration = "(Từ {0} ngày {1} đến {2} ngày {3})";
                duration = String.Format(duration,
                  fr.ToStringTimeVN(), fr.ToStringDateVN(),
                  to.ToStringTimeVN(), to.ToStringDateVN());

                rpt.xrlFromTo.Text = duration;
                frm.SetReport(rpt);
            }
            else
            {
                var rpt = new Report.Rpt_RevenueFixed
                {
                    Name = String.Format(Level1.STR_DT,
                    Global.Session.User.Acc, Global.Session.Current),
                    DataSource = tb
                };

                rpt.parTitle1.Value = Global.Title1;
                rpt.parTitle2.Value = Global.Title2;
                rpt.parAddress.Value = Global.Address;
                rpt.parTaxcode.Value = Global.Taxcode;
                rpt.parDate.Value = to;

                //rpt.xrlCashier.Text = Global.Session.User.Name;
                //rpt.xrcMoney.Text = _sum.ToVietnamese("đồng");
                //rpt.xrlSophieu.Text = "Số phiếu: " + receipt;

                var duration = "(Từ {0} ngày {1} đến {2} ngày {3})";
                duration = String.Format(duration,
                  fr.ToStringTimeVN(), fr.ToStringDateVN(),
                  to.ToStringTimeVN(), to.ToStringDateVN());

                rpt.xrlFromTo.Text = duration;
                frm.SetReport(rpt);
            }

            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
        }

        protected override void LoadData()
        {
            var fr = dteFrom.DateTime.Date.AddTicks(Global.CutsFr.Ticks).AddSeconds(1);
            var to = dteTo.DateTime.Date.AddTicks(Global.CutsFr.Ticks);

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

            Text = STR_TITLE;

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

            var ql = Global.Session.User.CheckAdmin() || Global.Session.User.CheckOperator();
            if (ql)
            {
                AllowRestore = true;
                AllowInvoice = true;
            }
        }
        #endregion

        #region Events
        private void grvMain_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var tmpId = grvMain.GetFocusedRowCellValue("Id");
                if (tmpId == null)
                {
                    XtraMessageBox.Show(STR_CHOICE,
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                var id = (Guid)tmpId;
                var code = grvMain.GetFocusedRowCellValue("Code") + "";

                var frm = new Fixed.FrmTra_VehicleFixed()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    DataFilter = _bll.Tra_Vehicle.FindForFixed(id)
                };

                frm.DetailId = id;
                frm.AllowAdd = false;
                frm.ShowDialog();
                PerformRefresh();
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
            var seat = detail.Seats ?? 0;
            var bed = detail.Beds ?? 0;

            var note = (detail.Repair ? Global.STR_TEMP_OUT : "")
                                 + (detail.Show ? "" : ", " + Global.STR_NOT_VALUE)
                                 + (detail.Note == null ? "" : ", " + detail.Note);
            if (detail.Vehicle.More.ToInt32() > 0)
                note += String.Format("Xe thu khoán {0} ghế", seat);
            if (detail.Text + "" == Global.STR_ARREAR)
                note += detail.Text;

            note = note.Replace(", ", "").Trim();

            // Xe cố định, không đi sửa, xe đủ điều kiện
            if (_isFixed && !detail.Repair && detail.Show) // in phiếu thu xe cố định
            {
                var rpt = new Report.Rpt_Receipt();
                var tbl = new Station.DataSet.Dts_Fixed.ReceiptDataTable();
                var dtr = tbl.NewRow();

                rpt.parUnit.Value = Global.Title2;
                rpt.parAddress.Value = Global.Address;

                var cost = detail.Price1 * seat + detail.Price2 * bed;
                var rose = detail.Rose1 * (seat < 1 ? 1 : seat - 1) + detail.Rose2 * bed;
                var arrears = (cost + rose) * detail.Arrears ?? 0;
                var total = detail.Money + arrears;

                dtr["Seri"] = String.Format("{0}/{1}", detail.Order, Global.Session.Current.Month);
                dtr["Date"] = Global.Session.Current;
                dtr["Number"] = detail.Vehicle.Code;
                dtr["Transport"] = detail.Vehicle.Transport.Text;

                dtr["CostDescript"] = String.Format("{0:#,0} x {1} + {2:#,0} x {3} = ",
                    detail.Price1, seat, detail.Price2, bed);
                dtr["RoseDescript"] = String.Format("{0:#,0} x {1} + {2:#,0} x {3} = ",
                    detail.Rose1, (seat < 1 ? 1 : seat - 1), detail.Rose2, bed);

                dtr["Cost"] = cost;
                dtr["Rose"] = rose;

                dtr["ArrearsDescript"] = String.Format("({0:#,0} + {1:#,0}) x {2} = ",
                    cost, rose, detail.Arrears ?? 0);

                dtr["Arrears"] = arrears;
                dtr["Money"] = total;

                dtr["Parked"] = detail.Parked;
                dtr["ByChar"] = total.ToVietnamese("đồng");
                dtr["Creator"] = Global.Session.User.Name;
                dtr["Tariff"] = detail.Vehicle.Tariff.Text;
                dtr["Note"] = note.IsNullOrEmpty() ? "" : String.Format("({0})", note.ToUpperFirst());

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
        #endregion

        #region Properties
        #endregion

        #region Fields
        decimal _sum = 0;
        #endregion

        #region Constants
        private const string STR_TITLE = "DOANH THU XE CỐ ĐỊNH";
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