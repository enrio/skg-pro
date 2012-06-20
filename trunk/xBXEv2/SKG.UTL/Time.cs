using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL
{
    /// <summary>
    /// Date and time processing
    /// </summary>
    public static class Time
    {
        #region Enums
        /// <summary>
        /// Enums's quarter
        /// </summary>
        public enum Quarter { First = 1, Second = 2, Third = 3, Fourth = 4 }

        /// <summary>
        /// Enums's month
        /// </summary>
        public enum Month
        {
            January = 1, February = 2, March = 3, April = 4,
            May = 5, June = 6, July = 7, August = 8,
            September = 9, October = 10, November = 11, December = 12
        }
        #endregion

        #region Years
        /// <summary>
        /// Return a copy of this DateTime to start of year
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns></returns>
        public static DateTime ToStartOfYear(this DateTime d)
        {
            return d.Year.ToStartOfYear();
        }

        /// <summary>
        /// Return a copy of this DateTime to end of year
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns></returns>
        public static DateTime ToEndOfYear(this DateTime d)
        {
            return d.Year.ToEndOfYear();
        }
        #endregion

        #region Quarters
        /// <summary>
        /// Return a copy of this DateTime to start of quarter
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns></returns>
        public static DateTime ToStartOfQuarter(this DateTime d)
        {
            return d.Year.ToStartOfQuarter(d.Month);
        }

        /// <summary>
        /// Return a copy of this DateTime to end of quarter
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns></returns>
        public static DateTime ToEndOfQuarter(this DateTime d)
        {
            return d.Year.ToEndOfQuarter(d.Month);
        }

        /// <summary>
        /// Return a quarter of this DateTime
        /// </summary>
        /// <param name="m">Month</param>
        /// <returns></returns>
        public static Quarter ToQuarter(this DateTime d)
        {
            return d.Month.ToQuarter();
        }
        #endregion

        #region Months
        /// <summary>
        /// Return a copy of this DateTime to start of month
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns></returns>
        public static DateTime ToStartOfMonth(this DateTime d)
        {
            return d.Year.ToStartOfMonth(d.Month);
        }

        /// <summary>
        /// Return a copy of this DateTime to end of month
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns></returns>
        public static DateTime ToEndOfMonth(this DateTime d)
        {
            return d.Year.ToEndOfMonth(d.Month);
        }

        /// <summary>
        /// Return a quarter of this DateTime
        /// </summary>
        /// <param name="m">Date and time</param>
        /// <returns></returns>
        public static Month ToMonth(this DateTime d)
        {
            return (Month)d.Month;
        }
        #endregion

        #region Weeks
        /// <summary>
        /// Return a copy of this DateTime to start of week
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns></returns>
        public static DateTime ToStartOfWeek(this DateTime d)
        {
            var a = (int)d.DayOfWeek;
            var b = d.Subtract(TimeSpan.FromDays(a));
            return b.ToStartOfDay();
        }

        /// <summary>
        /// Return a copy of this DateTime to end of week
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns></returns>
        public static DateTime ToEndOfWeek(this DateTime d)
        {
            var a = d.ToStartOfWeek().AddDays(6);
            return a.ToEndOfDay();
        }
        #endregion

        #region Days
        /// <summary>
        /// Return a copy of this DateTime to start of day
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns></returns>
        public static DateTime ToStartOfDay(this DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Return a copy of this DateTime to end of day
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns></returns>
        public static DateTime ToEndOfDay(this DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, 23, 59, 59, 999);
        }
        #endregion
    }
}