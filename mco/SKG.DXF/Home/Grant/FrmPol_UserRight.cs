using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Home.Grant
{
    using SKG.Plugin;

    public partial class FrmPol_UserRight : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Gán quyền người dùng", Level = 3, Order = 14, Picture = @"Icons\UserRight.png" };
                return menu;
            }
        }
        #endregion

        public FrmPol_UserRight()
        {
            InitializeComponent();
        }
    }
}