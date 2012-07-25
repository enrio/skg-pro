﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Extend
{
    using Plugin;
    using System.IO;
    using System.Xml.Linq;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Text processing
    /// </summary>
    public static class Text
    {
        #region Strings
        /// <summary>
        /// Return a copy of this string between two strings with format case
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="start">String start</param>
        /// <param name="end">String end</param>
        /// <param name="format">Format case</param>
        /// <returns></returns>
        public static string ToBetween(this string s, string start, string end, Format format = Format.Orginal)
        {
            try
            {
                var a = start == null ? 0 : s.IndexOf(start);
                var b = s.IndexOf(end);
                var c = s.Substring(a, b - a);

                switch (format)
                {
                    case Format.Sentence: return c.ToUpperFirst();
                    case Format.Lower: return c.ToLower();
                    case Format.Upper: return c.ToUpper();
                    case Format.Capitalized: return c.ToUpperWords();
                    default: return c;
                }
            }
            catch { return String.Empty; }
        }

        /// <summary>
        /// Return a copy of this string between two chars with format case
        /// </summary>
        /// <param name="s">String</param>
        /// <param name="start">Char start</param>
        /// <param name="end">Char end</param>
        /// <param name="format">Format case</param>
        /// <returns></returns>
        public static string ToBetween(this string s, char start, char end, Format format = Format.Orginal)
        {
            try
            {
                var a = s.IndexOf(start);
                var b = s.IndexOf(end);
                var c = s.Substring(a, b - a);

                switch (format)
                {
                    case Format.Sentence: return c.ToUpperFirst();
                    case Format.Lower: return c.ToLower();
                    case Format.Upper: return c.ToUpper();
                    case Format.Capitalized: return c.ToUpperWords();
                    default: return c;
                }
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

        #region Checks
        /// <summary>
        /// Check text is number using Regex class
        /// </summary>
        /// <param name="s">Number</param>
        /// <returns></returns>
        public static bool IsNumber(this string s)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(s);
        }

        /// <summary>
        /// Check number between min & max
        /// </summary>
        /// <param name="n">Number</param>
        /// <param name="min">Minimum number</param>
        /// <param name="max">Maximum number</param>
        /// <returns></returns>
        public static bool CheckNumber(this string n, int min, int max)
        {
            return n.ToInt32().CheckNumber(min, max);
        }

        /// <summary>
        /// Check number between min & max
        /// </summary>
        /// <param name="n">Number</param>
        /// <param name="min">Minimum number</param>
        /// <param name="max">Maximum number</param>
        /// <returns></returns>
        public static bool CheckNumber(this string n, long min, long max)
        {
            return n.ToInt64().CheckNumber(min, max);
        }

        /// <summary>
        /// Check number between min & max
        /// </summary>
        /// <param name="n">Number</param>
        /// <param name="min">Minimum number</param>
        /// <param name="max">Maximum number</param>
        /// <returns></returns>
        public static bool CheckNumber(this string n, double min, double max)
        {
            return n.ToDouble().CheckNumber(min, max);
        }

        /// <summary>
        /// Check number between min & max
        /// </summary>
        /// <param name="n">Number</param>
        /// <param name="min">Minimum number</param>
        /// <param name="max">Maximum number</param>
        /// <returns></returns>
        public static bool CheckNumber(this string n, decimal min, decimal max)
        {
            return n.ToDecimal().CheckNumber(min, max);
        }

        /// <summary>
        /// Check SQL Server connection
        /// </summary>
        /// <param name="n">Connection string</param>
        /// <returns></returns>
        public static bool CheckSqlConnect(this string n)
        {
            try
            {
                using (var a = new SqlConnection(n)) { a.Open(); }
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Check SQL Server CE connection
        /// </summary>
        /// <param name="n">Connection string</param>
        /// <returns></returns>
        public static bool CheckSqlCeConnect(this string n)
        {
            try { return File.Exists(n); }
            catch { return false; }
        }
        #endregion

        #region Converts
        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 32-bit signed integer
        /// </summary>
        /// <param name="s">Number</param>
        /// <returns></returns>
        public static int ToInt32(this string s)
        {
            if (IsNumber(s)) return Convert.ToInt32(s);
            return 0;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 64-bit signed integer
        /// </summary>
        /// <param name="s">Number</param>
        /// <returns></returns>
        public static long ToInt64(this string s)
        {
            if (IsNumber(s)) return Convert.ToInt64(s);
            return 0;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent double number
        /// </summary>
        /// <param name="s">Number</param>
        /// <returns></returns>
        public static double ToDouble(this string s)
        {
            if (IsNumber(s)) return Convert.ToDouble(s);
            return 0;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent decimal number
        /// </summary>
        /// <param name="s">Number</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string s)
        {
            if (IsNumber(s)) return Convert.ToDecimal(s);
            return 0;
        }
        #endregion

        #region Menu
        /// <summary>
        /// Select menu's level
        /// </summary>
        /// <param name="menuFile">Path menu XML file</param>
        /// <param name="menuName">Menu's name</param>
        /// <returns></returns>
        private static List<Menuz> Select(string menuFile, string menuName)
        {
            try
            {
                var xmlDoc = XDocument.Load(menuFile);
                var res = from s in xmlDoc.Descendants(menuName)
                          select new
                          {
                              Level = s.Element("Level").Value,
                              Caption = s.Element("Caption").Value,
                              Code = s.Element("Code").Value,
                              Picture = s.Element("Picture").Value,
                              Order = s.Element("Order").Value,
                              Show = s.Element("Show").Value
                          };

                var lst = new List<Menuz>();

                foreach (var s in res)
                {
                    var p = new Menuz()
                    {
                        Level = Convert.ToInt32(s.Level),
                        Caption = s.Caption,
                        Code = s.Code,
                        Picture = s.Picture,
                        Show = Convert.ToBoolean(s.Show),
                        Order = Convert.ToInt32(s.Order)
                    };
                    lst.Add(p);
                }
                return lst;
            }
            catch { return null; }
        }

        /// <summary>
        /// Return menu
        /// </summary>
        /// <param name="menuFile">Path menu XML file</param>
        /// <param name="menuName">Menu's name</param>
        /// <returns></returns>
        public static List<Menuz> ToMenu(this string menuFile, string menuName)
        {
            return Select(menuFile, menuName);
        }
        #endregion
    }
}