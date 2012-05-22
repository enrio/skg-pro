using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using Entities;
    using System.Data;
    using System.Data.Entity;

    /// <summary>
    /// Base abstract class Data Access Layer
    /// </summary>
    public abstract class BaseDAL
    {
        protected Context _db = new Context();
        protected DataTable _tb = new DataTable("Tmp");

        public BaseDAL()
        {
            Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }
    }
}