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

    public abstract class BaseDb
    {
        #region Contansts
        protected const string STR_BACKUP = @"BACKUP DATABASE {0} " +
            @"TO DISK = N'{1}' WITH NOFORMAT, NOINIT, " +
            @"NAME = N'{2}', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

        protected const string STR_RESTOR = @"USE MASTER; DROP DATABASE {0}; RESTORE DATABASE {0} " +
            @"FROM  DISK = N'{1}' WITH  FILE = 1, NOUNLOAD, STATS = 10";

        protected const string STR_CREATE = @"CREATE DATABASE {0} " +
            @"ON  PRIMARY (NAME = N'{0}', FILENAME = N'{1}\{0}.mdf', SIZE = 3072KB, FILEGROWTH = 1024KB) " +
            @"LOG ON (NAME = N'{0}_log', FILENAME = N'{1}\{0}_log.ldf', SIZE = 1024KB, FILEGROWTH = 10%) " +
            @"COLLATE VIETNAMESE_CI_AI";

        protected const string STR_DBNAME = "master";
        protected const string STR_DFO = "set dateformat dmy";

        public const string STR_ESEC = "metadata=res://*/xG14.csdl|res://*/xG14.ssdl|res://*/xG14.msl;" +
            "provider=System.Data.SqlClient;provider connection string='Data Source={0};Initial Catalog={1};" +
            "Persist Security Info=True;User ID={2};Password={3};MultipleActiveResultSets=True'";

        public const string STR_ETRU = "metadata=res://*/xG14.csdl|res://*/xG14.ssdl|res://*/xG14.msl;" +
            "provider=System.Data.SqlClient;provider connection string='Data Source={0};Initial Catalog={1};" +
            "Integrated Security=True;MultipleActiveResultSets=True'";
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
        /// Current date time form system (SQL Server)
        /// </summary>
        //public static DateTime? CurrentTime { get { return new xG14DataContext().CurrentTime(); } }
        #endregion

        #region Constructors
        public BaseDb() : this(CurrentConnectString) { } // default connection string

        public BaseDb(string connectString)
        {
            _cnn = new SqlConnection(connectString);
            _cmd = new SqlCommand() { Connection = _cnn };

            DbName = "xG14";
            //FileX = Application.StartupPath + @"\xG14.sql";
            //FileY = Application.StartupPath + @"\yG14.sql";
        }
        #endregion

        #region Implements
        #endregion

        #region Events
        #endregion

        #region Methods
        /// <summary>
        /// Open connection
        /// </summary>
        /// <returns>True is open successfull else false</returns>
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
        /// <param name="tableName">table name</param>
        /// <returns>data</returns>
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
        /// <returns>number of records affect</returns>
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

        #region Overrides
        #endregion

        #region Statics
        /// <summary>
        /// Get all SQL Server in LAN
        /// </summary>
        /// <returns>Data</returns>
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

        #region More
        #endregion
    }
}