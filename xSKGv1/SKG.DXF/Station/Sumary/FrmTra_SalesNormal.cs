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
using System.Linq;
using System.Windows.Forms;

namespace SKG.DXF.Station.Sumary
{
    using SKG.Extend;
    using SKG.Plugin;

    public partial class FrmTra_SalesNormal : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(FrmTra_SalesFixed).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "Doanh thu xe vãng lai",
                    Level = 3,
                    Order = 28,
                    Picture = @"Icons\Sales.png"
                };
                return menu;
            }
        }
        #endregion

        public FrmTra_SalesNormal()
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
            var a = new Report.Rpt_Normal() { DataSource = _dtb };
            a.Name = Global.Session.User.Acc
                + Global.Session.Current.ToString("_dd.MM.yyyy_HH.mm.ss");

            /*a.xrlInfo.Text = String.Format("Từ ngày {0} đến ngày {1}",
                dteFrom.DateTime.ToString("dd/MM/yyyy"), dteTo.DateTime.ToString("dd/MM/yyyy"));
            a.xrcMoney.Text = _sum.ToVietnamese("đồng");

            var d = Global.Session.Current;
            a.xrcDate.Text = String.Format("Ngày {0:0#} tháng {1:0#} năm {2}", d.Day, d.Month, d.Year);
            a.xrcAccount.Text = Global.Session.User.Name;*/

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, _sum) };
            frm.SetReport(a);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
        }

        decimal _sum = 0;
        protected override void LoadData()
        {
            _dtb = _bll.Tra_Detail.SumaryNormal(out _sum);

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