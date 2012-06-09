using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents;

namespace Yahoo
{
    public delegate void Mess(string Mess, String ten);
    public partial class frmChat:Form
    {
        
        public frmChat()
        {
            InitializeComponent();
           
            
        }
        public Mess thu;        
        private void btGui_Click(object sender, EventArgs e)
        {
            //String chat = textBox1.Text;
           //listBox1.Items.Add(chat);
            
            if (thu != null)
            {
                thu(textBox1.Text,this.Text);
            }
            textBox1.Text = "";
        }

        private void frmChat_Load(object sender, EventArgs e)
        {

        }
        
    }
}
