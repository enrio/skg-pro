#region Information
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
    using DAL.Entities;
    using System.Data.Common;
    using System.Windows.Forms;
    using System.Drawing.Printing;

    /// <summary>
    /// Global objects
    /// </summary>
    public class Global
    {
        /// <summary>
        /// Check valid printing
        /// </summary>
        /// <returns></returns>
        public static bool CheckPrinter()
        {
            var prter = new PrinterSettings();
            return prter.IsValid;
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