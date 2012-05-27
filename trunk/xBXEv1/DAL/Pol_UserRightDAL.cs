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
        #region Implement
        public int Count()
        {
            return _db.Pol_UserRights.Count();
        }

        public object Select(string code)
        {
            throw new NotImplementedException();
        }

        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var a = from s in _db.Pol_UserRights
                        select new
                        {
                            ID = s.Id,
                            ParentID = s.Pol_Right.Id,

                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Query,
                            s.Print,
                            s.Full,
                            s.None,
                            s.Only,
                            Select = false,

                            UserName = s.Pol_User.Name
                        };

                var b = from s in _db.Pol_Rights
                        select new
                        {
                            ID = s.Id,
                            ParentID = s.Id,

                            Add = false,
                            Edit = false,
                            Delete = false,
                            Query = false,
                            Print = false,
                            Full = false,
                            None = false,
                            Only = false,
                            Select = false,

                            UserName = s.Name
                        };

                var res = a.Union(b);

                if (obj != null)
                {
                    var o = (Pol_UserRight)obj;
                    res = res.Where(s => s.ID == (Guid)obj);
                }

                if (take > 0) res = res.Skip(skip).Take(take);

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        public object Insert(object obj)
        {
            try
            {
                var o = (Pol_UserRight)obj;
                o.Id = Guid.NewGuid();
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
                var res = _db.Pol_UserRights.SingleOrDefault(s => s.Id == o.Id);

                //res.Pol_UserId = o.Pol_UserId;
                //res.Pol_RightId = o.Pol_RightId;
                res.Only = o.Only;

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

        public object Delete(object obj = null)
        {
            try
            {
                if (obj != null)
                {
                    var o = (Pol_UserRight)obj;
                    var res = _db.Pol_UserRights.SingleOrDefault(s => s.Id == (Guid)obj);
                    _db.Pol_UserRights.Remove(res);
                }
                else
                {
                    var tmp = _db.Pol_UserRights.ToList();
                    tmp.ForEach(s => _db.Pol_UserRights.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion
    }
}