using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.PRE.Report
{
    using SKG.UTL.Plugin;

    public partial class FrmPrint : FrmBase
    {
        public FrmPrint()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "In ấn", Level = 3, Order = 1, Picture = @"Icon\Print.png" };
                return menu;
            }
        }
        #endregion
    }
}