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
    using SKG.PRE;
    using SKG.Plugin;

    public partial class FrmTra_Kind : FrmBase
    {
        public FrmTra_Kind()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Loại xe", Level = 3, Order = 4, Picture = @"Icon\Kind.png" };
                return menu;
            }
        }
        #endregion
    }
}