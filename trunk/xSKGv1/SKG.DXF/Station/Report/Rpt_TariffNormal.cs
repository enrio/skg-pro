using System;

namespace SKG.DXF.Station.Report
{
    /// <summary>
    /// Bảng giá loại xe vãng lai
    /// </summary>
    public partial class Rpt_TariffNormal : DevExpress.XtraReports.UI.XtraReport
    {
        public Rpt_TariffNormal()
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