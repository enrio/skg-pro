using System;
using System.Collections.Generic;

namespace SKG.DXF
{
    using DevExpress.XtraReports.UI;

    public partial class FrmShowPrint : FrmInput
    {
        public FrmShowPrint()
        {
            InitializeComponent();

            AllowBar = false;
        }

        /// <summary>
        /// Set report
        /// </summary>
        /// <param name="r">XtraReport</param>
        public void SetReport(XtraReport r)
        {
            printControl1.PrintingSystem = r.PrintingSystem;
            r.CreateDocument();
            printControl1.UpdatePageView();
        }
    }
}