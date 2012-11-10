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
using System.Collections.Generic;
using System.Windows.Forms;

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
                var menu = new Menuz
                {
                    Code = typeof(FrmTra_GateOut).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "CỔNG RA",
                    Level = 3,
                    Order = 28,
                    Picture = @"Icons\GateOut.png"
                };
                return menu;
            }
        }
        #endregion

        public FrmTra_GateOut()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

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

            var ql = Global.Session.User.CheckOperator() || Global.Session.User.CheckAdmin();
            if (ql)
            {
                cmdInvoice.Text = "Tạm ra bến";
                cmdInvoice.Width += 10;

                cmdOut.Visible = false;
                cmdSumary1.Visible = false;
                cmdSumary2.Visible = false;
                cmdSumaryFixed.Visible = false;
            }
        }

        #region Events
        private void cmdInvoice_Click(object sender, EventArgs e)
        {
            Invoice();
            cmdOut.Enabled = true;
        }

        private void cmdOut_Click(object sender, EventArgs e)
        {
            Invoice(true);
            cmdOut.Enabled = false;
        }

        private void cmdSumary1_Click(object sender, EventArgs e)
        {
            var rpt = new Report.Rpt_Normal
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_n1", Global.Session.User.Acc, Global.Session.Current)
            };
            decimal sum = 0;

            rpt.DataSource = _bll.Tra_Detail.SumaryNormal(out sum, DAL.Tra_DetailDAL.Group.A);
            rpt.xrcMoney.Text = sum.ToVietnamese("đồng");
            rpt.xrLabel1.Text = "BẢNG KÊ THU PHÍ LƯU ĐẬU XE TẢI";

            rpt.xrcLve1.Text = "15.000";
            rpt.xrcLve2.Text = "20.000";
            rpt.xrcLve3.Text = "25.000";
            rpt.xrcLve4.Text = "30.000";
            rpt.xrcLve5.Text = "35.000";

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        private void cmdSumary2_Click(object sender, EventArgs e)
        {
            var rpt = new Report.Rpt_Normal
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_n2", Global.Session.User.Acc, Global.Session.Current)
            };
            decimal sum = 0;

            rpt.DataSource = _bll.Tra_Detail.SumaryNormal(out sum, DAL.Tra_DetailDAL.Group.B);
            rpt.xrcMoney.Text = sum.ToVietnamese("đồng");
            rpt.xrLabel1.Text = "BẢNG KÊ THU PHÍ DỊCH VỤ XE SANG HÀNG";

            rpt.xrcLve1.Text = "5.000";
            rpt.xrcLve2.Text = "8.000";
            rpt.xrcLve3.Text = "10.000";
            rpt.xrcLve4.Text = "15.000";
            rpt.xrcLve5.Text = "";

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        private void cmdSumaryFixed_Click(object sender, EventArgs e)
        {
            var rpt = new Report.Rpt_Fixed
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_cd", Global.Session.User.Acc, Global.Session.Current)
            };
            decimal sum = 0;

            rpt.DataSource = _bll.Tra_Detail.GetRevenueToday(out sum);
            rpt.xrcMoney.Text = sum.ToVietnamese("đồng");

            rpt.parDate.Value = Global.Session.Current.Date;
            rpt.xrlCashier.Text = Global.Session.User.Name;

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        private void lkeNumber_Enter(object sender, EventArgs e)
        {
            PerformRefresh();
        }
        #endregion

        #region Override
        protected override void LoadData()
        {
            _dtb = _bll.Tra_Detail.GetInDepot();
            if (_dtb.Rows.Count > 0)
            {
                cmdInvoice.Enabled = true;

                lkeNumber.Properties.DataSource = _dtb;
                lkeNumber.ItemIndex = 0;
            }
            else
            {
                cmdInvoice.Enabled = false;

                lblHalfDay.Text = "Nửa ngày:";
                lblFullDay.Text = "Một ngày:";

                lblMoney.Text = null;
                lblNumber.Text = null;

                lblDateIn.Text = null;
                lblDateOut.Text = null;

                lblSeats.Text = null;
                lblBeds.Text = null;

                lblPrice1.Text = null;
                lblRose1.Text = null;

                lblPrice2.Text = null;
                lblRose2.Text = null;

                lblDeposit.Text = null;
                lblNote.Text = null;

                lblUserIn.Text = null;
                lblPhone.Text = null;

                lkeNumber.Properties.DataSource = null;
            }

            base.LoadData();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            var a = _bll.Tra_Detail.SumInDepotFixed;
            var b = _bll.Tra_Detail.SumInDepotNormal;
            var c = a + b;

            lblSum.Text = c.ToString("#,0");
            lblSum.Text += "\n\r" + a.ToString("#,0");
            lblSum.Text += "\n\r" + b.ToString("#,0");

            lblKind.Text = null;
            lblGroup.Text = null;
            lblHalfDay.Text = null;
            lblFullDay.Text = null;

            lblNumber.Text = null;
            lblDateIn.Text = null;
            lblDateOut.Text = null;

            lblSeats.Text = null;
            lblBeds.Text = null;

            lblPrice1.Text = null;
            lblRose1.Text = null;

            lblPrice2.Text = null;
            lblRose2.Text = null;

            lblMoney.Text = null;
            lblDeposit.Text = null;

            lblUserIn.Text = null;
            lblPhone.Text = null;
            lblNote.Text = null;

            base.PerformRefresh();
        }
        #endregion

        bool _isFixed;
        /// <summary>
        /// Tính tiền và cho xe ra bến
        /// </summary>
        /// <param name="isOut">Cho xe ra</param>
        private void Invoice(bool isOut = false)
        {
            try
            {
                if (lkeNumber.Text == "") return;
                var detail = _bll.Tra_Detail.InvoiceOut(lkeNumber.Text, isOut);
                _isFixed = detail.Tra_Vehicle.Fixed;

                if (_isFixed)
                {
                    lblKind.Text = "Tuyến: " + detail.Tra_Vehicle.Tariff.Text;
                    lblGroup.Text = "ĐVVT: " + detail.Tra_Vehicle.Transport.Text;
                    lblHalfDay.Text = "Ghế:";
                    lblFullDay.Text = "Giường:";
                }
                else
                {
                    lblKind.Text = "Loại xe: " + detail.Tra_Vehicle.Tariff.Text;
                    lblGroup.Text = "Nhóm xe: " + detail.Tra_Vehicle.Tariff.Group.Text;
                    lblHalfDay.Text = "Nửa ngày:";
                    lblFullDay.Text = "Một ngày:";
                }

                lblNumber.Text = "BS " + detail.Tra_Vehicle.Code;

                lblDateIn.Text = detail.DateIn.ToString("dd/MM/yy HH:mm:ss");
                lblDateOut.Text = detail.DateOut.Value.ToString("dd/MM/yy HH:mm:ss");

                lblSeats.Text = detail.Seats == null ? null : detail.Seats.Value.ToString("#,#");
                lblBeds.Text = detail.Beds == null ? null : detail.Beds.Value.ToString("#,#");

                lblPrice1.Text = detail.Price1.ToString("#,#");
                lblRose1.Text = detail.Rose1.ToString("#,#");

                lblPrice2.Text = detail.Price2.ToString("#,#");
                lblRose2.Text = detail.Rose2.ToString("#,#");
                lblMoney.Text = (detail.Repair ? "PHÍ ĐẬU ĐÊM " : "LỆ PHÍ ")
                    + (detail.Money == 0 ? "0đ" : detail.Money.ToString("#,#đ"));

                var d = detail.DateOut.Value - detail.DateIn;
                lblDeposit.Text = String.Format("Lưu đậu tại bến: {0}ngày {1}giờ {2}phút {3}giây",
                    d.Days, d.Hours, d.Minutes, d.Seconds);

                lblUserIn.Text = "Cho vào: " + detail.Pol_UserIn.Name;
                lblPhone.Text = "Số ĐT: " + detail.Pol_UserIn.Phone;
                lblNote.Text = detail.Note;

                if (isOut)
                {
                    if (_isFixed && !detail.Repair)
                    {
                        var rpt = new Report.Rpt_Receipt
                        {
                            Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_pt", Global.Session.User.Acc, Global.Session.Current)
                        };

                        var tbl = new Station.DataSet.Dts_Fixed.ReceiptDataTable();
                        var dtr = tbl.NewRow();

                        dtr["Seri"] = String.Format("{0}/{1}", detail.Order, Global.Session.Current.Month);
                        dtr["Date"] = Global.Session.Current;
                        dtr["Number"] = detail.Tra_Vehicle.Code;
                        dtr["Transport"] = detail.Tra_Vehicle.Transport.Text;

                        dtr["Cost"] = detail.Cost;
                        dtr["Rose"] = detail.Rose;

                        var seat = detail.Seats ?? 0;
                        var bed = detail.Beds ?? 0;
                        dtr["CostDescript"] = String.Format("{0:#,#} x {1} + {2:#,#} x {3} = ",
                            detail.Price1, seat, detail.Price2, bed);
                        dtr["RoseDescript"] = String.Format("{0:#,#} x {1} + {2:#,#} x {3} = ",
                            detail.Rose1, (seat < 1 ? 1 : seat - 1), detail.Rose2, bed);

                        dtr["Parked"] = detail.Parked;
                        dtr["Money"] = detail.Money;
                        dtr["ByChar"] = detail.Money.ToVietnamese("đồng");
                        dtr["Creator"] = Global.Session.User.Name;

                        tbl.Rows.Add(dtr);
                        rpt.DataSource = tbl;

                        if (Global.CheckValidPrinting())
                            rpt.Print();
                        else
                            XtraMessageBox.Show("KHÔNG CÓ MÁY IN", Text,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    PerformRefresh();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi tính tiền;" + ex.Message, Text);
            }
        }

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
                frm.lblFullDay.Text = "Giường";
            }
            else
            {
                frm.lblHalfDay.Text = "Nửa ngày:";
                frm.lblFullDay.Text = "Một ngày:";
            }

            frm.ShowDialog();
        }

        private void FrmTra_GateOut_Load(object sender, EventArgs e)
        {
            AllowBar = false;
        }
    }
}