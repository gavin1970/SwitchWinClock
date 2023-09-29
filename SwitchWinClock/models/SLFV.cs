using SwitchWinClock.utils;
using System;

namespace SwitchWinClock.models
{
    public class SLFV
    {
        string _version = string.Empty;
        static bool _beenHere = false;
        public SLFV(string v)
        {
            if (string.IsNullOrWhiteSpace(v) && !_beenHere)
            {
                _version = About.AppInfo.FileVersion.Full;
                _beenHere = true;
            }
            else
                _version = v;
        }
        public string Full { get { return _version; } }
        public int Major { get { return GetVerNo<int>(0); } }
        public int Minor { get { return GetVerNo<int>(1); } }
        public int Revision { get { return GetVerNo<int>(2); } }
        public int Build { get { return GetVerNo<int>(3); } }
        public string MajorMinor { get { return GetVerNo<string>(1, true); } }
        public string MajorMinorBuild { get { return GetVerNo<string>(2, true); } }
        private T GetVerNo<T>(int lvl, bool restOf = false)
        {
            var retVal = default(T);
            string sRetVal = string.Empty;

            if (!string.IsNullOrWhiteSpace(_version))
            {
                //1.2.3.4
                string[] vs = _version.Split('.');
                //if version type exists.
                if (vs.Length >= lvl + 1)
                {
                    if (restOf)
                    {
                        for (int i = 0; i <= lvl; i++)
                        {
                            if (i > 0)
                                sRetVal += ".";

                            sRetVal += vs[i];
                        }
                    }
                    else
                        sRetVal = vs[lvl];
                }

                if (!string.IsNullOrWhiteSpace(sRetVal))
                    retVal = (T)Convert.ChangeType(sRetVal, typeof(T));
            }

            return retVal;
        }
    }
}
