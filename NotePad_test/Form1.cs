using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NotePad_test
{
    public partial class Form1 : Form
    {
        private bool _modifier = true;
        private string _fileName = "";
        private readonly MultiClipboard _bufClipboard;
        private Transliteration _transliteration;

        public Form1()
        {
            InitializeComponent();
            tsOpenTime.Text = DateTime.Now.ToLongTimeString();
            _bufClipboard = new MultiClipboard(tabControl1);
            _icon.Click += new EventHandler(TrayIcon_Clicked);
            _transliteration = new Transliteration(contextMenuStrip1);

            //contextMenuStrip1.Items[0].Text = Cursor.Position.Y - this.Location.Y;
            
        }

        #region File menu Events

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_modifier == false)
            {
                var dl = MessageBox.Show("Файл не збережено, зберегти?", "Попередження", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                switch (dl)
                {
                        case DialogResult.Yes:      saveToolStripMenuItem_Click(sender, e); break;
                        case DialogResult.No:       richTextBox1.Clear(); break;
                        case DialogResult.Cancel:   break;
                }
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                _fileName = saveFileDialog1.FileName;
                this.Text = _fileName;
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _modifier = false;
            if (_fileName == "")
                saveAsToolStripMenuItem_Click(sender, e);
            else
            {
                richTextBox1.SaveFile(_fileName, RichTextBoxStreamType.PlainText);
                _fileName = saveFileDialog1.FileName;
                this.Text = _fileName;
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                _fileName = saveFileDialog1.FileName;
                this.Text = _fileName;
                tsOpenTime.Text = DateTime.Now.ToLongTimeString();
            }
        }
        

        #endregion  

        #region Edit menu Events

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ff = new FindForm(richTextBox1, this);
            ff.Show();
            //var textToFind = ff.TextToFind;
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _bufClipboard.AddBuffer(richTextBox1.SelectedText);
            richTextBox1.SelectedText = "";
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _bufClipboard.AddBuffer(richTextBox1.SelectedText);
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clipboard.Clear();
            richTextBox1.SelectedText = _bufClipboard.ReadfromBuffer();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        } 

        #endregion

        #region Format menu Events

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.WordWrap = !richTextBox1.WordWrap;
        }

        #endregion

        #region View menu Events

        private void showHideBufferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = !tabControl1.Visible;
        }
        private void deleteCurrentBufferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _bufClipboard.DeleteCurrentBuffer();
        }

        #endregion

        #region richTextBox Events

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            _modifier = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tsCurrentTime.Text = DateTime.Now.ToLongTimeString();
        }   
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && e.Control)
                newToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.O && e.Control)
                openToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.S && e.Control)
                saveToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.S && e.Control && e.Shift)
                saveAsToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.F && e.Control)
                findToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.C && e.Control)
                copyToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.X && e.Control)
                cutToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.V && e.Control)
                pasteToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.Delete)
                deleteToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.B && e.Control)
                showHideBufferToolStripMenuItem_Click(sender, e);
            else if (e.KeyCode == Keys.D && e.Control)
                deleteCurrentBufferToolStripMenuItem_Click(sender, e);
        }
        /// <summary>
        /// Выводит текущую позицию каретки в richTextBox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            var pntCursorPosition = new Point
                {
                    X = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1,
                    Y = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine() + 1
                };
            tsCursorPos.Text = string.Format("Line {0}; Col {1}",pntCursorPosition.X, pntCursorPosition.Y);

        }
        
        
        #endregion

        /// <summary>
        /// Сворачивает приложение в трей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = !this.Visible;
                _icon.Icon = Properties.Resources.Notepad;
                _icon.Visible = true;
            }
        }
        /// <summary>
        /// Возвращает приложение из трея
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayIcon_Clicked(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = !this.Visible;
                this.WindowState = FormWindowState.Normal;
                this.Show();
                _icon.Visible = false;
            }
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionStart == richTextBox1.Text.Length)
            {
                contextMenuStrip1.Items[0].Text = "";
                return;
            }

            HighlightWord();

            try
            {
                contextMenuStrip1.Items[0].Text = _transliteration.ChangeTransliteration(richTextBox1.SelectedText);
            }
            catch (Exception) {}
            
        }
        private void HighlightWord()
        {
            int startIndex, endIndex = richTextBox1.SelectionStart;
            startIndex = endIndex;

            while (richTextBox1.Text[startIndex] != ' ' && startIndex != 0)
                startIndex--;
            while (endIndex != richTextBox1.Text.Length && richTextBox1.Text[endIndex] != ' ' && richTextBox1.Text[endIndex] != '\n')
                endIndex++;
            richTextBox1.SelectionStart = startIndex;// (startIndex == 0) ? startIndex : startIndex + 1;
            richTextBox1.SelectionLength = endIndex - startIndex;// (endIndex == richTextBox1.Text.Length) ? endIndex - startIndex : endIndex - startIndex - 1;
        }

        private void transliteraionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1.Items[0].Text == "")
                return;
            else
            {
                richTextBox1.SelectedText = contextMenuStrip1.Items[0].Text;
                contextMenuStrip1.Items[0].Text = "";
            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // hyi
        }
    }
}

