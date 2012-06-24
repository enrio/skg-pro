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
        /// Primary key
        /// </summary>
        public string Id { set; get; }

        /// <summary>
        /// Parent ID
        /// </summary>
        public string ParentId { set; get; }

        /// <summary>
        /// Assembly path
        /// </summary>
        public string Path { set; get; }

        /// <summary>
        /// Default language
        /// </summary>
        public string Text1 { set; get; }

        /// <summary>
        /// Second language
        /// </summary>
        public string Text2 { set; get; }

        /// <summary>
        /// Namespace or type name
        /// </summary>
        public string Type { set; get; }

        /// <summary>
        /// Enable
        /// </summary>
        public bool Show { set; get; }

        /// <summary>
        /// Order by
        /// </summary>
        public int Order { set; get; }

        /// <summary>
        /// Instance of plugin
        /// </summary>
        public IPlugin Instance { set; get; }

        public AvailablePlugin() { Show = true; }
    }
}