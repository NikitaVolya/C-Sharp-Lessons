using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Numbers;

namespace NotEvenNumbers
{
    class Number : Numbers.Number
    {
        public override int Value 
        {
            get { return this.value; }
            set
            {
                if (value % 2 == 0)
                    value -= 1;
                this.value = value;
            }
        }

        public Number(int pValue) : base(pValue) {}
    }
}
