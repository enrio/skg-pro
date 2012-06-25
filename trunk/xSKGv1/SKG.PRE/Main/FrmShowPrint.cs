using System;
using System.Collections.Generic;

namespace PRE.Main
{
    using DevExpress.XtraReports.UI;

    public partial class FrmShowPrint : PRE.Catalog.FrmBase
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