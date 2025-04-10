using System;
using System.Collections.Generic;
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

    }
}
