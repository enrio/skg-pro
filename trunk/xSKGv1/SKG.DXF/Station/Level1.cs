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
                var type = typeof(Level1);
                var name = Global.GetIconName(type);

                var menu = new Menuz
                {
                    Code = type.FullName,
                    Parent = typeof(Level1).FullName,
                    Text = STR_TITLE,
                    Level = 3,
                    Order = 27,
                    Picture = String.Format(STR_ICON, name)
                };
                return menu;
            }
        }
        #endregion

        #region Implements
        #endregion

        #region Overrides
        #endregion

        #region Methods
        #endregion

        #region Events
        #endregion

        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constants
        private const string STR_TITLE = "Bến xe";
        private const string STR_ICON = @"Icons\{0}.png";

        private const string STR_PAN1 = "Nhập liệu";
        private const string STR_PAN2 = "Danh sách";
        #endregion
    }
}