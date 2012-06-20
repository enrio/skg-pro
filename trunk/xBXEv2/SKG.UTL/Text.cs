﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Text processing
    /// </summary>
    public static class Text
    {
        #region Text
        /// <summary>
        /// Return a copy of this string between two strings
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="start">String start</param>
        /// <param name="end">String end</param>
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
        /// <param name="s">String</param>
        /// <param name="start">Char start</param>
        /// <param name="end">Char end</param>
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
        /// <param name="s">String</param>
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
        /// <param name="s">String</param>
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
        #endregion

        #region Convert
        public static int ToInt32(this string s)
        {
            if (IsNumberC(s)) return Convert.ToInt32(s);
            return 0;
        }

        public static long ToInt64(this string s)
        {
            if (IsNumberC(s)) return Convert.ToInt64(s);
            return 0;
        }

        public static decimal ToDecimal(this string s)
        {
            if (IsNumberC(s)) return Convert.ToDecimal(s);
            return 0;
        }

        public static double ToDouble(this string s)
        {
            if (IsNumberC(s)) return Convert.ToDouble(s);
            return 0;
        }

        /// <summary>
        /// Check text is number using Regex class
        /// </summary>
        /// <param name="s">Number</param>
        /// <returns></returns>
        public static bool IsNumberR(this string s)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(s);
        }

        /// <summary>
        /// Check text is number using Char class
        /// </summary>
        /// <param name="s">Number</param>
        /// <returns></returns>
        public static bool IsNumberC(this string s)
        {
            foreach (Char c in s)
                if (!Char.IsDigit(c))
                    return false;
            return true;
        }
        #endregion
    }
}