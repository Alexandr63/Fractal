using System;
using System.Drawing;

namespace LSystem
{
    /// <summary>
    /// Хелпер для рисования L-системы.
    /// </summary>
    public static class DrawHelper
    {
        /// <summary>
        /// Расчет координат следующей точки.
        /// </summary>
        public static Point CalcNextPoint(Point currentPoint, int lineLength, double angle)
        {
            int x = Convert.ToInt32(Math.Round(currentPoint.X + lineLength * Math.Cos(DegreesToRadians(angle))));
            int y = Convert.ToInt32(Math.Round(currentPoint.Y + lineLength * Math.Sin(DegreesToRadians(angle))));

            return new Point(x, y);
        }

        /// <summary>
        /// Преобразования координат из градусов в радианы.
        /// </summary>
        public static double DegreesToRadians(double value)
        {
            return value * Math.PI / 180D;
        }
    }
}
