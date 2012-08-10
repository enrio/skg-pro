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

namespace SKG.BLL
{
    using System.Data;
    using DAL.Entities;

    /// <summary>
    /// Policy - Pol_Dictionary accessing
    /// </summary>
    public sealed class Pol_DictionaryBLL : DAL.Pol_DictionaryDAL
    {
        #region Select
        /// <summary>
        /// Select all languages
        /// </summary>
        /// <returns></returns>
        public DataTable SelectLangs()
        {
            return Select((object)Global.STR_LANG);
        }

        /// <summary>
        /// Select all buttons
        /// </summary>
        /// <returns></returns>
        public DataTable SelectButtons()
        {
            return Select((object)Global.STR_BUTTON);
        }

        /// <summary>
        /// Select all roles
        /// </summary>
        /// <returns></returns>
        public DataTable SelectRoles()
        {
            return Select((object)Global.STR_ROLE);
        }

        /// <summary>
        /// Select all rights
        /// </summary>
        /// <returns></returns>
        public DataTable SelectRights()
        {
            return Select((object)Global.STR_RIGHT);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertLang(Pol_Dictionary o)
        {
            o.Type = Global.STR_LANG;
            return Insert(o);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertButton(Pol_Dictionary o)
        {
            o.Type = Global.STR_BUTTON;
            return Insert(o);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertRole(Pol_Dictionary o)
        {
            o.Type = Global.STR_ROLE;
            return Insert(o);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public object InsertRight(Pol_Dictionary o)
        {
            o.Type = Global.STR_RIGHT;
            return Insert(o);
        }

        /// <summary>
        /// Add menuz (right) data
        /// </summary>
        /// <param name="code">Primary key handmade</param>
        /// <param name="text">Content is shown</param>
        /// <param name="note">Descriptive detailing</param>
        /// <returns></returns>
        public object Insert(string code, string text, string note)
        {
            var o = new Pol_Dictionary() { Code = code, Text = text, Note = note };
            return InsertRight(o);
        }
        #endregion

        #region Update
        #endregion
    }
}