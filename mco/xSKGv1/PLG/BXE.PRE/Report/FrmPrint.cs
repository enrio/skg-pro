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
    public partial class FrmPrint : FrmBase
    {
        public FrmPrint()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override string Caption { get { return "In ấn"; } }        
        public override string Picture { get { return @"Icon\Print.png"; } }
        #endregion
    }
}