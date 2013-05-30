﻿using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Báo cáo doanh thu xe cố định
    /// </summary>
    public partial class Rpt_RevenueFixed2 : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_RevenueFixed2()
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
        }

        int _sation = 0;
        private void xrcStation_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcStation.Text = "" + ++_sation;
        }
    }
}