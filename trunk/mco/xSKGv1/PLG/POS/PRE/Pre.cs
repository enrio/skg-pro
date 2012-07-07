using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.PRE
{
    using SKG.UTL.Plugin;
    public class Pre : Pos
    {
        #region Override plugin
        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Kiểm tra", Level = base.Menu.Level + 1, Order = 1, Picture = @"Icon\Test.png" };
                return menu;
            }
        }
        #endregion
    }
}