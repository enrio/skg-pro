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

    public partial class FrmPol_UserRight : PRE.Catalog.FrmBase
    {
        public FrmPol_UserRight()
        {
            InitializeComponent();

            SetDockPanel(dockPanel1, "Nhập liệu");
            SetDockPanel(dockPanel2, "Danh sách");

            trlMain.PopulateColumns();
            trlMain.OptionsBehavior.Editable = false;
            _bll = new Pol_UserRightBLL();
        }

        #region Override
        protected override void PerformDelete()
        {
            //var tmp = trlMain.GetFocusedRowCellValue("Id") + "";

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

            trlMain.Enabled = isReadOnly;

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
                //trlMain.DataSource = _dtb;
                trlMain.DataSource = Record.GetData();
                treeListColumn3.BestFit(); // fit column STT
            }

            base.LoadData();
        }

        protected override bool ValidInput()
        {
            return base.ValidInput();
        }
        #endregion
    }

    public class Record
    {
        public int ID { get; private set; }
        public int ParentID { get; private set; }
        public string Category { get; private set; }
        public object Product1 { get; set; }
        public object Product2 { get; set; }
        public object Product3 { get; set; }

        public Record(string category, object product1, object product2, object product3, int id)
            : this(category, product1, product2, product3, id, -1) { }

        public Record(string category, object product1, object product2, object product3, int id, int parentID)
        {
            Category = category;
            Product1 = product1;
            Product2 = product2;
            Product3 = product3;
            ID = id;
            ParentID = parentID;
        }

        public static Record[] GetData()
        {
            Record[] records = new Record[11];
            records[0] = new Record("Product Name", "Chai", "Teatime Chocolate Biscuits", "Ipoh Coffee", 0);
            records[1] = new Record("Category", 1, 2, 1, 1);
            records[2] = new Record("Supplier", "Exotic Liquids", "Specialty Biscuits, Ltd.", "Leka Trading", 2);
            records[3] = new Record("Quantity Per Unit", "10 boxes x 20 bags", "10 boxes x 12 pieces", "16 - 500 g tins", 3, 0);
            records[4] = new Record("Unit Price", 18.00, 9.20, 46.00, 4, 0);
            records[5] = new Record("Units in Stock", 39, 25, 17, 5, 0);
            records[6] = new Record("Discontinued", true, false, true, 6, 0);
            records[7] = new Record("Last Order", new DateTime(2001, 12, 14), new DateTime(2000, 7, 20), new DateTime(2002, 1, 7), 7);
            records[8] = new Record("Relevance", 70, 90, 50, 8);
            records[9] = new Record("Contact Name", "Shelley Burke", "Robb Merchant", "Sven Petersen", 9, 2);
            records[10] = new Record("Phone", "(100)555-4822", "(111)555-1222", "(120)555-1154", 10, 2);

            return records;
        }
    }
}