﻿#region Information
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
        /// <param name="error">Error of time</param>
        /// <returns></returns>
        public decimal ChargeForNormal()
        {
            if (DateOut == null) return 0;
            if (DateOut.Value < DateIn) return 0;

            var dateIn = DateIn.AddMinutes(Global.Delay);
            var span = DateOut.Value - dateIn;

            var odd = span.TotalDays - span.Days;
            Money = span.Days * Price2;

            var seat = Seats ?? 0;
            var bed = Beds ?? 0;

            if (Vehicle.Tariff.Code == "A")
            {
                var tmp = new DateTime(DateIn.Year, DateIn.Month, DateIn.Day, 1, 30, 0);
                var spn = DateOut.Value - tmp;
                Money = Price1 * seat + Price2 * bed + spn.Days * Global.Park;
            }
            else
            {
                var v = Caodiem(dateIn);
                var r = Caodiem(DateOut.Value);
                var x = 8D / 24D;

                if (v || r) Money += odd < x ? Price1 : Price2;
                else Money += odd < 0.5 ? Price1 : Price2;
            }

            return Money;
        }

        /// <summary>
        /// Charge for vehicle fixed
        /// </summary>
        /// <param name="error">Error of time</param>
        /// <returns></returns>
        public decimal ChargeForFixed()
        {
            if (DateOut == null) return 0;
            if (DateOut.Value < DateIn) return 0;

            var dateIn = new DateTime(DateIn.Year, DateIn.Month, DateIn.Day, 1, 30, 0);
            var span = DateOut.Value - dateIn;
            Parked = span.Days * Global.Park;

            var seat = Seats ?? 0;
            var bed = Beds ?? 0;

            Cost = Price1 * seat + Price2 * bed;
            Rose = Rose1 * (seat < 1 ? 1 : seat - 1) + Rose2 * bed;

            Money = Parked + Cost + Rose;
            return Money;
        }
        #endregion

        /// <summary>
        /// Nằm trong giờ cao điểm 22:00:00 hôm nay đến 06:00:00 hôm sau
        /// </summary>
        /// <param name="d">Thời gian</param>
        /// <returns></returns>
        bool Caodiem(DateTime d)
        {
            var peakFr = Global.GetPeakFrom;
            var peakTo = Global.GetPeakTo;

            var cur = d.Date;
            DateTime to;

            var fr = cur.AddHours(peakFr.Hour)
                .AddMinutes(peakFr.Minute)
                .AddSeconds(peakFr.Second); // 22:00:00 hôm nay            

            if (Global.Session.Current >= fr)
                to = fr.AddHours(8); // 06:00:00 hôm sau            
            else
            {
                to = cur.AddHours(peakTo.Hour)
                    .AddMinutes(peakTo.Minute)
                    .AddSeconds(peakTo.Second); // 06:00:00 hôm nay

                fr = to.AddHours(-8); // 22:00:00 hôm trước
            }

            return (d >= fr && d <= to);
        }
    }
}