using SwitchWinClock.utils;
using System;
using System.Data;
using System.Drawing;
using System.Reflection;

namespace SwitchWinClock
{
    //[Editor("System.Drawing.Design.ContentAlignmentEditor, System.Drawing.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    public enum Clock_Style
    {
        Border = 0,
        Depth = 1
    }

    internal class SCConfig
    {
        const string SETTINGS_TABLE = "Settings";
        private readonly string[] RefreshDataErrors = new string[] { "does not belong", "column missing" };

        private static JSONData _jSON;
        private static DataTable _DataTable = new DataTable();
        private SLog Log = new SLog();
        private Clock_Style _ClockStyle = Clock_Style.Depth;
        private string _DateFormat = "dddd, MMM dd, hh:mm:ss tt";
        private Point _FormLocation = new Point(0, 0);
        private Font _Font = new Font("Arial", 72F, FontStyle.Bold);
        private int _TextBorderDepth = 5;
        private Color _ForeColor = Color.FromArgb(255, 0, 128, 128);
        private Color _BackColor = Color.Transparent;
        private Color _FormBorderColor = Color.Transparent;
        private Color _TextBorderColor = Color.Black;
        private ContentAlignment _TextAlignment = ContentAlignment.MiddleCenter;
        private ContentAlignment _WinAlignment = ContentAlignment.TopCenter;
        private bool _ManualWinAlignment = true;
        private int _DeviceNumber = 1;
        private bool _AlwaysOnTop = false;

        public SCConfig() 
        {
            _jSON = new JSONData(new System.Net.NetworkCredential("SWClock.config", ""));
            _DataTable = _jSON.GetTable($"{SETTINGS_TABLE}{Global.AppID}");

            if (_DataTable == null || _DataTable?.Rows.Count == 0)
                Update();   //will create table and add 1 record based on default.
            else if (_DataTable?.Rows.Count > 0)
                LoadData(); //load what exists in config.  First row only, just in case of error of more than one record.

            //startup log location.
            Log.WriteLine(SMsgType.Information, $"[ColNames.FormLocation] = {_FormLocation}");
        }

        ~SCConfig()
        {
            //shutdown log location.
            Log.WriteLine(SMsgType.Information, $"[ColNames.FormLocation] = {_FormLocation}");
        }

