using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Báo cáo doanh thu xe vãng lai
    /// </summary>
    public partial class Rpt_ReportNormal1 : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_ReportNormal1()
        {
            InitializeComponent();
        }

        int _noB = 0;
        private void xrc_NoB_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrc_NoB.Text = "" + ++_noB;
        }
    }
}