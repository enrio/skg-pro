using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL.Plugin
{
    /// <summary>
    /// Available plugin
    /// </summary>
    public sealed class Plugin : Menu
    {
        /// <summary>
        /// Instance of plugin
        /// </summary>
        public IPlugin Instance { set; get; }

        /// <summary>
        /// Assembly path
        /// </summary>
        public string Path { set; get; }

        public Plugin() { Show = true; }
    }
}