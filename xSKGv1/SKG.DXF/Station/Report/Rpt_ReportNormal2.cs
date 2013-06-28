using System;

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
    }
}