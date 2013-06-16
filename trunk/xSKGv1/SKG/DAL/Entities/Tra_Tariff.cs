﻿#region Information
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
        /// Belong to area group
        /// </summary>
        public virtual Pol_Dictionary Group { get; set; }

        /// <summary>
        /// List of vehicles
        /// </summary>
        public virtual ICollection<Tra_Vehicle> Tra_Vehicles { get; set; }
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