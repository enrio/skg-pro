#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 15/10/2012 21:21
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
    /// Transport - Tariff and commission of ticket
    /// </summary>
    public class Tra_Tariff : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// Belong to group (reference to Pol_Dictionary)
        /// </summary>
        [ForeignKey("Group")]
        public Guid? GroupId { set; get; }

        /// <summary>
        /// Belong to group AREA
        /// </summary>
        public virtual Pol_Dictionary Group { get; set; }
        #endregion

        #region Price
        /// <summary>
        /// Price of a seat or a half day
        /// </summary>
        public int Price1 { set; get; }

        /// <summary>
        /// Price of a bed or a full day
        /// </summary>
        public int Price2 { set; get; }
        #endregion

        #region Commission
        /// <summary>
        /// Commission of a seat
        /// </summary>
        public int Rose1 { set; get; }

        /// <summary>
        /// Commission of a bed
        /// </summary>
        public int Rose2 { set; get; }
        #endregion
    }
}