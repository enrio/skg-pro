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

    public partial class FrmKind : FrmBase
    {
        public FrmKind()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Loại hàng", Level = 3, Order = 4, Picture = @"Icon\Kind.png" };
                return menu;
            }
        }
        #endregion
    }
}