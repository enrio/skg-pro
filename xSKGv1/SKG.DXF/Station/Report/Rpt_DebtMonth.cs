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

        int _code = 0;
        private void xrcCode_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcCode.Text = "" + ++_code;
        }

        string _transport = "";
        private void xrcTransport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (_transport != xrcTransport.Text)
                _transport = xrcTransport.Text;
            else xrcTransport.Text = "";
        }

        string _tariff = "";
        private void xrcTariff_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (_tariff != xrcTariff.Text)
                _tariff = xrcTariff.Text;
            else xrcTariff.Text = "";
        }

        int _region = 0;
        private void xrcRegion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var x = 'A' + _region++;
            xrcRegion.Text = (char)x + "";
        }
    }
}