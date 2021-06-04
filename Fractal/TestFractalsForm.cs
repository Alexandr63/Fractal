using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fractal
{
    /// <summary>
    /// Тестовая форма для отрисовки фрактала.
    /// NOTE: Бывают проблемы с отрисовкой, когда накапливается ошибка при округлении значений при расчете координат точек. В этом случаии стоит задать другое значение параметра LineLength в фрактале.
    /// </summary>
    public partial class TestFractalsForm : Form
    {
        private IFractal _fractal;

        /// <summary>
        /// Ctor.
        /// </summary>
        public TestFractalsForm()
        {
            InitializeComponent();

            InitializeFractal();
        }

        /// <summary>
        /// Инициализация фрактала.
        /// </summary>
        private void InitializeFractal()
        {
            //// 1 вариант
            //_fractal = new SimpleFractal("F", "F-F++F-F", 60)
            //{
            //    StartPoint = new Point(50, 800)
            //};

            //// 2 вариант(Снежинка Коха)
            //_fractal = new SimpleFractal("F++F++F", "F-F++F-F", 60)
            //{
            //    StartPoint = new Point(50, 243)
            //};

            //// 3 вариант
            //_fractal = new SimpleFractal("F+F+F", "F-F+F", 120)
            //{
            //    StartPoint = new Point(1200, 350)
            //};

            //// 4 вариант
            //_fractal = new SimpleFractal("F+F+F+F", "FF+F++F+F", 90)
            //{
            //    StartPoint = new Point(50, 50)
            //};

            //// 9 вариант
            //_fractal = new SimpleFractal("F+F+F+F", "FF+F+F+F+FF", 90)
            //{
            //    StartPoint = new Point(50, 50)
            //};
            //_fractal = new FractalExt("F+F+F+F", "F->FF+F+F+F+FF", new[] {"F->FORWARD 1", "+->ROTATE 90"})
            //{
            //    StartPoint = new Point(50, 50),
            //    LineLength = 3
            //};

            //// 11 вариант
            //_fractal = new SimpleFractal("F+F+F+F", "F+F-F-FFF+F+F-F", 90)
            //{
            //    StartPoint = new Point(200, 400)
            //};

            //// 12 вариант
            //_fractal = new SimpleFractal("F+F+F+F", "F-FF+FF+F+F-F-FF+F+F-F-FF-FF+F", 90)
            //{
            //    StartPoint = new Point(200, 400)
            //};

            //// 13 вариант
            //_fractal = new SimpleFractal("F", "F-F+F+F-F", 90)
            //{
            //    StartPoint = new Point(50, 800)
            //};

            //// 15 вариант
            //_fractal = new SimpleFractal("F+F+F+F", "F+F-F+F+F", 90)
            //{
            //    StartPoint = new Point(300, 400)
            //};

            //// 16 вариант
            //_fractal = new SimpleFractal("F+F+F+F", "FF+F+F+F+F+F-F", 90)
            //{
            //    StartPoint = new Point(750, 150)
            //};

            //// 21 вариант
            //_fractal = new SimpleFractal("F-F-F-F", "F-F+F+F-F", 90)
            //{
            //    StartPoint = new Point(100, 850)
            //};

            //// 26 вариант
            //_fractal = new SimpleFractal("F+F+F+F", "F+F-F+F+F", 90)
            //{
            //    StartPoint = new Point(200, 300)
            //};

            //_fractal = new SimpleFractal("FF-FF-FF-FF", "FF+FF", 90);

            //_fractal = new SimpleFractal("FF-FFF-FFF-FF", "FF+FF", 90);

            //_fractal = new SimpleFractal("FFF-FF-FF-FFF", "FF+FF", 90);

            //_fractal = new SimpleFractal("FF-FF-FF-FF", "FF+FFF", 90);

            //_fractal = new SimpleFractal("FF-FF-FF-FF", "FF+F", 90);

            //_fractal = new SimpleFractal("FF-FFF-FF-FFF", "F+F-F", 90);

            //_fractal = new SimpleFractal("FF+++F+++FF+++F+++FF+++F+++FF", "FFF----F----FFF----F----FFF", 15);

            //_fractal = new SimpleFractal("FF-FF-FF", "+F-F+", 120)
            //{
            //    LineLength = 10
            //};

            //_fractal = new SimpleFractal("FF-FF-FF", "-F+F-", 120)
            //{
            //    LineLength = 10
            //};

            //_fractal = new SimpleFractal("F-F-F-F", "FF-F+F-F-FF", 90);

            //_fractal = new SimpleFractal("F", "FfF", 0);

            //_fractal = new Fractal("F+F+F+F", new[] {"F->F+f-FF+F+FF+Ff+FF-f+FF-F-FF-Ff-FFF", "f->ffffff"}, 90)
            //{
            //    StartPoint = new Point(50, 700)
            //};
            //_fractal = new FractalExt("F+F+F+F", new[] {"F->F+f-FF+F+FF+Ff+FF-f+FF-F-FF-Ff-FFF", "f->ffffff"}, new[] {"F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90", "f->BREAK"})
            //{
            //    StartPoint = new Point(50, 700),
            //    LineLength = 10
            //};

            //_fractal = new Fractal("F", "F->F+F-F-F+F", 90);

            //// Ковер Серпинского
            //_fractal = new Fractal("F", "F->FFF[+FFF+FFF+FFF]", 90)
            //{
            //    StartPoint = new Point(50, 50),
            //    LineLength = 2
            //};

            //// L - система для кривой Серпинского(вариант 1)
            //_fractal = new Fractal("F-G-G", new[] {"F->F-G+F+G-F", "G->GG"}, 120)
            //{
            //    StartPoint = new Point(50, 700),
            //    //LiteralColors =
            //    //{
            //    //    { 'F', Color.Black },
            //    //    { 'G', Color.Red }
            //    //}
            //};

            //// L - система для кривой Серпинского (вариант 2)
            //_fractal = new Fractal("A", new[] {"A->B-A-B", "B->A+B+A"}, 60)
            //{
            //    StartPoint = new Point(50, 500),
            //    //LiteralColors =
            //    //{
            //    //    {'A', Color.Black},
            //    //    {'B', Color.Red}
            //    //}
            //};
            //// L - система для кривой Серпинского (вариант 2) с различными длинами отрезков для A и B
            //_fractal = new FractalExt("A", new[] { "A->B-A-B", "B->A+B+A" }, new[] { "A->FORWARD 5", "B->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            //{
            //    StartPoint = new Point(50, 500),
            //    LineLength = 10,
            //    LiteralColors =
            //    {
            //        {'A', Color.Black},
            //        {'B', Color.Red}
            //    }
            //};
            //// L - система для кривой Серпинского (вариант 2) с различными длинами отрезков для A и B, при этом отрезок B не отрисовывается
            //_fractal = new FractalExt("A", new[] { "A->B-A-B", "B->A+B+A" }, new[] { "A->FORWARD 5", "B->BREAK 2", "+->ROTATE 60", "-->ROTATE -60" })
            //{
            //    StartPoint = new Point(50, 500),
            //    LineLength = 2
            //};


            //// L - система для дракона Хартера - Хейтвея
            // _fractal = new Fractal("FX", new[] {"X->X+YF", "Y->FX-Y"}, 90, new char[] {'F'})
            //{
            //    StartPoint = new Point(400, 400),
            //    LineLength = 10
            //};

            //// L - система для кривой Госпера
            //_fractal = new Fractal("FL", new[] {"F->", "L->FL-FR--FR+FL++FLFL+FR-", "R->+FL-FRFR--FR-FL++FL+FR"}, 60, new char[] {'F'})
            //{
            //    StartPoint = new Point(600, 700)
            //};
            //_fractal = new FractalExt("FL", new[] {"F->", "L->FL-FR--FR+FL++FLFL+FR-", "R->+FL-FRFR--FR-FL++FL+FR"}, new[] {"F->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60"})
            //{
            //    StartPoint = new Point(600, 700)
            //};

            //_fractal = new Fractal("X", new[] {"F->FF", "X->F[+X]F[-X]+X"}, 20)
            //{
            //    StartPoint = new Point(200, 400),
            //    LineLength = 2
            //};
            //_fractal = new FractalExt("X", new[] {"F->FF", "X->F[+X]F[-X]+X"}, new[] {"F->FORWARD 1", "+->ROTATE 20", "-->ROTATE -20", "[->SAVE", "]->RESTORE"})
            //{
            //    StartPoint = new Point(200, 400),
            //    LineLength = 2
            //};

            //_fractal = new FractalWithRandomAngle("X", new[] {"F->FF", "X->F[+X]F[-X]+X"}, 30, 25)
            //{
            //    StartPoint = new Point(200, 400),
            //    LineLength = 2
            //};
            
            // Дерево с изменениями в линиях и цвете
            //_fractal = new ColoredTreeFractal("X", "X->F[@[-X]+X]", new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE_RANDOM 0 45", "-->ROTATE_RANDOM 0 45", "[->SAVE", "]->RESTORE", "@->CHANGE_TREE" })
            //{
            //    Color = Color.Black,
            //    LineLength = 40,
            //    LineWidth = 10,
            //    StartPoint = new Point(300, 400)
            //};            
            //_fractal = new ColoredTreeFractal("X", "X->F[@[-X]+X]", new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE_RANDOM 10 35", "-->ROTATE_RANDOM -10 35", "[->SAVE", "]->RESTORE", "@->CHANGE_TREE" })
            //{
            //    // переопределяем цвета, теперь коньчики веток будут красные, а остальные линии черные, при этом длина и толщина веток по прежнему будет изменяться
            //    LiteralColors =
            //    {
            //        {'F', Color.Black},
            //        {'X', Color.Red}
            //    },
            //    LineLength = 40,
            //    LineWidth = 10,
            //    StartPoint = new Point(300, 400)
            //};

            //_fractal = new FractalWithRandomAngle("X", new[] {"F->FF", "X->F[+X]F[-X]+X"}, 30, 25)
            //{
            //    LiteralColors =
            //    {
            //        {'F', Color.Black},
            //        {'X', Color.Red}
            //    },
            //    LineLength = 3,
            //    StartPoint = new Point(200, 400)
            //};
            //_fractal = new FractalExt("X", new[] {"F->FF", "X->F[+X]F[-X]+X"}, new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE_RANDOM 45 20", "-->ROTATE_RANDOM -45 20", "[->SAVE", "]->RESTORE" })
            //{
            //    LiteralColors =
            //    {
            //        {'F', Color.Black},
            //        {'X', Color.Red}
            //    },
            //    LineLength = 3,
            //    StartPoint = new Point(200, 400)
            //};

            //_fractal = new Fractal("FX", new[] {"X->FF-[-F]-[+F]", "F->FF+[+F-F]-[-F+F]"}, 25)
            //{
            //    StartPoint = new Point(200, 400)
            //};

            //// Обнаженное дерево Пифагора
            //_fractal = new Fractal("F[+X][-X]", new[] {"X->F[+F[+X][-X]][-F[+X][-X]]", "F->FF"}, 45)
            //{
            //    LiteralColors =
            //    {
            //        {'F', Color.Black},
            //        {'X', Color.Red}
            //    },
            //    StartPoint = new Point(200, 400)
            //};

            //_fractal = new Fractal("F", new[] { "X->X", "F->FF[-F++F][+F--F]++F--F" }, 30)
            //{
            //    LineLength = 5,
            //    StartPoint = new Point(250, 50)
            //};

            //// L - система Algæ
            //_fractal = new FractalExt("A", new[] { "A->B", "B->AB" }, new[] { "A->ROTATE 60,FORWARD 1", "B->ROTATE -60,FORWARD 1" })
            //{
            //    LineLength = 20,
            //    StartPoint = new Point(400, 400)
            //};
        }

        /// <summary>
        /// Обработчик события нажатия кнопки 'Сбросить'
        /// </summary>
        private void ResetButtonClickEventHandler(object sender, EventArgs e)
        {
            // InitializeFractal();
            _fractal.Reset();

            _drawPanel.Refresh();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки 'Следующее поколение'
        /// </summary>
        private void NextGenerationButtonClickEventHandler(object sender, EventArgs e)
        {
            _nextGenerationButton.Enabled = false;
            Application.DoEvents();

            _fractal.NextGeneration();

            _drawPanel.Refresh();

            _nextGenerationButton.Enabled = true;
        }

        /// <summary>
        /// Обработчик события отрисовки панели.
        /// </summary>
        private void DrawPanelPaintEventHandler(object sender, PaintEventArgs e)
        {
            _generationLabel.Text = $"Поколение {_fractal.Generation}";

            // При необходимости можно повернуть изображение
            /*
            if (_generation == 0)
            {
                _fractal.StartPoint = RotatePoint(_fractal.StartPoint, 90, new Point(0, 0));
            }
            e.Graphics.RotateTransform(-90);
            */

            _fractal.Draw(e.Graphics);
        }

        /// <summary>
        /// Возвращает координаты точки после ее поворота на заданный угол вокруг заданной точки.
        /// </summary>
        /// <param name="pointToRotate">Точка, для которую надо повернуть.</param>
        /// <param name="angleInDegrees">Угол поворота.</param>
        /// <param name="centerPoint">Точка, вокруг которой надо повернуть заданную точку.</param>
        /// <returns></returns>
        static Point RotatePoint(Point pointToRotate, double angleInDegrees, Point centerPoint)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point
            {
                X = (int)(cosTheta * (pointToRotate.X - centerPoint.X) - sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                Y = (int)(sinTheta * (pointToRotate.X - centerPoint.X) + cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
            };
        }
    }
}
