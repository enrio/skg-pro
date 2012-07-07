using System;
using System.Collections.Generic;
using System.Linq;

namespace POS
{
    using SKG.UTL.Plugin;
    using System.Windows.Forms;

    public abstract class Plugin : IPlugin
    {
        #region Implement plugin
        public string Author { get { return "Zng Tfy"; } }
        public string Description { get { return "Using xSGKv1 Framework for POS - Point of sales"; } }
        public string Version { get { return "1.0"; } }

        public virtual Form Form { get { return null; } }
        public virtual IHost Host { get; set; }

        public virtual string Text1 { get { return "Bán hàng"; } }
        public virtual string Text2 { get { return "Point of sales"; } }
        public virtual string Icon { get { return @"Icon\POS.png"; } }

        public void Initialize() { }
        public void Dispose() { Form.Dispose(); }
        #endregion
    }
}