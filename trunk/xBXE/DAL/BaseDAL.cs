using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        protected MyContext _db = new MyContext();

        public BaseDAL()
        {
            Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
        }
    }
}