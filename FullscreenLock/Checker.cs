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
        
        [DllImport("user32")]
        private static extern int GetWindowLongA(IntPtr hWnd, int index);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        
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

        Label l;
        public Checker( Label ll)
        {
            l = ll;
            /* Adds the event and the event handler for the method that will 
            process the timer event to the timer. */
            t.Tick += new EventHandler(CheckForFullscreenApps);

            // Sets the timer interval to 5 seconds.
            t.Interval = 100;
            t.Start();
        }
        public void toggle(Button b, Label l)
        {
            if(t.Enabled)
                {
                t.Stop();
                l.Text = "Disabled";
            }
            else
            {
                t.Start();
                l.Text = "Waiting for focus";
            }
        }
        // This is the method to run when the timer is raised.
       
        
        private  void CheckForFullscreenApps(object sender, System.EventArgs e)
        {
        
            if (IsForegroundFullScreen())
            {
                Cursor.Clip = Screen.PrimaryScreen.WorkingArea;
                l.Text = "Fullscreen app in focus";
            }
            else
            {
                l.Text = "Waiting for focus";
                Cursor.Clip = Rectangle.Empty; 
            }
        }

        public static bool IsForegroundFullScreen()
        {
            
             IntPtr desktopHandle; //Window handle for the desktop
             IntPtr shellHandle; //Window handle for the shell
                                        //Get the handles for the desktop and shell now.
            desktopHandle = GetDesktopWindow();
            shellHandle = GetShellWindow();
            //Detect if the current app is running in full screen
            RECT appBounds;
            Rectangle screenBounds;
            IntPtr hWnd;

            //get the dimensions of the active window
            hWnd = GetForegroundWindow();
            if (hWnd!=null && !hWnd.Equals(IntPtr.Zero))
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
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }   
             }
             return false;
         }
    }
}

