using System;
using System.Data;
using System.Windows.Forms;
using BXE.PRE.YhwCcn;

namespace BXE.PRE.VbqGaa
{
    public partial class FrmAfcGaa : Form, UTL.PLG.ItfPlg
    {
        public UTL.BLL.UecLajVei _sss = new UTL.BLL.UecLajVei();
        const string STR_MENU = "Cổng &ra";

        DataSet _dts = new DataSet();
        readonly DAL.DetailDAL _dal = new DAL.DetailDAL();
        private decimal _sum;

        public FrmAfcGaa()
        {
            InitializeComponent();

            lblGroup.Dock = DockStyle.Fill;
            lblKind.Dock = DockStyle.Fill;
            lblDateIn.Dock = DockStyle.Fill;
            lblDateOut.Dock = DockStyle.Fill;
            lblDuration.Dock = DockStyle.Fill;
            lblPrice.Dock = DockStyle.Fill;
            lblMoney.Dock = DockStyle.Fill;
            lblAccIn.Dock = DockStyle.Fill;
            lblAccOut.Dock = DockStyle.Fill;
        }

        #region Implement plugin
        string UTL.PLG.ItfPlg.Name { get { return STR_MENU; } }
        string UTL.PLG.ItfPlg.Description { get { return "Out gate form"; } }
        string UTL.PLG.ItfPlg.Author { get { return "Zng Tfy"; } }
        string UTL.PLG.ItfPlg.Version { get { return "1.0"; } }

        UserControl UTL.PLG.ItfPlg.Usrcontrol { get { return null; } }
        Form UTL.PLG.ItfPlg.Frmcontrol { get { return this; } }
        UTL.PLG.ItfHst UTL.PLG.ItfPlg.Host { get; set; }

        public UTL.BLL.UecLajVei Sss { get { return _sss; } set { _sss = value; } }
        public UTL.CsoInf Inf { get; set; }

        void UTL.PLG.ItfPlg.Initialize() { }
        void UTL.PLG.ItfPlg.Dispose() { }
        #endregion

        private void FrmAfcGaa_Load(object sender, EventArgs e)
        {
            lblAccOut.Text = Sss.Name.ToUpper();
            _sss.Current = _dal.CurrentTime();
            Reset();
        }

        private void Reset()
        {
            ClearText();
            tmrDongHo_Tick(null, null);
            tmrDongHo.Enabled = true;
            LoadData();
        }

        private void cmdClose_Click(object sender, EventArgs e) { Close(); }

