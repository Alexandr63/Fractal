using System.Drawing;

namespace LSystem
{
    /// <summary>
    /// Состояние L-системы. Исползуется для созранения/загрузки состояния по литералам '[' и ']'.
    /// </summary>
    public class State
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public State()
        {
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public State(Point point, int angle, Color color, int lineLength, int lineWidth)
        {
            Point = point;
            Angle = angle;
            Color = color;
            LineLength = lineLength;
            LineWidth = lineWidth;
        }

        /// <summary>
        /// Угол поворота.
        /// </summary>
        public int Angle { get; set; }

        /// <summary>
        /// Точка для рисования.
        /// </summary>
        public Point Point { get; set; }

        /// <summary>
        /// Цвет линии.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Длина линии.
        /// </summary>
        public int LineLength { get; set; }

        /// <summary>
        /// Толщина линии.
        /// </summary>
        public int LineWidth { get; set; }
    }
}
