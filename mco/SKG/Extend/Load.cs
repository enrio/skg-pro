using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.Extend
{
    using Plugin;
    using System.IO;
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
        /// Load all menu for MenuStrip
        /// </summary>
        /// <param name="m">Menu strip</param>
        /// <param name="l">List all of plugin file name</param>
        /// <param name="f">Parent</param>
        public static void LoadMenu(this MenuStrip m, List<string> l, Form f = null)
        {
            Parent = f;
            foreach (var i in l) m.LoadMenu(i);
        }

        /// <summary>
        /// Load menu for MenuStrip
        /// </summary>
        /// <param name="m">Menu strip</param>
        /// <param name="s">Plugin file name</param>
        public static void LoadMenu(this MenuStrip m, string s)
        {
            var menu = Services.GetMenu(s);
            ToolStripMenuItem m1 = null;
            ToolStripMenuItem m2 = null;
            var path = Path.GetDirectoryName(s) + @"\";

            for (int j = 0; j < menu.Count; j++)
            {
                if (menu[j].Level == 1) // menu level 1 (root)
                {
                    m1 = new ToolStripMenuItem(menu[j].Caption);
                    m1.Image = Image.FromFile(path + menu[j].Picture);
                    m.Items.Add(m1);
                }
                else if (menu[j].Level == 2) // menu level 2
                {
                    m2 = new ToolStripMenuItem(menu[j].Caption);
                    m2.Image = Image.FromFile(path + menu[j].Picture);
                    m1.DropDownItems.Add(m2);
                }
                else if (m2 != null) // menu level 3
                {
                    var m3 = new ToolStripMenuItem(menu[j].Caption);
                    m2.DropDownItems.Add(m3);
                    Assembly y = Assembly.LoadFile(s);
                    m3.Tag = y.CreateInstance(menu[j].Code);
                    m3.Image = Image.FromFile(path + menu[j].Picture);
                    m3.Click += MenuItem_Click;
                }
            }
        }

        /// <summary>
        /// Click on menu
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
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