        private void tmrDongHo_Tick(object sender, EventArgs e)
        {
            lblDateOut.Text = _sss.Current.Value.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void cmdInvoice_Click(object sender, EventArgs e)
        {
            Invoice();
            cmdOut.Enabled = true;
            lblInf.Text = "ĐANG TÍNH TIỀN";
        }

        private void Invoice(bool isOut = false)
        {
            if (cbbNumber.Text == "") return;

            try
            {
                var o = new DAL.Detail() { AccOut = _sss.Id, Number = cbbNumber.Text, DateOut = _sss.Current };

                decimal money = 0, price1 = 0, price2 = 0;
                int day = 0, hour = 0;

                var dal = new DAL.DetailDAL();
                var tb = dal.InvoiceOut(o, ref  day, ref  hour, ref  money, ref  price1, ref  price2, isOut);

                if (tb == null) return;

                if (tb.Rows.Count > 0)
                {
                    DateTime timeIn = Convert.ToDateTime(tb.Rows[0]["DateIn"]);
                    DateTime timeOut = isOut ? Convert.ToDateTime(tb.Rows[0]["DateOut"]) : o.DateOut.Value;

                    int group = tb.Rows[0]["GroupId"] + "" != "" ? Convert.ToInt32(tb.Rows[0]["GroupId"]) : 0;
                    int chair = tb.Rows[0]["Chair"] + "" != "" ? Convert.ToInt32(tb.Rows[0]["Chair"]) : 0;
                    decimal weight = tb.Rows[0]["Weight"] + "" != "" ? Convert.ToDecimal(tb.Rows[0]["Weight"]) : 0;

                    lblDateIn.Text = timeIn.ToString("dd/MM/yyyy HH:mm:ss");
                    lblDateOut.Text = timeOut.ToString("dd/MM/yyyy HH:mm:ss");

                    lblNumber.Text = tb.Rows[0]["Number"].ToString();
                    lblGroup.Text = tb.Rows[0]["GroupName"].ToString();
                    lblKind.Text = tb.Rows[0]["Name"].ToString();
                    lblAccIn.Text = tb.Rows[0]["AccIn"].ToString().ToUpper();
                    lblAccIn.Text += " - SĐT: " + tb.Rows[0]["Phone"];

                    lblWeight.Text = weight.ToString();
                    lblChair.Text = chair.ToString();

                    string dayL = (hour > 0 && hour < 12) ? ".5" : "";
                    int dayF = (hour >= 12) ? day + 1 : day;

                    if (day == 0)
                    {
                        if (group == 1) dayL = ".5";
                        if (group == 2) dayF = 1;
                    }

                    lblDuration.Text = string.Format("{0}ngày {1}giờ => {2}{3}ngày", day, hour, dayF, dayL);

                    if (price1 == 0) lblPrice.Text = String.Format("{0:0,0}VNĐ (một lần)", price2);
                    else lblPrice.Text = String.Format("{0:0,0}VNĐ (một ngày); {1:0,0}VNĐ (nửa ngày)", price2, price1);

                    lblMoney.Text = String.Format("{0:0,0}VNĐ", money);

                    if (isOut)
                    {
                        LoadData();
                        tmrDongHo.Enabled = false;
                    }
                }
            }
            catch (Exception ex) { UTL.CsoUTL.Show("Lỗi tính tiền;" + ex.Message); }
        }

        private void LoadData()
        {
            decimal sum;
            var tb = _dal.GetListIn(out sum);
            cbbNumber.DataSource = tb;
            cbbNumber.ValueMember = "Id";
            cbbNumber.DisplayMember = "Number";

            if (tb.Rows.Count > 0) ShowButton();
            else ShowButton(false);
        }

        private void cmdOut_Click(object sender, EventArgs e)
        {
            Invoice(true);
            cmdOut.Enabled = false;
            lblInf.Text = "ĐÃ TÍNH TIỀN XONG - CHO XE RA";
        }

        private void ShowButton(bool isShow = true)
        {
            cbbNumber.Enabled = isShow;
            cmdInvoice.Enabled = isShow;
            cmdRedo.Enabled = isShow;
        }

        private void cmdRedo_Click(object sender, EventArgs e)
        {
            /*cmdOut.Enabled = false;
            ClearText();*/

            using (var x = new FrmAfcVbq())
            {
                x.EditNumber = cbbNumber.Text;
                x.EditMode = false;
                x.ShowDialog();
                x.EditNumber = null;
                x.EditMode = true;
                LoadData();
            }
        }

        private void ClearText()
        {
            lblGroup.Text = null;
            lblKind.Text = null;
            lblDateIn.Text = null;
            lblDateOut.Text = null;
            lblDuration.Text = null;
            lblPrice.Text = null;
            lblMoney.Text = null;
            lblAccIn.Text = null;
            lblNumber.Text = null;
            lblChair.Text = null;
            lblWeight.Text = null;
            lblInf.Text = null;
        }

        private void cmdInList_Click(object sender, EventArgs e)
        {
            using (var x = new YhwCcn.FrmAhvBdd()) { x.ShowDialog(); }
        }

        private void cbbNumber_SelectedIndexChanged(object sender, EventArgs e) { cmdOut.Enabled = false; Invoice(); }

        private void cbbNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { Invoice(); }
        }

        private void cmdSumary1_Click(object sender, EventArgs e)
        {
            using (var x = new FrmRepOrt() { WindowState = FormWindowState.Maximized })
            {
                x.rptAep.LocalReport.ReportPath = Application.StartupPath + @"\PLG\PRE\YhwCcn\Banke1.rdlc";
                DateTime fr, to;
                x.Current = _dal.CurrentTime();
                fr = UTL.ICA.CsoICA.GetStartOfDay(x.Current.Value);
                to = UTL.ICA.CsoICA.GetEndOfDay(x.Current.Value);

                x.SumaryData = _dal.SumaryDateOutByUser_1(out _sum, fr, to, _sss.Id);
                x.SumaryMoney = _sum;

                x.ShowDialog();
            }
        }

        private void cmdSumary2_Click(object sender, EventArgs e)
        {
            using (var x = new FrmRepOrt() { WindowState = FormWindowState.Maximized })
            {
                x.rptAep.LocalReport.ReportPath = Application.StartupPath + @"\PLG\PRE\YhwCcn\Banke1.rdlc";
                DateTime fr, to;
                x.Current = _dal.CurrentTime();
                fr = UTL.ICA.CsoICA.GetStartOfDay(x.Current.Value);
                to = UTL.ICA.CsoICA.GetEndOfDay(x.Current.Value);

                x.SumaryData = _dal.SumaryDateOutByUser_1(out _sum, fr, to, _sss.Id);
                x.SumaryMoney = _sum;

                x.ShowDialog();
            }
        }
    }
}