using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BXE.PRE.Sumary
{
    using SKG.UTL.Plugin;

    public partial class FrmSales : FrmBase
    {
        public FrmSales()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Doanh thu", Level = 1, Order = 1, Picture = @"Icon\Sales.png" };
                return menu;
            }
        }
        #endregion
    }
}