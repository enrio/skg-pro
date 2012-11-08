#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:17
 * Update: 23/07/2012 22:17
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF.Station
{
    using SKG.Plugin;

    public class Level1 : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(Level1).FullName,
                    Parent = "",
                    Text = "Bến xe",
                    Level = 1,
                    Order = 1,
                    Picture = @"Icons\Station.png"
                };
                return menu;
            }
        }
        #endregion
    }
}