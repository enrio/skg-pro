using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF.Catalog
{
    using SKG.Plugin;

    public class Level2 : Level1
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Danh mục", Level = 2, Order = 8, Picture = @"Icons\Category.png" };
                return menu;
            }
        }
        #endregion
    }
}