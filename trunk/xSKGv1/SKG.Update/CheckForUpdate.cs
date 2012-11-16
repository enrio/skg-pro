using System;
using System.Linq;
using System.Collections.Generic;

namespace SKG.Update
{
    using System.IO;
    using System.Xml;
    using System.Net;
    using System.Threading;
    using System.Windows.Forms;

    #region Structs
    /// <summary>
    /// This struct will contain the info from the xml file
    /// </summary>
    public struct DownloadedVersionInfo
    {
        public bool error;
        public Version latestVersion;
        public string installerUrl;
        public string homeUrl;
    }

    /// <summary>
    /// This will contain info about the downloaded installer
    /// </summary>
    public struct DownloadInstallerInfo
    {
        public bool error;
        public string path;
    }
    #endregion

    #region Delegates
    /// <summary>
    /// Delegates (will forward the request to our Frm_Update)
    /// this of course could be done in a better (more flexible) way
    /// </summary>
    /// <param name="versionInfo">Information</param>
    /// <returns></returns>
    public delegate bool DelegateCheckForUpdateFinished(DownloadedVersionInfo versionInfo);

    /// <summary>
    /// Delegates (will forward the request to our Frm_Update)
    /// this of course could be done in a better (more flexible) way
    /// </summary>
    /// <param name="info">Information</param>
    public delegate void DelegateDownloadInstallerFinished(DownloadInstallerInfo info);
    #endregion

    /// <summary>
    /// Check for update new version of software
    /// </summary>
    class CheckForUpdate : IDisposable
    {
        private static string xmlFileUrl = "https://skg-pro.googlecode.com/svn/trunk/Update/xSKGv1/app_version.xml";

        private readonly Frm_Update mainApp;

