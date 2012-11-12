#region Information
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
    using SKG.Extend;
    using SKG.Plugin;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    /// <summary>
    /// Input gate
    /// </summary>
    public partial class FrmTra_ByHandIn : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_ByHandIn);
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
            _tbFixed.Columns.Add("Transport");

            foreach (DataRow r in _tbFixed.Rows)
            {
                var bs = r["Code"] + "";
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

                            r["Seats"] = ve.Seats;
                            r["Beds"] = ve.Beds;

                            r["Id"] = ve.Id;
                            r["UserIn"] = Global.Session.User.Name;
                        }
                    }
                    else
                    {
                        r.RowError = STR_NORMAL;
                        r["Note"] = r.RowError;
                    }
                }
            }
            grcFixed.DataSource = _tbFixed;
            #endregion

            #region Normal
            _tbNormal = ImportData(open.FileName, "Vanglai");
            _tbNormal.Columns.Add("Group");

            foreach (DataRow r in _tbNormal.Rows)
            {
                var bs = r["Code"] + "";
                var ve = (Tra_Vehicle)_bll.Tra_Vehicle.Select(bs);

                if (ve == null)
                {
                    var v = new Tra_Vehicle { Code = bs };
                    var tar = (Tra_Tariff)_bll.Tra_Tariff.Select(r["Tariff"] + "");

                    if (tar == null)
                    {
                        r.RowError = STR_NO_TARIFF;
                        r["Note"] = r.RowError;
                    }
                    else
                    {
                        r["Tariff"] = tar.Text;
                        v.TariffId = tar.Id;

                        var seats = r["Seats"] + "";
                        var beds = r["Beds"] + "";

                        v.Seats = seats.ToInt32();
                        v.Beds = beds.ToInt32();

                        var tmp = (Tra_Vehicle)_bll.Tra_Vehicle.Insert(v);
                        if (tmp == null)
                        {
                            r.RowError = STR_NO_ADD;
                            r["Note"] = r.RowError;
                        }
                        else r["Id"] = tmp.Id;
                    }
                }
                else
                {
                    if (!ve.Fixed)
                    {
                        r["Tariff"] = ve.Tariff.Text;
                        r["Group"] = ve.Tariff == null ? "" : ve.Tariff.Group.Text;

                        r["Seats"] = ve.Seats ?? 0;
                        r["Beds"] = ve.Beds ?? 0;

                        r["Id"] = ve.Id;
                        r["UserIn"] = Global.Session.User.Name;
                    }
                    else
                    {
                        r.RowError = STR_FIXED;
                        r["Note"] = r.RowError;
                    }
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
        public FrmTra_ByHandIn()
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

            tb.Columns[2].ColumnName = "DateIn";
            tb.Columns[2].DataType = typeof(DateTime);

            if (sheetName.ToLower() == "vanglai")
            {
                tb.Columns[3].ColumnName = "Tariff";

                tb.Columns[4].ColumnName = "Seats";
                tb.Columns[4].DataType = typeof(int?);

                tb.Columns[5].ColumnName = "Beds";
                tb.Columns[5].DataType = typeof(int?);
            }
            else
            {
                tb.Columns.Add("Tariff");

                tb.Columns.Add("Seats", typeof(int?));
                tb.Columns.Add("Beds", typeof(int?));
            }

            tb.Columns.Add("Id", typeof(Guid));
            tb.Columns.Add("UserIn");
            tb.Columns.Add("Note");
            return tb;
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

        private const string STR_IN_DEPOT = "XE ĐANG TRONG BẾN";
        private const string STR_ENTERED = "ĐÃ CHO XE VÀO";
        private const string STR_INTO = "SỐ LƯỢNG CHO VÀO\n\rXE CỐ ĐỊNH: {0}\n\rXE VÃNG LAI: {1}";

        public const string STR_PAN1 = "XE CỐ ĐỊNH";
        public const string STR_PAN2 = "XE VÃNG LAI";
        #endregion
    }
}