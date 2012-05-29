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
    using DevExpress.XtraTreeList.StyleFormatConditions;
    using System.Drawing.Drawing2D;

    public partial class FrmPol_UserRole : PRE.Catalog.FrmBase
    {
        private const string STR_DELETE = "Xoá người dùng trong nhóm";
        private const string STR_SELECT = "Chọn người dùng!";
        private const string STR_CONFIRM = "Có muốn xoá người dùng được\nchọn ra khỏi nhóm không?";


        public FrmPol_UserRole()
        {
            InitializeComponent();

            AllowCollapse = true;
            AllowExpand = true;
            AllowEdit = false;
            AllowFind = false;

            dockPanel1.Visibility = DockVisibility.Hidden;
            SetDockPanel(dockPanel2, "Danh sách");

            _bll = new Pol_UserRoleBLL();
            trlMain.Columns["Select"].Visible = false; // tạm thời ẩn cột Chọn
            trlMain.Columns["No_"].Visible = false; // tạm thời ẩn cột STT
            FormatRows();
        }

        #region Override
        Guid _idRole;
        protected override void PerformAdd()
        {
            TreeListNode n = trlMain.FocusedNode;
            if (n.ParentNode == null)
            {
                n.Checked = true;
                _idRole = (Guid)n.GetValue("ID");
            }
            else
            {
                n.ParentNode.Checked = true;
                _idRole = (Guid)n.ParentNode.GetValue("ID");
            }

            using (var frm = new FrmSelect() { Text = Text })
            {
                frm.ShowDialog();
                if (frm.ListInfo == null) return;

                foreach (var x in frm.ListInfo)
                {
                    var r = _dtb.NewRow();

                    r["ID"] = x.Id;
                    r["ParentID"] = _idRole;
                    r["Name"] = x.Descript;

                    _dtb.Rows.Add(r);
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
                        var o = new Pol_UserRole() { Pol_UserId = (Guid)r["ID"], Pol_RoleId = (Guid)r["ParentID"] };
                        _bll.Insert(o);
                    }
                    return true;
                }
                else return false;
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