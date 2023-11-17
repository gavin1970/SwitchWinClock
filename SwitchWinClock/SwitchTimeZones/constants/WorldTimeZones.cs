//using System;
//using System.Collections.Generic;

//namespace SwitchTimeZones2
//{
//    //WorldTimeZones.CreateWorldTimeZones(".\\world_timezones.csv");
//    [Serializable]
//    internal static class WorldTimeZones
//    {
//        /// <summary>
//        /// Internal Class creation only.
//        /// </summary>
//        /// <param name="filePath"></param>
//        //internal static void CreateWorldTimeZones(string filePath)
//        //{
//        //    if (File.Exists(filePath))
//        //        File.Delete(filePath);
//        //    if (File.Exists($"{filePath}.json"))
//        //        File.Delete($"{filePath}.json");

//        //    using (StreamWriter writer = new StreamWriter(filePath))
//        //    {
//        //        foreach (TimeZoneInfo tzi in TimeZoneInfo.GetSystemTimeZones())
//        //        {
//        //            int start = tzi.DisplayName.IndexOf("(");
//        //            int end = tzi.DisplayName.IndexOf(")");
//        //            end = end > -1 ? end + 1 : end;
//        //            string displayName = start > -1 && end > -1 ? tzi.DisplayName.Substring(end, tzi.DisplayName.Length - end).Trim() : tzi.DisplayName;
//        //            TimeSpan baseUtcDST = tzi.SupportsDaylightSavingTime ? tzi.BaseUtcOffset.Add(TimeSpan.FromHours(1)) : tzi.BaseUtcOffset;

//        //            string curTz = IsDST ? baseUtcDST.ToString() : tzi.BaseUtcOffset.ToString();
//        //            displayName = $"({curTz}) {displayName}";

