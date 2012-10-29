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
            open.ShowDialog();
            if (open.CheckFileExists)
            {
                #region Fixed
                _tb_fixed = Data.Excel.ImportFromExcel(open.FileName, "Codinh");
                _tb_fixed.Columns[1].ColumnName = "Code";
                _tb_fixed.Columns[2].ColumnName = "DateIn";
                _tb_fixed.Columns.Add("CodeId", typeof(Guid));

                _tb_fixed.Columns.Add("Route");
                _tb_fixed.Columns.Add("Transport");
                _tb_fixed.Columns.Add("Seats");
                _tb_fixed.Columns.Add("Beds");

                foreach (DataRow r in _tb_fixed.Rows)
                {
                    var bs = r["Code"] + "";
                    var ve = (Tra_Vehicle)_bll.Tra_Vehicle.Select(bs);

                    if (ve == null) r.RowError = "Xe chưa có trong danh sách quản lí";
                    else
                    {
                        r["Route"] = ve.Tariff.Text;
                        r["Transport"] = ve.Transport == null ? "" : ve.Transport.Text;
                        r["Seats"] = ve.Seats;
                        r["Beds"] = ve.Beds;
                        r["CodeId"] = ve.Id;
                    }
                }
                grcFixed.DataSource = _tb_fixed;
                #endregion

                #region Normal
                _tb_normal = Data.Excel.ImportFromExcel(open.FileName, "Vanglai");
                _tb_normal.Columns[1].ColumnName = "Code";
                _tb_normal.Columns[2].ColumnName = "DateIn";
                _tb_normal.Columns.Add("CodeId", typeof(Guid));

                _tb_normal.Columns.Add("Route");
                _tb_normal.Columns.Add("Transport");
                _tb_normal.Columns.Add("Seats");
                _tb_normal.Columns.Add("Beds");

                foreach (DataRow r in _tb_normal.Rows)
                {
                    var bs = r["Code"] + "";
                    var ve = (Tra_Vehicle)_bll.Tra_Vehicle.Select(bs);

                    if (ve == null) r.RowError = "Xe chưa có trong danh sách quản lí";
                    else
                    {
                        r["Route"] = ve.Tariff.Text;
                        r["Transport"] = ve.Transport == null ? "" : ve.Transport.Text;
                        r["Seats"] = ve.Seats;
                        r["Beds"] = ve.Beds;
                        r["CodeId"] = ve.Id;
                    }
                }
                grcNormal.DataSource = _tb_normal;
                #endregion
            }
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