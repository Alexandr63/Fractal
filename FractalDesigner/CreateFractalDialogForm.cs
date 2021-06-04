using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Fractal;

namespace FractalDesigner
{
    public partial class CreateFractalDialogForm : Form
    {
        private FractalExt _fractal;

        public CreateFractalDialogForm()
        {
            InitializeComponent();
        }

        public FractalExt Fractal
        {
            get => _fractal;
            set
            {
                _fractal = value;
                UpdateUi();
            }
        }

        private void UpdateUi()
        {
            if (_fractal != null)
            {
                // Аксиома
                _axiomTextBox.Text = _fractal.Axiom;

                // Правила
                string rules = string.Empty;
                foreach (KeyValuePair<char, FractalRule> rule in _fractal.Rules)
                {
                    rules += $"{rule.Value.Literal}->{rule.Value.Rule};";
                }
                rules = rules.TrimEnd(';');
                _rulesTextBox.Text = rules;

                // Интерпритации
                string interpretations = string.Empty;
                foreach (KeyValuePair<char, FractalInterpretation> interpretation in _fractal.Interpretations)
                {
                    interpretations += $"{interpretation.Value.Literal}->";
                    foreach (FractalCommand command in interpretation.Value.Commands)
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
                foreach (KeyValuePair<char, Color> color in _fractal.LiteralColors)
                {
                    literalColors += $"{color.Key}->#{color.Value.R:X2}{color.Value.G:X2}{color.Value.B:X2};";
                }
                literalColors = literalColors.TrimEnd(';');
                _literalColorsTextBox.Text = literalColors;

                // Длина линии
                _lineLengthNumericUpDown.Value = _fractal.LineLength;

                // Толщина линии
                _lineWidthNumericUpDown.Value = _fractal.LineWidth;

                // Цвет по умолчанию
                _colorTextBox.Text = $"#{_fractal.Color.R:X2}{_fractal.Color.G:X2}{_fractal.Color.B:X2}";

                // Стартовая точка
                _startPointTextBox.Text = $"{_fractal.StartPoint.X},{_fractal.StartPoint.Y}";
            }
        }

        private void Save()
        {
            string[] startCoordinates = _startPointTextBox.Text.Trim().Split(',');
            
            int defaultColorArgb = int.Parse($"FF{_colorTextBox.Text.Trim().Replace("#", "")}", NumberStyles.HexNumber);

            _fractal = new FractalExt(_axiomTextBox.Text.Trim(), _rulesTextBox.Text.Trim().Split(';'), _interpretationsTextBox.Text.Trim().Split(';'))
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
                    _fractal.LiteralColors.Add(Convert.ToChar(items[0].Trim()), Color.FromArgb(argb));
                }
            }
        }

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
                MessageBox.Show($"Ошибка при сохранении фрактала. {exception.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CancelButtonClickEventHandler(object sender, EventArgs e)
        {
            Close();
        }
    }
}
