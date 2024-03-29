﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 09/08/2013 20:32
 * Update: 01/06/2013 05:58
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace SKG.DAL
{
    using Entities;
    using SKG.Extend;

    /// <summary>
    /// Policy - Pol_Dictionary accessing
    /// </summary>
    public abstract class Pol_DictionaryDAL : BaseDAL, IBase
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
            return _db.Pol_Dictionarys.Count();
        }

        /// <summary>
        /// Return data by foreign key
        /// </summary>
        /// <param name="fKey">Foreign key on this table</param>
        /// <returns></returns>
        public DataTable Select(Guid fKey)
        {
            try
            {
                var res = from s in _db.Pol_Dictionarys
                          where s.ParentId == fKey
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              s.ParentId,
                              s.Code,
                              s.Type,
                              s.Text,
                              s.Note,
                              s.More,
                              s.Text1,
                              s.Note1,
                              s.More1,
                              s.Text2,
                              s.Note2,
                              s.More2,
                              s.Text3,
                              s.Note3,
                              s.More3,
                              s.Order,
                              s.Show
                          };

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// Select object of entity by primary key handmade
        /// </summary>
        /// <param name="code">Primary key (when need to)</param>
        /// <returns></returns>
        public object Select(string code)
        {
            try
            {
                if (Global.Setting) return null;

                var gui = new Guid();
                var ok = Guid.TryParse(code, out gui);

                if (ok) return _db.Pol_Dictionarys.FirstOrDefault(s => s.Id == gui);
                return _db.Pol_Dictionarys.FirstOrDefault(s => s.Code == code);
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
                var res = from s in _db.Pol_Dictionarys
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              s.ParentId,
                              s.Code,
                              s.Type,
                              s.Text,
                              s.Note,
                              s.More,
                              s.Text1,
                              s.Note1,
                              s.More1,
                              s.Text2,
                              s.Note2,
                              s.More2,
                              s.Text3,
                              s.Note3,
                              s.More3,
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
            var o = new Pol_Dictionary();
            try
            {
                o = (Pol_Dictionary)obj;

                if (Select(o.Code) != null)
                    return null; // already exists

                if (o.Id == Guid.Empty)
                    o.Id = Guid.NewGuid();

                var oki = _db.Pol_Dictionarys.Add(o);
                _db.SaveChanges();

                return oki;
            }
            catch
            {
                _db.Pol_Dictionarys.Remove(o);

                return null;
            }
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
                var o = (Pol_Dictionary)obj;

                var c = _db.Pol_Dictionarys.Where(p => p.Code == o.Code && p.Id != o.Id).Count();
                if (c > 0) return null; // already exists

                var res = _db.Pol_Dictionarys.SingleOrDefault(s => s.Id == o.Id);

                res.ParentId = o.ParentId;
                res.Code = o.Code;
                res.Type = o.Type;
                res.Text = o.Text;
                res.Note = o.Note;
                res.More = o.More;
                res.Text1 = o.Text1;
                res.Note1 = o.Note1;
                res.More1 = o.More1;
                res.Text2 = o.Text2;
                res.Note2 = o.Note2;
                res.More2 = o.More2;
                res.Text3 = o.Text3;
                res.Note3 = o.Note3;
                res.More3 = o.More3;
                res.Order = o.Order;
                res.Show = o.Show;

                return _db.SaveChanges();
            }
            catch { return null; }
        }

        /// <summary>
        /// Update data More field by Code field
        /// </summary>
        /// <param name="c">Code field</param>
        /// <param name="m">More field</param>
        /// <returns></returns>
        public object UpdateMoreByCode(string c, string m)
        {
            try
            {
                var res = _db.Pol_Dictionarys.SingleOrDefault(s => s.Code == c);
                res.More = m;

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
                    var res = _db.Pol_Dictionarys.SingleOrDefault(s => s.Id == id);
                    _db.Pol_Dictionarys.Remove(res);
                }
                else
                {
                    var tmp = _db.Pol_Dictionarys.ToList();
                    tmp.ForEach(s => _db.Pol_Dictionarys.Remove(s));
                }
                return _db.SaveChanges();
            }
            catch { return null; }
        }
        #endregion

        /// <summary>
        /// Select data by Type field
        /// </summary>
        /// <param name="t">Type of data</param>
        /// <returns></returns>
        public DataTable Select(object t)
        {
            try
            {
                var a = t + "";
                var res = from s in _db.Pol_Dictionarys
                          where s.Type == a
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              s.ParentId,
                              Belong = s.Parent.Text,
                              s.Code,
                              s.Type,
                              s.Text,
                              s.Note,
                              s.More,
                              s.Text1,
                              s.Note1,
                              s.More1,
                              s.Text2,
                              s.Note2,
                              s.More2,
                              s.Text3,
                              s.Note3,
                              s.More3,
                              s.Order,
                              s.Show
                          };

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// List for vehicle fixed
        /// </summary>
        /// <returns></returns>
        public DataTable SelectForFixed()
        {
            try
            {
                var res = from s in _db.Pol_Dictionarys
                          where s.Type == "ROOT" && s.Show == true
                          && s.Code != "ROLE" && s.Code != "GROUP"
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              s.ParentId,
                              Belong = s.Parent.Text,
                              s.Code,
                              s.Type,
                              s.Text,
                              s.Note,
                              s.More,
                              s.Text1,
                              s.Note1,
                              s.More1,
                              s.Text2,
                              s.Note2,
                              s.More2,
                              s.Text3,
                              s.Note3,
                              s.More3,
                              s.Order,
                              s.Show
                          };

                return res.ToDataTable();
            }
            catch { return _tb; }
        }

        /// <summary>
        /// Select data by More field
        /// </summary>
        /// <param name="c">Key of data</param>
        /// <param name="t">Type of data</param>
        /// <returns></returns>
        public DataTable SelectByMore(string c, string t)
        {
            try
            {
                var res = from s in _db.Pol_Dictionarys
                          where s.More == c && s.Type == t
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              s.ParentId,
                              Belong = s.Parent.Text,
                              s.Code,
                              s.Type,
                              s.Text,
                              s.Note,
                              s.More,
                              s.Text1,
                              s.Note1,
                              s.More1,
                              s.Text2,
                              s.Note2,
                              s.More2,
                              s.Text3,
                              s.Note3,
                              s.More3,
                              s.Order,
                              s.Show
                          };

                return res.ToDataTable();
            }
            catch { return _tb; }
        }
    }
}