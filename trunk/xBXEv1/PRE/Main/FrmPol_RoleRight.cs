using System;
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

    public partial class FrmPol_RoleRight : PRE.Catalog.FrmBase
    {
        public FrmPol_RoleRight()
        {
            InitializeComponent();

            //SetDockPanel(dockPanel1, "Nhập liệu");
            dockPanel1.Visibility = DockVisibility.Hidden;
            SetDockPanel(dockPanel2, "Danh sách");

            //trlMain.KeyFieldName = "Pol_RoleId";
            //trlMain.ParentFieldName = "Pol_RightId";
            trlMain.OptionsBehavior.Editable = false;
            _bll = new Pol_RoleRightBLL();

            AddTreeListColumns();
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
            //txtName.Properties.ReadOnly = isReadOnly;

            trlMain.Enabled = isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) ; return false;

            }
            catch { return false; }
        }

        protected override bool InsertObject()
        {
            try
            {
                if (!ValidInput()) ; return false;

            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            //_dtb = _bll.Select();
            //_dtb = BaseBLL._pol_RoleRightBLL.GetForRight();

            var tbl = new DataTable();
            _dtb = BaseBLL._pol_RoleRightBLL.TestPivot(ref tbl);

            var dts = new DataSet("MrToan");
            tbl.TableName = "Test";
            dts.Tables.Add(tbl);
            dts.Tables.Add(_dtb);

            //trlMain.KeyFieldName = "Sequence";
            //trlMain.ParentFieldName = "Sequence2";
            //trlMain.PopulateColumns();

            tbl = BaseBLL._pol_RoleRightBLL.TestUnion();

            if (_dtb != null)
            {
                trlMain.DataSource = tbl;

                //treeListColumn3.BestFit(); // fit column STT
                //treeListColumn7.BestFit();
                //treeListColumn8.BestFit();
                //treeListColumn9.BestFit();
                //treeListColumn10.BestFit();
                //treeListColumn11.BestFit();
                //treeListColumn12.BestFit();
                //treeListColumn13.BestFit();
                //treeListColumn14.BestFit();
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            return base.ValidInput();
        }
        #endregion

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
                    //tlc.ColumnEdit = repositoryItemCheckEdit1;
                    tlc.VisibleIndex = treeListColumn1.TreeList.VisibleColumns.Count + 4;
                    //tlc.Visible = true;

                    treeListColumn1.TreeList.Columns.AddRange(new TreeListColumn[] { tlc });
                    treeListColumn1.TreeList.Update();
                }

                // move last index
                //treeListColumn4.VisibleIndex = treeListColumn1.TreeList.VisibleColumns.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "");
            }
        }
    }
}