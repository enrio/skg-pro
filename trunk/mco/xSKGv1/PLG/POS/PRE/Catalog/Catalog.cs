using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.PRE.Catalog
{
    using SKG.UTL.Plugin;

    public class Catalog : Pos
    {
        #region Override plugin
        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Danh mục", Level = 2, Order = 1, Picture = @"Icon\Catalog.png" };
                return menu;
            }
        }
        #endregion
    }
}