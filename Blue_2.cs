using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _filter;
        public Blue_2(string input, string filter) : base(input)
        {
            _filter = filter;
            _output = null;
        }
        public string Output => _output;
        public string Filter => _filter;
        public override void Review()
        {
            if (string.IsNullOrEmpty(_filter) || string.IsNullOrEmpty(Input)) return;

            string[] words = Input.Split(' ');
            string result = "";
            string separator = "";
            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word) || string.IsNullOrEmpty(word)) continue;
                if (!word.ToLower().Contains(_filter.ToLower())) //Contains - метод, доступный для всех объектов типа string
                {
                    result += separator;
                    result += word;
                    separator = " ";
                }
                else if (word.Length > 0 && !char.IsLetter(word[0]))
                {
                    result += " " + word[0] + word[0];
                    separator = " ";
                }
                if (word.ToLower().Contains(_filter.ToLower()) && word.Length > 0 && !(char.IsLetter(word[word.Length - 1])))
                {
                    result += word[word.Length - 1];
                    separator = " ";
                }
            }
            _output = result;
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(_output) || _output.Length == 0) return string.Empty;
            return _output;
        }
    }
}
