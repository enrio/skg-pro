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
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Policy - List of user right on menuz or form
    /// </summary>
    public class Pol_RoleRight : Zaction
    {
        #region Foreign key
        /// <summary>
        /// Refercence to Pol_Role
        /// </summary>
        [Column(Order = 0), ForeignKey("Pol_Role")]
        public Guid? Pol_RoleId { set; get; }
        public virtual Pol_Dictionary Pol_Role { get; set; }

        /// <summary>
        /// Refercence to Pol_Right
        /// </summary>
        [Column(Order = 1), ForeignKey("Pol_Right")]
        public Guid? Pol_RightId { set; get; }
        public virtual Pol_Dictionary Pol_Right { get; set; }
        #endregion
    }
}