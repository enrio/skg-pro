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

        int _region = 0;
        private void xrcRegion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var x = 'A' + _region++;
            xrcRegion.Text = (char)x + "";
        }

        int _area = 0;
        private void xrcArea_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcArea.Text = SKG.Extend.Number.ToRoman(++_area);
        }

        int _province = 0;
        private void xrcProvince_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcProvince.Text = "" + ++_province;
        }
    }
}