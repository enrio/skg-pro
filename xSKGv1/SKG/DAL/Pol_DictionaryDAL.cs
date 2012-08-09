#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 09/08/2013 20:32
 * Update: 09/08/2013 20:32
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
    /// Policy - Pol_Dictionary accessing
    /// </summary>
    public abstract class Pol_DictionaryDAL : BaseDAL, IBase
    {
        #region Implement
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
            throw new NotImplementedException();
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
                return _db.Pol_Dictionarys.SingleOrDefault(s => s.Code == code);
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
                              s.Code,
                              s.Text,
                              s.Type,
                              s.Text1,
                              s.Text2,
                              s.Text3,
                              Descript = s.Note,
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
                var o = (Pol_Dictionary)obj;
                if (Select(o.Code) != null) return null; // already exists
                o.Id = Guid.NewGuid();
                var oki = _db.Pol_Dictionarys.Add(o);

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
                var o = (Pol_Dictionary)obj;
                var res = _db.Pol_Dictionarys.SingleOrDefault(s => s.Id == o.Id);

                res.Text = o.Text;
                res.Type = o.Type;
                res.Text1 = o.Text1;
                res.Text2 = o.Text2;
                res.Text3 = o.Text3;
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
        /// Select by type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public DataTable Select(object type)
        {
            try
            {
                var a = type + "";
                var res = from s in _db.Pol_Dictionarys
                          where s.Type == a
                          orderby s.Order
                          select new
                          {
                              s.Id,
                              s.Code,
                              s.Text,
                              s.Type,
                              s.Text1,
                              s.Text2,
                              s.Text3,
                              Descript = s.Note,
                              s.Order,
                              s.Show
                          };
                return res.ToDataTable();
            }
            catch { return _tb; }
        }
    }
}