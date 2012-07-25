using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.DXF.Help.Util
{
    using SKG.Plugin;

    public class Level2 : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Tiện ích", Level = 2, Order = 991, Picture = @"Icons\Catalog.png" };
                return menu;
            }
        }
        #endregion
    }
}