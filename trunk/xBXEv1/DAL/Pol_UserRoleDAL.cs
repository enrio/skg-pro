﻿using System;
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
                              s.Pol_UserId,
                              s.Pol_RoleId,
                              s.Add,
                              s.Edit,
                              s.Delete,
                              s.Query,
                              s.Print,
                              s.Full,
                              s.None,
                              Code = s.Pol_Role.Code,
                              UserName = s.Pol_User.Name,
                              UserBirth = s.Pol_User.Birth,
                              RoleName = s.Pol_Role.Name,
                              RoleDescript = s.Pol_Role.Descript
                          };


                if (obj != null)
                {
                    var o = (Pol_UserRole)obj;
                    res = res.Where(s => s.Pol_UserId == o.Pol_UserId && s.Pol_RoleId == o.Pol_RoleId);
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

        public DataTable GetForRole()
        {
            try
            {
                var tmp = Select();
                var id = Guid.NewGuid();

                var res = from s in _db.Pol_Roles
                          select new
                          {
                              Pol_UserId = s.Id,
                              Pol_RoleId = id,
                              Add = false,
                              Edit = false,
                              Delete = false,
                              Query = false,
                              Print = false,
                              Full = false,
                              None = false,
                              s.Code,
                              UserName = "",
                              UserBirth = DateTime.Now,
                              RoleName = s.Name,
                              RoleDescript = s.Descript
                          };

                tmp.Merge(res.ToDataTable());
                return tmp;
            }
            catch { return _tb; }
        }
    }
}