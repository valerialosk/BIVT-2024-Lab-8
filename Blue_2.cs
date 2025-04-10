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
            if (Output == null) return;
            string[] words = Input.Split(' ');
            string result = "";
            foreach (string word in words)
            {
                if (!word.Contains(Filter)) //Contains - метод, доступный для всех объектов типа string
                {
                    if (result.Length > 0)
                    {
                        result += " ";
                    }
                    result += word;
                }
            }
            Output = result.Trim(); //Trim удаляет лишние пробелы в начале и в конце строки
        }
        public override string ToString()
        {
            return Output;
        }
    }
}
