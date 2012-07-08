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
    public static class Base
    {
        /// <summary>
        /// Load menu for RibbonControl
        /// </summary>
        /// <param name="m">RibbonControl</param>
        /// <param name="l">List App.Config file</param>
        public static void LoadMenu(this RibbonControl m, List<string> l)
        {
            foreach (var i in l) m.LoadMenu(i);
        }

        /// <summary>
        /// Load menu for RibbonControl
        /// </summary>
        /// <param name="m">RibbonControl</param>
        /// <param name="s">Path's Menu.xml</param>
        public static void LoadMenu(this RibbonControl m, string s)
        {
            var name = typeof(Menuz).Name;
            var menu = String.Format(@"{0}\{1}.xml", s, name).ToMenu(name);

            // Menu's level 1 (root)
            var m1 = new RibbonPage() { Text = menu[0].Caption, Image = Image.FromFile(s + menu[0].Picture) };
            m.Pages.Add(m1);

            // Menu's level 2, 3
            RibbonPageGroup m2 = null;
            for (int j = 1; j < menu.Count; j++)
            {
                if (menu[j].Level == 2) // Menu's level 2
                {
                    m2 = new RibbonPageGroup(menu[j].Caption);
                    //m2.Glyph = Image.FromFile(s + menu[j].Picture);
                    m1.Groups.Add(m2);
                }
                else if (m2 != null)
                {
                    var m3 = new BarButtonItem() { Caption = menu[j].Caption };
                    m2.ItemLinks.Add(m3);

                    Assembly y = null;
                    try { y = Assembly.LoadFile(s + "BXE.PRE.exe"); }
                    catch { y = Assembly.LoadFile(s + "POS.dll"); }

                    m3.Tag = y.CreateInstance(menu[j].Type);
                    m3.LargeGlyph = Image.FromFile(s + menu[j].Picture);
                    m3.ItemClick += ButtonItem_ItemClick;
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