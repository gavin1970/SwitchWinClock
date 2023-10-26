using Newtonsoft.Json;
using SwitchWinClock.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Note to anyone that looks through any of my classes.  I like Properites over variables.  
/// It allows me to quickly see how many things are using it and quick references to all.
/// Some things can't be properties, which is why the are variables.
/// </summary>
namespace SwitchWinClock.utils
{
    public abstract class JSONHelper : IDisposable
    {
        public struct FIELD_VALUE
        {
            public string FieldName;
            public string Value;
        }

        internal const string SCHEMA_TABLE_NAME = "schemas";
        private const string MISSING_FILE = "File path in connection string is required.  e.g. file=C:\\Path\\DataFile.data";
        private bool m_disposedValue = false;

        /// <summary>
        /// This LastChanged is because the event will fire 2-3 times on one 
        /// change, so we only want to catch the first and ignore the rest for 1 sec.
        /// </summary>
        private static DateTime LastChanged { get; set; } = DateTime.Now;
        public static object DSetLock { get; } = new object();
        private static bool LocalSave { get; set; } = false;
        private static bool MonitorSet { get; set; } = false;
        private static FileSystemWatcher Watcher { get; set; }

        #region Public Properties
        /// <summary>
        /// set errors that might occur
        /// </summary>
        public Exception LastError { get; set; } = null;
        #endregion

        #region Internal Properties
        /// <summary>
        /// Holds all data records as a data table.
        /// </summary>
        internal DataSet RecordData { get; set; } = null;
        /// <summary>
        /// set connection string
        /// </summary>
        internal NetworkCredential ConnectionString { get; set; } = null;
        /// <summary>
        /// Last Stored Procedure
        /// </summary>
        internal string LastStoredProcedure { get; set; } = null;
        /// <summary>
        /// Last Parameters Passed in.
        /// </summary>
        internal object[] LastParameters { get; set; } = null;
        #endregion

        #region Internal Methods
        /// <summary>
        /// Setup watch of Monitor, if someone modifies it outside of this app, it will pick up the changes.
        /// </summary>
        internal void SetFileMonitor()
        {
            if (!File.Exists(ConnectionString.UserName) || MonitorSet)
                return;

            //dont allow more than one.
            MonitorSet = true;
            //folder to monitor
            string dir = Path.GetDirectoryName(ConnectionString.UserName);
            //check
            if (string.IsNullOrWhiteSpace(dir))
                dir = About.AppFileDirectory;
            //lets setup watch
            if (!string.IsNullOrWhiteSpace(dir) && Watcher == null)
            {
                Watcher = new FileSystemWatcher(dir)
                {
                    //info to send me.
                    NotifyFilter = NotifyFilters.CreationTime
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.Size
                };
                //event to be sent where for Change ONLY.
                Watcher.Changed += OnChanged;
                //filter to this config file only.
                Watcher.Filter = Path.GetFileName(ConnectionString.UserName);
                //no other folders or files.
                Watcher.IncludeSubdirectories = false;
                //allow event
                Watcher.EnableRaisingEvents = true;
            }
        }
        /// <summary>
        /// File Watcher Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            //at times, 3 events are fired, only accept the first.
            //also if this file is doing the save, we want that ignored as well.
            //Should be only change, doesn't hurt to verify.
            if (DateTime.Now.Subtract(LastChanged) < TimeSpan.FromSeconds(1) || 
                LocalSave || 
                e.ChangeType != WatcherChangeTypes.Changed)
                return;
            else
                LastChanged = DateTime.Now;

