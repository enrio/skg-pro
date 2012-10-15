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
    /// Transport - Registry to join route
    /// </summary>
    public class Tra_Registry : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// Of vehicle (refercence to Tra_Vehicle)
        /// </summary>
        [Column(Order = 0), ForeignKey("Vehicle")]
        public Guid? VehicleId { set; get; }
        /// <summary>
        /// Of vehicle
        /// </summary>
        public virtual Tra_Vehicle Vehicle { get; set; }

        /// <summary>
        /// Tariff and commission (refercence to Tra_Tariff)
        /// </summary>
        [Column(Order = 1), ForeignKey("Tariff")]
        public Guid? TariffId { set; get; }
        /// <summary>
        /// Tariff and commission
        /// </summary>
        public virtual Tra_Tariff Tariff { get; set; }

        /// <summary>
        /// Route registry (refercence to Tra_Tariff)
        /// </summary>
        [Column(Order = 4), ForeignKey("Route")]
        public Guid? RouteId { set; get; }
        /// <summary>
        /// Route registry
        /// </summary>
        public Pol_Dictionary Route { get; set; }

        /// <summary>
        /// List of vehicles
        /// </summary>
        public virtual ICollection<Tra_Vehicle> Tra_Vehicles { get; set; }
        #endregion

        /// <summary>
        /// Date and time leave (vietnam)
        /// </summary>
        public string TimeLeaves { get; set; }

        /// <summary>
        /// Date registry
        /// </summary>
        public DateTime RegDate { get; set; }
    }
}