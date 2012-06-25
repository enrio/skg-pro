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
            return d.Year.ToStartOfQuarter(d.Month.ToQuarter());
        }

        /// <summary>
        /// Return a copy of this DateTime to end of quarter
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns></returns>
        public static DateTime ToEndOfQuarter(this DateTime d)
        {
            return d.Year.ToEndOfQuarter(d.Month.ToQuarter());
        }

        /// <summary>
        /// Return a quarter of this DateTime
        /// </summary>
        /// <param name="m">Month</param>
        /// <returns></returns>
        public static Quarter ToQuarter(this DateTime d)
        {
            return (Quarter)d.Month.ToQuarter();
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

        /// <summary>
        /// Return a watch of this DateTime by two watches
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int ToWatch2(this DateTime d)
        {
            return d < new DateTime(d.Year, d.Month, d.Day, 12, 0, 0, 0) ? 1 : 2;
        }

        /// <summary>
        /// Return a watch of this DateTime by three watches
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int ToWatch3(this DateTime d)
        {
            var t1 = new DateTime(d.Year, d.Month, d.Day, 8, 0, 0, 0);
            var t2 = new DateTime(d.Year, d.Month, d.Day, 16, 0, 0, 0);
            return d < t1 ? 1 : d < t2 ? 2 : 3;
        }

        /// <summary>
        /// Converts the value of the current DateTime object to its equivalent string representation using the Vietnamese format information
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns></returns>
        public static string ToStringVN(this DateTime d)
        {
            return d.ToString("dd/MM/yyyy HH:mm:ss");
        }
        #endregion

        #region Ages
        /// <summary>
        /// Calculate age
        /// </summary>
        /// <param name="d">Birthday</param>
        /// <param name="now">Current year</param>
        /// <returns></returns>
        public static int ToAge(this DateTime d, DateTime now)
        {
            int years = now.Year - d.Year;
            if (now.Month < d.Month || (now.Month == d.Month && now.Day < d.Day)) years--;
            return years;
        }

        /// <summary>
        /// Return a copy of this DateTime to enough age
        /// </summary>
        /// <param name="d">Birthday</param>
        /// <param name="age">Age</param>
        /// <returns></returns>
        public static DateTime ToBirth(this DateTime d, int age)
        {
            if (d.Year - age < 1) return new DateTime();
            return new DateTime(d.Year - age, d.Month, d.Day,
                d.Hour, d.Minute, d.Second, d.Millisecond);
        }
        #endregion
    }
}