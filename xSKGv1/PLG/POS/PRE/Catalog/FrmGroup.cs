using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.PRE.Catalog
{
    using SKG.Plugin;

    public partial class FrmGroup : SKG.DXF.FrmInRight
    {
        public FrmGroup()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Nhóm hàng", Level = 3, Order = 3, Picture = @"Icon\Group.png" };
                return menu;
            }
        }
        #endregion
    }
}