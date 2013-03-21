#region Information
/*
 * Author: Zng Tfy
 * Email: nvt87x@gmail.com
 * Phone: +84 1645 515 010
 * ---------------------------
 * Create: 23/07/2012 21:17
 * Update: 08/11/2012 19:52
 * Status: OK
 */
#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SKG.DXF
{
    using SKG.Plugin;

    /// <summary>
    /// For menuz within input form
    /// </summary>
    public partial class FrmMenuz : DevExpress.XtraEditors.XtraForm, IPlugin
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