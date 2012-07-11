using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BXE.PRE.Catalog
{
    using SKG.Plugin;

    public partial class FrmTra_Kind : SKG.DXF.FrmInRight
    {
        public FrmTra_Kind()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Loại xe", Level = 3, Order = 4, Picture = @"Icon\Kind.png" };
                return menu;
            }
        }
        #endregion
    }
}