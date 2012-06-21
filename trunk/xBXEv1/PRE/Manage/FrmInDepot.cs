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

        #region Events
        #endregion

        #region Override
        protected override void LoadData()
        {
            int sum;

            _dtb = _bll.Tra_Detail.GetInDepot(out sum);
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
        #endregion
    }
}