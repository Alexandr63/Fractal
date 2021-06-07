using System.Drawing;

namespace LSystem
{
    /// <summary>
    /// Интерфейс L-системы.
    /// </summary>
    public interface ILSystem
    {
        /// <summary>
        /// Текущая строка L-системы.
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
        /// Длина линии при рисовании L-системы.
        /// </summary>
        int LineLength { get; set; }

        /// <summary>
        /// Толщина линии при рисовании L-системы.
        /// </summary>
        int LineWidth { get; set; }

        /// <summary>
        /// Цвет линии при рисовании L-системы.
        /// </summary>
        Color Color { get; set; }

        /// <summary>
        /// Сформировать следующее поколение L-системы.
        /// </summary>
        void NextGeneration();

        /// <summary>
        /// Нарисовать L-систему в заданный объект <see cref="Graphics"/>.
        /// </summary>
        void Draw(Graphics g);

        /// <summary>
        /// Сбросить состояние L-системы в 0 поколение
        /// </summary>
        void Reset();
    }
}
