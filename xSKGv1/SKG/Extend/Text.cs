#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 16/06/2013 07:57
 * Status: OK
 */
#endregion

using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace SKG.Extend
{
    using Plugin;

    /// <summary>
    /// Text processing
    /// </summary>
    public static class Text
    {
        /// <summary>
        /// Ping
        /// </summary>
        /// <param name="s">Host name</param>
        /// <returns></returns>
        public static bool Ping(this string s)
        {
            try
            {
                if (s == ".") s = "127.0.0.1";

                var ping = new Ping();
                var reply = ping.Send(s);

                if (reply.Status == IPStatus.Success)
                {
                    //Console.WriteLine("Dia chi: {0}", reply.Address);
                    //Console.WriteLine("Thoi gian ping: {0}", reply.RoundtripTime);
                    //Console.WriteLine("Thoi gian song cua goi tin: {0}", reply.Options.Ttl);
                    //Console.WriteLine("khong phan manh: {0}", reply.Options.DontFragment);
                    //Console.WriteLine("Kich thuoc goi tin: {0}", reply.Buffer.Length);
                    //Console.WriteLine("Tinh trang: {0}", reply.Status);
                    //Console.ReadLine();

                    return true;
                }
                else
                {
                    //Console.WriteLine("Error");
                    //Console.WriteLine("Status: {0}", reply.Status);
                    //Console.ReadLine();

                    return false;
                }
            }
            catch { return false; }
        }

        #region Strings
        /// <summary>
        /// Format standard phone number
        /// </summary>
        /// <param name="s">Phone number</param>
        /// <returns></returns>
        public static string FormatPhoneNumber(this string s)
        {
            if (s != null)
            {
                s = s.Trim();
                s = s.Replace("+84", "0");
                s = s.Replace(" ", "");
            }

            return s;
        }

        /// <summary>
        /// Return string split by separate
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="sep">Separate</param>
        /// <param name="idx">Index</param>
        /// <returns></returns>
        public static string SplitIndex(this string str, char sep, int idx)
        {
            try
            {
                var sp = str.Split(new char[] { sep });
                return sp[idx];
            }
            catch { return null; }
        }

        /// <summary>
        /// Return list of string config as server name, database name, user and password
        /// </summary>
        /// <param name="str">String connection</param>
        /// <returns></returns>
        public static List<string> GetConfig(this string str)
        {
            var lst = new List<string>();
            var sp = str.Split(new char[] { ';' });

            switch (sp.Length)
            {
                case 3:
                    var a = sp[0];
                    a = a.SplitIndex('=', 1); // get server name
                    lst.Add(a);

                    var b = sp[1];
                    b = b.SplitIndex('=', 1); // get database name                    
                    lst.Add(b);
                    break;

                case 5:
                    a = sp[0];
                    a = a.SplitIndex('=', 1); // get server name
                    lst.Add(a);
                    b = sp[1];
                    b = b.SplitIndex('=', 1); // get database name
                    lst.Add(b);

                    var c = sp[3];
                    c = c.SplitIndex('=', 1); // get user
                    lst.Add(c);
                    var d = sp[4];
                    d = d.SplitIndex('=', 1); // get password
                    lst.Add(d);
                    break;

                default:
                    return null;
            }

            return lst;
        }

        /// <summary>
        /// Removing Vietnamese
        /// </summary>
        /// <param name="str">String</param>
        /// <returns></returns>
        public static string RemoveVN(this string str)
        {
            var regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            var strFormD = str.Normalize(NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

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
                s = s.Trim();
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
                s = s.Trim();
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
                s = s.Trim();
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
                s = s.Trim();
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
            int i = 0;
            Int32.TryParse(s, out  i);
            return i;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 64-bit signed integer
        /// </summary>
        /// <param name="s">Number</param>
        /// <returns></returns>
        public static long ToInt64(this string s)
        {
            long i = 0;
            Int64.TryParse(s, out  i);
            return i;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent double number
        /// </summary>
        /// <param name="s">Number</param>
        /// <returns></returns>
        public static double ToDouble(this string s)
        {
            double i = 0;
            Double.TryParse(s, out  i);
            return i;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent decimal number
        /// </summary>
        /// <param name="s">Number</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string s)
        {
            decimal i = 0;
            Decimal.TryParse(s, out  i);
            return i;
        }

        /// <summary>
        /// Converts the specified string representation of a logic value to an equivalent boolean
        /// </summary>
        /// <param name="s">Boolean value</param>
        /// <returns></returns>
        public static bool ToBoolean(this string s)
        {
            bool i = false;
            Boolean.TryParse(s, out  i);
            return i;
        }

        /// <summary>
        /// Converts the specified string representation of a date time value to an equivalent DateTime
        /// </summary>
        /// <param name="s">Date time</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string s)
        {
            var i = DateTime.Now;
            DateTime.TryParse(s, out  i);
            return i;
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
                              Text = s.Element("Text").Value,
                              Parent = s.Element("Parent").Value,
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
                        Text = s.Text,
                        Code = s.Code,
                        Parent = s.Parent,
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