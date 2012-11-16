#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 17/11/2012 00:01
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.Update
{
    using System.IO;
    using System.Threading;
    using System.Diagnostics;
    using ICSharpCode.SharpZipLib.Zip;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Thread.Sleep(2000);
                const string STR_ZIP = "Update.zip";
                const string STR_CLIENT = "SKG.Client.exe";
                string STR_PATH = Application.StartupPath;

                var fs = File.OpenRead(String.Format(@"{0}\{1}", STR_PATH, STR_ZIP));
                using (ZipInputStream s = new ZipInputStream(fs))
                {
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(theEntry.Name);
                        string fileName = Path.GetFileName(theEntry.Name);

                        // Create directory
                        if (directoryName.Length > 0)
                            Directory.CreateDirectory(directoryName);

                        if (fileName != String.Empty)
                        {
                            using (FileStream streamWriter = File.Create(theEntry.Name))
                            {
                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                        streamWriter.Write(data, 0, size);
                                    else break;
                                }
                            }
                        }
                    }
                }
                Process.Start(STR_CLIENT);
                Application.Exit();
            }
            catch
            {
                MessageBox.Show("Không cập nhật được!", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}