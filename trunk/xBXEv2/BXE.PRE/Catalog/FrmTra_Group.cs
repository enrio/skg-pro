using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BXE.PRE.Catalog
{
    using SKG.Plugin;

    public partial class FrmTra_Group : SKG.DXF.FrmInRight
    {
        public FrmTra_Group()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Nhóm xe", Level = 3, Order = 3, Picture = @"Icon\Group.png" };
                return menu;
            }
        }
        #endregion
    }
}