            //lets force a reload of data.
            LoadData(true);
        }
        private Color Convert2Color(string color)
        {
            Color retVal = Color.Empty;

            string s = Regex.Replace(color, "[^0-9,-]", "");
            if (Int32.TryParse(color, out Int32 colInt))
                retVal = Color.FromArgb(colInt);
            else if (s.IndexOf(',') > -1)
            {
                string[] colorSplit = s.Split(',');
                List<int> argb = new List<int>();
                foreach (string newS in colorSplit)
                {
                    if (int.TryParse(newS, out int c))
                        argb.Add(c);
                }
                if (argb.Count > 3)
                    retVal = Color.FromArgb(argb[0], argb[1], argb[2], argb[3]);
                else if (argb.Count > 2)
                    retVal = Color.FromArgb(255, argb[0], argb[1], argb[2]);
            }
            else
                retVal = Color.FromName(color);

            return retVal;
        }
        /// <summary>
        /// Many formats of Font as string, these 
        /// are the most popular ones.
        /// </summary>
        /// <param name="fontString"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private Font Convert2Font(string fontString)
        {
            var fC = new FontConverter();
            try
            {
                //lets try easy way first.
                var ft = fC.ConvertFromString(fontString) as Font;
                return ft;
            }
            catch { }

            string stripFont = fontString;

            //format 1
            if (fontString.StartsWith("[Font: "))
            {
                try
                {
                    stripFont = fontString.Replace("[Font: ", "").Replace("]", "");
                    var ft = fC.ConvertFromString(stripFont) as Font;
                    return ft;
                }
                catch { /* Ingore, we will try the next format */ }
            }

            //format 2
            if (fontString.Contains("Name="))
            {
                try
                {
                    string[] fontSplit = stripFont.Split(',');

                    string name = "";
                    float size = 0F;
                    FontStyle style = FontStyle.Regular;
                    GraphicsUnit units = GraphicsUnit.Pixel;
                    byte gdiCharSet = 0;
                    bool gdiVerticalFont = false;

                    foreach (string s in fontSplit)
                    {
                        string[] col = s.Split('=');
                        switch (col[0].ToLower().Trim())
                        {
                            case "name":
                                name = col[1];
                                break;
                            case "size":
                                size = float.Parse(col[1]);
                                break;
                            case "style":
                                if (int.TryParse(col[1], out int iStyle))
                                    style = (FontStyle)Enum.ToObject(typeof(FontStyle), iStyle);
                                else
                                    style = (FontStyle)Enum.ToObject(typeof(FontStyle), col[1]);
                                break;
                            case "units":
                                if (int.TryParse(col[1], out int iUnit))
                                    units = (GraphicsUnit)Enum.ToObject(typeof(GraphicsUnit), iUnit);
                                else
                                    units = (GraphicsUnit)Enum.ToObject(typeof(GraphicsUnit), col[1]);
                                break;
                            case "gdicharset":
                                gdiCharSet = byte.Parse(col[1]);
                                break;
                            case "gdiverticalfont":
                                gdiVerticalFont = bool.Parse(col[1]);
                                break;
                        }
                    }

                    var ft = new Font(name, size, style, units, gdiCharSet, gdiVerticalFont);
                    return ft;
                }
                catch { }
            }

            throw new Exception($"Font couldn't be converted from String '{fontString}'");
        }

