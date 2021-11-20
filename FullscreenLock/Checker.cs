using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FullscreenLock {

    public class BoolEventArgs : EventArgs {

        public BoolEventArgs(bool b) {
            Bool = b;
        }

        public bool Bool { get; set; }
    }

    internal class Checker {
        private readonly Timer t = new Timer();
        private bool ForegroundFullscreenState = false;

        public Checker() {
            t.Tick += new EventHandler(CheckForFullscreenApps);
            t.Interval = 100;
            t.Start();
        }

        public event EventHandler<BoolEventArgs> ActiveStateChanged;

        public event EventHandler<BoolEventArgs> ForegroundFullscreenStateChanged;

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ClipCursor(ref RECT rcClip);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static bool IsForegroundFullScreen() {
            //Get the handles for the desktop and shell now.
            IntPtr desktopHandle = GetDesktopWindow();
            IntPtr shellHandle = GetShellWindow();
            Rectangle screenBounds;
            IntPtr hWnd;

            hWnd = GetForegroundWindow();
            if (hWnd != null && !hWnd.Equals(IntPtr.Zero)) {
                //Check we haven't picked up the desktop or the shell
                if (!(hWnd.Equals(desktopHandle) || hWnd.Equals(shellHandle))) {
                    GetWindowRect(hWnd, out RECT appBounds);
                    //determine if window is fullscreen
                    screenBounds = Screen.FromHandle(hWnd).Bounds;
                    GetWindowThreadProcessId(hWnd, out uint procid);
                    var proc = Process.GetProcessById((int)procid);
                    var screenHeight = (appBounds.Bottom - appBounds.Top);
                    var screenWidth = (appBounds.Right - appBounds.Left);
                    if (screenHeight >= screenBounds.Height && screenWidth >= screenBounds.Width) {
                        Console.WriteLine(proc.ProcessName);
                        Cursor.Clip = screenBounds;
                        return true;
                    } else {
                        Cursor.Clip = Rectangle.Empty;
                        return false;
                    }
                }
            }
            return false;
        }

        public void ActiveStateToggled(object sender, EventArgs e) {
            if (t.Enabled) {
                t.Stop();
            } else {
                t.Start();
            }

            ActiveStateChanged?.Invoke(this, new BoolEventArgs(t.Enabled));
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

        // Import a bunch of win32 API calls.
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowRect(IntPtr hwnd, out RECT rc);

        private void CheckForFullscreenApps(object sender, EventArgs e) {
            bool NewFullscreenState = IsForegroundFullScreen();

            //If the fullscreen state changed, set the new state and emit the change event
            if (ForegroundFullscreenState != NewFullscreenState) {
                ForegroundFullscreenState = NewFullscreenState;
                ForegroundFullscreenStateChanged?.Invoke(this, new BoolEventArgs(NewFullscreenState));
            }
        }
    }
}