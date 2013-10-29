#region Information
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
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Fixed
{
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    public partial class FrmTra_AuditMonth : FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_AuditMonth);
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
        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            dteMonth.Properties.ReadOnly = !isReadOnly;
            radType.Properties.ReadOnly = !isReadOnly;
            chkHideActive.Properties.ReadOnly = !isReadOnly;

            grvMain.OptionsBehavior.Editable = !isReadOnly;

            base.ReadOnlyControl(isReadOnly);
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

        protected override void PerformSave()
        {
            if (_num + "" != "") Close();
            grvMain.CloseEditor();
            grvMain.UpdateCurrentRow();

            base.PerformSave();
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) return false;

                var tb = _dtb.GetChanges(DataRowState.Modified);
                foreach (DataRow r in tb.Rows)
                {
                    var id = (Guid)r["Id"];
                    var guest = "" + r["Guest"];
                    var discount = "" + r["Discount"];
                    var arrears = "" + r["Arrears"];

                    var o = new Tra_Detail()
                    {
                        Id = id,
                        Guest = guest.ToInt32(),
                        Discount = discount.ToInt32(),
                        Arrears = arrears.ToInt32()
                    };

                    _bll.Tra_Detail.UpdateMore(o);
                }
                return true;
            }
            catch { return false; }
        }

        public string num = "";
        protected override void LoadData()
        {
            DateTime fr, to;
            Session.CutShiftMonth(dteMonth.DateTime, out fr, out to);

            var isOut = (bool)radType.Properties.Items[radType.SelectedIndex].Value;
            _dtb = _bll.Tra_Detail.GetAuditFixed(fr, to, isOut);

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                grvMain.BestFitColumns();
            }

            base.LoadData();
        }

        protected override void PerformPrint()
        {
            var oki = XtraMessageBox.Show(STR_CFM,
                Level1.STR_PRINT, MessageBoxButtons.YesNo);

            var receipt = "";
            var frm = new FrmPrint();
            decimal sum = 0;

            DateTime fr, to;
            Session.CutShiftMonth(dteMonth.DateTime, out fr, out to);

            if (oki == DialogResult.Yes)
            {
                var rpt = new Report.Rpt_ReportFixed
                {
                    Name = String.Format(Level1.STR_DT,
                    Global.Session.User.Acc, Global.Session.Current),
                    DataSource = _bll.Tra_Detail.GetRevenueFixed(out sum, out receipt, fr, to)
                };

                rpt.parTitle1.Value = Global.Title1;
                rpt.parTitle2.Value = Global.Title2;
                rpt.parAddress.Value = Global.Address;
                rpt.parTaxcode.Value = Global.Taxcode;
                rpt.xrlTitle.Text = String.Format(rpt.xrlTitle.Text,
                    fr.ToStringDateVN(), to.ToStringDateVN());

                var duration = "(Từ {0} ngày {1} đến {2} ngày {3})";
                duration = String.Format(duration,
                  fr.ToStringTimeVN(), fr.ToStringDateVN(),
                  to.ToStringTimeVN(), to.ToStringDateVN());

                rpt.xrlFromTo.Text = duration;
                frm.SetReport(rpt);
            }
            else
            {
                var rpt4 = new Report.Rpt_AuditMonthSgtvt
                {
                    Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_tdt",
                    Global.Session.User.Acc, Global.Session.Current)
                };

                rpt4.DataSource = _bll.Tra_Detail.AuditMonthFixedSgtvt(fr, to);
                rpt4.xrlTitle.Text += dteMonth.DateTime.ToString(" MM/yyyy");

                rpt4.parTitle1.Value = Global.Title1;
                rpt4.parTitle2.Value = Global.Title2;
                rpt4.parNum.Value = Global.AuditNumber;
                rpt4.parDate.Value = Global.Session.Current;
                frm.SetReport(rpt4);
            }

            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
        }
        #endregion

        #region Methods
        public FrmTra_AuditMonth()
        {
            InitializeComponent();
            Text = STR_TITLE.ToUpper();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();

            AllowAdd = false;
            AllowPrint = true;

            dteMonth.DateTime = Global.Session.Current;
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

        private void dteMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PerformRefresh();
        }

        private void dteMonth_Validated(object sender, EventArgs e)
        {
            PerformRefresh();
        }

        private void FrmTra_AuditMonth_Activated(object sender, EventArgs e)
        {
            PerformRefresh();
        }

        private void radType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerformRefresh();
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        public string _num;
        #endregion

        #region Constants
        private const string STR_TITLE = "Theo dõi tháng";
        private const string STR_CFM = "BÁO CÁO THÁNG (CHỌN YES), BÁO CÁO SỞ (CHỌN NO)";
        private const string STR_PRINT = "In báo cáo";

        private const string STR_DELETE = "Xoá chi tiết ra/vào";
        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng!";
        private const string STR_CONFIRM = "Có xoá xe '{0}' không?";

        private const string STR_CHOICE = "CHỌN DÒNG CẦN XOÁ\n\rHOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ XOÁ";
        private const string STR_CHOICE_R = "CHỌN DÒNG CẦN PHỤC HỒI\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ PHỤC HỒI";
        #endregion
    }
}