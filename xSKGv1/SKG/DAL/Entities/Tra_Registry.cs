using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Đơn vị vận tải tham gia chạy tuyến
    /// </summary>
    public class Tra_Registry : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// Refercence to Tra_Vehicle
        /// </summary>
        [Column(Order = 0), ForeignKey("Vehicle")]
        public Guid? VehicleId { set; get; }
        public virtual Tra_Vehicle Vehicle { get; set; }

        /// <summary>
        /// Refercence to Pol_Role
        /// </summary>
        [Column(Order = 1), ForeignKey("Route")]
        public Guid? RouteId { set; get; }
        public virtual Pol_Dictionary Route { get; set; }
        #endregion

        /// <summary>
        /// Bến đi
        /// </summary>
        public string Arrivals { get; set; }

        /// <summary>
        /// Bến đến
        /// </summary>
        public string Departures { get; set; }

        /// <summary>
        /// Ngày giờ xuất bến (âm lịch)
        /// </summary>
        public string TimeLeaves { get; set; }
    }
}