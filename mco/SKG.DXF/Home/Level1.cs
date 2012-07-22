using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.DXF.Home
{
    using SKG.Plugin;

    public class Level1 : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Trang chính", Level = 1, Order = 1, Picture = @"Icons\Home.png" };
                return menu;
            }
        }
        #endregion
    }
}