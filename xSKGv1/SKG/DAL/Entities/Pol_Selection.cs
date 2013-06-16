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