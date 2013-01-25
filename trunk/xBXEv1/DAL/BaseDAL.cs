using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    using SKG.UTL.Extension;
    using Entities;
    using System.Data;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Sql;

    /// <summary>
    /// Base abstract class Data Access Layer
    /// </summary>
    public abstract class BaseDAL
    {
        internal ZContext _db = new ZContext();
        internal DataTable _tb = new DataTable("Tmp");

        /// <summary>
        /// Đối tượng kết nối cơ sở dữ liệu
        /// </summary>
        /// <returns>DbConnection</returns>
        public DbConnection Connection()
        {
            return _db.Database.Connection;
        }

        /// <summary>
        /// Xoá cơ sở dữ liệu, nếu mô hình thay đổi
        /// </summary>
        public BaseDAL()
        {
            Database.SetInitializer<ZContext>(new DropCreateDatabaseIfModelChanges<ZContext>());
        }

        /// <summary>
        /// Lấy giờ hệ thống (SQL Server)
        /// </summary>
        /// <returns></returns>
        public DateTime GetDate()
        {
            return _db.Database.SqlQuery<DateTime>("SELECT GETDATE()").First();
        }

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
        /// Get all database in SQL Server
        /// </summary>
        /// <returns>Data</returns>
        public static List<string> GetDatabases()
        {
            try
            {
                var db = new ZContext();
                return db.Database.SqlQuery<string>("select name from sys.sysdatabases").ToList();
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

        #region Test
        public static DataTable TestPivot()
        {
            // sample data
            var data = new[] { new { Foo = 1, Bar = "Don Smith" }, 
                                 new { Foo = 1, Bar = "Mike Jones" }, 
                                 new { Foo = 1, Bar = "James Ray" }, 
                                 new { Foo = 2, Bar = "Tom Rizzo" }, 
                                 new { Foo = 2, Bar = "Alex Homes" }, 
                                 new { Foo = 3, Bar = "Andy Bates" }, };

            // group into columns, and select the rows per column
            var grps = from d in data
                       group d by d.Foo
                           into grp
                           select new
                           {
                               Foo = grp.Key,
                               Bars = grp.Select(d2 => d2.Bar).ToArray()
                           };

            return grps.ToDataTable();
        }

        public class Sales
        {
            public int Sequence { get; set; }
            public int Sequence2 { get; set; }
            public string Day { get; set; }
            public double Amount { get; set; }
        }

        public static DataTable TestPivot(ref DataTable src)
        {
            var week_days = new List<Sales>();
            week_days.Add(new Sales { Sequence = 1, Sequence2 = 8, Day = "Sun", Amount = 23 });
            week_days.Add(new Sales { Sequence = 2, Sequence2 = 8, Day = "Mon", Amount = 18 });
            week_days.Add(new Sales { Sequence = 3, Sequence2 = 8, Day = "Tue", Amount = 30 });
            week_days.Add(new Sales { Sequence = 4, Sequence2 = 8, Day = "Wed", Amount = 15 });
            week_days.Add(new Sales { Sequence = 5, Sequence2 = 8, Day = "Thu", Amount = 20 });
            week_days.Add(new Sales { Sequence = 6, Sequence2 = 8, Day = "Fri", Amount = 08 });
            week_days.Add(new Sales { Sequence = 7, Sequence2 = 8, Day = "Sat", Amount = 0 });
            week_days.Add(new Sales { Sequence = 8, Sequence2 = 0, Day = "Fri", Amount = 18 });

            src = week_days.ToDataTable();

            // before transpose
            foreach (var day in week_days)
                Console.WriteLine("{0}  {1}  {2}", day.Sequence, day.Day, day.Amount);

            var tr = from row in week_days
                     group row by "SALES" into g
                     where g.FirstOrDefault() != null
                     select new
                     {
                         DAY = g.Key,
                         Sun = g.Where(sales => sales.Day == "Sun").Sum(sales => sales.Amount),
                         Mon = g.Where(sales => sales.Day == "Mon").Sum(sales => sales.Amount),
                         Tue = g.Where(sales => sales.Day == "Tue").Sum(sales => sales.Amount),
                         Wed = g.Where(sales => sales.Day == "Wed").Sum(sales => sales.Amount),
                         Thu = g.Where(sales => sales.Day == "Thu").Sum(sales => sales.Amount),
                         Fri = g.Where(sales => sales.Day == "Fri").Sum(sales => sales.Amount),
                         Sat = g.Where(sales => sales.Day == "Sat").Sum(sales => sales.Amount)
                     };

            return tr.ToDataTable();
        }
        #endregion
    }
}