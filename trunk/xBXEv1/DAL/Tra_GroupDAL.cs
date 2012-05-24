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
        #region Implement
        public int Count()
        {
            return _db.Tra_Groups.Count();
        }

        public object Select(string code)
        {
            try
            {
                return _db.Tra_Groups.SingleOrDefault(s => s.Code == code);
            }
            catch { return null; }
        }

        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var res = from s in _db.Tra_Groups
                          select new
                          {
                              s.Id,
                              s.Name,
                              s.Descript,

                              s.Code,
                              s.Order,
                              s.Show
                          };

                if (obj != null) res = res.Where(s => s.Name == obj + "");
                if (take > 0) res = res.Skip(skip).Take(take);

                return res.ToDataTable();
            }
            catch { return _tb; }
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

        public object Update(object obj)
        {
            throw new NotImplementedException();
        }

        public object Delete(object obj = null)
        {
            try
            {
                if (obj != null)
                {
                    var res = _db.Tra_Groups.SingleOrDefault(s => s.Id == (Guid)obj);
                    _db.Tra_Groups.Remove(res);
                }
                else
                {
                    var tmp = _db.Tra_Groups.ToList();
                    tmp.ForEach(s => _db.Tra_Groups.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion
    }
}