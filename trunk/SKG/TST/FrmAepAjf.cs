using System;
using System.Windows.Forms;

namespace TST
{
    public partial class FrmAepAjf : Form
    {
        public FrmAepAjf()
        {
            InitializeComponent();
        }

        private void FrmAepAjf_Load(object sender, EventArgs e)
        {
            //using (var o = new FolderBrowserDialog())
            //{
            //    o.ShowDialog();
            //    UTL.TEU.CsoTEU.ReleaseSKG(o.SelectedPath);
            //}

            string tmp = Application.StartupPath;
            UTL.TEU.CsoTEU.ReleaseSKG(tmp.Substring(0, tmp.Length - 4));
        }
    }
}