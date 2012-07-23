using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.DXF.Home.Grant
{
    using SKG.Plugin;

    public class Level2 : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Phân quyền", Level = 3, Order = 13, Picture = @"Icons\Permission.png" };
                return menu;
            }
        }
        #endregion
    }
}