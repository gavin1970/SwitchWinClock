using System.Drawing;

namespace SwitchWinClock.utils
{
    public static class ClassExt
    {
        public static int ToInt(this FontStyle value) 
        { 
            return (int)value; 
        }
    }
}
