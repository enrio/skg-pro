using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;
    using Entities;

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
            try
            {
                var res = from s in _db.Pol_Roles
                          select new
                          {
                              s.Id,
                              s.Name,
                              s.Descript
                          };
                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        public DataTable Select(Guid id, bool isFkey = false)
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
            try
            {
                var o = (Pol_Role)obj;
                o.Id = Guid.NewGuid();
                var oki = _db.Pol_Roles.Add(o);
                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        public object Update(object obj)
        {
            throw new NotImplementedException();
        }

        public object Delete(Guid id)
        {
            try
            {
                var res = _db.Pol_Roles.SingleOrDefault(s => s.Id == id);
                _db.Pol_Roles.Remove(res);

                return _db.SaveChanges();
            }
            catch { return null; }
        }
    }
}