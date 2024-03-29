﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 22:20
 * Update: 12/06/2013 12:38
 * Status: OK
 */
#endregion

using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace SKG.DAL
{
    using Entities;
    using SKG.Extend;

    /// <summary>
    /// Policy - Pol_RoleRight processing
    /// </summary>
    public abstract class Pol_RoleRightDAL : BaseDAL, IBase
    {
        #region Implement
        /// <summary>
        /// Auto generate code
        /// </summary>
        /// <param name="format">Format code</param>
        /// <returns></returns>
        public string GenerateCode(string format)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Count number of records
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _db.Pol_RoleRights.Count();
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
                var a = from s in _db.Pol_RoleRights
                        select new
                        {
                            xID = s.Id,
                            xParentID = s.Role.Id,

                            ID = s.Right.Id,
                            ParentID = s.Right.Parent.Id == null ? s.Role.Id : s.Right.Parent.Id,

                            RightId = s.RightId,
                            Format = false,
                            s.Add,
                            s.Edit,
                            s.Delete,
                            s.Default,
                            s.Print,
                            s.Access,
                            s.Full,
                            s.None,
                            Name = s.Right.Text,
                            Descript = s.Right.Note,
                        };
                Guid? id = new Guid();
                var b = from s in _db.Pol_Dictionarys
                        where s.Type == Global.STR_ROLE
                        select new
                        {
                            xID = s.Id,
                            xParentID = s.Id,

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
                            Name = s.Text,
                            Descript = s.Note
                        };
                var res = a.Union(b);
                if (obj != null)
                {
                    var o = (Pol_RoleRight)obj;
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
                var o = (Pol_RoleRight)obj;
                o.Id = Guid.NewGuid();
                var r = _db.Pol_Dictionarys
                    .Where(s => s.Id == o.RightId)
                    .FirstOrDefault();
                o.Code = r.Code;
                o.Note = r.Note;

                var oki = _db.Pol_RoleRights.Add(o);
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
                var o = (Pol_RoleRight)obj;
                var res = _db.Pol_RoleRights.SingleOrDefault(s => s.Id == o.Id);

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
                    var res = _db.Pol_RoleRights.SingleOrDefault(s => s.Id == id);
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