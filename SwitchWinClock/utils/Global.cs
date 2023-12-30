using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using TruTimeZones;

namespace SwitchWinClock.utils
{
    internal class Global
    {
        public const string DefaultInstanceName = "Unknown";
        public const int MaxImAliveSeconds = 10;
        public static bool ShowedTimeZone = false;
        //custom empty, because of Color Picker, will auto select
        //Black, so if Black is selected, it thinks there is no change.
        public static Color EmptyColor { get; } = Color.FromArgb(0, 0, 1, 0);

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
        public static TruTimeZone CurrentTimeZone()
        {
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id);
            return SCConfig.GetTimeZones().First(f => f.Id == tzi.Id);
        }
        /// <summary>
        /// This presumes that weeks start with Monday.<br/>
        /// Week 1 is the 1st week of the year with a Thursday in it.<br/>
        /// <a href="https://stackoverflow.com/questions/11154673/get-the-correct-week-number-of-a-given-date"></a>
        /// </summary>
        /// <param name="dateTime">Date to count from.</param>
        /// <returns></returns>
        public static int GetIso8601WeekOfYear(DateTime dateTime)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dateTime);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                dateTime = dateTime.AddDays(3);

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
