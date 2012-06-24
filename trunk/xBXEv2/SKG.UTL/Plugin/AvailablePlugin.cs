using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL.Plugin
{
    /// <summary>
    /// Available plugin
    /// </summary>
    public sealed class AvailablePlugin
    {
        /// <summary>
        /// Instance of plugin
        /// </summary>
        public IPlugin Instance { set; get; }

        /// <summary>
        /// Assembly path
        /// </summary>
        public string Path { set; get; }

        /// <summary>
        /// Vietnamese name
        /// </summary>
        public string Vn { set; get; }

        /// <summary>
        /// English name
        /// </summary>
        public string En { set; get; }

        /// <summary>
        /// Namespace name
        /// </summary>
        public string Ns { set; get; }

        public AvailablePlugin() { Instance = null; Path = ""; }
    }
}