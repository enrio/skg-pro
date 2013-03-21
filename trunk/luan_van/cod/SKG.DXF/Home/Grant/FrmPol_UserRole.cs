#region Information
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
    using DevExpress.XtraTreeList.StyleFormatConditions;

    public partial class FrmPol_UserRole : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var type = typeof(FrmPol_UserRole);
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

            using (var frm = new FrmSelect() { Text = Text, Caption = "Họ tên", Field = "Name", DataSource = _bll.Pol_User.Select() })
            {
                frm.ShowDialog();
                if (frm.ListInfo == null) return;

                foreach (var x in frm.ListInfo)
                {
                    var tmp = String.Format("UserId = '{0}' And ParentID = '{1}'", x.Id + "", _idParent + "");
                    var dtr = _dtb.Select(tmp);
                    if (dtr.Length > 0) continue;
                    else
                    {
                        var r = _dtb.NewRow();

                        r["ID"] = x.Id;
                        r["ParentID"] = _idParent;
                        r["Name"] = x.Note;

                        _dtb.Rows.Add(r);
                    }
                }
            }

            base.PerformAdd();
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
                var res = XtraMessageBox.Show(STR_CONFIRM, STR_DELETE, MessageBoxButtons.OKCancel);
                if (res != DialogResult.OK) return;

                foreach (TreeListNode n in lst)
                    _bll.Pol_UserRole.Delete((Guid)n.GetValue("ID"));
                PerformRefresh();
            }
            else XtraMessageBox.Show(STR_SELECT, STR_DELETE);

            base.PerformDelete();
        }

        protected override void PerformRefresh()
        {
            LoadData();

            base.PerformRefresh();
        }

        protected override void PerformSave()
        {
            if (_state == State.Add)
                if (InsertObject())
                {
                    ChangeStatus(); PerformRefresh();
                }

            base.PerformSave();
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
                        var o = new Pol_UserRole() { UserId = (Guid)r["ID"], RoleId = _idParent };
                        _bll.Pol_UserRole.Insert(o);
                    }
                    return true;
                }
                else return false;
            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Pol_UserRole.Select();
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
        public FrmPol_UserRole()
        {
            InitializeComponent();

            dockPanel1.Visibility = DockVisibility.Hidden;
            dockPanel2.SetDockPanel(Global.STR_PAN2);

            AllowCollapse = true;
            AllowExpand = true;
            AllowEdit = false;
            AllowFind = false;

            trlMain.Columns["No_"].Visible = false; // tạm thời ẩn cột STT
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

        #region Events
        #endregion

        #region Properties
        #endregion

        #region Fields
        Guid _idParent;
        #endregion

        #region Constants
        private const string STR_TITLE = "Người dùng thuộc nhóm";

        private const string STR_DELETE = "Xoá người dùng trong nhóm";
        private const string STR_SELECT = "Chọn người dùng!";
        private const string STR_CONFIRM = "Có muốn xoá người dùng được\nchọn ra khỏi nhóm không?";
        #endregion
    }
}