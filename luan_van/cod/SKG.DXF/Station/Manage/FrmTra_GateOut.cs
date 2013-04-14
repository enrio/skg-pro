﻿#region Information
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
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Manage
{
    using SKG.Extend;
    using SKG.Plugin;
    using DevExpress.XtraEditors;

    /// <summary>
    /// Cổng ra
    /// </summary>
    public partial class FrmTra_GateOut : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_GateOut);
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
        protected override void LoadData()
        {
            int fix, nor;
            _dtb = _bll.Tra_Detail.GetInDepot(out fix, out nor);
            var all = fix + nor;

            // Số lượng xe trong bến
            lblSum.Text = all.ToString("#,0");
            lblSum.Text += "\n\r" + fix.ToString("#,0"); // xe cố định
            lblSum.Text += "\n\r" + nor.ToString("#,0"); // xe vãng lai

            if (_dtb.Rows.Count > 0)
            {
                cmdInvoice.Enabled = true;
                lkeNumber.Properties.DataSource = _dtb;
                lkeNumber.ItemIndex = 0;
            }
            else cmdInvoice.Enabled = false;

            base.LoadData();
        }

        protected override void ResetInput()
        {
            lblGroup.Text = null;
            lblKind.Text = null;

            lblSeats.Text = null;
            lblBeds.Text = null;

            lblDateIn.Text = null;
            lblDateOut.Text = null;

            lblDeposit.Text = null;
            lblUserIn.Text = null;
            lblPhone.Text = null;

            lblNumber.Text = null;
            lblNote.Text = null;

            lblTotal.Text = null;
            lblMoney.Text = null;
            lblArrears.Text = null;

            txtNote.Text = null;

            base.ResetInput();
        }

        protected override void PerformRefresh()
        {
            ResetInput();
            LoadData();

            base.PerformRefresh();
        }
        #endregion

        #region Methods
        public FrmTra_GateOut()
        {
            InitializeComponent();

            dockPanel2.SetDockPanel("CỔNG RA-CHO XE RA BẾN");
            tmrMain.Enabled = true;

            AllowAdd = false;
            AllowEdit = false;
            AllowDelete = false;
            AllowSave = false;
            AllowCancel = false;
            AllowFind = false;
            AllowPrint = false;

            lblCaption.Text = "Xe trong bến:";
            lblCaption.Text += "\n\r - Cố định:";
            lblCaption.Text += "\n\r - Vãng lai:";
        }

        /// <summary>
        /// Tính tiền và cho xe ra bến
        /// </summary>
        /// <param name="isOut">Cho xe ra</param>
        private void Invoice(bool isOut = false, bool isRepair = true)
        {
            try
            {
                if (lkeNumber.Text == "") return;
                var detail = _bll.Tra_Detail.InvoiceOut(lkeNumber.Text, isOut, null, isRepair, txtNote.Text, txtSeri.Text);

                _isFixed = detail.Vehicle.Fixed;
                var seat = detail.Seats ?? 0;
                var bed = detail.Beds ?? 0;

                var cost = detail.Price1 * seat + detail.Price2 * bed;
                var rose = detail.Rose1 * (seat < 1 ? 1 : seat - 1) + detail.Rose2 * bed;
                var arrears = (cost + rose) * detail.Arrears ?? 0;

                if (_isFixed)
                {
                    lblKind.Text = "Tuyến: " + detail.Vehicle.Tariff.Text;
                    lblGroup.Text = "ĐVVT: " + detail.Vehicle.Transport.Text;
                    lblHalfDay.Text = "Ghế:";
                    lblFullDay.Text = "Giường:";

                    if (detail.Arrears != null)
                    {
                        if (detail.Arrears > 0)
                            lblArrears.Text = String.Format("TRUY THU {0:#,0}L = {1:#,0đ}", detail.Arrears, arrears);
                    }
                }
                else
                {
                    lblSeri.Visible = !isOut;
                    txtSeri.Visible = !isOut;
                    if (isOut)
                        txtSeri.Text = "";
                    else txtSeri.Focus();

                    lblKind.Text = "Loại xe: " + detail.Vehicle.Tariff.Text;
                    lblGroup.Text = "Nhóm xe: " + detail.Vehicle.Tariff.Group.Text;
                    lblHalfDay.Text = "Nửa ngày:";
                    lblFullDay.Text = "Một ngày:";

                    lblArrears.Text = null;
                }

                lblNumber.Text = "BS " + detail.Vehicle.Code;
                lblSeats.Text = seat.ToString("#,0");
                lblBeds.Text = bed.ToString("#,0");

                lblDateIn.Text = detail.DateIn.ToString("dd/MM/yyyy HH:mm:ss");
                lblDateOut.Text = detail.DateOut.Value.ToString("dd/MM/yyyy HH:mm:ss");

                lblPrice1.Text = detail.Price1.ToString("#,0");
                lblRose1.Text = detail.Rose1.ToString("#,0");

                lblPrice2.Text = detail.Price2.ToString("#,0");
                lblRose2.Text = detail.Rose2.ToString("#,0");
                lblMoney.Text = (detail.Repair ? "PHÍ ĐẬU ĐÊM " : "LỆ PHÍ ")
                    + (detail.Money == 0 ? "0đ" : detail.Money.ToString("#,0đ"));

                var total = detail.Money + arrears;
                lblTotal.Text = total.ToString("PHẢI THU #,0đ");

                var d = detail.DateOut.Value - detail.DateIn;
                lblDeposit.Text = String.Format("Lưu đậu tại bến: {0}ngày {1}giờ {2}phút {3}giây",
                    d.Days, d.Hours, d.Minutes, d.Seconds);

                lblUserIn.Text = "Cho vào: " + detail.UserIn.Name;
                lblPhone.Text = "Số ĐT: " + detail.UserIn.Phone;

                detail.Note += "";
                var split = detail.Note.Split(new string[] { ";!;" }, StringSplitOptions.None);
                lblNote.Text = split.Length > 0 ? split[0] : "";
                txtNote.Text = split.Length > 1 ? split[1] : "";

                if (isOut)
                {
                    PerformRefresh();

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

                cmdOut.Enabled = !isOut;
                cmdTariff.Enabled = !isOut;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi tính tiền;" + ex.Message, Text);
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Hiện bảng đơn giá
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdTariff_Click(object sender, EventArgs e)
        {
            var frm = new Frm_Tariff();

            frm.lblPrice1.Text = lblPrice1.Text;
            frm.lblPrice2.Text = lblPrice2.Text;

            frm.lblRose1.Text = lblRose1.Text;
            frm.lblRose2.Text = lblRose2.Text;

            if (_isFixed)
            {
                frm.lblHalfDay.Text = "Ghế:";
                frm.lblFullDay.Text = "Giường:";
            }
            else
            {
                frm.lblHalfDay.Text = "Nửa ngày:";
                frm.lblFullDay.Text = "Một ngày:";
            }

            frm.ShowDialog();
        }

        /// <summary>
        /// Ẩn toolbar nhập liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTra_GateOut_Load(object sender, EventArgs e)
        {
            AllowBar = false;

            if (_ql)
            {
                cmdInvoice.Visible = false;
                cmdOut.Visible = false;
                cmdSumary1.Visible = false;
                cmdSumary2.Visible = false;
                cmdSumaryFixed.Visible = false;
                cmdPrintIngate.Visible = false;

                cmdTempOut.Visible = true;
                cmdNotEnough.Visible = true;
            }
            else txtNote.Properties.ReadOnly = true;
        }

        /// <summary>
        /// Tính tiền
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdInvoice_Click(object sender, EventArgs e)
        {
            Invoice();
        }

        /// <summary>
        /// Cho xe ra bến
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOut_Click(object sender, EventArgs e)
        {
            Invoice(true);
        }

        /// <summary>
        /// In bảng kê nhóm 1 - xe tải lưu đậu nhóm xe vãng lai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSumary1_Click(object sender, EventArgs e)
        {
            var rpt = new Report.Rpt_Normal
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_n1", Global.Session.User.Acc, Global.Session.Current)
            };
            decimal sum = 0;

            var to = Global.Session.Current.Date.AddHours(14);
            var fr = to.AddDays(-1).AddSeconds(1);

            Session.CutShiftNormal(Global.Session.Current, out fr, out to);
            rpt.xrcWatch.Text = String.Format("{0:HH:mm} - {1:HH:mm}", fr, to);

            _dtb = _bll.Tra_Detail.GetRevenueNormal(out sum, fr, to, DAL.Tra_DetailDAL.Group.A);
            rpt.DataSource = _dtb;

            rpt.parDate.Value = Global.Session.Current;
            rpt.parUserOut.Value = Global.Session.User.Name;

            rpt.xrcMoney.Text = sum.ToVietnamese("đồng");
            rpt.xrlTitle.Text = "BẢNG KÊ THU PHÍ LƯU ĐẬU XE TẢI";

            rpt.xrcLve1.Text = "15.000";
            rpt.xrcLve2.Text = "20.000";
            rpt.xrcLve3.Text = "25.000";
            rpt.xrcLve4.Text = "30.000";
            rpt.xrcLve5.Text = "35.000";

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,0}", Text, sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        /// <summary>
        /// In bảng kê nhóm 2 - xe sang hàng nhóm xe vãng lai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSumary2_Click(object sender, EventArgs e)
        {
            var rpt = new Report.Rpt_Normal
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_n2", Global.Session.User.Acc, Global.Session.Current)
            };
            decimal sum = 0;

            var to = Global.Session.Current.Date.AddHours(14);
            var fr = to.AddDays(-1).AddSeconds(1);

            Session.CutShiftNormal(Global.Session.Current, out fr, out to);
            rpt.xrcWatch.Text = String.Format("{0:HH:mm} - {1:HH:mm}", fr, to);

            _dtb = _bll.Tra_Detail.GetRevenueNormal(out sum, fr, to, DAL.Tra_DetailDAL.Group.B);
            rpt.DataSource = _dtb;

            rpt.parDate.Value = Global.Session.Current;
            rpt.parUserOut.Value = Global.Session.User.Name;

            rpt.xrcMoney.Text = sum.ToVietnamese("đồng");
            rpt.xrlTitle.Text = "BẢNG KÊ THU PHÍ DỊCH VỤ XE SANG HÀNG";

            rpt.xrcLve1.Text = "5.000";
            rpt.xrcLve2.Text = "8.000";
            rpt.xrcLve3.Text = "10.000";
            rpt.xrcLve4.Text = "15.000";
            rpt.xrcLve5.Text = "";

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,0}", Text, sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        /// <summary>
        /// In bảng kê xe cố định từ 13:00 hôm trước đến 13:00 hôm nay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSumaryFixed_Click(object sender, EventArgs e)
        {
            var rpt = new Report.Rpt_Fixed1
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_cd", Global.Session.User.Acc, Global.Session.Current)
            };
            decimal sum = 0;
            string receipt = "";

            rpt.DataSource = _bll.Tra_Detail.GetRevenueToday(out sum, out  receipt);
            rpt.xrcMoney.Text = sum.ToVietnamese("đồng");

            rpt.parDate.Value = Global.Session.Current.Date;
            rpt.xrlCashier.Text = Global.Session.User.Name;
            rpt.xrlSophieu.Text = "Số phiếu: " + receipt;

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,0}", Text, sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        /// <summary>
        /// Cập nhật lại danh sách xe trong bến
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkeNumber_Enter(object sender, EventArgs e)
        {
            PerformRefresh();
        }

        private void cmdTempOut_Click(object sender, EventArgs e)
        {
            var ok = XtraMessageBox.Show("XÁC NHẬN TẠM RA BẾN?", Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok == DialogResult.No) return;

            Invoice(false, true);
        }

        private void cmdNotEnough_Click(object sender, EventArgs e)
        {
            var ok = XtraMessageBox.Show("XÁC NHẬN KHÔNG ĐỦ ĐIỀU KIỆN?", Text,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok == DialogResult.No) return;

            Invoice(false, false);
            PerformRefresh();
        }

        private void cmdPrintIngate_Click(object sender, EventArgs e)
        {
            var rpt = new Report.Rpt_IngateMaster
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_vl", Global.Session.User.Acc, Global.Session.Current)
            };

            var tb = _bll.Tra_Detail.GetInDepotFixed();
            tb.Numbered();
            var sub = new Report.Rpt_Ingate() { DataSource = tb };
            rpt.xrSubreport1.ReportSource = sub;

            tb = _bll.Tra_Detail.GetInDepotNormal();
            tb.Numbered();
            sub = new Report.Rpt_Ingate() { DataSource = tb };
            rpt.xrSubreport2.ReportSource = sub;

            rpt.parDate.Value = Global.Session.Current;
            rpt.parUserOut.Value = Global.Session.User.Name;

            var frm = new FrmPrint();
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        bool _isFixed;
        bool _ql = Global.Session.User.CheckOperator() || Global.Session.User.CheckAdmin();
        #endregion

        #region Constants
        private const string STR_TITLE = "Cổng ra";
        #endregion
    }
}