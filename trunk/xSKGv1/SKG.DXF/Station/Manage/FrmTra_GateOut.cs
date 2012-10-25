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
                var menu = new Menuz() { Code = typeof(FrmTra_GateOut).FullName, Parent = typeof(Level2).FullName, Text = "Cổng ra", Level = 3, Order = 28, Picture = @"Icons\GateOut.png" };
                return menu;
            }
        }
        #endregion

        public FrmTra_GateOut()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            tmrMain.Enabled = true; // bật đồng hồ đếm giờ

            AllowAdd = false;
            AllowEdit = false;
            AllowDelete = false;
            AllowSave = false;
            AllowCancel = false;
            AllowFind = false;
            AllowPrint = false;
        }

        #region Events
        private void cbbNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            Invoice();
        }

        private void cbbNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Invoice();
        }

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

        private void cbbNumber_Enter(object sender, EventArgs e)
        {
            LoadData();
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
            //rpt.xrcWatch.Text = d.ToWatch2() + "";
            rpt.xrcMoney.Text = _sum.ToVietnamese("đồng");

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, _sum) };
            frm.SetReport(rpt);
            frm.Show(MdiParent);

            base.PerformPrint();
        }

        protected override void LoadData()
        {
            int sum;
            _dtb = _bll.Tra_Detail.GetInDepot(out sum);
            cmdInvoice.Enabled = sum > 0 ? true : false;
            //cmdRedo.Enabled = cmdInvoice.Enabled;

            cbbNumber.DataSource = _dtb;
            cbbNumber.ValueMember = "Id";
            cbbNumber.DisplayMember = "Code";

            base.LoadData();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            base.PerformRefresh();
        }
        #endregion

        /// <summary>
        /// Tính tiền
        /// </summary>
        /// <param name="isOut">Cho xe ra</param>
        private void Invoice(bool isOut = false)
        {
            try
            {
                if (cbbNumber.Text == "") return;

                var detail = _bll.Tra_Detail.InvoiceOut(cbbNumber.Text, isOut);

                if (detail.Tra_Vehicle.Fixed)
                {
                    lblKind.Text = "Tuyến: " + detail.Tra_Vehicle.Tariff.Text;
                    lblGroup.Text = "ĐVVT: " + detail.Tra_Vehicle.Transport.Text;
                    lblMoney.Text = detail.ChargeForFixed().ToString("#,#");

                    lblHalfDay.Text = "Ghế:";
                    lblFullDay.Text = "Giường:";
                }
                else
                {
                    lblKind.Text = "Loại xe: " + detail.Tra_Vehicle.Tariff.Text;
                    lblGroup.Text = "Nhóm xe: " + detail.Tra_Vehicle.Tariff.Group.Text;
                    lblMoney.Text = detail.ChargeForNormal().ToString("#,#");

                    lblHalfDay.Text = "Nửa ngày:";
                    lblFullDay.Text = "Một ngày:";
                }

                lblNumber.Text = "BS:" + detail.Tra_Vehicle.Code;

                lblDateIn.Text = detail.DateIn.ToString("dd/MM/yy HH:mm:ss");
                lblDateOut.Text = detail.DateOut.Value.ToString("dd/MM/yy HH:mm:ss");

                lblSeats.Text = detail.Seats == null ? null : detail.Seats.Value.ToString("#,#");
                lblBeds.Text = detail.Beds == null ? null : detail.Beds.Value.ToString("#,#");

                lblPrice1.Text = detail.Price1.ToString("#,#");
                lblRose1.Text = detail.Rose1.ToString("#,#");

                lblPrice2.Text = detail.Price2.ToString("#,#");
                lblRose2.Text = detail.Rose2.ToString("#,#");

                var d = detail.DateOut.Value - detail.DateIn;
                lblDeposit.Text = String.Format("Lưu đậu tại bến: {0}ngày {1}giờ {2}phút", d.Days, d.Hours, d.Minutes);

                lblUserIn.Text = "Cho vào: " + detail.Pol_UserIn.Name;
                lblPhone.Text = "Số ĐT: " + detail.Pol_UserIn.Phone;

            }
            catch (Exception ex)
            { XtraMessageBox.Show("Lỗi tính tiền;" + ex.Message, Text); }
        }

        private void cmdInList_Click(object sender, EventArgs e)
        {
            Extend.ShowRight<FrmTra_InDepot>(Global.Parent);
        }

        private void cmdSumary1_Click(object sender, EventArgs e)
        {
            var rpt = new Report.Rpt_Sumary1();
            var d = Global.Session.Current;
            var fr = d.ToStartOfDay();
            var to = d.ToEndOfDay();
            decimal _sum;

            rpt.DataSource = _bll.Tra_Detail.Sumary(out _sum, fr, to, DAL.Tra_DetailDAL.Group.A, Global.Session.User.Id);
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
            decimal _sum;

            rpt.DataSource = _bll.Tra_Detail.Sumary(out _sum, fr, to, DAL.Tra_DetailDAL.Group.B, Global.Session.User.Id);
            rpt.xrcWatch.Text = d.ToWatch2() + "";
            rpt.xrcMoney.Text = _sum.ToVietnamese("đồng");
            rpt.xrLabel1.Text = "BẢNG KÊ THU PHÍ DỊCH VỤ XE SANG HÀNG";

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, _sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }
    }
}