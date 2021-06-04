using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Fractal;

namespace FractalDesigner
{
    public partial class LoadFractalDialog : Form
    {
        public LoadFractalDialog()
        {
            InitializeComponent();


            List<FractalExt> fractals = new List<FractalExt>();
            fractals.Add(new FractalExt("A", new[] { "A->B", "B->AB" }, new[] { "A->ROTATE 60,FORWARD 1", "B->ROTATE -60,FORWARD 1" })
            {
                LineLength = 20,
                StartPoint = new Point(400, 400)
            });

            fractals.Add(new FractalExt("X", new[] { "F->FF", "X->F[+X]F[-X]+X" }, new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE_RANDOM 45 20", "-->ROTATE_RANDOM -45 20", "[->SAVE", "]->RESTORE" })
            {
                LiteralColors =
                {
                    {'F', Color.Black},
                    {'X', Color.Red}
                },
                LineLength = 3,
                StartPoint = new Point(200, 400)
            });

            foreach (FractalExt fractal in GetFractals())
            {
                _fractalsListBox.Items.Add(fractal);
            }
            /*
            _fractalsListBox.Items.Add(fractals[0]);
            _fractalsListBox.Items.Add(fractals[1]);
            */
            _fractalsListBox.SelectedIndex = 0;
        }

        public FractalExt Fractal { get; set; }

        private void LoadButtonClickEventHandler(object sender, EventArgs e)
        {
            Fractal = (FractalExt) _fractalsListBox.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButtonClickEventHandler(object sender, EventArgs e)
        {
            Close();
        }

        private List<FractalExt> GetFractals()
        {
            List<FractalExt> fractals = new List<FractalExt>();

            fractals.Add(new FractalExt("F", "F->F-F++F-F", new[] { "F->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(50, 800),
                Description = "1 вариант"
            });

            fractals.Add(new FractalExt("F++F++F", "F->F-F++F-F", new[] { "F->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(50, 243),
                Description = "2 вариант(Снежинка Коха)"
            });

            fractals.Add(new FractalExt("F+F+F", "F->F-F+F", new[] { "F->FORWARD 1", "+->ROTATE 120", "-->ROTATE -120" })
            {
                StartPoint = new Point(1200, 350),
                Description = "3 вариант"
            });
            
            fractals.Add(new FractalExt("F+F+F+F", "F->FF+F++F+F", new[] { "F->FORWARD 1", "+->ROTATE 90" })
            {
                StartPoint = new Point(50, 50),
                Description = "4 вариант"
            });

            fractals.Add(new FractalExt("F+F+F+F", "F->FF+F+F+F+FF", new[] { "F->FORWARD 1", "+->ROTATE 90" })
            {
                StartPoint = new Point(50, 50),
                Description = "9 вариант"
            });

            fractals.Add(new FractalExt("F+F+F+F", "F->FF+F+F+F+FF", new[] { "F->FORWARD 1", "+->ROTATE 90" })
            {
                StartPoint = new Point(50, 50),
                LineLength = 3
            });

            fractals.Add(new FractalExt("F+F+F+F", "F->F+F-F-FFF+F+F-F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(200, 400),
                Description = "11 вариант"
            });


            fractals.Add(new FractalExt("F+F+F+F", "F->F-FF+FF+F+F-F-FF+F+F-F-FF-FF+F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(200, 400),
                Description = "12 вариант"
            });
            
            fractals.Add(new FractalExt("F", "F->F-F+F+F-F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(50, 800),
                Description = "13 вариант"
            });
            
            fractals.Add(new FractalExt("F+F+F+F", "F->F+F-F+F+F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(300, 400),
                Description = "15 вариант"
            });
            
            fractals.Add(new FractalExt("F+F+F+F", "F->FF+F+F+F+F+F-F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(750, 150),
                Description = "16 вариант"
            });

            fractals.Add(new FractalExt("F-F-F-F", "F->F-F+F+F-F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(100, 850),
                Description = "21 вариант"
            });

            fractals.Add(new FractalExt("F+F+F+F", "F->F+F-F+F+F", new[] { "F->FORWARD 1", "+->ROTATE 90" })
            {
                StartPoint = new Point(200, 300),
                Description = "26 вариант"
            });

            fractals.Add(new FractalExt("FF-FF-FF-FF", "F->FF+FF", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            fractals.Add(new FractalExt("FF-FFF-FFF-FF", "F->FF+FF", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            fractals.Add(new FractalExt("FFF-FF-FF-FFF", "F->FF+FF", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            fractals.Add(new FractalExt("FF-FF-FF-FF", "F->FF+FFF", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            fractals.Add(new FractalExt("FF-FF-FF-FF", "F->FF+F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            fractals.Add(new FractalExt("FF-FFF-FF-FFF", "F->F+F-F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            fractals.Add(new FractalExt("FF+++F+++FF+++F+++FF+++F+++FF", "F->FFF----F----FFF----F----FFF", new[] { "F->FORWARD 1", "+->ROTATE 15", "-->ROTATE -15" }));

            fractals.Add(new FractalExt("FF-FF-FF", "F->+F-F+", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                LineLength = 10
            });

            fractals.Add(new FractalExt("FF-FF-FF", "F->-F+F-", new[] { "F->FORWARD 1", "+->ROTATE 120", "-->ROTATE -120" })
            {
                LineLength = 10
            });

            fractals.Add(new FractalExt("F-F-F-F", "F->FF-F+F-F-FF", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" }));

            fractals.Add(new FractalExt("F", "F->FfF", new[] { "F->FORWARD 1", "f->BREAK 1" }));

            fractals.Add(new FractalExt("F+F+F+F", new[] { "F->F+f-FF+F+FF+Ff+FF-f+FF-F-FF-Ff-FFF", "f->ffffff" }, new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90", "f->BREAK" })
            {
                StartPoint = new Point(200, 200),
                LineLength = 10
            });

            fractals.Add(new FractalExt("F", "F->F+F-F-F+F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(0, 0)
            });

            fractals.Add(new FractalExt("F", "F->FFF[+FFF+FFF+FFF]", new[] { "F->FORWARD 1", "+->ROTATE 90", "[->SAVE", "]->RESTORE" })
            {
                StartPoint = new Point(50, 50),
                LineLength = 2,
                Description = "Ковер Серпинского"
            });

            fractals.Add(new FractalExt("F-G-G", new[] { "F->F-G+F+G-F", "G->GG" }, new[] { "F->FORWARD 1", "G->FORWARD 1","+->ROTATE 120", "-->ROTATE -120" })
            {
                StartPoint = new Point(50, 700),
                LiteralColors =
                {
                    { 'F', Color.Black },
                    { 'G', Color.Red }
                },
                Description = "L - система для кривой Серпинского(вариант 1)"
            });

            fractals.Add(new FractalExt("A", new[] { "A->B-A-B", "B->A+B+A" }, new[] { "A->FORWARD 5", "B->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(50, 500),
                LineLength = 10,
                LiteralColors =
                {
                    {'A', Color.DarkViolet},
                    {'B', Color.DarkBlue}                   
                },
                Description = "L - система для кривой Серпинского (вариант 2)"
            });

            fractals.Add(new FractalExt("A", new[] { "A->B-A-B", "B->A+B+A" }, new[] { "A->FORWARD 5", "B->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(50, 500),
                LineLength = 10,
                LiteralColors =
                {
                    {'A', Color.Black},
                    {'B', Color.Red}
                },
                Description = "L - система для кривой Серпинского (вариант 2) с различными длинами отрезков для A и B"
            });

            fractals.Add(new FractalExt("A", new[] { "A->B-A-B", "B->A+B+A" }, new[] { "A->FORWARD 5", "B->BREAK 2", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(50, 500),
                LineLength = 2,
                Description = "L - система для кривой Серпинского (вариант 2) с различными длинами отрезков для A и B, при этом отрезок B не отрисовывается"
            });

            fractals.Add(new FractalExt("FX", new[] { "X->X+YF", "Y->FX-Y" }, new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(400, 400),
                LineLength = 10,
                Description = "L - система для дракона Хартера - Хейтвея"
            });

            fractals.Add(new FractalExt("FL", new[] { "F->", "L->FL-FR--FR+FL++FLFL+FR-", "R->+FL-FRFR--FR-FL++FL+FR" }, new[] { "F->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(600, 700),
                Description = "L - система для кривой Госпера"
            });

            fractals.Add(new FractalExt("X", new[] { "F->FF", "X->F[+X]F[-X]+X" }, new[] { "F->FORWARD 1", "+->ROTATE 20", "-->ROTATE -20", "[->SAVE", "]->RESTORE" })
            {
                StartPoint = new Point(200, 400),
                LineLength = 2
            });

            fractals.Add(new FractalExt("FFFF", "F->F+F-F+F+F", new[] { "F->FORWARD 1", "+->ROTATE 90", "-->ROTATE -90" })
            {
                StartPoint = new Point(300, 400),
                Description = "вариант"
            });
            
            fractals.Add(new FractalExt("X", new[] { "F->FF", "X->F[+X]F[-X]+X" }, new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE_RANDOM 45 20", "-->ROTATE_RANDOM -45 20", "[->SAVE", "]->RESTORE" })
            {
                LiteralColors =
                {
                    {'F', Color.Black},
                    {'X', Color.Red}
                },
                LineLength = 3,
                StartPoint = new Point(200, 400)
            });

            fractals.Add(new FractalExt("X", new[] { "F->FF", "X->F[+X]F[-X]+X" }, new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE_RANDOM 45 20", "-->ROTATE_RANDOM -45 20", "[->SAVE", "]->RESTORE" })
            {
                LiteralColors =
                {
                    {'F', Color.Black},
                    {'X', Color.Red}
                },
                LineLength = 3,
                StartPoint = new Point(200, 400)
            });

            fractals.Add(new FractalExt("X", new[] { "F->FF", "X->F[+X]F[-X]+X" }, new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE_RANDOM 45 20", "-->ROTATE_RANDOM -45 20", "[->SAVE", "]->RESTORE" })
            {
                LiteralColors =
                {
                    {'F', Color.Black},
                    {'X', Color.Red}
                },
                LineLength = 3,
                StartPoint = new Point(200, 400)
            });

            fractals.Add(new FractalExt("FX", new[] { "X->FF-[-F]-[+F]", "F->FF+[+F-F]-[-F+F]" }, new[] { "F->FORWARD 1", "+->ROTATE 25", "-->ROTATE -25", "[->SAVE", "]->RESTORE" })
            {
                StartPoint = new Point(200, 400)
            });

            fractals.Add(new FractalExt("F[+X][-X]", new[] { "X->F[+F[+X][-X]][-F[+X][-X]]", "F->FF"}, new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE 45", "-->ROTATE -45", "[->SAVE", "]->RESTORE" })
            {
                LiteralColors =
                {
                    {'F', Color.Black},
                    {'X', Color.Red}
                },
                StartPoint = new Point(200, 400),
                Description = " Обнаженное дерево Пифагора"
            });

            fractals.Add(new FractalExt("F", new[] { "X->X", "F->FF[-F++F][+F--F]++F--F" }, new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE 30", "-->ROTATE -30", "[->SAVE", "]->RESTORE" })
            {
                LiteralColors =
                {
                    {'F', Color.Black},
                    {'X', Color.Red}
                },
                LineLength = 5,
                StartPoint = new Point(250, 50)
            });
            
            fractals.Add(new FractalExt("A", new[] { "A->B", "B->AB" }, new[] { "A->ROTATE 60,FORWARD 1", "B->ROTATE -60,FORWARD 1" })
            {
                LineLength = 20,
                StartPoint = new Point(400, 400),
                Description = "L - система Algae"
            });

            fractals.Add(new FractalExt("X", "X->F[@[-X]+X]", new[] { "F->FORWARD 1", "X->FORWARD 1", "+->ROTATE_RANDOM 10 35", "-->ROTATE_RANDOM -10 35", "[->SAVE", "]->RESTORE", "@->CHANGE_TREE" })
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

            return fractals;
        }
    }
}
