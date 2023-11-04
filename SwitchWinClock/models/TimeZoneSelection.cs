using System;
using System.ComponentModel;
using SwitchWinClock.utils;

namespace SwitchWinClock
{
    [DefaultProperty("Id")]
    internal class TimeZoneSelection
    {
        public TimeZoneSelection(string timezoneId)
        {
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
            Id = timezoneId;

            UTCDiff = tzi.BaseUtcOffset;
            DisplayName = tzi.DisplayName;
            LocalName = $"{UTCDiff} | {timezoneId}";
        }

        /// <summary>
        /// Full Name only, no time diff displayed.
        /// </summary>
        internal string Id { get; }
        /// <summary>
        /// Time Difference from UTC
        /// </summary>
        internal TimeSpan UTCDiff { get; }
        /// <summary>
        /// Full name with Time Different 
        /// </summary>
        internal string DisplayName { get; }
        /// <summary>
        /// Internal name used after removal of (UTC) in front of the time name.
        /// </summary>
        internal string LocalName { get; }
    }
}
