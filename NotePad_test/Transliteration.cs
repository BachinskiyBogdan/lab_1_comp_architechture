using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NotePad_test
{
    class Transliteration
    {
        private Dictionary<char, string> _dictionary;
        private Dictionary<string, char> _inversediDictionary;
        private ContextMenuStrip _contextMenu;

        public Transliteration(ContextMenuStrip contextMenuStrip)
        {
            DictionaryInitialize();

            _contextMenu = contextMenuStrip;
        }

        private void DictionaryInitialize()
        {
            var fileStream = new StreamReader("translit.txt");
            _dictionary = new Dictionary<char, string>();
            _inversediDictionary = new Dictionary<string, char>();

            while (!fileStream.EndOfStream)
            {
                var line = fileStream.ReadLine();
                var key = line[0];
                string value = line.Trim('\n', line[0]);
                _dictionary.Add(key, value);
                _inversediDictionary.Add(value, key);
            }
            _dictionary[' '] = " ";
            _inversediDictionary[" "] = ' ';
            fileStream.Close();
        }

        private string RusToLatin(string inputText)
        {
            string result = "";

            foreach (char ch in inputText)
            {
                result += _dictionary[ch];
            }

            return result;
        }

        private string LatinToRus(string inputText)
        {
            string result = "";
            int i = 0;
            if (inputText[0] == ' ')
            {
                i++;
                result += " ";
            }
            for (i = i; i < inputText.Length; i++)
            {
                char value;
                string key = "";
                try
                {
                    key += inputText[i].ToString() + inputText[i + 1].ToString() + inputText[i + 2].ToString();

                    if (_inversediDictionary.TryGetValue(key, out value))
                    {
                        result += value;
                        i += 2;
                        continue;
                    }
                }
                catch (Exception) {}
                try
                {
                    key = "";
                    key += inputText[i].ToString() + inputText[i + 1].ToString();
                    if (_inversediDictionary.TryGetValue(key, out value))
                    {
                        result += value;
                        i += 1;
                        continue;
                    }
                }
                catch (Exception) {}

                key = inputText[i].ToString();
                if (_inversediDictionary.TryGetValue(key, out value))
                {
                    result += value;
                    continue;
                }
            }
             

            return result;
        }

        public string ChangeTransliteration(string inputText)
        {
            string value;
            int i = 0;
            if (inputText[i] == ' ')
                i++;
            if (inputText[i] > 0x400)
                value = RusToLatin(inputText);
            else
                value = LatinToRus(inputText);
            return value;
        }

    }
}
