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
        #endregion

        #region Years
        /// <summary>
        /// Get start of year
        /// </summary>
        /// <param name="year">Year</param>
        /// <returns>DateTime's start of year</returns>
        public static DateTime GetStartOfYear(int year)
        {
            return new DateTime(year, 1, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Get end of year
        /// </summary>
        /// <param name="year">Year</param>
        /// <returns>DateTime's end of year</returns>
        public static DateTime GetEndOfYear(int year)
        {
            return new DateTime(year, 12, 31, 23, 59, 59, 999);
        }

        /// <summary>
        /// Return a copy of this DateTime to start of year
        /// </summary>
        /// <param name="d">DateTime</param>
        /// <returns></returns>
        public static DateTime ToStartOfYear(this DateTime d)
        {
            return new DateTime(d.Year, 1, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Return a copy of this DateTime to end of year
        /// </summary>
        /// <param name="d">DateTime</param>
        /// <returns></returns>
        public static DateTime ToEndOfYear(this DateTime d)
        {
            return new DateTime(d.Year, 12, 31, 23, 59, 59, 999);
        }
        #endregion

        #region Quarters
        /// <summary>
        /// Get start of quarter
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="quarter">Quarter</param>
        /// <returns>DateTime's start of quarter</returns>
        public static DateTime GetStartOfQuarter(int year, Quarter quarter)
        {
            switch (quarter)
            {
                case Quarter.First: // 1st Quarter = January 1 to March 31
                    return new DateTime(year, 1, 1, 0, 0, 0, 0);

                case Quarter.Second: // 2nd Quarter = April 1 to June 30
                    return new DateTime(year, 4, 1, 0, 0, 0, 0);

                case Quarter.Third: // 3rd Quarter = July 1 to September 30
                    return new DateTime(year, 7, 1, 0, 0, 0, 0);

                default: // 4th Quarter = October 1 to December 31
                    return new DateTime(year, 10, 1, 0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Get end of quarter
        /// </summary>
        /// <param name="year">Year</param>
        /// <param name="quarter">Quarter</param>
        /// <returns>DateTime's end of quarter</returns>
        public static DateTime GetEndOfQuarter(int year, Quarter quarter)
        {
            switch (quarter)
            {
                case Quarter.First: // 1st Quarter = January 1 to March 31
                    return new DateTime(year, 3, 31, 23, 59, 59, 999);

                case Quarter.Second: // 2nd Quarter = April 1 to June 30
                    return new DateTime(year, 6, 30, 23, 59, 59, 999);

                case Quarter.Third: // 3rd Quarter = July 1 to September 30
                    return new DateTime(year, 9, 30, 23, 59, 59, 999);

                default: // 4th Quarter = October 1 to December 31
                    return new DateTime(year, 12, 31, 23, 59, 59, 999);
            }
        }

        /// <summary>
        /// Get quarter
        /// </summary>
        /// <param name="month">Month</param>
        /// <returns>Quarter</returns>
        public static Quarter GetQuarter(Month month)
        {
            if (month <= Month.March) return Quarter.First; // 1st Quarter = January 1 to March 31
            else if ((month >= Month.April) && (month <= Month.June)) return Quarter.Second; // 2nd Quarter = April 1 to June 30
            else if ((month >= Month.July) && (month <= Month.September)) return Quarter.Third; // 3rd Quarter = July 1 to September 30
            else return Quarter.Fourth; // 4th Quarter = October 1 to December 31
        }
        #endregion

        #region Months
        /// <summary>
        /// Get start of month
        /// </summary>
        /// <param name="month">Month</param>
        /// <param name="year">Year</param>
        /// <returns>DateTime's start of month</returns>
        public static DateTime GetStartOfMonth(Month month, int year)
        {
            return new DateTime(year, (int)month, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Get end of month
        /// </summary>
        /// <param name="month">Month</param>
        /// <param name="year">Year</param>
        /// <returns>DateTime's end of month</returns>
        public static DateTime GetEndOfMonth(Month month, int year)
        {
            var m = (int)month;
            var d = DateTime.DaysInMonth(year, m);
            return new DateTime(year, m, d, 23, 59, 59, 999);
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