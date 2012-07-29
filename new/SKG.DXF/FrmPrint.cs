#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 29/07/2012 10:27
 * Update: 29/07/2012 10:27
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;

namespace SKG.DXF
{
    using DevExpress.XtraReports.UI;

    /// <summary>
    /// Show print report
    /// </summary>
    public partial class FrmPrint : XtraForm
    {
        /// <summary>
        /// Create
        /// </summary>
        public FrmPrint()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set XtraReport
        /// </summary>
        /// <param name="r">Xtra report</param>
        public void SetReport(XtraReport r)
        {
            printControl1.PrintingSystem = r.PrintingSystem;
            r.CreateDocument();
            printControl1.UpdatePageView();
        }
    }
}