using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PRE.Main
{
    using BLL;
    using DAL.Entities;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraTreeList.Nodes;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.StyleFormatConditions;
    using System.Drawing.Drawing2D;

    public partial class FrmPol_RoleRight : PRE.Catalog.FrmBase
    {
        private const string STR_DELETE = "Xoá người dùng trong nhóm";
        private const string STR_SELECT = "Chọn người dùng!";
        private const string STR_CONFIRM = "Có muốn xoá người dùng được\nchọn ra khỏi nhóm không?";

        public FrmPol_RoleRight()
        {
            InitializeComponent();

            AllowCollapse = true;
            AllowExpand = true;
            AllowEdit = false;
            AllowFind = false;

            dockPanel1.Visibility = DockVisibility.Hidden;
            SetDockPanel(dockPanel2, "Danh sách");

            _bll = new Pol_RoleRightBLL();
            trlMain.Columns["Select"].Visible = false; // tạm thời ẩn cột Chọn
            trlMain.Columns["No_"].Visible = false; // tạm thời ẩn cột STT
            AddTreeListColumns();
            FormatRows();
        }

        #region Override
        protected override void PerformDelete()
        {
            var lst = new List<TreeListNode>();

            foreach (TreeListNode tln in trlMain.Nodes)
                if (tln.HasChildren) // khi chọn dòng con
                    foreach (TreeListNode n in tln.Nodes)
                        if (n.Checked) lst.Add(n);

            if (lst.Count > 0)
            {
                var res = BasePRE.ShowMessage(STR_CONFIRM, STR_DELETE,
                        MessageBoxButtons.OKCancel);
                if (res != DialogResult.OK) return;

                foreach (TreeListNode n in lst)
                    _bll.Delete((Guid)n.GetValue("ID"));
                PerformRefresh();
            }
            else BasePRE.ShowMessage(STR_SELECT, STR_DELETE);

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

                default:
                    break;
            }

            base.PerformSave();
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
                    var o = new Pol_UserRight()
                    {
                        Id = (Guid)r["ID"],
                        Add = (bool)r["Add"],
                        Edit = (bool)r["Edit"],
                        Delete = (bool)r["Delete"],
                        Query = (bool)r["Query"],
                        Print = (bool)r["Print"],
                        Access = (bool)r["Access"],
                        Full = (bool)r["Full"],
                        None = (bool)r["None"]
                    };
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
                var tb = _dtb.GetChanges(DataRowState.Added);

                foreach (DataRow r in tb.Rows)
                {
                    var o = new Pol_UserRight()
                    {
                        Add = (bool)r["Add"],
                        Edit = (bool)r["Edit"],
                        Delete = (bool)r["Delete"],
                        Query = (bool)r["Query"],
                        Print = (bool)r["Print"],
                        Access = (bool)r["Access"],
                        Full = (bool)r["Full"],
                        None = (bool)r["None"]
                    };
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

        }

        /// <summary>
        /// Khi click check ở dòng cha, tất cả dòng con sẽ được check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trlMain_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            var val = (bool)e.Value;

            if (e.Node.HasChildren) // khi click dòng cha
            {
                var id = (Guid)e.Node.GetValue("ParentID");
                var sl = String.Format("ParentID='{0}'", id);
                DataRow[] sdr = _dtb.Select(sl);

                switch (e.Column.FieldName)
                {
                    case "Select":
                        if (sdr != null && sdr.Length > 0)
                            foreach (DataRow dr in sdr) dr["Select"] = val;
                        break;

                    case "Add":
                        if (sdr != null && sdr.Length > 0)
                            foreach (DataRow dr in sdr)
                            {
                                dr["Add"] = val;
                                dr["Full"] = false;
                                dr["None"] = false;
                            }
                        break;

                    case "Edit":
                        if (sdr != null && sdr.Length > 0)
                            foreach (DataRow dr in sdr)
                            {
                                dr["Edit"] = val;
                                dr["Full"] = false;
                                dr["None"] = false;
                            };
                        break;

                    case "Delete":
                        if (sdr != null && sdr.Length > 0)
                            foreach (DataRow dr in sdr)
                            {
                                dr["Delete"] = val;
                                dr["Full"] = false;
                                dr["None"] = false;
                            }
                        break;

                    case "Query":
                        if (sdr != null && sdr.Length > 0)
                            foreach (DataRow dr in sdr)
                            {
                                dr["Query"] = val;
                                dr["Full"] = false;
                                dr["None"] = false;
                            }
                        break;

                    case "Print":
                        if (sdr != null && sdr.Length > 0)
                            foreach (DataRow dr in sdr)
                            {
                                dr["Print"] = val;
                                dr["Full"] = false;
                                dr["None"] = false;
                            }
                        break;

                    case "Access":
                        if (sdr != null && sdr.Length > 0)
                            foreach (DataRow dr in sdr)
                            {
                                dr["Access"] = val;
                                dr["Full"] = false;
                                dr["None"] = false;
                            }
                        break;

                    case "Full":
                        if (sdr != null && sdr.Length > 0)
                            foreach (DataRow dr in sdr)
                            {
                                dr["Full"] = val;
                                if (val)
                                {
                                    dr["None"] = false;
                                    dr["Add"] = true;
                                    dr["Edit"] = true;
                                    dr["Delete"] = true;
                                    dr["Query"] = true;
                                    dr["Print"] = true;
                                    dr["Access"] = true;
                                }
                            }
                        break;

                    case "None":
                        if (sdr != null && sdr.Length > 0)
                            foreach (DataRow dr in sdr)
                            {
                                dr["None"] = val;
                                if (val)
                                {
                                    dr["Full"] = false;
                                    dr["Add"] = false;
                                    dr["Edit"] = false;
                                    dr["Delete"] = false;
                                    dr["Query"] = false;
                                    dr["Print"] = false;
                                    dr["Access"] = false;
                                }
                            }
                        break;

                    default:
                        break;
                }
            }
            else // khi click dòng con
            {
                switch (e.Column.FieldName)
                {
                    case "Full":
                        if (val)
                        {
                            e.Node.SetValue("Add", true);
                            e.Node.SetValue("Edit", true);
                            e.Node.SetValue("Delete", true);
                            e.Node.SetValue("Query", true);
                            e.Node.SetValue("Query", true);
                            e.Node.SetValue("Print", true);
                            e.Node.SetValue("Access", true);
                            e.Node.SetValue("None", false);
                        }
                        break;

                    case "None":
                        if (val)
                        {
                            e.Node.SetValue("Add", false);
                            e.Node.SetValue("Edit", false);
                            e.Node.SetValue("Delete", false);
                            e.Node.SetValue("Query", false);
                            e.Node.SetValue("Query", false);
                            e.Node.SetValue("Print", false);
                            e.Node.SetValue("Access", false);
                            e.Node.SetValue("Full", false);
                        }
                        break;

                    default:
                        e.Node.SetValue("Full", false);
                        e.Node.SetValue("None", false);
                        break;
                }
            }
        }

        /// <summary>
        /// Khi click check ở dòng cha, tất cả dòng con sẽ được check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trlMain_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node.HasChildren) foreach (TreeListNode n in e.Node.Nodes) n.Checked = e.Node.Checked;
            else if (e.Node.ParentNode != null) // khi click dòng con
            {
                bool oki = true;
                foreach (TreeListNode n in e.Node.ParentNode.Nodes) oki &= n.Checked;
                if (e.Node.Checked == false) e.Node.ParentNode.Checked = false;
                if (oki) e.Node.ParentNode.Checked = true;
            }
        }
    }
}