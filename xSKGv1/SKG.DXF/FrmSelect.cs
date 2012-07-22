using System;
using System.Collections.Generic;
using System.Data;

namespace SKG.DXF
{
    using DAL.Entities;
    using DevExpress.XtraTreeList.Nodes;

    public partial class FrmSelect : SKG.DXF.FrmMenuz
    {
        /// <summary>
        /// Dữ liệu được chọn
        /// </summary>
        public List<ZBase> ListInfo { private set; get; }

        /// <summary>
        /// Dữ liệu cần để chọn
        /// </summary>
        public DataTable DataSource { set; get; }

        /// <summary>
        /// Tiêu đề của cột Name
        /// </summary>
        public string Caption { set; get; }

        public FrmSelect()
        {
            InitializeComponent();

            trlMain.Columns["No_"].Visible = false; // tạm thời ẩn cột STT
        }

        private void FrmSelect_Load(object sender, EventArgs e)
        {
            treeListColumn3.Caption = Caption;
            if (DataSource != null) trlMain.DataSource = DataSource;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ListInfo = new List<ZBase>();

            foreach (TreeListNode n in trlMain.Nodes)
                if (n.Checked)
                {
                    var id = (Guid)n.GetValue("Id");
                    var name = n.GetValue("Name") + "";
                    var o = new ZBase() { Id = id, Descript = name };
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