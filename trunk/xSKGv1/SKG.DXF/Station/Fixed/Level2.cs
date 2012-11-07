using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF.Station.Fixed
{
    using SKG.Plugin;

    public class Level2 : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz { Code = typeof(Level2).FullName,
                Parent = typeof(Level1).FullName,
                Text = "Cố định",
                Level = 2,
                Order = 24,
                Picture = @"Icons\Catalog.png" };
                return menu;
            }
        }
        #endregion
    }
}