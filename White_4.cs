using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class White_4 : White
    {
        private int _output;

        // Свойство 
        public int Output => _output;

        // Конструктор 
        public White_4(string input) : base(input)
        {
            _output = 0; // результат
        }

        // переопределяем абстрактный метод Review
        public override void Review()
        {

            foreach (char c in Input)
            {
                // проверяем является ли символ цифрой
                if (c >= '0' && c <= '9')
                {
                    _output += c - '0';
                }
            }
        }

        // переопределяем метод для строкового результата
        public override string ToString()
        {
            return _output.ToString();
        }
    }
}
