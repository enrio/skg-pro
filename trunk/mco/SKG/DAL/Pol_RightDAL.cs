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
    using System.Data;

    /// <summary>
    /// Policy - Pol_Right processing
    /// </summary>
    public abstract class Pol_RightDAL : BaseDAL, IBase
    {
        #region Implement
        /// <summary>
        /// Count number of records
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _db.Pol_Rights.Count();
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
            try
            {
                return _db.Pol_Rights.SingleOrDefault(s => s.Code == code);
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
                var res = from s in _db.Pol_Rights
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              s.Code,
                              s.Caption,
                              s.Level,
                              s.Picture,
                              s.Descript,
                              s.Order,
                              s.Show
                          };
                if (obj != null) res = res.Where(s => s.Code == obj + "");
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
                var o = (Pol_Right)obj;
                if (Select(o.Code) != null) return null; // account already exists
                o.Id = Guid.NewGuid();
                var oki = _db.Pol_Rights.Add(o);

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
                var o = (Pol_Right)obj;
                var res = _db.Pol_Rights.SingleOrDefault(s => s.Id == o.Id);

                res.Pol_UserLangId = o.Pol_UserLangId;
                res.Caption = o.Caption;
                res.Level = o.Level;
                res.Picture = o.Picture;
                res.Code = o.Code;
                res.Descript = o.Descript;
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
                    var res = _db.Pol_Rights.SingleOrDefault(s => s.Id == id);
                    _db.Pol_Rights.Remove(res);
                }
                else
                {
                    var tmp = _db.Pol_Rights.ToList();
                    tmp.ForEach(s => _db.Pol_Rights.Remove(s));
                }
                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion
    }
}