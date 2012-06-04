using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRE.Manage
{
    /// <summary>
    /// Cổng ra
    /// </summary>
    public partial class FrmGateOut : PRE.Catalog.FrmBase
    {
        public FrmGateOut()
        {
            InitializeComponent();

            tmrMain.Enabled = true; // bật đồng hồ đếm giờ
            //lblUserIn.Text = BasePRE._sss.User.Name.ToUpper();

            SetDockPanel(dockPanel1, "Nhập liệu");
            SetDockPanel(dockPanel2, "Danh sách");

            //grvMain.OptionsView.ShowAutoFilterRow = true;
            //grvMain.OptionsBehavior.Editable = false;
        }
    }
}