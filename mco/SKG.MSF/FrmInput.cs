using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SKG.MSF
{
    using BLL;
    using SKG.Plugin;
    using DAL.Entities;

    /// <summary>
    /// For menuz with input form
    /// </summary>
    public partial class FrmInput : Form, IPlugin
    {
        #region Implement plugin
        public string Author { get { return "Zng Tfy"; } }
        public string Description { get { return "xSGKv1 Framework 2012 - For menuz with input form"; } }
        public string Version { get { return "1.0"; } }

        public virtual Form Form { get { return null; } }
        public virtual IHost Host { get; set; }
        public virtual Menuz Menuz { get { return new Menuz(); } }

        public void Initialize() { }
        #endregion

        public FrmInput()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Base access data
        /// </summary>
        protected BaseBLL _bll = new BaseBLL();

        /// <summary>
        /// Default table empty
        /// </summary>
        protected DataTable _dtb = new DataTable("Tmp");

        /// <summary>
        /// Form state
        /// </summary>
        protected State _state;

        /// <summary>
        /// Check user's right
        /// </summary>
        /// <returns></returns>
        public Zaction CheckRight()
        {
            return CheckRight(this);
        }

        /// <summary>
        /// Call check user's right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBase_Activated(object sender, EventArgs e)
        {
            CheckRight(this, true);
        }

        /// <summary>
        /// Set default form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBase_Load(object sender, EventArgs e)
        {
            Text = Menuz.Caption;
            SetNullPrompt();
            PerformRefresh();
        }

        /// <summary>
        /// Action item click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void bmgMain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    switch (e.Item.Name)
        //    {
        //        case "bbiAdd":
        //            _state = State.Add;
        //            PerformAdd();
        //            break;

        //        case "bbiEdit":
        //            _state = State.Edit;
        //            PerformEdit();
        //            break;

        //        case "bbiDelete":
        //            PerformDelete();
        //            break;

        //        case "bbiSave":
        //            PerformSave();
        //            break;

        //        case "bbiCancel":
        //            PerformCancel();
        //            break;

        //        case "bbiRefresh":
        //            _state = State.View;
        //            PerformRefresh();
        //            break;

        //        case "bbiFind":
        //            PerformFind();
        //            break;

        //        case "bbiCollapse":
        //            PerformCollapse();
        //            break;

        //        case "bbiExpand":
        //            PerformExpand();
        //            break;

        //        case "bbiPrint":
        //            PerformPrint();
        //            break;

        //        default:
        //            Close();
        //            break;
        //    }
        //}

        /// <summary>
        /// Change status command button on form
        /// </summary>
        /// <param name="isEnable">Enable</param>
        protected void ChangeStatus(bool isEnable = true)
        {
            //bbiAdd.Enabled = isEnable;
            //bbiEdit.Enabled = isEnable;
            //bbiDelete.Enabled = isEnable;

            //bbiSave.Enabled = !isEnable;
            //bbiCancel.Enabled = !isEnable;

            //bbiRefresh.Enabled = isEnable;
            //bbiFind.Enabled = isEnable;
            //bbiPrint.Enabled = isEnable;
        }

        #region Virtual
        /// <summary>
        /// Perform when click add button
        /// </summary>
        protected virtual void PerformAdd()
        {
            ChangeStatus(false);
            ReadOnlyControl(false);

            ClearDataBindings();
            ResetInput();
        }

        /// <summary>
        /// Perform when click edit button
        /// </summary>
        protected virtual void PerformEdit()
        {
            ChangeStatus(false);
            ReadOnlyControl(false);
        }

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
        protected virtual void PerformRefresh() { }

        /// <summary>
        /// Perform when click find button
        /// </summary>
        protected virtual void PerformFind() { }

        /// <summary>
        /// Perform when click print button
        /// </summary>
        protected virtual void PerformPrint() { }

        /// <summary>
        /// Perform when click collapse button
        /// </summary>
        protected virtual void PerformCollapse() { }

        /// <summary>
        /// Perform when click expand button
        /// </summary>
        protected virtual void PerformExpand() { }

        /// <summary>
        /// Set null value prompt
        /// </summary>
        protected virtual void SetNullPrompt() { }

        /// <summary>
        /// Reset all input control
        /// </summary>
        protected virtual void ResetInput() { }

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
        /// <param name="isReadOnly">Read only</param>
        protected virtual void ReadOnlyControl(bool isReadOnly = true) { }

        /// <summary>
        /// Update object
        /// </summary>
        /// <returns></returns>
        protected virtual bool UpdateObject() { return true; }

        /// <summary>
        /// Insert object
        /// </summary>
        /// <returns></returns>
        protected virtual bool InsertObject() { return true; }

        /// <summary>
        /// Load data
        /// </summary>
        protected virtual void LoadData() { }

        /// <summary>
        /// Valid data before insert or update to database
        /// </summary>
        /// <returns></returns>
        protected virtual bool ValidInput() { return true; }

        /// <summary>
        /// Check user's right after logon
        /// </summary>
        /// <param name="frmRight">Form need to check</param>
        /// <param name="showMessage">Show message</param>
        /// <returns></returns>
        protected virtual Zaction CheckRight(Form frmRight, bool showMessage = false)
        {
            var name = frmRight.GetType().FullName;
            var z = Global.Session.GetZAction(name);

            if (z == null || z.Access == false)
            {
                if (showMessage) MessageBox.Show("Không có quyền", name, MessageBoxButtons.OK);
            }
            else
            {
                //bbiAdd.Enabled = z.Add;
                //bbiEdit.Enabled = z.Edit;
                //bbiDelete.Enabled = z.Delete;
                //bbiPrint.Enabled = z.Print;

                //bbiSave.Enabled = false;
                //bbiCancel.Enabled = false;

                AllowBar = true;
            }
            return z;
        }

        /// <summary>
        /// System timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void TimerTick(object sender, EventArgs e) { }
        #endregion

        #region Allow show/hide toolbar, command button
        private bool _allowBar;
        /// <summary>
        /// Allow show or hide toolbar
        /// </summary>
        public bool AllowBar
        {
            get { return _allowBar; }
            set
            {
                //bar1.Visible = value;
                _allowBar = value;
            }
        }

        private bool _allowAdd;
        /// <summary>
        /// Allow show or hide add button
        /// </summary>
        [DefaultValue(false)]
        public bool AllowAdd
        {
            get { return _allowAdd; }
            set
            {
                _allowAdd = value;
                //if (!_allowAdd) bbiAdd.Visibility = BarItemVisibility.Never;
                //else bbiAdd.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowEdit;
        /// <summary>
        /// Allow show or hide edit button
        /// </summary>
        [DefaultValue(false)]
        public bool AllowEdit
        {
            get { return _allowEdit; }
            set
            {
                _allowEdit = value;
                //if (!_allowEdit) bbiEdit.Visibility = BarItemVisibility.Never;
                //else bbiEdit.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowDelete;
        /// <summary>
        /// Allow show or hide delete button
        /// </summary>
        [DefaultValue(false)]
        public bool AllowDelete
        {
            get { return _allowDelete; }
            set
            {
                _allowDelete = value;
                //if (!_allowDelete) bbiDelete.Visibility = BarItemVisibility.Never;
                //else bbiDelete.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowSave;
        /// <summary>
        /// Allow show or hide save button
        /// </summary>
        [DefaultValue(false)]
        public bool AllowSave
        {
            get { return _allowSave; }
            set
            {
                _allowSave = value;
                //if (!_allowSave) bbiSave.Visibility = BarItemVisibility.Never;
                //else bbiSave.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowCancel;
        /// <summary>
        /// Allow show or hide cancel button
        /// </summary>
        [DefaultValue(false)]
        public bool AllowCancel
        {
            get { return _allowCancel; }
            set
            {
                _allowCancel = value;
                //if (!_allowCancel) bbiCancel.Visibility = BarItemVisibility.Never;
                //else bbiCancel.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowRefresh;
        /// <summary>
        /// Allow show or hide refresh button
        /// </summary>
        [DefaultValue(false)]
        public bool AllowRefresh
        {
            get { return _allowRefresh; }
            set
            {
                _allowRefresh = value;
                //if (!_allowRefresh) bbiRefresh.Visibility = BarItemVisibility.Never;
                //else bbiRefresh.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowFind;
        /// <summary>
        /// Allow show or hide find button
        /// </summary>
        [DefaultValue(false)]
        public bool AllowFind
        {
            get { return _allowFind; }
            set
            {
                _allowFind = value;
                //if (!_allowFind) bbiFind.Visibility = BarItemVisibility.Never;
                //else bbiFind.Visibility = BarItemVisibility.Always;
            }
        }

        private bool _allowPrint;
        /// <summary>
        /// Allow show or hide print button
        /// </summary>
        [DefaultValue(false)]
        public bool AllowPrint
        {
            get { return _allowPrint; }
            set
            {
                _allowPrint = value;
                //if (!_allowPrint) bbiPrint.Visibility = BarItemVisibility.Never;
                //else bbiPrint.Visibility = BarItemVisibility.Always;
            }
        }
        #endregion

        #region For permission
        private bool _allowCollapse;
        /// <summary>
        /// Collapse all tree
        /// </summary>
        public bool AllowCollapse
        {
            get { return _allowCollapse; }
            set
            {
                //if (value) bbiCollapse.Visibility = BarItemVisibility.Always;
                //else bbiCollapse.Visibility = BarItemVisibility.Never;
                _allowCollapse = value;
            }
        }

        private bool _allowExpand;
        /// <summary>
        /// Expand all tree
        /// </summary>
        public bool AllowExpand
        {
            get { return _allowExpand; }
            set
            {
                //if (value) bbiExpand.Visibility = BarItemVisibility.Always;
                //else bbiExpand.Visibility = BarItemVisibility.Never;
                _allowExpand = value;
            }
        }
        #endregion
    }
}