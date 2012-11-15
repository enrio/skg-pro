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
        private const string STR_ZIP = "Update.zip";
        private const string STR_CLIENT = "SKG.Client.exe";
        private string STR_PATH = Application.StartupPath;
        private const string STR_URL = @"https://skg-pro.googlecode.com/svn/trunk/Update/xSKGv1/";

        DateTime _curr, _new;
        Version _currVer, _newVer;

        public Frm_Update()
        {
            InitializeComponent();

            var file = String.Format(@"{0}\{1}", STR_PATH, STR_CLIENT);
            var inf = new FileInfo(file);
            lblNewVersion.Text = inf.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss");
            _curr = inf.LastWriteTime;

            var asm = Assembly.LoadFrom(file);
            var ver = asm.GetName().Version;
            lblCurrVersion.Text = ver.ToString();
            _currVer = ver;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            #region Check new version
            var file = STR_URL + STR_CLIENT;
            var tmp = String.Format(@"{0}\_{1}", STR_PATH, STR_CLIENT);

            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri(file), tmp);

            var inf = new FileInfo(tmp);
            _new = inf.LastWriteTime;

            //var asm = Assembly.LoadFrom(tmp);
            //var ver = asm.GetName().Version;
            //lblCurrVersion.Text = ver.ToString();
            //_newVer = ver;
            #endregion

            // Perform update software
            if (_new > _curr && _newVer > _currVer)
            {
                webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri(STR_URL + STR_ZIP), String.Format(@"{0}\{1}", STR_PATH, STR_ZIP));
            }
            else MessageBox.Show("Đây là phiên bản mới nhất!", "Update",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(String.Format(@"{0}\{1}", STR_PATH, STR_ZIP))))
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