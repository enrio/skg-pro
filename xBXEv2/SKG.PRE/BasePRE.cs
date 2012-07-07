using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SKG.PRE
{
    using UTL.Extension;
    using UTL.Plugin;
    using System.Reflection;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Ribbon;

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
                var a = i.ToMenu(typeof(AvailablePlugin).Name);
                if (a == null || a.Count < 1) continue;

                // Menu's level 1 (root)
                var m1 = new ToolStripMenuItem() { Text = a[0].Text1, Image = Image.FromFile(String.Format(@"{0}\Plugins\{1}", App.StartupPath, a[0].Icon)) };
                m.Items.Add(m1);

                // Menu's level 2, 3
                ToolStripMenuItem m2 = null;
                for (int j = 1; j < a.Count; j++)
                {
                    if (a[j].Level == 2) // Menu's level 2
                    {
                        m2 = new ToolStripMenuItem(a[j].Text1);
                        m2.Image = Image.FromFile(String.Format(@"{0}\Plugins\{1}", App.StartupPath, a[j].Icon));
                        m1.DropDownItems.Add(m2);
                    }
                    else if (m2 != null)
                    {
                        var m3 = new ToolStripMenuItem(a[j].Text1);
                        m2.DropDownItems.Add(m3);

                        var x = i.Substring(0, i.Length - ".exe.config".Length) + ".exe";
                        var y = Assembly.LoadFile(x);
                        m3.Tag = y.CreateInstance(a[j].Type);
                        m3.Image = Image.FromFile(String.Format(@"{0}\Plugins\{1}", App.StartupPath, a[j].Icon));
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
            var a = (s + "Menu.xml").ToMenu(typeof(AvailablePlugin).Name);

            // Menu's level 1 (root)
            var m1 = new ToolStripMenuItem() { Text = a[0].Text1, Image = Image.FromFile(s + a[0].Icon) };
            m.Items.Add(m1);

            // Menu's level 2, 3
            ToolStripMenuItem m2 = null;
            for (int j = 1; j < a.Count; j++)
            {
                if (a[j].Level == 2) // Menu's level 2
                {
                    m2 = new ToolStripMenuItem(a[j].Text1);
                    m2.Image = Image.FromFile(s + a[j].Icon);
                    m1.DropDownItems.Add(m2);
                }
                else if (m2 != null)
                {
                    var m3 = new ToolStripMenuItem(a[j].Text1);
                    m2.DropDownItems.Add(m3);

                    Assembly y = null;
                    try { y = Assembly.LoadFile(s + "BXE.PRE.exe"); }
                    catch { y = Assembly.LoadFile(s + "POS.dll"); }

                    m3.Tag = y.CreateInstance(a[j].Type);
                    m3.Image = m2.Image = Image.FromFile(s + a[j].Icon);
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

        public static void LoadMenu(this RibbonControl m, List<string> l)
        {
            foreach (var i in l)
            {
                var a = i.ToMenu(typeof(AvailablePlugin).Name);
                if (a == null || a.Count < 1) continue;

                // Menu's level 1 (root)
                var m1 = new RibbonPage(a[0].Text1);
                m.Pages.Add(m1);

                // Menu's level 2, 3
                RibbonPageGroup m2 = null;
                for (int j = 1; j < a.Count; j++)
                {
                    if (a[j].Level == 2) // Menu's level 2
                    {
                        m2 = new RibbonPageGroup(a[j].Text1);
                        m1.Groups.Add(m2);
                    }
                    else if (m2 != null)
                    {
                        var m3 = new BarButtonItem() { Caption = a[j].Text1 };
                        m2.ItemLinks.Add(m3);

                        var x = i.Substring(0, i.Length - ".exe.config".Length) + ".exe";
                        var y = Assembly.LoadFile(x);
                        m3.Tag = y.CreateInstance(a[j].Type);
                        m3.LargeGlyph = Image.FromFile(String.Format(@"{0}\Plugins\{1}", App.StartupPath, a[j].Icon));
                        m3.ItemClick += ButtonItem_ItemClick;
                    }
                }
            }
        }

        private static void ButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var f = (Form)e.Item.Tag;
                f.ShowDialog();
            }
            catch { return; }
        }
    }
}