﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BXE.PRE
{
    using SKG.Plugin;

    public partial class FrmTest : SKG.DXF.FrmInput
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Kiểm tra", Level = 3, Order = 11, Picture = @"Icon\Test.png" };
                return menu;
            }
        }
        #endregion
    }
}