using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Báo cáo công nợ tháng
    /// </summary>
    public partial class Rpt_DebtMonth : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_DebtMonth()
        {
            InitializeComponent();
        }

        int _region = 0;
        private void xrcRegion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var x = 'A' + _region++;
            xrcRegion.Text = (char)x + "";
            //_area = 0;
        }

        int _area = 0;
        private void xrcTariff_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcTariff.Text = "" + ++_area;
            //_sation = 0;
        }

        int _sation = 0;
        private void xrcCode_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcCode.Text = "" + ++_sation;
        }
    }
}