        /// <summary>
        /// converts color to integer.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal int ColorToInt(Color color)
        {
            try
            {
                int iArgb = color.ToArgb();
                return iArgb;
            }
            catch { }

            try
            {
                //near color, since exact doesn't work.
                KnownColor kc = color.ToKnownColor();
                int iArgb = Color.FromKnownColor(kc).ToArgb();

                return iArgb;
            }
            catch { }

            throw new Exception($"Cannot convert Color {color} to int.");
        }
        internal void ClearError()
        {

        }
        /// <summary>
        /// Internal user to validate params have been set along with data loaded.
        /// </summary>
        internal void CheckFilePath()
        {
            string errMsg = null;

            if (string.IsNullOrWhiteSpace(ConnectionString.UserName))
                errMsg = MISSING_FILE;

            if (errMsg == null)
            {
                ResultStatus rs = LoadData();
                if (rs.Status != RESULT_STATUS.OK && rs.Status != RESULT_STATUS.MISSING)
                    errMsg = rs.Description;
            }

            //check to ensure a valid connections tring was passed.
            if (errMsg != null)
                //create error
                ThrowException(errMsg);
        }
        /// <summary>
        /// throw an exception and put it in the last error property
        /// </summary>
        /// <param name="msg"></param>
        internal void ThrowException(string msg)
        {
            //create error
            LastError = new Exception(msg);
            //pass the error back to the client
            throw LastError;
        }
        /// <summary>
        /// Load all data from JSON to DataSet "RecordData"
        /// </summary>
        /// <returns></returns>
        internal ResultStatus LoadData(bool force = false)
        {
            ResultStatus retVal = new ResultStatus();
            if (RecordData != null && RecordData.Tables.Count != 0 && !force)
                return retVal;

            try
            {
                if (!File.Exists(ConnectionString.UserName))
                {
                    retVal.Status = RESULT_STATUS.MISSING;
                    retVal.Description = $"Missing Data File: {ConnectionString.UserName}";
                    lock (DSetLock)
                    {
                        if (RecordData == null)
                            RecordData = new DataSet();
                    }
                }
                else
                {
                    lock (DSetLock)
                    {
                        byte[] bytes = File.ReadAllBytes(ConnectionString.UserName);
                        string json = Encoding.UTF8.GetString(bytes);
                        RecordData = (DataSet)JsonConvert.DeserializeObject(GetSecure(json).Password, (typeof(DataSet)));
                    }
                    ColumnCheck();
                }
            }
            catch (Exception ex)
            {
                retVal.Status = RESULT_STATUS.EXCEPTION;
                retVal.Description = ex.Message;
                retVal.StackTrace = ex.StackTrace;
            }

            return retVal;
        }
        internal NetworkCredential GetSecure(SecureString sec)
        {
            return new NetworkCredential("", sec);
        }
        internal NetworkCredential GetSecure(string sec)
        {
            return new NetworkCredential("", sec);
        }
        internal ResultStatus SaveJsonData(string jsonData)
        {
            ResultStatus retVal = new ResultStatus();

            try
            {
                lock (DSetLock)
                    RecordData = (DataSet)JsonConvert.DeserializeObject(jsonData, (typeof(DataSet)));
            }
            catch (Exception ex)
            {
                retVal.Status = RESULT_STATUS.EXCEPTION;
                retVal.Description = ex.Message;
                retVal.StackTrace = ex.StackTrace;
            }

            return SaveData();
        }
        internal void ColumnCheck()
        {
            if (RecordData == null || !RecordData.Tables.Contains(SCHEMA_TABLE_NAME))
                return;

            lock (DSetLock)
            {
                DataTable schemaDataTable = RecordData.Tables[SCHEMA_TABLE_NAME];
                if (schemaDataTable?.Rows != null && schemaDataTable.Rows?.Count > 0)
                {
                    DataRow schemaDataRow = schemaDataTable.Rows[0];

                    foreach (DataTable dt in RecordData.Tables)
                    {
                        if (dt.Rows.Count == 0)
                        {
                            string[] columns = schemaDataRow[dt.TableName].ToString().Split(',');
                            foreach (string column in columns)
                                dt.Columns.Add(column);
                        }
                    }
                }

                //we don't want send this back to caller since it's an internal table.
                RecordData.Tables.Remove(SCHEMA_TABLE_NAME);
            }
        }
        internal string GetJsonData()
        {
            DataSet dataSet = null;

            lock (DSetLock)
            {
                dataSet = new DataSet(RecordData.DataSetName);
                foreach (DataTable dt in RecordData.Tables)
                {
                    if (dt.TableName == SCHEMA_TABLE_NAME)
                        continue;

                    DataTable newDt = new DataTable(dt.TableName);
                    foreach (DataColumn dc in dt.Columns)
                        newDt.Columns.Add(dc.ColumnName);

                    foreach (DataRow dr in dt.Rows)
                    {
                        DataRow newDr = newDt.NewRow();
                        foreach (DataColumn dc in dt.Columns)
                        {
                            string val = dr[dc.ColumnName].ToString();
                            newDr[dc.ColumnName] = val;
                        }

                        newDt.Rows.Add(newDr);
                    }

                    dataSet.Tables.Add(newDt);
                }
            }

            if (dataSet != null)
                return JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            else
                return null;
        }
        internal ResultStatus UpdateSchemas()
        {
            ResultStatus retVal = new ResultStatus();
            DataTable schemaTable = new DataTable(SCHEMA_TABLE_NAME);
            DataRow schemaDataRow = schemaTable.NewRow();

            lock (DSetLock)
            {
                if (RecordData.Tables.Contains(SCHEMA_TABLE_NAME))
                    RecordData.Tables.Remove(SCHEMA_TABLE_NAME);

                foreach (DataTable dt in RecordData.Tables)
                {
                    schemaTable.Columns.Add(dt.TableName);

                    string columnNames = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (columnNames.Length > 0)
                            columnNames += ",";
                        columnNames += dc.ColumnName;
                    }

                    schemaDataRow[dt.TableName] = columnNames;
                }

                schemaTable.Rows.Add(schemaDataRow);
                RecordData.Tables.Add(schemaTable);
            }

