using SwitchWinClock.utils;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;

namespace SwitchWinClock
{
    [Editor("System.Drawing.Design.ContentAlignmentEditor, System.Drawing.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    public enum Clock_Style
    {
        Border = 0,
        Depth = 1
    }

    internal class SCConfig
    {
        const string SETTINGS_TABLE = "Settings";
        private static JSONData _jSON;
        private static DataTable _DataTable = new DataTable();

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

        public SCConfig() 
        {
            _jSON = new JSONData(new System.Net.NetworkCredential("SWClock.config", ""));
            _DataTable = _jSON.GetTable($"{SETTINGS_TABLE}{Global.AppID}");

            if (_DataTable == null || _DataTable?.Rows.Count == 0)
                Update();   //will create table and add 1 record based on default.
            else if (_DataTable?.Rows.Count > 0)
                LoadData(); //load what exists in config.  First row only, just in case of error of more than one record.
        }

        public Clock_Style ClockStyle { get { return _ClockStyle; } set { _ClockStyle = value; Update(); } }
        public string DateFormat { get { return _DateFormat; } set { _DateFormat = value; Update(); } }
        public Point FormLocation { get { return _FormLocation; } set { _FormLocation = value; Update(); } }
        public Font Font { get { return _Font; } set { _Font = value; Update(); } }
        public int TextBorderDepth { get { return _TextBorderDepth; } set { _TextBorderDepth = value; Update(); } }
        public Color ForeColor { get { return _ForeColor; } set { _ForeColor = value; Update(); } }
        public Color BackColor { get { return _BackColor; } set { _BackColor = value; Update(); } }
        public Color FormBorderColor { get { return _FormBorderColor; } set { _FormBorderColor = value; Update(); } }
        public Color TextBorderColor { get { return _TextBorderColor; } set { _TextBorderColor = value; Update(); } }
        public ContentAlignment TextAlignment { get { return _TextAlignment; } set { TextAlignment = value; Update(); } }
        private void LoadData()
        {
            foreach(DataRow dRow in _DataTable.Rows)
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
            }

            //if missing a new column, lets create new table, using existing memory data.
            if (_jSON.LastError != null && _jSON.LastError.Message.IndexOf("does not belong", StringComparison.OrdinalIgnoreCase) > -1)
            {
                _DataTable.Clear();
                _DataTable = null;
                Update();
            }
            else if (_jSON.LastError != null)
                throw new Exception(_jSON.LastError.Message);
        }
        private void Update()
        {
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

            if (_DataTable.Rows.Count == 0)
                _DataTable.Rows.Add(dRow);  //add record to table.

            _jSON.UpdateTable(_DataTable);
        }
        private void CreateDataTable()
        {
            _DataTable = new DataTable($"{SETTINGS_TABLE}{Global.AppID}");
            _DataTable.Columns.Add(new DataColumn(ColNames.ClockStyle, typeof(Clock_Style)));
            _DataTable.Columns.Add(new DataColumn(ColNames.DateFormat, typeof(string)));
            _DataTable.Columns.Add(new DataColumn(ColNames.FormLocation, typeof(Point)));
            _DataTable.Columns.Add(new DataColumn(ColNames.Font, typeof(Font)));
            _DataTable.Columns.Add(new DataColumn(ColNames.TextBorderDepth, typeof(int)));
            _DataTable.Columns.Add(new DataColumn(ColNames.ForeColor, typeof(int)));
            _DataTable.Columns.Add(new DataColumn(ColNames.BackColor, typeof(int)));
            _DataTable.Columns.Add(new DataColumn(ColNames.FormBorderColor, typeof(int)));
            _DataTable.Columns.Add(new DataColumn(ColNames.TextBorderColor, typeof(int)));
            _DataTable.Columns.Add(new DataColumn(ColNames.TextAlignment, typeof(ContentAlignment)));
        }
    }
}
