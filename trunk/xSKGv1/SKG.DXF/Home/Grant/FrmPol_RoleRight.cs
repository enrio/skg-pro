﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 29/07/2012 10:27
 * Update: 29/07/2012 10:27
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SKG.DXF.Home.Grant
{
    using SKG.Plugin;
    using DAL.Entities;
    using DevExpress.XtraEditors;
    using System.Drawing.Drawing2D;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraTreeList.Nodes;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.StyleFormatConditions;

    public partial class FrmPol_RoleRight : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmPol_RoleRight);
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
            TreeListNode n = trlMain.FocusedNode;
            if (n.ParentNode == null)
            {
                n.Checked = true;
                _idParent = (Guid)n.GetValue("ID");
            }
            else
            {
                n.ParentNode.Checked = true;
                _idParent = (Guid)n.ParentNode.GetValue("ID");
            }

            using (var frm = new FrmSelect() { Text = Text, Caption = "Tên form (chức năng)", Field = "Text", DataSource = _bll.Pol_Dictionary.SelectRights() })
            {
                frm.ShowDialog();
                if (frm.ListInfo == null) return;

                foreach (var x in frm.ListInfo)
                {
                    var tmp = String.Format("RightId = '{0}' And ParentID = '{1}'", x.Id + "", _idParent + "");
                    var dtr = _dtb.Select(tmp);
                    if (dtr.Length > 0) continue;
                    else
                    {
                        var r = _dtb.NewRow();

                        r["ID"] = x.Id;
                        r["ParentID"] = _idParent;
                        r["Name"] = x.Note;

                        r["Add"] = false;
                        r["Edit"] = false;
                        r["Delete"] = false;
                        r["Default"] = false;
                        r["Print"] = false;
                        r["Access"] = false;
                        r["Full"] = false;
                        r["None"] = true;

                        _dtb.Rows.Add(r);
                    }
                }
            }

            base.PerformAdd();
        }

        protected override void PerformEdit()
        {
            trlMain.OptionsBehavior.Editable = true;

            base.PerformEdit();
        }

        protected override void PerformDelete()
        {
            var lst = new List<TreeListNode>();

            foreach (TreeListNode tln in trlMain.Nodes)
                if (tln.HasChildren) // khi chọn dòng con
                    foreach (TreeListNode n in tln.Nodes)
                        if (n.Checked) lst.Add(n);

            if (lst.Count > 0)
            {
                var res = XtraMessageBox.Show(STR_CONFIRM, STR_DELETE,
                        MessageBoxButtons.OKCancel);
                if (res != DialogResult.OK) return;

                foreach (TreeListNode n in lst)
                    _bll.Pol_RoleRight.Delete((Guid)n.GetValue("ID"));
                PerformRefresh();
            }
            else XtraMessageBox.Show(STR_SELECT, STR_DELETE);

            base.PerformDelete();
        }

        protected override void PerformRefresh()
        {
            LoadData();
            ReadOnlyControl();

            base.PerformRefresh();
        }

        protected override void PerformSave()
        {
            trlMain.EndCurrentEdit();

            switch (_state)
            {
                case State.Add:
                    if (InsertObject())
                    {
                        ChangeStatus(); PerformRefresh();
                    }
                    break;

                case State.Edit:
                    if (UpdateObject())
                    {
                        ChangeStatus(); PerformRefresh();
                    }
                    break;

                default:
                    break;
            }

            base.PerformSave();
        }

        protected override void ReadOnlyControl(bool isReadOnly = true)
        {
            trlMain.OptionsBehavior.Editable = !isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                var tb = _dtb.GetChanges(DataRowState.Modified);
                if (tb != null)
                {
                    foreach (DataRow r in tb.Rows)
                    {
                        var o = new Pol_RoleRight()
                        {
                            Id = (Guid)r["ID"],
                            Add = (bool)r["Add"],
                            Edit = (bool)r["Edit"],
                            Delete = (bool)r["Delete"],
                            Default = (bool)r["Default"],
                            Print = (bool)r["Print"],
                            Access = (bool)r["Access"],
                            Full = (bool)r["Full"],
                            None = (bool)r["None"]
                        };
                        _bll.Pol_RoleRight.Update(o);
                    }
                    return true;
                }
                else return false;
            }
            catch { return false; }
        }

        protected override bool InsertObject()
        {
            try
            {
                var tb = _dtb.GetChanges(DataRowState.Added);
                if (tb != null)
                {
                    foreach (DataRow r in tb.Rows)
                    {
                        var o = new Pol_RoleRight()
                        {
                            RightId = (Guid)r["ID"],
                            RoleId = (Guid)r["ParentID"],
                            Add = (bool)r["Add"],
                            Edit = (bool)r["Edit"],
                            Delete = (bool)r["Delete"],
                            Default = (bool)r["Default"],
                            Print = (bool)r["Print"],
                            Access = (bool)r["Access"],
                            Full = (bool)r["Full"],
                            None = (bool)r["None"]
                        };
                        _bll.Pol_RoleRight.Insert(o);
                    }
                    return true;
                }
                else return false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Pol_RoleRight.Select();
            if (_dtb != null)
            {
                trlMain.DataSource = _dtb;
                trlMain.ExpandAll();
            }
            trlMain.AutoFit();

            base.LoadData();
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

        #region Methods
        public FrmPol_RoleRight()
        {
            InitializeComponent();

            AllowCollapse = true;
            AllowExpand = true;
            AllowFind = false;

            dockPanel1.Visibility = DockVisibility.Hidden;
            dockPanel2.SetDockPanel(Global.STR_PAN2);

            trlMain.Columns["No_"].Visible = false; // tạm thời ẩn cột STT
            AddTreeListColumns();
            FormatRows();
        }

        /// <summary>
        /// Định dạng in đậm, màu dòng cấp cha
        /// </summary>
        private void FormatRows()
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
        private void AddTreeListColumns()
        {
            try
            {
                var tbl = _bll.Pol_Dictionary.Select((object)"BUTTON");
                foreach (DataRow drAction in tbl.Rows)
                {
                    var tlc = new TreeListColumn();
                    tlc.Caption = "" + drAction["Text"];
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
        #endregion

        #region Events
        /// <summary>
        /// Khi click check ở dòng cha, tất cả dòng con sẽ được check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trlMain_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            var val = (bool)e.Value;
            var id = (Guid)e.Node.GetValue("ParentID");
            var sl = String.Format("ParentID='{0}'", id);
            DataRow[] sdr = _dtb.Select(sl);

            if (sdr.Length < 1) return;

            if (e.Node.HasChildren) // khi click dòng cha
                foreach (DataRow dr in sdr)
                {
                    dr["Full"] = false;
                    dr["None"] = false;

                    switch (e.Column.FieldName)
                    {
                        case "Add":
                            dr["Add"] = val;
                            break;

                        case "Edit":
                            dr["Edit"] = val;
                            break;

                        case "Delete":
                            dr["Delete"] = val;
                            break;

                        case "Default":
                            dr["Default"] = val;
                            break;

                        case "Print":
                            dr["Print"] = val;
                            break;

                        case "Access":
                            dr["Access"] = val;
                            break;

                        case "Full":
                            dr["Full"] = val;
                            if (val)
                            {
                                dr["None"] = false;
                                dr["Add"] = true;
                                dr["Edit"] = true;
                                dr["Delete"] = true;
                                dr["Default"] = true;
                                dr["Print"] = true;
                                dr["Access"] = true;
                            }
                            break;

                        case "None":
                            dr["None"] = val;
                            if (val)
                            {
                                dr["Full"] = false;
                                dr["Add"] = false;
                                dr["Edit"] = false;
                                dr["Delete"] = false;
                                dr["Default"] = false;
                                dr["Print"] = false;
                                dr["Access"] = false;
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
                            e.Node.SetValue("Default", true);
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
                            e.Node.SetValue("Default", false);
                            e.Node.SetValue("Print", false);
                            e.Node.SetValue("Access", false);
                            e.Node.SetValue("Full", false);
                        }
                        break;

                    //case "Default":
                    //    if (sdr.Length > 0)
                    //        foreach (DataRow dr in sdr) dr["Default"] = false;
                    //    e.Node.SetValue("Default", val);
                    //    break;

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
        #endregion

        #region Properties
        #endregion

        #region Fields
        Guid _idParent;
        #endregion

        #region Constants
        private const string STR_TITLE = "Gán quyền cho nhóm người";

        private const string STR_DELETE = "Xoá chức năng (form) trong nhóm";
        private const string STR_SELECT = "Chọn chức năng (form)!";
        private const string STR_CONFIRM = "Có muốn xoá chức năng (form) được\nchọn ra khỏi nhóm không?";
        #endregion
    }
}