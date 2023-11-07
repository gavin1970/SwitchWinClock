using System;

namespace SwitchTimeZones
{
    public class TimeZoneSearch
    {
        /// <summary>
        /// Will search all timezone as Exact or Contains.<br/>
        /// Search is NOT CASE sensitive.
        /// </summary>
        /// <param name="timeZoneId">Timezone Id to search for.</param>
        /// <param name="contains">
        /// <code>
        /// Search within the Id.<br/>
        ///     Default: false
        /// </code>
        /// </param>
        /// <returns>
        /// <code>
        /// TrueTimeZone:<br/>
        ///     TimeSpan BaseUtcOffset<br/>
        ///     TimeSpan DSTUtcOffset<br/>
        ///     string DisplayName<br/>
        ///     string DaylightName<br/>
        ///     string Id<br/>
        ///     string StandardName<br/>
        ///     bool SupportsDaylightSavingTime
        /// </code>
        /// </returns>
        public static TrueTimeZone SearchById(string timeZoneId, bool contains = false)
        {
            //Contains does have StringComparison properties, so it has to be lower cased.
            if (contains)
                return WorldTimeZones.TimeZones.Find(f => f.Id.ToLower().Contains(timeZoneId.ToLower()));
            else
                return WorldTimeZones.TimeZones.Find(f => f.Id.Equals(timeZoneId, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Will search all timezone as Exact or Contains.<br/>
        /// Search is NOT CASE sensitive.
        /// </summary>
        /// <param name="timeZoneId">Timezone Id to search for.</param>
        /// <param name="contains">
        /// <code>
        /// Search within the Id.<br/>
        ///     Default: false
        /// </code>
        /// </param>
        /// <returns>
        /// <code>
        /// TrueTimeZone:<br/>
        ///     TimeSpan BaseUtcOffset<br/>
        ///     TimeSpan DSTUtcOffset<br/>
        ///     string DisplayName<br/>
        ///     string DaylightName<br/>
        ///     string Id<br/>
        ///     string StandardName<br/>
        ///     bool SupportsDaylightSavingTime
        /// </code>
        /// </returns>
        public static TrueTimeZone SearchByName(string displayName, bool contains = false)
        {
            //Contains does have StringComparison properties, so it has to be lower cased.
            if (contains)
                return WorldTimeZones.TimeZones.Find(f => f.DisplayName.ToLower().Contains(displayName.ToLower()));
            else
                return WorldTimeZones.TimeZones.Find(f => f.DisplayName.Equals(displayName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
