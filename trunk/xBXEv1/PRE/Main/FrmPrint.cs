using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PRE.Main
{
    using DevExpress.XtraPrinting;
    using DevExpress.XtraEditors;
    using DevExpress.XtraReports.UI;
    using System.IO;

    public partial class FrmPrint : DevExpress.XtraEditors.XtraForm
    {
        public FrmPrint()
        {
            InitializeComponent();
        }

        string fileName = "";
        XtraReport report;

        public string FileName
        {
            set
            {
                string dirName = Path.GetDirectoryName(Application.StartupPath + @"\Repx\");
                fileName = Path.Combine(dirName, value);
            }
        }

        public XtraReport Report
        {
            get { return report; }
            set
            {
                report = value;
                try
                {
                    if (String.Compare(fileName, "", false) == 0) fileName = GetReportPath(report, "repx");
                    if (File.Exists(fileName)) report.LoadLayout(fileName);

                    report.CreateDocument();
                }
                catch (Exception ex) { BasePRE.ShowMessage(ex.Message, "Exception"); }
            }
        }

        /// <summary>
        /// Get report path
        /// </summary>
        /// <param name="report">XtraReport</param>
        /// <param name="ext">String</param>
        /// <returns>String</returns>
        public static string GetReportPath(XtraReport report, string ext)
        {
            try
            {
                string repName = report.Report.GetType().Name;

                if (repName.Length == 0) repName = report.GetType().Name;

                string dirName = Path.GetDirectoryName(Application.StartupPath + @"\Repx\");

                if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);

                string filename = Path.Combine(dirName, String.Format("{0}.{1}", repName, ext));
                if (!File.Exists(filename))
                {
                    using (var fstream = File.Create(filename))
                    {
                        report.SaveLayout(fstream);
                        fstream.Flush();
                        fstream.Close();
                    }
                }
                return filename;
            }
            catch (Exception ex) { BasePRE.ShowMessage(ex.Message, "Exception"); return ""; }
        }

        /// <summary>
        /// Used when displaying a single report
        /// </summary>
        /// <param name="report">XtraReport</param>
        public void SetReport(XtraReport report)
        {
            printControl1.PrintingSystem = report.PrintingSystem;
            report.CreateDocument();
            printControl1.UpdatePageView();
        }

        /// <summary>
        /// Used when displaying merged reports
        /// </summary>
        /// <param name="system">PrintingSystem</param>
        public void SetReport(PrintingSystem system)
        {
            printControl1.PrintingSystem = system;
            printControl1.UpdatePageView();
        }
    }
}