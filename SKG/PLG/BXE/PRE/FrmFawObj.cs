using System;
using System.Windows.Forms;

namespace BXE.PRE
{
    public partial class FrmFawObj : UTL.FRM.FrmFawObj, UTL.PLG.ItfPlg
    {
        private const string STR_ERR_LOGIN = "Sai mật khẩu hoặc mã người dùng không có!;";
        private const string STR_LOGIN = "Đăng &nhập;";
        private readonly string _menu = STR_LOGIN.Replace(";", "");

        public FrmFawObj()
        {
            InitializeComponent();
        }

        #region Implement plugin
        string UTL.PLG.ItfPlg.Name { get { return _menu; } }
        string UTL.PLG.ItfPlg.Description { get { return "Login form"; } }
        string UTL.PLG.ItfPlg.Author { get { return "Zng Tfy"; } }
        string UTL.PLG.ItfPlg.Version { get { return "1.0"; } }

        UserControl UTL.PLG.ItfPlg.Usrcontrol { get { return null; } }
        Form UTL.PLG.ItfPlg.Frmcontrol { get { return this; } }
        UTL.PLG.ItfHst UTL.PLG.ItfPlg.Host { get; set; }

        public UTL.BLL.UecLajVei Sss
        {
            get { return null; }
            set { value = null; }
        }

        public UTL.CsoInf Inf
        {
            get { return null; }
            set { value = null; }
        }

        void UTL.PLG.ItfPlg.Initialize() { }
        void UTL.PLG.ItfPlg.Dispose() { }
        #endregion

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdOk_Click(sender, e);
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            var dal = new DAL.UserDAL();
            DAL.User usr = dal.GetPass(txtUser.Text);

            if (usr != null && usr.Pass == txtPass.Text)
            {
                _sss.Login = true;
                _sss.Id = usr.Id;
                _sss.Acc = usr.Acc;
                _sss.Pass = usr.Pass;
                _sss.Name = usr.Name;
                _sss.Role = (UTL.BLL.UecLajVei.Roles)usr.Role;
                _sss.Current = dal.CurrentTime();

                Close();
            }
            else
            {
                _sss.Login = false;
                UTL.CsoUTL.Show(STR_ERR_LOGIN, _menu.Replace("&", ""));
            }
        }

        private void FrmFawObj_Load(object sender, EventArgs e)
        {
            Text = _menu.Replace("&", "");

            txtUser.Text = null;
            txtPass.Text = null;

#if DEBUG
            txtUser.Text = "bv1"; txtPass.Text = txtUser.Text;
            txtUser.Text = "admin"; txtPass.Text = txtUser.Text;
            //txtUser.Text = "triet"; txtPass.Text = txtUser.Text;
#endif
            //txtUser.Focus();
        }

        public object GetSss()
        {
            return (object)_sss;
        }
    }
}