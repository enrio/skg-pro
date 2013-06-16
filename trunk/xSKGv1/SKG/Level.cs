#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:48
 * Update: 16/06/2013 08:32
 * Status: OK
 */
#endregion

using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SKG
{
    using SKG.Plugin;

    /// <summary>
    /// Level for menuz
    /// </summary>
    public abstract class Level : IPlugin
    {
        #region Implement plugin
        public string Author { get { return "Zng Tfy"; } }
        public string Description { get { return "xSGKv1 Framework 2012"; } }
        public string Version { get { return "1.0"; } }

        public virtual Form Form { get { return null; } }
        public virtual IHost Host { get; set; }

        /// <summary>
        /// Menuz of plugin
        /// </summary>
        public virtual Menuz Menuz { get; set; }

        public void Initialize() { }
        public void Dispose() { Form.Dispose(); }
        #endregion
    }
}