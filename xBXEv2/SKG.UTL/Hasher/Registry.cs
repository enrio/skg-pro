using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.UTL.Hasher
{
    using System.IO;
    //using System.Windows.Forms;
    using System.Security.Cryptography;

    /// <summary>
    /// License processing
    /// </summary>
    public static class Registry
    {
        /// <summary>
        /// ID's this computer
        /// </summary>
        static readonly string a = Windows.ProcessorID();
        static readonly string b = Windows.MACAddress();
        static readonly string c = Windows.SerialNumber();

        private static byte[] ConvertStringToByteArray(string data)
        {
            return (new UnicodeEncoding()).GetBytes(data);
        }

        private static FileStream GetFileStream(string pathName)
        {
            return (new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
        }

        public static string GetSHA1Hash(string pathName, bool isFile = false)
        {
            string res = "";
            string strHashData = "";

            byte[] val;
            FileStream teu = null;

            using (var hsh = new SHA1CryptoServiceProvider())
            {
                try
                {
                    if (isFile)
                    {
                        teu = GetFileStream(pathName);
                        val = hsh.ComputeHash(teu);
                        teu.Close();
                        strHashData = BitConverter.ToString(val);
                    }
                    else
                    {
                        var b = Encoding.ASCII.GetBytes(pathName);
                        val = hsh.ComputeHash(b);
                        strHashData = BitConverter.ToString(val);
                    }

                    strHashData = strHashData.Replace("-", "");
                    res = strHashData;
                }
                catch { return null; }
            }

            return res;
        }

        public static string GetMD5Hash(string pathName, bool isFile = false)
        {
            string res = "";
            string strHashData = "";

            byte[] val;
            FileStream teu = null;

            using (var hsh = new MD5CryptoServiceProvider())
            {
                try
                {
                    if (isFile)
                    {
                        teu = GetFileStream(pathName);
                        val = hsh.ComputeHash(teu);
                        teu.Close();
                        strHashData = BitConverter.ToString(val);
                    }
                    else
                    {
                        var b = Encoding.ASCII.GetBytes(pathName);
                        val = hsh.ComputeHash(b);
                        strHashData = BitConverter.ToString(val);
                    }

                    strHashData = strHashData.Replace("-", "");
                    res = strHashData;
                }
                catch { return null; }
            }

            return res;
        }

        /// <summary>
        /// Get key (product or lincense key)
        /// </summary>
        /// <param name="proId">Is null the get lincense key else get product key</param>
        /// <returns>Key</returns>
        static string GetKey(string proId = null)
        {
            string f;

            if (proId != null) f = GetMD5Hash(proId);
            else f = GetSHA1Hash(a + b + c); // lincense

            f = f.Substring(0, 25);
            string tmp = "";

            for (int i = 0; i < 5; i++)
                tmp += f.Substring(i * 5, 5) + (i == 4 ? "" : "-");

            return tmp;
        }

        /// <summary>
        /// Get lincense key
        /// </summary>
        /// <param name="proId">Product key</param>
        /// <returns>Lincense key</returns>
        public static string GetLincense(string proId = null)
        {
            if (proId == null) return GetKey(GetProuctId());
            else return GetKey(proId);
        }

        /// <summary>
        /// Get trial key
        /// </summary>
        /// <returns>Trial key</returns>
        public static string GetTrial() { return GetKey("F7DF8-A184F-0X0X-AB15A-7C8AB"); }

        /// <summary>
        /// Get product key
        /// </summary>
        /// <returns>Product key</returns>
        public static string GetProuctId() { return GetKey(); }

        /// <summary>
        /// Check is lincense
        /// </summary>
        /// <param name="key">Product key</param>
        /// <returns>True is lincense else false</returns>
        public static License IsLincense(string key)
        {
            string licen = GetLincense();
            string trial = GetTrial();
            if (key == licen) return License.Unlimited;
            else if (key == trial) return License.Trial;
            return License.None;
        }
    }
}