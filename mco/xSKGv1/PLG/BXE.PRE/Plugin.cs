using System;
using System.Collections.Generic;
using System.Linq;

namespace BXE.PRE
{
    using SKG.UTL.Plugin;
    using System.Windows.Forms;

    public abstract class Plugin : IPlugin
    {
        #region Implement plugin
        public string Author { get { return "Zng Tfy"; } }
        public string Description { get { return "Using xSGKv1 Framework for BXE - Transport"; } }
        public string Version { get { return "1.0"; } }

        public virtual Form Form { get { return null; } }
        public virtual IHost Host { get; set; }

        public virtual string Caption { get { return "Vận tải"; } }        
        public virtual string Picture { get { return @"Icon\Transport.png"; } }

        public void Initialize() { }
        public void Dispose() { Form.Dispose(); }
        #endregion
    }
}