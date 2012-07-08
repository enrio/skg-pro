using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.UTL.Hasher
{
    using System.IO;
    using System.Security.Cryptography;

    /// <summary>
    /// License processing
    /// </summary>
    public static class License
    {
        static readonly string a = Windows.ProcessorID();
        static readonly string b = Windows.MACAddress();
        static readonly string c = Windows.SerialNumber();

        /// <summary>
        /// Convert string to byte array
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns></returns>
        private static byte[] ConvertStringToByteArray(string data)
        {
            return (new UnicodeEncoding()).GetBytes(data);
        }

        /// <summary>
        /// Get file stream
        /// </summary>
        /// <param name="pathName">Path name</param>
        /// <returns></returns>
        private static FileStream GetFileStream(string pathName)
        {
            return (new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
        }

        /// <summary>
        /// Get SHA1 hash
        /// </summary>
        /// <param name="pathName">Path name</param>
        /// <param name="isFile">Is file</param>
        /// <returns></returns>
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

        /// <summary>
        /// Get MD5 hash
        /// </summary>
        /// <param name="pathName">Path name</param>
        /// <param name="isFile">Is file</param>
        /// <returns></returns>
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
        /// <param name="key">Is null lincense key else product key</param>
        /// <returns></returns>
        static string GetKey(string key = null)
        {
            string f;
            if (key != null) f = GetMD5Hash(key);
            else f = GetSHA1Hash(a + b + c); // lincense

            f = f.Substring(0, 25);
            string tmp = "";

            for (int i = 0; i < 5; i++)
                tmp += f.Substring(i * 5, 5) + (i == 4 ? "" : "-");
            return tmp;
        }

        /// <summary>
        /// Get license key
        /// </summary>
        /// <param name="key">Product key</param>
        /// <returns></returns>
        public static string GetLicenseKey(string key = null)
        {
            if (key == null) return GetKey(GetProuctKey());
            else return GetKey(key);
        }

        /// <summary>
        /// Get trial key
        /// </summary>
        /// <returns></returns>
        public static string GetTrialKey()
        {
            return GetKey("F7DF8-A184F-0X0X-AB15A-7C8AB");
        }

        /// <summary>
        /// Get product key
        /// </summary>
        /// <returns></returns>
        public static string GetProuctKey() { return GetKey(); }

        /// <summary>
        /// Check license
        /// </summary>
        /// <param name="k">License key</param>
        /// <returns></returns>
        public static LicState IsLincense(string k)
        {
            if (k == null) return LicState.None;
            var a = GetLicenseKey();
            var b = GetTrialKey();

            if (k == a) return LicState.Unlimited;
            else if (k == b) return LicState.Trial;
            return LicState.None;
        }
    }
}