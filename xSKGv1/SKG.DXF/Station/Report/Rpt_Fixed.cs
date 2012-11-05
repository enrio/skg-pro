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

        static int _region = 0;
        private void xrcRegion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcRegion.Text = "" + ++_region;
        }

        static int _area = 0;
        private void xrcArea_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcArea.Text = "" + ++_area;
        }

        static int _province = 0;
        private void xrcProvince_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcProvince.Text = "" + ++_province;
        }
    }
}