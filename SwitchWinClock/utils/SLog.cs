using System;
using System.IO;

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
    /// Threw together a very simple thread safe text logger.  
    /// This is NOT written for speed.  Just simple app text logging.
    /// </summary>
    internal class SLog
    {
        private static readonly object logLock = new object();

        #region Internal Statics
        internal static SMsgType LogLevel { get; set; } = SMsgType.Debug;
        #endregion

        #region Private Statics
        //internal so it can be changed on the fly.
        private static bool LoggerEnabled { get; set; } = false;
        //1, 2, 4, 8 = requires 9.  Could be a lookup, but this is quicker, no look up needed.
        private static long[] LogSizes { get; set; } = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //1, 2, 4, 8 = requires 9.  Could be a lookup, but this is quicker, no look up needed.
        private static long[] Incr { get; set; } = new long[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        #endregion

        #region Constants
        const int MaxDaysForLogs = 30;
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
            //this will allow it to be fully loaded before a new instnace can be created.
            lock (logLock)
            {
                //ensures new insnaces follow original rules.
                if (!LoggerEnabled)
                {
                    //set so new instance will run this over again.
                    LoggerEnabled = true;
                    //set Log Level, this can also be changed via public this->LogLevel
                    LogLevel = logLevel;

                    //check if folder exists
                    if (!Directory.Exists(LogFolder))
                        Directory.CreateDirectory(LogFolder);

                    //run cleanup on old log files
                    CleanOldLogs();

                    DateTime now = DateTime.Now;
                    var msgTypes = Enum.GetValues(typeof(SMsgType));

                    //go through all log types, checking size and setting names.
                    foreach (SMsgType msgType in msgTypes)
                    {
                        //inital run
                        string filePath = $"{LogFolder}{now:yyMMdd}_{msgType}_{Incr[(int)msgType]:00}{LogExt}";
                        var fileInfo = new FileInfo(filePath);
                        //check size
                        while (fileInfo.Exists && fileInfo.Length > MaxFileSize)
                        {
                            //was too big, lets try the next incr version of todays.
                            Incr[(int)msgType]++;
                            //new file name
                            filePath = $"{LogFolder}{now:yyMMdd}_{msgType}_{Incr[(int)msgType]:00}{LogExt}";
                            //load new file
                            fileInfo = new FileInfo(filePath);
                        }
                        //keep track of log sizes for each type.
                        LogSizes[(int)msgType] = fileInfo.Exists ? fileInfo.Length : 0;
                    }
                }
            }
        }
        /// <summary>
        /// Clean up logs based on MaxDaysForLogs
        /// </summary>
        private void CleanOldLogs()
        {
            //get all log files
            string[] allFiles = Directory.GetFiles(LogFolder, $"*{LogExt}");
            //get current time
            DateTime now = DateTime.Now;
            //find oldest allowed 
            DateTime cutOffDate = now.AddDays(-MaxDaysForLogs);
            //loop through files
            foreach (string f in allFiles)
            {
                //pull file info
                FileInfo fileInfo = new FileInfo(f);
                //if prior to cut off date
                if (fileInfo.LastWriteTime < cutOffDate)
                    fileInfo.Delete();  //delete file
            }
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

                    //if log size for this log type is greater than max size, then create a new one.
                    if (LogSizes[(int)msgType] > MaxFileSize)
                    {
                        //while we are here.
                        CleanOldLogs();
                        //increment todays filename.
                        Incr[(int)msgType]++;
                        //set inital file length
                        LogSizes[(int)msgType] = msg.Length;
                    }
                    else
                        LogSizes[(int)msgType] += msg.Length;   //update max length

                    //file name is now set based on type and max size incr number.
                    string fileName = $"{LogFolder}{now:yyMMdd}_{msgType}_{Incr[(int)msgType]:00}{LogExt}";

                    //could open the file up front and leave it open, but don't
                    //figure that we need that much logged all the time.
                    File.AppendAllText(fileName, msg);
                }
            }
        }
        #endregion
    }
}
