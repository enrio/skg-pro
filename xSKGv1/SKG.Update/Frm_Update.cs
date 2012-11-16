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
        private readonly CheckForUpdate checkForUpdate = null;

        public Frm_Update()
        {
            InitializeComponent();

            // create an objects that will manage our check for update process
            checkForUpdate = new CheckForUpdate(this);

            //var file = String.Format(@"{0}\{1}", STR_PATH, STR_CLIENT);
            //var inf = new FileInfo(file);
            //lblNewVersion.Text = inf.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss");
            //_curr = inf.LastWriteTime;

            //var asm = Assembly.LoadFrom(file);
            //var ver = asm.GetName().Version;
            //lblCurrVersion.Text = ver.ToString();
            //_currVer = ver;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // start the check for update process
            checkForUpdate.OnCheckForUpdate();

            //#region Check new version
            //var file = STR_URL + STR_CLIENT;
            //var tmp = String.Format(@"{0}\_{1}", STR_PATH, STR_CLIENT);

            //WebClient webClient = new WebClient();
            //webClient.DownloadFileAsync(new Uri(file), tmp);

            //var inf = new FileInfo(tmp);
            //_new = inf.LastWriteTime;

            ////var asm = Assembly.LoadFrom(tmp);
            ////var ver = asm.GetName().Version;
            ////lblCurrVersion.Text = ver.ToString();
            ////_newVer = ver;
            //#endregion

            //// Perform update software
            //if (_new > _curr)
            //{
            //    webClient = new WebClient();
            //    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            //    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            //    webClient.DownloadFileAsync(new Uri(STR_URL + STR_ZIP), String.Format(@"{0}\{1}", STR_PATH, STR_ZIP));
            //}
            //else MessageBox.Show("Đây là phiên bản mới nhất!", "Update",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>
        /// this method is called when the checkForUpdate finishes checking
        /// for the new version. If this method returns true, our checkForUpdate
        /// object will download the installer
        /// </summary>
        /// <param name="versionInfo"></param>
        /// <returns></returns>
        public bool OnCheckForUpdateFinished(DownloadedVersionInfo versionInfo)
        {
            if ((versionInfo.error) || (versionInfo.installerUrl.Length == 0) || (versionInfo.latestVersion == null))
            {
                MessageBox.Show(this, "Error while looking for the newest version", "Check for updates",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // compare the current version with the downloaded version number
            Version curVer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (curVer.CompareTo(versionInfo.latestVersion) >= 0)
            {
                // no new version
                MessageBox.Show(this, "No new version detected", "Check for updates",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            // new version found, ask the user if he wants to download the installer
            string str = String.Format("New version found!\nYour version: {0}.\nNewest version: {1}.",
                curVer, versionInfo.latestVersion);
            return DialogResult.Yes == MessageBox.Show(this, str, "Check for updates",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Called after the checkForUpdate object downloaded the installer
        /// </summary>
        /// <param name="info"></param>
        public void OnDownloadInstallerinished(DownloadInstallerInfo info)
        {
            if (info.error)
            {
                MessageBox.Show(this, "Error while downloading the installer", "Check for updates",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ask the user if he want to start the installer
            if (DialogResult.Yes != MessageBox.Show(this, "Do you know to install the newest version?", "Check for updates",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                // it not - remove the downloaded file
                try
                {
                    File.Delete(info.path);
                }
                catch { }
                return;
            }

            // run the installer and exit the app
            try
            {
                //Process.Start(info.path);

                using (ZipInputStream s = new ZipInputStream(File.OpenRead(info.path)))
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

                //Close();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error while running the installer.", "Check for updates",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                try
                {
                    File.Delete(info.path);
                }
                catch { }
                return;
            }
            return;
        }

        private void Frm_Update_FormClosing(object sender, FormClosingEventArgs e)
        {
            // when the app is closing, this will stop the thread that checks for the
            // new version or downloads it
            this.checkForUpdate.StopThread();
        }
    }
}