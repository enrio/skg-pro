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
    using SKG.Plugin;

    public partial class FrmTra_Sales : SKG.DXF.FrmInRight
    {
        public FrmTra_Sales()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Doanh thu", Level = 3, Order = 9, Picture = @"Icon\Sales.png" };
                return menu;
            }
        }
        #endregion
    }
}