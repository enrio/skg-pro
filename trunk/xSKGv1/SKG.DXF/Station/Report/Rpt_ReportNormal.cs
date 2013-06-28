using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Báo cáo doanh thu xe vãng lai
    /// </summary>
    public partial class Rpt_ReportNormal : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_ReportNormal()
        {
            InitializeComponent();
        }

        int _noA = 0;
        private void xrc_NoA_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrc_NoA.Text = "" + ++_noA;
        }
    }
}