using System;
using System.Linq;
using System.Windows.Forms;
using LSystem;

namespace LSystemDesigner
{
    /// <summary>
    /// Главная форма дизайнера L-систем. Предназначена для отрисовки L-системы.
    /// </summary>
    public partial class LSystemDesignerForm : Form
    {
        private LSystemExt _lSystem;

        /// <summary>
        /// Ctor.
        /// </summary>
        public LSystemDesignerForm()
        {
            InitializeComponent();

            InitializeDefaultLSystem();

            UpdateUi();
        }

        /// <summary>
        /// Загрузка L-системы, кототорый будет отображаться в момент запуска приложения
        /// </summary>
        private void InitializeDefaultLSystem()
        {
            _lSystem = LSystemSource.GetLSystems().First();
        }

        /// <summary>
        /// Обновление состояния UI
        /// </summary>
        private void UpdateUi()
        {
            _generationToolStripLabel.Text = $"Поколение {_lSystem?.Generation ?? 0}";

            _nextGenerationToolStripButton.Enabled = _lSystem != null;
            _resetToolStripButton.Enabled = _lSystem != null;

            _drawPanel.Refresh();
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку 'Редактировать L-систему'
        /// </summary>
        private void EditToolStripButtonClickEventHandler(object sender, EventArgs e)
        {
            EditLSystemDialogForm editDialog = new EditLSystemDialogForm
            {
                LSystem = _lSystem
            };
            if (editDialog.ShowDialog(this) == DialogResult.OK)
            {
                _lSystem = editDialog.LSystem;
            }

            UpdateUi();
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку 'Загрузить L-систему'
        /// </summary>
        private void LoadToolStripButtonClickEventHandler(object sender, EventArgs e)
        {
            LoadLSystemDialog loadDialog = new LoadLSystemDialog();
            if (loadDialog.ShowDialog(this) == DialogResult.OK)
            {
                _lSystem = loadDialog.LSystem;
            }

            if (string.IsNullOrWhiteSpace(_lSystem.Description))
            {
                Text = "Дизайнер L-систем";
            }
            else
            {
                Text = $"Дизайнер L-систем '{_lSystem.Description}'";
            }

            UpdateUi();
        }
        
        /// <summary>
        /// Обработчик события нажатия на кнопку 'Сбросить поколения в 0'
        /// </summary>
        private void ResetToolStripButtonClickEventHandler(object sender, EventArgs e)
        {
            _lSystem?.Reset();

            UpdateUi();
        }
        
        /// <summary>
        /// Обработчик события нажатия на кнопку 'Следующее поколение'
        /// </summary>
        private void NextGenerationToolStripButtonClickEventHandler(object sender, EventArgs e)
        {
            _toolStrip.Enabled = false;
            Application.DoEvents();

            _lSystem.NextGeneration();

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
                _lSystem?.Draw(e.Graphics);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка при отрисовки L-системы. {exception.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
