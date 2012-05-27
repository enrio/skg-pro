using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;
    using Entities;

    /// <summary>
    /// Chính sách - Xử lí bảng Pol_RoleRight
    /// </summary>
    public abstract class Pol_RoleRightDAL : BaseDAL, UTL.IBaseDAL
    {
        #region Implement
        public int Count()
        {
            return _db.Pol_RoleRights.Count();
        }

        public object Select(string code)
        {
            throw new NotImplementedException();
        }

        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var a = from s in _db.Pol_RoleRights
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

                            RoleName = s.Pol_Role.Name,
                            RoleDescript = s.Pol_Role.Descript
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

                            RoleName = s.Name,
                            RoleDescript = s.Descript
                        };

                var res = a.Union(b);

                if (obj != null)
                {
                    var o = (Pol_RoleRight)obj;
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
                var o = (Pol_RoleRight)obj;
                o.Id = Guid.NewGuid();
                var oki = _db.Pol_RoleRights.Add(o);

                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        public object Update(object obj)
        {
            try
            {
                var o = (Pol_RoleRight)obj;
                var res = _db.Pol_RoleRights.SingleOrDefault(s => s.Id == (Guid)obj);

                res.Pol_RoleId = o.Pol_RoleId;
                res.Pol_RightId = o.Pol_RightId;
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
                    var o = (Pol_RoleRight)obj;
                    var res = _db.Pol_RoleRights.SingleOrDefault(s => s.Id == (Guid)obj);
                    _db.Pol_RoleRights.Remove(res);
                }
                else
                {
                    var tmp = _db.Pol_RoleRights.ToList();
                    tmp.ForEach(s => _db.Pol_RoleRights.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion
    }
}