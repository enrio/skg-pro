using System;
using System.Collections.Generic;
using System.Data;

namespace PRE.Main
{
    using DAL.Entities;
    using DevExpress.XtraTreeList.Nodes;

    public partial class FrmSelect : DevExpress.XtraEditors.XtraForm
    {
        public List<ZInfor> ListInfo { private set; get; }
        public DataTable DataSource { set; get; }

        public FrmSelect()
        {
            InitializeComponent();

            trlMain.Columns["No_"].Visible = false; // tạm thời ẩn cột STT
        }

        private void FrmSelect_Load(object sender, EventArgs e)
        {
            if (DataSource != null) trlMain.DataSource = DataSource;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ListInfo = new List<ZInfor>();

            foreach (TreeListNode n in trlMain.Nodes)
                if (n.Checked)
                {
                    var id = (Guid)n.GetValue("Id");
                    var name = n.GetValue("Name") + "";
                    var o = new ZInfor() { Id = id, Descript = name };
                    ListInfo.Add(o);
                }

            Close();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeListNode n in trlMain.Nodes) n.Checked = chkAll.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}