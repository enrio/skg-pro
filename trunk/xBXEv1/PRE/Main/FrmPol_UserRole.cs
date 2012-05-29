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
    using DevExpress.XtraTreeList.Nodes;
    using DevExpress.XtraTreeList.StyleFormatConditions;
    using System.Drawing.Drawing2D;

    public partial class FrmPol_UserRole : PRE.Catalog.FrmBase
    {
        private const string STR_ADD = "Thêm người dùng vào nhóm";
        private const string STR_EDIT = "Sửa người dùng vào nhóm";
        private const string STR_DELETE = "Xoá người dùng trong nhóm";

        private const string STR_SELECT = "Chọn người dùng!";
        private const string STR_CONFIRM = "Có muốn xoá người dùng được\nchọn ra khỏi nhóm không?";
        private const string STR_UNDELETE = "Không xoá được!\nDữ liệu đang được sử dụng";

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
            }

            base.PerformAdd();
        }

        protected override void PerformEdit()
        {
            base.PerformEdit();
        }

        protected override void PerformDelete()
        {
            /*var dtr = _dtb.Select("Format = False And Select = True"); // chọn dòng con được check
            if (dtr.Length > 0)
            {
                var res = BasePRE.ShowMessage(STR_CONFIRM, STR_DELETE,
                    MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    foreach (DataRow r in dtr) _bll.Delete((Guid)r["ID"]);
                    PerformRefresh();
                }
            }
            else BasePRE.ShowMessage(STR_SELECT, STR_DELETE);*/

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
            //trlMain.OptionsBehavior.Editable = true;

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

        /// <summary>
        /// Khi click check ở dòng cha, tất cả dòng con sẽ được check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trlMain_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            /*if (e.Column.FieldName == "Select")
            {
                if (e.Node.HasChildren) // khi click dòng cha
                {
                    var id = (Guid)e.Node.GetValue("ParentID");
                    var sl = String.Format("ParentID='{0}'", id);
                    DataRow[] sdr = _dtb.Select(sl);
                    if (sdr.Length > 0)
                        foreach (DataRow dr in sdr) dr["Select"] = e.Value;
                }
            }*/
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