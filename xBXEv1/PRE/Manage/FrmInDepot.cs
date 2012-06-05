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

    /// <summary>
    /// Danh sách xe trong bến
    /// </summary>
    public partial class FrmInDepot : PRE.Catalog.FrmBase
    {
        public FrmInDepot()
        {
            InitializeComponent();

            SetDockPanel(dockPanel1, "Nhập liệu");
            SetDockPanel(dockPanel2, "Danh sách");

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;            
        }

        private void FrmInDepot_Load(object sender, EventArgs e)
        {
            decimal sum;
            _dtb = _bll.Tra_Detail.GetInDepot(out sum);
            grcMain.DataSource = _dtb;
            Text = String.Format("Tổng số xe hiện có: {0}", sum.ToString("0"));
        }
    }
}