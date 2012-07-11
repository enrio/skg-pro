using System;
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

    public partial class FrmPrint : SKG.DXF.FrmInRight
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
                var menu = new Menuz() { Caption = "In ấn", Level = 3, Order = 7, Picture = @"Icon\Print.png" };
                return menu;
            }
        }
        #endregion
    }
}