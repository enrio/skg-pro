using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Theo dõi tình hình hoạt động của xe cố định theo tháng
    /// </summary>
    public partial class Rpt_Audit : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_Audit()
        {
            InitializeComponent();
        }

        int _region = 0;
        private void xrcRegion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var x = 'A' + _region++;
            xrcRegion.Text = (char)x + "";
        }

        int _area = 0;
        private void xrcArea_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcArea.Text = "" + ++_area;
        }

        int _sation = 0;
        private void xrcStation_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcStation.Text = "" + ++_sation;
        }
    }
}