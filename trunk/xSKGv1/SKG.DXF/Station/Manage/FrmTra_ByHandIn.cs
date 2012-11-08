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
                var menu = new Menuz
                {
                    Code = typeof(FrmTra_ByHandIn).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "NHẬP XE BẰNG TAY",
                    Level = 3,
                    Order = 27,
                    Picture = @"Icons\ByHand.png"
                };
                return menu;
            }
        }
        #endregion

        DataTable _tb_fixed;
        DataTable _tb_normal;

        public FrmTra_ByHandIn()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("XE CỐ ĐỊNH");
            dockPanel2.SetDockPanel("XE VÃNG LAI");

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

        protected override void PerformAdd()
        {
            var open = new OpenFileDialog { Filter = "Excel file (NhapBT.xls)|NhapBT.xls" };
            open.ShowDialog();

            if (open.FileName == "" || !open.CheckFileExists)
            {
                PerformCancel();
                return;
            }

            #region Fixed
            _tb_fixed = ImportData(open.FileName, "Codinh");
            _tb_fixed.Columns.Add("Route");
            _tb_fixed.Columns.Add("Transport");

            foreach (DataRow r in _tb_fixed.Rows)
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
            grcFixed.DataSource = _tb_fixed;
            #endregion

            #region Normal
            _tb_normal = ImportData(open.FileName, "Vanglai");
            _tb_normal.Columns.Add("Group");

            foreach (DataRow r in _tb_normal.Rows)
            {
                var bs = r["Code"] + "";
                var ve = (Tra_Vehicle)_bll.Tra_Vehicle.Select(bs);

                if (ve == null)
                {
                    var ve_x = new Tra_Vehicle { Code = bs };
                    var tar = (Tra_Tariff)_bll.Tra_Tariff.Select(r["Kind"] + "");
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

                        if (_bll.Tra_Vehicle.Insert(ve_x) == null)
                        {
                            r.RowError = "Không thêm thông tin xe được!";
                            r["Note"] = r.RowError;
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
            grcNormal.DataSource = _tb_normal;
            #endregion

            base.PerformAdd();
        }

        protected override void PerformSave()
        {
            int fix = 0, normal = 0;

            // Fixed
            var dtr = _tb_fixed.Select("[CodeId] Is Not Null ");
            foreach (DataRow r in dtr)
            {
                var dt = Global.Session.Current;
                if (!DateTime.TryParse(r["DateIn"] + "", out dt))
                {
                    r["Note"] = "Thời gian nhập sai!";
                    continue;
                }

                var o = new Tra_Detail { Tra_VehicleId = (Guid)r["CodeId"], DateIn = dt };

                if (_bll.Tra_Detail.Insert(o) == null)
                {
                    r["Note"] = "Xe này đã ở trong bến!";
                    continue;
                }
                else fix++;
            }

            // Normal
            dtr = _tb_normal.Select("[CodeId] Is Not Null ");
            foreach (DataRow r in dtr)
            {
                var dt = Global.Session.Current;
                if (!DateTime.TryParse(r["DateIn"] + "", out dt))
                {
                    r["Note"] = "Thời gian nhập sai!";
                    continue;
                }

                var o = new Tra_Detail { Tra_VehicleId = (Guid)r["CodeId"], DateIn = dt };

                if (_bll.Tra_Detail.Insert(o) == null)
                {
                    r["Note"] = "Xe này đã ở trong bến!";
                    continue;
                }
                else normal++;
            }

            XtraMessageBox.Show(String.Format("XE CỐ ĐỊNH: {0}\nXE VÃNG LAI: {1}", fix, normal), Text);
            PerformCancel();

            base.PerformSave();
        }

        /// <summary>
        /// Import data from excel file (by hand)
        /// </summary>
        /// <param name="fileName">File excel name</param>
        /// <param name="sheetName">Sheet name</param>
        /// <returns></returns>
        DataTable ImportData(string fileName, string sheetName)
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
    }
}