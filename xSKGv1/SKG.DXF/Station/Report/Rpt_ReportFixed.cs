﻿using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Bảng kê doanh thu xe cố định
    /// </summary>
    public partial class Rpt_ReportFixed : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_ReportFixed()
        {
            InitializeComponent();
        }

        private void xrcHoadon_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            _region = 0;
        }

        int _region = 0;
        private void xrcRegion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var x = 'A' + _region++;
            xrcRegion.Text = (char)x + "";
        }

        int _province = 0;
        private void xrcProvince_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcProvince.Text = "" + ++_province;
        }
    }
}