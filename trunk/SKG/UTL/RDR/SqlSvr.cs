using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;

namespace UTL.RDR
{
    public class SqlSvr : CsoRDR
    {
        private const string STR_SL1 = "select name from sys.columns where object_id = (select object_id from sys.tables where name = '{0}')";
        private const string STR_SL2 = "select * from {0}";
        private const string STR_IS1 = "insert into {0}({1}) values({2})";
        private const string STR_DFO = "set dateformat dmy";
        private const string STR_DBS = "select name from sys.sysdatabases";

        public SqlConnection Cnn { set; get; }

        #region Constructor
        public SqlSvr(string connectString) { Cnn = new SqlConnection(connectString); }

        public SqlSvr(string serverName, string databaseName)
        {
            Cnn = new SqlConnection(String.Format(STR_TRU, serverName, databaseName));
        }

        public SqlSvr(string serverName, string databaseName, string userName, string password)
        {
            Cnn = new SqlConnection(String.Format(STR_SEC, serverName, databaseName, userName, password));
        }
        #endregion

        #region Method
        public bool NotExists(string dbName)
        {
            var res = GetDatabases();
            if (res == null) return false;

            DataRow[] dtr = res.Select(String.Format("[name]='{0}'", dbName));
            if (dtr.Length > 0) return false;
            return true;
        }

        public DataTable GetDatabases()
        {
            return ExecuteReader(STR_DBS);
        }

        public DataTable ExecuteReader(string command, string tableName = "Tmp")
        {
            if (Open() == false) return null;

            var trs = Cnn.BeginTransaction();

            try
            {
                using (var cmd = new SqlCommand(command, Cnn, trs))
                {
                    var res = new DataTable(tableName);
                    res.Load(cmd.ExecuteReader());
                    trs.Commit();
                    return res;
                }
            }
            catch { trs.Rollback(); return null; }
            finally { Close(); }
        }

