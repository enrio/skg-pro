#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 26/10/2012 23:21
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

        #region Constants
        private const string STR_TITLE = "NHẬP XE BẰNG TAY";
        private const string STR_ICON = @"Icons\{0}.png";

        private const string STR_PAN1 = "XE CỐ ĐỊNH";
        private const string STR_PAN2 = "XE VÃNG LAI";

        private const string STR_INTO = "SỐ LƯỢNG CHO VÀO\n\rXE CỐ ĐỊNH: {0}\n\rXE VÃNG LAI: {1}";
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
            grvFixed.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grvFixed.Appearance.HeaderPanel.Options.UseTextOptions = true;
            grvFixed.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grvNormal.OptionsView.ShowAutoFilterRow = true;
            grvNormal.OptionsBehavior.Editable = false;

            grvNormal.Appearance.BandPanel.Options.UseTextOptions = true;
            grvNormal.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            grvNormal.Appearance.HeaderPanel.Options.UseTextOptions = true;
            grvNormal.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
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
            _tbFixed.Columns.Add("Route");
            _tbFixed.Columns.Add("Transport");

            foreach (DataRow r in _tbFixed.Rows)
            {
                var bs = r["Code"] + "";
                var ve = (Tra_Vehicle)_bll.Tra_Vehicle.Select(bs);

                if (ve == null)
                {
                    r.RowError = "Xe chưa có trong danh sách quản lí";
                    r["Note"] = r.RowError;
                }
                else
                {
                    if (ve.Fixed)
                    {
                        if (ve.Tariff == null)
                        {
                            r.RowError = "Xe chưa đăng kí tuyến";
                            r["Note"] = r.RowError;
                        }
                        else
                        {
                            r["Route"] = ve.Tariff.Text;
                            r["Transport"] = ve.Transport == null ? "" : ve.Transport.Text;
                            r["Seats"] = ve.Seats;
                            r["Beds"] = ve.Beds;
                            r["CodeId"] = ve.Id;
                        }
                    }
                    else
                    {
                        r.RowError = "Đây là xe vãng lai";
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
                    var ve_x = new Tra_Vehicle { Code = bs };
                    var tar = (Tra_Tariff)_bll.Tra_Tariff.Select(r["Kind"] + "");
                    r["Kind"] = tar.Text;

                    if (tar == null)
                    {
                        r.RowError = "Loại xe này không có!";
                        r["Note"] = r.RowError;
                    }
                    else
                    {
                        ve_x.TariffId = tar.Id;
                        var seats = r["Seats"] + "";
                        var beds = r["Beds"] + "";

                        ve_x.Seats = seats.ToInt32();
                        ve_x.Beds = beds.ToInt32();

                        var tmp = (Tra_Vehicle)_bll.Tra_Vehicle.Insert(ve_x);
                        if (tmp == null)
                        {
                            r.RowError = "Không thêm thông tin xe được!";
                            r["Note"] = r.RowError;
                        }
                        else
                        {
                            r["CodeId"] = tmp.Id;
                        }
                    }
                }
                else
                {
                    if (!ve.Fixed)
                    {
                        r["Kind"] = ve.Tariff.Text;
                        r["Group"] = ve.Tariff == null ? "" : ve.Tariff.Group.Text;
                        r["Seats"] = ve.Seats ?? 0;
                        r["Beds"] = ve.Beds ?? 0;
                        r["CodeId"] = ve.Id;
                    }
                    else
                    {
                        r.RowError = "Đây là xe cố định";
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
            var dtr = _tbFixed.Select("[CodeId] Is Not Null ");
            foreach (DataRow r in dtr)
            {
                var dt = Global.Session.Current;
                if (!DateTime.TryParse(r["DateIn"] + "", out dt))
                {
                    r["Note"] = "Thời gian nhập sai!";
                    continue;
                }

                var o = new Tra_Detail { VehicleId = (Guid)r["CodeId"], DateIn = dt };

                if (_bll.Tra_Detail.Insert(o) == null)
                {
                    r["Note"] = "Xe này đã ở trong bến!";
                    continue;
                }
                else
                {
                    r["Note"] = "ĐÃ CHO XE VÀO!";
                    fix++;
                }
            }
            #endregion

            #region Normal
            dtr = _tbNormal.Select("[CodeId] Is Not Null ");
            foreach (DataRow r in dtr)
            {
                var dt = Global.Session.Current;
                if (!DateTime.TryParse(r["DateIn"] + "", out dt))
                {
                    r["Note"] = "Thời gian nhập sai!";
                    continue;
                }

                var o = new Tra_Detail { VehicleId = (Guid)r["CodeId"], DateIn = dt };

                if (_bll.Tra_Detail.Insert(o) == null)
                {
                    r["Note"] = "Xe này đã ở trong bến!";
                    continue;
                }
                else
                {
                    r["Note"] = "ĐÃ CHO XE VÀO!";
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
                tb.Columns[3].ColumnName = "Kind";
                tb.Columns[4].ColumnName = "Seats";
                tb.Columns[5].ColumnName = "Beds";
            }
            else
            {
                tb.Columns.Add("Seats");
                tb.Columns.Add("Beds");
            }

            tb.Columns.Add("CodeId", typeof(Guid));
            tb.Columns.Add("Note");
            return tb;
        }
        #endregion

        #region Events
        #endregion
    }
}