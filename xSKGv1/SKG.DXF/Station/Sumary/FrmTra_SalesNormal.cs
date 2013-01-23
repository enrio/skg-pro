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
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Sumary
{
    using SKG.Extend;
    using SKG.Plugin;
    using DevExpress.XtraEditors;

    public partial class FrmTra_SalesNormal : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_SalesNormal);
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

        protected override void PerformPrint()
        {
            LoadData();
            _dtb.Numbered();

            var rpt = new Report.Rpt_Normal
            {
                DataSource = _dtb,
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_vl",
                Global.Session.User.Acc, Global.Session.Current)
            };

            rpt.xrcMoney.Text = _sum.ToVietnamese("đồng");
            rpt.parDate.Value = Global.Session.Current;
            rpt.parUserOut.Value = Global.Session.User.Name;

            rpt.xrlSove.Visible = false;
            rpt.xrtSove.Visible = false;

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, _sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
        }

        protected override void LoadData()
        {
            var fr = dteFrom.DateTime.Date.AddHours(14).AddSeconds(1);
            var to = dteTo.DateTime.Date.AddHours(14);
            _dtb = _bll.Tra_Detail.SumaryNormal(out _sum, fr, to);

            grcMain.DataSource = _dtb;
            grvMain.BestFitColumns();

            base.LoadData();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            base.PerformRefresh();
        }
        #endregion

        #region Methods
        public FrmTra_SalesNormal()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();

            AllowAdd = false;
            AllowEdit = false;
            AllowSave = false;
            AllowCancel = false;
            AllowRefresh = false;
            AllowFind = false;
            AllowPrint = true;

            var d = Global.Session.Current;
            cbeMonth.SelectedIndex = (int)d.ToMonth() - 1;

            dteFrom.DateTime = d.AddDays(-1);
            dteTo.DateTime = d;

            var ql = Global.Session.User.CheckAdmin();
            if (!ql) cmdRestore.Visible = false;
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

        private void FrmTra_Sales_Activated(object sender, EventArgs e)
        {
            PerformRefresh();
        }

        private void cbeQuater_Validated(object sender, EventArgs e)
        {
            var a = cbeQuater.SelectedIndex + 1;
            var b = Global.Session.Current.Year;

            dteFrom.DateTime = b.ToStartOfQuarter(a).AddDays(-1);
            dteTo.DateTime = b.ToEndOfQuarter(a);
        }

        private void cbeMonth_Validated(object sender, EventArgs e)
        {
            var a = cbeMonth.SelectedIndex + 1;
            var b = Global.Session.Current.Year;
            var c = b.ToStartOfMonth(a).AddDays(-1);

            cbeQuater.SelectedIndex = (int)c.ToQuarter() - 1;
            dteFrom.DateTime = c;
            dteTo.DateTime = b.ToEndOfMonth(a);
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            PerformRefresh();
        }

        /// <summary>
        /// In bảng kê nhóm 1 - xe tải lưu đậu nhóm xe vãng lai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSumary1_Click(object sender, EventArgs e)
        {
            var rpt = new Report.Rpt_Normal
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_n1", Global.Session.User.Acc, Global.Session.Current)
            };
            decimal sum = 0;

            var fr = dteFrom.DateTime.Date.AddHours(14).AddSeconds(1);
            var to = dteTo.DateTime.Date.AddHours(14);
            rpt.DataSource = _bll.Tra_Detail.GetRevenueNormal(out sum, fr, to, DAL.Tra_DetailDAL.Group.A);

            rpt.parDate.Value = Global.Session.Current;
            rpt.parUserOut.Value = Global.Session.User.Name;
            rpt.xrcMoney.Text = sum.ToVietnamese("đồng");
            rpt.xrLabel1.Text = "BẢNG KÊ THU PHÍ LƯU ĐẬU XE TẢI";

            rpt.xrcLve1.Text = "15.000";
            rpt.xrcLve2.Text = "20.000";
            rpt.xrcLve3.Text = "25.000";
            rpt.xrcLve4.Text = "30.000";
            rpt.xrcLve5.Text = "35.000";

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        /// <summary>
        /// In bảng kê nhóm 2 - xe sang hàng nhóm xe vãng lai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSumary2_Click(object sender, EventArgs e)
        {
            var rpt = new Report.Rpt_Normal
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_n2", Global.Session.User.Acc, Global.Session.Current)
            };
            decimal sum = 0;

            var fr = dteFrom.DateTime.Date.AddHours(14).AddSeconds(1);
            var to = dteTo.DateTime.Date.AddHours(14);
            rpt.DataSource = _bll.Tra_Detail.GetRevenueNormal(out sum, fr, to, DAL.Tra_DetailDAL.Group.B);

            rpt.parDate.Value = Global.Session.Current;
            rpt.parUserOut.Value = Global.Session.User.Name;
            rpt.xrcMoney.Text = sum.ToVietnamese("đồng");
            rpt.xrLabel1.Text = "BẢNG KÊ THU PHÍ DỊCH VỤ XE SANG HÀNG";

            rpt.xrcLve1.Text = "5.000";
            rpt.xrcLve2.Text = "8.000";
            rpt.xrcLve3.Text = "10.000";
            rpt.xrcLve4.Text = "15.000";
            rpt.xrcLve5.Text = "";

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        /// <summary>
        /// Phục hồi xe trạng thái xe trong bến
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRestore_Click(object sender, EventArgs e)
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
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        decimal _sum = 0;
        #endregion

        #region Constants
        private const string STR_TITLE = "Doanh thu xe vãng lai";
        private const string STR_SELECT = "Chọn dữ liệu!";

        private const string STR_DELETE = "Xoá xe";
        private const string STR_CONFIRM = "Có xoá xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";

        private const string STR_RESTORE = "Phục hồi";
        private const string STR_CONFIRM_R = "Có phục hồi xe '{0}' không?";
        private const string STR_UNRESTORE = "Không phục hồi được!";

        private const string STR_CHOICE = "CHỌN DÒNG CẦN XOÁ\n\rHOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ";
        private const string STR_CHOICE_R = "CHỌN DÒNG CẦN PHỤC HỒI\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ PHỤC HỒI";
        #endregion
    }
}