//        //            writer.WriteLine($"new TrueTimeZone(new TimeSpan({tzi.BaseUtcOffset.Hours}, {tzi.BaseUtcOffset.Minutes}, {tzi.BaseUtcOffset.Seconds}), " +
//        //                $"new TimeSpan({baseUtcDST.Hours}, {baseUtcDST.Minutes}, {baseUtcDST.Seconds}), " +
//        //                $"\"{displayName.Trim()}\", " +
//        //                $"\"{tzi.DaylightName}\", " +
//        //                $"\"{tzi.Id}\", " +
//        //                $"\"{tzi.StandardName}\", " +
//        //                $"{tzi.SupportsDaylightSavingTime.ToString().ToLower()}, IsDST),");
//        //        }
//        //    }
//        //}
//        /// <summary>
//        /// DST changes for all zones at the same time as long as they 
//        /// support DST, so pulling DST from local will be the same for all TimeZones.
//        /// </summary>
//        private static bool IsDST
//        {
//            get
//            {
//                return TimeZoneInfo.Local.BaseUtcOffset != DateTimeOffset.Now.Offset;
//            }
//        }
//        internal static List<TrueTimeZone> TimeZones { get; } = new List<TrueTimeZone>()
//        {
//            new TrueTimeZone(new TimeSpan(-12,00,00), new TimeSpan(-12,00,00), "International Date Line West", "Dateline Daylight Time", "Dateline Standard Time", "Dateline Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-11, 0, 0), new TimeSpan(-11, 0, 0), "Coordinated Universal Time-11", "UTC-11", "UTC-11", "UTC-11", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-10, 0, 0), new TimeSpan(-9, 0, 0), "Aleutian Islands", "Aleutian Daylight Time", "Aleutian Standard Time", "Aleutian Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-10, 0, 0), new TimeSpan(-10, 0, 0), "Hawaii", "Hawaiian Daylight Time", "Hawaiian Standard Time", "Hawaiian Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-9, -30, 0), new TimeSpan(-9, -30, 0), "Marquesas Islands", "Marquesas Daylight Time", "Marquesas Standard Time", "Marquesas Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-9, 0, 0), new TimeSpan(-8, 0, 0), "Alaska", "Alaskan Daylight Time", "Alaskan Standard Time", "Alaskan Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-9, 0, 0), new TimeSpan(-9, 0, 0), "Coordinated Universal Time-09", "UTC-09", "UTC-09", "UTC-09", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-8, 0, 0), new TimeSpan(-7, 0, 0), "Baja California", "Pacific Daylight Time (Mexico)", "Pacific Standard Time (Mexico)", "Pacific Standard Time (Mexico)", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-8, 0, 0), new TimeSpan(-8, 0, 0), "Coordinated Universal Time-08", "UTC-08", "UTC-08", "UTC-08", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-8, 0, 0), new TimeSpan(-7, 0, 0), "Pacific Time (US & Canada)", "Pacific Daylight Time", "Pacific Standard Time", "Pacific Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-7, 0, 0), new TimeSpan(-7, 0, 0), "Arizona", "US Mountain Daylight Time", "US Mountain Standard Time", "US Mountain Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-7, 0, 0), new TimeSpan(-6, 0, 0), "La Paz, Mazatlan", "Mountain Daylight Time (Mexico)", "Mountain Standard Time (Mexico)", "Mountain Standard Time (Mexico)", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-7, 0, 0), new TimeSpan(-6, 0, 0), "Mountain Time (US & Canada)", "Mountain Daylight Time", "Mountain Standard Time", "Mountain Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-7, 0, 0), new TimeSpan(-6, 0, 0), "Yukon", "Yukon Daylight Time", "Yukon Standard Time", "Yukon Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-6, 0, 0), new TimeSpan(-6, 0, 0), "Central America", "Central America Daylight Time", "Central America Standard Time", "Central America Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-6, 0, 0), new TimeSpan(-5, 0, 0), "Central Time (US & Canada)", "Central Daylight Time", "Central Standard Time", "Central Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-6, 0, 0), new TimeSpan(-5, 0, 0), "Easter Island", "Easter Island Daylight Time", "Easter Island Standard Time", "Easter Island Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-6, 0, 0), new TimeSpan(-5, 0, 0), "Guadalajara, Mexico City, Monterrey", "Central Daylight Time (Mexico)", "Central Standard Time (Mexico)", "Central Standard Time (Mexico)", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-6, 0, 0), new TimeSpan(-6, 0, 0), "Saskatchewan", "Canada Central Daylight Time", "Canada Central Standard Time", "Canada Central Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-5, 0, 0), new TimeSpan(-5, 0, 0), "Bogota, Lima, Quito, Rio Branco", "SA Pacific Daylight Time", "SA Pacific Standard Time", "SA Pacific Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-5, 0, 0), new TimeSpan(-4, 0, 0), "Chetumal", "Eastern Daylight Time (Mexico)", "Eastern Standard Time (Mexico)", "Eastern Standard Time (Mexico)", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-5, 0, 0), new TimeSpan(-4, 0, 0), "Eastern Time (US & Canada)", "Eastern Daylight Time", "Eastern Standard Time", "Eastern Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-5, 0, 0), new TimeSpan(-4, 0, 0), "Haiti", "Haiti Daylight Time", "Haiti Standard Time", "Haiti Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-5, 0, 0), new TimeSpan(-4, 0, 0), "Havana", "Cuba Daylight Time", "Cuba Standard Time", "Cuba Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-5, 0, 0), new TimeSpan(-4, 0, 0), "Indiana (East)", "US Eastern Daylight Time", "US Eastern Standard Time", "US Eastern Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-5, 0, 0), new TimeSpan(-4, 0, 0), "Turks and Caicos", "Turks and Caicos Daylight Time", "Turks And Caicos Standard Time", "Turks and Caicos Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-4, 0, 0), new TimeSpan(-3, 0, 0), "Asuncion", "Paraguay Daylight Time", "Paraguay Standard Time", "Paraguay Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-4, 0, 0), new TimeSpan(-3, 0, 0), "Atlantic Time (Canada)", "Atlantic Daylight Time", "Atlantic Standard Time", "Atlantic Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-4, 0, 0), new TimeSpan(-3, 0, 0), "Caracas", "Venezuela Daylight Time", "Venezuela Standard Time", "Venezuela Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-4, 0, 0), new TimeSpan(-3, 0, 0), "Cuiaba", "Central Brazilian Daylight Time", "Central Brazilian Standard Time", "Central Brazilian Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-4, 0, 0), new TimeSpan(-4, 0, 0), "Georgetown, La Paz, Manaus, San Juan", "SA Western Daylight Time", "SA Western Standard Time", "SA Western Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-4, 0, 0), new TimeSpan(-3, 0, 0), "Santiago", "Pacific SA Daylight Time", "Pacific SA Standard Time", "Pacific SA Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-3, -30, 0), new TimeSpan(-2, -30, 0), "Newfoundland", "Newfoundland Daylight Time", "Newfoundland Standard Time", "Newfoundland Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-3, 0, 0), new TimeSpan(-2, 0, 0), "Araguaina", "Tocantins Daylight Time", "Tocantins Standard Time", "Tocantins Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-3, 0, 0), new TimeSpan(-2, 0, 0), "Brasilia", "E. South America Daylight Time", "E. South America Standard Time", "E. South America Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-3, 0, 0), new TimeSpan(-3, 0, 0), "Cayenne, Fortaleza", "SA Eastern Daylight Time", "SA Eastern Standard Time", "SA Eastern Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-3, 0, 0), new TimeSpan(-2, 0, 0), "City of Buenos Aires", "Argentina Daylight Time", "Argentina Standard Time", "Argentina Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-3, 0, 0), new TimeSpan(-2, 0, 0), "Montevideo", "Montevideo Daylight Time", "Montevideo Standard Time", "Montevideo Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-3, 0, 0), new TimeSpan(-2, 0, 0), "Punta Arenas", "Magallanes Daylight Time", "Magallanes Standard Time", "Magallanes Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-3, 0, 0), new TimeSpan(-2, 0, 0), "Saint Pierre and Miquelon", "Saint Pierre Daylight Time", "Saint Pierre Standard Time", "Saint Pierre Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-3, 0, 0), new TimeSpan(-2, 0, 0), "Salvador", "Bahia Daylight Time", "Bahia Standard Time", "Bahia Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-2, 0, 0), new TimeSpan(-2, 0, 0), "Coordinated Universal Time-02", "UTC-02", "UTC-02", "UTC-02", false, IsDST),
//            new TrueTimeZone(new TimeSpan(-2, 0, 0), new TimeSpan(-1, 0, 0), "Greenland", "Greenland Daylight Time", "Greenland Standard Time", "Greenland Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-2, 0, 0), new TimeSpan(-1, 0, 0), "Mid-Atlantic - Old", "Mid-Atlantic Daylight Time", "Mid-Atlantic Standard Time", "Mid-Atlantic Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-1, 0, 0), new TimeSpan(0, 0, 0), "Azores", "Azores Daylight Time", "Azores Standard Time", "Azores Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(-1, 0, 0), new TimeSpan(-1, 0, 0), "Cabo Verde Is.", "Cabo Verde Daylight Time", "Cape Verde Standard Time", "Cabo Verde Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0), "Coordinated Universal Time", "Coordinated Universal Time", "UTC", "Coordinated Universal Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(0, 0, 0), new TimeSpan(1, 0, 0), "Dublin, Edinburgh, Lisbon, London", "GMT Daylight Time", "GMT Standard Time", "GMT Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0), "Monrovia, Reykjavik", "Greenwich Daylight Time", "Greenwich Standard Time", "Greenwich Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(0, 0, 0), new TimeSpan(1, 0, 0), "Sao Tome", "Sao Tome Daylight Time", "Sao Tome Standard Time", "Sao Tome Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(0, 0, 0), new TimeSpan(1, 0, 0), "Casablanca", "Morocco Daylight Time", "Morocco Standard Time", "Morocco Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(1, 0, 0), new TimeSpan(2, 0, 0), "Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna", "W. Europe Daylight Time", "W. Europe Standard Time", "W. Europe Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(1, 0, 0), new TimeSpan(2, 0, 0), "Belgrade, Bratislava, Budapest, Ljubljana, Prague", "Central Europe Daylight Time", "Central Europe Standard Time", "Central Europe Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(1, 0, 0), new TimeSpan(2, 0, 0), "Brussels, Copenhagen, Madrid, Paris", "Romance Daylight Time", "Romance Standard Time", "Romance Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(1, 0, 0), new TimeSpan(2, 0, 0), "Sarajevo, Skopje, Warsaw, Zagreb", "Central European Daylight Time", "Central European Standard Time", "Central European Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(1, 0, 0), new TimeSpan(1, 0, 0), "West Central Africa", "W. Central Africa Daylight Time", "W. Central Africa Standard Time", "W. Central Africa Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Athens, Bucharest", "GTB Daylight Time", "GTB Standard Time", "GTB Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Beirut", "Middle East Daylight Time", "Middle East Standard Time", "Middle East Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Cairo", "Egypt Daylight Time", "Egypt Standard Time", "Egypt Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Chisinau", "E. Europe Daylight Time", "E. Europe Standard Time", "E. Europe Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Damascus", "Syria Daylight Time", "Syria Standard Time", "Syria Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Gaza, Hebron", "West Bank Gaza Daylight Time", "West Bank Standard Time", "West Bank Gaza Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(2, 0, 0), "Harare, Pretoria", "South Africa Daylight Time", "South Africa Standard Time", "South Africa Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius", "FLE Daylight Time", "FLE Standard Time", "FLE Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Jerusalem", "Jerusalem Daylight Time", "Israel Standard Time", "Jerusalem Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Juba", "South Sudan Daylight Time", "South Sudan Standard Time", "South Sudan Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Kaliningrad", "Russia TZ 1 Daylight Time", "Kaliningrad Standard Time", "Russia TZ 1 Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Khartoum", "Sudan Daylight Time", "Sudan Standard Time", "Sudan Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Tripoli", "Libya Daylight Time", "Libya Standard Time", "Libya Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0), "Windhoek", "Namibia Daylight Time", "Namibia Standard Time", "Namibia Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(3, 0, 0), new TimeSpan(4, 0, 0), "Amman", "Jordan Daylight Time", "Jordan Standard Time", "Jordan Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(3, 0, 0), new TimeSpan(4, 0, 0), "Baghdad", "Arabic Daylight Time", "Arabic Standard Time", "Arabic Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(3, 0, 0), new TimeSpan(4, 0, 0), "Istanbul", "Turkey Daylight Time", "Turkey Standard Time", "Turkey Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(3, 0, 0), new TimeSpan(3, 0, 0), "Kuwait, Riyadh", "Arab Daylight Time", "Arab Standard Time", "Arab Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(3, 0, 0), new TimeSpan(4, 0, 0), "Minsk", "Belarus Daylight Time", "Belarus Standard Time", "Belarus Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(3, 0, 0), new TimeSpan(4, 0, 0), "Moscow, St. Petersburg", "Russia TZ 2 Daylight Time", "Russian Standard Time", "Russia TZ 2 Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(3, 0, 0), new TimeSpan(3, 0, 0), "Nairobi", "E. Africa Daylight Time", "E. Africa Standard Time", "E. Africa Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(3, 0, 0), new TimeSpan(4, 0, 0), "Volgograd", "Volgograd Daylight Time", "Volgograd Standard Time", "Volgograd Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(3, 30, 0), new TimeSpan(4, 30, 0), "Tehran", "Iran Daylight Time", "Iran Standard Time", "Iran Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(4, 0, 0), new TimeSpan(4, 0, 0), "Abu Dhabi, Muscat", "Arabian Daylight Time", "Arabian Standard Time", "Arabian Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(4, 0, 0), new TimeSpan(5, 0, 0), "Astrakhan, Ulyanovsk", "Astrakhan Daylight Time", "Astrakhan Standard Time", "Astrakhan Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(4, 0, 0), new TimeSpan(5, 0, 0), "Baku", "Azerbaijan Daylight Time", "Azerbaijan Standard Time", "Azerbaijan Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(4, 0, 0), new TimeSpan(5, 0, 0), "Izhevsk, Samara", "Russia TZ 3 Daylight Time", "Russia Time Zone 3", "Russia TZ 3 Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(4, 0, 0), new TimeSpan(5, 0, 0), "Port Louis", "Mauritius Daylight Time", "Mauritius Standard Time", "Mauritius Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(4, 0, 0), new TimeSpan(5, 0, 0), "Saratov", "Saratov Daylight Time", "Saratov Standard Time", "Saratov Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(4, 0, 0), new TimeSpan(4, 0, 0), "Tbilisi", "Georgian Daylight Time", "Georgian Standard Time", "Georgian Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(4, 0, 0), new TimeSpan(5, 0, 0), "Yerevan", "Caucasus Daylight Time", "Caucasus Standard Time", "Caucasus Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(4, 30, 0), new TimeSpan(4, 30, 0), "Kabul", "Afghanistan Daylight Time", "Afghanistan Standard Time", "Afghanistan Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(5, 0, 0), new TimeSpan(5, 0, 0), "Ashgabat, Tashkent", "West Asia Daylight Time", "West Asia Standard Time", "West Asia Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(5, 0, 0), new TimeSpan(6, 0, 0), "Ekaterinburg", "Russia TZ 4 Daylight Time", "Ekaterinburg Standard Time", "Russia TZ 4 Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(5, 0, 0), new TimeSpan(6, 0, 0), "Islamabad, Karachi", "Pakistan Daylight Time", "Pakistan Standard Time", "Pakistan Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(5, 0, 0), new TimeSpan(6, 0, 0), "Qyzylorda", "Qyzylorda Daylight Time", "Qyzylorda Standard Time", "Qyzylorda Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(5, 30, 0), new TimeSpan(5, 30, 0), "Chennai, Kolkata, Mumbai, New Delhi", "India Daylight Time", "India Standard Time", "India Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(5, 30, 0), new TimeSpan(5, 30, 0), "Sri Jayawardenepura", "Sri Lanka Daylight Time", "Sri Lanka Standard Time", "Sri Lanka Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(5, 45, 0), new TimeSpan(5, 45, 0), "Kathmandu", "Nepal Daylight Time", "Nepal Standard Time", "Nepal Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(6, 0, 0), new TimeSpan(6, 0, 0), "Astana", "Central Asia Daylight Time", "Central Asia Standard Time", "Central Asia Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(6, 0, 0), new TimeSpan(7, 0, 0), "Dhaka", "Bangladesh Daylight Time", "Bangladesh Standard Time", "Bangladesh Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(6, 0, 0), new TimeSpan(7, 0, 0), "Omsk", "Omsk Daylight Time", "Omsk Standard Time", "Omsk Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(6, 30, 0), new TimeSpan(6, 30, 0), "Yangon (Rangoon)", "Myanmar Daylight Time", "Myanmar Standard Time", "Myanmar Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(7, 0, 0), new TimeSpan(7, 0, 0), "Bangkok, Hanoi, Jakarta", "SE Asia Daylight Time", "SE Asia Standard Time", "SE Asia Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(7, 0, 0), new TimeSpan(8, 0, 0), "Barnaul, Gorno-Altaysk", "Altai Daylight Time", "Altai Standard Time", "Altai Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(7, 0, 0), new TimeSpan(8, 0, 0), "Hovd", "W. Mongolia Daylight Time", "W. Mongolia Standard Time", "W. Mongolia Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(7, 0, 0), new TimeSpan(8, 0, 0), "Krasnoyarsk", "Russia TZ 6 Daylight Time", "North Asia Standard Time", "Russia TZ 6 Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(7, 0, 0), new TimeSpan(8, 0, 0), "Novosibirsk", "Novosibirsk Daylight Time", "N. Central Asia Standard Time", "Novosibirsk Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(7, 0, 0), new TimeSpan(8, 0, 0), "Tomsk", "Tomsk Daylight Time", "Tomsk Standard Time", "Tomsk Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(8, 0, 0), new TimeSpan(8, 0, 0), "Beijing, Chongqing, Hong Kong, Urumqi", "China Daylight Time", "China Standard Time", "China Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(8, 0, 0), new TimeSpan(9, 0, 0), "Irkutsk", "Russia TZ 7 Daylight Time", "North Asia East Standard Time", "Russia TZ 7 Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(8, 0, 0), new TimeSpan(8, 0, 0), "Kuala Lumpur, Singapore", "Malay Peninsula Daylight Time", "Singapore Standard Time", "Malay Peninsula Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(8, 0, 0), new TimeSpan(9, 0, 0), "Perth", "W. Australia Daylight Time", "W. Australia Standard Time", "W. Australia Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(8, 0, 0), new TimeSpan(8, 0, 0), "Taipei", "Taipei Daylight Time", "Taipei Standard Time", "Taipei Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(8, 0, 0), new TimeSpan(9, 0, 0), "Ulaanbaatar", "Ulaanbaatar Daylight Time", "Ulaanbaatar Standard Time", "Ulaanbaatar Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(8, 45, 0), new TimeSpan(8, 45, 0), "Eucla", "Aus Central W. Daylight Time", "Aus Central W. Standard Time", "Aus Central W. Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0), "Chita", "Transbaikal Daylight Time", "Transbaikal Standard Time", "Transbaikal Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(9, 0, 0), new TimeSpan(9, 0, 0), "Osaka, Sapporo, Tokyo", "Tokyo Daylight Time", "Tokyo Standard Time", "Tokyo Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0), "Pyongyang", "North Korea Daylight Time", "North Korea Standard Time", "North Korea Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(9, 0, 0), new TimeSpan(9, 0, 0), "Seoul", "Korea Daylight Time", "Korea Standard Time", "Korea Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0), "Yakutsk", "Russia TZ 8 Daylight Time", "Yakutsk Standard Time", "Russia TZ 8 Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(9, 30, 0), new TimeSpan(10, 30, 0), "Adelaide", "Cen. Australia Daylight Time", "Cen. Australia Standard Time", "Cen. Australia Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(9, 30, 0), new TimeSpan(9, 30, 0), "Darwin", "AUS Central Daylight Time", "AUS Central Standard Time", "AUS Central Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(10, 0, 0), new TimeSpan(10, 0, 0), "Brisbane", "E. Australia Daylight Time", "E. Australia Standard Time", "E. Australia Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), "Canberra, Melbourne, Sydney", "AUS Eastern Daylight Time", "AUS Eastern Standard Time", "AUS Eastern Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(10, 0, 0), new TimeSpan(10, 0, 0), "Guam, Port Moresby", "West Pacific Daylight Time", "West Pacific Standard Time", "West Pacific Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), "Hobart", "Tasmania Daylight Time", "Tasmania Standard Time", "Tasmania Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), "Vladivostok", "Russia TZ 9 Daylight Time", "Vladivostok Standard Time", "Russia TZ 9 Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(10, 30, 0), new TimeSpan(11, 30, 0), "Lord Howe Island", "Lord Howe Daylight Time", "Lord Howe Standard Time", "Lord Howe Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0), "Bougainville Island", "Bougainville Daylight Time", "Bougainville Standard Time", "Bougainville Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0), "Chokurdakh", "Russia TZ 10 Daylight Time", "Russia Time Zone 10", "Russia TZ 10 Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0), "Magadan", "Magadan Daylight Time", "Magadan Standard Time", "Magadan Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0), "Norfolk Island", "Norfolk Daylight Time", "Norfolk Standard Time", "Norfolk Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0), "Sakhalin", "Sakhalin Daylight Time", "Sakhalin Standard Time", "Sakhalin Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(11, 0, 0), new TimeSpan(11, 0, 0), "Solomon Is., New Caledonia", "Central Pacific Daylight Time", "Central Pacific Standard Time", "Central Pacific Standard Time", false, IsDST),
//            new TrueTimeZone(new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0), "Anadyr, Petropavlovsk-Kamchatsky", "Russia TZ 11 Daylight Time", "Russia Time Zone 11", "Russia TZ 11 Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0), "Auckland, Wellington", "New Zealand Daylight Time", "New Zealand Standard Time", "New Zealand Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(12, 0, 0), new TimeSpan(12, 0, 0), "Coordinated Universal Time+12", "UTC+12", "UTC+12", "UTC+12", false, IsDST),
//            new TrueTimeZone(new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0), "Fiji", "Fiji Daylight Time", "Fiji Standard Time", "Fiji Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(12, 0, 0), new TimeSpan(13, 0, 0), "Petropavlovsk-Kamchatsky - Old", "Kamchatka Daylight Time", "Kamchatka Standard Time", "Kamchatka Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(12, 45, 0), new TimeSpan(13, 45, 0), "Chatham Islands", "Chatham Islands Daylight Time", "Chatham Islands Standard Time", "Chatham Islands Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(13, 0, 0), new TimeSpan(13, 0, 0), "Coordinated Universal Time+13", "UTC+13", "UTC+13", "UTC+13", false, IsDST),
//            new TrueTimeZone(new TimeSpan(13, 0, 0), new TimeSpan(14, 0, 0), "Nuku'alofa", "Tonga Daylight Time", "Tonga Standard Time", "Tonga Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(13, 0, 0), new TimeSpan(14, 0, 0), "Samoa", "Samoa Daylight Time", "Samoa Standard Time", "Samoa Standard Time", true, IsDST),
//            new TrueTimeZone(new TimeSpan(14, 0, 0), new TimeSpan(14, 0, 0), "Kiritimati Island", "Line Islands Daylight Time", "Line Islands Standard Time", "Line Islands Standard Time", false, IsDST),
//        };
//    }
//}
