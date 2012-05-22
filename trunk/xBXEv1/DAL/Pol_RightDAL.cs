using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;
    using Entities;

    /// <summary>
    /// Chính sách - Xử lí bảng Pol_Right
    /// </summary>
    public abstract class Pol_RightDAL : BaseDAL, UTL.IBaseDAL
    {
        public int Count()
        {
            return _db.Pol_Rights.Count();
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public DataTable Select(object obj)
        {
            throw new NotImplementedException();
        }

        public DataTable Select(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public DataTable Select(int skip, int take, object obj)
        {
            throw new NotImplementedException();
        }

        public object Insert(object obj)
        {
            var o = (Pol_Right)obj;
            try
            {
                o.Id = Guid.NewGuid();
                return _db.Pol_Rights.Add(o);
            }
            catch { return null; }
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