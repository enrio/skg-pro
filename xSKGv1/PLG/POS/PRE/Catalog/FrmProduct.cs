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

    public partial class FrmProduct : SKG.DXF.FrmInRight
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Sản phẩm", Level = 3, Order = 5, Picture = @"Icon\Product.png" };
                return menu;
            }
        }
        #endregion
    }
}