using System.Reflection;

namespace SwitchWinClock.utils
{
    internal class EventTypes
    {
        public const int EVENT_SHUTDOWN = 0;
        public const int EVENT_MANUAL = 1;
        public const int EVENT_TIMEOUT = 258;
    }

    internal class MenuText
    {
        public const string TextBorderText = "&Text Border Size";
        public const string TextDepthText = "&Text Depth";
    }

    internal class ExampleDateTimeFormats
    {
        public const string dddd_MMMdd_hhmmss_tt = "dddd, MMM dd, hh:mm:ss tt";
        public const string ddd_MMMdd_HHmmss = "ddd, MMM dd, HH:mm:ss";
        public const string dddd_MMMMdd = "dddd, MMMM dd";
        public const string hhmmss_tt = "hh:mm:ss tt";
        public const string z_hhmmss_tt = "(z) hh:mm:ss tt";
        public const string zz_hhmmss_tt = "(zz) hh:mm:ss tt";
        public const string zzz_hhmmss_tt = "(zzz) hh:mm:ss tt";
        public const string zzzz_id = "(zzzz) - {id}";
        public const string dtst = @"DST or S\tan\dar\d Ti\me: {dtst}";
        public const string Text_hhmmss = @"Cu\s\to\m \tex\t exa\mple: hh:mm:ss";

        internal static FieldInfo[] GetFormats
        {
            get
            {
                return typeof(ExampleDateTimeFormats).GetFields(
                                        BindingFlags.Public |
                                        BindingFlags.Static |
                                        BindingFlags.FlattenHierarchy);
            }
        }
    }
    internal class ColNames
    {
        public const string InstanceName = "InstanceName";
        public const string ClockStyle = "ClockStyle";
        public const string DateFormat = "DateFormat";
        public const string FormLocation = "FormLocation";
        public const string Font = "Font";
        public const string TextBorderDepth = "TextBorderDepth";
        public const string ForeColor = "ForeColor";
        public const string BackColor = "BackColor";
        public const string FormBorderColor = "FormBorderColor";
        public const string TextBorderColor = "TextBorderColor";
        public const string TextAlignment = "TextAlignment";
        public const string ManualWinAlignment = "ManualWinAlignment";
        public const string WinAlignment = "WinAlignment";
        public const string DeviceNumber = "DeviceNumber";
        public const string AlwaysOnTop = "AlwaysOnTop";
        public const string ImAlive = "ImAlive";
        public const string TimeZone = "TimeZone";

        internal static FieldInfo[] GetFields
        { 
            get 
            {
                return typeof(ColNames).GetFields(
                                        BindingFlags.Public |
                                        BindingFlags.Static |
                                        BindingFlags.FlattenHierarchy);
            }
        }
    }
}
