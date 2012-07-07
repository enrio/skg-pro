﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL.Plugin
{
    /// <summary>
    /// Available plugin
    /// </summary>
    public sealed class AvailablePlugin
    {
        #region Menu
        /// <summary>
        /// Menu's level
        /// </summary>
        public int Level { set; get; }

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
        /// Picture for icon
        /// </summary>
        public string Icon { set; get; }

        /// <summary>
        /// Enable
        /// </summary>
        public bool Show { set; get; }
        #endregion

        #region Plugin
        /// <summary>
        /// Instance of plugin
        /// </summary>
        public IPlugin Instance { set; get; }

        /// <summary>
        /// Assembly path
        /// </summary>
        public string Path { set; get; }
        #endregion

        public AvailablePlugin() { Show = true; }
    }
}