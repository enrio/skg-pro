using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SKG.Update
{
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Diagnostics;
    using ICSharpCode.SharpZipLib.Zip;

    public partial class Frm_Update : Form
    {
        const string file = "Update.zip";
        string path = Application.StartupPath;

        public Frm_Update()
        {
            InitializeComponent();

            var file = String.Format(@"{0}\{1}", path, "SKG.Client.exe");
            var inf = new FileInfo(file);
            lblNewVersion.Text = inf.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss");

            var asm = Assembly.LoadFrom(file);
            var ver = asm.GetName().Version;
            lblCurrVersion.Text = ver.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string url = @"https://skg-pro.googlecode.com/svn/trunk/Update/xSKGv1/" + file;
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(url), String.Format(@"{0}\{1}", path, file));
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(String.Format(@"{0}\{1}", path, file))))
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

                Process.Start("SKG.Client.exe");
                Application.ExitThread();
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