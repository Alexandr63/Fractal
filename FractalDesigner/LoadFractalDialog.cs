using System;
using System.Windows.Forms;
using Fractal;

namespace FractalDesigner
{
    /// <summary>
    /// Форма загрузки фракталов уже созданных в системе
    /// </summary>
    public partial class LoadFractalDialog : Form
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public LoadFractalDialog()
        {
            InitializeComponent();

            foreach (FractalExt fractal in FractalSource.GetFractals())
            {
                _fractalsListBox.Items.Add(fractal);
            }
            
            _fractalsListBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Выбранный фрактал
        /// </summary>
        public FractalExt Fractal { get; set; }

        /// <summary>
        /// Обработчик события нажатия на кнопку 'Загрузкить'
        /// </summary>
        private void LoadButtonClickEventHandler(object sender, EventArgs e)
        {
            Fractal = (FractalExt) _fractalsListBox.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
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
