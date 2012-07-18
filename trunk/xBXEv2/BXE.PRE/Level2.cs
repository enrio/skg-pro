using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BXE.PRE
{
    using SKG.Plugin;

    public class Level2 : Level1
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Kiểm tra", Level = 2, Order = 10, Picture = @"Icon\Test.png" };
                return menu;
            }
        }
        #endregion
    }
}