using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Numbers;

namespace EvenNumbers
{
    class Number : Numbers.Number
    {
        public override int Value
        {
            get { return this.value; }
            set
            {
                if (value % 2 != 0)
                    this.value -= 1;
                this.value = value;
            }
        }

        public Number(int pValue) : base(pValue) { }
    }
}
