﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 25/01/2012 21:07
 * Update: 02/06/2013 21:07
 * Status: OK
 */
#endregion

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.InDepot
{
    using SKG.Plugin;

    using DevExpress.XtraEditors;
    using DevExpress.XtraBars.Docking;

    /// <summary>
    /// Danh sách xe trong bến
    /// </summary>
    public partial class FrmTra_InDepotFixed : FrmInput
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
            grvMain.BestFitColumns();

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

            dockPanel1.Visibility = DockVisibility.Hidden;
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();

            AllowAdd = false;
            AllowEdit = false;
            AllowSave = false;
            AllowCancel = false;
            AllowPrint = false;
        }
        #endregion

        #region Events
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