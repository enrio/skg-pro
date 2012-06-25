using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKG.PRE
{
    using UTL;
    using System.Windows.Forms;

    /// <summary>
    /// Extension Methods
    /// </summary>
    public static class BasePRE
    {
        /// <summary>
        /// Load menu from App.Config file
        /// </summary>
        /// <param name="m">MenuStrip</param>
        /// <param name="l">List App.Config file</param>
        public static void LoadMenu(this MenuStrip m, List<string> l)
        {
            foreach (var i in l)
            {
                var a = i.ToMenu("menu");
                if (a == null) continue;

                var oo = new ToolStripMenuItem(a[0].Text1);
                var b = m.Items.Add(oo);

                for (int j = 1; j < a.Count; j++) oo.DropDownItems.Add(a[j].Text1);
            }
        }
    }
}