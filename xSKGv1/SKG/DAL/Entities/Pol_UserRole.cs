#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 12/06/2013 06:33
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SKG.DAL.Entities
{
    /// <summary>
    /// Policy - List of user belong group
    /// </summary>
    public class Pol_UserRole : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// Refercence to Pol_User
        /// </summary>
        [Column(Order = 0), ForeignKey("User")]
        public Guid? UserId { set; get; }
        /// <summary>
        /// User
        /// </summary>
        public virtual Pol_User User { get; set; }

        /// <summary>
        /// Refercence to Pol_Role
        /// </summary>
        [Column(Order = 1), ForeignKey("Role")]
        public Guid? RoleId { set; get; }
        /// <summary>
        /// Role
        /// </summary>
        public virtual Pol_Dictionary Role { get; set; }
        #endregion
    }
}