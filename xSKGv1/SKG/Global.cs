﻿#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 09/08/2013 20:32
 * Update: 09/08/2013 20:32
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG
{
    using System.Windows.Forms;

    /// <summary>
    /// Global objects
    /// </summary>
    public class Global
    {
        #region Dictionary constants
        /// <summary>
        /// Code of group language
        /// </summary>
        public const string STR_LANG = "LANG";

        /// <summary>
        /// Code of group button
        /// </summary>
        public const string STR_BUTTON = "BUTTON";

        /// <summary>
        /// Code of group role
        /// </summary>
        public const string STR_ROLE = "ROLE";

        /// <summary>
        /// Code of group right (menuz)
        /// </summary>
        public const string STR_RIGHT = "RIGHT";

        /// <summary>
        /// Code of group vehicle
        /// </summary>
        public const string STR_GROUP = "GROUP";

        /// <summary>
        /// Code of group area
        /// </summary>
        public const string STR_AREA = "AREA";

        /// <summary>
        /// Code of group region
        /// </summary>
        public const string STR_REGION = "REGION";

        /// <summary>
        /// Code of group busline
        /// </summary>
        public const string STR_LINE = "LINE";
        #endregion

        #region Global properties
        /// <summary>
        /// Session of current an user logon
        /// </summary>
        public static Session Session { get; set; }

        /// <summary>
        /// Form MDI parent
        /// </summary>
        public static Form Parent { get; set; }

        /// <summary>
        /// Static service for plugin
        /// </summary>
        public static Services Service = new Services();
        #endregion
    }
}