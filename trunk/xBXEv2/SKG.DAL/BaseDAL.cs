using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.DAL
{
    using Entities;
    using System.Data;
    using System.Data.Common;
    using System.Data.Entity;

    /// <summary>
    /// 
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
    }
}