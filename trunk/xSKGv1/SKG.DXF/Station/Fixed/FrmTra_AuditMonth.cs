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
using System.Windows.Forms;

namespace SKG.DXF.Station.Fixed
{

    using SKG.Extend;
    using SKG.Plugin;
    using System.Data;
    using DAL.Entities;

    public partial class FrmTra_AuditMonth : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(FrmTra_AuditMonth).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "THEO DÕI THÁNG",
                    Level = 3,
                    Order = 23,
                    Picture = @"Icons\Vehicle.png"
                };
                return menu;
            }
        }
        #endregion

        public string _num;

        public FrmTra_AuditMonth()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            AllowAdd = false;
            AllowDelete = false;
            AllowPrint = true;

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;

            grvMain.Appearance.BandPanel.Options.UseTextOptions = true;
            grvMain.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grvMain.Appearance.HeaderPanel.Options.UseTextOptions = true;
            grvMain.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            dteMonth.DateTime = Global.Session.Current;
        }

        private void dteMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PerformRefresh();
        }

        #region Override
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

                    var o = new Tra_Detail()
                    {
                        Id = id,
                        Guest = guest.ToInt32()
                    };

                    _bll.Tra_Detail.UpdateGuest(o);
                }
                return true;
            }
            catch { return false; }
        }

        public string num = "";
        protected override void LoadData()
        {
            var fr = dteMonth.DateTime.ToStartOfMonth();
            var to = dteMonth.DateTime.ToEndOfMonth();
            _dtb = _bll.Tra_Detail.GetForAuditFixed(fr, to);

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
            }

            base.LoadData();
        }

        protected override void PerformPrint()
        {
            var rpt = new Report.Rpt_Audit
            {
                Name = String.Format("{0}{1:_dd.MM.yyyy_HH.mm.ss}_td", Global.Session.User.Acc, Global.Session.Current)
            };

            rpt.parDate.Value = Global.Session.Current;
            rpt.DataSource = _bll.Tra_Detail.AuditMonthFixed();

            var frm = new FrmPrint();
            frm.SetReport(rpt);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();

            base.PerformPrint();
        }
        #endregion
    }
}