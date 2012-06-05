using System;
using System.Windows.Forms;

namespace SKG
{
    public partial class FrmBauVlv : Form
    {
        public FrmBauVlv()
        {
            InitializeComponent();
        }

        private void FrmBauVlv_Load(object sender, EventArgs e)
        {
            mskProId.Text = UTL.HSH.BamDul.GetProuctId();
#if DEBUG
            mskKey.Text = UTL.HSH.BamDul.GetLincense();
#endif
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (UTL.HSH.BamDul.isLincense(mskKey.Text))
            {
                var key = new UTL.HSH.FawCdt();
                key.Write("Key", mskKey.Text);

                UTL.CsoUTL.Show("Mua thành công! Cám ơn bạn đã sử dụng phầm mềm!" + Environment.NewLine + "Xin hãy khởi động lại chương trình!");

                Close();
                Application.Exit();
            }
            else { UTL.CsoUTL.Show("Khoá bản quyền không đúng!"); }
        }
    }
}