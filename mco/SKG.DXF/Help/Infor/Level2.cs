﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.DXF.Help.Infor
{
    using SKG.Plugin;

    public class Level2 : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Thông tin", Level = 2, Order = 6, Picture = @"Icons\Catalog.png" };
                return menu;
            }
        }
        #endregion
    }
}