using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output; //кортеж
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
            _output = new (char, double)[0];
        }
        public override void Review()
        {
            if (Input == null) return;
            char[] letters = {
            'а','б','в','г','д','е','ё','ж','з','и','й',
            'к','л','м','н','о','п','р','с','т','у','ф',
            'х','ц','ч','ш','щ', 'ъ', 'ы', 'ь', 'э','ю','я'};
            int[] counts = new int[letters.Length];
            int total = 0; //количество всех слов
            string[] words = Input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].Trim();
                if (word.Length == 0) continue;
                char first = char.ToLower(word[0]); //ToLower переводит заглавную букву в строчную, используем метод через сам типа char
                for (int j = 0; j < letters.Length; j++)
                {
                    if (first == letters[j])
                    {
                        counts[j]++; 
                        total++;
                        break;
                    }
                }
            }
            var unsorted = new (char, double)[letters.Length];
            int size = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                if (counts[i] > 0)
                {
                    double percent = counts[i] * 100.0 / total; //процент
                    unsorted[size] = (letters[i], percent);
                    size++;
                }
            }
            _output = unsorted.Take(size).OrderByDescending(p => p.Item2).ThenBy(p => p.Item1).ToArray();
        }
        public override string ToString()
        {
            if (_output == null) return null;
            string s = "";
            for (int i = 0; i < _output.Length; i++)
            {
                s += $"{_output[i].Item1}-{_output[i].Item2}";
                if (i < _output.Length - 1) s += "\n";
            }
            return s;
        }
    }
}
