using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Datax
{
    using System.Data;
    using System.Data.OleDb;
    using System.Windows.Forms;

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
            catch (Exception e)
            {
                MessageBox.Show(e.Message); return null;
            }
        }
    }
}