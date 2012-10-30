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
            var rpt = new Report.Rpt_Normal();
            decimal sum = 0;

            rpt.DataSource = _bll.Tra_Detail.SumaryNormal(out sum, DAL.Tra_DetailDAL.Group.A);

            if (Shift() == 1)
                rpt.xrcWatch.Text = "07:00 - 16:00";
            else
                rpt.xrcWatch.Text = "16:00 - 07:00";

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
            var rpt = new Report.Rpt_Normal();
            decimal sum = 0;

            rpt.DataSource = _bll.Tra_Detail.SumaryNormal(out sum, DAL.Tra_DetailDAL.Group.B);

            if (Shift() == 1)
                rpt.xrcWatch.Text = "07:00 - 16:00";
            else
                rpt.xrcWatch.Text = "16:00 - 07:00";

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

        private void lkeNumber_EditValueChanged(object sender, EventArgs e)
        {
            Invoice();
        }

        private void lkeNumber_Enter(object sender, EventArgs e)
        {
            PerformRefresh();
        }
        #endregion

        #region Override
        protected override void PerformPrint()
        {
            var rpt = new Report.Rpt_Sumary2();
            decimal _sum = 0;

            rpt.DataSource = _bll.Tra_Detail.SumaryNormal(out _sum);
            rpt.xrcMoney.Text = _sum.ToVietnamese("đồng");

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, _sum) };
            frm.SetReport(rpt);
            frm.Show(MdiParent);

            base.PerformPrint();
        }

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
                lblSum.Text = null;

                lblUserIn.Text = null;
                lblPhone.Text = null;

                lkeNumber.Properties.DataSource = null;
            }

            base.LoadData();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            var a = _bll.Tra_Detail.SumOfFixed();
            var b = _bll.Tra_Detail.SumOfNormal();
            var c = a + b;

            lblSum.Text = "Tổng xe trong bến: " + (c == 0 ? "0" : c.ToString("#,#"));
            lblSum.Text += "\n-Cố định:  " + (a == 0 ? "0" : a.ToString("#,#"));
            lblSum.Text += "\n-Vãng lai: " + (b == 0 ? "0" : b.ToString("#,#"));

            base.PerformRefresh();
        }
        #endregion

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

                if (detail.Tra_Vehicle.Fixed)
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

                lblMoney.Text = detail.Money.ToString("LỆ PHÍ #,#đ");

                var d = detail.DateOut.Value - detail.DateIn;
                lblDeposit.Text = String.Format("Lưu đậu tại bến: {0}ngày {1}giờ {2}phút", d.Days, d.Hours, d.Minutes);

                lblUserIn.Text = "Cho vào: " + detail.Pol_UserIn.Name;
                lblPhone.Text = "Số ĐT: " + detail.Pol_UserIn.Phone;

                if (isOut) PerformRefresh();
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

            frm.ShowDialog();
        }

        private int Shift()
        {
            var cur = Global.Session.Current;
            var log = Global.Session.Login.Value;

            var t = cur - log;
            var tick = t.Ticks / 2;
            var shift = cur.Subtract(new TimeSpan(tick));

            var start = cur.Date.AddHours(7); // start of shift 1
            var end = cur.Date.AddHours(16); // end of shift 1            

            if (shift >= start && shift <= end)
                return 1;
            else
                return 2;
        }
    }
}