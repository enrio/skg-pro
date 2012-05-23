using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRE.Main
{
    using BLL;
    using DAL.Entities;

    public partial class FrmPol_UserRight : PRE.Catalog.FrmBase
    {
        public FrmPol_UserRight()
        {
            InitializeComponent();

            SetDockPanel(dockPanel1, "Nhập liệu");
            SetDockPanel(dockPanel2, "Danh sách");

            //grvMain.OptionsBehavior.Editable = false;
            _bll = new Pol_RightBLL();
        }
    }
}