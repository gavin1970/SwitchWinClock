using System;
using System.Diagnostics;

namespace SwitchWinClock.utils
{
    internal class Global
    {
        public const string DefaultInstanceName = "Unknown";
        public const int MaxImAliveSeconds = 5;
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
        public static TimeZoneSelection CurrentTimeZone()
        {
            DateTimeOffset locDiff = DateTimeOffset.Now;
            DateTime utcD = DateTime.UtcNow;
            DateTime locD = DateTime.Now;

            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id);
            TimeZoneInfo tzi2 = TimeZoneInfo.FindSystemTimeZoneById("Azores Standard Time");
            
            //this whole if statement is attempting to find a work around for TimeZoneInfo not
            //returning the write timezone.  Current I'm -4 CST, but for some reason
            //it's returning -5 CST.  After some research, this is a know issue for some time.
            if (!ShowedTimeZone)
            {
                string tmp = DateTime.Now.ToString("zzz");
                DateTime newDt = DateTime.UtcNow.Add(tzi2.BaseUtcOffset);
                
                ShowedTimeZone = true;

                bool isDST = TimeZoneInfo.Local.BaseUtcOffset != locDiff.Offset;    //true
                bool isDST1 = TimeZoneInfo.Local.IsDaylightSavingTime(locD);        //true
                bool isDST2 = TimeZoneInfo.Local.IsDaylightSavingTime(utcD);        //true
                bool isDST3 = TimeZoneInfo.Utc.IsDaylightSavingTime(utcD);          //false
                bool isDST4 = TimeZoneInfo.Utc.IsDaylightSavingTime(locD);          //false

                if(!tmp.Equals("-04:00"))
                    Console.WriteLine($"11/4 Now = Was: -04:00,  Now: {tmp}");
                if (!isDST)
                    Console.WriteLine($"11/4 isDST = Was: true,  Now: {isDST}");
                if (!isDST1)
                    Console.WriteLine($"11/4 isDST1 = Was: true,  Now: {isDST1}");
                if (!isDST2)
                    Console.WriteLine($"11/4 isDST2 = Was: true,  Now: {isDST2}");
                if (isDST3)
                    Console.WriteLine($"11/4 isDST3 = Was: false,  Now: {isDST3}");
                if (isDST4)
                    Console.WriteLine($"11/4 isDST4 = Was: false,  Now: {isDST4}");
            }

            return SCConfig.GetTimeZones().Find(f => f.DisplayName == tzi.DisplayName);
        }
    }
}
