using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.UTL.Db
{
    using System.IO;
    using System.Data.SqlClient;
    using System.Data.Sql;
    using System.Data;
    using System.Configuration;

    public sealed class SQLServer : BaseDb
    {
        #region Contansts
        public const string STR_SEC = "Data Source={0};Initial Catalog={1};User Id={2};Password={3};";
        public const string STR_TRU = "Data Source={0};Initial Catalog={1};Integrated Security=SSPI;";

        private const string STR_SUCCESS = "Cài đặt thành công!";
        private const string STR_SETUP = "Cài đặt";
        private const string STR_NOT_FOUND = "Không tìm thấy file dữ liệu!";
        private const string STR_NOCONNECT = "Không kết nối được server!";
        private const string STR_ERR_EXCUTE = "Lỗi thực thi lệnh SQL!";
        private const string STR_ERR_SET = "Lỗi cài đặt!";
        #endregion

        #region Default objects
        #endregion

        #region More objects
        #endregion

        #region Properties
        #endregion

        #region Implements
        #endregion

        #region Constructors
        public SQLServer() { }
        public SQLServer(string connectString) : base(connectString) { }
        #endregion

        #region Events
        #endregion

        #region Methods
        /// <summary>
        /// Get all database in SQL Server
        /// </summary>
        /// <returns>Data</returns>
        public List<string> GetDatabases()
        {
            var tbl = ExecuteQuery("select name from sys.sysdatabases");
            var lst = new List<string>();
            foreach (DataRow r in tbl.Rows) lst.Add(r["name"] + "");
            return lst;
        }

        /// <summary>
        /// Check database exitst
        /// </summary>
        /// <param name="dbName">Database name</param>
        /// <returns>True is exists else false</returns>
        public bool CheckDbExists(string dbName)
        {
            var res = GetDatabases();
            return res.Contains(dbName);
        }

        /// <summary>
        /// Create a database
        /// </summary>
        /// <param name="dbName">Database name</param>
        /// <param name="path">Path store database</param>
        /// <returns>True is ok else false</returns>
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
        /// <param name="fileName">File SQL name</param>
        /// <param name="showInfo">Show message is true else not show</param>
        /// <returns>True is successfull else false</returns>
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
                //if (showInfo) UTL.Message.Show(STR_SUCCESS, STR_SETUP);
                return true;
            }
            else
            {
                if (showInfo)
                {
                    if (err == null) err = STR_ERR_SET;
                    //UTL.Message.Show(err, STR_SETUP);
                }

                return false;
            }
        }

        /// <summary>
        /// Execute SQL file
        /// </summary>
        /// <param name="fileName">File SQL name</param>
        /// <returns>True is successfull else false</returns>
        /*public bool ExecuteFileSQL(string fileName)
        {
            try
            {
                FileInfo file = new FileInfo(@fileName);
                string script = file.OpenText().ReadToEnd();

                Server server = new Server();
                server.ConnectionContext.ConnectionString = DAL.Properties.Settings.Default.Setting;
                server.ConnectionContext.ExecuteNonQuery(script);
                return true;
            }
            catch { return false; }
        }*/
        #endregion

        #region More
        #endregion
    }
}