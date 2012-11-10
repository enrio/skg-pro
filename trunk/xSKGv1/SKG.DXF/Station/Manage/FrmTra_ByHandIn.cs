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
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF.Station.Manage
{
    using SKG.Extend;
    using SKG.Plugin;
    using System.Data;
    using DAL.Entities;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;

    /// <summary>
    /// Input gate
    /// </summary>
    public partial class FrmTra_ByHandIn : SKG.DXF.FrmInput
    {
        #region Constants
        private const string STR_TITLE = "NHẬP XE BẰNG TAY";
        private const string STR_ICON = @"Icons\{0}.png";

        private const string STR_PAN1 = "XE CỐ ĐỊNH";
        private const string STR_PAN2 = "XE VÃNG LAI";

        private const string STR_ERR_DATE = "Thời gian nhập sai";
        private const string STR_NO_LIST = "Không có trong danh sách";
        private const string STR_NO_ROUTE = "Không đăng kí tuyến";
        private const string STR_NO_TARIFF = "Loại xe này không có";
        private const string STR_NO_ADD = "Không thêm thông tin được";

        private const string STR_FIXED = "ĐÂY LÀ " + STR_PAN1;
        private const string STR_NORMAL = "ĐÂY LÀ " + STR_PAN2;

        private const string STR_IN_DEPOT = "XE ĐANG TRONG BẾN";
        private const string STR_ENTERED = "ĐÃ CHO XE VÀO";
        private const string STR_INTO = "SỐ LƯỢNG CHO VÀO\n\rXE CỐ ĐỊNH: {0}\n\rXE VÃNG LAI: {1}";
        #endregion

        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var tmp = typeof(FrmTra_ByHandIn);
                var icon = tmp.Name.Split('_');

                var menu = new Menuz
                {
                    Code = tmp.FullName,
                    Parent = typeof(Level2).FullName,
                    Text = STR_TITLE,
                    Level = 3,
                    Order = 27,
                    Picture = String.Format(STR_ICON, icon[1])
                };
                return menu;
            }
        }
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

        #region Properties
        #endregion

        #region Methods
        public FrmTra_ByHandIn()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(STR_PAN1);
            dockPanel2.SetDockPanel(STR_PAN2);

            AllowEdit = false;
            AllowDelete = false;
            AllowRefresh = false;

            grvFixed.OptionsView.ShowAutoFilterRow = true;
            grvFixed.OptionsBehavior.Editable = false;
            grvFixed.Appearance.BandPanel.Options.UseTextOptions = true;
            grvFixed.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            grvFixed.Appearance.HeaderPanel.Options.UseTextOptions = true;
            grvFixed.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

            grvNormal.OptionsView.ShowAutoFilterRow = true;
            grvNormal.OptionsBehavior.Editable = false;
            grvNormal.Appearance.BandPanel.Options.UseTextOptions = true;
            grvNormal.Appearance.BandPanel.TextOptions.HAlignment = HorzAlignment.Center;
            grvNormal.Appearance.HeaderPanel.Options.UseTextOptions = true;
            grvNormal.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
        }

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
            _tbFixed.Columns.Add("Tariff");
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

        /// <summary>
        /// Import data from excel file (by hand)
        /// </summary>
        /// <param name="fileName">File excel name</param>
        /// <param name="sheetName">Sheet name</param>
        /// <returns></returns>
        private DataTable ImportData(string fileName, string sheetName)
        {
            var tb = SKG.Data.Excel.ImportFromExcel(fileName, sheetName);
            tb.Columns[0].ColumnName = "No_";
            tb.Columns[1].ColumnName = "Code";
            tb.Columns[2].ColumnName = "DateIn";

            if (sheetName.ToLower() == "vanglai")
            {
                tb.Columns[3].ColumnName = "Tariff";
                tb.Columns[4].ColumnName = "Seats";
                tb.Columns[5].ColumnName = "Beds";
            }
            else
            {
                tb.Columns.Add("Seats");
                tb.Columns.Add("Beds");
            }

            tb.Columns.Add("Id", typeof(Guid));
            tb.Columns.Add("UserIn");
            tb.Columns.Add("Note");
            return tb;
        }
        #endregion

        #region Events
        #endregion
    }
}