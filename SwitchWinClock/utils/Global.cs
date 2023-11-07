using SwitchTimeZones;
using System;
using System.Diagnostics;

namespace SwitchWinClock.utils
{
    internal class Global
    {
        public const string DefaultInstanceName = "Unknown";
        public const int MaxImAliveSeconds = 10;
        public static bool ShowedTimeZone = false;

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
        public static string StripUTC(string utcName)
        {
            if (utcName.IndexOf("(UTC)") == -1)
                utcName = utcName.Replace("(UTC", "(");

            return utcName.Trim();
        }
        public static TrueTimeZone CurrentTimeZone()
        {
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id);
            return SCConfig.GetTimeZones().Find(f => f.Id == tzi.Id);
        }
    }
}
