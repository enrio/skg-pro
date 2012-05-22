using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;

    /// <summary>
    /// Chính sách - Xử lí bảng Pol_Role
    /// </summary>
    public abstract class Pol_RoleDAL : BaseDAL, UTL.IBaseDAL
    {
        public int Count()
        {
            return _db.Pol_Roles.Count();
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public DataTable Select(object obj)
        {
            throw new NotImplementedException();
        }

        public DataTable Select(int take, int skip)
        {
            throw new NotImplementedException();
        }

        public DataTable Select(int skip, int take, object obj)
        {
            throw new NotImplementedException();
        }

        public object Insert(object obj)
        {
            throw new NotImplementedException();
        }

        public object Update(object obj)
        {
            throw new NotImplementedException();
        }

        public object Delete(object obj)
        {
            throw new NotImplementedException();
        }
    }
}