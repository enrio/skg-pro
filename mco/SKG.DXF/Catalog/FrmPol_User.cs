using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Catalog
{
    using SKG.Plugin;

    public partial class FrmPol_User : SKG.DXF.FrmInRight
    {
        public FrmPol_User()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Người dùng", Level = 3, Order = 11, Picture = @"Images\Mail_16x16.png" };
                return menu;
            }
        }
        #endregion
    }
}