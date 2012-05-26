using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PRE.Catalog
{
    using UTL;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraBars;

    /// <summary>
    /// Standard input form
    /// </summary>
    public partial class FrmBase : XtraForm, IFormUserActions
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
        protected void SetDockPanel(DockPanel dPanel, string caption)
        {
            dPanel.Options.AllowFloating = false;
            dPanel.Options.FloatOnDblClick = false;
            dPanel.Options.ShowAutoHideButton = false;
            dPanel.Options.ShowCloseButton = false;
            dPanel.Options.ShowMaximizeButton = false;
            dPanel.Text = caption;
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
        #endregion

        private State _FormState;
        [Category("FrmBase")]
        [Description("Trạng thái trên form khi người dùng thao tác trên các nút")]
        [DefaultValue(State.View)]
        public State FormState
        {
            set
            {
                if (AfterChangeFormState != null)
                    AfterChangeFormState(this, new FormStateEventArgs(_FormState, value));

                _FormState = value;
            }
            get { return _FormState; }
        }

        #region Custome events
        /// <summary>
        /// Sự kiện xảy ra sau khi RightHelpers thực thi CheckUserRightAction
        /// </summary>
        public event EventHandler AfterCheckUserRightAction;

        /// <summary>
        /// Sự kiện xảy ra sau khi thay đổi giá trị thuộc tính FormState
        /// </summary>
        public event FormStateEventHandler AfterChangeFormState;
        #endregion

        #region Implement
        private bool enableAdd = true;
        [Category("FrmBase")]
        [DefaultValue(true)]
        public bool EnableAdd
        {
            get { return enableAdd; }
            set
            {
                enableAdd = value;
                if (FormState != State.Add || FormState != State.Edit)
                {
                    bbiAdd.Enabled = enableAdd;

                    if (AfterCheckUserRightAction != null)
                        AfterCheckUserRightAction(this, new EventArgs());
                }
            }
        }

        private bool enableEdit = true;
        [Category("FrmBase")]
        [DefaultValue(true)]
        public bool EnableEdit
        {
            get { return enableEdit; }
            set
            {
                enableEdit = value;
                if (FormState != State.Add || FormState != State.Edit)
                {
                    bbiEdit.Enabled = enableEdit;

                    if (AfterCheckUserRightAction != null)
                        AfterCheckUserRightAction(this, new EventArgs());
                }
            }
        }

        private bool enableDelete = false;
        [Category("FrmBase")]
        [DefaultValue(true)]
        public bool EnableDelete
        {
            get { return enableDelete; }
            set
            {
                enableDelete = value;
                if (FormState != State.Add || FormState != State.Edit)
                {
                    bbiDelete.Enabled = enableDelete;

                    if (AfterCheckUserRightAction != null)
                        AfterCheckUserRightAction(this, new EventArgs());
                }
            }
        }

        private bool enableQuery = true;
        [Category("FrmBase")]
        [DefaultValue(true)]
        public bool EnableQuery
        {
            get { return enableQuery; }
            set
            {
                enableQuery = value;
                if (FormState != State.Add || FormState != State.Edit)
                {
                    //item_Query.Enabled = enableQuery;

                    if (AfterCheckUserRightAction != null)
                        AfterCheckUserRightAction(this, new EventArgs());
                }
            }
        }

        private bool enablePrintPreview = true;
        [Category("FrmBase")]
        [DefaultValue(true)]
        public bool EnablePrintPreview
        {
            get { return enablePrintPreview; }
            set
            {
                enablePrintPreview = value;
                if (FormState != State.Add || FormState != State.Edit)
                {
                    bbiPrint.Enabled = enablePrintPreview;

                    if (AfterCheckUserRightAction != null)
                        AfterCheckUserRightAction(this, new EventArgs());
                }
            }
        }

        private bool enableTest = false;
        [Category("FrmBase")]
        [DefaultValue(true)]
        public bool EnableTest
        {
            get { return enableTest; }
            set
            {
                enableTest = value;
                if (FormState != State.Add || FormState != State.Edit)
                {
                    //item_Test.Enabled = enableTest;

                    if (AfterCheckUserRightAction != null)
                        AfterCheckUserRightAction(this, new EventArgs());
                }
            }
        }

        private bool enableVerify = false;
        [Category("FrmBase")]
        [DefaultValue(true)]
        public bool EnableVerify
        {
            get { return enableVerify; }
            set
            {
                enableVerify = value;
                if (FormState != State.Add || FormState != State.Edit)
                {
                    //item_Verify.Enabled = enableVerify;

                    if (AfterCheckUserRightAction != null)
                        AfterCheckUserRightAction(this, new EventArgs());
                }
            }
        }

        public bool CancelClosed { get; set; }

        private bool denied = false;
        [Category("FrmBase")]
        [DefaultValue(true)]
        public bool Denied
        {
            get { return denied; }
            set
            {
                denied = value;
                //if (denied) timer1.Interval = 5;

                if (AfterCheckUserRightAction != null)
                    AfterCheckUserRightAction(this, new EventArgs());
            }
        }

        [Category("FrmBase")]
        public Actions UserActions { get; set; }
        #endregion

        #region Cho phép
        private bool _allowPrint;
        [Category("FrmBase")]
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

        private bool _allowQuery = false;
        [Category("FrmBase")]
        [Description("Hiển thị nút ? hay không")]
        [DefaultValue(false)]
        public bool AllowQuery
        {
            get { return _allowQuery; }
            set
            {
                _allowQuery = value;
                //if (!_allowQuery) item_Query.Visibility = BarItemVisibility.Never;
                //else item_Query.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowRefresh = false;
        [Category("FrmBase")]
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

        private bool _allowSelect = false;
        [Category("FrmBase")]
        [Description("Hiển thị nút chọn hay không")]
        [DefaultValue(false)]
        public bool AllowSelect
        {
            get { return _allowSelect; }
            set
            {
                _allowSelect = value;
                //if (!_allowSelect) item_Select.Visibility = BarItemVisibility.Never;
                //else item_Select.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowTest = false;
        [Category("FrmBase")]
        [Description("Hiển thị nút Test hay không")]
        [DefaultValue(false)]
        public bool AllowTest
        {
            get { return _allowTest; }
            set
            {
                _allowTest = value;
                //if (!_allowTest) item_Test.Visibility = BarItemVisibility.Never;
                //else item_Test.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowVerify = false;
        [Category("FrmBase")]
        [Description("Hiển thị nút Verify hay không")]
        [DefaultValue(false)]
        public bool AllowVerify
        {
            get { return _allowVerify; }
            set
            {
                _allowVerify = value;
                //if (!_allowVerify) item_Verify.Visibility = BarItemVisibility.Never;
                //else item_Verify.Visibility = BarItemVisibility.Always;
            }
        }
        #endregion
    }

    #region Sự kiện trên form
    public delegate void FormStateEventHandler(object sender, FormStateEventArgs e);

    public class FormStateEventArgs : EventArgs
    {
        public FrmBase.State LastFormState;
        public FrmBase.State NewFormState;

        public FormStateEventArgs(FrmBase.State lastFormState, FrmBase.State newFormState)
        {
            LastFormState = lastFormState;
            NewFormState = newFormState;
        }
    }
    #endregion
}