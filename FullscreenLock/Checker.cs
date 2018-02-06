using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using System.Diagnostics;

namespace FullscreenLock
{
    class Checker
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

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

        Label l; // One day I'll figure out how to set the label without sending a pointer into the constructor.
        public Checker(Label ll)
        {
            l = ll;
            t.Tick += new EventHandler(CheckForFullscreenApps);
            t.Interval = 100;
            t.Start();
        }

        public void toggle(Button b, Label l)
        {
            if(t.Enabled)
            {
                t.Stop();
                l.Text = "Paused";
            }
            else
            {
                t.Start();
                l.Text = "Waiting for focus";
            }
        }
        
        private void CheckForFullscreenApps(object sender, System.EventArgs e)
        {
        
            if (IsForegroundFullScreen())
            {
                
                l.Text = "Fullscreen app in focus";
            }
            else
            {
                l.Text = "Waiting for focus";
                
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
             return false;
         }
    }
}

