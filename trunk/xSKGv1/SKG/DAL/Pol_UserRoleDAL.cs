#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 22:20
 * Update: 24/07/2012 22:48
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
    using System.Data;

    /// <summary>
    /// Policy - Pol_UserRole processing
    /// </summary>
    public abstract class Pol_UserRoleDAL : BaseDAL, IBase
    {
        #region Implement
        /// <summary>
        /// Count number of records
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _db.Pol_UserRoles.Count();
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
        /// Select object of entity by secondary primary key (when need to)
        /// </summary>
        /// <param name="code">Primary key (when need to)</param>
        /// <returns></returns>
        public object Select(string code)
        {
            throw new NotImplementedException();
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
                var a = from s in _db.Pol_UserRoles
                        select new
                        {
                            ID = s.Id,
                            ParentID = s.Pol_Role.Id,
                            UserId = s.Pol_UserId,
                            Format = false,
                            Name = s.Pol_User.Name,
                            Descript = s.Pol_User.Acc,
                        };
                Guid? id = new Guid();
                var b = from s in _db.Pol_Dictionarys
                        where s.Type == Global.STR_ROLE
                        select new
                        {
                            ID = s.Id,
                            ParentID = s.Id,
                            UserId = id,
                            Format = true,
                            Name = s.Text,
                            Descript = s.Note
                        };
                var res = a.Union(b);
                if (obj != null)
                {
                    var o = (Pol_UserRole)obj;
                    res = res.Where(s => s.ID == o.Id);
                }
                if (take > 0) res = res.Skip(skip).Take(take);
                return res.OrderBy(s => s.Name).ToDataTable();
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
                var o = (Pol_UserRole)obj;
                o.Id = Guid.NewGuid();
                var oki = _db.Pol_UserRoles.Add(o);
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
                var o = (Pol_UserRole)obj;
                var res = _db.Pol_UserRoles.SingleOrDefault(s => s.Id == o.Id);

                res.Pol_UserId = o.Pol_UserId;
                res.Pol_RoleId = o.Pol_RoleId;
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
                    var res = _db.Pol_UserRoles.SingleOrDefault(s => s.Id == id);
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