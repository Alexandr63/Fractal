using System;
using System.Windows.Forms;
using LSystem;

namespace LSystemDesigner
{
    /// <summary>
    /// Форма загрузки L-систем уже созданных в системе
    /// </summary>
    public partial class LoadLSystemDialog : Form
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        public LoadLSystemDialog()
        {
            InitializeComponent();

            foreach (LSystemExt lSystem in LSystemSource.GetLSystems())
            {
                _lSystemsListBox.Items.Add(lSystem);
            }
            
            _lSystemsListBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Выбранная L-система
        /// </summary>
        public LSystemExt LSystem { get; set; }

        /// <summary>
        /// Обработчик события нажатия на кнопку 'Загрузкить'
        /// </summary>
        private void LoadButtonClickEventHandler(object sender, EventArgs e)
        {
            LSystem = (LSystemExt) _lSystemsListBox.SelectedItem;
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
