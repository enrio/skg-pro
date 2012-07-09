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
    using SKG.Plugin;

    public partial class FrmVehicle : FrmBase
    {
        public FrmVehicle()
        {
            InitializeComponent();
        }

        #region Override plugin
        public override Form Form { get { return this; } }

        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Xe cộ", Level = 3, Order = 5, Picture = @"Icon\Vehicle.png" };
                return menu;
            }
        }
        #endregion
    }
}