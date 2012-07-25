using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.DXF
{
    using BLL;
    using Plugin;
    using System.Windows.Forms;

    public class Global
    {
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