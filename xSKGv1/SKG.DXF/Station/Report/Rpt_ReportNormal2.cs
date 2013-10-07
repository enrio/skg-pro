using System;
using DevExpress.XtraPrinting;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Báo cáo doanh thu xe vãng lai
    /// </summary>
    public partial class Rpt_ReportNormal2 : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_ReportNormal2()
        {
            InitializeComponent();
        }

        int _noC = 0;
        private void xrc_NoC_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrc_NoC.Text = "" + ++_noC;
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrc_NoC.Text == "1")
            {
                var bd = BorderSide.Bottom;
                xrTableCell55.Borders = bd;
                xrTableCell87.Borders = bd;
                xrTableCell88.Borders = bd;
                xrTableCell89.Borders = bd | BorderSide.Right;

                xrTableCell87.Text = null;
                xrTableCell88.Text = null;
                xrTableCell89.Text = null;

                xrTableCell87.DataBindings.Clear();
                xrTableCell88.DataBindings.Clear();
                xrTableCell89.DataBindings.Clear();
            }
        }
    }
}