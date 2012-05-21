using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    using System.Data.Entity;

    /// <summary>
    /// Base abstract class Data Access Layer
    /// </summary>
    public abstract class BaseDAL
    {
        /// <summary>
        /// All perform status of DAL
        /// </summary>
        public enum State { Empty, Duplicate, Uninsert, Unupdate, Undelete, Unfind, Success }

        protected Context _db = new Context();

        public BaseDAL()
        {
            Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }
    }
}