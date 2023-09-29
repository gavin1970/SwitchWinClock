using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SwitchWinClock.utils
{
    internal enum SMsgType
    {
        Debug = 1,
        Information = 2,
        Warning = 4,
        Error = 8
    }

    /// <summary>
    /// Simplest thread safe logger ever made.
    /// </summary>
    internal class SLog
    {
        #region Private Statics
        private static readonly object logLock = new object();
        private static SMsgType LogLevel { get; set; } = SMsgType.Debug;
        private static bool LoggerEnabled { get; set; } = false;
        private static long[] LogSizes = new long[0];
        private static long[] Incr = new long[0];
        #endregion

        #region Constants
        const long MaxFileSize = 50 * 1024 * 1024;  // 50MB
        const string LogFolder = "./Logs/";
        const string LogExt = ".log";
        #endregion

        #region Constructor
        /// <summary>
        /// Use what ever LogLevel is coded as default above or from previous instance.  This allow 
        /// new instance of logger in new class to use the same setting as startup as well as sharing logLock.
        /// </summary>
        internal SLog() : this(LogLevel) {}
        /// <summary>
        /// Set log level something beside default instance.  Note, changing this effects 
        /// all instances of this logger and will all move to the same LogLevel.
        /// </summary>
        /// <param name="logLevel"></param>
        internal SLog(SMsgType logLevel) 
        {
            if (!LoggerEnabled)
            {
                if (!Directory.Exists(LogFolder))
                    Directory.CreateDirectory(LogFolder);

                LogSizes = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                Incr = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                DateTime now = DateTime.Now;
                var msgTypes = Enum.GetValues(typeof(SMsgType));

                foreach (SMsgType msgType in msgTypes)
                {
                    string filePath = $"{LogFolder}{now:yyMMdd}_{msgType}_{Incr[(int)msgType]:00}{LogExt}";
                    var fileInfo = new FileInfo(filePath);
                    while (fileInfo.Exists && fileInfo.Length > MaxFileSize)
                    {
                        Incr[(int)msgType]++;
                        filePath = $"{LogFolder}{now:yyMMdd}_{msgType}_{Incr[(int)msgType]:00}{LogExt}";
                        fileInfo = new FileInfo(filePath);
                    }
                    LogSizes[(int)msgType] = fileInfo.Exists ? fileInfo.Length : 0;
                }

                LoggerEnabled = true;
            }

            LogLevel = logLevel;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Default message to lowest log level.
        /// </summary>
        /// <param name="message"></param>
        public void WriteLine(string message) 
        {
            WriteLine(LogLevel, message);
        }
        /// <summary>
        /// Set specific logLevel for a message.
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="message"></param>
        public void WriteLine(SMsgType msgType, string message)
        {
            if (msgType >= LogLevel)
            {
                //thread safe
                lock (logLock)
                {
                    DateTime now = DateTime.Now;
                    string msg = $"{now:HH:mm:ss.fff}: {message}\n";

                    if (LogSizes[(int)msgType] > MaxFileSize)
                    {
                        Incr[(int)msgType]++;
                        LogSizes[(int)msgType] = msg.Length;
                    }
                    else
                        LogSizes[(int)msgType] += msg.Length;

                    string fileName = $"{LogFolder}{now:yyMMdd}_{msgType}_{Incr[(int)msgType]:00}{LogExt}";

                    File.AppendAllText(fileName, msg);
                }
            }
        }
        #endregion
    }
}
