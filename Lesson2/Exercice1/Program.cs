using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

//створіть додаток, який відображає кількість парних,
//непарних, унікальних елементів масиву.

namespace Exercice1
{


    internal class Program
    {
        static int coupleCount(int[] nums)
        {
            Dictionary<int, int> numsDict = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (numsDict.ContainsKey(num))
                    numsDict[num]++;
                else
                    numsDict[num] = 1;
            }

            int count = 0;
            foreach (KeyValuePair<int, int> entry in numsDict)
            {
                if (entry.Value == 2)
                    count++;
            }

            return count;
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 1, 4, 3, 2, 5, 4, 4 };
            Console.WriteLine(coupleCount(arr));
            Console.ReadLine();
        }

        
    }
}
