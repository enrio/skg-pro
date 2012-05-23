using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;
    using Entities;

    /// <summary>
    /// Chính sách - Xử lí bảng Pol_UserRight
    /// </summary>
    public abstract class Pol_UserRightDAL : BaseDAL, UTL.IBaseDAL
    {
        public int Count()
        {
            return _db.Pol_UserRights.Count();
        }

        public DataTable Select()
        {
            try
            {
                var res = from s in _db.Pol_UserRights
                          select new
                          {
                              s.Pol_UserId,
                              s.Pol_RightId,
                              s.Add,
                              s.Edit,
                              s.Delete,
                              s.Query,
                              s.Print,
                              s.Full,
                              s.None
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
                var o = (Pol_UserRight)obj;
                var oki = _db.Pol_UserRights.Add(o);
                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        public object Update(object obj)
        {
            try
            {
                var o = (Pol_UserRight)obj;
                var res = _db.Pol_UserRights.SingleOrDefault(s => s.Pol_UserId == o.Pol_UserId && s.Pol_RightId == o.Pol_RightId);

                res.Add = o.Add;
                res.Edit = o.Edit;
                res.Delete = o.Delete;
                res.Query = o.Query;
                res.Print = o.Print;
                res.Full = o.Full;
                res.None = o.None;

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