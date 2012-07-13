using System;
using System.Collections.Generic;

namespace BXE.PRE.Manage
{
    using SKG;
    using BLL;
    using SKG.DXF;
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;
    using SKG.DXF.Sytem;
    using DevExpress.XtraEditors;

    public partial class FrmSales : SKG.DXF.FrmInRight
    {
        public FrmSales()
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
            var a = new Report.Rpt_Sumary2() { DataSource = _dtb };
            a.xrlInfo.Text = String.Format("Từ ngày {0} đến ngày {1}",
                dteFrom.DateTime.ToString("dd/MM/yyyy"), dteTo.DateTime.ToString("dd/MM/yyyy"));
            a.xrcMoney.Text = _sum.ToVietnamese("đồng");

            var d = Global.Session.Current;
            a.xrcDate.Text = String.Format("Ngày {0:0#} tháng {1:0#} năm {2}", d.Day, d.Month, d.Year);
            a.xrcAccount.Text = Global.Session.User.Name;

            var frm = new FrmShowPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, _sum) };
            frm.SetReport(a);
            frm.ShowRight(MdiParent);

            base.PerformPrint();
        }

        decimal _sum;
        protected override void LoadData()
        {
            _dtb =Sample. _bll.Tra_Detail.Sumary(out _sum, dteFrom.DateTime, dteTo.DateTime);

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
    }
}