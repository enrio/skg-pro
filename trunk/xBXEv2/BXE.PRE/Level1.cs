using System;
using System.Collections.Generic;
using System.Linq;

namespace BXE.PRE
{
    using SKG.Plugin;

    public class Level1 : SKG.Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Vận tải", Level = 1, Order = 20, Picture = @"Icons\Transport.png" };
                return menu;
            }
        }
        #endregion
    }
}