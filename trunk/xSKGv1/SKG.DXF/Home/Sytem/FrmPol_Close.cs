#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 29/07/2012 10:27
 * Update: 30/07/2012 20:27
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF.Home.Sytem
{
    using SKG.Plugin;

    /// <summary>
    /// Menuz - Close all form
    /// </summary>
    public class FrmPol_Close : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz() { Caption = "Đóng hết", Level = 3, Order = 6, Picture = @"Icons\Close.png" };
                return menu;
            }
        }
        #endregion
    }
}