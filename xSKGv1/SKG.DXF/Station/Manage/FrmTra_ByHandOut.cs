#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 12/11/2012 14:32
 * Status: OK
 */
#endregion

using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Manage
{
    using SKG.Datax;
    using SKG.Plugin;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    /// <summary>
    /// Input gate
    /// </summary>
    public partial class FrmTra_ByHandOut : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_ByHandOut);
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
        protected override void PerformAdd()
        {
            try
            {
                var file = Application.StartupPath + @"\Import\XuatBT.xls";

                _tbFixed = ImportData(file, "Codinh");
                InvoiceOut(_tbFixed.Rows);
                grcFixed.DataSource = _tbFixed;

                _tbNormal = ImportData(file, "Vanglai");
                InvoiceOut(_tbNormal.Rows);
                grcNormal.DataSource = _tbNormal;

                grvFixed.BestFitColumns();
                grvNormal.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
            }

            base.PerformAdd();
        }

        protected override void PerformSave()
        {
            try
            {
                int fix = 0, nor;
                var ql = Global.Session.User.CheckOperator() || Global.Session.User.CheckAdmin();

                if (ql && _tbFixed.Rows.Count > 0)
                {
                    var ok = XtraMessageBox.Show("XÁC NHẬN TẠM RA BẾN?", Text,
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ok == DialogResult.No)
                    {
                        fix = InvoiceOut(_tbFixed.Rows, true);
                        grcFixed.DataSource = _tbFixed;
                    }
                }

                nor = InvoiceOut(_tbNormal.Rows, null, true);
                grcNormal.DataSource = _tbNormal;

                XtraMessageBox.Show(String.Format(STR_INTO, fix, nor), Text);
                PerformCancel();

                grvFixed.BestFitColumns();
                grvNormal.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
            }

            base.PerformSave();
        }
        #endregion

        #region Methods
        public FrmTra_ByHandOut()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(STR_PAN1);
            dockPanel2.SetDockPanel(STR_PAN2);

            grvFixed.SetStandard();
            grvNormal.SetStandard();

            AllowEdit = false;
            AllowDelete = false;
            AllowRefresh = false;
        }

        /// <summary>
        /// Import data from excel file (by hand)
        /// </summary>
        /// <param name="fileName">File excel name</param>
        /// <param name="sheetName">Sheet name</param>
        /// <returns></returns>
        private DataTable ImportData(string fileName, string sheetName)
        {
            try
            {
                var tb = Excel.ImportFromExcel(fileName, sheetName);
                tb.Columns[0].ColumnName = "No_";
                tb.Columns[1].ColumnName = "Code";
                tb.Columns[2].ColumnName = "DateOut";

                tb.Columns.Add("UserIn");
                tb.Columns.Add("DateIn", typeof(DateTime));
                tb.Columns.Add("Phone");

                tb.Columns.Add("UserOut");
                tb.Columns.Add("Note");
                tb.Columns.Add("Tariff");

                tb.Columns.Add("Transport");
                tb.Columns.Add("Group");

                tb.Columns.Add("Seats");
                tb.Columns.Add("Beds");

                tb.Columns.Add("Cost", typeof(decimal));
                tb.Columns.Add("Rose", typeof(decimal));
                tb.Columns.Add("Parked", typeof(decimal));
                tb.Columns.Add("Money", typeof(decimal));
                return tb;
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        /// <summary>
        /// Invoice and out gate
        /// </summary>
        /// <param name="dtr">Data</param>
        /// <param name="isOut">Out gate</param>
        /// <returns></returns>
        private int InvoiceOut(DataRowCollection dtr, bool? isRepair = null, bool isOut = false)
        {
            try
            {
                int count = 0;
                foreach (DataRow r in dtr)
                {
                    var code = r["Code"] + "";
                    var date = Global.Session.Current;

                    if (!DateTime.TryParse(r["DateOut"] + "", out date))
                    {
                        r.RowError = STR_ERR_DATE;
                        r["Note"] = r.RowError;
                        continue;
                    }

                    var d = _bll.Tra_Detail.InvoiceOut(code, isOut, date, isRepair);
                    if (d == null)
                    {
                        r.RowError = STR_IN_DEPOT;
                        r["Note"] = r.RowError;

                        var v = (Tra_Vehicle)_bll.Tra_Vehicle.Select(code);
                        if (v == null)
                        {
                            r.RowError = STR_NO_LIST;
                            r["Note"] = r.RowError;
                        }
                        else
                        {
                            if (v.Tariff == null)
                            {
                                r.RowError = STR_NO_ROUTE;
                                r["Note"] = r.RowError;
                            }
                            else
                            {
                                r["Tariff"] = v.Tariff.Text;
                                r["Group"] = v.Tariff.Group.Text;
                                r["Transport"] = v.Transport == null ? "" : v.Transport.Text;

                                r["Seats"] = v.Seats;
                                r["Beds"] = v.Beds;
                            }
                        }
                    }
                    else
                    {
                        r["Tariff"] = d.Vehicle.Tariff.Text;
                        r["Group"] = d.Vehicle.Tariff.Group.Text;
                        r["Transport"] = d.Vehicle.Transport == null ? "" : d.Vehicle.Transport.Text;

                        r["Seats"] = d.Vehicle.Seats;
                        r["Beds"] = d.Vehicle.Beds;

                        r["DateOut"] = d.DateOut;

                        r["UserIn"] = d.UserIn.Name;
                        r["DateIn"] = d.DateIn;
                        r["Phone"] = d.UserIn.Phone;

                        r["Cost"] = d.Cost;
                        r["Rose"] = d.Rose;
                        r["Parked"] = d.Parked;
                        r["Money"] = d.Money;

                        // Thời gian xe ra < thời gian vào
                        if (d.Note != null)
                        {
                            r.RowError = d.Note;
                            r["Note"] = r.RowError;
                        }
                        else
                        {
                            if (isOut) r["Note"] = STR_EXIT;
                            count++;
                        }
                    }

                    r["UserOut"] = Global.Session.User.Name;
                }

                return count;
            }
            catch (Exception ex)
            {
#if DEBUG
                XtraMessageBox.Show(ex.Message);
#endif
                return -1;
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Numbered for vihicle fixed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvFixed_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        /// <summary>
        /// Numbered for vihicle normal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvNormal_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void FrmTra_ByHandOut_Load(object sender, EventArgs e)
        {
            PerformAdd();
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        /// <summary>
        /// List all of vihicle fixed
        /// </summary>
        private DataTable _tbFixed;

        /// <summary>
        /// List all of vihicle normal
        /// </summary>
        private DataTable _tbNormal;
        #endregion

        #region Constants
        private const string STR_TITLE = "Xuất xe bằng tay";

        private const string STR_NO_LIST = "CHƯA CÓ THÔNG TIN XE";
        private const string STR_NO_ROUTE = "CHƯA ĐĂNG KÍ TUYẾN";

        private const string STR_ERR_DATE = "THỜI GIAN NHẬP SAI";
        private const string STR_IN_DEPOT = "XE CHƯA VÀO BẾN";
        private const string STR_EXIT = "ĐÃ CHO XE RA";
        private const string STR_INTO = "SỐ LƯỢNG CHO RA\n\rXE CỐ ĐỊNH: {0}\n\rXE VÃNG LAI: {1}";

        public const string STR_PAN1 = "XE CỐ ĐỊNH";
        public const string STR_PAN2 = "XE VÃNG LAI";
        #endregion
    }
}