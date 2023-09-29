using SwitchWinClock.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SwitchWinClock
{
    internal static class Program
    {
        private static Mutex mutex;
        const string debugFile = "./startup.log";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
#if DEBUG
            string mutexExt = "Debug";
#else
            string mutexExt = "Release";
#endif
            bool createdNew = false;
            string appName = $"{About.AppTitle.Replace(" ", "")}{mutexExt}";
            Global.AppID = 1;   //default

            if (File.Exists(debugFile))
                File.Delete(debugFile);

            File.AppendAllText(debugFile, $"appName: {appName}\n");

            //ignore args, just want to make sure an int was passed in.
            if (args.Length == 1 && int.TryParse(args[0], out int id))
            {
                File.AppendAllText(debugFile, $"Arg.length == 1\n");
                for (; Global.AppID < 10; Global.AppID++)
                {
                    File.AppendAllText(debugFile, $"Checking: {appName}{ Global.AppID}\n");
                    mutex = new Mutex(initiallyOwned: true, $"{appName}{Global.AppID}", out createdNew);
                    if (createdNew)
                    {
                        File.AppendAllText(debugFile, $"createdNew (break): {appName}{Global.AppID}\n");
                        break;
                    }
                    File.AppendAllText(debugFile, $"Was found, Check next.\n");
                }
            }
            else
            {
                File.AppendAllText(debugFile, $"Arg.length != 1 or Arg wasn't Int\n");
                File.AppendAllText(debugFile, $"Checking 2: {appName}{Global.AppID}\n");
                mutex = new Mutex(initiallyOwned: true, $"{appName}{Global.AppID}", out createdNew);
            }

            if (!createdNew)
            {
                File.AppendAllText(debugFile, $"Exiting: createdNew: {createdNew}\n");
                return;
            }

            File.AppendAllText(debugFile, $"Starting: {appName}{Global.AppID}\n");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DisplayForm());
        }
    }
}
