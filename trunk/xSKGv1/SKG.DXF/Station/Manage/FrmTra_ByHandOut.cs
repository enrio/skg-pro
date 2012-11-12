﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 10/11/2012 16:32
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
            var open = new OpenFileDialog { Filter = "Excel file (*.xls)|*.xls" };
            open.ShowDialog();

            if (open.FileName == "" || !open.CheckFileExists)
            {
                PerformCancel();
                return;
            }

            #region Fixed
            _tbFixed = ImportData(open.FileName, "Codinh");
            foreach (DataRow r in _tbFixed.Rows)
            {
                var bs = r["Code"] + "";
                var dt = Global.Session.Current;

                if (!DateTime.TryParse(r["DateOut"] + "", out dt))
                {
                    r.RowError = STR_ERR_DATE;
                    r["Note"] = r.RowError;
                    continue;
                }

                var det = _bll.Tra_Detail.InvoiceOut(bs, false, dt);
                if (det == null)
                {
                    r.RowError = STR_IN_DEPOT;
                    r["Note"] = r.RowError;

                    var ve = (Tra_Vehicle)_bll.Tra_Vehicle.Select(bs);

                    if (ve == null)
                    {
                        r.RowError = STR_NO_LIST;
                        r["Note"] = r.RowError;
                    }
                    else
                    {
                        if (ve.Fixed)
                        {
                            if (ve.Tariff == null)
                            {
                                r.RowError = STR_NO_ROUTE;
                                r["Note"] = r.RowError;
                            }
                            else
                            {
                                r["Tariff"] = ve.Tariff.Text;
                                r["Transport"] = ve.Transport == null ? "" : ve.Transport.Text;

                                r["Seats"] = ve.Seats ?? 0;
                                r["Beds"] = ve.Beds ?? 0;
                            }
                        }
                        else
                        {
                            r.RowError = STR_NORMAL;
                            r["Note"] = r.RowError;
                        }
                    }
                }
                else
                {
                    r["Tariff"] = det.Vehicle.Tariff.Text;
                    r["Transport"] = det.Vehicle.Transport.Text;

                    r["Seats"] = det.Vehicle.Seats ?? 0;
                    r["Beds"] = det.Vehicle.Beds ?? 0;

                    r["UserOut"] = Global.Session.User.Name;

                    r["UserIn"] = det.UserIn.Name;
                    r["DateIn"] = det.DateIn;
                    r["Phone"] = det.UserIn.Phone;

                    r["Cost"] = det.Cost;
                    r["Rose"] = det.Rose;
                    r["Parked"] = det.Parked;
                    r["Money"] = det.Money;
                }
            }
            grcFixed.DataSource = _tbFixed;
            #endregion

            #region Normal
            _tbNormal = ImportData(open.FileName, "Vanglai");
            foreach (DataRow r in _tbNormal.Rows)
            {
                var bs = r["Code"] + "";
                var dt = Global.Session.Current;

                if (!DateTime.TryParse(r["DateOut"] + "", out dt))
                {
                    r.RowError = STR_ERR_DATE;
                    r["Note"] = r.RowError;
                    continue;
                }

                var det = _bll.Tra_Detail.InvoiceOut(bs, false, dt);
                if (det == null)
                {
                    r.RowError = STR_IN_DEPOT;
                    r["Note"] = r.RowError;

                    var ve = (Tra_Vehicle)_bll.Tra_Vehicle.Select(bs);

                    if (ve == null)
                    {
                        r.RowError = STR_NO_LIST;
                        r["Note"] = r.RowError;
                    }
                    else
                    {
                        if (!ve.Fixed)
                        {
                            r["Tariff"] = ve.Tariff.Text;
                            r["Transport"] = ve.Transport == null ? "" : ve.Transport.Text;

                            r["Seats"] = ve.Seats ?? 0;
                            r["Beds"] = ve.Beds ?? 0;
                        }
                        else
                        {
                            r.RowError = STR_FIXED;
                            r["Note"] = r.RowError;
                        }
                    }
                }
                else
                {
                    r["Tariff"] = det.Vehicle.Tariff.Text;
                    r["Group"] = det.Vehicle.Tariff.Group.Text;

                    r["Seats"] = det.Vehicle.Seats ?? 0;
                    r["Beds"] = det.Vehicle.Beds ?? 0;

                    r["UserOut"] = Global.Session.User.Name;

                    r["UserIn"] = det.UserIn.Name;
                    r["DateIn"] = det.DateIn;
                    r["Phone"] = det.UserIn.Phone;

                    r["Cost"] = det.Cost;
                    r["Rose"] = det.Rose;
                    r["Parked"] = det.Parked;
                    r["Money"] = det.Money;
                }
            }
            grcNormal.DataSource = _tbNormal;
            #endregion

            base.PerformAdd();
        }

        protected override void PerformSave()
        {
            int fix = 0, normal = 0;

            #region Fixed
            var dtr = _tbFixed.Select("[Id] Is Not Null ");
            foreach (DataRow r in dtr)
            {
                var dt = Global.Session.Current;
                if (!DateTime.TryParse(r["DateIn"] + "", out dt))
                {
                    r["Note"] = STR_ERR_DATE;
                    continue;
                }

                var o = new Tra_Detail { VehicleId = (Guid)r["Id"], DateIn = dt };

                if (_bll.Tra_Detail.Insert(o) == null)
                {
                    r["Note"] = STR_IN_DEPOT;
                    continue;
                }
                else
                {
                    r["Note"] = STR_ENTERED;
                    fix++;
                }
            }
            #endregion

            #region Normal
            dtr = _tbNormal.Select("[Id] Is Not Null ");
            foreach (DataRow r in dtr)
            {
                var dt = Global.Session.Current;
                if (!DateTime.TryParse(r["DateIn"] + "", out dt))
                {
                    r["Note"] = STR_ERR_DATE;
                    continue;
                }

                var o = new Tra_Detail { VehicleId = (Guid)r["Id"], DateIn = dt };

                if (_bll.Tra_Detail.Insert(o) == null)
                {
                    r["Note"] = STR_IN_DEPOT;
                    continue;
                }
                else
                {
                    r["Note"] = STR_ENTERED;
                    normal++;
                }
            }
            #endregion

            XtraMessageBox.Show(String.Format(STR_INTO, fix, normal), Text);
            PerformCancel();

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

        /// <summary>
        /// Invoice and out gate
        /// </summary>
        /// <param name="dtr">Data</param>
        /// <param name="isOut">Out gate</param>
        /// <returns></returns>
        private int InvoiceOut(DataRowCollection dtr, bool isOut = true)
        {
            int count = 0;
            foreach (DataRow r in dtr)
            {
                var bs = r["Code"] + "";
                var dt = Global.Session.Current;

                if (!DateTime.TryParse(r["DateOut"] + "", out dt))
                {
                    r.RowError = STR_ERR_DATE;
                    r["Note"] = r.RowError;
                    continue;
                }

                var det = _bll.Tra_Detail.InvoiceOut(bs, isOut, dt);
                if (det == null)
                {
                    r.RowError = STR_IN_DEPOT;
                    r["Note"] = r.RowError;

                    var ve = (Tra_Vehicle)_bll.Tra_Vehicle.Select(bs);

                    if (ve == null)
                    {
                        r.RowError = STR_NO_LIST;
                        r["Note"] = r.RowError;
                    }
                    else
                    {
                        if (ve.Fixed)
                        {
                            if (ve.Tariff == null)
                            {
                                r.RowError = STR_NO_ROUTE;
                                r["Note"] = r.RowError;
                            }
                            else
                            {
                                r["Tariff"] = ve.Tariff.Text;
                                r["Group"] = ve.Tariff.Group.Text;
                                r["Transport"] = ve.Transport == null ? "" : ve.Transport.Text;

                                r["Seats"] = ve.Seats;
                                r["Beds"] = ve.Beds;
                            }
                        }
                        else
                        {
                            r.RowError = STR_NORMAL;
                            r["Note"] = r.RowError;
                        }
                    }
                }
                else
                {
                    r["Tariff"] = det.Vehicle.Tariff.Text;
                    r["Group"] = det.Vehicle.Tariff.Group.Text;
                    r["Transport"] = det.Vehicle.Transport.Text;

                    r["Seats"] = det.Vehicle.Seats;
                    r["Beds"] = det.Vehicle.Beds;

                    r["UserOut"] = Global.Session.User.Name;
                    r["DateOut"] = det.DateOut;

                    r["UserIn"] = det.UserIn.Name;
                    r["DateIn"] = det.DateIn;
                    r["Phone"] = det.UserIn.Phone;

                    r["Cost"] = det.Cost;
                    r["Rose"] = det.Rose;
                    r["Parked"] = det.Parked;
                    r["Money"] = det.Money;

                    count++;
                }
            }
            return count;
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
        private const string STR_TITLE = "Nhập xe bằng tay";

        private const string STR_ERR_DATE = "Thời gian nhập sai";
        private const string STR_NO_LIST = "Không có trong danh sách";
        private const string STR_NO_ROUTE = "Không đăng kí tuyến";
        private const string STR_NO_TARIFF = "Loại xe này không có";
        private const string STR_NO_ADD = "Không thêm thông tin được";

        private const string STR_FIXED = "ĐÂY LÀ " + Global.STR_PAN1;
        private const string STR_NORMAL = "ĐÂY LÀ " + Global.STR_PAN2;

        private const string STR_IN_DEPOT = "XE CHƯA VÀO BẾN";
        private const string STR_ENTERED = "ĐÃ CHO XE VÀO";
        private const string STR_INTO = "SỐ LƯỢNG CHO VÀO\n\rXE CỐ ĐỊNH: {0}\n\rXE VÃNG LAI: {1}";

        public const string STR_PAN1 = "XE CỐ ĐỊNH";
        public const string STR_PAN2 = "XE VÃNG LAI";
        #endregion
    }
}