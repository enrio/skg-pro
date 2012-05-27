﻿using System;
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
                var a = from s in _db.Pol_UserRights

                        join u in _db.Pol_Users on s.Pol_UserId equals u.Id
                        join r in _db.Pol_Rights on s.Pol_RightId equals r.Id

                        where s.Pol_UserId == userId
                        select new
                        {
                            RightCode = r.Code,
                            RightName = r.Name,
                            RightDescript = r.Descript,

                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Query,
                            s.Print,
                            s.Full,
                            s.None,
                            s.Only,
                        };

                var b = from s in _db.Pol_RoleRights

                        join r in _db.Pol_Rights on s.Pol_RightId equals r.Id
                        join ur in _db.Pol_UserRoles on s.Pol_RoleId equals ur.Pol_RoleId
                        join u in _db.Pol_Users on ur.Pol_UserId equals u.Id

                        where ur.Pol_User.Id == userId
                        select new
                        {
                            RightCode = r.Code,
                            RightName = r.Name,
                            RightDescript = r.Descript,

                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Query,
                            s.Print,
                            s.Full,
                            s.None,
                            s.Only,
                        };

                return a.Union(b).ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// Lấy quyền của người dùng đăng nhập trên form
        /// </summary>
        /// <param name="userId">Id người dùng đăng nhập</param>
        /// <param name="codeRight">Mã quyền (tên form)</param>
        /// <returns>Hành động</returns>
        public ZAction GetRights(Guid userId, string codeRight)
        {
            try
            {
                var a = from s in _db.Pol_UserRights

                        join u in _db.Pol_Users on s.Pol_UserId equals u.Id
                        join r in _db.Pol_Rights on s.Pol_RightId equals r.Id

                        where s.Pol_UserId == userId
                        select new
                        {
                            RightCode = r.Code,

                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Query,
                            s.Print,
                            s.Full,
                            s.None,
                            s.Only,
                        };

                var b = from s in _db.Pol_RoleRights

                        join r in _db.Pol_Rights on s.Pol_RightId equals r.Id
                        join ur in _db.Pol_UserRoles on s.Pol_RoleId equals ur.Pol_RoleId
                        join u in _db.Pol_Users on ur.Pol_UserId equals u.Id

                        where ur.Pol_User.Id == userId
                        select new
                        {
                            RightCode = r.Code,

                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Query,
                            s.Print,
                            s.Full,
                            s.None,
                            s.Only,
                        };

                var res = a.Union(b).SingleOrDefault(s => s.RightCode == codeRight);

                return new ZAction()
                {
                    Add = res.Add,
                    Edit = res.Edit,
                    Delete = res.Delete,
                    Query = res.Query,
                    Print = res.Print,
                    Full = res.Full,
                    None = res.None,
                    Only = res.Only
                };
            }
            catch { return null; }
        }
    }
}