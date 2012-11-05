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
    /// Transport - Details of in/out
    /// </summary>
    public class Tra_Detail : Zinfors
    {
        #region Foreign key
        /// <summary>
        /// Of vehicle (refercence to Tra_Vehicle)
        /// </summary>
        [Column(Order = 0), ForeignKey("Tra_Vehicle")]
        public Guid? Tra_VehicleId { set; get; }
        /// <summary>
        /// Of vehicle
        /// </summary>
        public virtual Tra_Vehicle Tra_Vehicle { get; set; }

        /// <summary>
        /// Of User ingate (refercence to Pol_User)
        /// </summary>
        [Column(Order = 1), ForeignKey("Pol_UserIn")]
        public Guid? Pol_UserInId { set; get; }
        /// <summary>
        /// Of User ingate
        /// </summary>
        public virtual Pol_User Pol_UserIn { get; set; }

        /// <summary>
        /// Of User outgate (refercence to Pol_User)
        /// </summary>
        [Column(Order = 2), ForeignKey("Pol_UserOut")]
        public Guid? Pol_UserOutId { set; get; }
        /// <summary>
        /// Of User outgate
        /// </summary>
        public virtual Pol_User Pol_UserOut { get; set; }
        #endregion

        #region In station
        /// <summary>
        /// Date time into
        /// </summary>
        public DateTime DateIn { set; get; }

        /// <summary>
        /// Date time out
        /// </summary>
        public DateTime? DateOut { set; get; }

        /// <summary>
        /// Full day
        /// </summary>
        public int FullDay { set; get; }

        /// <summary>
        /// Half day
        /// </summary>
        public int HalfDay { set; get; }
        #endregion

        #region Out station
        /// <summary>
        /// Date time into again when vehicle repair out gate succesfull
        /// </summary>
        public DateTime? DateInRepair { set; get; }

        /// <summary>
        /// Date time out when vehicle gate out to repair
        /// </summary>
        public DateTime? DateOutRepair { set; get; }
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

        #region Weight
        /// <summary>
        /// Number of seats current
        /// </summary>
        public int? Seats { set; get; }

        /// <summary>
        /// Number of beds current
        /// </summary>
        public int? Beds { set; get; }
        #endregion

        #region Money
        /// <summary>
        /// Sum of cost
        /// </summary>
        public long Cost { set; get; }

        /// <summary>
        /// Sum of rose
        /// </summary>
        public long Rose { set; get; }

        /// <summary>
        /// Parked in the bus station overnight
        /// </summary>
        public long Parked { set; get; }

        /// <summary>
        /// Total money
        /// </summary>
        public decimal Money { set; get; }
        #endregion

        /// <summary>
        /// Charge for vehicle normal
        /// </summary>
        /// <param name="error">Error of time</param>
        /// <returns></returns>
        public decimal ChargeForNormal(int error = 11)
        {
            if (DateOut == null) return 0;
            if (DateOut.Value < DateIn) return 0;

            var dateIn = DateIn.AddMinutes(error);
            var span = DateOut.Value - dateIn;

            var odd = span.TotalDays - span.Days;
            Money = span.Days * Price2;

            var seat = Seats ?? 0;
            var bed = Beds ?? 0;

            Money += odd < 0.5 ? Price1 : Price2;
            Money += Price1 * seat + Price2 * bed;
            return Money;
        }

        /// <summary>
        /// Charge for vehicle fixed
        /// </summary>
        /// <param name="error">Error of time</param>
        /// <returns></returns>
        public decimal ChargeForFixed(int error = 11)
        {
            if (DateOut == null) return 0;
            if (DateOut.Value < DateIn) return 0;

            var dateIn = new DateTime(DateIn.Year, DateIn.Month, DateIn.Day, 2, error, 0);
            var span = DateOut.Value - dateIn;
            Parked = span.Days * 20000;

            var seat = Seats ?? 0;
            var bed = Beds ?? 0;

            Cost = Price1 * seat + Rose1 * (seat < 1 ? 1 : seat - 1);
            Rose += (Price2 + Rose2) * bed;
            Money = Parked + Cost + Rose;
            return Money;
        }
    }
}