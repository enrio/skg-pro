using System;
using System.Collections.Generic;

namespace PRE.Manage
{
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
            int sum;
            _dtb = _bll.Tra_Detail.GetInDepot(out sum);
            grcMain.DataSource = _dtb;
            Text = String.Format("Tổng số xe hiện có: {0}", sum.ToString("0"));
        }
    }
}