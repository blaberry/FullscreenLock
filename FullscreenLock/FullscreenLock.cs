using System;
using System.Windows.Forms;

namespace FullscreenLock
{
    public partial class FullscreenLock : Form
    {
        public event EventHandler ActiveStateToggled;

        public FullscreenLock()
        {
            InitializeComponent();
        }

        private void FullscreenLock_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FullscreenLock_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                SetVisibility(false);
        }

        private void ToggleButton_Click(object sender, EventArgs e)
        {
            ActiveStateToggled?.Invoke(this, e);
        }

        public void SetVisibility(bool state)
        {
            // Always setting to minimized ensures that the window gets focus when visibility is set to true
            WindowState = FormWindowState.Minimized;

            Visible = state;

            if (state)
                WindowState = FormWindowState.Normal;
        }

        public void ActiveStateChanged(object sender, BoolEventArgs e)
        {
            StatusLabel.Text = e.Bool ? "Waiting for focus" : "Paused";
        }

        public void ForegroundFullscreenStateChanged(object sender, BoolEventArgs e)
        {
            StatusLabel.Text = e.Bool ? "Fullscreen app in focus" : "Waiting for focus";
        }
    }
}
