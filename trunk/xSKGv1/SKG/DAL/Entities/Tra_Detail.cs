#region Information
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
    using SKG.Extend;

    /// <summary>
    /// Transport - Details of in or out
    /// </summary>
    public class Tra_Detail : Zinfors
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
        /// Of user ingate (refercence to Pol_User)
        /// </summary>
        [Column(Order = 1), ForeignKey("UserIn")]
        public Guid? UserInId { set; get; }
        /// <summary>
        /// Of user ingate
        /// </summary>
        public virtual Pol_User UserIn { get; set; }

        /// <summary>
        /// Of user outgate (refercence to Pol_User)
        /// </summary>
        [Column(Order = 2), ForeignKey("UserOut")]
        public Guid? UserOutId { set; get; }
        /// <summary>
        /// Of user outgate
        /// </summary>
        public virtual Pol_User UserOut { get; set; }
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

        #region More
        /// <summary>
        /// Allow out gate to repair not make money
        /// </summary>
        public bool Repair { set; get; }

        /// <summary>
        /// Number of guest out gate
        /// </summary>
        public int? Guest { set; get; }

        /// <summary>
        /// Number of discount
        /// </summary>
        public int? Discount { set; get; }

        /// <summary>
        /// Number of arrears
        /// </summary>
        public int? Arrears { set; get; }
        #endregion

        #region Charge
        /// <summary>
        /// Charge for vehicle normal
        /// </summary>
        /// <returns></returns>
        decimal ChargeForNormal()
        {
            if (DateOut == null) return 0;
            if (DateOut.Value < DateIn) return 0;

            var dateIn = DateIn.AddMinutes(Global.Delay);
            var span = DateOut.Value - dateIn;

            // Xe thu khoán 1 ngày (dùng cột City ghi nhận)
            if (Vehicle.City != null && Vehicle.City.Value)
                Money = Price2;
            else if (Vehicle.Tariff.Code == "A")
            {
                var std = DateIn.Date.AddTicks(Global.ParkFr.Ticks).AddDays(span.Days);
                var days = span.Days + ((dateIn > std || DateOut.Value > std) ? 1 : 0);

                HalfDay = 1;
                var seat = Seats ?? 0;
                var bed = Beds ?? 0;
                var weight = seat > bed ? seat : bed;

                // Qua 22:00:00 thì tính 1 đêm
                Parked = days * (weight < Global.Weight ? Global.Park1 : Global.Park);
                Cost = Price1 * seat + Price2 * bed;
                Rose = Rose1 * (seat < 1 ? 1 : seat - 1) + Rose2 * bed;
                Money = Parked + Cost + Rose;
            }
            else
            {
                var to = DateIn.Date.AddTicks(Global.PeakFr.Ticks);
                var fr = DateIn.Date.AddTicks(Global.PeakTo.Ticks).AddDays(-1);
                var a = dateIn.CheckBetween(fr, to);

                to = DateOut.Value.Date.AddTicks(Global.PeakFr.Ticks);
                fr = DateOut.Value.Date.AddTicks(Global.PeakTo.Ticks).AddDays(-1);
                var b = DateOut.Value.CheckBetween(fr, to);

                double x = 0;
                var v = a && b || a || b;

                if (v) x = 8D / 24D;
                else x = 0.5;

                var odd = span.TotalDays - span.Days;
                Money = span.Days * Price2;
                FullDay = span.Days;

                if (odd < x)
                {
                    HalfDay = 1;
                    Money += Price1;
                }
                else
                {
                    HalfDay = 0;
                    FullDay++;
                    Money += Price2;
                }
            }

            return Money;
        }

        /// <summary>
        /// Charge for vehicle fixed
        /// </summary>
        /// <returns></returns>
        decimal ChargeForFixed()
        {
            if (DateOut == null) return 0;
            if (DateOut.Value < DateIn) return 0;

            var dateIn = DateIn.AddMinutes(Global.Delay);
            var span = DateOut.Value - dateIn;
            var std = DateIn.Date.AddTicks(Global.ParkFr.Ticks).AddDays(span.Days);
            var days = span.Days + ((dateIn > std || DateOut.Value > std) ? 1 : 0);

            var seat = Seats ?? 0;
            var bed = Beds ?? 0;
            var weight = seat > bed ? seat : bed;

            // Qua 22:00:00 thì tính 1 đêm
            Parked = days * (weight < Global.Weight ? Global.Park1 : Global.Park);
            Cost = Price1 * seat + Price2 * bed;
            Rose = Rose1 * (seat < 1 ? 1 : seat - 1) + Rose2 * bed;
            Money = Parked + Cost + Rose;

            return Money;
        }

        /// <summary>
        /// Charge for vehicle fixed and normal
        /// </summary>
        /// <returns></returns>
        public decimal Charge()
        {
            return Vehicle.Fixed ? ChargeForFixed() : ChargeForNormal();
        }
        #endregion
    }
}