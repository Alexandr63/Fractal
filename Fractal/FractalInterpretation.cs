using System;
using System.Collections.Generic;
using System.Linq;

namespace Fractal
{
    /// <summary>
    /// Интерпритация для заданного литерала в фрактале.
    /// </summary>
    public class FractalInterpretation
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public FractalInterpretation()
        {
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public FractalInterpretation(string interpretations)
        {
            string[] items = interpretations.Split(new[] { "->" }, StringSplitOptions.None);
            Literal = items[0].First();

            foreach (string command in items[1].Split(';'))
            {
                Commands.Add(new FractalCommand(command));
            }
        }

        /// <summary>
        /// Литерал, для которого заданы команды.
        /// </summary>
        public char Literal { get; set; }

        /// <summary>
        /// Команды, которые будут выполнены для заданного литерала.
        /// </summary>
        public List<FractalCommand> Commands { get; } = new List<FractalCommand>();
    }
}
