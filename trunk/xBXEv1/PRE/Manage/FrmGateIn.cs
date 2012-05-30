﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRE.Manage
{
    using BLL;
    using DAL.Entities;

    public partial class FrmGateIn : PRE.Catalog.FrmBase
    {
        public FrmGateIn()
        {
            InitializeComponent();

            lblUserIn.Text = BasePRE._sss.User.Name.ToUpper();

            SetDockPanel(dockPanel1, "Nhập liệu");
            SetDockPanel(dockPanel2, "Danh sách");

            grvMain.OptionsBehavior.Editable = false;
            _bll = new Tra_DetailBLL();
        }

        #region Override
        protected override void PerformDelete()
        {
            var tmp = grvMain.GetFocusedRowCellValue("Id") + "";

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
            //txtName.Properties.ReadOnly = isReadOnly;

            grcMain.Enabled = isReadOnly;

            base.ReadOnlyControl(isReadOnly);
        }

        protected override bool UpdateObject()
        {
            try
            {
                if (!ValidInput()) ; return false;

            }
            catch { return false; }
        }

        protected override bool InsertObject()
        {
            try
            {
                if (!ValidInput()) ; return false;

            }
            catch { return false; }
        }

        protected override void LoadData()
        {
            _dtb = _bll.Select();

            if (_dtb != null)
            {
                grcMain.DataSource = _dtb;
                gridColumn2.BestFit(); // fit column STT
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            return base.ValidInput();
        }

        protected override void tmrMain_Tick(object sender, EventArgs e)
        {
            base.tmrMain_Tick(sender, e);
        }
        #endregion

        private void FrmGateIn_Load(object sender, EventArgs e)
        {
            lkeGroup.Properties.DataSource = BaseBLL._tra_GroupBLL.Select();
            lkeGroup.ItemIndex = 0;
        }

        private void lkeGroup_EditValueChanged(object sender, EventArgs e)
        {
            var id = (Guid)lkeGroup.GetColumnValue("Id");
            lkeKind.Properties.DataSource = BaseBLL._tra_KindBLL.Select(id);
            lkeKind.ItemIndex = 0;
        }
    }
}