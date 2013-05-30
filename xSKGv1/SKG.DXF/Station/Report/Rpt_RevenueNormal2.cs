using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Báo cáo doanh thu xe vãng lai
    /// </summary>
    public partial class Rpt_RevenueNormal2 : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_RevenueNormal2()
        {
            InitializeComponent();
        }

        int _group = 0;
        private void xrcGroup_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var x = 'A' + _group++;
            xrcGroup.Text = (char)x + "";
        }

        int _no = 0;
        private void xrc_No_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrc_No.Text = "" + ++_no;
        }
    }
}