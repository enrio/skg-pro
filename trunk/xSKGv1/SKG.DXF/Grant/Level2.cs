using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF.Grant
{
    using SKG.Plugin;

    public class Level2 : Level1
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Phân quyền", Level = 2, Order = 41, Picture = @"Resources\main.png" };
                return menu;
            }
        }
        #endregion
    }
}