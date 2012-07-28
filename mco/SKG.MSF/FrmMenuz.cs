using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SKG.MSF
{
    using SKG.Plugin;

    /// <summary>
    /// For menuz within input form
    /// </summary>
    public partial class FrmMenuz : Form, IPlugin
    {
        #region Implement plugin
        public string Author { get { return "Zng Tfy"; } }
        public string Description { get { return "xSGKv1 Framework 2012 - For menuz within input form"; } }
        public string Version { get { return "1.0"; } }

        public virtual Form Form { get { return null; } }
        public virtual IHost Host { get; set; }
        public virtual Menuz Menuz { get { return new Menuz(); } }

        public void Initialize() { }
        #endregion

        public FrmMenuz()
        {
            InitializeComponent();
        }
    }
}