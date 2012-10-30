﻿using System;
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

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            prbUpdate.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            string url = @"https://skg-pro.googlecode.com/svn/trunk/xSKGv1/Update/Update.zip";

            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(url), @"c:\Update.zip");
        }
    }
}