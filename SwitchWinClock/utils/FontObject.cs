using System;
using System.Drawing;

namespace SwitchWinClock.utils
{
    internal class FontObject : IDisposable
    {
        private float currentScreenDPI = 0.0F;
        private float m_SizeInPoints = 0.0F;
        private float m_SizeInPixels = 0.0F;
        private bool disposedValue;

        public FontObject()
            : this(string.Empty, FontFamily.GenericSansSerif, FontStyle.Regular, 18F) { }
        public FontObject(string text, Font font)
            : this(text, font.FontFamily, font.Style, font.SizeInPoints) { }
        public FontObject(string text, FontFamily fontFamily, FontStyle fontStyle, float FontSize)
        {
            if (FontSize < 3) FontSize = 3;
            using (Graphics g = Graphics.FromHwndInternal(IntPtr.Zero))
            {
                currentScreenDPI = g.DpiY;
            }
            Text = text;
            FontFamily = fontFamily;
            //SizeInPoints = FontSize;
            SizeInPixels = FontSize;
            FillColor = Color.Black;
            Outline = new Pen(Color.Black, 1);
            Outlined = false;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                // if (disposing) {}
                disposedValue = true;
            }
        }

        ~FontObject()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public string Text { get; set; }
        public FontStyle FontStyle { get; set; }
        public FontFamily FontFamily { get; set; }
        public Color FillColor { get; set; }
        public Pen Outline { get; set; }
        public bool Outlined { get; set; }
        public float SizeInPoints
        {
            get => m_SizeInPoints;
            set
            {
                m_SizeInPoints = value;
                m_SizeInPixels = (value * 72F) / currentScreenDPI;
                SizeInEms = GetEmSize();
            }
        }
        public float SizeInPixels
        {
            get => m_SizeInPixels;
            set
            {
                m_SizeInPixels = value;
                m_SizeInPoints = (value / 72F) * currentScreenDPI;
                SizeInEms = GetEmSize();
            }
        }

        public float SizeInEms { get; private set; }
        public PointF Location { get; set; }
        public RectangleF DrawingBox { get; set; }

        private float GetEmSize()
        {
            return ((m_SizeInPoints *
                   (this.FontFamily.GetCellAscent(FontStyle) +
                    this.FontFamily.GetCellDescent(FontStyle))) /
                    this.FontFamily.GetEmHeight(FontStyle)); //added the 1.11F to match up with standard font size.
        }
    }
}
