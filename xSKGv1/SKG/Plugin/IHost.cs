using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Plugin
{
    /// <summary>
    /// Interface of host
    /// </summary>
    public interface IHost
    {
        /// <summary>
        /// Feed back
        /// </summary>
        /// <param name="feedBack">Feed back</param>
        /// <param name="plugin">Plugin</param>
        void FeedBack(string feedBack, IPlugin plugin);

        /// <summary>
        /// Register plugin
        /// </summary>
        /// <param name="plugin">Plugin</param>
        /// <returns></returns>
        bool Register(IPlugin plugin);

        /// <summary>
        /// Load all plugins
        /// </summary>
        void LoadPlugins();
    }
}