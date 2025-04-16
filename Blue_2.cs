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
            Output = input;
        }
        public override void Review()
        {
            if (Input == null || Filter == null || Input.Length == 0 || Filter.Length == 0) return;
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
                else if (word.Contains(Filter) & (!char.IsLetter(word[0]) || !char.IsLetter(word[word.Length - 1])))
                {
                    foreach (char simvol in word)
                    {
                        if (!char.IsLetter(simvol)) result += simvol;
                    }
                }
                //если рядом со словом стоит знак препинания, то он отлетает (в случае удаления слова), а тут я его добавляю
            }
            Output = result.Trim(); //Trim удаляет лишние пробелы в начале и в конце строки
            System.Console.WriteLine(Output.Length);
        }
        public override string ToString()
        {
            return Output;
        }
    }
}
