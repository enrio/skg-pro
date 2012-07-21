using System;
using System.Collections.Generic;
using System.Linq;

namespace BXE.DAL
{
    using Entities;
    using System.Data;
    using System.Data.Common;
    using System.Data.Entity;

    public class BaseDAL : IDisposable
    {
        internal Context _db = new Context();
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
            Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }

        /// <summary>
        /// Lấy giờ hệ thống (SQL Server)
        /// </summary>
        /// <returns>Thời gian hiện tại</returns>
        public DateTime GetDate()
        {
            return _db.Database.SqlQuery<DateTime>("SELECT GETDATE()").First();
        }

        public void Dispose()
        {
            _db.Dispose();
            _tb.Dispose();

            _db = null;
            _tb = null;
        }
    }
}