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

namespace SKG.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Policy - All menu, form of system is called right (menuz)
    /// </summary>
    public class Pol_Right : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// Reference to Pol_Dictionary (ID)
        /// </summary>
        [Key, Column(Order = 0), ForeignKey("Dictionary")]
        public new Guid Id { set; get; }

        /// <summary>
        /// Reference to Pol_Dictionary (object)
        /// </summary>
        public virtual Pol_Dictionary Dictionary { get; set; }

        /// <summary>
        /// List of user right on menuz
        /// </summary>
        public virtual ICollection<Pol_RoleRight> Pol_RoleRights { get; set; }

        /// <summary>
        /// User's list has permission
        /// </summary>
        public virtual ICollection<Pol_UserRight> Pol_UserRights { get; set; }
        #endregion

        /// <summary>
        /// Menu of level
        /// </summary>
        public int Level { set; get; }

        /// <summary>
        /// Picture for icon
        /// </summary>
        public string Picture { set; get; }
    }
}