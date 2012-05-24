using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;
    using Entities;

    /// <summary>
    /// Chính sách - Xử lí bảng Pol_Action
    /// </summary>
    public abstract class Pol_ActionDAL : BaseDAL, UTL.IBaseDAL
    {
        #region Implement
        public int Count()
        {
            return _db.Pol_Actions.Count();
        }

        public object Select(string code)
        {
            try
            {
                return _db.Pol_Actions.SingleOrDefault(s => s.Code == code);
            }
            catch { return null; }
        }

        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var res = from s in _db.Pol_Actions
                          select new
                          {
                              s.Id,
                              s.Code,
                              s.Name,
                              s.Descript
                          };

                if (obj != null) res = res.Where(s => s.Code == obj + "");
                if (take > 0) res = res.Skip(skip).Take(take);

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        public object Insert(object obj)
        {
            try
            {
                var o = (Pol_Action)obj;
                o.Id = Guid.NewGuid();
                var oki = _db.Pol_Actions.Add(o);

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
                    var res = _db.Pol_Actions.SingleOrDefault(s => s.Id == (Guid)obj);
                    _db.Pol_Actions.Remove(res);
                }
                else
                {
                    var tmp = _db.Pol_Actions.ToList();
                    tmp.ForEach(s => _db.Pol_Actions.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion
    }
}