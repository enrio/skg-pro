#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 25/01/2012 21:07
 * Update: 26/09/2013 13:37
 * Status: OK
 */
#endregion

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Fixed
{
    using SKG.Plugin;
    using SKG.Extend;
    using DAL.Entities;

    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;

    public partial class FrmTra_FindInfo : FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_Province);
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
        protected override void PerformInvoice()
        {
            XtraMessageBox.Show("Chức năng này chưa có", "Tính tiền");
            base.PerformInvoice();
        }

        /// <summary>
        /// Phục hồi xe trạng thái xe trong bến
        /// </summary>
        protected override void PerformRestore()
        {
            var tmpId = grvMain.GetFocusedRowCellValue("Id");
            if (tmpId == null)
            {
                XtraMessageBox.Show(STR_CHOICE_R,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var code = grvMain.GetFocusedRowCellValue("Code");
            var dateIn = grvMain.GetFocusedRowCellValue("DateIn");
            var id = (Guid)tmpId;

            var cfm = String.Format(STR_CONFIRM_R, code + " VÀO LÚC " + dateIn);
            var oki = XtraMessageBox.Show(cfm.ToUpper(), STR_RESTORE, MessageBoxButtons.OKCancel);

            if (oki == DialogResult.OK)
                if (_bll.Tra_Detail.Restore(id)) PerformRefresh();
                else XtraMessageBox.Show(STR_UNRESTORE, STR_RESTORE);

            base.PerformRestore();
        }

        protected override void PerformFind()
        {
            _dtb = _bll.Tra_Detail.FindFixed(lueNumber.Text, lueTransport.Text, lueRoute.Text);

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                grvMain.BestFitColumns();
            }

            base.PerformFind();
        }

        protected override void PerformDelete()
        {
            var tmpId = grvMain.GetFocusedRowCellValue("Id");
            if (tmpId == null)
            {
                XtraMessageBox.Show(STR_CHOICE,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var code = grvMain.GetFocusedRowCellValue("Code");
            var dateIn = grvMain.GetFocusedRowCellValue("DateIn");
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
        #endregion

        #region Methods
        public FrmTra_FindInfo()
        {
            InitializeComponent();
            Text = STR_TITLE.ToUpper();

            AllowAdd = false;
            AllowEdit = false;
            AllowSave = false;
            AllowCancel = false;
            AllowFind = true;
            AllowRefresh = false;
            AllowPrint = false;

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();

            var ql = Global.Session.User.CheckAdmin() || Global.Session.User.CheckOperator();
            if (ql) AllowRestore = true;
        }
        #endregion

        #region Events
        private void grvMain_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var tmpId = grvMain.GetFocusedRowCellValue("Id");
                if (tmpId == null)
                {
                    XtraMessageBox.Show(STR_CHOICE,
                        Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                var id = (Guid)tmpId;
                var code = grvMain.GetFocusedRowCellValue("Code") + "";

                var frm = new FrmTra_VehicleFixed()
                {
                    StartPosition = FormStartPosition.CenterParent,
                    DataFilter = _bll.Tra_Vehicle.FindForFixed(id)
                };

                frm.DetailId = id;
                frm.AllowAdd = false;
                frm.ShowDialog();
                PerformRefresh();
            }
        }

        private void FrmTra_FindInfo_Load(object sender, EventArgs e)
        {
            lueNumber.Properties.DataSource = _bll.Tra_Vehicle.SelectForFixed(TermForFixed.Default);
            lueTransport.Properties.DataSource = _bll.Pol_Dictionary.SelectTransport();
            lueRoute.Properties.DataSource = _bll.Tra_Tariff.SelectForFixed();
        }

        private void lueNumber_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
                lueNumber.EditValue = null;
        }

        private void lueTransport_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
                lueTransport.EditValue = null;
        }

        private void lueRoute_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
                lueRoute.EditValue = null;
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Truy tìm";
        private const string STR_DELETE = "Xoá xe";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng";

        private const string STR_RESTORE = "Phục hồi";
        private const string STR_CONFIRM_R = "Có phục hồi xe '{0}' không?";
        private const string STR_UNRESTORE = "Không phục hồi được!";

        private const string STR_CHOICE = "CHỌN DÒNG CẦN SỬA\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ SỬA";
        private const string STR_CHOICE_R = "CHỌN DÒNG CẦN PHỤC HỒI\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ PHỤC HỒI";
        #endregion
    }
}