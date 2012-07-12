﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SKG.DXF
{
    using SKG.Plugin;

    public partial class FrmNoRight : XtraForm, IPlugin
    {
        public FrmNoRight()
        {
            InitializeComponent();
        }

        #region Implement plugin
        public string Author { get { return "Zng Tfy"; } }
        public string Description { get { return "xSGKv1 Framework"; } }
        public string Version { get { return "1.0"; } }

        public virtual Form Form { get { return this; } }
        public virtual IHost Host { get; set; }

        public virtual new Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Cơ sở", Level = 3, Order = 0, Picture = @"Icon\Base.png" };
                return menu;
            }
        }

        public void Initialize() { }
        #endregion
    }
}