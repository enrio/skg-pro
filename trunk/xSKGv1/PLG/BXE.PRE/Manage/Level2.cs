using System;
using System.Collections.Generic;
using System.Linq;

namespace BXE.PRE.Manage
{
    using SKG.Plugin;

    public class Level2 : Level1
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Quản lý", Level = 2, Order = 12, Picture = @"Icon\Catalog.png" };
                return menu;
            }
        }
        #endregion
    }
}