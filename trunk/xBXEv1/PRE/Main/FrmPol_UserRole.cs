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
    using DevExpress.XtraTreeList.StyleFormatConditions;
    using System.Drawing.Drawing2D;

    public partial class FrmPol_UserRole : PRE.Catalog.FrmBase
    {
        public FrmPol_UserRole()
        {
            InitializeComponent();

            AllowCollapse = true;
            AllowExpand = true;

            dockPanel1.Visibility = DockVisibility.Hidden;
            SetDockPanel(dockPanel2, "Danh sách");

            trlMain.OptionsBehavior.Editable = false;
            _bll = new Pol_UserRoleBLL();

            trlMain.Columns["Select"].Visible = false; // tạm thời ẩn cột Chọn
            trlMain.Columns["No_"].Visible = false; // tạm thời ẩn cột STT

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
                    o.Access = (bool)r["Access"];
                    o.Full = (bool)r["Full"];
                    o.None = (bool)r["None"];
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
                    o.Access = (bool)r["Access"];
                    o.Full = (bool)r["Full"];
                    o.None = (bool)r["None"];
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

        protected override void PerformCollapse()
        {
            trlMain.CollapseAll();

            base.PerformCollapse();
        }

        protected override void PerformExpand()
        {
            trlMain.ExpandAll();

            base.PerformExpand();
        }
        #endregion

        /// <summary>
        /// Định dạng in đậm, màu dòng cấp cha
        /// </summary>
        void FormatRows()
        {
            var sfc = new StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal,
                trlMain.Columns["Format"], null, true, true, true);

            sfc.Appearance.BackColor = Color.Orange;
            sfc.Appearance.BackColor2 = Color.Yellow;
            sfc.Appearance.GradientMode = LinearGradientMode.BackwardDiagonal;

            var f = new Font(Font, FontStyle.Bold);
            sfc.Appearance.Font = f;
            sfc.Appearance.ForeColor = Color.Blue;

            trlMain.FormatConditions.Add(sfc);
        }
    }
}