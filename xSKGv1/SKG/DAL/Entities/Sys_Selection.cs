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
    /// System - Select language for user logon
    /// </summary>
    public class Sys_Selection
    {
        #region Primary and foreign key
        /// <summary>
        /// Reference to Pol_User
        /// </summary>
        [Column(Order = 0), Key, ForeignKey("User")]
        public Guid? UserId { set; get; }
        public virtual Pol_User User { get; set; }

        /// <summary>
        /// Reference to Sys_Dictionary
        /// </summary>
        [Column(Order = 1), Key, ForeignKey("Dictionary")]
        public Guid? DictionaryId { set; get; }
        public virtual Sys_Dictionary Dictionary { get; set; }
        #endregion
    }
}