using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;
    using Entities;

    /// <summary>
    /// Chính sách - Xử lí bảng Pol_UserRole
    /// </summary>
    public abstract class Pol_UserRoleDAL : BaseDAL, UTL.IBaseDAL
    {
        #region Implement
        public int Count()
        {
            return _db.Pol_UserRoles.Count();
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
                            CodeRight = s.Pol_Right.Code,
                            CodeRole = s.Pol_Role.Code,

                            ID = s.Pol_Right.Code + s.Pol_Role.Code,
                            ParentID = s.Pol_Right.Code,

                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Query,
                            s.Print,
                            s.Full,
                            s.None,

                            RoleName = s.Pol_Role.Name,
                            RoleDescript = s.Pol_Role.Descript
                        };

                var b = from s in _db.Pol_Rights
                        select new
                        {
                            CodeRight = s.Code,
                            CodeRole = "",

                            ID = s.Code + "",
                            ParentID = s.Code,

                            Add = false,
                            Edit = false,
                            Delete = false,
                            Query = false,
                            Print = false,
                            Full = false,
                            None = false,

                            RoleName = s.Name,
                            RoleDescript = s.Descript
                        };

                var res = a.Union(b);

                if (obj != null)
                {
                    var o = (Pol_UserRole)obj;
                    //res = res.Where(s => s.Pol_UserId == o.Pol_UserId && s.Pol_RoleId == o.Pol_RoleId);
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
                var o = (Pol_UserRole)obj;
                var oki = _db.Pol_UserRoles.Add(o);

                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        public object Update(object obj)
        {
            try
            {
                var o = (Pol_UserRole)obj;
                var res = _db.Pol_UserRoles.SingleOrDefault(s => s.Pol_UserId == o.Pol_UserId && s.Pol_RoleId == o.Pol_RoleId);

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
                    var o = (Pol_UserRole)obj;
                    var res = _db.Pol_UserRoles.SingleOrDefault(s => s.Pol_UserId == o.Pol_UserId && s.Pol_RoleId == o.Pol_RoleId);
                    _db.Pol_UserRoles.Remove(res);
                }
                else
                {
                    var tmp = _db.Pol_UserRoles.ToList();
                    tmp.ForEach(s => _db.Pol_UserRoles.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion
    }
}