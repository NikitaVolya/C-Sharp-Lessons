using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Numbers;

namespace PrimeNumbers
{
    
    class PrimeNumber
    {

        static public bool IsPrimeNumber(int number)
        {
            if (number < 0) return false;

            bool[] values = new bool[number];
            for (int i = 0; i < values.Length; i++)
                values[i] = true;

            for (int i = 2; i < values.Length; i++)
            {
                if (values[i])
                {
                    if (number % i == 0)
                    {
                        Console.WriteLine(i);
                        return false;
                    }
                    int j = i + i;
                    while (j < values.Length)
                    {
                        values[j] = false;
                        j += i;
                    }
                }
            }

            return true;
        }
    }

    
}
