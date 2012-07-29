using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SKG.DXF.Station.Sumary
{
    using SKG.Plugin;

    public partial class FrmTra_Sales : SKG.DXF.FrmInput
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Doanh thu", Level = 3, Order = 33, Picture = @"Icons\Base.png" };
                return menu;
            }
        }
        #endregion

        public FrmTra_Sales()
        {
            InitializeComponent();
        }
    }
}