using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class White_2 : White
    {
        private int[,] _output;

        public object Output => _output;

        public White_2(string input) : base(input)
        {
            _output = new int[0, 0]; // нач значение
        }
        public override void Review()
        {
            int[,] result = new int[20, 2]; // [кол-во слогов, сколько таких слов]
            int i = 0;

            while (i < Input.Length)
            {
                // пропуск всего, что не часть слова
                while (i < Input.Length && !IsLetterOrValidChar(Input[i]))
                    i++;

                int syllables = 0;
                bool hasVowel = false;

                // читаем слово
                while (i < Input.Length && IsLetterOrValidChar(Input[i]))
                {
                    if (IsVowel(Input[i]))
                    {
                        syllables++;
                        hasVowel = true;
                    }
                    i++;
                }

                if (!hasVowel)
                    syllables = 1;

                if (syllables > 0 && syllables < 20)
                {
                    result[syllables, 0] = syllables;
                    result[syllables, 1]++;
                }
            }

            // подсчет непустых строк
            int count = 0;
            for (int j = 0; j < 20; j++)
            {
                if (result[j, 1] > 0)
                    count++;
            }

            int[,] final = new int[count, 2];
            int index = 0;
            for (int j = 0; j < 20; j++)
            {
                if (result[j, 1] > 0)
                {
                    final[index, 0] = result[j, 0];
                    final[index, 1] = result[j, 1];
                    index++;
                }
            }

            _output = final;
        }

        public override string ToString()
        {
            int[,] res = (int[,])_output;
            string result = "";
            for (int i = 0; i < res.GetLength(0); i++)
            {
                result += $"{res[i, 0]} - {res[i, 1]}";
                if (i != res.GetLength(0) - 1)
                    result += "\n";
            }
            return result;
        }

        private bool IsLetterOrValidChar(char c)
        {
            return char.IsLetter(c) || c == '\'' || c == '-';
        }

        private bool IsVowel(char c)
        {
            return "aeiouyаеёиоуыэюяAEIOUYАЕЁИОУЫЭЮЯ".IndexOf(c) >= 0;
        }
    }

}
