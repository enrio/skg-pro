#region Information
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
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Sumary
{
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;

    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid.Views.BandedGrid;

    public partial class FrmTra_SalesNormal : FrmInput
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

        protected override void PerformEdit()
        {
            grvMain.OptionsBehavior.Editable = true;

            base.PerformEdit();
        }

        protected override void PerformPrint()
        {
            var dlg = new FrmRevenueNormal();
            var res = dlg.ShowDialog();

            decimal sum = 0;
            var fr = dteFrom.DateTime;
            var to = dteTo.DateTime;
            var frm = new FrmPrint();

            switch (res)
            {
                case DialogResult.OK: // bảng kê xe tải lưu đậu
                    var tb = _bll.Tra_Detail.GetRevenueNormal(out sum, fr, to, DAL.Tra_DetailDAL.Group.A);

                    var rpt1 = new Report.Rpt_RevenueNormal1
                    {
                        Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_n1",
                        Global.Session.User.Acc, Global.Session.Current),
                        DataSource = tb
                    };

                    rpt1.parTitle1.Value = Global.Title1;
                    rpt1.parTitle2.Value = Global.Title2;
                    rpt1.parUserOut.Value = Global.Session.User.Name;
                    rpt1.parDate.Value = to;
                    rpt1.xrcWatch.Text = String.Format("{0:HH:mm} - {1:HH:mm}", fr, to);
                    rpt1.xrcMoney.Text = sum.ToVietnamese("đồng");

                    frm.Text = String.Format("In: {0} - Số tiền: {1:#,0}", Text, sum);
                    frm.SetReport(rpt1);
                    break;

                case DialogResult.Yes: // bảng kê xe sang hàng
                    tb = _bll.Tra_Detail.GetRevenueNormal(out sum, fr, to, DAL.Tra_DetailDAL.Group.B);

                    var rpt2 = new Report.Rpt_RevenueNormal2
                    {
                        Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_n2",
                        Global.Session.User.Acc, Global.Session.Current),
                        DataSource = tb
                    };

                    rpt2.parTitle1.Value = Global.Title1;
                    rpt2.parTitle2.Value = Global.Title2;
                    rpt2.parUserOut.Value = Global.Session.User.Name;
                    rpt2.parDate.Value = to;
                    rpt2.xrcWatch.Text = String.Format("{0:HH:mm} - {1:HH:mm}", fr, to);
                    rpt2.xrcMoney.Text = sum.ToVietnamese("đồng");

                    frm.Text = String.Format("In: {0} - Số tiền: {1:#,0}", Text, sum);
                    frm.SetReport(rpt2);
                    break;

                case DialogResult.No: // bảng kê xe khách vãng lai
                    tb = _bll.Tra_Detail.GetRevenueNormal(out sum, fr, to, DAL.Tra_DetailDAL.Group.C);

                    var rpt3 = new Report.Rpt_RevenueNormal3
                    {
                        Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_n2",
                        Global.Session.User.Acc, Global.Session.Current),
                        DataSource = tb
                    };

                    rpt3.parTitle1.Value = Global.Title1;
                    rpt3.parTitle2.Value = Global.Title2;
                    rpt3.parUserOut.Value = Global.Session.User.Name;
                    rpt3.parDate.Value = to;
                    rpt3.xrcWatch.Text = String.Format("{0:HH:mm} - {1:HH:mm}", fr, to);
                    rpt3.xrcMoney.Text = sum.ToVietnamese("đồng");

                    frm.Text = String.Format("In: {0} - Số tiền: {1:#,0}", Text, sum);
                    frm.SetReport(rpt3);
                    break;

                case DialogResult.Cancel: // báo cáo
                    tb = _bll.Tra_Detail.SumaryReportNormal(out sum, fr, to);

                    var rpt4 = new Report.Rpt_ReportNormal
                    {
                        Name = String.Format(Level1.STR_DT,
                        Global.Session.User.Acc, Global.Session.Current),
                        DataSource = tb
                    };

                    var sub1 = new Report.Rpt_ReportNormal1() { DataSource = tb };
                    rpt4.xrSubreport1.ReportSource = sub1;

                    var sub2 = new Report.Rpt_ReportNormal2() { DataSource = tb };
                    rpt4.xrSubreport2.ReportSource = sub2;

                    rpt4.parTitle1.Value = Global.Title1;
                    rpt4.parTitle2.Value = Global.Title2;
                    rpt4.parNum.Value = Global.AuditNumber;
                    rpt4.parDate.Value = to;
                    rpt4.parTotal.Value = sum;
                    rpt4.parUserOut.Value = Global.Session.User.Name;

                    var count = tb.Compute("Sum(CountFullDay)", "").ToInt32()
                        + tb.Compute("Sum(CountHalfDay)", "").ToInt32();

                    var vote = tb.Compute("Sum(FullDay)", "").ToInt32()
                        + tb.Compute("Sum(HalfDay)", "").ToInt32();

                    rpt4.parCount.Value = tb == null ? 0 : count;
                    rpt4.parFullDay.Value = tb == null ? 0 : vote;

                    var duration = "(Từ {0} ngày {1} đến {2} ngày {3})";
                    duration = String.Format(duration,
                      fr.ToStringTimeVN(), fr.ToStringDateVN(),
                      to.ToStringTimeVN(), to.ToStringDateVN());
                    rpt4.xrlFromTo.Text = duration;

                    frm.Text = String.Format("In: {0} - Số tiền: {1:#,0}", Text, sum);
                    frm.SetReport(rpt4);
                    break;
            }

            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
        }

        protected override void LoadData()
        {
            var fr = dteFrom.DateTime;
            var to = dteTo.DateTime;

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

        protected override bool UpdateObject()
        {
            try
            {
                //if (!ValidInput()) return false;

                var tb = _dtb.GetChanges(DataRowState.Modified);
                foreach (DataRow r in tb.Rows)
                {
                    var id = (Guid)r["Id"];
                    var text = "" + r["Text"];

                    var o = new Tra_Detail()
                    {
                        Id = id,
                        Text = text
                    };

                    _bll.Tra_Detail.UpdateSeri(o);
                }
                return true;
            }
            catch { return false; }
        }
        #endregion

        #region Methods
        public FrmTra_SalesNormal()
        {
            InitializeComponent();

            Text = STR_TITLE;

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();

            AllowAdd = false;
            AllowRefresh = false;
            AllowFind = false;
            AllowPrint = true;

            var d = Global.Session.Current;
            cbeMonth.SelectedIndex = (int)d.ToMonth() - 1;

            DateTime fr, to;
            Session.CutShiftNormal(Global.Session.Current, out fr, out to);
            dteFrom.DateTime = fr;
            dteTo.DateTime = to;

            // Only allow edit on columns colSeri
            foreach (BandedGridColumn c in grvMain.Columns)
                c.OptionsColumn.ReadOnly = true;
            colSeri.OptionsColumn.ReadOnly = false;

            var ql = Global.Session.User.CheckAdmin() || Global.Session.User.CheckOperator();
            if (ql)
            {
                AllowRestore = true;
                AllowInvoice = true;
            }
        }
        #endregion

        #region Events
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
        #endregion

        #region Properties
        #endregion

        #region Fields
        decimal _sum = 0;
        #endregion

        #region Constants
        private const string STR_TITLE = "DOANH THU XE LƯU ĐẬU";
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