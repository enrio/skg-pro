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
    /// Menuz - Exit
    /// </summary>
    public class FrmPol_Exit : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(FrmPol_Exit).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "Thoát",
                    Level = 3,
                    Order = 7,
                    Picture = @"Icons\Exit.png"
                };
                return menu;
            }
        }
        #endregion
    }
}