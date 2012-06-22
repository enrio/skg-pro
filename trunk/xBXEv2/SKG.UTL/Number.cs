using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL
{
    /// <summary>
    /// Numberic processing
    /// </summary>
    public static class Number
    {
        #region Years
        /// <summary>
        /// Return a start of year of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <returns></returns>
        public static DateTime ToStartOfYear(this int y)
        {
            return new DateTime(y, 1, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Return a end of year of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <returns></returns>
        public static DateTime ToEndOfYear(this int y)
        {
            return new DateTime(y, 12, 31, 23, 59, 59, 999);
        }
        #endregion

        #region Quarters
        /// <summary>
        /// Return a start of quarter of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <param name="q">Quarter</param>
        /// <returns></returns>
        public static DateTime ToStartOfQuarter(this int y, int q)
        {
            switch (q)
            {
                case 1: // 1st Quarter = January 1 to March 31
                    return new DateTime(y, 1, 1, 0, 0, 0, 0);

                case 2: // 2nd Quarter = April 1 to June 30
                    return new DateTime(y, 4, 1, 0, 0, 0, 0);

                case 3: // 3rd Quarter = July 1 to September 30
                    return new DateTime(y, 7, 1, 0, 0, 0, 0);

                default: // 4th Quarter = October 1 to December 31
                    return new DateTime(y, 10, 1, 0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Return a end of quarter of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <param name="q">Quarter</param>
        /// <returns></returns>
        public static DateTime ToEndOfQuarter(this int y, int q)
        {
            switch (q)
            {
                case 1: // 1st Quarter = January 1 to March 31
                    return new DateTime(y, 3, 31, 23, 59, 59, 999);

                case 2: // 2nd Quarter = April 1 to June 30
                    return new DateTime(y, 6, 30, 23, 59, 59, 999);

                case 3: // 3rd Quarter = July 1 to September 30
                    return new DateTime(y, 9, 30, 23, 59, 59, 999);

                default: // 4th Quarter = October 1 to December 31
                    return new DateTime(y, 12, 31, 23, 59, 59, 999);
            }
        }

        /// <summary>
        /// Return a quarter of this Month
        /// </summary>
        /// <param name="m">Month</param>
        /// <returns></returns>
        public static int ToQuarter(this int m)
        {
            if (m <= 3) return 1; // 1st Quarter = January 1 to March 31
            else if ((m >= 4) && (m <= 6)) return 2; // 2nd Quarter = April 1 to June 30
            else if ((m >= 7) && (m <= 9)) return 3; // 3rd Quarter = July 1 to September 30
            else return 4; // 4th Quarter = October 1 to December 31
        }
        #endregion

        #region Months
        /// <summary>
        /// Return a start of Month of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <param name="m">Month</param>
        /// <returns></returns>
        public static DateTime ToStartOfMonth(this int y, int m)
        {
            return new DateTime(y, m, 1, 0, 0, 0, 0);
        }

        /// <summary>
        /// Return a end of Month of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <param name="m">Month</param>
        /// <returns></returns>
        public static DateTime ToEndOfMonth(this int y, int m)
        {
            var a = DateTime.DaysInMonth(y, m);
            return new DateTime(y, m, a, 23, 59, 59, 999);
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
        public static bool CheckNumber(this int n, int min, int max)
        {
            if (n >= min && n <= max) return true;
            return false;
        }

        /// <summary>
        /// Check number between min & max
        /// </summary>
        /// <param name="n">Number</param>
        /// <param name="min">Minimum number</param>
        /// <param name="max">Maximum number</param>
        /// <returns></returns>
        public static bool CheckNumber(this long n, long min, long max)
        {
            if (n >= min && n <= max) return true;
            return false;
        }

        /// <summary>
        /// Check number between min & max
        /// </summary>
        /// <param name="n">Number</param>
        /// <param name="min">Minimum number</param>
        /// <param name="max">Maximum number</param>
        /// <returns></returns>
        public static bool CheckNumber(this double n, double min, double max)
        {
            if (n >= min && n <= max) return true;
            return false;
        }

        /// <summary>
        /// Check number between min & max
        /// </summary>
        /// <param name="n">Number</param>
        /// <param name="min">Minimum number</param>
        /// <param name="max">Maximum number</param>
        /// <returns></returns>
        public static bool CheckNumber(this decimal n, decimal min, decimal max)
        {
            if (n >= min && n <= max) return true;
            return false;
        }
        #endregion

        #region Converts
        /// <summary>
        /// Remove number zero
        /// </summary>
        /// <param name="n">Number</param>
        /// <returns></returns>
        private static string RemoveZero(this string n)
        {
            int vt = 0;
            while (n[vt].Equals('0')) vt++;
            return n.Substring(vt, n.Length - vt);
        }

        /// <summary>
        /// Converts number to Vietnamese
        /// </summary>
        /// <param name="n">Number</param>
        /// <returns></returns>
        private static string ToVietnamese(string n)
        {
            try
            {
                var res = "";
                if (n.Equals("0")) res = "không";
                else
                {
                    n = RemoveZero(n);
                    if (n[0].ToString().Equals("-"))
                    {
                        res = "âm ";
                        n = n.Substring(1, n.Length - 1);
                    }

                    if (n[0].ToString().Equals("+"))
                        n = n.Substring(1, n.Length - 1);

                    var arrNum = new string[10] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                    var arrDonvi = new string[4] { "", "ngàn", "triệu", "tỷ" };

                    string donvi;
                    int temp;
                    var strTemp = n;

                    int nLen;
                    nLen = strTemp.Length;

                    int i, vt;
                    int a;

                    for (i = 0; i < nLen; i++)
                    {
                        donvi = "";
                        vt = (nLen - i - 1) % 3;
                        a = int.Parse(strTemp.Substring(i, 1));

                        switch (a)
                        {
                            case 1:
                                if ((vt == 0) && (i > 0))
                                {
                                    if ((strTemp.Substring(i - 1, 1) != "1") && (strTemp.Substring(i - 1, 1) != "0"))
                                        arrNum[1] = "mốt";
                                    else arrNum[1] = "một";
                                }
                                else
                                {
                                    if (vt == 1) arrNum[1] = "mười";
                                    else arrNum[1] = "một";
                                }
                                break;

                            case 5:
                                if ((vt == 0) && (i != 0))
                                {
                                    if (strTemp.Substring(i - 1, 1) != "0") arrNum[5] = "lăm";
                                    else arrNum[5] = "năm";
                                }
                                else arrNum[5] = "năm";
                                break;

                            case 0:
                                arrNum[0] = "";
                                if (vt == 0 && nLen.Equals(1)) arrNum[0] = "không";
                                else if (vt == 1)
                                {
                                    if (strTemp.Substring(i + 1, 1) != "0")
                                        arrNum[0] = "lẻ";
                                }
                                else if (vt == 2)
                                {
                                    if ((strTemp.Substring(i + 1, 1) != "0") || (strTemp.Substring(i + 2, 1) != "0"))
                                        arrNum[0] = "không";
                                }
                                break;

                            default:
                                break;
                        }

                        switch (vt)
                        {
                            case 2:
                                if (i == 0)
                                    donvi = "trăm";
                                else if ((strTemp.Substring(i, 1) != "0") || (strTemp.Substring(i + 1, 1) != "0") || (strTemp.Substring(i + 2, 1) != "0"))
                                    donvi = "trăm";
                                break;
                            case 1:
                                if ((strTemp.Substring(i, 1) != "1") && (strTemp.Substring(i, 1) != "0"))
                                    donvi = "mươi";
                                break;

                            default:
                                temp = (nLen - i) / 3;
                                if (temp > 3) temp = temp % 3;
                                if (i > 2)
                                {
                                    if (strTemp.Substring(i - 2, 1) != "0" || strTemp.Substring(i - 1, 1) != "0" || strTemp.Substring(i, 1) != "0" || i == strTemp.Length)
                                        donvi = arrDonvi[temp];
                                }
                                else donvi = arrDonvi[temp];
                                break;
                        }

                        if (arrNum[a] == "") res = String.Format("{0} {1}", res.Trim(), donvi);
                        else res = String.Format("{0} {1} {2}", res.Trim(), arrNum[a], donvi);
                    }
                }

                return res.Trim();
            }
            catch { return String.Empty; }
        }

        /// <summary>
        /// Converts number to Vietnamese
        /// </summary>
        /// <param name="n">Number</param>
        /// <param name="curency">Money</param>
        /// <returns></returns>
        public static string ToVietnamese(this int n, string curency)
        {
            var a = ToVietnamese(n + "");
            return (String.Format("{0} {1}", a, curency)).ToUpperFirst();
        }

        /// <summary>
        /// Converts number to Vietnamese
        /// </summary>
        /// <param name="n">Number</param>
        /// <param name="curency">Money</param>
        /// <returns></returns>
        public static string ToVietnamese(this long n, string curency)
        {
            var a = ToVietnamese(n + "");
            return (String.Format("{0} {1}", a, curency)).ToUpperFirst();
        }

        /// <summary>
        /// Converts number to Vietnamese
        /// </summary>
        /// <param name="n">Number</param>
        /// <param name="curency">Money</param>
        /// <returns></returns>
        public static string ToVietnamese(this double n, string curency)
        {
            var a = n + "";
            var b = a.IndexOf(".") + a.IndexOf(",") + 1;
            var c = "";

            if (b > 0)
            {
                var s1 = a.Substring(0, b);
                var s2 = (a).Substring(b + 1, 2);

                if (s2 == "00") c = ToVietnamese(s1);
                else c = String.Format("{0} phẩy {1}", ToVietnamese(s1), ToVietnamese(s2));
            }
            else c = ToVietnamese(a);

            return (String.Format("{0} {1}", c, curency)).ToUpperFirst();
        }

        /// <summary>
        /// Converts number to Vietnamese
        /// </summary>
        /// <param name="n">Number</param>
        /// <param name="curency">Money</param>
        /// <returns></returns>
        public static string ToVietnamese(this decimal n, string curency)
        {
            var a = n + "";
            var b = a.IndexOf(".") + a.IndexOf(",") + 1;
            var c = "";

            if (b > 0)
            {
                var s1 = a.Substring(0, b);
                var s2 = (a).Substring(b + 1, 2);

                if (s2 == "00") c = ToVietnamese(s1);
                else c = String.Format("{0} phẩy {1}", ToVietnamese(s1), ToVietnamese(s2));
            }
            else c = ToVietnamese(a);

            return (String.Format("{0} {1}", c, curency)).ToUpperFirst();
        }
        #endregion
    }
}