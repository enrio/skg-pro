#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:17
 * Update: 08/11/2012 19:52
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF.Station.Sumary
{
    using SKG.Plugin;

    public class Level2 : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(Level2).FullName,
                    Parent = typeof(Level1).FullName,
                    Text = "Thống kê",
                    Level = 2,
                    Order = 27,
                    Picture = @"Icons\Sumary.png"
                };
                return menu;
            }
        }
        #endregion
    }
}