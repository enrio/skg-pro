using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL
{
    /// <summary>
    /// Date & time processing
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

        /// <summary>
        /// Enums's week
        /// </summary>
        public enum Week
        {
            Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        }
        #endregion

        #region Years
        /// <summary>
        /// Return a start of year of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <returns></returns>
        public static DateTime ToStartOfYear(this int y)
        {
            try
            {
                return new DateTime(y, 1, 1, 0, 0, 0, 0);
            }
            catch { return DateTime.Now.ToStartOfYear(); }
        }

        /// <summary>
        /// Return a copy of this DateTime to start of year
        /// </summary>
        /// <param name="d">Date & time</param>
        /// <returns></returns>
        public static DateTime ToStartOfYear(this DateTime d)
        {
            return d.Year.ToStartOfYear();
        }

        /// <summary>
        /// Return a end of year of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <returns></returns>
        public static DateTime ToEndOfYear(this int y)
        {
            try
            {
                return new DateTime(y, 12, 31, 23, 59, 59, 999);
            }
            catch { return DateTime.Now.ToEndOfYear(); }
        }

        /// <summary>
        /// Return a copy of this DateTime to end of year
        /// </summary>
        /// <param name="d">Date & time</param>
        /// <returns></returns>
        public static DateTime ToEndOfYear(this DateTime d)
        {
            return d.Year.ToEndOfYear();
        }
        #endregion

        #region Quarters
        /// <summary>
        /// Return a start of quarter of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <param name="q">Quarter</param>
        /// <returns></returns>
        public static DateTime ToStartOfQuarter(this int y, Quarter q)
        {
            switch (q)
            {
                case Quarter.First: // 1st Quarter = January 1 to March 31
                    return new DateTime(y, 1, 1, 0, 0, 0, 0);

                case Quarter.Second: // 2nd Quarter = April 1 to June 30
                    return new DateTime(y, 4, 1, 0, 0, 0, 0);

                case Quarter.Third: // 3rd Quarter = July 1 to September 30
                    return new DateTime(y, 7, 1, 0, 0, 0, 0);

                default: // 4th Quarter = October 1 to December 31
                    return new DateTime(y, 10, 1, 0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Return a copy of this DateTime to start of quarter
        /// </summary>
        /// <param name="d">Date & time</param>
        /// <param name="q">Quarter</param>
        /// <returns></returns>
        public static DateTime ToStartOfQuarter(this DateTime d, Quarter q)
        {
            return d.Year.ToStartOfQuarter(q);
        }

        /// <summary>
        /// Return a end of quarter of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <param name="q">Quarter</param>
        /// <returns></returns>
        public static DateTime ToEndOfQuarter(this int y, Quarter q)
        {
            switch (q)
            {
                case Quarter.First: // 1st Quarter = January 1 to March 31
                    return new DateTime(y, 3, 31, 23, 59, 59, 999);

                case Quarter.Second: // 2nd Quarter = April 1 to June 30
                    return new DateTime(y, 6, 30, 23, 59, 59, 999);

                case Quarter.Third: // 3rd Quarter = July 1 to September 30
                    return new DateTime(y, 9, 30, 23, 59, 59, 999);

                default: // 4th Quarter = October 1 to December 31
                    return new DateTime(y, 12, 31, 23, 59, 59, 999);
            }
        }

        /// <summary>
        /// Return a copy of this DateTime to start of quarter
        /// </summary>
        /// <param name="d">Date & time</param>
        /// <param name="q">Quarter</param>
        /// <returns></returns>
        public static DateTime ToEndOfQuarter(this DateTime d, Quarter q)
        {
            return d.Year.ToEndOfQuarter(q);
        }

        /// <summary>
        /// Return a quarter of this Month
        /// </summary>
        /// <param name="m">Month</param>
        /// <returns></returns>
        public static Quarter ToQuarter(this Month m)
        {
            if (m <= Month.March) return Quarter.First; // 1st Quarter = January 1 to March 31
            else if ((m >= Month.April) && (m <= Month.June)) return Quarter.Second; // 2nd Quarter = April 1 to June 30
            else if ((m >= Month.July) && (m <= Month.September)) return Quarter.Third; // 3rd Quarter = July 1 to September 30
            else return Quarter.Fourth; // 4th Quarter = October 1 to December 31
        }

        /// <summary>
        /// Return a quarter of this Month
        /// </summary>
        /// <param name="m">Month</param>
        /// <returns></returns>
        public static Quarter ToQuarter(this int m)
        {
            return ((Month)m).ToQuarter();
        }

        /// <summary>
        /// Return a quarter of this Month
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
        /// Return a start of month of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <param name="m">Month</param>
        /// <returns></returns>
        public static DateTime ToStartOfMonth(this int y, Month m)
        {
            return new DateTime(y, (int)m, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Return a copy of this DateTime to start of month
        /// </summary>
        /// <param name="d">Date & time</param>
        /// <param name="m">Month</param>
        /// <returns></returns>
        public static DateTime ToStartOfMonth(this DateTime d, Month m)
        {
            return d.Year.ToStartOfMonth(m);
        }

        /// <summary>
        /// Return a end of month of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <param name="m">Month</param>
        /// <returns></returns>
        public static DateTime ToEndOfMonth(this int y, Month m)
        {
            var a = (int)m;
            var d = DateTime.DaysInMonth(y, a);
            return new DateTime(y, a, d, 23, 59, 59, 999);
        }

        /// <summary>
        /// Return a copy of this DateTime to end of month
        /// </summary>
        /// <param name="d">Date & time</param>
        /// <param name="m">Month</param>
        /// <returns></returns>
        public static DateTime ToEndOfMonth(this DateTime d, Month m)
        {
            return d.Year.ToEndOfMonth(m);
        }
        #endregion

        #region Weeks
        /// <summary>
        /// Get start of last week
        /// </summary>
        /// <returns>DateTime's start of last week</returns>
        public static DateTime GetStartOfLastWeek()
        {
            var tmp = (int)DateTime.Now.DayOfWeek + 7;
            var dt = DateTime.Now.Subtract(TimeSpan.FromDays(tmp));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Get end of last week
        /// </summary>
        /// <returns>DateTime's end of last week</returns>
        public static DateTime GetEndOfLastWeek()
        {
            var dt = GetStartOfLastWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        /// <summary>
        /// Get start of current week
        /// </summary>
        /// <returns>DateTime's start of current week</returns>
        public static DateTime GetStartOfCurrentWeek()
        {
            var tmp = (int)DateTime.Now.DayOfWeek;
            var dt = DateTime.Now.Subtract(TimeSpan.FromDays(tmp));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Get end of current week
        /// </summary>
        /// <returns>DateTime's end of current week</returns>
        public static DateTime GetEndOfCurrentWeek()
        {
            var dt = GetStartOfCurrentWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }
        #endregion

        #region Days
        /// <summary>
        /// Get start of day
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>DateTime's start of day</returns>
        public static DateTime GetStartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Get end of day
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>DateTime's end of day</returns>
        public static DateTime GetEndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }
        #endregion
    }
}