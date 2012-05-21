using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using DAL.Entities;
    using System.Data.Entity;

    public abstract class BaseDAL
    {
        protected MyContext _db = new MyContext();

        public BaseDAL()
        {
            Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
        }
    }
}