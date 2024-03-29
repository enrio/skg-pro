﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 02/06/2013 20:32
 * Status: OK
 */
#endregion

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Manage
{
    using SKG.Plugin;

    using DevExpress.XtraEditors;

    /// <summary>
    /// Danh sách xe tạm ra bến
    /// </summary>
    public partial class FrmTra_TempOut : FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_TempOut);
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
            if (dockManager1.ActivePanel == dockPanel1) // ds xe tạm ra bến
            {
                var tmpId = grvTempOut.GetFocusedRowCellValue("Id");
                if (tmpId == null)
                {
                    XtraMessageBox.Show("CHỌN DÒNG CẦN XOÁ\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var code = grvTempOut.GetFocusedRowCellValue("Code");
                var dateIn = grvTempOut.GetFocusedRowCellValue("DateIn") + "";
                dateIn = dateIn.Replace("AM", "SÁNG");
                dateIn = dateIn.Replace("PM", "CHIỀU");
                var id = (Guid)tmpId;

                if (id == new Guid()) XtraMessageBox.Show(STR_SELECT, STR_DELETE);
                else
                {
                    var cfm = String.Format(STR_CONFIRM, code + " VÀO LÚC " + dateIn);
                    var oki = XtraMessageBox.Show(cfm.ToUpper(), STR_DELETE, MessageBoxButtons.OKCancel);

                    if (oki == DialogResult.OK)
                        if (_bll.Tra_Detail.DeleteTempOut(id) != null) PerformRefresh();
                        else XtraMessageBox.Show(STR_UNDELETE, STR_DELETE);
                }
            }
            else // ds xe không đủ điều kiện
            {
                var tmpId = grvNotEnough.GetFocusedRowCellValue("Id");
                if (tmpId == null)
                {
                    XtraMessageBox.Show("CHỌN DÒNG CẦN XOÁ\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ",
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var code = grvNotEnough.GetFocusedRowCellValue("Code");
                var dateIn = grvNotEnough.GetFocusedRowCellValue("DateIn") + "";
                dateIn = dateIn.Replace("AM", "SÁNG");
                dateIn = dateIn.Replace("PM", "CHIỀU");
                var id = (Guid)tmpId;

                if (id == new Guid()) XtraMessageBox.Show(STR_SELECT, STR_DELETE);
                else
                {
                    var cfm = String.Format(STR_CONFIRM, code + " VÀO LÚC " + dateIn);
                    var oki = XtraMessageBox.Show(cfm.ToUpper(), STR_DELETE, MessageBoxButtons.OKCancel);

                    if (oki == DialogResult.OK)
                        if (_bll.Tra_Detail.DeleteNotEnough(id) != null) PerformRefresh();
                        else XtraMessageBox.Show(STR_UNDELETE, STR_DELETE);
                }
            }

            base.PerformDelete();
        }

        protected override void LoadData()
        {
            grcTempOut.DataSource = _bll.Tra_Detail.GetTempOut();
            grvTempOut.BestFitColumns();

            grcNotEnough.DataSource = _bll.Tra_Detail.GetTempOut(DAL.Tra_DetailDAL.Condition.NotEnough);
            grvNotEnough.BestFitColumns();

            base.LoadData();
        }
        #endregion

        #region Methods
        public FrmTra_TempOut()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(STR_PAN1);
            dockPanel2.SetDockPanel(STR_PAN2);

            grvNotEnough.SetStandard();
            grvTempOut.SetStandard();

            AllowAdd = false;
            AllowEdit = false;
            AllowSave = false;
            AllowCancel = false;
            AllowPrint = false;
        }
        #endregion

        #region Events
        private void FrmTra_InDepot_Activated(object sender, EventArgs e)
        {
            PerformRefresh();
        }

        private void grvNotEnough_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var code = grvNotEnough.GetFocusedRowCellValue("Code") + "";
                var id = (Guid)grvNotEnough.GetFocusedRowCellValue("Id");

                var frm = new Fixed.FrmTra_VehicleFixed()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    DataFilter = _bll.Tra_Vehicle.FindForFixed(id)
                };

                frm.DetailId = id;
                frm.AllowAdd = false;
                frm.ShowDialog();
            }
        }

        private void grvTempOut_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var code = grvTempOut.GetFocusedRowCellValue("Code") + "";
                var id = (Guid)grvTempOut.GetFocusedRowCellValue("Id");

                var frm = new Fixed.FrmTra_VehicleFixed()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    DataFilter = _bll.Tra_Vehicle.FindForFixed(id)
                };

                frm.DetailId = id;
                frm.AllowAdd = false;
                frm.ShowDialog();
            }
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_PAN1 = "XE TẠM RA BẾN";
        private const string STR_PAN2 = "XE K.ĐỦ Đ.KIỆN";

        private const string STR_TITLE = "Ds xe tạm ra bến";
        private const string STR_DELETE = "Xoá xe";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        #endregion
    }
}