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

        public FrmTra_ByHand()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            AllowAdd = false;
            AllowEdit = false;
            AllowDelete = false;

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;
        }

        private void cmdFixed_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            open.ShowDialog();
            if (open.CheckFileExists)
            {
                var tb = Data.Excel.ImportFromExcel(open.FileName, "Ravao");
                tb.Columns.Add("Route");
                tb.Columns.Add("Transport");
                tb.Columns.Add("Seats");
                tb.Columns.Add("Beds");

                foreach (DataRow r in tb.Rows)
                {
                    var bs = r["Code"] + "";
                    var dt = Global.Session.Current;
                    DateTime.TryParse(r["DateIn"] + "", out dt);

                    var ve = (Tra_Vehicle)_bll.Tra_Vehicle.Select(bs);
                    if (ve == null) r.RowError = "Xe chưa có trong danh sách quản lí";
                    else
                    {
                        r["Route"] = ve.Tariff.Text;
                        r["Transport"] = ve.Transport == null ? "" : ve.Transport.Text;
                        r["Seats"] = ve.Seats;
                        r["Beds"] = ve.Beds;
                    }
                    //else
                    //{
                    //    var o = new Tra_Detail();
                    //    o.Tra_VehicleId = ve.Id;
                    //    o.DateIn = dt;
                    //    _bll.Tra_Detail.Insert(o);
                    //}
                }

                grcMain.DataSource = tb;
            }
        }

        private void cmdNormal_Click(object sender, EventArgs e)
        {

        }
    }
}