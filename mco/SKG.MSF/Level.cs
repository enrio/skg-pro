using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.MSF
{
    using SKG.Plugin;
    using System.Windows.Forms;

    public abstract class Level : IPlugin
    {
        #region Implement plugin
        public string Author { get { return "Zng Tfy"; } }
        public string Description { get { return "xSGKv1 Framework 2012"; } }
        public string Version { get { return "1.0"; } }

        public virtual Form Form { get { return null; } }
        public virtual IHost Host { get; set; }
        public virtual Menuz Menuz { get; set; }

        public void Initialize() { }
        public void Dispose() { Form.Dispose(); }
        #endregion
    }
}