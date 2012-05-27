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
                var res = from s in _db.Pol_UserRoles
                          select new
                          {
                              UserId = s.Pol_User.Id,
                              RoleId = s.Pol_Role.Id
                          };

                if (obj != null)
                {
                    var o = (Pol_UserRole)obj;
                    res = res.Where(s => s.UserId == o.Pol_UserId && s.RoleId == o.Pol_RoleId);
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
                o.Id = Guid.NewGuid();
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
                var res = _db.Pol_UserRoles.SingleOrDefault(s => s.Id == o.Id);

                res.Pol_UserId = o.Pol_UserId;
                res.Pol_RoleId = o.Pol_RoleId;

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
                    var res = _db.Pol_UserRoles.SingleOrDefault(s => s.Id == (Guid)obj);
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