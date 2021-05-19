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
        private Checker c;

        public FullscreenLock()
        {
            InitializeComponent();
        }

        private void FullscreenLock_Load(object sender, EventArgs e)
        {
            c = new Checker(label1);
        }

        private void FullscreenLock_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                setVisibility(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.toggle(button1, label1);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setVisibility(true);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            setVisibility(true);
        }

        private void setVisibility(bool state)
        {
            Visible = state;

            if (state) WindowState = FormWindowState.Normal;

            notifyIcon1.Visible = !state;
        }
    }
}
