using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SKG.DXF
{
    using SKG.Plugin;

    public abstract partial class FrmMenuz : DevExpress.XtraEditors.XtraForm, IPlugin
    {
        #region Implement plugin
        public string Author { get { return "Zng Tfy"; } }
        public string Description { get { return "xSGKv1 Framework 2012 - Menuz"; } }
        public string Version { get { return "1.0"; } }

        public virtual Form Form { get { return null; } }
        public virtual IHost Host { get; set; }
        public virtual Menuz Menuz { get; set; }

        public void Initialize() { }
        #endregion

        public FrmMenuz()
        {
            InitializeComponent();
        }
    }
}