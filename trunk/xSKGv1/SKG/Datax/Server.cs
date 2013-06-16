#region Information
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
using System.IO;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SKG.Datax
{
    /// <summary>
    /// SQL Server processing
    /// </summary>
    public class Server : Base
    {
        #region Contansts
        public const string STR_SEC = @"Data Source={0};Initial Catalog={1};Persist Security Info=True;User Id={2};Password={3}";
        public const string STR_TRU = @"Data Source={0};Initial Catalog={1};Integrated Security=SSPI";

        private const string STR_2K7 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";";
        private const string STR_2K3 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";

        private const string STR_SUCCESS = "Cài đặt thành công!";
        private const string STR_SETUP = "Cài đặt";
        private const string STR_NOT_FOUND = "Không tìm thấy file dữ liệu!";
        private const string STR_NOCONNECT = "Không kết nối được server!";
        private const string STR_ERR_EXCUTE = "Lỗi thực thi lệnh SQL!";
        private const string STR_ERR_SET = "Lỗi cài đặt!";
        #endregion

        #region Constructors
        public Server() { }
        public Server(string connectString) : base(connectString) { }
        #endregion

        #region Methods
        /// <summary>
        /// Get all database name in SQL Server (not sysdatabases)
        /// </summary>
        /// <returns></returns>
        public List<string> GetDatabases()
        {
            try
            {
                var tbl = ExecuteQuery("select [name] from sys.sysdatabases where [name] not in ('master', 'tempdb', 'model', 'msdb')");
                var lst = new List<string>();
                foreach (DataRow r in tbl.Rows) lst.Add(r["name"] + "");
                return lst;
            }
            catch { return null; }
        }

        /// <summary>
        /// Check database exitst
        /// </summary>
        /// <param name="dbName">Database name</param>
        /// <returns></returns>
        public bool CheckDbExists(string dbName)
        {
            var res = GetDatabases();
            return res == null ? false : res.Contains(dbName);
        }

        /// <summary>
        /// Create a database
        /// </summary>
        /// <param name="dbName">Database name</param>
        /// <param name="path">Path database file name</param>
        /// <returns></returns>
        public bool CreateDbName(string dbName, string path = null)
        {
            string sql;
            if (path != null) sql = STR_CREATE;
            else sql = "CREATE DATABASE {0}";

            var res = ExecuteNonQuery(String.Format(sql, dbName, path));
            return res == -2 ? false : true;
        }

        /// <summary>
        /// Execute SQL file
        /// </summary>
        /// <param name="dbName">Database name</param>
        /// <param name="fileName">Path SQL script file name</param>
        /// <param name="showInfo">Show message</param>
        /// <returns></returns>
        public bool ExecuteFileSQL(string dbName, string fileName, bool showInfo = false)
        {
            bool res = true;
            string err = null;

            if (File.Exists(fileName) == true)
            {
                if (Open())
                {
                    var trs = _cnn.BeginTransaction();
                    try
                    {
                        using (var cmd = new SqlCommand { Connection = _cnn, Transaction = trs })
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
                        err = STR_ERR_EXCUTE;
                        res = false;
                    }
                    finally { Close(); }
                }
                else
                {
                    err = STR_NOCONNECT;
                    res = false;
                }
            }
            else
            {
                err = STR_NOT_FOUND;
                res = false;
            }

            if (res)
            {
                if (showInfo) MessageBox.Show(STR_SUCCESS, STR_SETUP);
                return true;
            }
            else
            {
                if (showInfo)
                {
                    if (err == null) err = STR_ERR_SET;
                    MessageBox.Show(err, STR_SETUP);
                }
                return false;
            }
        }
        #endregion

        /// <summary>
        /// Import from Sheet in Excel file to Table in SQL Server
        /// </summary>
        /// <param name="file">Path Excel file</param>
        /// <param name="strCnn">String connection</param>
        /// <param name="tbl">Table name or Sheet name</param>
        /// <param name="isSQL">Use SQL Server</param>
        public static DataTable ImportFromExcel(string file, string strCnn, DataTable tbl, bool isSQL = true)
        {
            try
            {
                var tmp = file.Split(new char[] { '.' });
                var str = "";

                if (tmp[1] == "xls")
                    str = String.Format(STR_2K3, file);
                else if (tmp[1] == "xlsx")
                    str = String.Format(STR_2K7, file);
                else
                {
                    MessageBox.Show("Not excel file!");
                    return null;
                }

                var oleCnn = new OleDbConnection(str);
                var cmd = new OleDbCommand(String.Format("SELECT * FROM [{0}$]", tbl.TableName), oleCnn);

                oleCnn.Open();
                var rdr = cmd.ExecuteReader();

                tbl.Load(rdr);
                oleCnn.Close();

                var dtr = tbl.Select("Id Is Null");
                foreach (DataRow r in dtr)
                    r["Id"] = Guid.NewGuid();

                if (isSQL)
                {
                    var copy = new SqlBulkCopy(strCnn) { DestinationTableName = tbl.TableName };
                    copy.WriteToServer(tbl);
                }

                return tbl;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}