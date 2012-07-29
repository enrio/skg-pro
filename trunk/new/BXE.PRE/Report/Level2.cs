using System;
using System.Collections.Generic;
using System.Linq;

namespace BXE.PRE.Report
{
    using SKG.Plugin;

    public class Level2 : Level1
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Báo cáo", Level = 2, Order = 30, Picture = @"Icons\Report.png" };
                return menu;
            }
        }
        #endregion
    }
}