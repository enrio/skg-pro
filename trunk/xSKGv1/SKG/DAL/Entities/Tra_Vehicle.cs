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
    /// Vận tải - Danh sách xe
    /// </summary>
    public class Tra_Vehicle : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// Belong to transport (reference to Pol_Dictionary)
        /// </summary>
        [Column(Order = 1), ForeignKey("Transport")]
        public Guid? TransportId { set; get; }
        /// <summary>
        /// Belong to transport unit
        /// </summary>
        public virtual Pol_Dictionary Transport { get; set; }

        /// <summary>
        /// Belong to tariff and commission (reference to Tra_Tariff)
        /// </summary>
        [Column(Order = 2), ForeignKey("Tariff")]
        public Guid? TariffId { set; get; }
        /// <summary>
        /// Have tariff and commission
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
        /// List of details in/out
        /// </summary>
        public virtual ICollection<Tra_Detail> Tra_Details { get; set; }
        #endregion

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
        public int? ProductionYear { set; get; }

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
        /// Server quality
        /// </summary>
        public string ServerQuality { set; get; }

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