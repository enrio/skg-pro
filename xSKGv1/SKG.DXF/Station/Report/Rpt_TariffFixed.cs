using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Bảng giá tuyến xe cố định
    /// </summary>
    public partial class Rpt_TariffFixed : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_TariffFixed()
        {
            InitializeComponent();
        }

        int _group = 0;
        private void xrcGroup_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcGroup.Text = "" + ++_group;
        }

        int _text = 0;
        private void xrcText_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrcText.Text = "" + ++_text;
        }
    }
}