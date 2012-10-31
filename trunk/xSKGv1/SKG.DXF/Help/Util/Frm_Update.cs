using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            MessageBox.Show("Tải xong bản cập nhật!", "Cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            
        }
    }
}