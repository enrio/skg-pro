using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF.Sytem
{
    using SKG.Plugin;

    public class Level2 : Level1
    {
        #region Override plugin
        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Hệ thống", Level = 2, Order = 21, Picture = @"Resources\lease.png" };
                return menu;
            }
        }
        #endregion
    }
}