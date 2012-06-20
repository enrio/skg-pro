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
    using Main;
    using SKG.UTL;

    public partial class FrmSales : PRE.Catalog.FrmBase
    {
        public FrmSales()
        {
            InitializeComponent();

            SetDockPanel(dockPanel1, "Nhập liệu");
            SetDockPanel(dockPanel2, "Danh sách");

            AllowAdd = false;
            AllowEdit = false;
            AllowDelete = false;
            AllowSave = false;
            AllowCancel = false;
            AllowFind = false;
            AllowPrint = true;

            var d = BasePRE._sss.Current.Value;
            dteFrom.DateTime = d;
            dteTo.DateTime = d;

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;
        }

        private void cbeQuater_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = cbeQuater.SelectedIndex + 1;
            var b = BasePRE._sss.Current.Value.Year;

            dteFrom.DateTime = b.ToStartOfQuarter(a);
            dteTo.DateTime = b.ToEndOfQuarter(a);

            LoadData();
        }

        private void cbeMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = cbeMonth.SelectedIndex + 1;
            var b = BasePRE._sss.Current.Value.Year;
            var c = b.ToStartOfMonth(a);

            cbeQuater.SelectedIndex = (int)c.ToQuarter() - 1;
            dteFrom.DateTime = c;
            dteTo.DateTime = b.ToEndOfMonth(a);

            LoadData();
        }

        /// <summary>
        /// Perform when click print button
        /// </summary>
        protected override void PerformPrint()
        {
            var rpt = new Report.Rpt_Sumary2() { DataSource = _dtb };
            rpt.xrlInfo.Text = String.Format("Từ ngày {0} đến ngày {1}",
                dteFrom.DateTime.ToString("dd/MM/yyyy"), dteTo.DateTime.ToString("dd/MM/yyyy"));
            rpt.xrcMoney.Text = _sum.ToVietnamese("đồng");

            var d = BasePRE._sss.Current.Value;
            rpt.xrcDate.Text = String.Format("Ngày {0:0#} tháng {1:0#} năm {2}", d.Day, d.Month, d.Year);
            rpt.xrcAccount.Text = BasePRE._sss.User.Name;

            var frm = new FrmPrint();
            frm.Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, _sum);
            frm.SetReport(rpt);

            frm.MdiParent = MdiParent;
            frm.Show();

            base.PerformPrint();
        }

        decimal _sum;
        protected override void LoadData()
        {
            _dtb = _bll.Tra_Detail.Sumary(out _sum, dteFrom.DateTime, dteTo.DateTime);

            grcMain.DataSource = _dtb;
            gridColumn2.BestFit(); // fit column STT
            gridColumn3.BestFit(); // fit column BSX

            base.LoadData();
        }

        protected override void PerformRefresh()
        {
            var d = BasePRE._sss.Current.Value;
            dteFrom.DateTime = d.ToStartOfDay();
            dteTo.DateTime = d.ToEndOfDay();
            cbeMonth.SelectedIndex = (int)d.ToMonth() - 1;

            LoadData();

            base.PerformRefresh();
        }
    }
}