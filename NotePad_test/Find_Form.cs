using System;
using System.Windows.Forms;

namespace NotePad_test
{
    public partial class FindForm : Form
    {
        private string _textToFind;
        private readonly Form1 _mainForm;
        private readonly RichTextBox _richTextBox;

        public FindForm(RichTextBox richTextBox, Form1 mainForm)
        {
            InitializeComponent();
            _richTextBox = richTextBox;
            _mainForm = mainForm;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            _textToFind = textBox1.Text;

            if (Down_rb.Checked)
            {
                DownSearch();
            }
            else
            {
                UpSearch();
            } 
            _mainForm.Focus();
        }

        private void ShowErrorMessage()
        {
            MessageBox.Show("Не удается найти \"" + _textToFind + "\"", "Блокнот", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
        private void DownSearch()
        {
            int returnindex;
            int index = _richTextBox.SelectionStart + _richTextBox.SelectedText.Length;

            _richTextBox.SelectionLength = 0;
            //textBox2.Text = string.Format(index + " ; " + _richTextBox.SelectedText.Length + " ; " + _richTextBox.TextLength);

            if (index >= _richTextBox.TextLength - 1)
            {
                ShowErrorMessage();
                return;
            }
            if (Case_chkb.Checked == true)
                returnindex = _richTextBox.Find(_textToFind, index,
                                                RichTextBoxFinds.MatchCase);
            else
                returnindex = _richTextBox.Find(_textToFind, index,
                                                RichTextBoxFinds.None);

            if (returnindex == -1)
                ShowErrorMessage();
        }
        private void UpSearch()
        {
            int returnindex;
            int index = _richTextBox.SelectionStart - _richTextBox.SelectedText.Length;

            //textBox2.Text = string.Format(index + " ; " + _richTextBox.SelectedText.Length);

            if (index < 0)
            {
                ShowErrorMessage();
                return;
            }

            if (Case_chkb.Checked == true)
                returnindex = _richTextBox.Find(_textToFind, 0, index,
                                                RichTextBoxFinds.Reverse | RichTextBoxFinds.MatchCase);
            else
                returnindex = _richTextBox.Find(_textToFind, 0, index,
                                                RichTextBoxFinds.Reverse);
            if (returnindex == -1)
                ShowErrorMessage();
        }
    }
}
