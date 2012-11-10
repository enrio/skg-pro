#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2012 21:33
 * Update: 24/07/2012 21:45
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
    /// Policy - User's list has permission
    /// </summary>
    public class Pol_UserRight : Zaction
    {
        #region Foreign key
        /// <summary>
        /// Refercence to Pol_User
        /// </summary>
        [Column(Order = 0), ForeignKey("Pol_User")]
        public Guid? UserId { set; get; }
        /// <summary>
        /// User
        /// </summary>
        public virtual Pol_User User { get; set; }

        /// <summary>
        /// Refercence to Pol_Right
        /// </summary>
        [Column(Order = 1), ForeignKey("Pol_Right")]
        public Guid? RightId { set; get; }
        /// <summary>
        /// Right
        /// </summary>
        public virtual Pol_Dictionary Right { get; set; }
        #endregion
    }
}