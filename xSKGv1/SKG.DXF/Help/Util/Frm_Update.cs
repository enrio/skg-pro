using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Help.Util
{
    using System.Net;

    public partial class Frm_Update : SKG.DXF.FrmMenuz
    {
        public Frm_Update()
        {
            InitializeComponent();
        }

        private void buttonDownloadFile_Click(object sender, EventArgs e)
        {
            string url = @"https://skg-pro.googlecode.com/svn/trunk/xSKGv1/Update/Update.zip";

            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("http://mysite.com/myfile.txt"), @"c:\myfile.txt");

            // Create an instance of WebClient
            WebClient client = new WebClient();
            // Hookup DownloadFileCompleted Event
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);

            // Start the download and copy the file to c:\temp
            client.DownloadFileAsync(new Uri(url), @"c:\Update.zip");
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("File downloaded");
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarControl1.EditValue = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }
    }
}