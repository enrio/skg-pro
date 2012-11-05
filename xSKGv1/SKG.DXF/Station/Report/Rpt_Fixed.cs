using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace SKG.DXF.Station.Report
{
    public partial class Rpt_Fixed : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_Fixed()
        {
            InitializeComponent();
        }

        private void xrcRegion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrcArea_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrcProvince_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}