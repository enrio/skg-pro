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
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Fixed
{
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;

    public partial class FrmTra_AuditMonth : SKG.DXF.FrmInput
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
            switch (_state)
            {
                case State.Add:
                    if (InsertObject())
                    {
                        ResetInput(); LoadData();
                    }
                    break;

                case State.Edit:
                    if (UpdateObject())
                    {
                        ChangeStatus(); ReadOnlyControl();
                        PerformRefresh();
                    }
                    break;
            }
            if (_num + "" != "") Close();
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

                    var o = new Tra_Detail()
                    {
                        Id = id,
                        Guest = guest.ToInt32(),
                        Discount = discount.ToInt32()
                    };

                    _bll.Tra_Detail.UpdateGuestDiscount(o);
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
                gridColumn2.BestFit(); // fit column STT
            }

            base.LoadData();
        }

        protected override void PerformPrint()
        {
            var rpt = new Report.Rpt_AuditMonth
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_tdt", Global.Session.User.Acc, Global.Session.Current)
            };

            DateTime fr, to;
            Session.CutShiftMonth(dteMonth.DateTime, out fr, out to);

            rpt.DataSource = _bll.Tra_Detail.AuditMonthFixed(fr, to, chkHideActive.Checked);
            rpt.parDate.Value = Global.Session.Current;
            rpt.xrlTitle.Text += dteMonth.DateTime.ToString(" MM/yyyy");

            var frm = new FrmPrint();
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
        }
        #endregion

        #region Methods
        public FrmTra_AuditMonth()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();

            AllowAdd = false;
            AllowDelete = false;
            AllowRefresh = false;
            AllowPrint = true;

            dteMonth.DateTime = Global.Session.Current;
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
        #endregion
    }
}