using System.Drawing;
using System.Windows.Forms;

namespace NotePad_test
{
    class MultiClipboard : Form
    {
        private readonly TabControl _control;
        private readonly int _maxCountofBuffers;
        private int _currentCountofBuffers;
        private int _currentIndex;

        public MultiClipboard(TabControl control)
        {
            _maxCountofBuffers = 4;
            _currentIndex = 0;
            _currentCountofBuffers = 0;
            _control = control;
        }

        /// <summary>
        /// Создает буфер и добавляет его в TabControl
        /// </summary>
        /// <param name="text">Выделеный текст из richTextBox</param>
        public void AddBuffer(string text)
        {
            if (_currentCountofBuffers == 0)
                _control.Visible = true;

            if (_currentCountofBuffers < _maxCountofBuffers)
            {
                TabPage tabPage;
                InitializePage(text, out tabPage);
            }
            else
            {
                ChangecontentBuffer(_currentIndex, text);
                _currentIndex++;
                if (_currentIndex == 4)
                    _currentIndex = 0;
            }
        }

        /// <summary>
        /// Создает страницу и добавляет туда textbox
        /// </summary>
        /// <param name="text">Выделеный текст из richTextBox</param>
        /// <param name="tabPage">Текущая страница Буфера</param>
        private void InitializePage(string text, out TabPage tabPage)
        {
            tabPage = new TabPage {Text = Name = ("Buffer" + (_currentCountofBuffers + 1))};

            var textbox = new TextBox
            {
                Text = text,
                Multiline = true,
                Size = new Size(_control.Width,
                                _control.Height),
                ReadOnly = true,
                Name = "textbox"
            };

            _control.Visible = true;

            tabPage.Controls.Add(textbox);
            _control.TabPages.Add(tabPage);
            _control.SelectedTab = tabPage;

            _currentCountofBuffers++;
        }

        /// <summary>
        /// Изменяет содержание уже созданого буфера
        /// </summary>
        /// <param name="index">индекс выбраного буфера</param>
        /// <param name="text">Выделеный текст из richTextBox</param>
        private void ChangecontentBuffer(int index, string text)
        {
            if (_control.TabPages[index].Controls.ContainsKey("textbox"))
            {
                var textBox = (TextBox)_control.TabPages[index].Controls["textbox"];
                textBox.Text = text;
                _control.SelectedTab = _control.TabPages[index];
            }
            else
            {
                MessageBox.Show(@"Error. WTF?");
            }
        }

        public string ReadfromBuffer()
        {
            if (_currentCountofBuffers == 0)
                return "";
            return ((TextBox)_control.TabPages[_control.SelectedIndex].Controls["textbox"]).Text;
        }
        public void DeleteCurrentBuffer()
        {
            if (_currentCountofBuffers == 0)
                return;
            _control.TabPages.Remove(_control.TabPages[_control.SelectedIndex]);
            _currentCountofBuffers--;

            for (int i = 0; i < _currentCountofBuffers; i++)
                _control.TabPages[i].Text = (@"Buffer" + (i + 1)); 
        }
    }
}
;