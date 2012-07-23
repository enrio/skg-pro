﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.DXF.Home.Sytem
{
    using SKG.Plugin;

    public class Level2 : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Hệ thống", Level = 2, Order = 2, Picture = @"Icons\System.png" };
                return menu;
            }
        }
        #endregion
    }
}