using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BXE.PRE.Catalog
{
    public partial class FrmKind : FrmBase
    {
        public FrmKind()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override string Text1 { get { return "Loại xe"; } }
        public override string Text2 { get { return "Kind"; } }
        public override string Icon { get { return @"Icon\Kind.png"; } }
        #endregion
    }
}