        public Clock_Style ClockStyle 
        { 
            get { return _ClockStyle; } 
            set { 
                _ClockStyle = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.ClockStyle] = {(int)_ClockStyle}");
                Update(); 
            }
        }
        public string DateFormat 
        { 
            get { return _DateFormat; }
            set
            {
                _DateFormat = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.DateFormat] = {_DateFormat}");
                Update();
            }
        }
        public Point FormLocation
        {
            get { return _FormLocation; }
            set
            {
                _FormLocation = value;
                //dont log location, because this will spam the log with cords.
                //It's locked on start and closing of this class.
                Update();
            }
        }
        public Font Font
        {
            get { return _Font; }
            set
            {
                _Font = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.Font] = {_Font}");
                Update();
            }
        }
        public int TextBorderDepth
        {
            get { return _TextBorderDepth; }
            set
            {
                _TextBorderDepth = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.TextBorderDepth] = {_TextBorderDepth}");
                Update();
            }
        }
        public Color ForeColor
        {
            get { return _ForeColor; }
            set
            {
                _ForeColor = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.ForeColor] = {_jSON.ColorToInt(_ForeColor)}");
                Update();
            }
        }
        public Color BackColor
        {
            get { return _BackColor; }
            set
            {
                _BackColor = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.BackColor] = {_jSON.ColorToInt(_BackColor)}");
                Update();
            }
        }
        public Color FormBorderColor
        {
            get { return _FormBorderColor; }
            set
            {
                _FormBorderColor = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.FormBorderColor] = {_jSON.ColorToInt(_FormBorderColor)}");
                Update();
            }
        }
        public Color TextBorderColor
        {
            get { return _TextBorderColor; }
            set
            {
                _TextBorderColor = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.TextBorderColor] = {_jSON.ColorToInt(_TextBorderColor)}");
                Update();
            }
        }
        public bool ManualWinAlignment
        {
            get { return _ManualWinAlignment; }
            set
            {
                _ManualWinAlignment = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.ManualWinAlignment] = {_ManualWinAlignment}");
                Update();
            }
        }
        public ContentAlignment WinAlignment
        {
            get { return _WinAlignment; }
            set
            {
                _WinAlignment = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.WinAlignment] = {_WinAlignment}");
                Update();
            }
        }
        public ContentAlignment TextAlignment
        {
            get { return _TextAlignment; }
            set
            {
                _TextAlignment = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.TextAlignment] = {_TextAlignment}");
                Update();
            }
        }
        public int DeviceNumber
        {
            get { return _DeviceNumber; }
            set
            {
                _DeviceNumber = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.DeviceNumber] = {_DeviceNumber}");
                Update();
            }
        }
        public bool AlwaysOnTop
        {
            get { return _AlwaysOnTop; }
            set
            {
                _AlwaysOnTop = value;
                Log.WriteLine(SMsgType.Information, $"[ColNames.AlwaysOnTop] = {_AlwaysOnTop}");
                Update();
            }
        }
        private void LoadData()
        {
            if(!ValidColums())
                CreateDataTable();

            foreach (DataRow dRow in _DataTable.Rows)
            {
                _ClockStyle = _jSON.GetColumn<Clock_Style>(dRow, ColNames.ClockStyle, _ClockStyle);
                _DateFormat = _jSON.GetColumn<string>(dRow, ColNames.DateFormat, _DateFormat);
                _FormLocation = _jSON.GetColumn<Point>(dRow, ColNames.FormLocation, _FormLocation);
                _Font = _jSON.GetColumn<Font>(dRow, ColNames.Font, _Font);
                _TextBorderDepth = _jSON.GetColumn<int>(dRow, ColNames.TextBorderDepth, _TextBorderDepth);
                _ForeColor = _jSON.GetColumn<Color>(dRow, ColNames.ForeColor, _ForeColor);
                _BackColor = _jSON.GetColumn<Color>(dRow, ColNames.BackColor, _BackColor);
                _FormBorderColor = _jSON.GetColumn<Color>(dRow, ColNames.FormBorderColor, _FormBorderColor);
                _TextBorderColor = _jSON.GetColumn<Color>(dRow, ColNames.TextBorderColor, _TextBorderColor);
                _TextAlignment = _jSON.GetColumn<ContentAlignment>(dRow, ColNames.TextAlignment, _TextAlignment);
                _ManualWinAlignment = _jSON.GetColumn<bool>(dRow, ColNames.ManualWinAlignment, _ManualWinAlignment);
                _WinAlignment = _jSON.GetColumn<ContentAlignment>(dRow, ColNames.WinAlignment, _WinAlignment);
                _DeviceNumber = _jSON.GetColumn<int>(dRow, ColNames.DeviceNumber, _DeviceNumber);
                _AlwaysOnTop = _jSON.GetColumn<bool>(dRow, ColNames.AlwaysOnTop, _AlwaysOnTop);
            }

            /*
            //TODO: Don't think this is required anymore as it's called on startup of the app because of forced click.
            //if something is missing a column or required data, lets add it
            //to the table, using existing data in memory/defaults.  
            if (IsResetDataMessage())
                Update();               
            else              
            */
            if (_jSON.LastError != null)
                throw new Exception(_jSON.LastError.Message);
        }
        private bool IsResetDataMessage()
        {
            bool retVal = false;
            string msg;

            if (_jSON.LastError == null)
                return retVal;
            else
                msg = _jSON.LastError.Message;

            foreach (string str in RefreshDataErrors)
            {
                if (msg.ToLower().Contains(str.ToLower()))
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }
        private void Update()
        {
            Log.WriteLine(SMsgType.Debug, "Update called...");
            DataRow dRow;

            if (_DataTable == null)
                CreateDataTable();

            //should never have more than one record.  If it does, delete
            //all data and create what exists in memory.
            if (_DataTable.Rows.Count > 1)
                _DataTable.Rows.Clear();

            //if a record exists, pull row
            if (_DataTable.Rows.Count == 1)
                dRow = _DataTable.Rows[0];
            else
                //create row since none exists.
                dRow = _DataTable.NewRow();

            dRow[ColNames.ClockStyle] = (int)_ClockStyle;
            dRow[ColNames.DateFormat] = _DateFormat;
            dRow[ColNames.FormLocation] = _FormLocation;
            dRow[ColNames.Font] = _Font;
            dRow[ColNames.TextBorderDepth] = _TextBorderDepth;
            dRow[ColNames.ForeColor] = _jSON.ColorToInt(_ForeColor);
            dRow[ColNames.BackColor] = _jSON.ColorToInt(_BackColor);
            dRow[ColNames.FormBorderColor] = _jSON.ColorToInt(_FormBorderColor);
            dRow[ColNames.TextBorderColor] = _jSON.ColorToInt(_TextBorderColor);
            dRow[ColNames.TextAlignment] = _TextAlignment;
            dRow[ColNames.ManualWinAlignment] = _ManualWinAlignment;
            dRow[ColNames.WinAlignment] = _WinAlignment;
            dRow[ColNames.DeviceNumber] = _DeviceNumber;
            dRow[ColNames.AlwaysOnTop] = _AlwaysOnTop;

            if (_DataTable.Rows.Count == 0)
                _DataTable.Rows.Add(dRow);  //add record to table.

            _jSON.UpdateTable(_DataTable);
            Log.WriteLine(SMsgType.Debug, "Update Complete...");
        }
        private void CreateDataTable()
        {
            Log.WriteLine(SMsgType.Information, $"Creating table: {SETTINGS_TABLE}{Global.AppID}...");
            if(_DataTable == null)
                _DataTable = new DataTable($"{SETTINGS_TABLE}{Global.AppID}");
            if(!_DataTable.Columns.Contains(ColNames.ClockStyle))
                _DataTable.Columns.Add(new DataColumn(ColNames.ClockStyle, typeof(Clock_Style)));
            if (!_DataTable.Columns.Contains(ColNames.DateFormat))
                _DataTable.Columns.Add(new DataColumn(ColNames.DateFormat, typeof(string)));
            if (!_DataTable.Columns.Contains(ColNames.FormLocation))
                _DataTable.Columns.Add(new DataColumn(ColNames.FormLocation, typeof(Point)));
            if (!_DataTable.Columns.Contains(ColNames.Font))
                _DataTable.Columns.Add(new DataColumn(ColNames.Font, typeof(Font)));
            if (!_DataTable.Columns.Contains(ColNames.TextBorderDepth))
                _DataTable.Columns.Add(new DataColumn(ColNames.TextBorderDepth, typeof(int)));
            if (!_DataTable.Columns.Contains(ColNames.ForeColor))
                _DataTable.Columns.Add(new DataColumn(ColNames.ForeColor, typeof(int)));
            if (!_DataTable.Columns.Contains(ColNames.BackColor))
                _DataTable.Columns.Add(new DataColumn(ColNames.BackColor, typeof(int)));
            if (!_DataTable.Columns.Contains(ColNames.FormBorderColor))
                _DataTable.Columns.Add(new DataColumn(ColNames.FormBorderColor, typeof(int)));
            if (!_DataTable.Columns.Contains(ColNames.TextBorderColor))
                _DataTable.Columns.Add(new DataColumn(ColNames.TextBorderColor, typeof(int)));
            if (!_DataTable.Columns.Contains(ColNames.TextAlignment))
                _DataTable.Columns.Add(new DataColumn(ColNames.TextAlignment, typeof(ContentAlignment)));
            if (!_DataTable.Columns.Contains(ColNames.ManualWinAlignment))
                _DataTable.Columns.Add(new DataColumn(ColNames.ManualWinAlignment, typeof(bool)));
            if (!_DataTable.Columns.Contains(ColNames.WinAlignment))
                _DataTable.Columns.Add(new DataColumn(ColNames.WinAlignment, typeof(ContentAlignment)));
            if (!_DataTable.Columns.Contains(ColNames.DeviceNumber))
                _DataTable.Columns.Add(new DataColumn(ColNames.DeviceNumber, typeof(int)));
            if (!_DataTable.Columns.Contains(ColNames.AlwaysOnTop))
                _DataTable.Columns.Add(new DataColumn(ColNames.AlwaysOnTop, typeof(bool)));
            Log.WriteLine(SMsgType.Information, $"Created table: {SETTINGS_TABLE}{Global.AppID}...");
        }
        private bool ValidColums()
        {
            bool retVal = true;

            foreach(FieldInfo field in ColNames.GetFields)
            {
                if (!_DataTable.Columns.Contains(field.Name))
                {
                    retVal = false;
                    break;
                }

            }

            return retVal;
        }
    }
}
