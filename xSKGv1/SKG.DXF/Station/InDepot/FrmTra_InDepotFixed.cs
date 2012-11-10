#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:17
 * Update: 08/11/2012 19:52
 * Status: OK
 */
#endregion

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.InDepot
{
    using SKG.Plugin;

    using DevExpress.Utils;
    using DevExpress.XtraEditors;

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
                var type = typeof(FrmTra_InDepotFixed);
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
        protected override void PerformRefresh()
        {
            LoadData();

            if (_dtb != null)
            {
                ClearDataBindings();
                if (_dtb.Rows.Count > 0) DataBindingControl();
            }

            ReadOnlyControl();

            base.PerformRefresh();
        }

        protected override void DataBindingControl()
        {
            //txtNumber.DataBindings.Add("EditValue", _dtb, ".Code");

            base.DataBindingControl();
        }

        protected override void ClearDataBindings()
        {
            //txtNumber.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void PerformDelete()
        {
            var tmpId = grvMain.GetFocusedRowCellValue("Id");
            if (tmpId == null)
            {
                XtraMessageBox.Show("CHỌN DÒNG CẦN XOÁ\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var code = grvMain.GetFocusedRowCellValue("Code");
            var dateIn = grvMain.GetFocusedRowCellValue("DateIn") + "";
            dateIn = dateIn.Replace("AM", "SÁNG");
            dateIn = dateIn.Replace("PM", "CHIỀU");
            var id = (Guid)tmpId;

            if (id == new Guid()) XtraMessageBox.Show(STR_SELECT, STR_DELETE);
            else
            {
                var cfm = String.Format(STR_CONFIRM, code + " VÀO LÚC " + dateIn);
                var oki = XtraMessageBox.Show(cfm.ToUpper(), STR_DELETE, MessageBoxButtons.OKCancel);

                if (oki == DialogResult.OK)
                    if (_bll.Tra_Detail.Delete(id) != null) PerformRefresh();
                    else XtraMessageBox.Show(STR_UNDELETE, STR_DELETE);
            }

            base.PerformDelete();
        }

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

        protected override void PerformFind()
        {
            LoadData();

            base.PerformFind();
        }
        #endregion

        #region Methods
        public FrmTra_InDepotFixed()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetGridViewStandard();

            AllowAdd = false;
            AllowEdit = false;
            AllowSave = false;
            AllowCancel = false;
            AllowPrint = false;
        }
        #endregion

        #region Events
        /// <summary>
        /// Numbered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvMain_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle < 0)
                {
                    return;
                }
                e.Info.DisplayText = "" + (e.RowHandle + 1);
                e.Handled = false;
            }
        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) PerformFind();
        }

        private void FrmTra_InDepot_Activated(object sender, EventArgs e)
        {
            PerformRefresh();
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Xe cố định trong bến";
        private const string STR_DELETE = "Xoá xe";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        #endregion
    }
}