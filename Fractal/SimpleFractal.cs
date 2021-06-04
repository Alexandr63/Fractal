using System.Drawing;

namespace Fractal
{
    /// <summary>
    /// Реализация для простых фракталов с одной аксивомой, одним правилом и углом поворота.
    /// Фрактал может принимать команды для рисования линии и поворота на заданный угол по/против часовой стрелки.
    /// Переменная для рисования - 'F'. Команда поворота по часовой стрелке - '+'. Команда поворота против часовой стрелки - '-'.
    /// Пирмер.
    /// Аксиома: F+F+F+F
    /// Правило: FF+F+F+F+FF
    /// Угол: 90
    /// </summary>
    public class SimpleFractal : IFractal
    {
        #region Ctor.

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="axiom">Аксиома.</param>
        /// <param name="rule">Правило.</param>
        /// <param name="angle">Угол поворота в градусах.</param>
        public SimpleFractal(string axiom, string rule, int angle)
        {
            Axiom = axiom;
            Rule = rule;
            Angle = angle;
            ResultString = Axiom;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Аксиома.
        /// </summary>
        public string Axiom { get; }

        /// <summary>
        /// Правило.
        /// </summary>
        public string Rule { get; }

        /// <summary>
        /// Угол поворота в градусах.
        /// </summary>
        public int Angle { get; }

        /// <summary>
        /// Текущее поколение.
        /// </summary>
        public int Generation { get; private set; }

        /// <summary>
        /// Текущая строка фрактала.
        /// </summary>
        public string ResultString { get; private set; }

        /// <summary>
        /// Стартовая точка для рисования.
        /// </summary>
        public Point StartPoint { get; set; } = new Point(700, 300);

        /// <summary>
        /// Длина линии при рисовании фрактала.
        /// </summary>
        public int LineLength { get; set; } = 5;

        /// <summary>
        /// Толщина линии при рисовании фрактала.
        /// </summary>
        public int LineWidth { get; set; } = 1;

        /// <summary>
        /// Цвет линии при рисовании фрактала.
        /// </summary>
        public Color Color { get; set; } = Color.Blue;

        #endregion

        #region Public Methods

        /// <summary>
        /// Сформировать следующее поколение фрактала.
        /// </summary>
        public void NextGeneration()
        {
            string result = string.Empty;

            foreach (char c in ResultString)
            {
                if (c == 'F')
                {
                    result += Rule;
                }
                else
                {
                    result += c;
                }
            }

            Generation++;

            ResultString = result;

            System.Diagnostics.Debug.WriteLine(ResultString);
        }

        /// <summary>
        /// Нарисовать фрактал в заданный объект <see cref="Graphics"/>.
        /// </summary>
        public void Draw(Graphics g)
        {
            Point currentPoint = StartPoint;
            int currentAngle = 0;

            foreach (char c in ResultString)
            {
                switch (c)
                {
                    // Рисуем линию
                    case 'F':
                        Point nextPoint = DrawHelper.CalcNextPoint(currentPoint, LineLength, currentAngle);
                        g.DrawLine(new Pen(Color, LineWidth), currentPoint, nextPoint);
                        currentPoint = nextPoint;
                        break;
                    // Поворот по часовой стрелке
                    case '+':
                        currentAngle += Angle;
                        break;
                    // Поворот против часовой стрелки
                    case '-':
                        currentAngle -= Angle;
                        break;
                }
            }
        }

        #endregion
    }
}
