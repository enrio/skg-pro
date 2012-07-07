using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.PRE.Report
{
    using SKG.UTL.Plugin;

    public class Report : Pos
    {
        #region Override plugin
        public override Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Báo cáo", Level = 2, Order = 1, Picture = @"Icon\Report.png" };
                return menu;
            }
        }
        #endregion
    }
}