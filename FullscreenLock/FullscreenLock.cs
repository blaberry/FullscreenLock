using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullscreenLock
{
    public partial class FullscreenLock : Form
    {
        public FullscreenLock()
        {
            InitializeComponent();
        }
        private Checker c;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.c = new Checker(label1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           c.toggle(this.button1,this.label1);
        }
        public void labelset(string s)
        {
            this.label1.Text = s;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {


        }
    }
}
