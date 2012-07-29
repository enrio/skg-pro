﻿using System;
using System.Collections.Generic;
using System.Linq;

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
                var menu = new Menuz() { Caption = "Thống kê", Level = 2, Order = 32, Picture = @"Icons\Sumary.png" };
                return menu;
            }
        }
        #endregion
    }
}