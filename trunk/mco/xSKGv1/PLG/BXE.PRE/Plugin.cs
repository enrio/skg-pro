using System;
using System.Collections.Generic;
using System.Linq;

namespace BXE.PRE
{
    using SKG.UTL.Plugin;
    using System.Windows.Forms;

    public class Plugin : IPlugin
    {
        #region Implement plugin
        public string Author { get { return "Zng Tfy"; } }
        public string Description { get { return "Using xSGKv1 Framework for BXE - Transport"; } }
        public string Version { get { return "1.0"; } }

        public virtual Form Form { get { return null; } }
        public virtual IHost Host { get; set; }

        public virtual Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Vận tải", Level = 1, Order = 1, Picture = @"Icon\Transport.png" };
                return menu;
            }
        }

        public void Initialize() { }
        public void Dispose() { Form.Dispose(); }
        #endregion
    }
}