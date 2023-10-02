using SwitchWinClock.utils;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SwitchWinClock
{
    public partial class DisplayForm : Form
    {
        delegate void VoidDelegate();
        private readonly Font ButtonFont = new Font("Arial Black", 10F, FontStyle.Regular, GraphicsUnit.Pixel);

        private FontObject fontObject;
        private SCConfig config = new SCConfig();
        private static bool closingForm = false;
        private static DateTime mouseMoved = DateTime.MinValue;
        private int waitTimer = 60000;  //default: 1 min

        public DisplayForm()
        {
            InitializeComponent();

            this.SetupMenuChecks();
            this.SetCheckTextDepth(config.TextBorderDepth);
            this.SetDateFormatMenus();
            this.SetFormLocation();
        }
        private StringFormat GetTextAlignment()
        {
            StringFormat stringFormat;

            switch (config.TextAlignment)
            {
                case ContentAlignment.TopCenter:
                    stringFormat = new StringFormat()
                    {
                        LineAlignment = StringAlignment.Near,
                        Alignment = StringAlignment.Center
                    };
                    break;
                case ContentAlignment.BottomCenter:
                    stringFormat = new StringFormat()
                    {
                        LineAlignment = StringAlignment.Far,
                        Alignment = StringAlignment.Center
                    };
                    break;
                case ContentAlignment.TopLeft:
                    stringFormat = new StringFormat()
                    {
                        LineAlignment = StringAlignment.Near,
                        Alignment = StringAlignment.Near
                    };
                    break;
                case ContentAlignment.BottomLeft:
                    stringFormat = new StringFormat()
                    {
                        LineAlignment = StringAlignment.Far,
                        Alignment = StringAlignment.Near
                    };
                    break;
                case ContentAlignment.TopRight:
                    stringFormat = new StringFormat()
                    {
                        LineAlignment = StringAlignment.Near,
                        Alignment = StringAlignment.Far
                    };
                    break;
                case ContentAlignment.BottomRight:
                    stringFormat = new StringFormat()
                    {
                        LineAlignment = StringAlignment.Far,
                        Alignment = StringAlignment.Far
                    };
                    break;
                default:
                    stringFormat = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    break;
            }

            return stringFormat;
        }
        private void DrawForm(Graphics g, Size sz)
        {
            Rectangle rect = new Rectangle() { X = 0, Y = 0, Width = sz.Width, Height = sz.Height };

            if (config.BackColor.A != 0)
                g.FillRectangle(new SolidBrush(config.BackColor), rect);
            if (config.FormBorderColor.A != 0)
                g.DrawRectangle(new Pen(config.FormBorderColor, 2), rect);
        }
        private void DrawCloseButton(Graphics g, StringFormat sFormat)
        {
            int buttonSize = 15;
            Rectangle rect = new Rectangle() { Height = buttonSize, Width = buttonSize, X = this.ClientSize.Width - (buttonSize + 5), Y = 5 };

            g.FillRectangle(Brushes.Red, rect);
            g.DrawString("X", ButtonFont, Brushes.White, rect, sFormat);
            g.DrawRectangle(new Pen(Brushes.Gray, 2), rect);
        }
        private void SetFormLocation()
        {
            if (config.FormLocation.X == 0)
                this.Left = (Screen.GetWorkingArea(this).Width / 2) - (this.Width / 2);     //center screen
            else
                this.Left = config.FormLocation.X;

            if (config.FormLocation.Y == 0)
                this.Top = (Screen.GetWorkingArea(this).Height / 2) - (this.Height / 2);    //center screen
            else
                this.Top = config.FormLocation.Y;
        }
        private void RefreshForm()
        {
            if (InvokeRequired)
            {
                var d = new VoidDelegate(RefreshForm);
                if (!Disposing && !IsDisposed)
                {
                    try { Invoke(d); }
                    catch (ObjectDisposedException ex) { Debug.WriteLine(ex.Message); }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, $"Exception Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (!Disposing && !IsDisposed)
            {
                if (closingForm)
                    return;

                this.SetFormLocation();
                this.Invalidate();
            }
        }
        private void StartCounter()
        {
            int iEvent = EventTypes.EVENT_TIMEOUT;

            SetWaitTimer();

            while (iEvent != EventTypes.EVENT_SHUTDOWN && !closingForm)
            {
                RefreshForm();
                iEvent = WaitHandle.WaitAny(SWCEvents, waitTimer);
            }
        }
        private void SetWaitTimer()
        {
            if (SWCEvents == null)
                return;

            DateTime now = DateTime.Now;
            DateTime futureDate = now;  //default is identical

            if (config.DateFormat?.IndexOf("fff") > -1)
                waitTimer = 1;
            else if (config.DateFormat?.IndexOf("ff") > -1)
                waitTimer = 10;
            else if (config.DateFormat?.IndexOf("f") > -1)
                waitTimer = 100;
            else //if (config.DateFormat?.IndexOf("ss") > -1)
            {
                waitTimer = 1000;
                RefreshForm();

                futureDate = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second + 1);   //strips milliseconds
            }
            
            TimeSpan diff = futureDate.Subtract(now);
            //wait to set on exact millisecond
            WaitHandle.WaitAny(SWCEvents, diff);
            //make sure, what ever might be on hold, resets based on new waitTimer
            SWCEvents[EventTypes.EVENT_MANUAL].Set();
        }
        private void SetupMenuChecks()
        {
            if (config.ClockStyle == Clock_Style.Depth)
                StyleDeptMenuItem_Click(null, null);
            else
                StyleBorderMenuItem_Click(null, null);

            if (config.BackColor.A == 0)
                BackColorTransparentMenuItem.Checked = true;
            else
                BackColorTransparentMenuItem.Checked = false;

            if (config.FormBorderColor.A == 0)
                BorderColorTransparentMenuItem.Checked = true;
            else
                BorderColorTransparentMenuItem.Checked = false;

            if (config.ForeColor.A == 0)
                ForeColorTransparentMenuItem.Checked = true;
            else
                ForeColorTransparentMenuItem.Checked = false;

            if (config.TextBorderColor.A == 0)
                TextBorderTransparentMenuItem.Checked = true;
            else
                TextBorderTransparentMenuItem.Checked = false;
        }
        private void SetDateFormatMenus(ToolStripMenuItem menuItem = null)
        {
            if (menuItem == null)
            {
                bool found = false;
                string format = config.DateFormat;

                foreach (ToolStripMenuItem tsi in DateFormattingMenuItem.DropDownItems)
                {
                    if (format == tsi.Text)
                    {
                        tsi.Checked = true;
                        found = true;                        
                    }
                    else
                        tsi.Checked = false;
                }

                if(!found)
                    CustomDateTextBox.Text = format;
            }
            else
            {
                foreach (ToolStripMenuItem tsi in DateFormattingMenuItem.DropDownItems)
                {
                    if (menuItem.Text == tsi.Text)
                        tsi.Checked = true;
                    else
                        tsi.Checked = false;
                }
                config.DateFormat = menuItem.Text;
            }

            SetWaitTimer();
        }

        private AutoResetEvent[] SWCEvents { get; set; } = null;                               //could be shut down event or new message event
        private bool Drag { get; set; }
        private Point StartPoint { get; set; } = Point.Empty;
        private void Menu_MouseLeave(object sender, EventArgs e)
        {
            //SettingsContextMenu.Hide();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            SWCEvents = new AutoResetEvent[]
            {
                new AutoResetEvent(false),  //EVENT_SHUTDOWN
                new AutoResetEvent(false),  //EVENT_MANUAL
            };

            Thread thread = new Thread(() => { StartCounter(); });
            thread.Start();
        }
        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int addSize;

            Color fColor = config.ForeColor;
            int depth = config.TextBorderDepth;
            int dblPad = (depth * 2);

            string dt = DateTime.Now.ToString(config.DateFormat);
            Font ft = config.Font;
            switch (ft.Unit)
            {
                case GraphicsUnit.Point:
                    addSize = 15;
                    break;
                case GraphicsUnit.Millimeter:
                    addSize = 20;
                    break;
                case GraphicsUnit.Display:
                case GraphicsUnit.Document:
                    addSize = 15;
                    break;
                default:
                    addSize = 0;
                    break;
            }

            SizeF textSize = e.Graphics.MeasureString(dt, ft);
            Size sz = new Size(this.ClientSize.Width - dblPad, this.ClientSize.Height - dblPad);

            int newHeight = (sz.Height + dblPad);
            int newWidth = (sz.Width + dblPad);

            int sugWidth = (int)Math.Round(textSize.Width) + addSize + dblPad;
            int sugHeight = (int)Math.Round(textSize.Height) + addSize + dblPad;

            if (sugHeight > newHeight)
                newHeight = sugHeight;

            if (sugWidth > newHeight)
                newWidth = sugWidth;

            if (newHeight != sz.Height || newWidth != sz.Width)
            {
                this.ClientSize = new Size(newWidth, newHeight);
                sz = new Size(this.ClientSize.Width - dblPad, this.ClientSize.Height - dblPad);
            }

            StringFormat sFormat = GetTextAlignment();

            int bColor = 125;
            int tColor = bColor < 128 ? bColor + 128 : 128 - bColor;

            //float scale = Math.Min((sz.Width / textSize.Width), sz.Height / textSize.Height);
            //e.Graphics.ScaleTransform(scale, scale);

            DrawForm(g, this.ClientSize);

            if (config.ClockStyle == Clock_Style.Border)
            {
                fontObject = new FontObject(dt, ft);
                fontObject.Outlined = true;
                fontObject.Outline = new Pen(config.TextBorderColor, depth);
                fontObject.FillColor = config.ForeColor;

                CanvasPaint(e);
            }
            else
            {
                for (int i = 1; i <= depth; i++)
                {
                    g.DrawString(dt, ft, new SolidBrush(Color.FromArgb(255, bColor, bColor, bColor)), new Rectangle(depth + i, depth, sz.Width, sz.Height), sFormat);
                    g.DrawString(dt, ft, new SolidBrush(Color.FromArgb(255, bColor, bColor, bColor)), new Rectangle(depth, depth + i, sz.Width, sz.Height), sFormat);
                    g.DrawString(dt, ft, new SolidBrush(Color.FromArgb(255, tColor, tColor, tColor)), new Rectangle(depth - i, depth, sz.Width, sz.Height), sFormat);
                    g.DrawString(dt, ft, new SolidBrush(Color.FromArgb(255, tColor, tColor, tColor)), new Rectangle(depth, depth - i, sz.Width, sz.Height), sFormat);
                }

                g.DrawString(dt, ft, new SolidBrush(fColor), new Rectangle(depth, depth, sz.Width, sz.Height), sFormat);
            }

            if (mouseMoved > DateTime.Now)
                DrawCloseButton(g, sFormat);

        }
        private void CanvasPaint(PaintEventArgs e)
        {
            using (var path = new GraphicsPath())
            using (var format = new StringFormat())
            {
                format.Alignment = StringAlignment.Center; //As selected
                format.LineAlignment = StringAlignment.Center; //As selected

                //float f = e.Graphics.DpiY * fontObject.SizeInPixels / 72f;
                //fontObject.SizeInEms
                path.AddString(fontObject.Text, fontObject.FontFamily, (int)fontObject.FontStyle, fontObject.SizeInPoints, this.ClientRectangle, format);

                //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;   //commented, or it shows the pink form background around the border.
                // When text is rendered directly
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                // The composition properties are useful when drawing on a composited surface
                // It has no effect when drawing on a Control's plain surface
                e.Graphics.CompositingMode = CompositingMode.SourceOver;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

                if (fontObject.Outlined)
                    e.Graphics.DrawPath(fontObject.Outline, path);

                using (var brush = new SolidBrush(fontObject.FillColor))
                    e.Graphics.FillPath(brush, path);
            }

            fontObject.Dispose();
        }
        public void NextSubpathExample2(PaintEventArgs e)
        {

            // Create a graphics path.
            GraphicsPath myPath = new GraphicsPath();

            // Set up primitives to add to myPath.
            Point[] myPoints = {new Point(20, 20), new Point(120, 120), new Point(20, 120),new Point(20, 20) };
            Rectangle myRect = new Rectangle(120, 120, 100, 100);

            // Add 3 lines, a rectangle, an ellipse, and 2 markers.
            myPath.AddLines(myPoints);
            myPath.SetMarkers();
            myPath.AddRectangle(myRect);
            myPath.SetMarkers();
            myPath.AddEllipse(220, 220, 100, 100);

            // Get the total number of points for the path,

            // and the arrays of the points and types.
            int myPathPointCount = myPath.PointCount;
            PointF[] myPathPoints = myPath.PathPoints;
            byte[] myPathTypes = myPath.PathTypes;

            // Set up variables for listing all of the path's

            // points to the screen.
            int i;
            float j = 20;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);

            // List the values of all the path points and types to the screen.
            for (i = 0; i < myPathPointCount; i++)
            {
                e.Graphics.DrawString(myPathPoints[i].X.ToString() +
                    ", " + myPathPoints[i].Y.ToString() + ", " +
                    myPathTypes[i].ToString(),
                    myFont,
                    myBrush,
                    20,
                    j);
                j += 20;
            }

            // Create a GraphicsPathIterator for myPath.
            GraphicsPathIterator myPathIterator = new
                GraphicsPathIterator(myPath);

            // Rewind the iterator.
            myPathIterator.Rewind();

            // Create the GraphicsPath section.
            GraphicsPath myPathSection = new GraphicsPath();

            // Iterate to the 3rd subpath and list the number of points therein

            // to the screen.
            int subpathPoints;
            bool IsClosed2;

            // Iterate to the third subpath.
            subpathPoints = myPathIterator.NextSubpath(
                myPathSection, out IsClosed2);
            subpathPoints = myPathIterator.NextSubpath(
                myPathSection, out IsClosed2);
            subpathPoints = myPathIterator.NextSubpath(
                myPathSection, out IsClosed2);

            // Write the number of subpath points to the screen.
            e.Graphics.DrawString("Subpath: 3" +
                "   Num Points: " +
                subpathPoints.ToString(),
                myFont,
                myBrush,
                200,
                20);
        }
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Drag)
            {
                // if we should be dragging it, we need to figure out some movement
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.StartPoint.X,
                                     p2.Y - this.StartPoint.Y);
                
                config.FormLocation = p3;
                this.Location = p3;
            }
            else
            {
                mouseMoved = DateTime.Now.AddSeconds(5);
                if (e.X > this.Width - 25 && e.Y < 25)
                    Cursor = Cursors.Hand;
                else
                    Cursor = Cursors.Default;
            }
        }
        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (e.X > this.Width - 25 && e.Y < 25)
                {
                    this.Close();
                }
            }
            else
            {
                Point pt = new Point(e.X + this.Left, e.Y + this.Top);
                SettingsContextMenu.Show(pt);
            }
        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            this.StartPoint = e.Location;
            this.Drag = true;
        }
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            Drag = false;
        }
        private void Form_Closing(object sender, EventArgs e)
        {
            closingForm = true;
            SWCEvents[EventTypes.EVENT_SHUTDOWN].Set();
        }
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FontSetupMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.ShowApply = true;
                fontDialog.Apply += FontApply;
                fontDialog.Font = config.Font;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    FontApply(fontDialog, e);
                    //this.Size = new Size(10, 10);
                    //config.Font = fontDialog.Font;
                }
            }
        }
        private void FontApply(object sender, EventArgs e)
        {
            var fd = sender as FontDialog;
            config.Font = fd.Font;
        }
        private void TextDepthp_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = ((ToolStripMenuItem)sender);
            SetCheckTextDepth(menuItem);

            string name = Regex.Replace(menuItem.Name, "[^0-9]", "");
            if (int.TryParse(name, out int iVal))
                config.TextBorderDepth = iVal;
        }
        private void ColorTransparentMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = ((ToolStripMenuItem)sender);
            int isTransparent = menuItem.Checked ? 0 : 255;

            switch(menuItem.Name)
            {
                case "BackColorTransparentMenuItem":
                    config.BackColor = Color.FromArgb(isTransparent, config.BackColor.R, config.BackColor.G, config.BackColor.B);
                    break;
                case "BorderColorTransparentMenuItem":
                    config.FormBorderColor = Color.FromArgb(isTransparent, config.FormBorderColor.R, config.FormBorderColor.G, config.FormBorderColor.B);
                    break;
                case "ForeColorTransparentMenuItem":
                    config.ForeColor = Color.FromArgb(isTransparent, config.ForeColor.R, config.ForeColor.G, config.ForeColor.B);
                    break;
                case "TextBorderTransparentMenuItem":
                    config.TextBorderColor = Color.FromArgb(isTransparent, config.TextBorderColor.R, config.TextBorderColor.G, config.TextBorderColor.B);
                    break;
            }
        }
        private void SetCheckTextDepth(ToolStripMenuItem menuItem)
        {
            foreach (ToolStripMenuItem tsi in TextDepthpMenuItem.DropDownItems)
            {
                if (menuItem.Name == tsi.Name)
                    tsi.Checked = true;
                else
                    tsi.Checked = false;
            }
        }
        private void SetCheckTextDepth(int menuItem)
        {
            foreach (ToolStripMenuItem tsi in TextDepthpMenuItem.DropDownItems)
            {
                string name = Regex.Replace(tsi.Name, "[^0-9]", "");
                if (int.TryParse(name, out int iVal) && iVal == menuItem)
                {
                    tsi.Checked = true;
                    break;
                }
            }
        }
        private void BackColorSetMenuItem_Click(object sender, EventArgs e)
        {
            Color defColor = config.BackColor;
            using (ColorDialog cd = new ColorDialog())
            {
                cd.FullOpen = true;
                cd.Color = config.BackColor;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    config.BackColor = cd.Color;
                    BackColorTransparentMenuItem.Checked = false;
                }
                else
                    config.BackColor = defColor;
            }
        }
        private bool PickColor(Color color, out Color retColor)
        {
            bool retVal = false;
            retColor = color;
            using (ColorDialog cd = new ColorDialog())
            {
                cd.FullOpen = true;
                cd.Color = color;
                if (cd.ShowDialog(this) == DialogResult.OK)
                {
                    retColor = cd.Color;
                    retVal = true;
                }
            }

            return retVal;
        }
        private void BorderColorSetMenuItem_Click(object sender, EventArgs e)
        {
            if(PickColor(config.FormBorderColor, out Color selColor))
            {
                config.FormBorderColor = selColor;
                BorderColorTransparentMenuItem.Checked = false;
            }
        }
        private void CustomDateTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                config.DateFormat = CustomDateTextBox.Text.Trim();
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
                SetDateFormatMenus();
        }
        private void DateFormatItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = ((ToolStripMenuItem)sender);
            menuItem.Checked = !menuItem.Checked;
            SetDateFormatMenus(menuItem);
        }
        private void ForeColorSetMenuItem_Click(object sender, EventArgs e)
        {
            if (PickColor(config.ForeColor, out Color selColor))
            {
                config.ForeColor = selColor;
                ForeColorTransparentMenuItem.Checked = false;
            }
        }
        private void StyleDeptMenuItem_Click(object sender, EventArgs e)
        {
            this.TextDepthpMenuItem.Text = "&Text Depth";
            config.ClockStyle = Clock_Style.Depth;
            StyleBorderMenuItem.Checked = false;
            TextBorderColorMenuItem.Visible = false;
        }
        private void StyleBorderMenuItem_Click(object sender, EventArgs e)
        {
            this.TextDepthpMenuItem.Text = "&Text Border";
            config.ClockStyle = Clock_Style.Border;
            StyleDeptMenuItem.Checked = false;
            TextBorderColorMenuItem.Visible = true;
        }
        private void TextBorderSetColorMenuItem_Click(object sender, EventArgs e)
        {
            if (PickColor(config.TextBorderColor, out Color selColor))
            {
                config.TextBorderColor = selColor;
                TextBorderTransparentMenuItem.Checked = false;
            }
        }
        private void NewInstanceMenuItem_Click(object sender, EventArgs e)
        {
            Global.RunApp(file: About.AppPath, args: "1");
        }
    }
}