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
        /// Refercence to Tra_Tariff
        /// </summary>
        [Column(Order = 1), ForeignKey("Tariff")]
        public Guid? TariffId { set; get; }
        /// <summary>
        /// Giá vé
        /// </summary>
        public virtual Tra_Tariff Tariff { get; set; }

        /// <summary>
        /// Refercence to Tra_Tariff
        /// </summary>
        [Column(Order = 2), ForeignKey("Commission")]
        public Guid? CommissionId { set; get; }
        /// <summary>
        /// Hoa hồng
        /// </summary>
        public virtual Tra_Tariff Commission { get; set; }

        /// <summary>
        /// Bến đi
        /// </summary>
        [Column(Order = 3), ForeignKey("Arrival")]
        public Guid? ArrivalId { set; get; }
        public Pol_Dictionary Arrival { get; set; }

        /// <summary>
        /// Bến đến
        /// </summary>
        [Column(Order = 4), ForeignKey("Departure")]
        public Guid? DepartureId { set; get; }
        public Pol_Dictionary Departure { get; set; }
        #endregion

        /// <summary>
        /// Ngày giờ xuất bến (âm lịch)
        /// </summary>
        public string TimeLeaves { get; set; }
    }
}