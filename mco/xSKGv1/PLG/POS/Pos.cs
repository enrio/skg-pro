using System;
using System.Collections.Generic;
using System.Linq;

namespace POS
{
    using SKG.UTL.Plugin;
    using System.Windows.Forms;

    public class Pos : IPlugin
    {
        #region Implement plugin
        public string Author { get { return "Zng Tfy"; } }
        public string Description { get { return "Using xSGKv1 Framework for POS - Point of sales"; } }
        public string Version { get { return "1.0"; } }

        public virtual Form Form { get { return null; } }
        public virtual IHost Host { get; set; }

        public virtual Menuz Menu
        {
            get
            {
                var menu = new Menuz() { Caption = "Bán hàng", Level = 1, Order = 1, Picture = @"Icon\POS.png" };
                return menu;
            }
        }

        public void Initialize() { }
        public void Dispose() { Form.Dispose(); }
        #endregion
    }
}