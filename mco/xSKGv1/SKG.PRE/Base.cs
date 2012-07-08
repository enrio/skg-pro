﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SKG.PRE
{
    using UTL.Extension;
    using UTL.Plugin;
    using System.Reflection;

    /// <summary>
    /// Extension Methods
    /// </summary>
    public static class Base
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
                var a = i.ToMenu(typeof(Plugin).Name);
                if (a == null || a.Count < 1) continue;

                // Menu's level 1 (root)
                var m1 = new ToolStripMenuItem() { Text = a[0].Caption, Image = Image.FromFile(String.Format(@"{0}\Plugins\{1}", Application.StartupPath, a[0].Picture)) };
                m.Items.Add(m1);

                // Menu's level 2, 3
                ToolStripMenuItem m2 = null;
                for (int j = 1; j < a.Count; j++)
                {
                    if (a[j].Level == 2) // Menu's level 2
                    {
                        m2 = new ToolStripMenuItem(a[j].Caption);
                        m2.Image = Image.FromFile(String.Format(@"{0}\Plugins\{1}", Application.StartupPath, a[j].Picture));
                        m1.DropDownItems.Add(m2);
                    }
                    else if (m2 != null)
                    {
                        var m3 = new ToolStripMenuItem(a[j].Caption);
                        m2.DropDownItems.Add(m3);

                        var x = i.Substring(0, i.Length - ".exe.config".Length) + ".exe";
                        var y = Assembly.LoadFile(x);
                        m3.Tag = y.CreateInstance(a[j].Type);
                        m3.Image = Image.FromFile(String.Format(@"{0}\Plugins\{1}", Application.StartupPath, a[j].Picture));
                        m3.Click += MenuItem_Click;
                    }
                }
            }
        }

        /// <summary>
        /// Load menu for MenuStrip
        /// </summary>
        /// <param name="m">MenuStrip</param>
        /// <param name="s">Path's Menu.xml</param>
        public static void LoadMenu(this MenuStrip m, string s)
        {
            var name = typeof(Menuz).Name;
            var menu = String.Format(@"{0}\{1}.xml", s, name).ToMenu(name);

            // Menu's level 1 (root)
            var m1 = new ToolStripMenuItem() { Text = menu[0].Caption, Image = Image.FromFile(s + menu[0].Picture) };
            m.Items.Add(m1);

            // Menu's level 2, 3
            ToolStripMenuItem m2 = null;
            for (int j = 1; j < menu.Count; j++)
            {
                if (menu[j].Level == 2) // Menu's level 2
                {
                    m2 = new ToolStripMenuItem(menu[j].Caption);
                    m2.Image = Image.FromFile(s + menu[j].Picture);
                    m1.DropDownItems.Add(m2);
                }
                else if (m2 != null)
                {
                    var m3 = new ToolStripMenuItem(menu[j].Caption);
                    m2.DropDownItems.Add(m3);

                    Assembly y = null;
                    try { y = Assembly.LoadFile(s + "BXE.PRE.exe"); }
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
                f.ShowDialog();
            }
            catch { return; }
        }
    }
}