using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Reader
{
    using System.Data;
    using System.Data.OleDb;

    public class ExcelReader : BaseReader
    {
        private const string STR_SL1 = "select * from [{0}$]";

        public OleDbConnection Cnn { set; get; }
        public ExcelReader() { Cnn = null; }

        #region override method
        /// <summary>
        /// Get all tables/worksheet
        /// </summary>
        /// <param name="name">excel file name</param>
        /// <returns></returns>
        public override List<string> GetTable(string name = null)
        {
            try
            {
                if (name.IndexOf("xlsx") == -1)
                {
                    Cnn = new OleDbConnection(String.Format(STR_2K3, name));
                }
                else
                {
                    Cnn = new OleDbConnection(String.Format(STR_2K7, name));
                }
                Cnn.Open();
                DataTable tbl = Cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                List<string> lst = new List<string>();
                foreach (DataRow r in tbl.Rows)
                {
                    lst.Add(r["TABLE_NAME"].ToString().Trim(new char[] { '$' }));
                }
                lst.Sort();
                return lst;
            }
            catch (Exception e)
            {
                Err = e.Message;
                return null;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Get all columns
        /// </summary>
        /// <param name="name">table/worksheet name</param>
        /// <returns>data in columns</returns>
        public override DataTable GetColumn(string name)
        {
            try
            {
                Cnn.Open();
                DataTable tbl = Cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);
                DataTable tmp = new DataTable(name);
                tmp.Columns.Add("COLUMN_NAME");
                DataRow[] dr = tbl.Select(String.Format("[TABLE_NAME]='{0}$'", name));
                foreach (DataRow r in dr)
                {
                    tmp.Rows.Add(new[] { r["COLUMN_NAME"].ToString() });
                }
                return tmp;
            }
            catch (Exception e)
            {
                Err = e.Message;
                return null;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Get all data
        /// </summary>
        /// <param name="name">table/worksheet name</param>
        /// <returns>data in table/worksheet</returns>
        public override DataTable GetData(string name)
        {
            try
            {
                using (var dar = new OleDbDataAdapter(String.Format(STR_SL1, name), Cnn))
                {
                    var tbl = new DataTable(name);
                    dar.Fill(tbl);
                    return tbl;
                }
            }
            catch (Exception e)
            {
                Err = e.Message;
                return null;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="table">data need to insert</param>
        /// <param name="name">table/worksheet name</param>
        /// <returns></returns>
        public override int InsertData(DataTable table, string name)
        {
            try
            {
                return 1;
            }
            catch (Exception e)
            {
                Err = e.Message;
                return -1;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Close connection
        /// </summary>
        public override void Close()
        {
            if (Cnn != null)
            {
                Cnn.Close();
            }
        }
        #endregion
    }
}