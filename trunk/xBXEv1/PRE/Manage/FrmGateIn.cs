using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRE.Manage
{
    using BLL;
    using DAL.Entities;

    public partial class FrmGateIn : PRE.Catalog.FrmBase
    {
        public FrmGateIn()
        {
            InitializeComponent();

            lblUserIn.Text = BasePRE._sss.User.Name.ToUpper();

            SetDockPanel(dockPanel1, "Nhập liệu");
            SetDockPanel(dockPanel2, "Danh sách");

            grvMain.OptionsBehavior.Editable = false;
            _bll = new Tra_DetailBLL();
        }
    }
}