using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.PRE
{
    using Plugin;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Ribbon;

    /// <summary>
    /// Extension methods for load menu
    /// </summary>
    public static class Extend
    {
        /// <summary>
        /// Form MDI parent
        /// </summary>
        public static Form Parent { get; set; }

        /// <summary>
        /// Load menu for RibbonControl
        /// </summary>
        /// <param name="m">RibbonControl</param>
        /// <param name="s">Path's Menu.xml</param>
        public static void LoadMenu(this RibbonControl m, List<string> l, Form f = null)
        {
            Parent = f;
            foreach (var i in l) m.LoadMenu(i);
        }

        /// <summary>
        /// Load menu for RibbonControl
        /// </summary>
        /// <param name="m">RibbonControl</param>
        /// <param name="s">Path's Menu.xml</param>
        public static void LoadMenu(this RibbonControl m, string s)
        {
            var menu = Services.GetMenu(s);
            RibbonPage m1 = null;
            RibbonPageGroup m2 = null;

            for (int j = 0; j < menu.Count; j++)
            {
                if (menu[j].Level == 1) // menu level 1 (root)
                {
                    m1 = new RibbonPage(menu[j].Caption);
                    m1.Image = Image.FromFile(s + menu[j].Picture);
                    m.Pages.Add(m1);
                }
                else if (menu[j].Level == 2) // menu level 2
                {
                    m2 = new RibbonPageGroup(menu[j].Caption);
                    m2.Glyph = Image.FromFile(s + menu[j].Picture);
                    m1.Groups.Add(m2);
                }
                else if (m2 != null) // menu level 3
                {
                    var m3 = new BarButtonItem() { Caption = menu[j].Caption };
                    m2.ItemLinks.Add(m3);

                    Assembly y = null;
                    try { y = Assembly.LoadFile(s + "BXE.PRE.dll"); }
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

                if (f == null || f.IsDisposed)
                    f = Activator.CreateInstance(f.GetType()) as Catalog.FrmBase;

                if (Parent != null) f.MdiParent = Parent;
                f.ShowRight();
            }
            catch { return; }
        }
    }
}