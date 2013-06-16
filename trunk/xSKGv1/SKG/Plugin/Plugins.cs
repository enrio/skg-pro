#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 12/06/2013 06:07
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Collections.Generic;

namespace SKG.Plugin
{
    /// <summary>
    /// Available plugin
    /// </summary>
    public class Plugins
    {
        /// <summary>
        /// Menu information
        /// </summary>
        public Menuz Menuz { get; set; }

        /// <summary>
        /// Instance of plugin
        /// </summary>
        public IPlugin Instance { set; get; }

        /// <summary>
        /// Assembly path
        /// </summary>
        public string Path { set; get; }
    }
}