﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.PRE.Catalog
{
    using SKG.UTL.Plugin;

    public partial class FrmProduct : FrmBase
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Sản phẩm", Level = 3, Order = 1, Picture = @"Icon\Product.png" };
                return menu;
            }
        }
        #endregion
    }
}