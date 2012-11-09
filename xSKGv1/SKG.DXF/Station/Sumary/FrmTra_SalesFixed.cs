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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SKG.DXF.Station.Sumary
{
    using SKG.Extend;
    using SKG.Plugin;
    using SKG.Extend;
    using SKG.Plugin;
    using DevExpress.XtraEditors;

    public partial class FrmTra_SalesFixed : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(FrmTra_SalesFixed).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "Doanh thu xe cố định",
                    Level = 3,
                    Order = 28,
                    Picture = @"Icons\Sales.png"
                };
                return menu;
            }
        }
        #endregion

        public FrmTra_SalesFixed()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            AllowAdd = false;
            AllowEdit = false;
            //AllowDelete = false;
            AllowSave = false;
            AllowCancel = false;
            AllowFind = false;
            AllowPrint = true;

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;

            grvMain.Appearance.BandPanel.Options.UseTextOptions = true;
            grvMain.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grvMain.Appearance.HeaderPanel.Options.UseTextOptions = true;
            grvMain.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            var d = Global.Session.Current;
            cbeMonth.SelectedIndex = (int)d.ToMonth() - 1;

            dteFrom.DateTime = d.ToStartOfDay();
            dteTo.DateTime = d.ToEndOfDay();
        }

        #region Events
        private void cbeQuater_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = cbeQuater.SelectedIndex + 1;
            var b = Global.Session.Current.Year;

            dteFrom.DateTime = b.ToStartOfQuarter(a);
            dteTo.DateTime = b.ToEndOfQuarter(a);
        }

        private void cbeMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = cbeMonth.SelectedIndex + 1;
            var b = Global.Session.Current.Year;
            var c = b.ToStartOfMonth(a);

            cbeQuater.SelectedIndex = (int)c.ToQuarter() - 1;
            dteFrom.DateTime = c;
            dteTo.DateTime = b.ToEndOfMonth(a);
        }
        #endregion

        #region Override
        protected override void PerformDelete()
        {
            var tmpId = grvMain.GetFocusedRowCellValue("Id");
            if (tmpId == null)
            {
                XtraMessageBox.Show("KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ", Text);
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
            var rpt = new Report.Rpt_Fixed
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_cd",
                Global.Session.User.Acc, Global.Session.Current)
            };
            decimal sum = 0;

            // Ca làm việc
            DateTime shift;
            Global.Session.Shift(out shift);

            var end = dteTo.DateTime.ToEndOfDay();
            var start = dteFrom.DateTime.ToStartOfDay();

            rpt.xrlTitle.Text = "BẢNG KÊ DOANH THU XE KHÁCH BẾN XE NGÃ TƯ GA";
            rpt.xrlDuration.Text += "Từ ngày " + start.ToString("dd/MM/yyyy");
            rpt.xrlDuration.Text += " đến ngày " + end.ToString("dd/MM/yyyy");

            var tmp = shift.Date.ToString("A dd B MM C yyyy");
            tmp = tmp.Replace("A", "Ngày");
            tmp = tmp.Replace("B", "tháng");
            tmp = tmp.Replace("C", "nămy");
            rpt.xrcDate.Text = tmp;
            rpt.xrlCashier.Text = Global.Session.User.Name;

            rpt.DataSource = _bll.Tra_Detail.SumaryFixed(out sum, start, end);
            rpt.xrcMoney.Text = sum.ToVietnamese("đồng");

            var frm = new FrmPrint() { Text = String.Format("In: {0} - Số tiền: {1:#,#}", Text, sum) };
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
        }

        decimal _sum = 0;
        protected override void LoadData()
        {
            _dtb = _bll.Tra_Detail.SumaryFixed(out _sum, dteFrom.DateTime, dteTo.DateTime);

            grcMain.DataSource = _dtb;
            gridColumn2.BestFit(); // fit column STT
            gridColumn3.BestFit(); // fit column BSX
            gridColumn13.BestFit(); // fit column Kind

            base.LoadData();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            base.PerformRefresh();
        }
        #endregion

        private void FrmTra_Sales_Activated(object sender, EventArgs e)
        {
            PerformRefresh();
        }

        private const string STR_ADD = "Thêm xe";
        private const string STR_EDIT = "Sửa xe";
        private const string STR_DELETE = "Xoá xe";

        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_CONFIRM = "Có xoá xe '{0}' không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng.";
        private const string STR_DUPLICATE = "Xe này có rồi";

        private const string STR_NOT_V = "Chưa nhập biển số xe!";
        private const string STR_NOT_C = "Chưa nhập số ghế!";
        private const string STR_NOT_N = "Chưa nhập nốt tài/tháng!";
    }
}