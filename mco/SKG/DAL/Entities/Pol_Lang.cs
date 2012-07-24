#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:33
 * Update: 24/07/2012 21:26
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
    /// Policy - Language for system (include all form, menuz and more)
    /// </summary>
    public class Pol_Lang : ZBase
    {
        #region Foreign key
        /// <summary>
        /// Refercence to Pol_User
        /// </summary>
        [Column(Order = 0), ForeignKey("Pol_User")]
        public Guid? Pol_UserId { set; get; }
        public virtual Pol_User Pol_User { get; set; }
        #endregion

        /// <summary>
        /// ZnG ioz
        /// </summary>
        public string Zng { get; set; }

        /// <summary>
        /// Vietnamese
        /// </summary>
        public string Vietnamese { get; set; }

        /// <summary>
        /// English
        /// </summary>
        public string English { get; set; }

        /// <summary>
        /// Default language
        /// </summary>
        [StringLength(256)]
        public string Default { get; set; }

        public Pol_Lang()
        {
            Default = "Vietnamese";
        }
    }
}