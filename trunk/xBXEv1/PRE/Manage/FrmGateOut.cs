using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PRE.Manage
{
    using DAL.Entities;
    using Main;
    using SKG.UTL;

    /// <summary>
    /// Cổng ra
    /// </summary>
    public partial class FrmGateOut : PRE.Catalog.FrmBase
    {
        public FrmGateOut()
        {
            InitializeComponent();

            tmrMain.Enabled = true; // bật đồng hồ đếm giờ
            lblAccOut.Text = BasePRE._sss.User.Name.ToUpper();

            SetDockPanel(dockPanel1, "Nhập liệu");
            SetDockPanel(dockPanel2, "Danh sách");

            AllowAdd = false;
            AllowEdit = false;
            AllowDelete = false;
            AllowSave = false;
            AllowCancel = false;
            AllowFind = false;
            AllowPrint = true;
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
            lblInfo.Text = "ĐANG TÍNH TIỀN";
        }

        private void cmdOut_Click(object sender, EventArgs e)
        {
            Invoice(true);
            cmdOut.Enabled = false;
            lblInfo.Text = "ĐÃ TÍNH TIỀN XONG - CHO XE RA";
        }

        private void cbbNumber_Enter(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region Override
        protected override void PerformPrint()
        {
            var rpt = new Report.Rpt_Sumary1();
            var d = BasePRE._sss.Current.Value;
            var fr = d.ToStartOfDay();
            var to = d.ToEndOfDay();
            decimal _sum;

            rpt.DataSource = _bll.Tra_Detail.Sumary(out _sum, fr, to, DAL.Tra_DetailDAL.Group.A, BasePRE._sss.User.Id);
            rpt.xrcWatch.Text = d.ToWatch2() + "";
            rpt.xrcMoney.Text = _sum.ToVietnamese("đồng");

            var frm = new FrmShowPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, _sum) };
            frm.SetReport(rpt);
            frm.ShowRight(MdiParent);

            base.PerformPrint();
        }

        protected override void LoadData()
        {
            int sum;
            _dtb = _bll.Tra_Detail.GetInDepot(out sum);
            cmdInvoice.Enabled = sum > 0 ? true : false;

            cbbNumber.DataSource = _dtb;
            cbbNumber.ValueMember = "Id";
            cbbNumber.DisplayMember = "Number";

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
            if (cbbNumber.Text == "") return;

            try
            {
                var v = (Tra_Vehicle)_bll.Tra_Vehicle.Select(cbbNumber.Text);
                var o = new Tra_Detail() { Pol_UserOutId = BasePRE._sss.User.Id, Tra_VehicleId = v.Id, DateOut = BasePRE._sss.Current };

                decimal money = 0;
                int price1 = 0, price2 = 0;
                int day = 0, hour = 0;

                var tb = _bll.Tra_Detail.InvoiceOut(o, ref  day, ref  hour, ref  money, ref  price1, ref  price2, isOut);

                if (tb == null) return;

                if (tb.Rows.Count > 0)
                {
                    DateTime timeIn = Convert.ToDateTime(tb.Rows[0]["DateIn"]);
                    DateTime timeOut = isOut ? Convert.ToDateTime(tb.Rows[0]["DateOut"]) : o.DateOut.Value;

                    string code = tb.Rows[0]["GroupCode"] + "" != "" ? tb.Rows[0]["GroupCode"] + "" : "";
                    int chair = (tb.Rows[0]["Chair"] + "").ToInt32();

                    lblDateIn.Text = timeIn.ToString("dd/MM/yyyy HH:mm:ss");
                    lblDateOut.Text = timeOut.ToString("dd/MM/yyyy HH:mm:ss");

                    lblNumber.Text = (tb.Rows[0]["Number"] + "").ToUpper();
                    lblGroup.Text = tb.Rows[0]["GroupName"] + "";
                    lblKind.Text = tb.Rows[0]["Name"].ToString();
                    lblAccIn.Text = (tb.Rows[0]["UserInName"] + "").ToUpper();
                    lblAccIn.Text += " - SĐT: " + tb.Rows[0]["UserInPhone"];

                    lblChair.Text = chair + "";

                    string dayL = (hour > 0 && hour < 12) ? ".5" : "";
                    int dayF = (hour >= 12) ? day + 1 : day;

                    if (day == 0)
                    {
                        if (code == "A") dayL = ".5";
                        if (code == "B") dayF = 1;
                    }

                    lblDuration.Text = string.Format("{0}ngày {1}giờ => {2}{3}ngày", day, hour, dayF, dayL);

                    if (price1 == 0) lblPrice.Text = String.Format("{0:0,0}VNĐ (một lần)", price2);
                    else lblPrice.Text = String.Format("{0:0,0}VNĐ (một ngày); {1:0,0}VNĐ (nửa ngày)", price2, price1);

                    lblMoney.Text = String.Format("{0:0,0}VNĐ", money);

                    if (isOut)
                    {
                        LoadData();
                        tmrMain.Enabled = false;
                    }
                }
            }
            catch (Exception ex) { BasePRE.ShowMessage("Lỗi tính tiền;" + ex.Message, Text); }
        }
    }
}