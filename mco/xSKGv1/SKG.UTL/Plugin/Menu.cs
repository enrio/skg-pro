using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL.Plugin
{
    /// <summary>
    /// Information menu
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Menu of level
        /// </summary>
        public int Level { set; get; }

        /// <summary>
        /// Default language
        /// </summary>
        public string Caption { set; get; }

        /// <summary>
        /// Namespace or type name
        /// </summary>
        public string Type { set; get; }

        /// <summary>
        /// Picture for icon
        /// </summary>
        public string Picture { set; get; }

        /// <summary>
        /// Order
        /// </summary>
        public int Order { set; get; }

        /// <summary>
        /// Allow menu show
        /// </summary>
        public bool Show { set; get; }

        public Menu() { Show = true; }
    }
}