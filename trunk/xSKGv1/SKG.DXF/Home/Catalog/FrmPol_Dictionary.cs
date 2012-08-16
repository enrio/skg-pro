using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Home.Catalog
{
    using SKG.Plugin;
    using SKG.Extend;
    using DAL.Entities;
    using DevExpress.XtraEditors;

    public partial class FrmPol_Dictionary : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Code = typeof(_FrmPol_Dictionary).FullName, Parent = typeof(Level2).FullName, Text = "Từ điển", Level = 0, Order = 12, Picture = @"Icons\Lang.png" };
                return menu;
            }
        }
        #endregion

        public FrmPol_Dictionary()
        {
            InitializeComponent();

            dockPanel1.SetDockPanel("Nhập liệu");
            dockPanel2.SetDockPanel("Danh sách");

            grvMain.OptionsView.ShowAutoFilterRow = true;
            grvMain.OptionsBehavior.Editable = false;

            lokList.Properties.DataSource = _bll.Pol_Dictionary.SelectRoot();
        }

        private void lokList_EditValueChanged(object sender, EventArgs e)
        {
            var tbl = _bll.Pol_Dictionary.Select(lokList.EditValue);
            grcMain.DataSource = tbl;

            var tmp = tbl.Rows[0]["ParentId"];
            if (tmp + "" == "") return;

            tbl = _bll.Pol_Dictionary.Select(tmp, 0, 0);

            if (tbl.Rows.Count > 0)
                tbl = _bll.Pol_Dictionary.Select(tbl.Rows[0]["Type"]);
            else tbl = new DataTable(tbl.TableName);

            lokBelong.Properties.DataSource = tbl;
        }
    }
}