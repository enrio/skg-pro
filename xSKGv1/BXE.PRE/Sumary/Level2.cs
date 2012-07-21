using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BXE.PRE.Sumary
{
    using SKG.Plugin;

    public class Level2 : Level1
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Thống kê", Level = 2, Order = 8, Picture = @"Icon\Sumary.png" };
                return menu;
            }
        }
        #endregion
    }
}