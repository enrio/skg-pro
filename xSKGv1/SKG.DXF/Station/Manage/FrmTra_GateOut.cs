using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Station.Manage
{
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;
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
            cmdRedo.Enabled = cmdInvoice.Enabled;

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
            if (cbbNumber.Text == "") return;

            try
            {
                var v = (Tra_Vehicle)_bll.Tra_Vehicle.Select(cbbNumber.Text);
                if (v == null) return;
                var o = new Tra_Detail() { Pol_UserOutId = Global.Session.User.Id, Tra_VehicleId = v.Id, DateOut = Global.Session.Current };

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
                    int seats = (tb.Rows[0]["Seats"] + "").ToInt32();
                    int beds = (tb.Rows[0]["Seats"] + "").ToInt32();

                    lblDateIn.Text = timeIn.ToStringVN();
                    lblDateOut.Text = timeOut.ToStringVN();

                    lblNumber.Text = (tb.Rows[0]["Code"] + "").ToUpper();
                    lblGroup.Text = tb.Rows[0]["GroupName"] + "";
                    lblKind.Text = tb.Rows[0]["Name"].ToString();
                    lblAccIn.Text = (tb.Rows[0]["UserInName"] + "").ToUpper();
                    lblAccIn.Text += " - SĐT: " + tb.Rows[0]["UserInPhone"];

                    lblChair.Text = seats + "";

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
            catch (Exception ex) { XtraMessageBox.Show("Lỗi tính tiền;" + ex.Message, Text); }
        }

        private void FrmGateOut_Load(object sender, EventArgs e)
        {
            lblAccOut.Text = Global.Session.User.Name.ToUpper();
        }

        private void cmdRedo_Click(object sender, EventArgs e)
        {
            //using (var x = new FrmTra_GateIn { EditNumber = cbbNumber.Text, EditMode = false, StartPosition = FormStartPosition.CenterScreen })
            //{
            //    x.ShowDialog();
            //    x.EditNumber = null;
            //    x.EditMode = true;
            //    LoadData();
            //}

            if (cbbNumber.Text == "") return;
            cmdOut.Enabled = false;

            var x = new Station.Discrete.FrmTra_Vehicle
            {
                num = cbbNumber.Text,
                AllowAdd = false,
                AllowDelete = false,
                WindowState = FormWindowState.Maximized
            };
            x.AllowCancel = false;
            x.ShowDialog();
            LoadData();
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