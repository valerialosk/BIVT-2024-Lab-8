using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output; //массив кортежей
        public (char, double)[] Output
        {
            get
            {
                if (_output == null) return null;
                (char, double)[] copy = new (char, double)[_output.Length];
                Array.Copy(_output, copy, _output.Length);
                return copy;
            }
        }
        public Blue_3(string input) : base(input) 
        {
            _output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }
            char[] znak = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            string[] words = Input.Split(znak, StringSplitOptions.RemoveEmptyEntries);
            int[] counts = new int[char.MaxValue]; //считаю буквы
            int total = 0; //количество всех слов
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (word.Length == 0) continue;
                char first = char.ToLower(word[0]);
                if (char.IsLetter(word[0]) == true)
                {
                    counts[first]++;
                    total++;
                }
            }
            int unique = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    unique++;
                }
            }
            _output = new (char, double)[unique];
            int ind = 0;
            for (int i = 0; i < counts.Length; ++i)
            {
                if (counts[i] > 0)
                {
                    double result = Math.Round(counts[i] * 100.0 / total, 4);
                    _output[ind] = ((char)i, result);
                    ind++;
                }
            }
            Array.Sort(_output,(i, j) =>
            {
                int procent = j.Item2.CompareTo(i.Item2);
                if (procent != 0)
                {
                    return procent;
                }
                else
                {
                    return i.Item1.CompareTo(j.Item1);
                }
            });
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return "";
            var s = new StringBuilder();
            for (int i = 0; i < _output.Length; i++)
            {
                s.Append($"{_output[i].Item1} - {(_output[i].Item2):F4}"); // поправила исходя из теста 6 ожидаемый результат идет в формате целая часть и 4 символа после запятой
                if (i < _output.Length - 1) s.AppendLine();
            }
            return s.ToString();
        }
    }
}
