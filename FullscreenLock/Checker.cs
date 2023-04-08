using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace FullscreenLock
{
    class Checker
    {
        readonly Timer t = new Timer();
        bool ForegroundFullscreenState = false;
        public event EventHandler<BoolEventArgs> ActiveStateChanged;
        public event EventHandler<BoolEventArgs> ForegroundFullscreenStateChanged;

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

        public Checker()
        {
            t.Tick += new EventHandler(CheckForFullscreenApps);
            t.Interval = 100;
            t.Start();
        }

        public void ActiveStateToggled(object sender, EventArgs e)
        {
            if (t.Enabled)
            {
                t.Stop();
            }
            else
            {
                t.Start();
            }

            ActiveStateChanged?.Invoke(this, new BoolEventArgs(t.Enabled));
        }

        private void CheckForFullscreenApps(object sender, EventArgs e)
        {
            bool NewFullscreenState = IsForegroundFullScreen();

            //If the fullscreen state changed, set the new state and emit the change event
            if (ForegroundFullscreenState != NewFullscreenState)
            {
                ForegroundFullscreenState = NewFullscreenState;
                ForegroundFullscreenStateChanged?.Invoke(this, new BoolEventArgs(NewFullscreenState));
            }
        }

        public static bool IsForegroundFullScreen()
        {
            //Get the handles for the desktop and shell now.
            IntPtr desktopHandle = GetDesktopWindow();
            IntPtr shellHandle = GetShellWindow();
            Rectangle screenBounds;
            IntPtr hWnd;

            hWnd = GetForegroundWindow();
            if (hWnd != null && !hWnd.Equals(IntPtr.Zero))
            {
                //Check we haven't picked up the desktop or the shell
                if (!(hWnd.Equals(desktopHandle) || hWnd.Equals(shellHandle)))
                {
                    GetWindowRect(hWnd, out RECT appBounds);
                    //determine if window is fullscreen
                    screenBounds = Screen.FromHandle(hWnd).Bounds;

                    //determine process, to check the whitelist
                    Process proc = null;
                    try
                    {
                        GetWindowThreadProcessId(hWnd, out uint procid);
                        proc = Process.GetProcessById((int)procid);
                    }
                    catch (Exception) { }

                    if (proc != null)
                    {
                        if ((appBounds.Bottom - appBounds.Top) == screenBounds.Height && (appBounds.Right - appBounds.Left) == screenBounds.Width
                            && !IsWhitelisted(proc.MainModule.FileName))
                        {
                            Console.WriteLine(proc.ProcessName);
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
            }
            return false;
        }

        public static bool IsWhitelisted(string sFullPathToProgram)
        {
            return Program.Settings_File.Instance.asWhitelist.ConvertAll(s => s.ToLower()).Contains(sFullPathToProgram.ToLower());
        }
    }

    public class BoolEventArgs : EventArgs
    {
        public bool Bool { get; set; }

        public BoolEventArgs(bool b)
        {
            Bool = b;
        }
    }
}
