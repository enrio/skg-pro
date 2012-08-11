using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Reader
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.Sql;

    public class SqlReader : BaseReader
    {
        private const string STR_SL1 = "select name from sys.columns where object_id = (select object_id from sys.tables where name = '{0}')";
        private const string STR_SL2 = "select * from {0}";
        private const string STR_IS1 = "insert into {0}({1}) values({2})";
        private const string STR_DFO = "set dateformat dmy";
        private const string STR_DBS = "select name from sys.sysdatabases";

        public SqlConnection Cnn { set; get; }
        public SqlReader() { Cnn = null; }

        public SqlReader(string serverName, string databaseName)
        {
            Cnn = new SqlConnection(String.Format(STR_TRU, serverName, databaseName));
        }

        public SqlReader(string serverName, string databaseName, string userName, string password)
        {
            Cnn = new SqlConnection(String.Format(STR_SEC, serverName, databaseName, userName, password));
        }

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
                using (SqlDataAdapter adp = new SqlDataAdapter("select name from sys.tables", Cnn))
                {
                    using (DataTable tbl = new DataTable("Tmp"))
                    {
                        adp.Fill(tbl);
                        List<string> lst = new List<string>();
                        foreach (DataRow r in tbl.Rows)
                        {
                            lst.Add(r["name"].ToString());
                        }
                        lst.Sort();
                        return lst;
                    }
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
        /// Get all columns
        /// </summary>
        /// <param name="name">table name/worksheet name</param>
        /// <returns>data in columns</returns>
        public override DataTable GetColumn(string name)
        {
            try
            {
                using (SqlDataAdapter adp = new SqlDataAdapter(String.Format(STR_SL1, name), Cnn))
                {
                    DataTable tbl = new DataTable(name);
                    adp.Fill(tbl);
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
        /// Get all data
        /// </summary>
        /// <param name="name">table name/worksheet name</param>
        /// <returns>data in table/worksheet</returns>
        public override DataTable GetData(string name)
        {
            try
            {
                using (var dar = new SqlDataAdapter(String.Format(STR_SL2, name), Cnn))
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
                #region columns
                DataTable tbl = GetColumn(name);
                string col = "";
                foreach (DataRow r in tbl.Rows)
                {
                    col += String.Format("{0}, ", r[0]);
                }
                col = col.TrimEnd(new char[] { ',', ' ' });
                #endregion

                #region values
                int i = 0;
                using (var cmd = new SqlCommand { Connection = Cnn })
                {
                    Cnn.Open();
                    cmd.CommandText = STR_DFO;
                    cmd.ExecuteNonQuery();

                    foreach (DataRow r in table.Rows)
                    {
                        string val = "";
                        foreach (DataColumn c in table.Columns)
                        {
                            //if (r[c.ColumnName] + "" == "") continue;
                            val += String.Format("N'{0}', ", r[c.ColumnName]);
                        }
                        val = val.TrimEnd(new char[] { ',', ' ' });
                        cmd.CommandText = String.Format(STR_IS1, name, col, val);
                        try
                        {
                            i += cmd.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                            Err = e.Message;
                        }
                    }
                }
                #endregion
                return i;
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

        /// <summary>
        /// Get all SQL Server and Instance name
        /// </summary>
        /// <returns>data in table</returns>
        public static DataTable GetSQLServers()
        {
            SqlDataSourceEnumerator list = SqlDataSourceEnumerator.Instance;
            return list.GetDataSources();
        }

        /// <summary>
        /// Get all database names
        /// </summary>
        /// <returns>data in table</returns>
        public DataTable GetDatabases()
        {
            using (var dap = new SqlDataAdapter(STR_DBS, Cnn))
            {
                var tbl = new DataTable("Tmp");
                dap.Fill(tbl);
                return tbl;
            }
        }
    }
}