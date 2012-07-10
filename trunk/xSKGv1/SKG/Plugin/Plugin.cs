using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Plugin
{
    /// <summary>
    /// Available plugin
    /// </summary>
    public class Plugin
    {
        /// <summary>
        /// Menu information
        /// </summary>
        public Menuz Menu { get; set; }

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