﻿using System;
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

                // Menu's level 1 (root)
                var m1 = new ToolStripMenuItem(a[0].Text1);
                m.Items.Add(m1);

                // Menu's level 2, 3
                ToolStripMenuItem m2 = null;
                for (int j = 1; j < a.Count; j++)
                {
                    if (a[j].ParentId == "1") // Menu's level 2
                    {
                        m2 = new ToolStripMenuItem(a[j].Text1);
                        m1.DropDownItems.Add(m2);
                    }
                    else if (m2 != null)
                    {
                        var m3 = new ToolStripMenuItem(a[j].Text1);
                        m2.DropDownItems.Add(m3);
                    }
                }
            }
        }
    }
}