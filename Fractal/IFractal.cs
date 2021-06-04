using System.Drawing;

namespace Fractal
{
    /// <summary>
    /// Интерфейс фрактала.
    /// </summary>
    public interface IFractal
    {
        /// <summary>
        /// Текущая строка фрактала.
        /// </summary>
        string ResultString { get; }

        /// <summary>
        /// Текущее поколение.
        /// </summary>
        int Generation { get; }

        /// <summary>
        /// Стартовая точка для рисования.
        /// </summary>
        Point StartPoint { get; set; }

        /// <summary>
        /// Длина линии при рисовании фрактала.
        /// </summary>
        int LineLength { get; set; }

        /// <summary>
        /// Толщина линии при рисовании фрактала.
        /// </summary>
        int LineWidth { get; set; }

        /// <summary>
        /// Цвет линии при рисовании фрактала.
        /// </summary>
        Color Color { get; set; }

        /// <summary>
        /// Сформировать следующее поколение фрактала.
        /// </summary>
        void NextGeneration();

        /// <summary>
        /// Нарисовать фрактал в заданный объект <see cref="Graphics"/>.
        /// </summary>
        void Draw(Graphics g);
    }
}
