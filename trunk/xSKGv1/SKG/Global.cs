#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 10/11/2012 21:48
 * Update: 10/11/2012 21:48
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Data.Common;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

namespace SKG
{
    using DAL.Entities;

    /// <summary>
    /// Global objects
    /// </summary>
    public class Global
    {
        #region Methods
        /// <summary>
        /// Check valid printer
        /// </summary>
        /// <returns></returns>
        public static bool CheckPrinter()
        {
            bool online;
            try
            {
                var printDocument = new PrintDocument();
                online = printDocument.PrinterSettings.IsValid;
            }
            catch { online = false; }
            return online;
        }

        /// <summary>
        /// Get icon name
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public static string GetIconName(Type type)
        {
            var cls = type.Name.Split('_').Last();
            var nsp = type.Namespace.Split('.').Last();
            return cls.Contains("Level") ? nsp : cls;
        }
        #endregion

        #region Icon and panel constants
        /// <summary>
        /// Path of image icon
        /// </summary>
        public const string STR_ICON = @"Icons\{0}.png";

        /// <summary>
        /// Default title of dock panel 2
        /// </summary>
        public const string STR_PAN1 = "Nhập liệu";

        /// <summary>
        /// Default title of dock panel 2
        /// </summary>
        public const string STR_PAN2 = "Danh sách";
        #endregion

        #region Dictionary constants
        /// <summary>
        /// Code of group kind of data
        /// </summary>
        public const string STR_ROOT = "ROOT";

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
        /// Code of group region
        /// </summary>
        public const string STR_REGION = "REGION";

        /// <summary>
        /// Code of group area
        /// </summary>
        public const string STR_AREA = "AREA";

        /// <summary>
        /// Code of group province
        /// </summary>
        public const string STR_PROVINCE = "PROVINCE";

        /// <summary>
        /// Code of group busline (station)
        /// </summary>
        public const string STR_STATION = "STATION";

        /// <summary>
        /// Code of group busline (station)
        /// </summary>
        public const string STR_TRANSPORT = "TRANSPORT";

        /// <summary>
        /// Code of group shift
        /// </summary>
        public const string STR_SHIFT = "SHIFT";
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

        /// <summary>
        /// Get database connection
        /// </summary>
        public static DbConnection Connection
        {
            get
            {
                var db = new Context();
                return db.Database.Connection;
            }
        }
        #endregion
    }
}