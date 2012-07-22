using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF.Help
{
    using SKG.Plugin;

    public class Level1 : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Trợ giúp", Level = 1, Order = 990, Picture = @"Icons\Help.png" };
                return menu;
            }
        }
        #endregion
    }
}