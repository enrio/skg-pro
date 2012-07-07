using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.PRE.Sumary
{
    using SKG.UTL.Plugin;

    public class Sumary : Pos
    {
        #region Override plugin
        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Thống kê", Level = 2, Order = 1, Picture = @"Icon\Sumary.png" };
                return menu;
            }
        }
        #endregion
    }
}