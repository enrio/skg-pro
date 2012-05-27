using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PRE.Catalog
{
    using UTL;
    using BLL;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraBars;

    /// <summary>
    /// Standard input form
    /// </summary>
    public partial class FrmBase : XtraForm
    {
        public enum State { View, Add, Edit, Delete, Save, Cancel, }

        protected UTL.IBaseDAL _bll;
        protected DataTable _dtb = new DataTable("Tmp");
        protected State _state;

        public FrmBase()
        {
            InitializeComponent();
        }

        private void FrmBase_Load(object sender, EventArgs e)
        {
            CheckRight(this);
            ReadOnlyControl();
            PerformRefresh();
        }

        private void bmgMain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "bbiAdd":
                    _state = State.Add;

                    ChangeStatus(false);
                    ClearDataBindings();
                    ReadOnlyControl(false);
                    ResetText();

                    PerformAdd();
                    break;

                case "bbiEdit":
                    _state = State.Edit;

                    ChangeStatus(false);
                    ReadOnlyControl(false);

                    PerformEdit();
                    break;

                case "bbiDelete":
                    PerformDelete();
                    break;

                case "bbiSave":
                    PerformSave();
                    break;

                case "bbiCancel":
                    PerformCancel();
                    break;

                case "bbiRefresh":
                    PerformRefresh();
                    break;

                case "bbiFind":
                    PerformFind();
                    break;

                case "bbiPrint":
                    PerformPrint();
                    break;

                case "bbiClose":
                    Close();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Change status command button on form
        /// </summary>
        /// <param name="isEnable">Enable if true else disable</param>
        protected void ChangeStatus(bool isEnable = true)
        {
            bbiAdd.Enabled = isEnable;
            bbiEdit.Enabled = isEnable;
            bbiDelete.Enabled = isEnable;

            bbiSave.Enabled = !isEnable;
            bbiCancel.Enabled = !isEnable;

            bbiRefresh.Enabled = isEnable;
            bbiFind.Enabled = isEnable;
            bbiPrint.Enabled = isEnable;
        }

        /// <summary>
        /// Set false some properties's DockPanel
        /// </summary>
        /// <param name="dPanel">DockPanel</param>
        /// <param name="caption">Caption's DockPanel</param>
        protected static void SetDockPanel(DockPanel dPanel, string caption)
        {
            dPanel.Options.AllowFloating = false;
            dPanel.Options.FloatOnDblClick = false;
            dPanel.Options.ShowAutoHideButton = false;
            dPanel.Options.ShowCloseButton = false;
            dPanel.Options.ShowMaximizeButton = false;
            dPanel.Text = caption;
        }

        /// <summary>
        /// Thu gọn cột
        /// </summary>
        /// <param name="trl">TreeList</param>
        protected static void AutoFit(TreeList trl)
        {
            foreach (TreeListColumn x in trl.Columns)
            {
                if (x.VisibleIndex != trl.Columns.Count - 1)
                    x.BestFit();
            }
        }

        #region Virtual
        /// <summary>
        /// Perform when click add button
        /// </summary>
        protected virtual void PerformAdd() { }

        /// <summary>
        /// Perform when click edit button
        /// </summary>
        protected virtual void PerformEdit() { }

        /// <summary>
        /// Perform when click delete button
        /// </summary>
        protected virtual void PerformDelete() { }

        /// <summary>
        /// Perform when click save button
        /// </summary>
        protected virtual void PerformSave() { }

        /// <summary>
        /// Perform when click cancel button
        /// </summary>
        protected virtual void PerformCancel()
        {
            ChangeStatus();
            ReadOnlyControl();
            PerformRefresh();
        }

        /// <summary>
        /// Load data or perform when click refresh button
        /// </summary>
        protected virtual void PerformRefresh() { ReadOnlyControl(); }

        /// <summary>
        /// Perform when click find button
        /// </summary>
        protected virtual void PerformFind() { }

        /// <summary>
        /// Perform when click print button
        /// </summary>
        protected virtual void PerformPrint() { }

        /// <summary>
        /// Reset all input control
        /// </summary>
        protected new virtual void ResetText() { }

        /// <summary>
        /// Clear data binding
        /// </summary>
        protected virtual void ClearDataBindings() { }

        /// <summary>
        /// Add data binding
        /// </summary>
        protected virtual void DataBindingControl() { }

        /// <summary>
        /// Set read only control on form
        /// </summary>
        /// <param name="isReadOnly">Read only is trule else normal</param>
        protected virtual void ReadOnlyControl(bool isReadOnly = true) { }

        /// <summary>
        /// Update object
        /// </summary>
        /// <returns>True if successful else false</returns>
        protected virtual bool UpdateObject() { return true; }

        /// <summary>
        /// Delete object
        /// </summary>
        /// <returns>True if successful else false</returns>
        protected virtual bool InsertObject() { return true; }

        /// <summary>
        /// Load data
        /// </summary>
        protected virtual void LoadData() { }

        /// <summary>
        /// Valid data before insert or update to database
        /// </summary>
        /// <returns>True if valid else false</returns>
        protected virtual bool ValidInput() { return true; }

        /// <summary>
        /// Kiểm tra quyền người dùng đăng nhập
        /// </summary>
        /// <param name="frmRight">Form cần kiểm tra</param>
        protected virtual void CheckRight(Form frmRight)
        {
            var zac = BasePRE._sss.GetRight(frmRight.GetType().Name);

            if (zac == null)
                MessageBox.Show("Không có quyền", frmRight.Name);
            else
            {
                bbiAdd.Enabled = zac.Add;
                bbiEdit.Enabled = zac.Edit;
                bbiDelete.Enabled = zac.Delete;
                bbiPrint.Enabled = zac.Print;
            }
        }
        #endregion

        #region Cho phép ẩn/hiện các nút lệnh
        private bool _allowAdd;
        [Description("Hiển thị nút Thêm hay không")]
        [DefaultValue(false)]
        public bool AllowAdd
        {
            get { return _allowAdd; }
            set
            {
                _allowAdd = value;
                if (!_allowAdd) bbiAdd.Visibility = BarItemVisibility.Never;
                else bbiAdd.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowEdit;
        [Description("Hiển thị nút Sửa hay không")]
        [DefaultValue(false)]
        public bool AllowEdit
        {
            get { return _allowEdit; }
            set
            {
                _allowEdit = value;
                if (!_allowEdit) bbiEdit.Visibility = BarItemVisibility.Never;
                else bbiEdit.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowDelete;
        [Description("Hiển thị nút Xoá hay không")]
        [DefaultValue(false)]
        public bool AllowDelete
        {
            get { return _allowDelete; }
            set
            {
                _allowDelete = value;
                if (!_allowDelete) bbiDelete.Visibility = BarItemVisibility.Never;
                else bbiDelete.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowSave;
        [Description("Hiển thị nút Lưu hay không")]
        [DefaultValue(false)]
        public bool AllowSave
        {
            get { return _allowSave; }
            set
            {
                _allowSave = value;
                if (!_allowSave) bbiSave.Visibility = BarItemVisibility.Never;
                else bbiSave.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowCancel;
        [Description("Hiển thị nút Huỷ hay không")]
        [DefaultValue(false)]
        public bool AllowCancel
        {
            get { return _allowCancel; }
            set
            {
                _allowCancel = value;
                if (!_allowCancel) bbiCancel.Visibility = BarItemVisibility.Never;
                else bbiCancel.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowRefresh;
        [Description("Hiển thị nút Cập nhật hay không")]
        [DefaultValue(false)]
        public bool AllowRefresh
        {
            get { return _allowRefresh; }
            set
            {
                _allowRefresh = value;
                if (!_allowRefresh) bbiRefresh.Visibility = BarItemVisibility.Never;
                else bbiRefresh.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowFind;
        [Description("Hiển thị nút Tìm hay không")]
        [DefaultValue(false)]
        public bool AllowFind
        {
            get { return _allowFind; }
            set
            {
                _allowFind = value;
                if (!_allowFind) bbiFind.Visibility = BarItemVisibility.Never;
                else bbiFind.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowPrint;
        [Description("Hiển thị nút In ấn hay không")]
        [DefaultValue(false)]
        public bool AllowPrint
        {
            get { return _allowPrint; }
            set
            {
                _allowPrint = value;
                if (!_allowPrint) bbiPrint.Visibility = BarItemVisibility.Never;
                else bbiPrint.Visibility = BarItemVisibility.Always;
            }
        }
        #endregion
    }
}