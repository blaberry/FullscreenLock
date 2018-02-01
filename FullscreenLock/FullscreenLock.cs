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
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "https://steamcommunity.com/tradeoffer/new/?partner=40730537&token=Y207zFvl";

            LinkLabel.Link link2 = new LinkLabel.Link();
            link2.LinkData = "https://steamcommunity.com/id/Rostok";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           c.toggle(this.button1,this.label1);
        }
        public void labelset(string s)
        {
            this.label1.Text = s;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Send the URL to the operating system.
            Process.Start(e.Link.LinkData as string);
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Process.Start(e.Link.LinkData as string);
        }
    }
}
