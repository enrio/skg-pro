using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace SKG.Extend
{
    /// <summary>
    /// Object processing
    /// </summary>
    public static class Objs
    {
        #region Object
        /// <summary>
        /// Return string nullable
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetString(this object o)
        {
            var tmp = o + "";
            if (tmp == "")
                return null;
            return tmp;
        }

        /// <summary>
        /// Return Guid nullable
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Guid? GetGuidNull(this object o)
        {
            if (o + "" == "")
                return null;
            return (Guid?)o;
        }

        /// <summary>
        /// Return Guid
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Guid GetGuid(this object o)
        {
            if (o + "" == "")
                return Guid.Empty;
            return (Guid)o;
        }
        #endregion

        #region Converts
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
        #endregion
    }
}