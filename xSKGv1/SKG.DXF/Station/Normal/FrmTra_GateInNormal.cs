﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 22:50
 * Update: 02/06/2013 20:32
 * Status: OK
 */
#endregion

using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG.DXF.Station.Normal
{
    using SKG.Plugin;
    using DAL.Entities;

    using DevExpress.XtraEditors;

    /// <summary>
    /// Input gate
    /// </summary>
    public partial class FrmTra_GateInNormal : FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmTra_GateInNormal);
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
            tmrMain.Enabled = true;

            base.PerformAdd();
        }

        protected override void PerformCancel()
        {
            tmrMain.Enabled = false;

            base.PerformCancel();
        }

        protected override void PerformSave()
        {
            if (!ValidInput()) return;

            // Xử lí khi không phải là xe ba gác (xe biển số bắt đầu là BG là xe ba gác)
            if (!txtNumber.Text.ToUpper().Contains("BG"))
            {
                var o = _bll.Tra_Vehicle.Select(txtNumber.Text);

                if (o == null)
                {
                    txtKind.Focus();
                    var tariff = (Tra_Tariff)_bll.Tra_Tariff.Select(txtKind.Text);

                    if (tariff != null)
                    {
                        var vehicle = new Tra_Vehicle()
                        {
                            TariffId = tariff.Id,
                            Code = txtNumber.Text,
                            Seats = 0,
                            Beds = 0,
                            Fixed = false,
                            City = false,
                            High = false
                        };

                        _bll.Tra_Vehicle.Insert(vehicle);
                    }
                    else if (txtKind.Text + "" != "")
                        XtraMessageBox.Show("LOẠI XE NÀY KHÔNG CÓ!", STR_NORMAL,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtKind.EditValue = null;
                    o = _bll.Tra_Vehicle.Select(txtNumber.Text);
                }

                if (o == null) return;
                var ve = (Tra_Vehicle)o;

                if (ve.Fixed)
                {
                    XtraMessageBox.Show(String.Format(STR_WARNING, txtNumber.Text),
                        STR_FIXED,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            switch (_state)
            {
                case State.Add:
                    if (InsertObject())
                    {
                        XtraMessageBox.Show(STR_INTO, STR_NORMAL,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetInput();
                    }
                    break;

                case State.Edit:
                    if (UpdateObject()) PerformCancel();
                    break;

                default:
                    break;
            }

            txtNumber.Focus();
        }

        protected override bool InsertObject()
        {
            try
            {
                var id = _bll.Tra_Vehicle.CheckExist(txtNumber.Text);

                if (id != new Guid())
                {
                    var o = new Tra_Detail()
                    {
                        UserInId = Global.Session.User.Id,
                        VehicleId = id,
                        DateIn = Global.Session.Current,
                        Code = txtNumber.Text
                    };

                    if (_bll.Tra_Detail.Insert(o) != null) return true;
                    else
                    {
                        XtraMessageBox.Show(STR_IN_GATE,
                            STR_ADD,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return false;
                    }
                }
                else return false;
            }
            catch { return false; }
            finally { LoadData(); }
        }

        protected override bool UpdateObject()
        {
            try
            {
                var id = (Guid)grvMain.GetFocusedRowCellValue("Id");

                var o = new Tra_Detail()
                {
                    Id = id,
                    DateIn = Global.Session.Current
                };

                if (_bll.Tra_Detail.Update(o) != null) return true;
                else
                {
                    XtraMessageBox.Show(STR_IN_GATE, Text);
                    return false;
                }
            }
            catch { return false; }
        }

        protected override void PerformDelete()
        {
            var tmp = grvMain.GetFocusedRowCellValue("Id");
            if (tmp + "" == "") return;
            var id = (Guid)tmp;

            if (id == new Guid()) XtraMessageBox.Show(STR_SELECT, STR_DELETE);
            else
            {
                var tg = txtDateIn.Text.Replace("AM", "SÁNG");
                tg = tg.Replace("PM", "CHIỀU");

                var cfm = String.Format(STR_CONFIRM, txtNumber.Text, tg);
                var oki = XtraMessageBox.Show(cfm,
                              STR_DELETE,
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);

                if (oki == DialogResult.Yes)
                    if (_bll.Tra_Detail.Delete(id) != null) PerformRefresh();
                    else XtraMessageBox.Show(STR_UNDELETE, STR_DELETE);
            }

            base.PerformDelete();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            base.PerformRefresh();
        }

        protected override void ResetInput()
        {
            txtNumber.Text = null;

            base.ResetInput();
        }

        /// <summary>
        /// Danh sách 20 xe vào bến cuối cùng
        /// </summary>
        protected override void LoadData()
        {
            _dtb = _bll.Tra_Detail.GetLatestNormal;
            if (_dtb == null) return;

            if (_dtb.Rows.Count > 0)
                grcMain.DataSource = _dtb;
            else
            {
                for (int i = 0; i < grvMain.RowCount; i++)
                    grvMain.DeleteRow(i);

                bbiEdit.Enabled = false;
                bbiDelete.Enabled = false;
            }

            grvMain.BestFitColumns();
            base.LoadData();
        }

        protected override bool ValidInput()
        {
            var oki = txtNumber.Text.Length == 0 ? false : true;
            if (!oki) XtraMessageBox.Show(STR_NOT_INP, STR_ADD,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else txtNumber.Text = txtNumber.Text.Replace(" ", "");
            return oki;
        }

        protected override void TimerTick(object sender, EventArgs e)
        {
            txtDateIn.EditValue = Global.Session.Current;

            base.TimerTick(sender, e);
        }
        #endregion

        #region Methods
        public FrmTra_GateInNormal()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel(Global.STR_PAN1);
            dockPanel2.SetDockPanel(Global.STR_PAN2);
            grvMain.SetStandard();
        }
        #endregion

        #region Events
        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PerformSave();
        }

        private void txtKind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PerformSave();
        }

        private void FrmTra_GateInNormal_Load(object sender, EventArgs e)
        {
            AllowBar = false;
            PerformAdd();
        }

        private void FrmTra_GateInNormal_Activated(object sender, EventArgs e)
        {
            PerformRefresh();
            PerformAdd();
            txtNumber.Focus();
        }
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Nhập xe lưu đậu";

        private const string STR_ADD = "Thêm chi tiết ra/vào";
        private const string STR_DELETE = "Xoá chi tiết ra/vào";
        private const string STR_SELECT = "Chọn dữ liệu!";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng!";

        private const string STR_CONFIRM = "CÓ XOÁ XE: {0}\nT.GIAN VÀO: {1}\nKHÔNG?";
        private const string STR_WARNING = "BIỂN SỐ {0} LÀ XE CỐ ĐỊNH\nXIN HÃY NHẬP BÊN CỔNG VÀO CỐ ĐỊNH";
        private const string STR_IN_GATE = "XE NÀY ĐANG Ở TRONG BẾN!";
        private const string STR_NOT_INP = "CHƯA NHẬP BIỂN SỐ!";

        private const string STR_INTO = "CHO XE VÀO";
        private const string STR_NORMAL = "XE LƯU ĐẬU";
        private const string STR_FIXED = "XE CỐ ĐỊNH";
        private const string STR_BG = "NHẬP THÊM XE BA BÁNH";
        #endregion
    }
}