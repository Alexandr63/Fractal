using System;
using System.Collections.Generic;
using System.Linq;

namespace LSystem
{
    /// <summary>
    /// Интерпритация для заданного литерала в L-системе.
    /// </summary>
    public class LSystemInterpretation
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public LSystemInterpretation()
        {
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public LSystemInterpretation(string interpretations)
        {
            string[] items = interpretations.Split(new[] { "->" }, StringSplitOptions.None);
            Literal = items[0].Trim().First();

            foreach (string command in items[1].Trim().Split(','))
            {
                Commands.Add(new LSystemCommand(command));
            }
        }

        /// <summary>
        /// Литерал, для которого заданы команды.
        /// </summary>
        public char Literal { get; set; }

        /// <summary>
        /// Команды, которые будут выполнены для заданного литерала.
        /// </summary>
        public List<LSystemCommand> Commands { get; } = new List<LSystemCommand>();
    }
}
