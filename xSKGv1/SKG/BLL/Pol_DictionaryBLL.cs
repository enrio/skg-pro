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

    /// <summary>
    /// Policy - Pol_Dictionary accessing
    /// </summary>
    public sealed class Pol_DictionaryBLL : DAL.Pol_DictionaryDAL
    {
        /// <summary>
        /// Select all menuzs
        /// </summary>
        /// <returns></returns>
        public DataTable SelectMenuzs()
        {
            return Select((object)Global.STR_MENUZ);
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
        /// Select all languages
        /// </summary>
        /// <returns></returns>
        public DataTable SelectLangs()
        {
            return Select((object)Global.STR_LANG);
        }

        /// <summary>
        /// Select all roles
        /// </summary>
        /// <returns></returns>
        public DataTable SelectRoles()
        {
            return Select((object)Global.STR_ROLE);
        }
    }
}