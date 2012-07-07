using System;
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
        public string Author { get { return "Zng Tfy"; } }
        public string Description { get { return "Using xSGKv1 Framework for POS - Point of sales"; } }
        public string Version { get { return "1.0"; } }

        public virtual Form Form { get { return this; } }
        public virtual IHost Host { get; set; }

        public virtual new Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Cơ sở", Level = 1, Order = 1, Picture = @"Icon\Base.png" };
                return menu;
            }
        }

        public void Initialize() { }
        #endregion
    }
}