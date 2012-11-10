#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 22:20
 * Update: 24/07/2012 22:20
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL
{
    using Entities;
    using SKG.Extend;
    using SKG.Hasher;
    using System.Data;

    /// <summary>
    /// Policy - Pol_User processing
    /// </summary>
    public abstract class Pol_UserDAL : BaseDAL, IBase
    {
        #region Implement
        /// <summary>
        /// Count number of records
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _db.Pol_Users.Count();
        }

        /// <summary>
        /// Return data by foreign key
        /// </summary>
        /// <param name="fKey">Foreign key on this table</param>
        /// <returns></returns>
        public DataTable Select(Guid fKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Select user by account
        /// </summary>
        /// <param name="code">User's account</param>
        /// <returns></returns>
        public object Select(string code)
        {
            try
            {
                return _db.Pol_Users.SingleOrDefault(s => s.Acc == code);
            }
            catch { return null; }
        }

        /// <summary>
        /// Return data
        /// </summary>
        /// <param name="obj">Object of entity</param>
        /// <param name="skip">Skip number of records</param>
        /// <param name="take">Take number of records</param>
        /// <returns></returns>
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

        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="obj">Object of entity</param>
        /// <returns></returns>
        public object Insert(object obj)
        {
            try
            {
                var o = (Pol_User)obj;
                if (Select(o.Acc) != null) return null; // account already exists
                o.Id = Guid.NewGuid();
                o.Pass = Coder.Encode(o.Pass);
                var oki = _db.Pol_Users.Add(o);

                _db.SaveChanges();
                return oki;
            }
            catch { return null; }
        }

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="obj">Object of entity</param>
        /// <returns></returns>
        public object Update(object obj)
        {
            try
            {
                var o = (Pol_User)obj;
                var res = _db.Pol_Users.SingleOrDefault(s => s.Id == o.Id || s.Acc == o.Acc);

                res.Pass = Coder.Encode(o.Pass);
                res.Name = o.Name;
                res.Birth = o.Birth;
                res.Address = o.Address;
                res.Phone = o.Phone;
                res.Code = o.Code;
                res.Note = o.Note;
                res.Order = o.Order;
                res.Show = o.Show;
                return _db.SaveChanges();
            }
            catch { return null; }
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns></returns>
        public object Delete(Guid id = new Guid())
        {
            try
            {
                if (id != new Guid())
                {
                    var res = _db.Pol_Users.SingleOrDefault(s => s.Id == id);
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
        /// Get all user's rights
        /// </summary>
        /// <param name="userId">User's Id</param>
        /// <returns></returns>
        public List<Zaction> GetRights(Guid userId)
        {
            try
            {
                var a = from s in _db.Pol_UserRights
                        join u in _db.Pol_Users on s.UserId equals u.Id
                        join r in _db.Pol_Dictionarys on s.RightId equals r.Id
                        where s.UserId == userId
                        select new
                        {
                            RightCode = r.Code,
                            RightName = r.Text,
                            RightDescript = r.Note,
                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Default,
                            s.Print,
                            s.Access,
                            s.Full,
                            s.None
                        };
                var b = from s in _db.Pol_RoleRights
                        join r in _db.Pol_Dictionarys on s.RightId equals r.Id
                        join ur in _db.Pol_UserRoles on s.RoleId equals ur.RoleId
                        join u in _db.Pol_Users on ur.UserId equals u.Id
                        where ur.User.Id == userId
                        select new
                        {
                            RightCode = r.Code,
                            RightName = r.Text,
                            RightDescript = r.Note,
                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Default,
                            s.Print,
                            s.Access,
                            s.Full,
                            s.None
                        };
                var tmp = a.Union(b);
                var lst = new List<Zaction>();
                foreach (var res in tmp)
                {
                    var z = new Zaction()
                    {
                        Code = res.RightCode,
                        Add = res.Add,
                        Edit = res.Edit,
                        Delete = res.Delete,
                        Default = res.Default,
                        Print = res.Print,
                        Access = res.Access,
                        Full = res.Full,
                        None = res.None
                    };
                    lst.Add(z);
                }
                return lst;
            }
            catch { return null; }
        }

        /// <summary>
        /// Get all user's roles
        /// </summary>
        /// <param name="userId">User's Id</param>
        /// <returns></returns>
        public List<Pol_Dictionary> GetRoles(Guid userId)
        {
            try
            {
                var a = from s in _db.Pol_UserRoles
                        join r in _db.Pol_Dictionarys on s.RoleId equals r.Id
                        where s.UserId == userId
                        select r;
                return a.ToList();
            }
            catch { return null; }
        }
    }
}