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
    /// Policy - User's language choice
    /// </summary>
    public class Pol_UserLang
    {
        #region Foreign key
        /// <summary>
        /// Refercence to Pol_User
        /// </summary>
        [Column(Order = 0), ForeignKey("Pol_User")]
        public Guid? Pol_UserId { set; get; }
        public virtual Pol_User Pol_User { get; set; }

        /// <summary>
        /// Refercence to Pol_Lang
        /// </summary>
        [Column(Order = 1), ForeignKey("Pol_Lang")]
        public Guid? Pol_LangId { set; get; }
        public virtual Pol_Lang Pol_Lang { get; set; }
        #endregion
    }
}