using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

            AllowAdd = false;
            AllowEdit = false;
            AllowDelete = false;
            AllowSave = false;
            AllowCancel = false;
            AllowPrint = false;

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;
        }

        #region Events
        private void txtNumber_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) PerformFind();
        }
        #endregion

        #region Override
        protected override void LoadData()
        {
            int sum;
            var n = txtNumber.Text == "" ? null : txtNumber.Text.Trim();

            _dtb = _bll.Tra_Detail.GetInDepot(out sum, n);
            Text = String.Format("Tổng số xe hiện có: {0}", sum.ToString("0"));

            grcMain.DataSource = _dtb;
            gridColumn2.BestFit(); // fit column STT
            gridColumn3.BestFit(); // fit column BSX
            gridColumn4.BestFit(); // fit column Chairs

            base.LoadData();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            base.PerformRefresh();
        }

        protected override void PerformFind()
        {
            LoadData();

            base.PerformFind();
        }
        #endregion
    }
}