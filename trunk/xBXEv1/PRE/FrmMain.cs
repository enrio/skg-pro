using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace PRE
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region Catalog
        private void bbiPol_Right_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (var x in MdiChildren) if (x is Catalog.FrmPol_Right) return;
            var frm = new Catalog.FrmPol_Right() { MdiParent = this };
            frm.Text = "Quyền hạn";
            frm.Show();
        }
        #endregion
    }
}