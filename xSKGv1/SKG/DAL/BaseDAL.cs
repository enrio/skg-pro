#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 24/07/2012 22:02
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL
{
    using Entities;
    using System.Data;
    using System.Data.Common;
    using System.Data.Entity;

    /// <summary>
    /// Data access layer
    /// </summary>
    public abstract class BaseDAL : IDisposable
    {
        /// <summary>
        /// Access to database
        /// </summary>
        internal Context _db = new Context();

        /// <summary>
        /// Empty table
        /// </summary>
        internal DataTable _tb = new DataTable("Tmp");

        /// <summary>
        /// Create database if not exists
        /// </summary>
        public BaseDAL()
        {
            //Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
        }

        /// <summary>
        /// Get system time (on SQL Server)
        /// </summary>
        /// <returns></returns>
        public DateTime GetDate()
        {
            return _db.Database.SqlQuery<DateTime>("SELECT GETDATE()").First();
        }

        /// <summary>
        /// Dispose empty table and access to database
        /// </summary>
        public void Dispose()
        {
            _db.Dispose();
            _tb.Dispose();

            _db = null;
            _tb = null;
        }
    }
}