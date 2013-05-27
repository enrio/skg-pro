using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Theo dõi tình hình hoạt động của xe cố định theo ngày
    /// </summary>
    public partial class Rpt_SalesFixed : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_SalesFixed()
        {
            InitializeComponent();
        }

        int _region = 0;
        private void xrcRegion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var x = 'A' + _region++;
            xrcRegion.Text = (char)x + "";
            _area = 0;
        }

        int _area = 0;
        private void xrcArea_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcArea.Text = "" + ++_area;
            _sation = 0;
        }

        int _sation = 0;
        private void xrcStation_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcStation.Text = "" + ++_sation;
        }
    }
}