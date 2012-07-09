using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.PRE.Report
{
    using SKG.Plugin;

    public class Level2 : Level1
    {
        #region Override plugin
        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Báo cáo", Level = base.Menu.Level + 1, Order = 6, Picture = @"Icon\Report.png" };
                return menu;
            }
        }
        #endregion
    }
}