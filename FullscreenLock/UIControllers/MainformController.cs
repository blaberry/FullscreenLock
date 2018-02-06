using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullscreenLock.UIControllers
{

    public class MainformController
    {
        private const string InfoPaused = "Paused";
        private const string InfoWaiting = "Waiting for focus";
        private const string InfoFocus = "Fullscreen app in focus";
        private const int TimerInterval = 100;
        private IMainForm MainForm;
        private System.Windows.Forms.Timer Timer;

        public MainformController(IMainForm mainForm)
        {
            MainForm = mainForm;
            Timer = new System.Windows.Forms.Timer();
            Timer.Interval = TimerInterval;

            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (IsForegroundFullScreen())
                MainForm.SetInformation(InfoFocus);
            else
                MainForm.SetInformation(InfoWaiting);
        }

        public void ToggleLock()
        {
            Timer.Enabled = !Timer.Enabled;
            if (Timer.Enabled)
            {
                MainForm.SetInformation(InfoWaiting);
            }
            else
            {
                MainForm.SetInformation(InfoPaused);
            }
        }

        public static bool IsForegroundFullScreen()
        {
            //Get the handles for the desktop and shell now.
            IntPtr desktopHandle;
            IntPtr shellHandle;
            desktopHandle = GetDesktopWindow();
            shellHandle = GetShellWindow();
            RECT appBounds;
            Rectangle screenBounds;
            IntPtr hWnd;

            //get the dimensions of the active window
            hWnd = GetForegroundWindow();
            if (hWnd != null && !hWnd.Equals(IntPtr.Zero))
            {
                //Check we haven't picked up the desktop or the shell
                if (!(hWnd.Equals(desktopHandle) || hWnd.Equals(shellHandle)))
                {
                    GetWindowRect(hWnd, out appBounds);
                    //determine if window is fullscreen
                    screenBounds = Screen.FromHandle(hWnd).Bounds;
                    uint procid = 0;
                    GetWindowThreadProcessId(hWnd, out procid);
                    var proc = Process.GetProcessById((int)procid);
                    if ((appBounds.Bottom - appBounds.Top) == screenBounds.Height && (appBounds.Right - appBounds.Left) == screenBounds.Width)
                    {
                        Cursor.Clip = screenBounds;
                        return true;
                    }
                    else
                    {
                        Cursor.Clip = Rectangle.Empty;
                        return false;
                    }
                }
            }
            return false;
        }

        #region Win32 Imports
        // Import a bunch of win32 API calls.
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowRect(IntPtr hwnd, out RECT rc);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ClipCursor(ref RECT rcClip);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();
        #endregion
    }
}
