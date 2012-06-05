using System;
using System.Windows.Forms;

namespace UTL.HSH
{
    public partial class FrmBauVlv : Form
    {
        public bool IsKey;

        public FrmBauVlv()
        {
            InitializeComponent();
        }

        private void FrmBauVlv_Load(object sender, EventArgs e)
        {
            if (IsKey)
            {
                lblInf.Text = "TẠO KHOÁ BẢN QUYỀN";
                mskKey.ReadOnly = !mskKey.ReadOnly;
                mskProId.ReadOnly = !mskProId.ReadOnly;
            }
            else
            {
                mskProId.Text = UTL.HSH.BamDul.GetProuctId();
#if DEBUG
                mskKey.Text = UTL.HSH.BamDul.GetLincense();
#endif
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (IsKey)
            {
                mskKey.Text = UTL.HSH.BamDul.GetLincense(mskProId.Text);
            }
            else
            {
                if (UTL.HSH.BamDul.isLincense(mskKey.Text))
                {
                    var key = new UTL.HSH.FawCdt();
                    key.Write("Key", mskKey.Text);

                    UTL.CsoUTL.Show(String.Format("Mua thành công! Cám ơn bạn đã sử dụng phầm mềm!{0}Xin hãy khởi động lại chương trình!", Environment.NewLine));

                    Close();
                    Application.Exit();
                }
                else { UTL.CsoUTL.Show("Khoá bản quyền không đúng!"); }
            }
        }
    }
}