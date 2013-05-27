using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Theo dõi tình hình hoạt động của xe cố định theo ngày
    /// </summary>
    public partial class Rpt_SalesNormal : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_SalesNormal()
        {
            InitializeComponent();
        }

        int _region = 0;
        private void xrcRegion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var x = 'A' + _region++;
            xrcRegion.Text = (char)x + "";
        }

        int _sation = 0;
        private void xrcStation_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcStation.Text = "" + ++_sation;
        }
    }
}