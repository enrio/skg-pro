using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Theo dõi tình hình hoạt động của xe cố định theo tháng
    /// </summary>
    public partial class Rpt_AuditMonthSgtvt : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_AuditMonthSgtvt()
        {
            InitializeComponent();
        }

        int _sation = 0;
        private void xrcStation_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcStation.Text = SKG.Extend.Number.ToRoman(++_sation);
            _transport = 0;
        }

        int _transport = 0;
        private void xrcTransport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcTransport.Text = "" + ++_transport;
        }
    }
}