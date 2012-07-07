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
        public new string Text1 { get { return "Doanh thu"; } }
        public new string Text2 { get { return "Sale"; } }
        public new string Type { get { return GetType().FullName; } }
        public new string Icon { get { return @"Icon\Sales.png"; } }
        #endregion
    }
}