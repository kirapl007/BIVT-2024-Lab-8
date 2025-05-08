using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class White_1 : White
    {
        private int _output;

        public int Output => _output;

        public White_1(string input) : base(input)
        {
            _output = 0;
        }

        public override void Review()
        {
            int words = 0;
            int punctuations = 0;
            int wordCount = 0;
            bool inWord = false;

            foreach (char c in Input)
            {
                if (char.IsLetter(c) || c == '\'' || c == '-')//проверяем является ли символ буквой, апострофом или дефисом
            {
                    if (!inWord)
                    {
                        inWord = true;
                        wordCount++;
                    }
                }
            else
                {
                    inWord = false;
                }
            }

            char[] punctuation = { '.', '!', '?', ',', ':', '"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            int punctuationCount = 0;

            foreach (char c in Input)
            {
                if (Array.IndexOf(punctuation, c) >= 0)// проверка на наличие знака препинания
                                                       // если есть, то возвращает индексб если нет то -1
                    punctuationCount++;
            }

            _output = wordCount + punctuationCount;
        }

        public override string ToString()
        {
            return Output.ToString();
        }
    }

}
