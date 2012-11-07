using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.DXF.Station.Sumary
{
    using SKG.Extend;
    using SKG.Plugin;

    public partial class FrmTra_SalesFixed : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz { Code = typeof(FrmTra_SalesFixed).FullName,
                Parent = typeof(Level2).FullName,
                Text = "Doanh thu xe cố định",
                Level = 3,
                Order = 28,
                Picture = @"Icons\Sales.png" };
                return menu;
            }
        }
        #endregion

        public FrmTra_SalesFixed()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            AllowAdd = false;
            AllowEdit = false;
            AllowDelete = false;
            AllowSave = false;
            AllowCancel = false;
            AllowFind = false;
            AllowPrint = true;

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;

            var d = Global.Session.Current;
            cbeMonth.SelectedIndex = (int)d.ToMonth() - 1;

            dteFrom.DateTime = d.ToStartOfDay();
            dteTo.DateTime = d.ToEndOfDay();
        }

        #region Events
        private void cbeQuater_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = cbeQuater.SelectedIndex + 1;
            var b = Global.Session.Current.Year;

            dteFrom.DateTime = b.ToStartOfQuarter(a);
            dteTo.DateTime = b.ToEndOfQuarter(a);
        }

        private void cbeMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = cbeMonth.SelectedIndex + 1;
            var b = Global.Session.Current.Year;
            var c = b.ToStartOfMonth(a);

            cbeQuater.SelectedIndex = (int)c.ToQuarter() - 1;
            dteFrom.DateTime = c;
            dteTo.DateTime = b.ToEndOfMonth(a);
        }
        #endregion

        #region Override
        protected override void PerformPrint()
        {
            var rpt = new Report.Rpt_Fixed
            {
                Name = Global.Session.User.Acc +
                    Global.Session.Current.ToString("_dd.MM.yyyy_HH.mm.ss") + "_cd"
            };
            decimal sum = 0;

            // Ca làm việc
            DateTime shift;
            int i = Global.Session.Shift(out shift);

            var end = dteTo.DateTime.ToEndOfDay();
            var start = dteFrom.DateTime.ToStartOfDay();

            rpt.xrlTitle.Text = "BẢNG KÊ DOANH THU XE KHÁCH BẾN XE NGÃ TƯ GA";
            rpt.xrlDuration.Text += "Từ ngày " + start.ToString("dd/MM/yyyy");
            rpt.xrlDuration.Text += " đến ngày " + end.ToString("dd/MM/yyyy");

            var tmp = shift.Date.ToString("A dd B MM C yyyy");
            tmp = tmp.Replace("A", "Ngày");
            tmp = tmp.Replace("B", "tháng");
            tmp = tmp.Replace("C", "nămy");
            rpt.xrcDate.Text = tmp;
            rpt.xrlCashier.Text = Global.Session.User.Name;

            rpt.DataSource = _bll.Tra_Detail.SumaryFixed(out sum, start, end);
            rpt.xrcMoney.Text = sum.ToVietnamese("đồng");

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
        }

        decimal _sum = 0;
        protected override void LoadData()
        {
            _dtb = _bll.Tra_Detail.SumaryFixed(out _sum, dteFrom.DateTime, dteTo.DateTime);

            grcMain.DataSource = _dtb;
            gridColumn2.BestFit(); // fit column STT
            gridColumn3.BestFit(); // fit column BSX
            gridColumn13.BestFit(); // fit column Kind

            base.LoadData();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            base.PerformRefresh();
        }
        #endregion

        private void FrmTra_Sales_Activated(object sender, EventArgs e)
        {
            PerformRefresh();
        }
    }
}