using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Extend
{
    using Plugin;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;

    /// <summary>
    /// Load menu
    /// </summary>
    public static class Load
    {
        /// <summary>
        /// Form MDI parent
        /// </summary>
        public static Form Parent { get; set; }

        /// <summary>
        /// Load menu for MenuStrip
        /// </summary>
        /// <param name="m">MenuStrip</param>
        /// <param name="s">Path's Menu.xml</param>
        public static void LoadMenu(this MenuStrip m, List<string> l, Form f = null)
        {
            Parent = f;
            foreach (var i in l) m.LoadMenu(i);
        }

        /// <summary>
        /// Load menu for MenuStrip
        /// </summary>
        /// <param name="m">MenuStrip</param>
        /// <param name="s">Path's Menu.xml</param>
        public static void LoadMenu(this MenuStrip m, string s)
        {
            var menu = Services.GetMenu(s);
            ToolStripMenuItem m1 = null;
            ToolStripMenuItem m2 = null;

            for (int j = 0; j < menu.Count; j++)
            {
                if (menu[j].Level == 1) // menu level 1 (root)
                {
                    m1 = new ToolStripMenuItem(menu[j].Caption);
                    m1.Image = Image.FromFile(s + menu[j].Picture);
                    m.Items.Add(m1);
                }
                else if (menu[j].Level == 2) // menu level 2
                {
                    m2 = new ToolStripMenuItem(menu[j].Caption);
                    m2.Image = Image.FromFile(s + menu[j].Picture);
                    m1.DropDownItems.Add(m2);
                }
                else if (m2 != null) // menu level 3
                {
                    var m3 = new ToolStripMenuItem(menu[j].Caption);
                    m2.DropDownItems.Add(m3);

                    Assembly y = null;
                    try { y = Assembly.LoadFile(s + "BXE.PRE.dll"); }
                    catch { y = Assembly.LoadFile(s + "POS.dll"); }

                    m3.Tag = y.CreateInstance(menu[j].Type);
                    m3.Image = Image.FromFile(s + menu[j].Picture);
                    m3.Click += MenuItem_Click;
                }
            }
        }

        private static void MenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var t = (ToolStripMenuItem)sender;
                var f = (Form)t.Tag;
                if (Parent != null) f.MdiParent = Parent;
                f.Show();
                f.Activate();
            }
            catch { return; }
        }
    }
}