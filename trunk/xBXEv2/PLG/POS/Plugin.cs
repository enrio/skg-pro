using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS
{
    using SKG.UTL.Plugin;
    using System.Windows.Forms;

    public class Plugin : IPlugin
    {
        #region Implement plugin
        public string Name { get { return ""; } }
        public string Description { get { return "Demo plugin"; } }
        public string Author { get { return "Zng Tfy"; } }
        public string Version { get { return "1.0"; } }

        public UserControl Usrcontrol { get { return null; } }
        public Form Frmcontrol { get { return null; } }
        public IHost Host { get; set; }

        public void Initialize() { }
        public void Dispose() { }
        #endregion
    }
}