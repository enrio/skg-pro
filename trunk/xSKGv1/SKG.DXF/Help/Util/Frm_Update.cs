#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 10/11/2012 21:48
 * Update: 10/11/2012 21:48
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SKG.DXF.Help.Util
{
    using System.IO;
    using System.Net;
    using SKG.Plugin;
    using System.Reflection;
    using System.Diagnostics;
    using ICSharpCode.SharpZipLib.Zip;

    public partial class Frm_Update : SKG.DXF.FrmMenuz
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(Frm_Update);
                var name = Global.GetIconName(type);

                var menu = new Menuz
                {
                    Code = type.FullName,
                    Parent = typeof(Level2).FullName,
                    Text = STR_TITLE,
                    Level = 1,
                    Order = 0,
                    Picture = String.Format(Global.STR_ICON, name)
                };
                return menu;
            }
        }
        #endregion

        #region Implements
        #endregion

        #region Overrides
        #endregion

        #region Methods
        public Frm_Update()
        {
            InitializeComponent();

            // create an objects that will manage our check for update process
            checkForUpdate = new CheckForUpdate(this);

            var curVer = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = String.Format("Phiên bản hiện tại: {0}\nCopyright © SKG 2012", curVer);

            //var file = String.Format(@"{0}\{1}", STR_PATH, STR_CLIENT);
            //var inf = new FileInfo(file);
            //lblNewVersion.Text = inf.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss");
            //_curr = inf.LastWriteTime;

            //var asm = Assembly.LoadFrom(file);
            //var ver = asm.GetName().Version;
            //lblCurrVersion.Text = ver.ToString();
            //_currVer = ver;
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
                MessageBox.Show(this, "Lỗi khi tìm bản mới nhất!", "Check for updates",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // compare the current version with the downloaded version number
            Version curVer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (curVer.CompareTo(versionInfo.latestVersion) >= 0)
            {
                // no new version
                MessageBox.Show(this, "Không có bản cập nhật mới nhất", "Check for updates",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            // new version found, ask the user if he wants to download the installer
            string str = String.Format("Phiên bản mới nhất!\nBản hiện tại: {0}.\nBản mới nhất: {1}.",
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
                MessageBox.Show(this, "Lỗi khi tải bản cập nhật mới nhất!", "Check for updates",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ask the user if he want to start the installer
            if (DialogResult.Yes != MessageBox.Show(this, "Có muốn cập nhật phiên bản mới nhất không?", "Check for updates",
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

            // unzip, exit the app and run new app
            try
            {
                Application.Restart();

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
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Lỗi khi cập nhật mới!", "Check for updates",
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
        #endregion

        #region Events
        private void Frm_Update_FormClosing(object sender, FormClosingEventArgs e)
        {
            // when the app is closing, this will stop the thread that checks for the
            // new version or downloads it
            this.checkForUpdate.StopThread();
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
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

        private void cmdUpdate_Click(object sender, EventArgs e)
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
        #endregion

        #region Properties
        #endregion

        #region Fields
        DateTime _curr, _new;
        Version _currVer, _newVer;
        private readonly CheckForUpdate checkForUpdate = null;
        #endregion

        #region Constants
        private const string STR_TITLE = "Cập nhật";

        private const string STR_ZIP = "Update.zip";
        private const string STR_CLIENT = "SKG.Client.exe";
        private string STR_PATH = Application.StartupPath;
        private const string STR_URL = @"https://skg-pro.googlecode.com/svn/trunk/Update/xSKGv1/";
        #endregion
    }
}