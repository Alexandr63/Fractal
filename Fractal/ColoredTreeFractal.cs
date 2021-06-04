using System.Collections.Generic;
using System.Drawing;

namespace Fractal
{
    /// <summary>
    /// Реализация фрактала с раширинными возможностями и кастомной командой CHANGE_TREE. Для отрисовки дерева и более тонкими и короткими ветками на конце и изименением цвета.
    /// </summary>
    public class ColoredTreeFractal : FractalExt
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="axiom">Аксиома.</param>
        /// <param name="rules">Правила.</param>
        /// <param name="interpretations">Интерпритации литералов</param>
        public ColoredTreeFractal(string axiom, IEnumerable<string> rules, IEnumerable<string> interpretations) : base(axiom, rules, interpretations)
        {
            Color = Color.Black;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="axiom">Аксиома.</param>
        /// <param name="rule">Правило.</param>
        /// <param name="interpretations">Интерпритации литералов</param>
        public ColoredTreeFractal(string axiom, string rule, IEnumerable<string> interpretations) : base(axiom, rule, interpretations)
        {
            Color = Color.Black;
        }

        /// <summary>
        /// Выполнение кастомной команды
        /// </summary>
        /// <param name="g">Объект <see cref="Graphics"/>, в который будет выполняться отрисовка.</param>
        /// <param name="literal">Текущий литерал.</param>
        /// <param name="command">Текущая команда.</param>
        protected override void ExecuteCustomCommand(Graphics g, char literal, FractalCommand command)
        {
            if (command.Command == "CHANGE_TREE")
            {
                // Уменшаем длину отрезка для отрисовки
                if (LineLength > 1)
                {
                    LineLength = LineLength - 3;
                }

                // Уменшаем толщину отрезка для отрисовки
                if (LineWidth > 1)
                {
                    LineWidth = LineWidth - 1;
                }

                // Делаем цвет отисовки более ярким
                int c = Color.R + 25;
                if (c > 255)
                {
                    c = 255;
                }
                Color = Color.FromArgb(Color.A, c, c, c);
            }
        }
    }
}
