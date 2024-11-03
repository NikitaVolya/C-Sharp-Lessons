using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Розробіть додаток, який знаходитиме мінімальне і
//    максимальне значення у двовимірному масиві.

namespace Exercice5
{
    internal class Program
    {
        static int min(int[][] nums)
        {
            int rep = nums[0].Min();
            for (int i = 1; i < nums.Length; i++)
            {
                int tmp = nums[i].Min();
                if (tmp < rep)
                    rep = tmp;
            }
            return rep;
        }
        static int max(int[][] nums)
        {
            int rep = nums[0].Max();
            for (int i = 1; i < nums.Length; i++)
            {
                int tmp = nums[i].Max();
                if (tmp > rep)
                    rep = tmp;
            }
            return rep;
        }

        static void Main(string[] args)
        {
            int[][] nums = { new int[]{ 1, 3, 4 }, 
                             new int[] { 0, 10, -2 }, 
                             new int[] {5, 6, 7} };
            Console.WriteLine($"Min: {min(nums)}");
            Console.WriteLine($"Max: {max(nums)}");

            Console.ReadLine();
    }
}
}
