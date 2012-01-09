using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace UTL.HSH
{
    public sealed class BamDul
    {
        static readonly string a = UTL.HSH.WinDow.ProcessorID();
        static readonly string b = UTL.HSH.WinDow.MACAddress();
        static readonly string c = UTL.HSH.WinDow.SerialNumber();

        private BamDul() { }

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
                catch (Exception ex) { CsoUTL.Show(ex.Message + ";", "Error!;Lỗi!"); }
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
                catch (Exception ex) { CsoUTL.Show(ex.Message + ";", "Error!;Lỗi!"); }
            }

            return res;
        }

        static string GetKey(string proId = null)
        {
            string f = GetSHA1Hash(a + b + c);

            if (proId != null) f = GetMD5Hash(proId); // lincense

            f = f.Substring(0, 25);
            string tmp = "";

            for (int i = 0; i < 5; i++)
            {
                tmp += f.Substring(i * 5, 5) + (i == 4 ? "" : "-");
            }

            return tmp;
        }

        public static string GetLincense(string proId = null)
        {
            if (proId == null) return GetKey(GetProuctId());
            else return GetKey(proId);
        }

        public static string GetProuctId() { return GetKey(); }

        public static bool isLincense(string key)
        {
            return true;
#if DEBUG
            return true;
#else
            string lic = GetLincense();
            if (key == lic) return true;
            return false;
#endif
        }
    }
}