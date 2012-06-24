using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BXE.PRE
{
    using SKG.UTL.Plugin;

    public partial class FrmDemo : Form, IPlugin
    {
        public FrmDemo()
        {
            InitializeComponent();
        }

        #region Implement plugin
        public string Name { get { return ""; } }
        public string Description { get { return "Demo plugin"; } }
        public string Author { get { return "Zng Tfy"; } }
        public string Version { get { return "1.0"; } }

        public UserControl Usrcontrol { get { return null; } }
        public Form Frmcontrol { get { return this; } }
        public IHost Host { get; set; }

        public void Initialize() { }
        public void Dispose() { }
        #endregion
    }
}