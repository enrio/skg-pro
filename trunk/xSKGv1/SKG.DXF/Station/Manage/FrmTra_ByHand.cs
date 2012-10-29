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
    using SKG.Plugin;
    using System.Data;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    /// <summary>
    /// Input gate
    /// </summary>
    public partial class FrmTra_ByHand : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(FrmTra_GateInNormal).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "NHẬP BẰNG TAY",
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

        public FrmTra_ByHand()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("XE CỐ ĐỊNH");
            dockPanel2.SetDockPanel("XE VÃNG LAI");

            AllowEdit = false;
            AllowDelete = false;

            grvFixed.OptionsView.ShowAutoFilterRow = true;
            grvFixed.OptionsBehavior.Editable = false;

            grvNormal.OptionsView.ShowAutoFilterRow = true;
            grvNormal.OptionsBehavior.Editable = false;
        }

        protected override void PerformAdd()
        {
            var open = new OpenFileDialog();
            open.Filter = "Excel file (Bangtay.xls)|Bangtay.xls";
            open.ShowDialog();
            if (open.FileName == "" || !open.CheckFileExists)
            {
                PerformCancel();
                return;
            }

            #region Fixed
            _dtb = Data.Excel.ImportFromExcel(open.FileName, "Codinh");
            _dtb.Columns[1].ColumnName = "Code";
            _dtb.Columns[2].ColumnName = "DateIn";
            _dtb.Columns.Add("CodeId", typeof(Guid));

            _dtb.Columns.Add("Route");
            _dtb.Columns.Add("Transport");
            _dtb.Columns.Add("Seats");
            _dtb.Columns.Add("Beds");
            _dtb.Columns.Add("Note");

            _tb_fixed = _dtb;
            foreach (DataRow r in _dtb.Rows)
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
                        r["Route"] = ve.Tariff.Text;
                        r["Transport"] = ve.Transport == null ? "" : ve.Transport.Text;
                        r["Seats"] = ve.Seats;
                        r["Beds"] = ve.Beds;
                        r["CodeId"] = ve.Id;
                        _tb_fixed.Rows.Add(r);
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
            _dtb = Data.Excel.ImportFromExcel(open.FileName, "Vanglai");
            _dtb.Columns[1].ColumnName = "Code";
            _dtb.Columns[2].ColumnName = "DateIn";
            _dtb.Columns.Add("CodeId", typeof(Guid));

            _dtb.Columns.Add("Kind");
            _dtb.Columns.Add("Group");
            _dtb.Columns.Add("Seats");
            _dtb.Columns.Add("Beds");
            _dtb.Columns.Add("Note");

            _tb_normal = _dtb;
            foreach (DataRow r in _dtb.Rows)
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
                    if (!ve.Fixed)
                    {
                        r["Route"] = ve.Tariff.Text;
                        r["Transport"] = ve.Transport == null ? "" : ve.Tariff.Group.Text;
                        r["Seats"] = ve.Seats;
                        r["Beds"] = ve.Beds;
                        r["CodeId"] = ve.Id;
                        _tb_fixed.Rows.Add(r);
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
            // Fixed
            var dtr = _tb_fixed.Select("[CodeId] Is Not Null ");
            foreach (DataRow r in dtr)
            {
                var bs = r["Code"] + "";
                var dt = Global.Session.Current;
                DateTime.TryParse(r["DateIn"] + "", out dt);

                var o = new Tra_Detail();
                o.Tra_VehicleId = (Guid)r["CodeId"];
                o.DateIn = dt;
                _bll.Tra_Detail.Insert(o);
            }

            // Normal
            dtr = _tb_normal.Select("[CodeId] Is Not Null ");
            foreach (DataRow r in dtr)
            {
                var bs = r["Code"] + "";
                var dt = Global.Session.Current;
                DateTime.TryParse(r["DateIn"] + "", out dt);

                var o = new Tra_Detail();
                o.Tra_VehicleId = (Guid)r["CodeId"];
                o.DateIn = dt;
                _bll.Tra_Detail.Insert(o);
            }

            XtraMessageBox.Show("NHẬP LIỆU THÀNH CÔNG!");
            base.PerformSave();
        }
    }
}