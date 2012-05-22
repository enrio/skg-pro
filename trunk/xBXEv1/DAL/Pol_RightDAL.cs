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
            try
            {
                var res = from s in _db.Pol_Rights
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
                var o = (Pol_Right)obj;
                o.Id = Guid.NewGuid();
                var oki = _db.Pol_Rights.Add(o);
                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        public object Update(object obj)
        {
            try
            {
                var o = (Pol_Right)obj;
                var res = _db.Pol_Rights.SingleOrDefault(s => s.Id == o.Id);

                res.Name = o.Name;
                res.Descript = o.Descript;

                return _db.SaveChanges();
            }
            catch { return null; }
        }

        public object Delete(Guid id)
        {
            try
            {
                var res = _db.Pol_Rights.SingleOrDefault(s => s.Id == id);
                _db.Pol_Rights.Remove(res);

                return _db.SaveChanges();
            }
            catch { return null; }
        }
    }
}