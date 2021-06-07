using System;
using System.Linq;
using System.Windows.Forms;
using Fractal;

namespace FractalDesigner
{
    /// <summary>
    /// главная форма дизайнера фрактклов. предназначена для отрисовки фракталов
    /// </summary>
    public partial class FractalDesignerForm : Form
    {
        private FractalExt _fractal;

        /// <summary>
        /// Ctor.
        /// </summary>
        public FractalDesignerForm()
        {
            InitializeComponent();

            InitializeDefaultFractal();

            UpdateUi();
        }

        /// <summary>
        /// Загрузка фрактала, кототорый будет отображаться в момент запуска приложения
        /// </summary>
        private void InitializeDefaultFractal()
        {
            _fractal = FractalSource.GetFractals().First();
        }

        /// <summary>
        /// Обновление состояния UI
        /// </summary>
        private void UpdateUi()
        {
            _generationToolStripLabel.Text = $"Поколение {_fractal?.Generation ?? 0}";

            _nextGenerationToolStripButton.Enabled = _fractal != null;
            _resetToolStripButton.Enabled = _fractal != null;

            _drawPanel.Refresh();
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку 'Редактировать фрактал'
        /// </summary>
        private void EdtiFractalToolStripButtonClickEventHandler(object sender, EventArgs e)
        {
            EditFractalDialogForm editFractalDialog = new EditFractalDialogForm
            {
                Fractal = _fractal
            };
            if (editFractalDialog.ShowDialog(this) == DialogResult.OK)
            {
                _fractal = editFractalDialog.Fractal;
            }

            UpdateUi();
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку 'Загрузить фрактал'
        /// </summary>
        private void LoadToolStripButtonClickEventHandler(object sender, EventArgs e)
        {
            LoadFractalDialog loadFractalDialog = new LoadFractalDialog();
            if (loadFractalDialog.ShowDialog(this) == DialogResult.OK)
            {
                _fractal = loadFractalDialog.Fractal;
            }

            if (string.IsNullOrWhiteSpace(_fractal.Description))
            {
                Text = "Дизайнер фракталов";
            }
            else
            {
                Text = $"Дизайнер фракталов '{_fractal.Description}'";
            }

            UpdateUi();
        }
        
        /// <summary>
        /// Обработчик события нажатия на кнопку 'Сбросить поколения в 0'
        /// </summary>
        private void ResetToolStripButtonClickEventHandler(object sender, EventArgs e)
        {
            _fractal?.Reset();

            UpdateUi();
        }
        
        /// <summary>
        /// Обработчик события нажатия на кнопку 'Следующее поколение'
        /// </summary>
        private void NextGenerationToolStripButtonClickEventHandler(object sender, EventArgs e)
        {
            _toolStrip.Enabled = false;
            Application.DoEvents();

            _fractal.NextGeneration();

            UpdateUi();

            _toolStrip.Enabled = true;
        }

        /// <summary>
        /// Обработчик события отрисовки панели
        /// </summary
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
