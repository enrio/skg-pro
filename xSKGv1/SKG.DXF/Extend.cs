using System;
using System.Collections.Generic;
using System.Linq;

namespace SKG.DXF
{
    using Plugin;
    using System.IO;
    using System.Drawing;
    using System.Reflection;
    using DevExpress.XtraBars;
    using System.Windows.Forms;
    using DevExpress.XtraBars.Ribbon;

    public static class Extend
    {
        #region Extension for for load menu
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
            if (menu == null) return;
            var path = Path.GetDirectoryName(s) + @"\";

            RibbonPage m1 = null;
            RibbonPageGroup m2 = null;

            for (int j = 0; j < menu.Count; j++)
            {
                if (menu[j].Level == 1) // menu level 1 (root)
                {
                    m1 = new RibbonPage(menu[j].Caption);
                    m1.Image = Image.FromFile(path + menu[j].Picture);
                    m.Pages.Add(m1);
                }
                else if (menu[j].Level == 2) // menu level 2
                {
                    m2 = new RibbonPageGroup(menu[j].Caption);
                    m2.Glyph = Image.FromFile(path + menu[j].Picture);
                    m1.Groups.Add(m2);
                }
                else if (m2 != null) // menu level 3
                {
                    var m3 = new BarButtonItem() { Caption = menu[j].Caption };
                    m2.ItemLinks.Add(m3);
                    Assembly y = Assembly.LoadFile(s);
                    m3.Tag = y.CreateInstance(menu[j].Type);
                    m3.LargeGlyph = Image.FromFile(path + menu[j].Picture);
                    m3.ItemClick += ButtonItem_ItemClick;
                }
            }
        }

        /// <summary>
        /// Click on menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ButtonItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var f = (FrmInRight)e.Item.Tag;
                if (f == null || f.IsDisposed)
                    f = Activator.CreateInstance(f.GetType()) as FrmInRight;
                f.ShowRight(Parent);
            }
            catch { return; }
        }
        #endregion
    }
}