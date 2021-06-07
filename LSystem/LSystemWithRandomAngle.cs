using System;
using System.Collections.Generic;

namespace LSystem
{
    /// <summary>
    /// Расширение класса <see cref="LSystem"/> со случайным значением угла в пределах заданного диапазона. 
    /// </summary>
    public class LSystemWithRandomAngle : LSystem
    {
        private readonly Random _random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Ctor.
        /// Все литералы, указанные в правилах будут отрисовываться.
        /// </summary>
        /// <param name="axiom">Аксиома.</param>
        /// <param name="rule">Правило.</param>
        /// <param name="angle">Угол поворота в градусах.</param>
        /// <param name="angleDeviation">Максимальное отклонение значения угла поворота в градусах относительно заданного значения <param name="angle"></param></param>
        public LSystemWithRandomAngle(string axiom, string rule, int angle, int angleDeviation) : base(axiom, rule, angle)
        {
            AngleDeviation = angleDeviation;
        }

        /// <summary>
        /// Ctor.
        /// Все литералы, указанные в правилах будут отрисовываться.
        /// </summary>
        /// <param name="axiom">Аксиома.</param>
        /// <param name="rules">Правила.</param>
        /// <param name="angle">Угол поворота в градусах.</param>
        /// <param name="angleDeviation">Максимальное отклонение значения угла поворота в градусах относительно заданного значения <param name="angle"></param></param>
        public LSystemWithRandomAngle(string axiom, IEnumerable<string> rules, int angle, int angleDeviation) : base(axiom, rules, angle)
        {
            AngleDeviation = angleDeviation;
        }

        /// <summary>
        /// Ctor.
        /// Отрисовываться будут только литералы, указанные в <param name="forwardLiterals"></param>
        /// </summary>
        /// <param name="axiom">Аксиома.</param>
        /// <param name="rules">Правила.</param>
        /// <param name="angle">Угол поворота.</param>
        /// <param name="angleDeviation">Максимальное отклонение значения угла поворота в градусах относительно заданного значения <param name="angle"></param></param>
        /// <param name="forwardLiterals">Список литералов, для которых будет выполняться отрисовка линии.</param>
        public LSystemWithRandomAngle(string axiom, IEnumerable<string> rules, int angle, int angleDeviation, IEnumerable<char> forwardLiterals) : base(axiom, rules, angle, forwardLiterals)
        {
            AngleDeviation = angleDeviation;
        }

        /// <summary>
        /// Максимальное отклонение значения угла поворота в градусах относительно заданного значения <see cref="LSystem.Angle"/>
        /// </summary>
        public int AngleDeviation { get; }

        /// <summary>
        /// Возвращает случайное зачение угла поворота в градусах с учетом парметра <see cref="AngleDeviation"/>
        /// </summary>
        /// <returns></returns>
        protected override int GetAngle()
        {
            return _random.Next(Angle - AngleDeviation, Angle + AngleDeviation);
        }
    }
}
