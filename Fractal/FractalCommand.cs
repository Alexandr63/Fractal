using System.Collections.Generic;
using System.Linq;

namespace Fractal
{
    /// <summary>
    /// Команда фрактала. Содержит команду и аргумент(ы) команды.
    /// Команда и аргумент(ы) должны быть разделены проблелом. Команда и аргумент(ы) не должны содержать пробелы. Аргументов может быть несоклько, так же аргумент может отсутствовать.
    /// Пример: FORWARD 1, ROTATE -45, SAVE, RESTORE, ROTATE_RANDOM 45 20 и т.д.
    /// </summary>
    public class FractalCommand
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public FractalCommand()
        {
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="command">Команда и аргумент.</param>
        public FractalCommand(string command)
        {
            string[] items = command.Trim().Split(' ');

            Command = items[0].Trim();

            if (items.Length > 1)
            {
                for (int i = 1; i < items.Length; i++)
                {
                    Arguments.Add(int.Parse(items[i].Trim()));
                }

                Argument = Arguments.First();
            }
        }

        /// <summary>
        /// Команда.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// Аргументы команды
        /// </summary>
        public List<int> Arguments { get; } = new List<int>();

        /// <summary>
        /// Первый аргумент команды (добавлен, так как чаше всего у команды 1 аргумент)
        /// </summary>
        public int Argument { get; }
    }
}
