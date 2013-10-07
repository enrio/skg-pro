#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 03/10/2013 18:07
 * Status: OK
 */
#endregion

using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SKG.Datax
{
    /// <summary>
    /// Excel processing
    /// </summary>
    public class Excel
    {
        private Microsoft.Office.Interop.Excel.Application oExcel = null;

        public Excel()
        {
            if (oExcel == null)
            {
                oExcel = new Microsoft.Office.Interop.Excel.Application();
                oExcel.Visible = false;
                oExcel.DisplayAlerts = false;
                oExcel.EnableEvents = false;
            }
        }

        /// <summary>
        /// Close excel
        /// </summary>
        public void CloseExcel()
        {
            oExcel.DisplayAlerts = true;
            oExcel.EnableEvents = true;
            oExcel.Quit();
            oExcel = null;
        }

        /// <summary>
        /// Find excel files
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns></returns>
        public List<string> FindExcelFiles(string path)
        {
            List<string> fileCollection = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(path);

            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Extension == ".xlsx" && file.CreationTime < DateTime.Today.AddDays(-10))
                    fileCollection.Add(file.FullName);
            }

            return fileCollection;
        }

        /// <summary>
        /// Clear sheet
        /// </summary>
        /// <param name="fileName">Path file name</param>
        public void ClearSheet(string fileName)
        {
            var xlApp = (Microsoft.Office.Interop.Excel.Application)Marshal.GetActiveObject("Excel.Application");
            var xlBooks = (Microsoft.Office.Interop.Excel.Workbooks)xlApp.Workbooks;

            foreach (Microsoft.Office.Interop.Excel.Workbook xlBook in xlBooks)
                if (xlBook.Name.Contains("NhapBT") || xlBook.Name.Contains("XuatBT"))
                    return;

            Microsoft.Office.Interop.Excel.Workbook oBook = null;
            oBook = oExcel.Workbooks.Open(fileName);

            foreach (Microsoft.Office.Interop.Excel.Worksheet sheet in oBook.Worksheets)
            {
                //var r = (Microsoft.Office.Interop.Excel.Range)sheet.get_Range("B2", "C3");
                //r.ClearContents();
                sheet.UsedRange.ClearContents();

                sheet.get_Range("A1").Value = "STT";
                sheet.get_Range("B1").Value = "BIENSO";

                if (fileName.Contains("NhapBT"))
                {
                    sheet.get_Range("C1").Value = "VAO";

                    if (sheet.Name.Contains("Luudau"))
                    {
                        sheet.get_Range("D1").Value = "LOAIXE";
                        sheet.get_Range("E1").Value = "GHE";
                        sheet.get_Range("F1").Value = "GIUONG";
                    }
                }

                if (fileName.Contains("XuatBT"))
                {
                    sheet.get_Range("C1").Value = "RA";

                    if (sheet.Name.Contains("Luudau"))
                        sheet.get_Range("D1").Value = "SERI";
                }
            }

            oBook.Save();
            oBook.Close();
        }

        /// <summary>
        /// Clear data in worksheet
        /// </summary>
        /// <param name="fileName">Path file name</param>
        public static void ClearWorksheets(string fileName)
        {
            var ex = new Excel();
            ex.ClearSheet(fileName);
        }

        /// <summary>
        /// Import data from Excel file
        /// </summary>
        /// <param name="excelFile">Excel file</param>
        /// <param name="tableName">Table name</param>
        /// <param name="colNotNull">Column not null</param>
        /// <returns></returns>
        public static DataTable ImportFromExcel(string excelFile, string tableName, string colNotNull = "BIENSO")
        {
            try
            {
                const string STR_2K7 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";";
                const string STR_2K3 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";

                var tmp = excelFile.Split(new char[] { '.' });
                var str = "";

                if (tmp[1] == "xls")
                    str = String.Format(STR_2K3, excelFile);
                else if (tmp[1] == "xlsx")
                    str = String.Format(STR_2K7, excelFile);
                else
                {
                    MessageBox.Show("Not excel file!");
                    return null;
                }

                var oleCnn = new OleDbConnection(str);
                var sql = String.Format("SELECT * FROM [{0}$] WHERE {1} IS NOT NULL", tableName, colNotNull);
                var cmd = new OleDbCommand(sql, oleCnn);

                oleCnn.Open();
                var rdr = cmd.ExecuteReader();

                var tbl = new DataTable(tableName);
                tbl.Load(rdr);
                oleCnn.Close();
                return tbl;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }
    }
}