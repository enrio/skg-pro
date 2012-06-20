using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.UTL
{
    /// <summary>
    /// Text processing
    /// </summary>
    public static class Text
    {
        /// <summary>
        /// Return a copy of this string between two strings
        /// </summary>
        /// <param name="s"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string ToBetween(this string s, string start, string end)
        {
            try
            {
                var a = s.IndexOf(start);
                var b = s.IndexOf(end);
                return s.Substring(a, b - a);
            }
            catch { return String.Empty; }
        }

        /// <summary>
        /// Return a copy of this string between two chars
        /// </summary>
        /// <param name="s"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string ToBetween(this string s, char start, char end)
        {
            try
            {
                var a = s.IndexOf(start);
                var b = s.IndexOf(end);
                return s.Substring(a, b - a);
            }
            catch { return String.Empty; }
        }

        /// <summary>
        /// Return a copy of this string with first letter converted to uppercase
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToUpperFirst(this string s)
        {
            try
            {
                if (String.IsNullOrEmpty(s)) return String.Empty;
                return Char.ToUpper(s[0]) + s.Substring(1);
            }
            catch { return s; }
        }

        /// <summary>
        /// Return a copy of this string with first letter of each word converted to uppercase
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToUpperWords(this string s)
        {
            try
            {
                var arr = s.ToCharArray();
                if (arr.Length >= 1)
                    if (Char.IsLower(arr[0]))
                        arr[0] = Char.ToUpper(arr[0]);
                for (var i = 1; i < arr.Length; i++)
                    if (arr[i - 1] == ' ')
                        if (Char.IsLower(arr[i]))
                            arr[i] = Char.ToUpper(arr[i]);
                return new string(arr);
            }
            catch { return s; }
        }
    }
}