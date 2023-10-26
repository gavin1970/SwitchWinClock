using System.Reflection;

namespace SwitchWinClock.utils
{
    internal class EventTypes
    {
        public const int EVENT_SHUTDOWN = 0;
        public const int EVENT_MANUAL = 1;
        public const int EVENT_TIMEOUT = 258;
    }

    internal class ColNames
    {
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
