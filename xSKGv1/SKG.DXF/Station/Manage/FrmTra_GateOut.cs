using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Station.Manage
{
    using Sumary;
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

        private void cmdInList_Click(object sender, EventArgs e)
        {
            Extend.ShowRight<FrmTra_InDepotFixed>(Global.Parent);
        }

        private void cmdSumary1_Click(object sender, EventArgs e)
        {
            var rpt = new Report.Rpt_Sumary1();
            var d = Global.Session.Current;
            var fr = d.ToStartOfDay();
            var to = d.ToEndOfDay();
            decimal _sum = 0;

            rpt.DataSource = _bll.Tra_Detail.SumaryNormal(DAL.Tra_DetailDAL.Group.A);
            rpt.xrcWatch.Text = d.ToWatch2() + "";
            rpt.xrcMoney.Text = _sum.ToVietnamese("đồng");
            rpt.xrLabel1.Text = "BẢNG KÊ THU PHÍ LƯU ĐẬU XE TẢI";

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, _sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        private void cmdSumary2_Click(object sender, EventArgs e)
        {
            var rpt = new Report.Rpt_Sumary1();
            var d = Global.Session.Current;
            var fr = d.ToStartOfDay();
            var to = d.ToEndOfDay();
            decimal _sum = 0;

            rpt.DataSource = _bll.Tra_Detail.SumaryNormal(DAL.Tra_DetailDAL.Group.B);
            rpt.xrcWatch.Text = d.ToWatch2() + "";
            rpt.xrcMoney.Text = _sum.ToVietnamese("đồng");
            rpt.xrLabel1.Text = "BẢNG KÊ THU PHÍ DỊCH VỤ XE SANG HÀNG";

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, _sum) };
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
            var d = Global.Session.Current;
            var fr = d.ToStartOfDay();
            var to = d.ToEndOfDay();
            decimal _sum;

            rpt.DataSource = _bll.Tra_Detail.Sumary(out _sum, fr, to, DAL.Tra_DetailDAL.Group.Z, Global.Session.User.Id);
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

                lblMoney.Text = detail.Money.ToString("#,#đ");

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
    }
}