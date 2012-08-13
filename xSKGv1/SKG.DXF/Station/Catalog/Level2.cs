using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF.Station.Catalog
{
    using SKG.Plugin;

    public class Level2 : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Code = typeof(Level2).FullName, Parent = typeof(Level1).FullName, Text = "Danh mục", Level = 2, Order = 19, Picture = @"Icons\Catalog.png" };
                return menu;
            }
        }
        #endregion
    }
}