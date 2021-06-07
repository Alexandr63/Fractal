using System.Collections.Generic;
using System.Drawing;

namespace LSystem
{
    /// <summary>
    /// Реализация L-системы с одной аксиомой, несколькими правилами, углом поворота.
    /// L-система может принимать команды для рисования линии, перехода в точку без рисования линии, поворота на заданный угол по/против часовой стрелки, сохранением и восстановлением позиции.
    /// Так же можно указать литералы, для которых необходимо рисовать линии (для литералов, которые не будут в этом списке будет изменяться текущая точка без рисования линии.
    /// Литералы отделяются от правила в строке правила символами "->".
    ///
    /// Поддерживаемые команды:
    /// + - поворот по часовой стрелке на угол, который вернет метод <see cref="GetAngle"/>
    /// - - поворот против часовой стрелки на угол, который вернет метод <see cref="GetAngle"/>
    /// [ - сохранить текущее состояние
    /// ] - восстановить состояние
    /// 
    /// Пирмер 1.
    /// Аксиома: "FX"
    /// Правила: "X->X+YF", "Y->FX-Y"
    /// Угол: 90
    ///
    /// Пирмер 2.
    /// Аксиома: "F"
    /// Правила: "F->FFF[+FFF+FFF+FFF]"
    /// Угол: 90
    /// </summary>
    public class LSystem : ILSystem
    {
        #region Ctor.

        /// <summary>
        /// Ctor.
        /// Все литералы, указанные в правилах будут отрисовываться.
        /// </summary>
        /// <param name="axiom">Аксиома.</param>
        /// <param name="rule">Правило.</param>
        /// <param name="angle">Угол поворота в градусах.</param>
        public LSystem(string axiom, string rule, int angle) :
            this(axiom, new[] { rule }, angle)
        {
        }

        /// <summary>
        /// Ctor.
        /// Все литералы, указанные в правилах будут отрисовываться.
        /// </summary>
        /// <param name="axiom">Аксиома.</param>
        /// <param name="rules">Правила.</param>
        /// <param name="angle">Угол поворота в градусах.</param>
        public LSystem(string axiom, IEnumerable<string> rules, int angle)
        {
            Axiom = axiom;

            Rules = new Dictionary<char, LSystemRule>();
            foreach (string rule in rules)
            {
                LSystemRule r = new LSystemRule(rule);
                Rules.Add(r.Literal, r);
            }

            Angle = angle;

            ResultString = Axiom;

            ForwardLiterals = new HashSet<char>(Rules.Keys);
        }

        /// <summary>
        /// Ctor.
        /// Отрисовываться будут только литералы, указанные в <param name="forwardLiterals"></param>
        /// </summary>
        /// <param name="axiom">Аксиома.</param>
        /// <param name="rules">Правила.</param>
        /// <param name="angle">Угол поворота в градусах.</param>
        /// <param name="forwardLiterals">Список литералов, для которых будет выполняться отрисовка линии.</param>
        public LSystem(string axiom, IEnumerable<string> rules, int angle, IEnumerable<char> forwardLiterals) :
            this(axiom, rules, angle)
        {
            ForwardLiterals = new HashSet<char>(forwardLiterals);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Цвета линий соответствущих каждому литералу.
        /// </summary>
        public Dictionary<char, Color> LiteralColors { get; } = new Dictionary<char, Color>();

        /// <summary>
        /// Аксиома.
        /// </summary>
        public string Axiom { get; }

        /// <summary>
        /// Правила, соответствующие каждому литералу.
        /// </summary>
        public Dictionary<char, LSystemRule> Rules { get; }

        /// <summary>
        /// Угол поворота в градусах.
        /// </summary>
        public int Angle { get; }

        /// <summary>
        /// Текущее поколение
        /// </summary>
        public int Generation { get; private set; }

        /// <summary>
        /// Текущая строка L-системы.
        /// </summary>
        public string ResultString { get; private set; }

        /// <summary>
        /// Список литералов, для которых будет выполняться отрисовка линии.
        /// </summary>
        public HashSet<char> ForwardLiterals { get; }

        /// <summary>
        /// Стартовая точка для рисования.
        /// </summary>
        public Point StartPoint { get; set; }

        /// <summary>
        /// Длина линии при рисовании L-системы.
        /// </summary>
        public int LineLength { get; set; } = 10;

        /// <summary>
        /// Толщина линии при рисовании L-системы.
        /// </summary>
        public int LineWidth { get; set; } = 1;

        /// <summary>
        /// Цвет линии при рисовании L-системы.
        /// </summary>
        public Color Color { get; set; } = Color.Blue;

        #endregion

        #region Public Methods


        /// <summary>
        /// Сбросить состояние L-системы в 0 поколение
        /// </summary>
        public void Reset()
        {
            Generation = 0;
            ResultString = Axiom;
        }

        /// <summary>
        /// Сформировать следующее поколение L-системы.
        /// </summary>
        public void NextGeneration()
        {
            string result = string.Empty;

            foreach (char c in ResultString)
            {
                if (Rules.ContainsKey(c))
                {
                    result += Rules[c].Rule;
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
        /// Нарисовать L-систему в заданный объект <see cref="Graphics"/>.
        /// </summary>
        public void Draw(Graphics g)
        {
            Stack<State> states = new Stack<State>();

            Point currentPoint = StartPoint;
            int currentAngle = 0;

            foreach (char c in ResultString)
            {
                switch (c)
                {
                    // Поворот по часовой стрелке
                    case '+':
                        currentAngle += GetAngle();
                        break;
                    // Поворот против часовой стрелки
                    case '-':
                        currentAngle -= GetAngle();
                        break;
                    // Сохранить состояние
                    case '[':
                        states.Push(new State(currentPoint, currentAngle, Color, LineLength, LineWidth));
                        break;
                    // Загрузить состояние
                    case ']':
                        State state = states.Pop();
                        currentAngle = state.Angle;
                        currentPoint = state.Point;
                        Color = state.Color;
                        LineLength = state.LineLength;
                        LineWidth = state.LineWidth;
                        break;
                    default:
                        // Проверяем, что литерал есть в списке на отрисовку
                        if (ForwardLiterals.Contains(c))
                        {
                            // Литерал есть в списке на отрисовку. Задаем цвет линии по умолчанию
                            Color cl = Color;
                            if (LiteralColors.ContainsKey(c))
                            {
                                // Если для литерала цвет задан явно - используем этот цвет
                                cl = LiteralColors[c];
                            }

                            // Рисуем линию
                            Point nextPoint = DrawHelper.CalcNextPoint(currentPoint, LineLength, currentAngle);
                            g.DrawLine(new Pen(cl, LineWidth), currentPoint, nextPoint);
                            currentPoint = nextPoint;
                        }
                        else
                        {
                            // Переходим в следующую точку без отрисовки линии
                            currentPoint = DrawHelper.CalcNextPoint(currentPoint, LineLength, currentAngle);
                        }
                        break;
                }
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Виртуальный метод для получения угла поворота в градусах.
        /// </summary>
        protected virtual int GetAngle()
        {
            return Angle;
        }

        #endregion
    }
}
