#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 23/07/2012 23:26
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Plugin
{
    /// <summary>
    /// Information menu
    /// </summary>
    public class Menuz
    {
        /// <summary>
        /// Menu of level
        /// </summary>
        public int Level { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Parent { set; get; }

        /// <summary>
        /// Default language
        /// </summary>
        public string Text { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string Note { set; get; }

        /// <summary>
        /// Namespace or type name
        /// </summary>
        public string Code { set; get; }

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

        public Menuz() { Show = true; }
    }
}