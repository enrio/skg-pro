#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 10/11/2012 16:32
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;

namespace SKG.DXF.Home.Sytem
{
    using SKG.Plugin;
    using System.Windows.Forms;
    using DevExpress.XtraEditors;

    public partial class FrmPol_Connection : SKG.DXF.FrmMenuz
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmPol_Connection);
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
        public FrmPol_Connection()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void tmrMain_Tick(object sender, EventArgs e)
        {
            _sec--;
            if (_sec < 0)
            {
                lblInfo.Text = "Đang kết nối ...";
                var ok = Datax.Base.PingToHost(Global.Connection.DataSource);
                if (!ok) lblInfo.Text = "Lỗi kết nối mạng cục bộ ...";
                if (Sample.IsNotConnect) lblInfo.Text = "Lỗi máy chủ cơ sở dữ liệu ...";
                _sec = 3;
            }
            else lblInfo.Text = String.Format("Tự động kết nối sau {0} giây", _sec);
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        private int _sec = 3;
        #endregion

        #region Constants
        private const string STR_TITLE = "Kết nối máy chủ";
        #endregion
    }
}