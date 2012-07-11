﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Plugin
{
    using System.Windows.Forms;

    /// <summary>
    /// Interface of plugin
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Description of plugin
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Author of plugin
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Version of plugin
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Form
        /// </summary>
        Form Form { get; }

        /// <summary>
        /// Host
        /// </summary>
        IHost Host { get; set; }

        /// <summary>
        /// Initialize plugin
        /// </summary>
        void Initialize();

        /// <summary>
        /// Dispose plugin
        /// </summary>
        void Dispose();

        /// <summary>
        /// Menu information
        /// </summary>
        Menuz Menu { get; }
    }
}