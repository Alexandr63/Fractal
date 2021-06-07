using System.Collections.Generic;
using System.Drawing;
using LSystem;

namespace LSystemDesigner
{
    /// <summary>
    /// Предоставляет список L-систем уже созданных в системе
    /// </summary>
    public static class LSystemSource
    {
        /// <summary>
        /// Возвращает список L-систем уже созданных в системе
        /// </summary>
        /// <returns></returns>
        public static List<LSystemExt> GetLSystems()
        {
            List<LSystemExt> lSystems = new List<LSystemExt>();

            lSystems.Add(new LSystemExt("F", "F->F-F++F-F", new[] { "F->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(50, 800),
                Description = "1 вариант (кривая Коха)"
            });

            lSystems.Add(new LSystemExt("F++F++F", "F->F-F++F-F", new[] { "F->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(50, 243),
                Description = "2 вариант (снежинка Коха)"
            });

            lSystems.Add(new LSystemExt("F+F+F", "F->F-F+F", new[] { "F->FORWARD 1", "+->ROTATE 120", "-->ROTATE -120" })
            {
                StartPoint = new Point(1200, 350),
                Description = "3 вариант"
            });

            lSystems.Add(new LSystemExt("F+F+F+F", "F->FF+F++F+F", new[] { "F->FORWARD 1", "+->ROTATE 90" })
            {
                StartPoint = new Point(50, 50),
                Description = "4 вариант"
            });

            lSystems.Add(new LSystemExt("FX", new[] { "X->X+YF", "Y->FX-Y" }, new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(400, 400),
                LineLength = 10,
                Description = "5 вариант (дракона Хартера - Хейтвея)"
            });

            lSystems.Add(new LSystemExt("XF", new[] { "X->X+YF++YF-FX--FXFX-YF+", "Y->-FX+YFYF++YF+FX--FX-Y" }, new[] { "X->FORWARD 1", "Y->FORWARD 1", "F->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(600, 700),
                Description = "6 вариант (кривая Госпера)"
            });

            lSystems.Add(new LSystemExt("F+XF+F+XF", new[] { "X->XF-F+F-XF+F+XF-F+F-X" }, new[] { "X->FORWARD 1", "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(600, 50),
                Description = "7 вариант (кривая Серпинского)"
            });

            lSystems.Add(new LSystemExt("X", new[] { "X->-YF+XFX+FY-", "Y->+XF-YFY-FX+" }, new[] { "X->FORWARD 1", "Y->FORWARD 1", "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(50, 600),
                Description = "8 вариант (кривая Гильберта)"
            });

            lSystems.Add(new LSystemExt("F+F+F+F", "F->FF+F+F+F+FF", new[] { "F->FORWARD 1", "+->ROTATE 90" })
            {
                StartPoint = new Point(50, 50),
                Description = "9 вариант"
            });

            lSystems.Add(new LSystemExt("F+F+F+F", "F->F+F-F-FF+F+F-F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(200, 400),
                Description = "10 вариант"
            });

            lSystems.Add(new LSystemExt("F+F+F+F", "F->F+F-F-FFF+F+F-F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(200, 400),
                Description = "11 вариант"
            });

            lSystems.Add(new LSystemExt("F+F+F+F", "F->F-FF+FF+F+F-F-FF+F+F-F-FF-FF+F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(200, 400),
                Description = "12 вариант"
            });

            lSystems.Add(new LSystemExt("F", "F->F-F+F+F-F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(50, 800),
                Description = "13 вариант"
            });

            lSystems.Add(new LSystemExt("YF", new[] { "X->YF+XF+Y", "Y->XF-YF-X" }, new[] { "X->FORWARD 1", "Y->FORWARD 1", "F->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(50, 600),
                Description = "14 вариант"
            });

            lSystems.Add(new LSystemExt("F+F+F+F", "F->F+F-F+F+F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(300, 400),
                Description = "15 вариант"
            });

            lSystems.Add(new LSystemExt("F+F+F+F", "F->FF+F+F+F+F+F-F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(750, 150),
                Description = "16 вариант"
            });

            lSystems.Add(new LSystemExt("Y", new[] { "X->X[-FFF][+FFF]FX", "Y->YFX[+Y][-Y]" }, new[] { "X->FORWARD 1", "Y->FORWARD 1", "F->FORWARD 1", "+->ROTATE 25", "-->ROTATE -25", "[->SAVE", "]->RESTORE" })
            {
                StartPoint = new Point(50, 600),
                Description = "17 вариант (куст)"
            });

            lSystems.Add(new LSystemExt("F", new[] { "F->FF+[+F-F-F]-[-F+F+F]" }, new[] { "F->FORWARD 1", "+->ROTATE 22", "-->ROTATE -22", "[->SAVE", "]->RESTORE" })
            {
                StartPoint = new Point(50, 400),
                Description = "18 вариант (куст)"
            });

            lSystems.Add(new LSystemExt("F", new[] { "F->F[+FF][-FF]F[-F][+F]F" }, new[] { "F->FORWARD 1", "+->ROTATE 36", "-->ROTATE -36", "[->SAVE", "]->RESTORE" })
            {
                StartPoint = new Point(50, 400),
                Description = "19 вариант (куст)"
            });

            lSystems.Add(new LSystemExt("X", new[] { "F->FF", "X->F[+X]F[-X]+X" }, new[] { "X->FORWARD 1", "F->FORWARD 1", "+->ROTATE 20", "-->ROTATE -20", "[->SAVE", "]->RESTORE" })
            {
                StartPoint = new Point(50, 600),
                Description = "20 вариант (куст)"
            });

            lSystems.Add(new LSystemExt("F-F-F-F", "F->F-F+F+F-F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(100, 850),
                Description = "21 вариант (куст)"
            });

            lSystems.Add(new LSystemExt("F", new[] { "F->F[+F]F[-F]F" }, new[] { "F->FORWARD 1", "+->ROTATE 25", "-->ROTATE -25", "[->SAVE", "]->RESTORE" })
            {
                StartPoint = new Point(50, 600),
                Description = "22 вариант (сорняк)"
            });

            lSystems.Add(new LSystemExt("F", new[] { "F->FXF", "X->[-F+F+F]+F-F-F+" }, new[] { "X->FORWARD 1", "F->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60", "[->SAVE", "]->RESTORE" })
            {
                StartPoint = new Point(200, 300),
                Description = "23 вариант"
            });

            lSystems.Add(new LSystemExt("FXF--FF--FF", new[] { "F->FF", "X->--FXF++FXF++FXF--" }, new[] { "F->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60", "[->SAVE", "]->RESTORE" })
            {
                StartPoint = new Point(100, 800),
                Description = "24 вариант (треугольник Серпинского)"
            });

            lSystems.Add(new LSystemExt("F", "F->FFF[+FFF+FFF+FFF]", new[] { "F->FORWARD 1", "+->ROTATE 90", "[->SAVE", "]->RESTORE" })
            {
                StartPoint = new Point(50, 50),
                LineLength = 2,
                Description = "25 вариант (ковер Серпинского)"
            });

            lSystems.Add(new LSystemExt("F+F+F+F", "F->F+F-F+F+F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(200, 300),
                Description = "26 вариант"
            });

            lSystems.Add(new LSystemExt("F+F+F+F", "F->FF+F+F+F+F+F-F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(700, 50),
                Description = "27 вариант"
            });

            lSystems.Add(new LSystemExt("F-G-G", new[] { "F->F-G+F+G-F", "G->GG" }, new[] { "F->FORWARD 1", "G->FORWARD 1", "+->ROTATE 120", "-->ROTATE -120" })
            {
                StartPoint = new Point(50, 700),
                LiteralColors =
                {
                    { 'F', Color.Black },
                    { 'G', Color.Red }
                },
                Description = "Треугольник Серпинского(вариант 2)"
            });

            lSystems.Add(new LSystemExt("A", new[] { "A->B-A-B", "B->A+B+A" }, new[] { "A->FORWARD 1", "B->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(50, 500),
                LineLength = 10,
                LiteralColors =
                {
                    {'A', Color.DarkViolet},
                    {'B', Color.DarkBlue}
                },
                Description = "Треугольник Серпинского (вариант 3)"
            });

            lSystems.Add(new LSystemExt("A", new[] { "A->B-A-B", "B->A+B+A" }, new[] { "A->FORWARD 5", "B->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(50, 500),
                LineLength = 10,
                LiteralColors =
                {
                    {'A', Color.Black},
                    {'B', Color.Red}
                },
                Description = "Треугольник Серпинского (вариант 3) с различными длинами отрезков для A и B"
            });

            lSystems.Add(new LSystemExt("A", new[] { "A->B-A-B", "B->A+B+A" }, new[] { "A->FORWARD 5", "B->BREAK 2", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(50, 500),
                LineLength = 2,
                Description = "Треугольник Серпинского (вариант 3) с различными длинами отрезков для A и B, при этом отрезок B не отрисовывается"
            });

            lSystems.Add(new LSystemExt("FL", new[] { "F->", "L->FL-FR--FR+FL++FLFL+FR-", "R->+FL-FRFR--FR-FL++FL+FR" }, new[] { "F->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(600, 700),
                Description = "Кривая Госпера (вариант 2)"
            });

            lSystems.Add(new LSystemExt("F[+X][-X]", new[] { "X->F[+F[+X][-X]][-F[+X][-X]]", "F->FF" }, new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE 45", "-->ROTATE -45", "[->SAVE", "]->RESTORE" })
            {
                LiteralColors =
                {
                    {'F', Color.Black},
                    {'X', Color.Red}
                },
                StartPoint = new Point(200, 400),
                Description = " Обнаженное дерево Пифагора"
            });

            lSystems.Add(new LSystemExt("A", new[] { "A->B", "B->AB" }, new[] { "A->ROTATE 60,FORWARD 1", "B->ROTATE -60,FORWARD 1" })
            {
                LineLength = 20,
                StartPoint = new Point(400, 400),
                Description = "L - система Algae"
            });

            lSystems.Add(new LSystemExt("X", "X->F[@[-X]+X]", new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE_RANDOM 10 35", "-->ROTATE_RANDOM -10 35", "[->SAVE", "]->RESTORE", "@->CHANGE_TREE" })
            {
                LiteralColors =
                {
                    {'F', Color.Black},
                    {'X', Color.Red}
                },
                LineLength = 40,
                StartPoint = new Point(300, 400),
                Description = "Дерево"
            });

            lSystems.Add(new LSystemExt("X", new[] { "F->FF", "X->F[+X]F[-X]+X" }, new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE_RANDOM 45 20", "-->ROTATE_RANDOM -45 20", "[->SAVE", "]->RESTORE" })
            {
                LiteralColors =
                {
                    {'F', Color.Black},
                    {'X', Color.Red}
                },
                LineLength = 3,
                StartPoint = new Point(200, 400),
                Description = "Куст со случаным поворотом веток"
            });

            lSystems.Add(new LSystemExt("F+F+F+F", "F->FF+F+F+F+FF", new[] { "F->FORWARD 1", "+->ROTATE 90" })
            {
                StartPoint = new Point(50, 50),
                LineLength = 3
            });

            lSystems.Add(new LSystemExt("FF-FF-FF", "F->+F-F+", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                LineLength = 10
            });

            lSystems.Add(new LSystemExt("FF-FF-FF", "F->-F+F-", new[] { "F->FORWARD 1", "+->ROTATE 120", "-->ROTATE -120" })
            {
                LineLength = 10
            });

            lSystems.Add(new LSystemExt("F-F-F-F", "F->FF-F+F-F-FF", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            lSystems.Add(new LSystemExt("F", "F->FfF", new[] { "F->FORWARD 1", "f->BREAK 1" }));

            lSystems.Add(new LSystemExt("F+F+F+F", new[] { "F->F+f-FF+F+FF+Ff+FF-f+FF-F-FF-Ff-FFF", "f->ffffff" }, new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90", "f->BREAK" })
            {
                StartPoint = new Point(200, 200),
                LineLength = 10
            });

            lSystems.Add(new LSystemExt("F", "F->F+F-F-F+F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(0, 0)
            });

            lSystems.Add(new LSystemExt("FFFF", "F->F+F-F+F+F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(300, 400),
            });

            lSystems.Add(new LSystemExt("FX", new[] { "X->FF-[-F]-[+F]", "F->FF+[+F-F]-[-F+F]" }, new[] { "F->FORWARD 1", "+->ROTATE 25", "-->ROTATE -25", "[->SAVE", "]->RESTORE" })
            {
                StartPoint = new Point(200, 400)
            });

            lSystems.Add(new LSystemExt("F", new[] { "X->X", "F->FF[-F++F][+F--F]++F--F" }, new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE 30", "-->ROTATE -30", "[->SAVE", "]->RESTORE" })
            {
                LiteralColors =
                {
                    {'F', Color.Black},
                    {'X', Color.Red}
                },
                LineLength = 5,
                StartPoint = new Point(250, 50)
            });

            lSystems.Add(new LSystemExt("FF-FF-FF-FF", "F->FF+FF", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            lSystems.Add(new LSystemExt("FF-FFF-FFF-FF", "F->FF+FF", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            lSystems.Add(new LSystemExt("FFF-FF-FF-FFF", "F->FF+FF", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            lSystems.Add(new LSystemExt("FF-FF-FF-FF", "F->FF+FFF", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            lSystems.Add(new LSystemExt("FF-FF-FF-FF", "F->FF+F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            lSystems.Add(new LSystemExt("FF-FFF-FF-FFF", "F->F+F-F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            lSystems.Add(new LSystemExt("FF+++F+++FF+++F+++FF+++F+++FF", "F->FFF----F----FFF----F----FFF", new[] { "F->FORWARD 1", "+->ROTATE 15", "-->ROTATE -15" }));

            return lSystems;
        }
    }
}
