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

            var rpt = new Report.Rpt_Sumary2() { DataSource = _dtb };
            rpt.xrlInfo.Text = String.Format("Từ ngày {0} đến ngày {1}", _fr.ToString("dd/MM/yyyy"), _to.ToString("dd/MM/yyyy"));
            rpt.xrcMoney.Text = Number.ChangeNum2VNStr(_sum, "đồng");

            var d = BasePRE._sss.Current.Value;
            rpt.xrcDate.Text = String.Format("Ngày {0:0#} tháng {1:0#} năm {2}", d.Day, d.Month, d.Year);

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
            _fr = TimeDate.GetStartOfDay(dteFrom.DateTime);
            _to = TimeDate.GetEndOfDay(dteTo.DateTime);
            _dtb = _bll.Tra_Detail.Sumary(out _sum, _fr, _to);

            base.LoadData();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            base.PerformRefresh();
        }
    }
}