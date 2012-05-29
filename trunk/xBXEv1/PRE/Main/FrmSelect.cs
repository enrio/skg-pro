using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PRE.Main
{
    using BLL;
    using DAL.Entities;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using DevExpress.XtraTreeList.StyleFormatConditions;
    using System.Drawing.Drawing2D;

    public partial class FrmSelect : DevExpress.XtraEditors.XtraForm
    {
        public List<Guid> ListId { private set; get; }

        Pol_UserBLL _bll = new Pol_UserBLL();

        public FrmSelect()
        {
            InitializeComponent();


            trlMain.Columns["Select"].Visible = false; // tạm thời ẩn cột Chọn
            trlMain.Columns["No_"].Visible = false; // tạm thời ẩn cột STT
        }

        private void FrmSelect_Load(object sender, EventArgs e)
        {
            var tb = _bll.Select();
            if (tb != null) trlMain.DataSource = tb;
            AutoFit(trlMain);
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            foreach (TreeListNode n in trlMain.Nodes)
                if (n.Checked)
                    ListId.Add((Guid)n.GetValue("ID"));
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeListNode n in trlMain.Nodes) n.Checked = chkAll.Checked;
        }
    }
}