#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 24/07/2013 11:05
 * Update: 24/07/2013 11:05
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
    /// Audit log
    /// </summary>
    public interface IAudit
    {
        #region Log
        /// <summary>
        /// Created date
        /// </summary>
        DateTime? CreatedDate { set; get; }

        /// <summary>
        /// Modifed date
        /// </summary>
        DateTime? ModifedDate { set; get; }

        /// <summary>
        /// Created by
        /// </summary>
        Pol_User CreatedBy { get; set; }

        /// <summary>
        /// Modified by
        /// </summary>
        Pol_User ModifiedBy { get; set; }

        /// <summary>
        /// Created ID
        /// </summary>
        [Column(Order = 0), ForeignKey("CreatedBy")]
        Guid? CreatedId { set; get; }

        /// <summary>
        /// Modified ID
        /// </summary>
        [Column(Order = 1), ForeignKey("ModifiedBy")]
        Guid? ModifiedId { set; get; }
        #endregion
    }
}