        Thread m_WorkerThread;
        // events used to stop worker thread
        readonly ManualResetEvent m_EventStopThread;
        readonly ManualResetEvent m_EventThreadStopped;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mainApp != null)
                    mainApp.Dispose();
                if (m_EventStopThread != null)
                    m_EventStopThread.Dispose();
                if (m_EventThreadStopped != null)
                    m_EventThreadStopped.Dispose();
            }
        }

        ~CheckForUpdate()
        {
            Dispose(false);
        }

        public CheckForUpdate(Frm_Update mainApp)
        {
            this.mainApp = mainApp;
            m_EventStopThread = new ManualResetEvent(false);
            m_EventThreadStopped = new ManualResetEvent(false);
        }

        /// <summary>
        /// Start the check for update process (if it is not already running)
        /// </summary>
        public void OnCheckForUpdate()
        {
            if ((this.m_WorkerThread != null) && (this.m_WorkerThread.IsAlive)) return;
            m_WorkerThread = new Thread(this.CheckForUpdateFunction);
            m_EventStopThread.Reset();
            m_EventThreadStopped.Reset();
            m_WorkerThread.Start();
        }

        /// <summary>
        /// When the worker thread is running - let it know it should stop
        /// </summary>
        public void StopThread()
        {
            if ((this.m_WorkerThread != null) && this.m_WorkerThread.IsAlive)
            {
                m_EventStopThread.Set();
                while (m_WorkerThread.IsAlive)
                {
                    if (WaitHandle.WaitAll((new ManualResetEvent[] { m_EventThreadStopped }), 100, true))
                        break;
                    Application.DoEvents();
                }
            }
        }

        /// <summary>
        /// Internal method - return true when the thread is supposed to stop
        /// </summary>
        /// <returns></returns>
        private bool StopWorkerThread()
        {
            if (m_EventStopThread.WaitOne(0, true))
            {
                m_EventThreadStopped.Set();
                return true;
            }
            return false;
        }

        /// <summary>
        /// This is run in a thread. do the whole updating process:
        /// - check for the new version (downloading the xml file)
        /// - download the installer
        /// the communication with the Form is done with the delegates
        /// </summary>
        private void CheckForUpdateFunction()
        {
            DownloadedVersionInfo i = new DownloadedVersionInfo
            {
                error = true,
                installerUrl = "",
                homeUrl = ""
            };

            try
            {
                XmlTextReader reader = new XmlTextReader(xmlFileUrl);

                reader.MoveToContent();
                string elementName = "";
                Version newVer = null;

                string url = "";
                string msiUrl = "";
                if (StopWorkerThread()) return;

                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "appinfo"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element) elementName = reader.Name;
                        else
                        {
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
                            {
                                switch (elementName)
                                {
                                    case "version":
                                        newVer = new Version(reader.Value);
                                        break;
                                    case "url":
                                        url = reader.Value;
                                        break;
                                    case "installer":
                                        msiUrl = reader.Value;
                                        break;
                                    case "date":
                                        //elementName = elementName;
                                        break;
                                }
                            }
                        }
                    }
                }
                reader.Close();

                i.error = false;
                i.latestVersion = newVer;
                i.homeUrl = url;
                i.installerUrl = msiUrl;
            }
            catch (Exception) { }

            if (StopWorkerThread()) return;
            bool download = (bool)this.mainApp.Invoke(new DelegateCheckForUpdateFinished(mainApp.OnCheckForUpdateFinished), new Object[] { i });
            if (!download) return;

            // download and let the main thread know
            DownloadInstallerInfo i2 = new DownloadInstallerInfo { error = true };
            string filepath = "";
            try
            {
                WebRequest request = WebRequest.Create(i.installerUrl);
                WebResponse response = request.GetResponse();
                string filename = "";
                int contentLength = 0;
                for (int a = 0; a < response.Headers.Count; a++)
                {
                    try
                    {
                        string val = response.Headers.Get(a);

                        switch (response.Headers.GetKey(a).ToLower())
                        {
                            case "content-length":
                                contentLength = Convert.ToInt32(val);
                                break;
                            case "content-disposition":
                                string[] v2 = val.Split(';');
                                foreach (string s2 in v2)
                                {
                                    string[] v3 = s2.Split('=');
                                    if (v3.Length == 2)
                                    {
                                        if (v3[0].Trim().ToLower() == "filename")
                                        {
                                            char[] sss = { ' ', '"' };
                                            filename = v3[1].Trim(sss);
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    catch (Exception) { };
                }
                if (StopWorkerThread()) return;
                if (filename.Length == 0) filename = "installer.msi";
                filepath = Path.Combine(Path.GetTempPath(), filename);

                if (File.Exists(filepath))
                {
                    try
                    {
                        File.Delete(filepath);
                    }
                    catch { }

                    if (File.Exists(filepath))
                    {
                        string rname = Path.GetRandomFileName();
                        rname.Replace('.', '_');
                        rname += ".msi";
                        filepath = Path.Combine(Path.GetTempPath(), rname);
                    }
                }
                Stream stream = response.GetResponseStream();
                int pos = 0;
                byte[] buf2 = new byte[8192];
                FileStream fs = new FileStream(filepath, FileMode.CreateNew);
                while ((0 == contentLength) || (pos < contentLength))
                {
                    int maxBytes = 8192;
                    if ((0 != contentLength) && ((pos + maxBytes) > contentLength)) maxBytes = contentLength - pos;
                    int bytesRead = stream.Read(buf2, 0, maxBytes);
                    if (bytesRead <= 0) break;
                    fs.Write(buf2, 0, bytesRead);
                    if (StopWorkerThread()) return;
                    pos += bytesRead;
                }
                fs.Close();
                stream.Close();
                i2.error = false;
                i2.path = filepath;
            }
            catch
            {
                // when something goes wrong - at least do the cleanup :)
                if (filepath.Length > 0)
                {
                    try
                    {
                        File.Delete(filepath);
                    }
                    catch { }
                }
            }
            if (StopWorkerThread()) return;
            this.mainApp.BeginInvoke(new DelegateDownloadInstallerFinished(mainApp.OnDownloadInstallerinished), new Object[] { i2 });
        }
    }
}