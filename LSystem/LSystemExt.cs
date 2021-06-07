using System;
using System.Collections.Generic;
using System.Drawing;

namespace LSystem
{
    /// <summary>
    /// Реализация L-системы с раширинными возможностями.
    /// L-система принимет на вход правила и интерпитации с командами для литералов. При наследовании можно реализовать выполнение кастомных команды.
    /// Литералы отделяются от правила в строке правила символами "->".
    /// Литералы отделяются от команды в строке интерпритации символами "->". Интерпритация может сожержать несолкько команд. Команды разделяются симолом ';'.
    /// 
    /// Поддерживаемые команды:
    /// BREAK X - перейти к следующей точке на указанное количество шагов без отрисовки линии.
    /// BREAK - перейти к следующей точке на один шаг без отрисовки линии.
    /// ROTATE X - поворот по часовой стрелке на указанное зачение в градусах
    /// ROTATE -X - поворот против часовой стрелке на указанное зачение в градусах
    /// ROTATE_RANDOM X Y - поворот по часовой стрелке на случайный угол в градусах X + случайное значение от -Y до +Y
    /// ROTATE_RANDOM -X Y - поворот против часовой стрелке на случайный угол в градусах X + случайное значение от -Y до +Y
    /// SAVE - сохранить текущее состояние
    /// RESTORE - восстановить состояние
    /// FORWARD - перейти к следующей точке на один шагc отрисовкой линии.
    /// FORWARD X - перейти к следующей точке на указанное количество шагов c отрисовкой линии.
    /// При необходимост доабвить новые доманды надо унаследоваться от данного класса, переопределить метод <see cref="ExecuteCustomCommand"/> и реализовать в нем обработку новой команды.
    ///
    /// Пример 1:
    /// Аксиома: "F+F+F+F"
    /// Правила: "F->F+f-FF+F+FF+Ff+FF-f+FF-F-FF-Ff-FFF", "f->ffffff"  
    /// Интерпритации: "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90", "f->BREAK
    ///
    /// Пример 2:
    /// Аксиома: "X"
    /// Правила: "F->FF", "X->F[+X]F[-X]+X"
    /// Интерпритации: "F->FORWARD 1", "+->ROTATE_RANDOM 45 20", "-->ROTATE_RANDOM -45 20", "[->SAVE", "]->RESTORE"
    ///
    /// Пример 3:
    /// Аксиома: "A"
    /// Правила: "A->B", "B->AB"
    /// Интерпритации: "A->ROTATE 60;FORWARD 1", "B->ROTATE -60;FORWARD 1" 
    /// </summary>
    public class LSystemExt : ILSystem
    {
        private readonly Random _random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="axiom">Аксиома.</param>
        /// <param name="rules">Правила.</param>
        /// <param name="interpretations">Интерпритации литералов</param>
        public LSystemExt(string axiom, IEnumerable<string> rules, IEnumerable<string> interpretations)
        {
            Axiom = axiom;

            Rules = new Dictionary<char, LSystemRule>();
            foreach (string rule in rules)
            {
                LSystemRule r = new LSystemRule(rule);
                Rules.Add(r.Literal, r);
            }

            Interpretations = new Dictionary<char, LSystemInterpretation>();
            foreach (string interpretation in interpretations)
            {
                LSystemInterpretation i = new LSystemInterpretation(interpretation);
                Interpretations.Add(i.Literal, i);
            }

            ResultString = Axiom;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="axiom">Аксиома.</param>
        /// <param name="rule">Правило.</param>
        /// <param name="interpretations">Интерпритации литералов</param>
        public LSystemExt(string axiom, string rule, IEnumerable<string> interpretations) :
            this(axiom, new[] { rule }, interpretations)
        {
        }

        /// <summary>
        /// Описание L-системы
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Текущая строка L-системы.
        /// </summary>
        public string ResultString { get; private set; }

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
        /// Интерпритации, соответствующие каждому литералу.
        /// </summary>
        public Dictionary<char, LSystemInterpretation> Interpretations { get; }

        /// <summary>
        /// Текущее поколение
        /// </summary>
        public int Generation { get; private set; }

        /// <summary>
        /// Стартовая точка для рисования.
        /// </summary>
        public Point StartPoint { get; set; } = new Point(600, 300);

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

        /// <summary>
        /// Стек с сохраненными состояниями при отрисовки L-системы.
        /// </summary>
        protected Stack<State> States { get; set; } = new Stack<State>();

        /// <summary>
        /// Текущая точка при отрисовке L-системы.
        /// </summary>
        protected Point CurrentPoint { get; set; }

        /// <summary>
        /// Текущй угол при отрисовке L-системы.
        /// </summary>
        protected int CurrentAngle { get; set; }

        /// <summary>
        /// Сбросить состояние L-системы в 0 поколение
        /// </summary>
        public void Reset()
        {
            CurrentPoint = StartPoint;
            CurrentAngle = 0;
            Generation = 0;
            States.Clear();
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

            System.Diagnostics.Debug.WriteLine($"{Generation} - {ResultString}");
        }

        /// <summary>
        /// Нарисовать L-систему в заданный объект <see cref="Graphics"/>.
        /// </summary>
        public void Draw(Graphics g)
        {
            States.Clear();
            CurrentPoint = StartPoint;
            CurrentAngle = 0;

            foreach (char c in ResultString)
            {
                if (Interpretations.ContainsKey(c))
                {
                    Execute(g, Interpretations[c]);
                }
            }
        }

        /// <summary>
        /// Выполнение данной интерпритации для литерала и отрисовка результата в заданный объект <see cref="Graphics"/>.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="interpretation"></param>
        private void Execute(Graphics g, LSystemInterpretation interpretation)
        {
            foreach (LSystemCommand command in interpretation.Commands)
            {
                switch (command.Command)
                {
                    // Перейти в точку без отрисовки линии
                    case "BREAK":
                        if (command.Argument == 0)
                        {
                            // Агруменов нет - переход на один шаг
                            CurrentPoint = DrawHelper.CalcNextPoint(CurrentPoint, LineLength, CurrentAngle);
                        }
                        else
                        {
                            // Переход на заданное количество шагов.
                            for (int i = 0; i < command.Argument; i++)
                            {
                                CurrentPoint = DrawHelper.CalcNextPoint(CurrentPoint, LineLength, CurrentAngle);
                            }
                        }
                        break;
                    // Поворот на заданный угол
                    case "ROTATE":
                        CurrentAngle += command.Argument;
                        break;
                    // Поворот на случайный угол
                    case "ROTATE_RANDOM":
                        CurrentAngle += _random.Next(command.Arguments[0] - command.Arguments[1], command.Arguments[0] + command.Arguments[1]);
                        break;
                    // Сохранить состояние
                    case "SAVE":
                        States.Push(new State(CurrentPoint, CurrentAngle, Color, LineLength, LineWidth));
                        break;
                    // Загрузить состояние
                    case "RESTORE":
                        State state = States.Pop();
                        CurrentAngle = state.Angle;
                        CurrentPoint = state.Point;
                        Color = state.Color;
                        LineLength = state.LineLength;
                        LineWidth = state.LineWidth;
                        break;
                    // Нарисовать линию
                    case "FORWARD":
                        Color cl = Color;
                        if (LiteralColors.ContainsKey(interpretation.Literal))
                        {
                            // Если для литерала цвет задан явно - используем этот цвет
                            cl = LiteralColors[interpretation.Literal];
                        }

                        if (command.Argument == 0)
                        {
                            // Агруменов нет - рисуем линию на один шаг
                            Point nextPoint = DrawHelper.CalcNextPoint(CurrentPoint, LineLength, CurrentAngle);
                            g.DrawLine(new Pen(cl, LineWidth), CurrentPoint, nextPoint);
                            CurrentPoint = nextPoint;
                        }
                        else
                        {
                            // Рисуем линию на заданное количество шагов
                            for (int i = 0; i < command.Argument; i++)
                            {
                                Point nextPoint = DrawHelper.CalcNextPoint(CurrentPoint, LineLength, CurrentAngle);
                                g.DrawLine(new Pen(cl, LineWidth), CurrentPoint, nextPoint);
                                CurrentPoint = nextPoint;
                            }
                        }
                        break;
                    default:
                        // Выполнить кастомную команду
                        ExecuteCustomCommand(g, interpretation.Literal, command);
                        break;
                }
            }
        }

        /// <summary>
        /// Выполнение кастомной команды
        /// </summary>
        /// <param name="g">Объект <see cref="Graphics"/>, в который будет выполняться отрисовка.</param>
        /// <param name="literal">Текущий литерал.</param>
        /// <param name="command">Текущая команда.</param>
        protected virtual void ExecuteCustomCommand(Graphics g, char literal, LSystemCommand command)
        {
        }

        public override string ToString()
        {
            string rules = string.Empty;
            foreach (KeyValuePair<char, LSystemRule> rule in Rules)
            {
                rules += $"{rule.Value.Literal}->{rule.Value.Rule};";
            }
            rules = rules.TrimEnd(';');

            if (string.IsNullOrWhiteSpace(Description))
            {
                return $"Аксиома: '{Axiom}'. Правила: {rules}.";
            }
            else
            {
                return $"Аксиома: '{Axiom}'. Правила: {rules}. {Description}.";
            }
        }
    }
}