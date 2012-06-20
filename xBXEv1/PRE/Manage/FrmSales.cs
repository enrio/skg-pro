﻿using System;
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
            var tmp = cbeQuater.Text.Trim();

            if (tmp != "")
            {
                var y = BasePRE._sss.Current.Value.Year;
                var m = tmp.ToInt32();

                dteFrom.DateTime = y.ToStartOfQuarter(m);
                dteTo.DateTime = y.ToEndOfQuarter(m);
            }
        }

        private void cbeMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tmp = cbeMonth.Text.Trim();

            if (tmp != "")
            {
                var y = BasePRE._sss.Current.Value.Year;
                var m = tmp.ToInt32();
                var a = y.ToStartOfMonth(m);

                cbeQuater.SelectedIndex = (int)a.ToQuarter() - 1;
                dteFrom.DateTime = a;
                dteTo.DateTime = y.ToEndOfMonth(m);
            }
        }

        /// <summary>
        /// Perform when click print button
        /// </summary>
        protected override void PerformPrint()
        {
            LoadData();

            var rpt = new Report.Rpt_Sumary2() { DataSource = _dtb };
            rpt.xrlInfo.Text = String.Format("Từ ngày {0} đến ngày {1}", _fr.ToString("dd/MM/yyyy"), _to.ToString("dd/MM/yyyy"));
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
        DateTime _fr, _to;
        protected override void LoadData()
        {
            _fr = dteFrom.DateTime.ToStartOfDay();
            _to = dteTo.DateTime.ToEndOfDay();
            _dtb = _bll.Tra_Detail.Sumary(out _sum, _fr, _to);

            grcMain.DataSource = _dtb;
            gridColumn2.BestFit(); // fit column STT
            gridColumn3.BestFit(); // fit column BSX

            base.LoadData();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            base.PerformRefresh();
        }
    }
}