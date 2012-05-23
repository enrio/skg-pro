using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRE.Catalog
{
    using BLL;
    using DAL.Entities;

    public partial class FrmPol_Role : PRE.Catalog.FrmBase
    {
        public FrmPol_Role()
        {
            InitializeComponent();

            SetDockPanel(dockPanel1, "Nhập liệu");
            SetDockPanel(dockPanel2, "Danh sách");

            //grvMain.OptionsBehavior.Editable = false;
            _bll = new Pol_RoleBLL();
        }
    }
}