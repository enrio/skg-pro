﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.PRE
{
    using SKG.UTL.Plugin;

    public partial class FrmBase : Form, IPlugin
    {
        public FrmBase()
        {
            InitializeComponent();
        }

        #region Implement plugin
        public new string Name { get { return ""; } }
        public string Description { get { return "Demo plugin"; } }
        public string Author { get { return "Zng Tfy"; } }
        public string Version { get { return "1.0"; } }

        public Form Form { get { return this; } }
        public IHost Host { get; set; }

        public void Initialize() { }
        public new void Dispose() { }

        public new string Icon { get { return @"Icon\Base.png"; } }
        public string Text1 { get { return "Cơ sở"; } }
        public string Text2 { get { return "Base"; } }
        public string Type { get { return GetType().FullName; } }
        #endregion
    }
}