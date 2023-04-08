using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FullscreenLock.Settings;

namespace FullscreenLock
{ 
    static class Program
    {
        public static SettingsFile Settings_File { get; set; } = new SettingsFile();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FullscreenLockContext());
        }
    }
}
