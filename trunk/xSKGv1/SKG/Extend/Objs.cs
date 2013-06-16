#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 12/06/2013 06:07
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Collections.Generic;

namespace SKG.Extend
{
    /// <summary>
    /// Object processing
    /// </summary>
    public static class Objs
    {
        #region Checks
        /// <summary>
        /// Check is null or empty
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this object o)
        {
            return String.IsNullOrEmpty(o + "");
        }

        /// <summary>
        /// Check is numeric
        /// </summary>
        /// <param name="o">Expression</param>
        /// <returns></returns>
        public static bool IsNumeric(this object o)
        {
            if (o == null || o is DateTime) return false;
            if (o is Int16 || o is Int32 || o is Int64) return true;
            if (o is Decimal || o is Single || o is Double || o is Boolean) return true;

            try
            {
                if (o is string) Double.Parse(o as string);
                else Double.Parse(o.ToString());
                return true;
            }
            catch { return false; }
        }
        #endregion

        #region Guid
        /// <summary>
        /// Return Guid nullable
        /// </summary>
        /// <param name="o">Guid object</param>
        /// <returns></returns>
        public static Guid? GetGuidNull(this object o)
        {
            return o.IsNullOrEmpty() ? null : (Guid?)o;
        }

        /// <summary>
        /// Return Guid
        /// </summary>
        /// <param name="o">Guid object</param>
        /// <returns></returns>
        public static Guid GetGuid(this object o)
        {
            return o.IsNullOrEmpty() ? Guid.Empty : (Guid)o;
        }
        #endregion

        #region Converts
        /// <summary>
        /// Return string nullable
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns></returns>
        public static string ToText(this object o)
        {
            var tmp = (o + "").Trim();
            return tmp == "" ? null : tmp;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 32-bit signed integer
        /// </summary>
        /// <param name="o">Number</param>
        /// <returns></returns>
        public static int ToInt32(this object o)
        {
            var tmp = o + "";
            return tmp.ToInt32();
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 64-bit signed integer
        /// </summary>
        /// <param name="o">Number</param>
        /// <returns></returns>
        public static long ToInt64(this object o)
        {
            var tmp = o + "";
            return tmp.ToInt64();
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent double number
        /// </summary>
        /// <param name="o">Number</param>
        /// <returns></returns>
        public static double ToDouble(this object o)
        {
            var tmp = o + "";
            return tmp.ToDouble();
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent decimal number
        /// </summary>
        /// <param name="o">Number</param>
        /// <returns></returns>
        public static decimal ToDecimal(this object o)
        {
            var tmp = o + "";
            return tmp.ToDecimal();
        }

        /// <summary>
        /// Converts the specified string representation of a logic value to an equivalent boolean
        /// </summary>
        /// <param name="o">Boolean value</param>
        /// <returns></returns>
        public static bool ToBoolean(this object o)
        {
            var tmp = o + "";
            return tmp.ToBoolean();
        }

        /// <summary>
        /// Converts the specified string representation of a date time value to an equivalent DateTime
        /// </summary>
        /// <param name="o">Date time</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object o)
        {
            var tmp = o + "";
            return tmp.ToDateTime();
        }
        #endregion
    }
}