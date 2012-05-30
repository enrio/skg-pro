using System;
using System.Collections.Generic;
using System.Linq;

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

        public DataTable Select(Guid fKey)
        {
            throw new NotImplementedException();
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
                            ParentID = s.Pol_User.Id,
                            RightId = s.Pol_RightId,
                            Format = false,

                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Query,
                            s.Print,
                            s.Access,
                            s.Default,
                            s.Full,
                            s.None,

                            Name = s.Pol_Right.Name,
                            Descript = s.Pol_Right.Descript,
                        };

                Guid? id = new Guid();

                var b = from s in _db.Pol_Users
                        select new
                        {
                            ID = s.Id,
                            ParentID = s.Id,
                            RightId = id,
                            Format = true,

                            Add = false,
                            Edit = false,
                            Delete = false,
                            Query = false,
                            Print = false,
                            Access = false,
                            Default = false,
                            Full = false,
                            None = false,

                            s.Name,
                            s.Descript
                        };

                var res = a.Union(b);

                if (obj != null)
                {
                    var o = (Pol_UserRight)obj;
                    res = res.Where(s => s.ID == o.Id);
                }

                if (take > 0) res = res.Skip(skip).Take(take);

                return res.OrderBy(s => s.Name).ToDataTable();
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

                res.Add = o.Add;
                res.Edit = o.Edit;
                res.Delete = o.Delete;
                res.Query = o.Query;
                res.Print = o.Print;
                res.Access = o.Access;
                res.Default = o.Default;
                res.Full = o.Full;
                res.None = o.None;

                return _db.SaveChanges();
            }
            catch { return null; }
        }

        public object Delete(Guid id = new Guid())
        {
            try
            {
                if (id != new Guid())
                {
                    var res = _db.Pol_UserRights.SingleOrDefault(s => s.Id == id);
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