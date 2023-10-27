using System.Diagnostics;

namespace SwitchWinClock.utils
{
    internal class Global
    {
        public const string DefaultInstanceName = "Unknown";
        public const int MaxImAliveSeconds = 5;
        public static string ConfigFileName { get { return $"SWClock{AppID:00}.config"; } }
        public static int AppID { get; set; }
        public static void RunApp(string file, string args = null, bool waitForExit = false)
        {
            Process process = new Process();
            process.StartInfo.FileName = file;

            if(!string.IsNullOrWhiteSpace(args))
                process.StartInfo.Arguments = args;

            process.Start();

            if (waitForExit)
                process.WaitForExit();// Waits here for the process to exit.        }
        }
    }
}
