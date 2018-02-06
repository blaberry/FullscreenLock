using FullscreenLock.UIControllers;
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
    public partial class FullscreenLock : Form, UIControllers.IMainForm
    {
        private MainformController Controller;

        public FullscreenLock()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Controller = new MainformController(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller.ToggleLock();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {


        }

        public void SetInformation(string info)
        {
            label1.Text = info;
        }
    }
}
