#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 24/07/2012 21:43
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// Policy - All menuz, form of system
    /// </summary>
    public class Pol_Right : Zinfors
    {
        /// <summary>
        /// Menu of level
        /// </summary>
        public int Level { set; get; }

        /// <summary>
        /// Default language
        /// </summary>
        public string Caption { set; get; }

        /// <summary>
        /// Picture for icon
        /// </summary>
        public string Picture { set; get; }

        #region Foreign key on another entity
        /// <summary>
        /// List of user right on menuz or form
        /// </summary>
        public virtual ICollection<Pol_RoleRight> Pol_RoleRights { get; set; }

        /// <summary>
        /// User's list has permission
        /// </summary>
        public virtual ICollection<Pol_UserRight> Pol_UserRights { get; set; }

        /// <summary>
        /// Language of menuz
        /// </summary>
        public virtual Pol_Lang Pol_Langs { get; set; }
        #endregion
    }
}