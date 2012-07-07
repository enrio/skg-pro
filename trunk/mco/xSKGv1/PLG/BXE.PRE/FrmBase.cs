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

    public partial class FrmBase : Form, IPlugin
    {
        public FrmBase()
        {
            InitializeComponent();
        }

        #region Implement plugin
        public string Author { get { return ""; } }
        public string Description { get { return ""; } }
        public string Version { get { return ""; } }

        public new Form Form { get { return this; } }
        public IHost Host { get; set; }

        public void Initialize() { }

        public string Text1 { get { return ""; } }
        public string Text2 { get { return ""; } }
        public string Type { get { return GetType().FullName; } }
        public new string Icon { get { return ""; } }
        #endregion
    }
}