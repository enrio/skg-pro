#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 22:52
 * Update: 24/07/2012 22:52
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
    /// Policy - Pol_UserRight processing
    /// </summary>
    public abstract class Pol_UserRightDAL : BaseDAL, IBase
    {
        #region Implement
        /// <summary>
        /// Count number of records
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _db.Pol_UserRights.Count();
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
                            s.Default,
                            s.Print,
                            s.Access,
                            s.Full,
                            s.None,
                            Name = s.Pol_Right.Text,
                            Descript = s.Pol_Right.Note,
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
                            Default = false,
                            Print = false,
                            Access = false,
                            Full = false,
                            None = false,
                            s.Name,
                            Descript = s.Note
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

        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="obj">Object of entity</param>
        /// <returns></returns>
        public object Insert(object obj)
        {
            try
            {
                var o = (Pol_UserRight)obj;
                o.Id = Guid.NewGuid();

                var r = _db.Pol_Rights
                    .Where(s => s.Id == o.Pol_RightId)
                    .FirstOrDefault();
                o.Code = r.Code;
                o.Note = r.Note;
                var oki = _db.Pol_UserRights.Add(o);
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
                var o = (Pol_UserRight)obj;
                var res = _db.Pol_UserRights.SingleOrDefault(s => s.Id == o.Id);

                res.Add = o.Add;
                res.Edit = o.Edit;
                res.Delete = o.Delete;
                res.Default = o.Default;
                res.Print = o.Print;
                res.Access = o.Access;
                res.Full = o.Full;
                res.None = o.None;
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