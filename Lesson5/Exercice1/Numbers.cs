using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class Number
    {
        protected int value;

        public virtual int Value { get; set; }

        public Number(int pValue)
        {
            Value = pValue;
        }

        public override string ToString() => Convert.ToString(value);
    }
}
