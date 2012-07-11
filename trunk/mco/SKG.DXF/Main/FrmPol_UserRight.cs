using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Main
{
    using SKG.Plugin;

    public partial class FrmPol_UserRight : SKG.DXF.FrmInRight
    {
        public FrmPol_UserRight()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Phân quyền cho người", Level = 3, Order = 11, Picture = @"Images\Mail_16x16.png" };
                return menu;
            }
        }
        #endregion
    }
}