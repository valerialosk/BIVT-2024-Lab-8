using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        public string[] Output
        {
            get; private set;
        }
        public Blue_1(string input) : base(input) 
        {
            Output = null;
        }
        public override void Review()
        {
            if (Input == null) return;
            string[] words = Input.Split(' ');
            string[] temp = new string[words.Length]; //максимальное количество строк - это количество слов в тексте
            string tempLine = ""; //временная строка, в которую я записываю слова, пока символов меньше, чем 50
            int count = 0; 
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (string.IsNullOrWhiteSpace(word) || string.IsNullOrEmpty(word)) continue;
                if (tempLine.Length == 0) tempLine = word;
                else if ((tempLine.Length + word.Length + 1) <= 50)
                {
                        tempLine += " ";
                        tempLine += word;
                }
                else
                {
                    temp[count] = tempLine;
                    tempLine = word;
                    count++;
                }
            }
            if (!string.IsNullOrEmpty(tempLine))
            {
                temp[count] = tempLine;
                count++; //увеличиваю count, чтобы count показывал в самом конце длину массива
            }
            Output = new string[count];
            for (int i = 0; i < count; i++)
            {
                Output[i] = temp[i];
            }
        }
        public override string ToString()
        {
            if (Output == null) return null;
            string result = "";
            for (int i = 0; i < Output.Length; i++)
            {
                result += $"{Output[i]}";
                if (i < Output.Length - 1)
                {
                    result += Environment.NewLine;
                }
            }
            if (string.IsNullOrEmpty(result)) return null;
            return result;
        }
    }
}