            return retVal;
        }
        /// <summary>
        /// Converts JSON special characters to unicode and back during restore.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="restore"></param>
        /// <returns></returns>
        public string JsonClean(string jsonValue, bool restore = false)
        {
            jsonValue = string.IsNullOrWhiteSpace(jsonValue) ? "" : jsonValue.Trim();
            //return jsonValue;
            List<char> lookfor = new List<char> { '/', '\"', '\'', '\b', '\f', '\t', '\r', '\n' };

            foreach (char ch in lookfor)
            {
                string find = string.Empty;
                string replace = string.Empty;

                if (restore)
                {
                    find = $"$\\{ch}$";
                    replace = ch.ToString();
                }
                else
                {
                    find = ch.ToString();
                    replace = $"$\\{ch}$";
                }

                if (jsonValue.IndexOf(find) > -1)
                    jsonValue = jsonValue.Replace(find, replace);
            }

            return jsonValue;
        }
        /// <summary>
        /// Generic to get column from a DataRow
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="columnName"></param>
        /// <returns>Generic</returns>
        /// <example>
        /// int userId = dataHelper.GetColumn<int>(dataRow, "UserID")
        /// </example>
        public T GetColumn<T>(DataRow dr, string columnName, T defaultValue = default)
        {
            object retVal = default(T);

            try
            {
                var value = dr[columnName];
                Type type = value.GetType();

                if (type.Name == "DBNull")
                    value = defaultValue;

                //if not null then convert it to what the generic is..
                if (value != null)
                {
                    if (typeof(T).IsEnum)
                    {
                        if (int.TryParse(value.ToString(), out int iVal))
                            retVal = (T)Enum.ToObject(typeof(T), iVal);
                        else
                            retVal = (T)value;
                    }
                    else if (typeof(T).Name == "Font")
                    {
                        retVal = Convert2Font(value?.ToString());
                    }
                    else if (type.Name == "Guid" && typeof(T).Name == "String")
                    {
                        //has to be converted this way as Convert.ChangeType can't convert.
                        Guid guid = (Guid)value;
                        retVal = guid.ToString().ToUpper();
                    }
                    else if (typeof(T).Name == "Guid")
                    {
                        //has to be converted this way as Convert.ChangeType can't convert.
                        retVal = (Guid)value;
                    }
                    else if (typeof(T).Name == "Color" && (type.Name == "String" || type.Name.StartsWith("Int")))
                    {
                        retVal = Convert2Color(value.ToString());
                    }
                    else if (type.Name == "String[]" && typeof(T).Name.ToLower().StartsWith("list"))
                    {
                        List<string> l = ((string[])value).ToList();
                        retVal = (T)(object)l;
                    }
                    else if (type.Name == "String" && typeof(T).Name.ToLower().Equals("point"))
                    {
                        string s = Regex.Replace(value.ToString(), "[^0-9,]", "");
                        string[] pointSplit = s.Split(',');
                        List<int> pInt = new List<int>();
                        foreach (string newS in pointSplit)
                        {
                            if (int.TryParse(newS, out int p))
                                pInt.Add(p);
                        }
                        if (pInt.Count > 1)
                            retVal = new Point(pInt[0], pInt[1]);
                    }
                    else
                        retVal = (T)Convert.ChangeType(value, typeof(T));

                    if (retVal == null)
                        retVal = defaultValue;

                    if (typeof(T).Name == "String")
                        retVal = JsonClean((string)retVal, true);
                }
                else
                    retVal = defaultValue;
            }
            catch (Exception ex)
            {
                //store error
                LastError = ex;
                //set default for the type required.
                retVal = defaultValue;
            }

            return (T)retVal;
        }
        /// <summary>
        /// Save all data from DataSet "RecordData" to JSON
        /// </summary>
        /// <returns></returns>
        internal ResultStatus SaveData()
        {
            LocalSave = true;
            ResultStatus retVal = new ResultStatus();
            try
            {
                lock (DSetLock)
                {
                    if (RecordData == null)
                    {
                        retVal.Status = RESULT_STATUS.MISSING;
                        retVal.Description = "Record data needs to be loaded and have structure before it can be saved.";
                        return retVal;
                    }
                }

                UpdateSchemas();

                if (File.Exists(ConnectionString.UserName))
                    File.Delete(ConnectionString.UserName);

                lock (DSetLock)
                {
                    string json = JsonConvert.SerializeObject(RecordData, Formatting.Indented);
                    File.WriteAllText(ConnectionString.UserName, json);
                }

                if (!MonitorSet)
                    SetFileMonitor();
            }
            catch (Exception ex)
            {
                retVal.Status = RESULT_STATUS.EXCEPTION;
                retVal.Description = ex.Message;
                retVal.StackTrace = ex.StackTrace;
            }
            finally
            {
                LocalSave = false;
            }

            return retVal;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposedValue)
            {
                if (disposing)
                {
                    Watcher?.Dispose();
                    RecordData?.Dispose();
                }

                m_disposedValue = true;
            }
        }
        ~JSONHelper()
        {
            Dispose(disposing: false);
        }
        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
