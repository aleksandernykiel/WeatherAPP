using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPP
{
    static class Tools
    {
        public static readonly FontFamily family = new FontFamily("Arial");
        public static readonly SolidBrush brush = new SolidBrush(Color.Black);

        public static void DrawString(this Graphics g, string str, float size, float x, float y)
        {
            g.DrawString(str, new Font(family, size), brush, x, y);
        }
    }
}
