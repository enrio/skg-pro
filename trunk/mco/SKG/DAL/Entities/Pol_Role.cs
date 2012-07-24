#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 24/07/2012 21:33
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// Policy - List role of user group
    /// </summary>
    public class Pol_Role : ZBase
    {
        /// <summary>
        /// Name of group user
        /// </summary>
        public string Name { set; get; }

        #region Foreign key on another entity
        /// <summary>
        /// List of user belong group
        /// </summary>
        public virtual ICollection<Pol_UserRole> Pol_UserRoles { get; set; }

        /// <summary>
        /// List of user right on menuz or form
        /// </summary>
        public virtual ICollection<Pol_RoleRight> Pol_RoleRights { get; set; }
        #endregion
    }
}