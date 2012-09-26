using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF.Station.Discrete
{
    using SKG.Plugin;

    public class Level2 : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Code = typeof(Level2).FullName, Parent = typeof(Level1).FullName, Text = "Vãng lai", Level = 2, Order = 22, Picture = @"Icons\Catalog.png" };
                return menu;
            }
        }
        #endregion
    }
}