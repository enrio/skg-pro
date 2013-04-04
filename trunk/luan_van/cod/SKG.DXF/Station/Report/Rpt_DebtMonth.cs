﻿using System;

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
            xrcRegion.Text = "" + ++_region;
        }

        int _code = 0;
        private void xrcCode_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcCode.Text = "" + ++_code;
        }
    }
}