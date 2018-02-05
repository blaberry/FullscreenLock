using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace FullscreenLock
{
    public partial class FullscreenLock : Form
    {
        private FullscreenChecker _fullscreenChecker = null;

        public FullscreenLock()
        {
            InitializeComponent();
        }

        private void ToggleButtonClicked(object sender, EventArgs e)
        {
            if (_fullscreenChecker == null)
            {
                _fullscreenChecker = new FullscreenChecker();
                _fullscreenChecker.BackgroundWorker.ProgressChanged += FullscreenCheckerProgressChanged;
            }
            else
            {
                _fullscreenChecker = null;
                lblStatus.Text = "Paused";
            }
        }

        private void FullscreenCheckerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = e.UserState as string;
        }
    }
}
