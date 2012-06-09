using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Server:Form
    {
        public Server()
        {
            InitializeComponent();
        }
        BindingSource bs = new BindingSource();
        DataLayer.UserDataLayer UserData = new DataLayer.UserDataLayer();
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 thu = new Form1();
            thu.MdiParent = this;
            thu.WindowState = FormWindowState.Maximized;
            thu.Show();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'chatDataSet.NguoiDung' table. You can move, or remove it, as needed.

            listBoxControl1.DataSource = UserData.LayToanBoUSer();
            listBoxControl1.ValueMember = "UID";
            listBoxControl1.DisplayMember = "TenThat";
            //treeList1.DataMember = "TenThat";

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void sdsfToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Form1 g = new Form1();
            //g.Text = listBox1.
            g.Show();
            g.MdiParent = this;
            g.WindowState = FormWindowState.Maximized;
        }

        

      
        
    }
}
