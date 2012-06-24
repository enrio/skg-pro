using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.UTL.Plugin
{
    /// <summary>
    /// Plugin's information for load menus
    /// </summary>
    public sealed class Info
    {
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
    }
}