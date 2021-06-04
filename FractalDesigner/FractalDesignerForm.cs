using System;
using System.Drawing;
using System.Windows.Forms;
using Fractal;

namespace FractalDesigner
{
    public partial class FractalDesignerForm : Form
    {
        private FractalExt _fractal;

        public FractalDesignerForm()
        {
            InitializeComponent();

            InitializeDefaultFractal();

            UpdateUi();
        }

        private void InitializeDefaultFractal()
        {
            // L - система для кривой Серпинского (вариант 2) с различными длинами отрезков для A и B
            _fractal = new FractalExt("A", new[] { "A->B-A-B", "B->A+B+A" }, new[] { "A->FORWARD 2", "B->FORWARD 1", "+->ROTATE 60", "-->ROTATE -60" })
            {
                StartPoint = new Point(50, 500),
                LineLength = 2,
                LiteralColors =
                {
                    {'A', Color.Black},
                    {'B', Color.Red}
                }
            };
        }

        private void UpdateUi()
        {
            _generationToolStripLabel.Text = $"Поколение {_fractal?.Generation ?? 0}";

            _nextGenerationToolStripButton.Enabled = _fractal != null;
            _resetToolStripButton.Enabled = _fractal != null;

            _drawPanel.Refresh();
        }

        private void CreateFractalToolStripButtonClickEventHandler(object sender, EventArgs e)
        {
            CreateFractalDialogForm createFractalDialog = new CreateFractalDialogForm
            {
                Fractal = _fractal
            };
            if (createFractalDialog.ShowDialog(this) == DialogResult.OK)
            {
                _fractal = createFractalDialog.Fractal;
            }

            UpdateUi();
        }

        private void LoadToolStripButtonClickEventHandler(object sender, EventArgs e)
        {
            LoadFractalDialog loadFractalDialog = new LoadFractalDialog();
            if (loadFractalDialog.ShowDialog(this) == DialogResult.OK)
            {
                _fractal = loadFractalDialog.Fractal;
            }

            UpdateUi();
        }

        private void ResetToolStripButtonClickEventHandler(object sender, EventArgs e)
        {
            _fractal?.Reset();

            UpdateUi();
        }

        private void NextGenerationToolStripButtonClickEventHandler(object sender, EventArgs e)
        {
            _toolStrip.Enabled = false;
            Application.DoEvents();

            _fractal.NextGeneration();

            UpdateUi();

            _toolStrip.Enabled = true;
        }

        private void DrawPanelPaintEventHandler(object sender, PaintEventArgs e)
        {
            try
            {
                _fractal?.Draw(e.Graphics);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка при отрисовки фрактала. {exception.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
