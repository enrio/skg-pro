using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Station.InDepot
{
    using SKG.Plugin;

    /// <summary>
    /// Danh sách xe trong bến
    /// </summary>
    public partial class FrmTra_InDepotFixed : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Code = typeof(FrmTra_InDepotFixed).FullName, Parent = typeof(Level2).FullName, Text = "Xe cố định trong bến", Level = 3, Order = 28, Picture = @"Icons\InDepot.png" };
                return menu;
            }
        }
        #endregion

        public FrmTra_InDepotFixed()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

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

            var n = txtNumber.Text == "" ? null : txtNumber.Text.Trim();
            _dtb = _bll.Tra_Detail.GetInDepotFixed(n);

            Text = String.Format("Tổng số xe cố định trong bến: {0}", _dtb.Rows.Count.ToString("0")).ToUpper();
            lblSum.Text = Text;

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

        private void FrmTra_InDepot_Activated(object sender, EventArgs e)
        {
            PerformRefresh();
        }
    }
}