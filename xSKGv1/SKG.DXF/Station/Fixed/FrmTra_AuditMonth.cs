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
            grvMain.OptionsBehavior.Editable = !isReadOnly;

            base.ReadOnlyControl(isReadOnly);
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
            var frm = new FrmPrint();
            var oki = XtraMessageBox.Show(STR_CFM, STR_PRINT, MessageBoxButtons.YesNo);
            DateTime fr, to;
            Session.CutShiftMonth(dteMonth.DateTime, out fr, out to);

            if (oki == DialogResult.Yes)
            {
                var rpt = new Report.Rpt_AuditMonth
                {
                    Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_tdt",
                    Global.Session.User.Acc, Global.Session.Current)
                };

                rpt.DataSource = _bll.Tra_Detail.AuditMonthFixed(fr, to,
                    chkHideActive.Checked);
                rpt.xrlTitle.Text += dteMonth.DateTime.ToString(" MM/yyyy");

                rpt.parTitle1.Value = Global.Title1;
                rpt.parTitle2.Value = Global.Title2;
                rpt.parNum.Value = Global.AuditNumber;
                rpt.parDate.Value = Global.Session.Current;
                frm.SetReport(rpt);
            }
            else
            {
                var rpt = new Report.Rpt_AuditDay
                {
                    Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_tdt",
                    Global.Session.User.Acc, Global.Session.Current)
                };

                string inf = "";
                rpt.DataSource = _bll.Tra_Detail.AuditDayFixed(fr, to,
                    chkHideActive.Checked, out inf);
                rpt.xrlTitle.Text = rpt.xrlTitle.Text.Replace("NGÀY",
                    String.Format("THÁNG{0: MM/yyyy}", dteMonth.DateTime));

                rpt.parTitle1.Value = Global.Title2;
                rpt.parTitle2.Value = Global.Title3;
                rpt.parDate.Value = Global.Session.Current;
                rpt.parInf.Value = inf;
                frm.SetReport(rpt);
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
            AllowDelete = false;
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
        private const string STR_CFM = "IN THEO MẪU 1 (CHỌN YES), MẪU 2 (CHỌN NO)";
        private const string STR_PRINT = "In báo cáo";

        private const string STR_CHOICE = "CHỌN DÒNG CẦN SỬA\n\r HOẶC KHÔNG ĐƯỢC CHỌN NHÓM ĐỂ SỬA";
        #endregion
    }
}