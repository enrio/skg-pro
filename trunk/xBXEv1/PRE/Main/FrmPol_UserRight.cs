﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRE.Main
{
    using BLL;
    using DAL.Entities;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.StyleFormatConditions;
    using System.Drawing.Drawing2D;

    public partial class FrmPol_UserRight : PRE.Catalog.FrmBase
    {
        public FrmPol_UserRight()
        {
            InitializeComponent();

            dockPanel1.Visibility = DockVisibility.Hidden;
            SetDockPanel(dockPanel2, "Danh sách");

            trlMain.OptionsBehavior.Editable = false;
            _bll = new Pol_UserRightBLL();

            AddTreeListColumns();
            FormatRows();
        }

        #region Override
        protected override void PerformDelete()
        {
            //var tmp = trlMain.GetFocusedRowCellValue("Id") + "";

            base.PerformDelete();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            if (_dtb != null)
            {
                ClearDataBindings();
                if (_dtb.Rows.Count > 0) DataBindingControl();
            }

            base.PerformRefresh();
        }

        protected override void PerformSave()
        {
            switch (_state)
            {
                case State.Add:
                    if (InsertObject())
                    {
                        ResetText(); LoadData();
                    }
                    break;

                case State.Edit:
                    if (UpdateObject())
                    {
                        ChangeStatus(); ReadOnlyControl();
                        PerformRefresh();
                    }
                    break;
            }

            base.PerformSave();
        }

        protected override void ResetText()
        {
            //txtName.Text = null;

            base.ResetText();
        }

        protected override void ClearDataBindings()
        {
            //txtName.DataBindings.Clear();

            base.ClearDataBindings();
        }

        protected override void DataBindingControl()
        {
            //txtName.DataBindings.Add("EditValue", _dtb, ".Name");

            base.DataBindingControl();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            trlMain.OptionsBehavior.Editable = true;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                //if (!ValidInput()) ; return false;
                var tb = _dtb.GetChanges(DataRowState.Modified);

                foreach (DataRow r in tb.Rows)
                {
                    var o = new Pol_UserRight();
                    o.Id = (Guid)r["ID"];
                    o.Add = (bool)r["Add"];
                    o.Edit = (bool)r["Edit"];
                    o.Delete = (bool)r["Delete"];
                    o.Query = (bool)r["Query"];
                    o.Print = (bool)r["Print"];
                    o.Full = (bool)r["Full"];
                    o.None = (bool)r["None"];
                    o.Only = (bool)r["Only"];
                    BaseBLL._pol_UserRightBLL.Update(o);
                }

                return true;
            }
            catch { return false; }
        }

        protected override bool InsertObject()
        {
            try
            {
                //if (!ValidInput()) ; return false;
                var tb = _dtb.GetChanges(DataRowState.Added);

                foreach (DataRow r in tb.Rows)
                {
                    var o = new Pol_UserRight();
                    //o.Id = (Guid)r["ID"];
                    o.Add = (bool)r["Add"];
                    o.Edit = (bool)r["Edit"];
                    o.Delete = (bool)r["Delete"];
                    o.Query = (bool)r["Query"];
                    o.Print = (bool)r["Print"];
                    o.Full = (bool)r["Full"];
                    o.None = (bool)r["None"];
                    o.Only = (bool)r["Only"];
                    BaseBLL._pol_UserRightBLL.Insert(o);
                }

                return true;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Select();
            if (_dtb != null)
            {
                trlMain.DataSource = _dtb;
                trlMain.ExpandAll();
            }
            AutoFit(trlMain);

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            return base.ValidInput();
        }
        #endregion

        /// <summary>
        /// Định dạng in đậm, màu dòng cấp cha
        /// </summary>
        void FormatRows()
        {
            var condition = new StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal,
                trlMain.Columns["Format"], null, true, true, true);

            condition.Appearance.BackColor = Color.Orange;
            condition.Appearance.BackColor2 = Color.Yellow;
            condition.Appearance.GradientMode = LinearGradientMode.Vertical;

            trlMain.FormatConditions.Add(condition);
        }

        /// <summary>
        /// Thêm các cột quyền truy cập (Thêm, Sửa, Xoá, ...)
        /// </summary>
        void AddTreeListColumns()
        {
            try
            {
                var tbl = BaseBLL._pol_ActionBLL.Select();
                foreach (DataRow drAction in tbl.Rows)
                {
                    var tlc = new TreeListColumn();
                    tlc.Caption = "" + drAction["Name"];
                    tlc.FieldName = "" + drAction["Code"];

                    tlc.VisibleIndex = trlMain.Columns.Count + 1;
                    tlc.ColumnEdit = ricSelect;

                    //tlc.Visible = true;
                    //tlc.BestFit();

                    treeListColumn1.TreeList.Columns.AddRange(new TreeListColumn[] { tlc });
                    treeListColumn1.TreeList.Update();
                }

                // move last index
                treeListColumn4.VisibleIndex = trlMain.Columns.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "");
            }
        }

        private void trlMain_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node == null) return;

            var ur = new Pol_UserRight();
            var ParentID = (Guid)e.Node.GetValue("ParentID");
            ur.Id = (Guid)e.Node.GetValue("ID");
            ur.Add = (bool)e.Node.GetValue("Add");
            ur.Edit = (bool)e.Node.GetValue("Edit");
            ur.Delete = (bool)e.Node.GetValue("Delete");
            ur.Query = (bool)e.Node.GetValue("Query");
            ur.Print = (bool)e.Node.GetValue("Print");
            ur.Full = (bool)e.Node.GetValue("Full");
            ur.None = (bool)e.Node.GetValue("None");
            ur.Only = (bool)e.Node.GetValue("Only");
        }

        DataRow[] sdr = null;
        private void trlMain_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            if (e.Node.HasChildren)
            {
                var id = (Guid)e.Node.GetValue("ParentID");
                var sl = String.Format("ParentID='{0}'", id);
                sdr = _dtb.Select(sl);

                switch (e.Column.FieldName)
                {
                    case "Select":
                        if (this.sdr != null && this.sdr.Length > 0)
                            foreach (DataRow dr in this.sdr) dr["Select"] = e.Value;
                        break;

                    case "Add":
                        if (this.sdr != null && this.sdr.Length > 0)
                            foreach (DataRow dr in this.sdr) dr["Add"] = e.Value;
                        break;

                    case "Edit":
                        if (this.sdr != null && this.sdr.Length > 0)
                            foreach (DataRow dr in this.sdr) dr["Edit"] = e.Value;
                        break;

                    case "Delete":
                        if (this.sdr != null && this.sdr.Length > 0)
                            foreach (DataRow dr in this.sdr) dr["Delete"] = e.Value;
                        break;

                    case "Query":
                        if (this.sdr != null && this.sdr.Length > 0)
                            foreach (DataRow dr in this.sdr) dr["Query"] = e.Value;
                        break;

                    case "Print":
                        if (this.sdr != null && this.sdr.Length > 0)
                            foreach (DataRow dr in this.sdr) dr["Print"] = e.Value;
                        break;

                    case "Full":
                        if (this.sdr != null && this.sdr.Length > 0)
                            foreach (DataRow dr in this.sdr) dr["Full"] = e.Value;
                        break;

                    case "None":
                        if (this.sdr != null && this.sdr.Length > 0)
                            foreach (DataRow dr in this.sdr) dr["None"] = e.Value;
                        break;

                    case "Only":
                        if (this.sdr != null && this.sdr.Length > 0)
                            foreach (DataRow dr in this.sdr) dr["Only"] = e.Value;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}