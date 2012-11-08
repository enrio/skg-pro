﻿#region Information
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

    public class Frm_Update : Level
    {
        #region Override plugin
        public override Menuz Menuz
        {
            get
            {
                var menu = new Menuz
                {
                    Code = typeof(Frm_Update).FullName,
                    Parent = typeof(Level2).FullName,
                    Text = "Sử dụng",
                    Level = 3,
                    Order = 997,
                    Picture = @"Icons\Update.png"
                };
                return menu;
            }
        }
        #endregion
    }
}