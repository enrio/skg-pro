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
using DevExpress.XtraEditors;

namespace SKG.DXF
{
    using DAL.Entities;
    using DevExpress.XtraTreeList.Nodes;

    /// <summary>
    /// Select object for permission
    /// </summary>
    public partial class FrmSelect : XtraForm
    {
        /// <summary>
        /// Data selected
        /// </summary>
        public List<Zinfors> ListInfo { private set; get; }

        /// <summary>
        /// Data need to select
        /// </summary>
        public DataTable DataSource { set; get; }

        /// <summary>
        /// Caption of column Name or Caption
        /// </summary>
        public string Caption { set; get; }

        /// <summary>
        /// FieldName of column Name or Caption
        /// </summary>
        public string Field { set; get; }

        /// <summary>
        /// Create
        /// </summary>
        public FrmSelect()
        {
            InitializeComponent();

            trlMain.Columns["No_"].Visible = false; // hide column STT
        }

        /// <summary>
        /// Default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSelect_Load(object sender, EventArgs e)
        {
            Field = Field ?? "Caption";
            treeListColumn3.Caption = Caption;
            treeListColumn3.FieldName = Field;
            if (DataSource != null) trlMain.DataSource = DataSource;
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            ListInfo = new List<Zinfors>();

            foreach (TreeListNode n in trlMain.Nodes)
            {
                if (n.Checked)
                {
                    var id = (Guid)n.GetValue("Id");
                    var name = n.GetValue(Field) + "";
                    var o = new Zinfors() { Id = id, Note = name };
                    ListInfo.Add(o);
                }

                foreach (TreeListNode n1 in n.Nodes)
                {
                    if (n1.Checked)
                    {
                        var id = (Guid)n1.GetValue("Id");
                        var name = n1.GetValue(Field) + "";
                        var o = new Zinfors() { Id = id, Note = name };
                        ListInfo.Add(o);
                    }

                    foreach (TreeListNode n2 in n1.Nodes)
                        if (n2.Checked)
                        {
                            var id = (Guid)n2.GetValue("Id");
                            var name = n2.GetValue(Field) + "";
                            var o = new Zinfors() { Id = id, Note = name };
                            ListInfo.Add(o);
                        }
                }
            }

            Close();
        }

        /// <summary>
        /// Check all
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeListNode n in trlMain.Nodes)
            {
                n.Checked = chkAll.Checked;
                foreach (TreeListNode n1 in n.Nodes)
                {
                    n1.Checked = chkAll.Checked;
                    foreach (TreeListNode n2 in n1.Nodes) n2.Checked = chkAll.Checked;
                }
            }
        }

        /// <summary>
        /// Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}