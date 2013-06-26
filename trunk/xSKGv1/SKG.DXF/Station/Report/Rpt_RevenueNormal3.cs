using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Báo cáo doanh thu xe vãng lai
    /// </summary>
    public partial class Rpt_RevenueNormal3 : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_RevenueNormal3()
        {
            InitializeComponent();
        }

        int _noA = 0;
        private void xrc_NoA_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrc_NoA.Text = "" + ++_noA;
        }

        int _noB = 0;
        private void xrc_NoB_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrc_NoB.Text = "" + ++_noB;
        }

        int _noC = 0;
        private void xrc_NoC_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrc_NoC.Text = "" + ++_noC;
        }
    }
}