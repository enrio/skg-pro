using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace UTL
{
    public class CsoUTL
    {
        #region Open - Close CD
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi)]
        static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, IntPtr hwndCallback);
        public static void OpenCD() { mciSendString("set cdaudio door open", null, 0, IntPtr.Zero); }
        public static void CloseCD() { mciSendString("set cdaudio door closed", null, 0, IntPtr.Zero); }
        #endregion

        #region Linq
        public static DataTable Linq2Table<T>(IEnumerable<T> list, string tableName)
        {
            try
            {
                var tb = new DataTable(tableName);
                PropertyInfo[] pro = null;
                if (list == null) return tb;

                foreach (T rec in list)
                {
                    if (pro == null)
                    {
                        pro = ((Type)rec.GetType()).GetProperties();
                        foreach (var pi in pro)
                        {
                            Type colType = pi.PropertyType;
                            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                                colType = colType.GetGenericArguments()[0];
                            tb.Columns.Add(new DataColumn(pi.Name, colType));
                        }
                    }

                    DataRow dr = tb.NewRow();
                    foreach (var pi in pro) dr[pi.Name] = pi.GetValue(rec, null) ?? DBNull.Value;
                    tb.Rows.Add(dr);
                }
                return tb;
            }
            catch { return null; }
        }
        #endregion

        #region File & folder
        public static void DeleteSVN(DirectoryInfo dir)
        {
            if (dir.Name == ".svn")
            {
                EmptyFolder(dir);
            }
            else
            {
                foreach (DirectoryInfo sub in dir.GetDirectories())
                {
                    DeleteSVN(sub);
                }
            }
        }

        public static void DeleteSVN(DirectoryInfo dir, string delete)
        {
            if (dir.Name == delete)
            {
                EmptyFolder(dir);
            }
            else
            {
                foreach (DirectoryInfo sub in dir.GetDirectories())
                {
                    DeleteSVN(sub);
                }
            }
        }

        public static void DeleteSVN(string path)
        {
            var dir = new DirectoryInfo(path);
            DeleteSVN(dir);
        }

        #region Private method
        /// <summary>
        /// Delete all files in it after delete all folder in it later delete it
        /// </summary>
        /// <param name="dir">DirectoryInfo object</param>
        private static bool EmptyFolder(DirectoryInfo dir)
        {
            try
            {
                // Delete all files in it
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.IsReadOnly = false; file.Delete();
                }

                // Delete all folder in it
                foreach (DirectoryInfo sub in dir.GetDirectories())
                    EmptyFolder(sub);

                dir.Delete(); // delete it

                return true;
            }
            catch { return false; }
        }
        #endregion

        #region Public method
        public static bool EmptyFolder(string path) { return EmptyFolder(new DirectoryInfo(path)); }
        #endregion
        #endregion

        #region Hash
        public static string HashFile(string path)
        {
            try
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    using (SHA1Managed sha = new SHA1Managed())
                    {
                        byte[] checksum = sha.ComputeHash(stream);
                        return BitConverter.ToString(checksum).Replace("-", string.Empty);
                    }
                }
            }
            catch { return null; }
        }
        #endregion

        #region Check is number
        public static bool IsNumberR(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        public static bool IsNumberC(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        #endregion

        #region Show information
        public static void Show(string str, string title = "Thông báo;Information")
        {
            string[] s = str.Split(new char[] { ';' });
            string[] t = title.Split(new char[] { ';' });

            using (var x = new UTL.FRM.FrmYhvBbp { Infor = s[0], Text = t[0] })
            {
                x.ShowDialog();
            }
        }
        #endregion
    }
}