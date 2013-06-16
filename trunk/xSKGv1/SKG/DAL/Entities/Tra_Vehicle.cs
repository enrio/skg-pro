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
    /// Transport - List of all vehicles
    /// </summary>
    public class Tra_Vehicle : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// Belong to transport unit (reference to Pol_Dictionary)
        /// </summary>
        [Column(Order = 1), ForeignKey("Transport")]
        public Guid? TransportId { set; get; }
        /// <summary>
        /// Belong to transport unit
        /// </summary>
        public virtual Pol_Dictionary Transport { get; set; }

        /// <summary>
        /// Have a tariff (ticket and commission) (reference to Tra_Tariff)
        /// </summary>
        [Column(Order = 2), ForeignKey("Tariff")]
        public Guid? TariffId { set; get; }
        /// <summary>
        /// Have a tariff (ticket and commission)
        /// </summary>
        public virtual Tra_Tariff Tariff { get; set; }

        /// <summary>
        /// Creator (refercence to Pol_User)
        /// </summary>
        [Column(Order = 3), ForeignKey("Creator")]
        public Guid? CreatorId { set; get; }
        /// <summary>
        /// Creator
        /// </summary>
        public virtual Pol_User Creator { get; set; }

        /// <summary>
        /// List of detail in or out station
        /// </summary>
        public virtual ICollection<Tra_Detail> Tra_Details { get; set; }
        #endregion

        /// <summary>
        /// Create date
        /// </summary>
        public DateTime? CreateDate { get; set; }

        #region Weight
        /// <summary>
        /// Number of seats
        /// </summary>
        public int? Seats { set; get; }

        /// <summary>
        /// Number of beds
        /// </summary>
        public int? Beds { set; get; }
        #endregion

        #region Information management
        /// <summary>
        /// Production year
        /// </summary>
        public string ProductionYear { set; get; }

        /// <summary>
        /// Limited registration
        /// </summary>
        public DateTime? LimitedRegistration { set; get; }

        /// <summary>
        /// Term insurance
        /// </summary>
        public DateTime? TermInsurance { set; get; }

        /// <summary>
        /// Term fixed routes
        /// </summary>
        public DateTime? TermFixedRoutes { set; get; }

        /// <summary>
        /// Term driver license
        /// </summary>
        public DateTime? TermDriverLicense { set; get; }

        /// <summary>
        /// Number of nodes per month
        /// </summary>
        public int? Node { set; get; }
        #endregion

        #region Information of vehicle
        /// <summary>
        /// High quality
        /// </summary>
        public bool? High { set; get; }

        /// <summary>
        /// Vehicle of city
        /// </summary>
        public bool? City { set; get; }

        /// <summary>
        /// Fixed route
        /// </summary>
        public bool Fixed { set; get; }
        #endregion

        #region Difference information
        /// <summary>
        /// Driver's fullname
        /// </summary>
        public string Driver { set; get; }

        /// <summary>
        /// Driver's birthday
        /// </summary>
        public DateTime? Birth { set; get; }

        /// <summary>
        /// Driver's address
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// Driver's telephone number
        /// </summary>
        public string Phone { set; get; }
        #endregion
    }
}