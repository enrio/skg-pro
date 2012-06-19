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
            //grvMain.OptionsBehavior.Editable = false;
        }

        private void cbeQuater_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp = cbeQuater.Text.Trim();
            cbeMonth.Text = "";

            if (tmp != "")
            {
                int y = BasePRE._sss.Current.Value.Year;
                int m = Convert.ToInt32(tmp);

                var fr = TimeDate.GetStartOfQuarter(y, (TimeDate.Quarter)m);
                var to = TimeDate.GetEndOfQuarter(y, (TimeDate.Quarter)m);

                dteFrom.EditValue = fr;
                dteTo.EditValue = to;
            }
        }

        private void cbeMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp = cbeMonth.Text.Trim();
            cbeQuater.Text = "";

            if (tmp != "")
            {
                int y = BasePRE._sss.Current.Value.Year;
                int m = Convert.ToInt32(tmp);

                var fr = new DateTime(y, m, 1);
                var to = new DateTime(y, m, DateTime.DaysInMonth(y, m), 23, 59, 59, 999);

                dteFrom.EditValue = fr;
                dteTo.EditValue = to;
            }
        }

        /// <summary>
        /// Perform when click print button
        /// </summary>
        protected override void PerformPrint()
        {
            LoadData();

            var frm = new FrmPrint();
            frm.Text = "In: " + Text;

            var rpt = new Report.Rpt_Sumary1() { DataSource = _dtb };

            frm.SetReport(rpt);

            frm.MdiParent = MdiParent;
            frm.Show();
            frm.Activate();

            base.PerformPrint();
        }

        protected override void LoadData()
        {
            decimal sum;
            DateTime fr, to;
            fr = TimeDate.GetStartOfDay(dteFrom.DateTime);
            to = TimeDate.GetEndOfDay(dteTo.DateTime);
            _dtb = _bll.Tra_Detail.SumaryDateOut(out sum, fr, to);

            base.LoadData();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            base.PerformRefresh();
        }
    }
}