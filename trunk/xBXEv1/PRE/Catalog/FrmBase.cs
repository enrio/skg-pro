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
    public partial class FrmBase : DevExpress.XtraEditors.XtraForm
    {
        public enum FormState { Add, Edit }

        protected UTL.IBaseDAL _bll;
        protected DataTable _dtb = new DataTable("Tmp");
        protected FormState _frmState;

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
                    _frmState = FormState.Add;

                    ChangeStatus(false);
                    ClearDataBindings();
                    ReadOnlyControl(false);
                    ResetText();

                    PerformAdd();
                    break;

                case "bbiEdit":
                    _frmState = FormState.Edit;

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
    }
}