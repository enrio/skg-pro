using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;

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
                              s.Name
                          };
                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        public DataTable Select(object obj)
        {
            throw new NotImplementedException();
        }

        public DataTable Select(int skip, int take)
        {
            try
            {
                var res = from s in _db.Tra_Groups
                          select new
                          {
                              s.Id,
                              s.Name
                          };
                return res.Skip(skip).Take(take).ToDataTable();
            }
            catch { return _tb; }
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