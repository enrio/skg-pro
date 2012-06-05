using System;
using System.Windows.Forms;

namespace BXE.PRE.YhwCcn
{
    public partial class FrmTkeVbq : Form, UTL.PLG.ItfPlg
    {
        public UTL.BLL.UecLajVei _sss = new UTL.BLL.UecLajVei();
        private readonly string _menu = "&Vào cổng";
        protected DAL.DetailDAL _dal = new DAL.DetailDAL();
        protected object _obj;

        public FrmTkeVbq()
        {
            InitializeComponent();
        }

        #region Implement plugin
        string UTL.PLG.ItfPlg.Name { get { return _menu; } }
        string UTL.PLG.ItfPlg.Description { get { return "Sumary vehicles in gate"; } }
        string UTL.PLG.ItfPlg.Author { get { return "Zng Tfy"; } }
        string UTL.PLG.ItfPlg.Version { get { return "1.0"; } }

        UserControl UTL.PLG.ItfPlg.Usrcontrol { get { return null; } }
        Form UTL.PLG.ItfPlg.Frmcontrol { get { return this; } }
        UTL.PLG.ItfHst UTL.PLG.ItfPlg.Host { get; set; }

        public UTL.BLL.UecLajVei Sss { get { return _sss; } set { _sss = value; } }
        public UTL.CsoInf Inf { get; set; }

        void UTL.PLG.ItfPlg.Initialize() { }
        void UTL.PLG.ItfPlg.Dispose() { }
        #endregion
    }
}