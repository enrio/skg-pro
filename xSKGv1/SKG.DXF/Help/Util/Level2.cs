#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 29/07/2012 10:27
 * Update: 29/07/2012 10:27
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF.Help.Util
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
                    Text = "Tiện ích",
                    Level = 2,
                    Order = 991,
                    Picture = @"Icons\Util.png"
                };
                return menu;
            }
        }
        #endregion
    }
}