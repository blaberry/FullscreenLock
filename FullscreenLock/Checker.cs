using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;

namespace FullscreenLock
{
    class FullscreenChecker : IDisposable
    {
        public BackgroundWorker BackgroundWorker { get; set; } = new BackgroundWorker();
        public string CurrentStatus { get; set; } = "Not Started";

        private IntPtr _desktopHandle;
        private IntPtr _shellHandle;

        private RunWorkerCompletedEventHandler _completedHandler;

        // Import a bunch of win32 API calls.
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowRect(IntPtr hwnd, out Rect rc);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();

        public FullscreenChecker()
        {
            // Get the pointers for the desktop and sell
            _desktopHandle = GetDesktopWindow();
            _shellHandle = GetShellWindow();

            _completedHandler = (sender, e) => { BackgroundWorker.RunWorkerAsync(); };

            BackgroundWorker.WorkerReportsProgress = true;
            BackgroundWorker.WorkerSupportsCancellation = true;

            BackgroundWorker.DoWork += CheckFullscreenAndClipCursor;
            // Make backgroundworker restart itself after it finished executing
            BackgroundWorker.RunWorkerCompleted += _completedHandler;

            BackgroundWorker.RunWorkerAsync();
        }

        public void CheckFullscreenAndClipCursor(object sender, DoWorkEventArgs e)
        {
            CurrentStatus = "Waiting for focus";

            // Get the dimensions of the active window
            IntPtr foregroundWindow = GetForegroundWindow();
            
            if (foregroundWindow != null && !foregroundWindow.Equals(IntPtr.Zero))
            {
                // Check we haven't picked up the desktop or the shell
                if (!(foregroundWindow.Equals(_desktopHandle) || foregroundWindow.Equals(_shellHandle)))
                {
                    GetWindowRect(foregroundWindow, out Rect appBounds);
                    // Determine if window is fullscreen
                    Rectangle screenBounds = Screen.FromHandle(foregroundWindow).Bounds;
                    GetWindowThreadProcessId(foregroundWindow, out uint procid);
                    var process = Process.GetProcessById((int)procid);

                    if ((appBounds.Bottom - appBounds.Top) == screenBounds.Height && (appBounds.Right - appBounds.Left) == screenBounds.Width)
                    {
                        Cursor.Clip = screenBounds;
                        CurrentStatus = "Fullscreen app in focus";
                    }
                    else
                    {
                        Cursor.Clip = Rectangle.Empty;
                    }
                }
            }
            BackgroundWorker.ReportProgress(100, CurrentStatus);
        }

        public void Dispose()
        {
            BackgroundWorker.RunWorkerCompleted -= _completedHandler;
            BackgroundWorker.CancelAsync();
        }
    }
}

