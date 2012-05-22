using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;
    using Entities;

    /// <summary>
    /// Vận tải - Xử lí bảng Tra_Group
    /// </summary>
    public abstract class Tra_GroupDAL : BaseDAL, UTL.IBaseDAL
    {
        public int Count()
        {
            return _db.Tra_Groups.Count();
        }

        public DataTable Select()
        {
            try
            {
                var res = from s in _db.Tra_Groups
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
                var o = (Tra_Group)obj;
                o.Id = Guid.NewGuid();
                var oki = _db.Tra_Groups.Add(o);
                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        public object Update(Guid id)
        {
            throw new NotImplementedException();
        }

        public object Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}