        public int ExecuteNonQuery(string command, bool transaction = true)
        {
            int error = -2;

            if (Open() == false) return error;

            if (transaction)
            {
                var trs = Cnn.BeginTransaction();

                try
                {
                    using (var cmd = new SqlCommand(command, Cnn, trs))
                    {
                        int res = cmd.ExecuteNonQuery();
                        trs.Commit();
                        return res;
                    }
                }
                catch { trs.Rollback(); return error; }
                finally { Close(); }
            }
            else
            {
                try
                {
                    using (var cmd = new SqlCommand(command, Cnn))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch { return error; }
                finally { Close(); }
            }
        }

        public bool ExecuteFileSQL(string dbName, string fileName, bool showInfo = false)
        {
            bool res = true;

            if (File.Exists(fileName) == true)
            {
                if (Open())
                {
                    var trs = Cnn.BeginTransaction();
                    try
                    {
                        using (var cmd = new SqlCommand { Connection = Cnn, Transaction = trs })
                        {
                            string sql = "USE {0}";
                            cmd.CommandText = String.Format(sql, dbName);
                            cmd.ExecuteNonQuery();

                            using (var rdr = new StreamReader(fileName))
                            {
                                sql = "";
                                string tmp = "";

                                while (!rdr.EndOfStream)
                                {
                                    tmp = rdr.ReadLine();
                                    if (tmp.ToLower() != "go")
                                    {
                                        if (!tmp.StartsWith("--"))
                                        {
                                            int i = tmp.LastIndexOf("--");
                                            if (i == -1) sql += tmp + Environment.NewLine;
                                            else sql += tmp.Substring(0, i) + Environment.NewLine;
                                        }
                                    }
                                    else
                                    {
                                        cmd.CommandText = sql;
                                        cmd.ExecuteNonQuery();
                                        sql = "";
                                    }
                                }
                                rdr.Close();
                            }
                        }
                        trs.Commit();
                    }
                    catch
                    {
                        trs.Rollback();

                        Info = String.Format("{0};{1}", "Lỗi thực thi lệnh SQL!", "Excute SQL command error!");
                        res = false;
                    }
                    finally { Close(); }
                }
                else
                {
                    Info = String.Format("{0};{1}", "Không kết nối được server!", "Not connect to server!");
                    res = false;
                }
            }
            else
            {
                Info = String.Format("{0};{1}", "Không tìm thấy file dữ liêu!", "Not found database file!");
                res = false;
            }

            if (res)
            {
                if (showInfo)
                {
                    string s = String.Format("{0};{1}", "Thành công!", "Successfull!");
                    UTL.CsoUTL.Show(s);
                }

                return true;
            }
            else
            {
                if (showInfo)
                {
                    if (Info == "") Info = String.Format("{0};{1}", "Lỗi cài đặt!", "Setup fail!");
                    string t = String.Format("{0};{1}", "Lỗi", "Error");
                    UTL.CsoUTL.Show(Info, t);
                }

                return false;
            }
        }

        public bool CreateDbName(string dbName, string path = null)
        {
            string sql = "CREATE DATABASE {0}";
            if (path != null) sql = UTL.DAL.CsoDAL.STR_CREATE;
            var res = ExecuteNonQuery(String.Format(sql, dbName, path), false);
            return res == -2 ? false : true;
        }
        #endregion

        #region Override method
        public override List<string> GetTable(string name = null)
        {
            var tbl = ExecuteReader("select name from sys.tables");
            var lst = new List<string>();

            foreach (DataRow r in tbl.Rows)
            {
                lst.Add(r["name"].ToString());
            }

            lst.Sort();
            return lst;
        }

        public override DataTable GetColumn(string name)
        {
            return ExecuteReader(String.Format(STR_SL1, name));
        }

        public override DataTable GetData(string name)
        {
            return ExecuteReader(String.Format(STR_SL2, name));
        }

        public override int InsertData(DataTable table, string name)
        {
            #region Columns
            DataTable tbl = GetColumn(name);
            string col = "";
            foreach (DataRow r in tbl.Rows)
            {
                col += String.Format("{0}, ", r[0]);
            }
            col = col.TrimEnd(new char[] { ',', ' ' });
            #endregion

            #region Values
            ExecuteNonQuery(STR_DFO);
            int i = 0;

            using (var cmd = new SqlCommand { Connection = Cnn })
            {
                foreach (DataRow r in table.Rows)
                {
                    string val = "";
                    foreach (DataColumn c in table.Columns)
                    {
                        val += String.Format("N'{0}', ", r[c.ColumnName]);
                    }

                    val = val.TrimEnd(new char[] { ',', ' ' });
                    i += ExecuteNonQuery(String.Format(STR_IS1, name, col, val));
                }
            }
            #endregion

            return i;
        }

        public override bool Open(bool showInfo = false)
        {
            try
            {
                if (Cnn.State == ConnectionState.Closed) Cnn.Open();
                return true;
            }
            catch (Exception ex)
            {
                if (showInfo)
                {
                    string s = String.Format("{0};{1}", "Lỗi kết nối!", ex.Message);
                    string t = String.Format("{0};{1}", "Lỗi", "Error");
                    Info = s;
                    UTL.CsoUTL.Show(s, t);
                }

                return false;
            }
        }

        public override void Close() { if (Cnn != null) { Cnn.Close(); } }
        #endregion

        #region Static method
        public static DataTable GetSQLServers()
        {
            try
            {
                SqlDataSourceEnumerator list = SqlDataSourceEnumerator.Instance;
                var tb = list.GetDataSources();
                tb.Columns.Add("name");
                string tmp = "";

                foreach (DataRow dr in tb.Rows)
                {
                    if (dr["InstanceName"] + "" == "") tmp = @"{0}{1}";
                    else tmp = @"{0}\{1}";
                    dr["name"] = String.Format(tmp, dr["ServerName"], dr["InstanceName"]);
                }

                return tb;
            }
            catch { return null; }
        }
        #endregion
    }
}