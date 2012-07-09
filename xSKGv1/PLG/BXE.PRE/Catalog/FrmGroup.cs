﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BXE.PRE.Catalog
{
    using SKG.Plugin;
    using SKG.PRE.Catalog;

    public partial class FrmGroup : FrmBase
    {
        public FrmGroup()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Nhóm xe", Level = 3, Order = 3, Picture = @"Icon\Group.png" };
                return menu;
            }
        }
        #endregion
    }
}