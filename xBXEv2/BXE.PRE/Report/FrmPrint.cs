﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BXE.PRE.Report
{
    using SKG.Plugin;

    public partial class FrmPrint : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "In ấn", Level = 3, Order = 31, Picture = @"Icons\Base.png" };
                return menu;
            }
        }
        #endregion

        public FrmPrint()
        {
            InitializeComponent();
        }
    }
}