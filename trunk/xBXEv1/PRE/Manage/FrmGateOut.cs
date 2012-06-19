using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRE.Manage
{
    using UTL;
    using DAL.Entities;
    using Main;
    using DevExpress.XtraReports.Parameters;

    /// <summary>
    /// Cổng ra
    /// </summary>
    public partial class FrmGateOut : PRE.Catalog.FrmBase
    {
        public FrmGateOut()
        {
            InitializeComponent();

            tmrMain.Enabled = true; // bật đồng hồ đếm giờ
            //lblUserIn.Text = BasePRE._sss.User.Name.ToUpper();

            SetDockPanel(dockPanel1, "Nhập liệu");
            SetDockPanel(dockPanel2, "Danh sách");

            //AllowBar = false;
            AllowAdd = false;
            AllowEdit = false;
            AllowDelete = false;
            AllowSave = false;
            AllowCancel = false;
            AllowFind = false;
            AllowPrint = true;

            //grvMain.OptionsView.ShowAutoFilterRow = true;
            //grvMain.OptionsBehavior.Editable = false;
        }

        /// <summary>
        /// Perform when click print button
        /// </summary>
        protected override void PerformPrint()
        {
            var frm = new FrmPrint();
            frm.Text = "In: " + Text;

            var rpt = new Report.Rpt_Sumary1();
            var d = BasePRE._sss.Current.Value;
            var fr = TimeDate.GetStartOfDay(d);
            var to = TimeDate.GetEndOfDay(d);
            decimal _sum;

            rpt.DataSource = _bll.Tra_Detail.Sumary(out _sum, fr, to, DAL.Tra_DetailDAL.Group.A, BasePRE._sss.User.Id);
            rpt.xrcWatch.Text = TimeDate.GetWatch2(d) + "";
            rpt.xrcMoney.Text = Number.ChangeNum2VNStr(_sum, "đồng");

            frm.SetReport(rpt);

            frm.MdiParent = MdiParent;
            frm.Show();
            frm.Activate();

            base.PerformPrint();
        }

        private void FrmGateOut_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        protected override void LoadData()
        {
            decimal sum;
            _dtb = _bll.Tra_Detail.GetInDepot(out sum);
            cbbNumber.DataSource = _dtb;
            cbbNumber.ValueMember = "Id";
            cbbNumber.DisplayMember = "Number";

            base.LoadData();
        }

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
                    int chair = tb.Rows[0]["Chair"] + "" != "" ? Convert.ToInt32(tb.Rows[0]["Chair"]) : 0;
                    //decimal weight = tb.Rows[0]["Weight"] + "" != "" ? Convert.ToDecimal(tb.Rows[0]["Weight"]) : 0;

                    lblDateIn.Text = timeIn.ToString("dd/MM/yyyy HH:mm:ss");
                    lblDateOut.Text = timeOut.ToString("dd/MM/yyyy HH:mm:ss");

                    lblNumber.Text = (tb.Rows[0]["Number"] + "").ToUpper();
                    lblGroup.Text = tb.Rows[0]["GroupName"].ToString();
                    lblKind.Text = tb.Rows[0]["Name"].ToString();
                    lblAccIn.Text = tb.Rows[0]["UserInName"].ToString().ToUpper();
                    lblAccIn.Text += " - SĐT: " + tb.Rows[0]["UserInPhone"];

                    //lblWeight.Text = weight.ToString();
                    lblChair.Text = chair.ToString();

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
            //lblInf.Text = "ĐANG TÍNH TIỀN";
        }

        private void cmdOut_Click(object sender, EventArgs e)
        {
            Invoice(true);
            cmdOut.Enabled = false;
            //lblInf.Text = "ĐÃ TÍNH TIỀN XONG - CHO XE RA";
        }

        private void cbbNumber_Enter(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}