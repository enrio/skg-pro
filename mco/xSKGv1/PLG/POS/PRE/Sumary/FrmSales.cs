using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POS.PRE.Sumary
{
    public partial class FrmSales : FrmBase
    {
        public FrmSales()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override string Text1 { get { return "Doanh thu"; } }
        public override string Text2 { get { return "Sale"; } }
        public override string Icon { get { return @"Icon\Sales.png"; } }
        #endregion
    }
}