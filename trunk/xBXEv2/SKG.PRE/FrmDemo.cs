using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SKG.PRE
{
    public partial class FrmDemo : Form
    {
        public FrmDemo()
        {
            InitializeComponent();
        }

        private void FrmDemo_Load(object sender, EventArgs e)
        {
            var a = AppDomain.CurrentDomain.BaseDirectory + @"\Plugins";
            var b = Global.Plugins.FindConfigs(a);
            menuStrip1.LoadMenu(b);
        }
        /*
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Get all root menu items
            var queryResult = (from RootItems in CTX.MenuTables
                               where RootItems.ParentID == null // if there are no children its a root item
                               select RootItems.Item);

            foreach (var item in queryResult)
            {
                // add the root item and check if it has any children
                AddChildMenuItems(menuStrip.Items.Add(item, null, new EventHandler(MenuItemClicked)));
            }
        }

        private void AddChildMenuItems(ToolStripItem parent)
        {
            // Cast the Parent to a ToolStripMenuItem
            ToolStripMenuItem ParentItem = (ToolStripMenuItem)parent;

            // Get the parents ID
            int ID = (from menuItem in CTX.MenuTables
                      where menuItem.Item == ParentItem.Text
                      select menuItem.ID).First();


            // Get a list of the parents children
            var queryResult = (from menuItem in CTX.MenuTables
                               where menuItem.ParentID == ID
                               select menuItem.Item);

            //if there are any children
            if (queryResult.Count() > 0)
            {
                foreach (var item in queryResult)
                {
                    if (item == "-")
                    {
                        // add a seperator
                        ParentItem.DropDownItems.Add(item);
                    }
                    else
                    {
                        // add child and check if it has any children
                        AddChildMenuItems(ParentItem.DropDownItems.Add(item, null, new EventHandler(MenuItemClicked)));
                    }
                }
            }
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            // if the sender is a ToolStripMenuItem
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                string ClickedItemText = ((ToolStripItem)sender).Text;

                //listBox1.Items.Add(ClickedItemText);

                switch (ClickedItemText)
                {
                    case "Exit":
                        Application.Exit();
                        break;
                }
            }
        }*/
    }
}