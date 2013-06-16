﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 12/06/2013 06:07
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.Datax
{
    /// <summary>
    /// Excel processing
    /// </summary>
    public class Excel
    {
        public static DataTable ImportFromExcel(string excelFile, string tableName)
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
                var cmd = new OleDbCommand(String.Format("SELECT * FROM [{0}$]", tableName), oleCnn);

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