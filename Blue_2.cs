using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        public string Filter
        {
            get; private set;
        }
        public string Output
        {
            get; private set;
        }
        public Blue_2(string input, string filter) : base(input)
        {
            Filter = filter;
            Output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Filter) || string.IsNullOrEmpty(Input))
            {
                Output = string.Empty;
                return;
            }
            string[] words = Input.Split(' ');
            string result = "";
            string separator = "";
            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word) || string.IsNullOrEmpty(word)) continue;
                if (!word.ToLower().Contains(Filter.ToLower())) //Contains - метод, доступный для всех объектов типа string
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
                if (word.ToLower().Contains(Filter.ToLower()) && word.Length > 0 && !(char.IsLetter(word[word.Length - 1])))
                {
                    result += word[word.Length - 1];
                    separator = " ";
                }
            }
            Output = result;
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Output) || Output.Length == 0) return string.Empty;
            return Output;
        }
    }
}
