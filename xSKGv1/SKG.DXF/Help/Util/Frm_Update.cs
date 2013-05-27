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
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace SKG.DXF.Help.Util
{
    using System.Net;
    using System.Xml;
    using SKG.Plugin;
    using System.Reflection;
    using System.Diagnostics;
    using DevExpress.XtraEditors;

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

            var curVer = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = String.Format("Phiên bản hiện tại: {0}", curVer);
        }

        private VersionInfo DownloadVersion()
        {
            var i = new VersionInfo
            {
                error = true,
                installerUrl = "",
                homeUrl = "",
                date = ""
            };

            try
            {
                var reader = new XmlTextReader(STR_URL + STR_XML);
                reader.MoveToContent();
                string elementName = "";
                Version newVer = null;

                string url = "";
                string msiUrl = "";
                string date = "";

                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "appinfo"))
                    while (reader.Read())
                        if (reader.NodeType == XmlNodeType.Element) elementName = reader.Name;
                        else
                            if ((reader.NodeType == XmlNodeType.Text) && (reader.HasValue))
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
                                        date = reader.Value;
                                        break;
                                }
                reader.Close();

                i.error = false;
                i.latestVersion = newVer;
                i.homeUrl = url;
                i.installerUrl = msiUrl;
                i.date = date;

                return i;
            }
            catch { return i; }
        }
        #endregion

        #region Events
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarControl1.Text = "" + e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start(STR_UPDATE);
            Application.Exit();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            var i = DownloadVersion();

            if ((i.error) || (i.installerUrl.Length == 0) || (i.latestVersion == null))
            {
                XtraMessageBox.Show(this, "Lỗi khi tìm bản mới nhất!", "Check for updates",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Compare the current version with the downloaded version number
            Version curVer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (curVer.CompareTo(i.latestVersion) >= 0)
            {
                // No new version
                XtraMessageBox.Show(this, "Không có bản cập nhật mới nhất", "Check for updates",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            // New version found, ask the user if he wants to download the update
            string str = String.Format("Phiên bản mới nhất!\nBản hiện tại: {0}.\nBản mới nhất: {1}.",
                curVer, i.latestVersion);
            if (DialogResult.Yes == XtraMessageBox.Show(this, str, "Check for updates",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                var webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                webClient.DownloadFileAsync(new Uri(STR_URL + STR_ZIP), STR_PATH + STR_ZIP);
            }
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Cập nhật";

        private const string STR_XML = "version.xml";
        private const string STR_ZIP = "Update.zip";
        private const string STR_UPDATE = "SKG.Update.exe";

        private string STR_PATH = Application.StartupPath + @"\";
        private const string STR_URL = "https://xskgv1.googlecode.com/svn/trunk/DUL/NTG/Update/";
        #endregion
    }

    /// <summary>
    /// This struct will contain the info from the xml file
    /// </summary>
    public struct VersionInfo
    {
        public bool error;
        public Version latestVersion;
        public string installerUrl;
        public string homeUrl;
        public string date;
    }
}