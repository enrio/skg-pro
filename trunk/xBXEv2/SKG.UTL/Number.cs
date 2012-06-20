using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.UTL
{
    using System.Text.RegularExpressions;

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
        public static DateTime ToStartOfQuarter(this int y, Time.Quarter q)
        {
            switch (q)
            {
                case Time.Quarter.First: // 1st Quarter = January 1 to March 31
                    return new DateTime(y, 1, 1, 0, 0, 0, 0);

                case Time.Quarter.Second: // 2nd Quarter = April 1 to June 30
                    return new DateTime(y, 4, 1, 0, 0, 0, 0);

                case Time.Quarter.Third: // 3rd Quarter = July 1 to September 30
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
        public static DateTime ToEndOfQuarter(this int y, Time.Quarter q)
        {
            switch (q)
            {
                case Time.Quarter.First: // 1st Quarter = January 1 to March 31
                    return new DateTime(y, 3, 31, 23, 59, 59, 999);

                case Time.Quarter.Second: // 2nd Quarter = April 1 to June 30
                    return new DateTime(y, 6, 30, 23, 59, 59, 999);

                case Time.Quarter.Third: // 3rd Quarter = July 1 to September 30
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
        public static Time.Quarter ToQuarter(this int m)
        {
            if (m <= 3) return Time.Quarter.First; // 1st Quarter = January 1 to March 31
            else if ((m >= 4) && (m <= 6)) return Time.Quarter.Second; // 2nd Quarter = April 1 to June 30
            else if ((m >= 7) && (m <= 9)) return Time.Quarter.Third; // 3rd Quarter = July 1 to September 30
            else return Time.Quarter.Fourth; // 4th Quarter = October 1 to December 31
        }
        #endregion        

        /// <summary>
        /// Convert to int 32bit
        /// </summary>
        /// <param name="num">String need to convert</param>
        /// <returns>Number converted</returns>
        public static int ToInt32(string num)
        {
            if (IsNumberR(num)) return Convert.ToInt32(num);
            return 0;
        }

        /// <summary>
        /// Convert to int 64bit
        /// </summary>
        /// <param name="num">String need to convert</param>
        /// <returns>Number converted</returns>
        public static long ToInt64(string num)
        {
            if (IsNumberR(num)) return Convert.ToInt64(num);
            return 0;
        }

        /// <summary>
        /// Convert to decimal
        /// </summary>
        /// <param name="num">String need to convert</param>
        /// <returns>Number converted</returns>
        public static decimal ToDecimal(string num)
        {
            if (IsNumberR(num)) return Convert.ToDecimal(num);
            return 0;
        }

        /// <summary>
        /// Convert to double
        /// </summary>
        /// <param name="num">String need to convert</param>
        /// <returns>Number converted</returns>
        public static double ToDouble(string num)
        {
            if (IsNumberR(num)) return Convert.ToDouble(num);
            return 0;
        }

        /// <summary>
        /// Check text is number using Regex class
        /// </summary>
        /// <param name="num">String need to check</param>
        /// <returns>True if number else false</returns>
        public static bool IsNumberR(string num)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(num);
        }

        /// <summary>
        /// Check text is number using Char class
        /// </summary>
        /// <param name="num">String need to check</param>
        /// <returns>True if number else false</returns>
        public static bool IsNumberC(string num)
        {
            foreach (Char c in num)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Check number bettween min & max
        /// </summary>
        /// <param name="num">number need to check</param>
        /// <param name="min">ower limited</param>
        /// <param name="max">upper limited</param>
        /// <returns>is true if number bettween min & max else false</returns>
        public static bool CheckNumber(int num, int min, int max)
        {
            if (num >= min && num <= max) return true;
            return false;
        }

        /// <summary>
        /// Check number bettween min & max
        /// </summary>
        /// <param name="num">number need to check</param>
        /// <param name="min">ower limited</param>
        /// <param name="max">upper limited</param>
        /// <returns>is true if number bettween min & max else false</returns>
        public static bool CheckNumber(decimal num, decimal min, decimal max)
        {
            if (num >= min && num <= max) return true;
            return false;
        }

        /// <summary>
        /// Check number bettween min & max
        /// </summary>
        /// <param name="num">number need to check</param>
        /// <param name="min">ower limited</param>
        /// <param name="max">upper limited</param>
        /// <returns>is true if number bettween min & max else false</returns>
        public static bool CheckNumber(double num, double min, double max)
        {
            if (num >= min && num <= max) return true;
            return false;
        }

        /// <summary>
        /// Check number bettween min & max
        /// </summary>
        /// <param name="num">number need to check</param>
        /// <param name="min">ower limited</param>
        /// <param name="max">upper limited</param>
        /// <returns>is true if number bettween min & max else false</returns>
        public static bool CheckNumber(long num, long min, long max)
        {
            if (num >= min && num <= max) return true;
            return false;
        }

        /// <summary>
        /// Check number bettween min & max
        /// </summary>
        /// <param name="num">number need to check</param>
        /// <param name="min">ower limited</param>
        /// <param name="max">upper limited</param>
        /// <returns>is true if number bettween min & max else false</returns>
        public static bool CheckNumber(string num, int min, int max)
        {
            if (num.Trim() == "") num = "0";

            var oki = false;
            int sfi;

            if (Int32.TryParse(num, out sfi)) oki = CheckNumber(sfi, min, max);
            else oki = false;

            return oki;
        }

        /// <summary>
        /// Check number bettween min & max
        /// </summary>
        /// <param name="num">number need to check</param>
        /// <param name="min">ower limited</param>
        /// <param name="max">upper limited</param>
        /// <returns>is true if number bettween min & max else false</returns>
        public static bool CheckNumber(string num, decimal min, decimal max)
        {
            var oki = false;
            decimal sfi;

            if (Decimal.TryParse(num, out sfi)) oki = CheckNumber(sfi, min, max);
            else oki = false;

            return oki;
        }

        /// <summary>
        /// Check number bettween min & max
        /// </summary>
        /// <param name="num">number need to check</param>
        /// <param name="min">ower limited</param>
        /// <param name="max">upper limited</param>
        /// <returns>is true if number bettween min & max else false</returns>
        public static bool CheckNumber(string num, double min, double max)
        {
            var oki = false;
            double sfi;

            if (Double.TryParse(num, out sfi)) oki = CheckNumber(sfi, min, max);
            else oki = false;

            return oki;
        }

        /// <summary>
        /// Check number bettween min & max
        /// </summary>
        /// <param name="num">number need to check</param>
        /// <param name="min">ower limited</param>
        /// <param name="max">upper limited</param>
        /// <returns>is true if number bettween min & max else false</returns>
        public static bool CheckNumber(string num, long min, long max)
        {
            var oki = false;
            long sfi;

            if (Int64.TryParse(num, out sfi)) oki = CheckNumber(sfi, min, max);
            else oki = false;

            return oki;
        }

        /// <summary>
        /// Convert number to Vietnamese string
        /// </summary>
        /// <param name="num">Number need to convert</param>
        /// <returns>Vietnamese string</returns>
        private static string Num2Vi(string num)
        {
            try
            {
                string strResult;
                strResult = "";

                if (num.Equals("0")) strResult = "không";
                else
                {
                    num = RemoveNumberZero(num);
                    if (num[0].ToString().Equals("-"))
                    {
                        strResult = "âm ";
                        num = num.Substring(1, num.Length - 1);
                    }
                    if (num[0].ToString().Equals("+"))
                    {
                        num = num.Substring(1, num.Length - 1);
                    }
                    string[] arrayNumStr = new string[10]{
						"không","một","hai","ba","bốn",
						"năm","sáu","bảy","tám","chín"
				};

                    string[] arrayDonVi = new string[4] { "", "ngàn", "triệu", "tỷ" };

                    string strDonVi;
                    int temp;

                    string strTemp;
                    strTemp = num;

                    int nLen;
                    nLen = strTemp.Length;

                    int i, vt;
                    int a;

                    for (i = 0; i < nLen; i++)
                    {
                        strDonVi = "";
                        vt = (nLen - i - 1) % 3;
                        a = int.Parse(strTemp.Substring(i, 1));

                        switch (a)
                        {
                            case 1:
                                if ((vt == 0) && (i > 0))
                                {
                                    if ((strTemp.Substring(i - 1, 1) != "1") && (strTemp.Substring(i - 1, 1) != "0"))
                                        arrayNumStr[1] = "mốt";
                                    else arrayNumStr[1] = "một";
                                }
                                else
                                {
                                    if (vt == 1) arrayNumStr[1] = "mười";
                                    else arrayNumStr[1] = "một";
                                }
                                break;

                            case 5:
                                if ((vt == 0) && (i != 0))
                                {
                                    if (strTemp.Substring(i - 1, 1) != "0") arrayNumStr[5] = "lăm";
                                    else arrayNumStr[5] = "năm";
                                }
                                else arrayNumStr[5] = "năm";
                                break;

                            case 0:
                                arrayNumStr[0] = "";
                                if (vt == 0 && nLen.Equals(1)) arrayNumStr[0] = "không";
                                else if (vt == 1)
                                {
                                    if (strTemp.Substring(i + 1, 1) != "0")
                                        arrayNumStr[0] = "lẻ";
                                }
                                else if (vt == 2)
                                {
                                    if ((strTemp.Substring(i + 1, 1) != "0") || (strTemp.Substring(i + 2, 1) != "0"))
                                        arrayNumStr[0] = "không";
                                }
                                break;

                            default:
                                break;
                        }

                        switch (vt)
                        {
                            case 2:
                                if (i == 0)
                                    strDonVi = "trăm";
                                else if ((strTemp.Substring(i, 1) != "0") ||
                                    (strTemp.Substring(i + 1, 1) != "0") ||
                                    (strTemp.Substring(i + 2, 1) != "0"))
                                    strDonVi = "trăm";
                                break;
                            case 1:
                                if ((strTemp.Substring(i, 1) != "1") && (strTemp.Substring(i, 1) != "0"))
                                    strDonVi = "mươi";
                                break;

                            default:
                                temp = (nLen - i) / 3;
                                if (temp > 3) temp = temp % 3;
                                if (i > 2)
                                {
                                    if (strTemp.Substring(i - 2, 1) != "0" ||
                                        strTemp.Substring(i - 1, 1) != "0" ||
                                        strTemp.Substring(i, 1) != "0" ||
                                        i == strTemp.Length)
                                        strDonVi = arrayDonVi[temp];
                                }
                                else strDonVi = arrayDonVi[temp];
                                break;
                        }

                        if (arrayNumStr[a] == "") strResult = String.Format("{0} {1}", strResult.Trim(), strDonVi);
                        else strResult = String.Format("{0} {1} {2}", strResult.Trim(), arrayNumStr[a], strDonVi);
                    }

                }

                return strResult.Trim();
            }
            catch { return null; }
        }

        /// <summary>
        /// Change number to Vietnamese
        /// </summary>
        /// <param name="num">Number need to change</param>
        /// <param name="curency">Kind of money</param>
        /// <returns>Vietnamese money string</returns>
        public static string ChangeNum2VNStr(decimal num, string curency)
        {
            string strTemp = num.ToString();
            int daucham = strTemp.IndexOf(".") + strTemp.IndexOf(",") + 1;
            var res = "";

            if (daucham > 0)
            {
                var s1 = strTemp.Substring(0, daucham);
                var s2 = (strTemp).Substring(daucham + 1, 2);

                if (s2 == "00") res = Num2Vi(s1);
                else res = String.Format("{0} phẩy {1}", Num2Vi(s1), Num2Vi(s2));
            }
            else res = Num2Vi(strTemp);
            var x = res.ToUpperInvariant();

            return Text.ToUpperFirst(res + " " + curency);
        }

        /// <summary>
        /// Remove number zero
        /// </summary>
        /// <param name="num">Number need to remove</param>
        /// <returns>Number removed</returns>
        public static string RemoveNumberZero(string num)
        {
            int vt = 0;
            while (num[vt].Equals('0')) vt++;
            return num.Substring(vt, num.Length - vt);
        }
    }
}