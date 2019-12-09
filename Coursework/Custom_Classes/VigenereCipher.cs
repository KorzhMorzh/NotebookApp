﻿using System;
using System.Collections;
using System.Text;

namespace Coursework.Custom_Classes
{
    public class VigenereCipher
    {
        private readonly ArrayList _alphabetLower = new ArrayList
        {
            'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у',
            'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
        };
        private readonly ArrayList _alphabetUpper = new ArrayList()
        {
            'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У',
            'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'
        };
        public string NewText { get; }

        public VigenereCipher(string text, string key, string isEncrypted)
        {
            NewText = isEncrypted == "false" ? Encrypt(text, key) : Decrypt(text, key);
        }

        private string Encrypt(string text, string key)
        {
            StringBuilder newText = new StringBuilder();
            var j = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (key.Length == 0) throw new Exception("Invalid key");
                var indexOfKey = _alphabetLower.IndexOf(key.ToLower()[(i - j) % key.Length]);
                if (indexOfKey == -1) throw new Exception("Invalid key");
                if (_alphabetLower.Contains(text[i]))
                {
                    var indexOfText = _alphabetLower.IndexOf(text[i]);
                    newText.Append(_alphabetLower[(indexOfText + indexOfKey) % 33]);
                }
                else if (_alphabetUpper.Contains(text[i]))
                {
                    var indexOfText = _alphabetUpper.IndexOf(text[i]);
                    newText.Append(_alphabetUpper[(indexOfText + indexOfKey) % 33]);
                }
                else
                {
                    newText.Append(text[i]);
                    j += 1;
                }
            }

            return newText.ToString();
        }

        private string Decrypt(string text, string key)
        {
            

            StringBuilder newText = new StringBuilder();
            var j = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (key.Length == 0) throw new Exception("Invalid key");
                var indexOfKey = _alphabetLower.IndexOf(key.ToLower()[(i - j) % key.Length]);
                if (indexOfKey == -1) throw new Exception("Invalid key");
                if (_alphabetLower.Contains(text[i]))
                {
                    var indexOfText = _alphabetLower.IndexOf(text[i]);
                    newText.Append(_alphabetLower[(33 + indexOfText - indexOfKey) % 33]);
                }
                else if (_alphabetUpper.Contains(text[i]))
                {
                    var indexOfText = _alphabetUpper.IndexOf(text[i]);
                    newText.Append(_alphabetUpper[(33 + indexOfText - indexOfKey) % 33]);
                }
                else
                {
                    newText.Append(text[i]);
                    j += 1;
                }
            }

            return newText.ToString();
        }
    }
}