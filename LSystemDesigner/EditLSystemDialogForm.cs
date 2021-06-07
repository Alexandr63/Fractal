using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using LSystem;

namespace LSystemDesigner
{
    /// <summary>
    /// форма редактирования L-системы
    /// </summary>
    public partial class EditLSystemDialogForm : Form
    {
        private LSystemExt _lSystem;

        /// <summary>
        /// Ctor.
        /// </summary>
        public EditLSystemDialogForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Отредактированная L-система
        /// </summary>
        public LSystemExt LSystem
        {
            get => _lSystem;
            set
            {
                _lSystem = value;
                UpdateUi();
            }
        }

        /// <summary>
        /// Обновление состояния UI
        /// </summary>
        private void UpdateUi()
        {
            if (_lSystem != null)
            {
                // Аксиома
                _axiomTextBox.Text = _lSystem.Axiom;

                // Правила
                string rules = string.Empty;
                foreach (KeyValuePair<char, LSystemRule> rule in _lSystem.Rules)
                {
                    rules += $"{rule.Value.Literal}->{rule.Value.Rule};";
                }
                rules = rules.TrimEnd(';');
                _rulesTextBox.Text = rules;

                // Интерпритации
                string interpretations = string.Empty;
                foreach (KeyValuePair<char, LSystemInterpretation> interpretation in _lSystem.Interpretations)
                {
                    interpretations += $"{interpretation.Value.Literal}->";
                    foreach (LSystemCommand command in interpretation.Value.Commands)
                    {
                        string arguments = string.Empty;
                        foreach (int arg in command.Arguments)
                        {
                            arguments += $"{arg} ";
                        }

                        arguments = arguments.TrimEnd();

                        interpretations += $"{command.Command} {arguments},";
                    }
                    interpretations = interpretations.TrimEnd(',');
                    interpretations += ";";
                }
                interpretations = interpretations.TrimEnd(';');
                _interpretationsTextBox.Text = interpretations;

                // Цвета литералов
                string literalColors = string.Empty;
                foreach (KeyValuePair<char, Color> color in _lSystem.LiteralColors)
                {
                    literalColors += $"{color.Key}->#{color.Value.R:X2}{color.Value.G:X2}{color.Value.B:X2};";
                }
                literalColors = literalColors.TrimEnd(';');
                _literalColorsTextBox.Text = literalColors;

                // Длина линии
                _lineLengthNumericUpDown.Value = _lSystem.LineLength;

                // Толщина линии
                _lineWidthNumericUpDown.Value = _lSystem.LineWidth;

                // Цвет по умолчанию
                _colorTextBox.Text = $"#{_lSystem.Color.R:X2}{_lSystem.Color.G:X2}{_lSystem.Color.B:X2}";

                // Стартовая точка
                _startPointTextBox.Text = $"{_lSystem.StartPoint.X},{_lSystem.StartPoint.Y}";
            }
        }

        /// <summary>
        /// Прочитать данные из UI и сохраить изменения в классе L-системы
        /// </summary>
        private void Save()
        {
            string[] startCoordinates = _startPointTextBox.Text.Trim().Split(',');
            
            int defaultColorArgb = int.Parse($"FF{_colorTextBox.Text.Trim().Replace("#", "")}", NumberStyles.HexNumber);

            _lSystem = new LSystemExt(_axiomTextBox.Text.Trim(), _rulesTextBox.Text.Trim().Split(';'), _interpretationsTextBox.Text.Trim().Split(';'))
            {
                LineLength = Convert.ToInt32(_lineLengthNumericUpDown.Value),
                LineWidth = Convert.ToInt32(_lineWidthNumericUpDown.Value),
                StartPoint = new Point(int.Parse(startCoordinates[0]), int.Parse(startCoordinates[1])),
                Color = Color.FromArgb(defaultColorArgb)
            };

            if (!string.IsNullOrWhiteSpace(_literalColorsTextBox.Text))
            {
                foreach (string literalWithColor in _literalColorsTextBox.Text.Trim().Split(';'))
                {
                    string[] items = literalWithColor.Split(new[] {"->"}, StringSplitOptions.None);
                    int argb = int.Parse($"FF{items[1].Trim().Replace("#", "")}", NumberStyles.HexNumber);
                    _lSystem.LiteralColors.Add(Convert.ToChar(items[0].Trim()), Color.FromArgb(argb));
                }
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку 'Сохранить'
        /// </summary>
        private void SaveButtonClickEventHandler(object sender, EventArgs e)
        {
            try
            {
                Save();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка при сохранении L-системы. {exception.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку 'Отмена'
        /// </summary>
        private void CancelButtonClickEventHandler(object sender, EventArgs e)
        {
            Close();
        }
    }
}
