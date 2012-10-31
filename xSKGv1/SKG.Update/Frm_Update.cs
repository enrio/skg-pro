using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SKG.Update
{
    using System.Net;

    public partial class Frm_Update : Form
    {
        public Frm_Update()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            const string file = "Update.zip";
            string url = @"https://skg-pro.googlecode.com/svn/trunk/" + file;
            string path = Application.StartupPath;

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
            MessageBox.Show("Tải xong bản cập nhật!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}