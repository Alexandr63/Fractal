using System;
using System.Linq;

namespace LSystem
{
    /// <summary>
    /// Правило L-системы
    /// </summary>
    public class LSystemRule
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public LSystemRule()
        {
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public LSystemRule(string rule)
        {
            string[] items = rule.Split(new [] { "->" }, StringSplitOptions.None);
            Literal = items[0].Trim().First();
            Rule = items[1].Trim();
        }

        /// <summary>
        /// Литерал, для которого описано правило.
        /// </summary>
        public char Literal { get; set; }

        /// <summary>
        /// Правило
        /// </summary>
        public string Rule { get; set; }
    }
}
