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
        /// Number of days in station
        /// </summary>
        public int Days { set; get; }

        /// <summary>
        /// Number of hours in station
        /// </summary>
        public int Hours { set; get; }
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

        /// <summary>
        /// Total money
        /// </summary>
        public decimal Money { set; get; }

        /// <summary>
        /// Charge for vehicle normal
        /// </summary>
        /// <param name="price1">Price of a half day (or a seat)</param>
        /// <param name="price2">Price of a full day (or a bed)</param>
        /// <param name="seats">Number of seat</param>
        /// <param name="beds">Number of bed</param>
        /// <param name="error">Errot of time</param>
        /// <returns>Money</returns>
        public decimal ChargeForNormal(int price1, int price2, int seats, int beds, int error = 11)
        {
            if (DateOut == null) return 0;
            if (DateOut.Value < DateIn) return 0;
            var dateOut = DateOut.Value.Subtract(new TimeSpan(0, error, 0));

            var span = DateOut.Value - DateIn;
            var odd = span.TotalDays - span.Days;

            var money = span.Days * price2;
            if (odd < 0.5) money += price1;
            else money += price2;

            return money;
        }

        /// <summary>
        /// Charge for vehicle fixed
        /// </summary>
        /// <param name="price1">Price of a seat</param>
        /// <param name="price2">Price of a bed</param>
        /// <param name="rose1">Commission of a seat</param>
        /// <param name="rose2">Commission of a bed</param>
        /// <param name="seats">Number of seat</param>
        /// <param name="beds">Number of bed</param>
        /// <param name="error">Error of time</param>
        /// <returns>Money</returns>
        public decimal ChargeForFixed(int price1, int price2, int rose1, int rose2, int seats, int beds, int error = 11)
        {
            if (DateOut == null) return 0;
            if (DateOut.Value < DateIn) return 0;
            var dateOut = DateOut.Value.Subtract(new TimeSpan(0, error, 0));

            var span = DateOut.Value - DateIn;
            var odd = span.TotalDays - span.Days;

            var money = span.Days * price2;
            if (odd < 0.5) money += price1;
            else money += price2;

            return money;
        }
    }
}