using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Data
{
    using System.Data;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    /// <summary>
    /// Database processing
    /// </summary>
    public abstract class Base : IDisposable
    {
        #region Contansts
        /// <summary>
        /// Backup database
        /// </summary>
        protected const string STR_BACKUP = @"BACKUP DATABASE {0} " +
            @"TO DISK = N'{1}' WITH NOFORMAT, NOINIT, " +
            @"NAME = N'{2}', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

        /// <summary>
        /// Restore database
        /// </summary>
        protected const string STR_RESTOR = @"USE MASTER; DROP DATABASE {0}; RESTORE DATABASE {0} " +
            @"FROM  DISK = N'{1}' WITH  FILE = 1, NOUNLOAD, STATS = 10";

        /// <summary>
        /// Create database
        /// </summary>
        protected const string STR_CREATE = @"CREATE DATABASE {0} " +
            @"ON  PRIMARY (NAME = N'{0}', FILENAME = N'{1}\{0}.mdf', SIZE = 3072KB, FILEGROWTH = 1024KB) " +
            @"LOG ON (NAME = N'{0}_log', FILENAME = N'{1}\{0}_log.ldf', SIZE = 1024KB, FILEGROWTH = 10%) " +
            @"COLLATE VIETNAMESE_CI_AI";

        /// <summary>
        /// Master database
        /// </summary>
        protected const string STR_DBN = "master";

        /// <summary>
        /// Format dd/MM/yyyy
        /// </summary>
        protected const string STR_DFO = "set dateformat dmy";
        #endregion

        #region Objects
        /// <summary>
        /// Default SqlConnection object
        /// </summary>
        protected SqlConnection _cnn;

        /// <summary>
        /// Default SqlCommand object
        /// </summary>
        protected SqlCommand _cmd;

        /// <summary>
        /// Default empty table
        /// </summary>
        protected readonly DataTable _dtb = new DataTable("Tmp");
        #endregion

        #region Properties
        /// <summary>
        /// Structure of database
        /// </summary>
        public static string FileX { set; get; }

        /// <summary>
        /// Data template of database
        /// </summary>
        public static string FileY { set; get; }

        /// <summary>
        /// Default database name 
        /// </summary>
        public static string DbName { set; get; }

        /// <summary>
        /// Get current connect string
        /// </summary>
        public static string CurrentConnectString
        {
            get
            {
                //Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                //var s = _config.ConnectionStrings.ConnectionStrings[1].ConnectionString;

                //var t = s.IndexOf('\'');
                //if (t < 0) return s;
                //return s.Substring(t).Replace("'", "");

                return "";
            }
        }

        /// <summary>
        /// Get current information connection 
        /// </summary>
        public static ConnectInfo CurrentConnectInfo
        {
            get
            {
                var tmp = new ConnectInfo();

                try
                {
                    var a = CurrentConnectString.Split(new char[] { ';' });

                    var a0 = a[0].Split(new char[] { '=' });
                    tmp.Server = a0[1];

                    var a1 = a[1].Split(new char[] { '=' });
                    tmp.Database = a1[1];

                    var a3 = a[3].Split(new char[] { '=' });
                    tmp.User = a3[1];

                    var a4 = a[4].Split(new char[] { '=' });
                    tmp.Password = a4[1];
                }
                catch { tmp.User = tmp.Password = ""; }

                return tmp;
            }
        }

        /// <summary>
        /// Current date time from system (SQL Server)
        /// </summary>
        public static DateTime Now { get { return DateTime.Now; } }
        #endregion

        #region Constructors
        public Base() : this(CurrentConnectString) { } // default connection string

        public Base(string connectString)
        {
            _cnn = new SqlConnection(connectString);
            _cmd = new SqlCommand() { Connection = _cnn };

            DbName = "xSKGv1";
            FileX = Application.StartupPath + @"\xSKGv1.sql";
            FileY = Application.StartupPath + @"\ySKGv1.sql";
        }
        #endregion

        #region Implements
        /// <summary>
        /// Dispose all fields
        /// </summary>
        public void Dispose()
        {
            _cnn.Dispose();
            _cmd.Dispose();
            _dtb.Dispose();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Open connection
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            try
            {
                if (_cnn.State == ConnectionState.Closed)
                    _cnn.Open();
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Close connection
        /// </summary>
        protected void Close()
        {
            if (_cnn.State != ConnectionState.Closed)
                _cnn.Close();
        }

        /// <summary>
        /// Execute query SQL command text
        /// </summary>
        /// <param name="sqlCommand">T-SQL</param>
        /// <param name="tableName">Table name</param>
        /// <returns></returns>
        protected DataTable ExecuteQuery(string sqlCommand, string tableName = "Tmp")
        {
            try
            {
                Open();
                _cmd.CommandText = sqlCommand;
                var tbl = new DataTable(tableName);
                tbl.Load(_cmd.ExecuteReader());
                return tbl;
            }
            catch { return null; }
            finally { Close(); }
        }

        /// <summary>
        /// Execute non query SQL command text
        /// </summary>
        /// <param name="sqlCommand">T-SQL</param>
        /// <returns></returns>
        protected int ExecuteNonQuery(string sqlCommand)
        {
            try
            {
                Open();
                _cmd.CommandText = sqlCommand;
                return _cmd.ExecuteNonQuery();
            }
            catch { return -1; }
            finally { Close(); }
        }
        #endregion

        #region Statics
        /// <summary>
        /// Get all SQL Server in LAN
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSQLServers()
        {
            try
            {
                SqlDataSourceEnumerator lst = SqlDataSourceEnumerator.Instance;
                var tbl = lst.GetDataSources();
                tbl.Columns.Add("name");
                string tmp = "";

                foreach (DataRow dtr in tbl.Rows)
                {
                    if (dtr["InstanceName"] + "" == "") tmp = @"{0}{1}";
                    else tmp = @"{0}\{1}";
                    dtr["name"] = String.Format(tmp, dtr["ServerName"], dtr["InstanceName"]);
                }

                return tbl;
            }
            catch { return null; }
        }
        #endregion

        #region More
        /// <summary>
        /// Current information connection
        /// </summary>
        public class ConnectInfo
        {
            public string Server { set; get; }
            public string Database { set; get; }
            public string User { set; get; }
            public string Password { set; get; }
        }
        #endregion
    }
}