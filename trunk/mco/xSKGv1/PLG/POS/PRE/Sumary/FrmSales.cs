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

        public override string Caption { get { return "Doanh thu"; } }
        public override string Picture { get { return @"Icon\Sales.png"; } }
        #endregion
    }
}