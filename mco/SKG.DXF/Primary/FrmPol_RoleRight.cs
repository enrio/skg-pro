using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Primary
{
    using SKG.DXF;
    using SKG.Plugin;

    public partial class FrmPol_RoleRight : SKG.DXF.FrmInRight
    {
        public FrmPol_RoleRight()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Nhóm quyền", Level = 3, Order = 11, Picture = @"Icon\Test.png" };
                return menu;
            }
        }
        #endregion
    }
}