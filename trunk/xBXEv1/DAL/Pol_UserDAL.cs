using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    using System.Data;
    using Entities;

    /// <summary>
    /// Chính sách - Xử lí bảng Pol_User
    /// </summary>
    public abstract class Pol_UserDAL : BaseDAL, UTL.IBaseDAL
    {
        #region Implement
        public int Count()
        {
            return _db.Pol_Users.Count();
        }

        public object Select(string code)
        {
            try
            {
                return _db.Pol_Users.SingleOrDefault(s => s.Acc == code);
            }
            catch { return null; }
        }

        public DataTable Select(object obj = null, int skip = 0, int take = 0)
        {
            try
            {
                var res = from s in _db.Pol_Users
                          select new
                          {
                              s.Id,
                              s.Acc,
                              s.Pass,
                              s.Name,
                              s.Birth,
                              s.Address,
                              s.Phone
                          };

                if (obj != null) res = res.Where(s => s.Acc == obj + "");
                if (take > 0) res = res.Skip(skip).Take(take);

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        public object Insert(object obj)
        {
            try
            {
                var o = (Pol_User)obj;
                o.Id = Guid.NewGuid();
                o.Pass = UTL.Hasher.Code.Encode(o.Pass);
                var oki = _db.Pol_Users.Add(o);

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
                    var res = _db.Pol_Users.SingleOrDefault(s => s.Id == (Guid)obj);
                    _db.Pol_Users.Remove(res);
                }
                else
                {
                    var tmp = _db.Pol_Users.ToList();
                    tmp.ForEach(s => _db.Pol_Users.Remove(s));
                }

                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion

        /// <summary>
        /// Lấy thông tin người dùng đăng nhập thông qua tài khoản
        /// </summary>
        /// <param name="acc">Tài khoản đăng nhập</param>
        /// <returns>Thông tin người dùng</returns>
        protected Pol_User GetPass(string acc)
        {
            try
            {
                return _db.Pol_Users.SingleOrDefault(s => s.Acc == acc);
            }
            catch { return null; }
        }

        /// <summary>
        /// Lấy tất cả các quyền (chức năng) của người dùng
        /// </summary>
        /// <param name="userId">Id người dùng đăng nhập</param>
        /// <returns>Danh sách các quyền (chức năng)</returns>
        public DataTable GetRights(Guid userId)
        {
            try
            {
                var res = from s in _db.Pol_UserRoles
                          where s.Pol_User.Id == userId
                          select new
                          {
                              UserId = s.Pol_User.Id,
                              UserAcc = s.Pol_User.Acc,
                              UserName = s.Pol_User.Name,

                              RoleId = s.Pol_Role.Id,
                              RoleCode = s.Pol_Role.Code,
                              RoleName = s.Pol_Role.Name
                          };

                return res.ToDataTable();
            }
            catch { return _tb; }
        }
    }
}