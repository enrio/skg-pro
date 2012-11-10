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
    /// Policy - Select language for user logon
    /// </summary>
    public class Pol_Selection : Zinfors
    {
        #region Primary and foreign key
        /// <summary>
        /// Reference to Pol_User (ID)
        /// </summary>
        [Column(Order = 1), ForeignKey("User")]
        public Guid? UserId { set; get; }
        /// <summary>
        /// User
        /// </summary>
        public virtual Pol_User User { get; set; }

        /// <summary>
        /// Reference to Pol_Dictionary (ID)
        /// </summary>
        [Column(Order = 2), ForeignKey("Dictionary")]
        public Guid? DictionaryId { set; get; }
        /// <summary>
        /// Dictionary
        /// </summary>
        public virtual Pol_Dictionary Dictionary { get; set; }
        #endregion
    }
}