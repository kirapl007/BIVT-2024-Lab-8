using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class White_3 : White
    {
        private string _output;

        // саблица кодов  двумерный массив строк [исходное слово, код]
        private string[,] _dictionary;

        public string Output => _output;

        public White_3(string input, string[,] dictionary) : base(input)
        {
            _dictionary = dictionary;
            _output = "";             // результат 
        }

        // метод переопределяет абстрактный метод 
        public override void Review()
        {
            string[] words = Input.Split(' '); // разбиваем входной текст на слова по пробелу

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];   // текущее слово
                string clean = word;      // переменная для чистого слова без знаков

                // удалим начальные и конечные знаки препинания, чтобы сравнить с таблицей
                while (clean.Length > 0 && !char.IsLetter(clean[0]))
                    clean = clean.Substring(1);
                while (clean.Length > 0 && !char.IsLetter(clean[clean.Length - 1]))
                    clean = clean.Substring(0, clean.Length - 1);

                string replacement = null; // переменная для хранения замены если есьб

                // сравниваем каждое слово из таблицы
                for (int j = 0; j < _dictionary.GetLength(0); j++)
                {
                    if (clean == _dictionary[j, 0])
                    {
                        replacement = _dictionary[j, 1]; // нашли замену
                        break;
                    }
                }

                if (replacement != null)
                {
                    // если нашли замену то заменяем в оригинальном слове
                    word = word.Replace(clean, replacement);
                }

                _output += word;

                // добавим пробел после слова кроме последнего
                if (i != words.Length - 1)
                    _output += " ";
            }
        }
        public override string ToString()
        {
            return _output;
        }
    }
}
