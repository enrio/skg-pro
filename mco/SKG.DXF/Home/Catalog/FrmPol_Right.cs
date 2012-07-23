using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Home.Catalog
{
    using SKG.Plugin;

    public partial class FrmPol_Right : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Chức năng", Level = 3, Order = 9, Picture = @"Icons\Right.png" };
                return menu;
            }
        }
        #endregion

        public FrmPol_Right()
        {
            InitializeComponent();
        }
    }
}