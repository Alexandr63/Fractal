using System;
using System.Linq;

namespace Fractal
{
    /// <summary>
    /// Правило фрактала
    /// </summary>
    public class FractalRule
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public FractalRule()
        {
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        public FractalRule(string rule)
        {
            string[] items = rule.Split(new [] { "->" }, StringSplitOptions.None);
            Literal = items[0].First();
            Rule = items[1];
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
