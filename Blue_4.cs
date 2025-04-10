using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        public int Output
        {
            get; private set;
        }
        public Blue_4 (string input) : base(input)
        {
            Output = 0;
        }
        public override void Review()
        {
            if (Input == null) return;
            int sum = 0;
            int number = 0; 
            bool flagNumber = false;
            bool flagNegative = false;
            for (int i = 0; i < Input.Length; i++)
            {
                if (i < Input.Length - 1 && Input[i] == '-' && char.IsDigit(Input[i + 1]) == true)
                {
                    flagNegative = true;
                }
                else if (char.IsDigit(Input[i]))
                {
                    number = number * 10 + (Input[i] - '0');
                    flagNumber = true;
                }
                else if (flagNumber == true)
                {
                    if (flagNegative == true) number = -number;
                    sum += number;
                    number = 0;
                    flagNumber = false;
                    flagNegative = false;
                }
            }
            if (flagNumber == true)
            {
                if (flagNegative == true)
                {
                    sum += -number;
                }
                else
                {
                    sum += number;
                }
            }
            Output = sum;
        }
        public override string ToString()
        {
            string str = $"{Output}";
            return str;
        }
    }
}
