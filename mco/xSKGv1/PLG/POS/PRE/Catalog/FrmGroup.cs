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
    public partial class FrmGroup : FrmBase
    {
        public FrmGroup()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override string Text1 { get { return "Nhóm hàng"; } }
        public override string Text2 { get { return "Group"; } }
        public override string Icon { get { return @"Icon\Group.png"; } }
        #endregion
    }
}