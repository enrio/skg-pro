﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 10/11/2012 21:48
 * Update: 02/06/2013 07:54
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Collections.Generic;

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
                    Parent = typeof(Level).FullName,
                    Text = STR_TITLE,
                    Level = 1,
                    Order = 0,
                    Picture = String.Format(Global.STR_ICON, name)
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

        public const string STR_CFM = "IN BÁO CÁO (CHỌN YES), BẢNG KÊ (CHỌN NO)";
        public const string STR_PRINT = "In thống kê";
        public const string STR_DT = "{0}{1:_dd.MM.yyyy_HH.mm.ss}_tk";
        #endregion
    }
}