using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Danh sách xe tuyến cố định
    /// </summary>
    public partial class Rpt_FixedVehicle1 : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_FixedVehicle1()
        {
            InitializeComponent();
        }

        int _transport = 0;
        private void xrcTransport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcTransport.Text = "" + ++_transport;
        }
    }
}